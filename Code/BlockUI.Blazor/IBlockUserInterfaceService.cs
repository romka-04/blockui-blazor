using System;

namespace BlockUI.Blazor
{
    public interface IBlockUserInterfaceService
    {
        /// <summary>
        /// A event that will be invoked when blocking the user interface
        /// </summary>
        event Action<object> OnBlock;
        /// <summary>
        /// A event that will be invoked when unblocking the user interface
        /// </summary>
        event Action<object> OnUnblock;

        /// <summary>
        /// The ID of the DOM element that is used to block screen
        /// </summary>
        string ElementId { get; }

        /// <summary>
        /// Blocks a part of the window.
        /// </summary>
        void Block();

        /// <summary>
        /// Unblocks a part of the window.
        /// </summary>
        void Unblock();
    }
}