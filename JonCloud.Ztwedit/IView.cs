using System.Collections.Generic;
using System.Windows.Forms;

namespace JonCloud.Ztwedit
{
    /// <summary>
    /// Provides an interface for a view.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Gets whether or not the view has unsaved changes.
        /// </summary>
        bool HasUnsavedChanges { get; }

        /// <summary>
        /// Gets or sets a reference to the main menu.
        /// </summary>
        IMainMenu MainMenu { get; set; }

        /// <summary>
        /// Gets a collection of parameters.
        /// </summary>
        IDictionary<string, object> Parameters { get; }

        /// <summary>
        /// Gets the hosted user control.
        /// </summary>
        Control UserControl { get; }

        /// <summary>
        /// Gets the title displayed to the user for the view.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Determines if the current view can be closed.
        /// </summary>
        bool Close();
        
        /// <summary>
        /// Loads any relevant data for the view.
        /// </summary>
        void LoadData();

        /// <summary>
        /// Saves any unsaved data on the view.
        /// </summary>
        void Save();
    }
}
