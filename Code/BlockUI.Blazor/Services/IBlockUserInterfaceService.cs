using System;
using System.Threading.Tasks;

namespace BlockUI.Blazor.Services
{
    public interface IBlockUserInterfaceService
    {
        #region Events

        /// <summary>
        /// A event that will be invoked when blocking the user interface
        /// </summary>
        event Action<object> OnBlock;
        /// <summary>
        /// A event that will be invoked when unblocking the user interface
        /// </summary>
        event Action<object> OnUnblock;

        #endregion

        #region Block Element

        /// <summary>
        /// Blocks all <see cref="BlockUserInterface"/> components on the page.
        /// </summary>
        /// <param name="message">Text message shown on block.</param>
        Task Block(string message = null);

        /// <summary>
        /// Blocks specified <paramref name="elementId"/> component on the page.
        /// </summary>
        /// <param name="elementId">A unique ID of the DOM element that is used to block screen.</param>
        /// <param name="message">Text message shown on block.</param>
        Task BlockElement(string elementId, string message = null);

        /// <summary>
        /// Blocks specified <paramref name="element"/> component on the page.
        /// </summary>
        /// <param name="element">A reference to component used to block screen.</param>
        /// <param name="message">Text message shown on block.</param>
        Task BlockElement(BlockUserInterface element, string message = null);

        #endregion

        #region Block Element with DOM element

        /// <summary>
        /// Blocks a part of the using DOM element of a page as display message.
        /// </summary>
        /// <param name="elementName">The name of <see cref="BlockUserInterfaceMessage"/> element.</param>
        Task BlockWithDomElement(string elementName);

        /// <summary>
        /// Blocks specified <see cref="BlockUserInterface"/> component on the page using DOM element of a page as display message.
        /// </summary>
        /// <param name="elementId">A unique ID of the DOM element that is used to block screen.</param>
        /// <param name="elementName">The name of <see cref="BlockUserInterfaceMessage"/> element.</param>
        Task BlockElementWithDomElement(string elementId, string elementName);

        /// <summary>
        /// Blocks specified <see cref="BlockUserInterface"/> component on the page using DOM element of a page as display message.
        /// </summary>
        /// <param name="element">A reference to component used to block screen.</param>
        /// <param name="elementName">The name of <see cref="BlockUserInterfaceMessage"/> element.</param>
        Task BlockElementWithDomElement(BlockUserInterface element, string elementName);

        #endregion

        #region Unblock Elements

        /// <summary>
        /// Unblocks all <see cref="BlockUserInterface"/> component on the page.
        /// </summary>
        Task Unblock();

        /// <summary>
        /// Unblocks specified <see cref="BlockUserInterface"/> component on the page.
        /// </summary>
        /// <param name="elementId">A unique ID of the DOM element that is used to block screen.</param>
        Task Unblock(string elementId);

        /// <summary>
        /// Unblocks specified <see cref="BlockUserInterface"/> component on the page.
        /// </summary>
        /// <param name="element">A reference to component used to block screen.</param>
        Task Unblock(BlockUserInterface element);

        #endregion

        #region Block Page

        /// <summary>
        /// Blocks the whole page.
        /// </summary>
        Task BlockPage(string message = null);

        /// <summary>
        /// Blocks the whole page using DOM element of a page as display message.
        /// </summary>
        Task BlockPageWithDomElement(string elementName);

        /// <summary>
        /// Unblocks the whole page.
        /// </summary>
        Task UnblockPage();

        #endregion
    }
}