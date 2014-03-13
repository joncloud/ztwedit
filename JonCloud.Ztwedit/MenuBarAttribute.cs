using System;
using System.ComponentModel.Composition;

namespace JonCloud.Ztwedit
{
    /// <summary>
    /// Describes an item that will appear on the menu bar.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    [MetadataAttribute]
    public class MenuBarAttribute : Attribute, IMenuBarItem
    {
        public MenuBarAttribute(string menuPath)
            : this(menuPath, true, true)
        {
        }

        public MenuBarAttribute(string menuPath, bool enabled, bool visible)
        {
            this.MenuEnabled = enabled;
            this.MenuPath = menuPath;
            this.MenuPaths = menuPath.Split('\\');
            this.MenuVisible = visible;
        }

        /// <summary>
        /// Gets or sets whether or not the menu item is initially enabled.
        /// </summary>
        public bool MenuEnabled { get; private set; }

        /// <summary>
        /// Gets or sets whether or not this menu item begins a group.
        /// </summary>
        public bool MenuBeginGroup { get; set; }

        /// <summary>
        /// Gets or sets the name of the image to render for this menu item.
        /// </summary>
        public string MenuImage { get; set; }

        /// <summary>
        /// Gets or sets the order in which this menu item will appear.
        /// </summary>
        public int MenuOrder { get; set; }

        /// <summary>
        /// Gets or sets the full path to this menu item (i.e., &File\&Open).
        /// </summary>
        public string MenuPath { get; private set; }

        /// <summary>
        /// Gets an array of the available menu path components.
        /// </summary>
        public string[] MenuPaths { get; private set; }

        /// <summary>
        /// Gets or sets whether or not this menu item is initially visible.
        /// </summary>
        public bool MenuVisible { get; private set; }
    }
}
