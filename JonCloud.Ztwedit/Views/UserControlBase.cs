using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace JonCloud.Ztwedit.Views
{
    /// <summary>
    /// Base class for all user controls.
    /// </summary>
    public class UserControlBase : UserControl, IView
    {
        public UserControlBase()
        {
            this.Parameters = new Dictionary<string, object>();
        }

        /// <summary>
        /// Gets whether or not the view has unsaved changes.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool HasUnsavedChanges { get; protected set; }

        /// <summary>
        /// Gets or sets a reference to the main menu.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IMainMenu MainMenu { get; set; }

        /// <summary>
        /// Gets a collection of parameters.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IDictionary<string, object> Parameters { get; private set; }

        /// <summary>
        /// Gets the hosted user control.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Control UserControl { get { return this; } }

        /// <summary>
        /// Gets the title displayed to the user for the view.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get
            {
                if (string.IsNullOrWhiteSpace(title))
                {
                    object instance;
                    if (this.Parameters.TryGetValue("Title", out instance) &&
                        instance is string)
                    {
                        this.title = instance.ToString();
                    }
                }
                return this.title;
            }
            protected set { this.title = value; }
        }
        private string title;

        protected virtual bool CanClose()
        {
            if (this.HasUnsavedChanges)
            {
                var result = MessageBox.Show(
                                            "There is currently unsaved data on this document. Do you want to save before closing?",
                                            "Unsaved Data",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Warning);
                switch (result)
                {
                    case DialogResult.Cancel:
                        return false;
                    case DialogResult.No:
                        return true;
                    case DialogResult.Yes:
                        this.Save();
                        return true;
                }
            }
            return true;
        }

        public bool Close()
        {
            return this.CanClose();
        }

        public void LoadData()
        {
            if (this.DesignMode) { return; }
            this.OnLoadData();
        }

        protected virtual void OnLoadData() { }

        public void Save()
        {
            if (!this.HasUnsavedChanges) { return; }
            this.HasUnsavedChanges = false;
            this.SaveData();
        }

        protected virtual void SaveData() { }
    }
}
