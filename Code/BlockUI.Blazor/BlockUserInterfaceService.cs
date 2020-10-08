using System;
using Microsoft.JSInterop;

namespace BlockUI.Blazor
{
    class BlockUserInterfaceService 
        : IBlockUserInterfaceService
    {
        public event Action<object> OnBlock;
        public event Action<object> OnUnblock;

        private readonly IJSRuntime _jsRuntime;
        private readonly IBlockInternalService _namedDomElements;

        public string ElementId { get; } = $"BlockUI-{Guid.NewGuid():N}";

        public BlockUserInterfaceService(IJSRuntime jsRuntime, IBlockInternalService namedDomElements)
        {
            _jsRuntime = jsRuntime
                ?? throw new ArgumentNullException(nameof(jsRuntime));
            _namedDomElements = namedDomElements
                ?? throw new ArgumentNullException(nameof(namedDomElements));
        }

        public void Block(string message = null)
        {
            _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.block",
                ElementId,
                message
            );
            OnBlock?.Invoke(this);
        }

        public void BlockWithDomElement(string elementName)
        {
            if (!_namedDomElements.TryGetValue(elementName, out string messageElementId))
                throw new Exception($"Blazor component '{nameof(BlockUserInterfaceMessage)}' with name '{elementName}' is not found.");

            _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.blockWithDomElement",
                ElementId,
                messageElementId
            );
            OnBlock?.Invoke(this);
        }

        public void Unblock()
        {
            _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.unblock",
                ElementId
            );
            OnUnblock?.Invoke(this);
        }

        public void BlockPage(string message = null)
        {
            _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.blockUI",
                message
            );
            OnBlock?.Invoke(this);
        }

        public void BlockPageWithDomElement(string elementName)
        {
            if (!_namedDomElements.TryGetValue(elementName, out string elementReference))
                throw new Exception($"Blazor component '{nameof(BlockUserInterfaceMessage)}' with name '{elementName}' is not found.");

            _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.blockUIWithDomElement",
                elementReference
            );
            OnBlock?.Invoke(this);
        }
        
        public void UnblockPage()
        {
            _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.unblockUI"
            );
            OnBlock?.Invoke(this);
        }
    }
}