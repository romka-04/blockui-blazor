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

        public string ElementId { get; } = $"BlockUI-{Guid.NewGuid():N}";

        public BlockUserInterfaceService(IJSRuntime jsRuntime)
        {
            this._jsRuntime = jsRuntime
                ?? throw new ArgumentNullException(nameof(jsRuntime));
        }

        public void Block()
        {
            Console.WriteLine("Block in service");

            _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.block",
                ElementId
            );
            OnBlock?.Invoke(this);
        }

        public void Unblock()
        {
            Console.WriteLine("unlock in service");

            _jsRuntime.InvokeVoidAsync(
                "blockUserInterfaceWrapper.unblock",
                ElementId
            );
            OnUnblock?.Invoke(this);
        }
    }
}