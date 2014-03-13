
namespace JonCloud.Ztwedit
{
    /// <summary>
    /// Provides an interface for menu items that exist on the menubar or toolbar.
    /// </summary>
    public interface IMenuItem
    {
        /// <summary>
        /// Gets or sets whether or not the menu is enabled.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// Gets or sets whether or not the menu is visible.
        /// </summary>
        bool Visible { get; set; }
    }
}
