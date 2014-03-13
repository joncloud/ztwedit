using System.Collections.Generic;
using System.Windows.Forms;

namespace JonCloud.Ztwedit
{
    /// <summary>
    /// Provides an interface to the main menu.
    /// </summary>
    public interface IMainMenu
    {
        /// <summary>
        /// Gets the currently active view; if no view is active null is returned.
        /// </summary>
        IView ActiveView { get; set; }

        /// <summary>
        /// Gets the instance of the main menu's form.
        /// </summary>
        Form Form { get; }

        /// <summary>
        /// Gets a reference to the ROM instance.
        /// </summary>
        Rom Rom { get; }

        /// <summary>
        /// Gets a collection of views that are open.
        /// </summary>
        IEnumerable<IView> Views { get; }

        /// <summary>
        /// Closes a view.
        /// </summary>
        bool Close(IView view);

        /// <summary>
        /// Gets a menu item from the button bar by name.
        /// </summary>
        IMenuItem GetButtonItem(string name);

        /// <summary>
        /// Gets a menu item from the menu bar by path.
        /// </summary>
        IMenuItem GetMenuItem(string path);

        /// <summary>
        /// Show a view.
        /// </summary>
        void Show(IView view);
    }
}
