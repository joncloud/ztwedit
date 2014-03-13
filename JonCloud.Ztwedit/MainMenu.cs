using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition.Hosting;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using JonCloud.Ztwedit.Properties;

namespace JonCloud.Ztwedit
{
    /// <summary>
    /// The main menu for the application.
    /// </summary>
    public partial class MainMenu : Form, IMainMenu
    {
        private Dictionary<string, IMenuItem> buttonItems = new Dictionary<string, IMenuItem>();
        private Dictionary<string, IMenuItem> menuItems = new Dictionary<string, IMenuItem>();
        private Dictionary<IView, TabPage> views = new Dictionary<IView, TabPage>();

        public MainMenu()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets the currently active view; if no view is active null is returned.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IView ActiveView
        {
            get
            {
                IView view = null;
                if (this.tabControl.SelectedTab != null)
                {
                    view = (this.tabControl.SelectedTab.Controls[0] as IView);
                }
                return view;
            }
            set
            {
                TabPage page;
                if (!this.views.TryGetValue(value, out page))
                {
                    return;
                }

                this.tabControl.SelectedTab = page;
            }
        }

        /// <summary>
        /// Gets the instance of the main menu's form.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Form Form { get { return this; } }

        /// <summary>
        /// Gets a reference to the ROM instance.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Rom Rom { get; private set; }

        /// <summary>
        /// Gets a collection of views that are open.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IEnumerable<IView> Views { get { return this.views.Keys; } }

        /// <summary>
        /// Adds buttons from the composition container.
        /// </summary>
        private void AddButtons(CompositionContainer container)
        {
            // Find all button bar items, and order them by order/tooltip.
            foreach (var buttonBarItem in container.GetExports<IWorker, IButtonBarItem>()
                                                   .OrderBy(l => l.Metadata.ButtonOrder)
                                                   .ThenBy(l => l.Metadata.ToolTip))
            {
                // Add a separator if this button begins the group.
                if (buttonBarItem.Metadata.ButtonBeginGroup)
                {
                    this.toolStrip1.Items.Add(new ToolStripSeparator());
                }

                // Create the button.
                var buttonItem = new ToolStripButton()
                {
                    Enabled = buttonBarItem.Metadata.ButtonEnabled,
                    Tag = buttonBarItem,
                    ToolTipText = buttonBarItem.Metadata.ToolTip,
                    Visible = buttonBarItem.Metadata.ButtonVisible
                };

                // If there is an image then assigni t.
                if (!string.IsNullOrWhiteSpace(buttonBarItem.Metadata.ButtonImage))
                {
                    buttonItem.Image = Resources.ResourceManager.GetObject(buttonBarItem.Metadata.ButtonImage) as Image;
                }

                // Add the item to the toolbar, and dictionary.
                this.buttonItems.Add(buttonBarItem.Metadata.ToolTip, new MenuItem(buttonItem));
                this.toolStrip1.Items.Add(buttonItem);
                buttonItem.Click += RunWorker;
            }
        }

        /// <summary>
        /// Adds menus from the composition container.
        /// </summary>
        private void AddMenus(CompositionContainer container)
        {
            // Find all menu items and order them by the order, and path.
            foreach (var menuItem in container.GetExports<IWorker, IMenuBarItem>()
                                              .OrderBy(l => l.Metadata.MenuOrder)
                                              .ThenBy(l => l.Metadata.MenuPath))
            {
                ToolStripItemCollection parent = this.menuStrip1.Items;
                ToolStripMenuItem buttonItem = null;

                // Iterate over each path, and add a menu.
                for (int i = 0; i < menuItem.Metadata.MenuPaths.Length; i++)
                {
                    // Get the current menu path.
                    string current = menuItem.Metadata.MenuPaths[i];

                    // Get the parent collection if it is present.
                    if (parent.ContainsKey(current))
                    {
                        parent = (parent[current] as ToolStripMenuItem).DropDownItems;
                    }
                    else
                    {
                        // Create a new menu item and add it.
                        buttonItem = new ToolStripMenuItem(current)
                        {
                            Name = current
                        };
                        parent.Add(buttonItem);

                        // If this is the last path, then make sure this gets all of the necessary components.
                        if (i == menuItem.Metadata.MenuPaths.Length - 1)
                        {
                            // Insert a separator as necessary.
                            if (menuItem.Metadata.MenuBeginGroup)
                            {
                                parent.Insert(parent.IndexOf(buttonItem), new ToolStripSeparator());
                            }

                            // Assign properties that make this clickable.
                            buttonItem.Enabled = menuItem.Metadata.MenuEnabled;
                            buttonItem.Tag = menuItem;
                            buttonItem.Visible = menuItem.Metadata.MenuVisible;
                            if (!string.IsNullOrWhiteSpace(menuItem.Metadata.MenuImage))
                            {
                                buttonItem.Image = Resources.ResourceManager.GetObject(menuItem.Metadata.MenuImage) as Image;
                            }
                            buttonItem.Click += RunWorker;
                        }
                        else
                        {
                            parent = buttonItem.DropDownItems;
                        }
                    }
                }

                // If there is a button item, then add it to the internal dictionary.
                if (buttonItem != null)
                {
                    this.menuItems.Add(menuItem.Metadata.MenuPath, new MenuItem(buttonItem));
                }
            }
        }

        /// <summary>
        /// Closes a view.
        /// </summary>
        public bool Close(IView view)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                if (!view.Close()) { return false; }

                var tabItem = this.views[view];
                this.tabControl.TabPages.Remove(tabItem);
                this.views.Remove(view);

                this.GetMenuItem(@"&File\Close &Document").Enabled = (this.tabControl.TabPages.Count > 0);

                return true;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Gets a menu item from the button bar by name.
        /// </summary>
        public IMenuItem GetButtonItem(string button)
        {
            return this.buttonItems[button];
        }

        /// <summary>
        /// Gets a menu item from the menu bar by path.
        /// </summary>
        public IMenuItem GetMenuItem(string path)
        {
            return this.menuItems[path];
        }

        /// <summary>
        /// Make sure that all views can close before closing.
        /// </summary>
        protected override void OnClosing(CancelEventArgs e)
        {
            // Determine if any view cannot close, and
            // if they cannot cancel the event.
            foreach (var key in this.views.Keys.ToArray())
            {
                if (!this.Close(key))
                {
                    e.Cancel = true;
                    return;
                }
            }

            base.OnClosing(e);
        }

        /// <summary>
        /// Loads all necessary data.
        /// </summary>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Do not continue if this is being designed.
            if (this.DesignMode) { return; }

            // Load the icon.
            this.Icon = Icon.FromHandle(Resources.Link.GetHicon());

            // New the rom.
            this.Rom = new Rom();

            // Load all buttons and menus.
            var container = new CompositionContainer(new AssemblyCatalog(typeof(MainMenu).Assembly));
            this.AddButtons(container);
            this.AddMenus(container);
        }

        /// <summary>
        /// Runs a worker.
        /// </summary>
        private void RunWorker(object sender, EventArgs e)
        {
            var host = (sender as ToolStripItem);
            var worker = (host.Tag as Lazy<IWorker>);
            worker.Value.DoWork(this);
        }

        /// <summary>
        /// Show a view.
        /// </summary>
        public void Show(IView view)
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                view.MainMenu = this;
                view.LoadData();

                var page = new TabPage { Text = view.Title };
                page.Controls.Add(view.UserControl);
                view.UserControl.Dock = DockStyle.Fill;

                this.tabControl.TabPages.Add(page);
                this.views.Add(view, page);
                this.tabControl.SelectedTab = page;

                this.GetMenuItem(@"&File\Close &Document").Enabled = true;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        /// <summary>
        /// Closes a tab item if it is middle clicked on.
        /// </summary>
        private void tabControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Middle) { return; }

            // Close the selected view if it was found.
            var view = this.tabControl.TabPages.Cast<TabPage>()
                                               .Where((t, i) => this.tabControl.GetTabRect(i).Contains(e.Location))
                                               .Select(t => t.Controls[0] as IView)
                                               .SingleOrDefault();
            if (view != null) { this.Close(view); }
        }

        private class MenuItem : IMenuItem
        {
            private ToolStripItem item;

            public MenuItem(ToolStripItem item)
            {
                this.item = item;
            }

            public bool Enabled
            {
                get { return this.item.Enabled; }
                set { this.item.Enabled = value; }
            }

            public bool Visible
            {
                get { return this.item.Visible; }
                set { this.item.Visible = value; }
            }
        }
    }
}
