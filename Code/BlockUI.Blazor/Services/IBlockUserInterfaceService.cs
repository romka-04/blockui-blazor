using System;

namespace BlockUI.Blazor.Services
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
        /// Blocks a part of the page.
        /// </summary>
        /// <param name="message"></param>
        void Block(string message = null);

        /// <summary>
        /// Blocks a part of the using DOM element of a page as display message.
        /// </summary>
        /// <param name="elementName">The name of <see cref="BlockUserInterfaceMessage"/> element.</param>
        void BlockWithDomElement(string elementName);

        /// <summary>
        /// Unblocks a part of the page.
        /// </summary>
        void Unblock();

        /// <summary>
        /// Blocks the whole page.
        /// </summary>
        void BlockPage(string message = null);

        /// <summary>
        /// Blocks the whole page using DOM element of a page as display message.
        /// </summary>
        void BlockPageWithDomElement(string elementName);

        /// <summary>
        /// Unblocks the whole page.
        /// </summary>
        void UnblockPage();
    }
}