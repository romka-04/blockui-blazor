using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace BlockUI.Blazor.Services
{
    class IdentityPoolBlockUserInterfaceService
        : IBlockUserInterfaceService
    {
        public event Action<object> OnBlock;
        public event Action<object> OnUnblock;

        private readonly IJSRuntime _jsRuntime;
        private readonly IBlockInternalService _namedDomElements;
        private readonly IIdentityPool _identityPool;

        public IdentityPoolBlockUserInterfaceService(IJSRuntime jsRuntime, IBlockInternalService namedDomElements, IIdentityPool identityPool)
        {
            _jsRuntime = jsRuntime
                ?? throw new ArgumentNullException(nameof(jsRuntime));
            _namedDomElements = namedDomElements
                ?? throw new ArgumentNullException(nameof(namedDomElements));
            _identityPool = identityPool
                ?? throw new ArgumentNullException(nameof(identityPool));
        }

        #region Block Element

        public async Task Block(string message = null)
        {
            var elements = _identityPool.GetAllIdentities();
            var tasks = elements.Select(e => BlockElement(e, message)).ToArray();
            await Task.WhenAll(tasks);
        }

        public async Task BlockElement(string elementId, string message = null)
        {
            await _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.block",
                elementId,
                message
            );
            OnBlock?.Invoke(this);
        }

        public async Task BlockElement(BlockUserInterface element, string message = null)
        {
            if (null == element) throw new ArgumentNullException(nameof(element));

            await BlockElement(element.ElementId, message);
        }

        #endregion

        #region Block Element with DOM element

        public async Task BlockWithDomElement(string elementName)
        {
            var elements = _identityPool.GetAllIdentities();
            var tasks = elements.Select(e => BlockElementWithDomElement(e, elementName)).ToArray();
            await Task.WhenAll(tasks);
        }

        public async Task BlockElementWithDomElement(string elementId, string elementName)
        {
            if (!_namedDomElements.TryGetValue(elementName, out string messageElementId))
                throw new Exception($"Blazor component '{nameof(BlockUserInterfaceMessage)}' with name '{elementName}' is not found.");

            await _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.blockWithDomElement",
                elementId,
                messageElementId
            );
            OnBlock?.Invoke(this);
        }

        public async Task BlockElementWithDomElement(BlockUserInterface element, string elementName)
        {
            await BlockElementWithDomElement(element.ElementId, elementName);
        }

        #endregion

        #region Unblock Elements

        public async Task Unblock()
        {
            var elements = _identityPool.GetAllIdentities();
            var tasks = elements.Select(Unblock).ToArray();
            await Task.WhenAll(tasks);
        }

        public async Task Unblock(string elementId)
        {
            await _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.unblock",
                elementId
            );
            OnUnblock?.Invoke(this);
        }

        public async Task Unblock(BlockUserInterface element)
        {
            await Unblock(element.ElementId);
        }

        #endregion

        #region Block Page

        public async Task BlockPage(string message = null)
        {
            await _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.blockUI",
                message
            );
            OnBlock?.Invoke(this);
        }

        public async Task BlockPageWithDomElement(string elementName)
        {
            if (!_namedDomElements.TryGetValue(elementName, out string elementReference))
                throw new Exception($"Blazor component '{nameof(BlockUserInterfaceMessage)}' with name '{elementName}' is not found.");

            await _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.blockUIWithDomElement",
                elementReference
            );
            OnBlock?.Invoke(this);
        }

        public async Task UnblockPage()
        {
            await _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.unblockUI"
            );
            OnBlock?.Invoke(this);
        }

        #endregion
    }
}