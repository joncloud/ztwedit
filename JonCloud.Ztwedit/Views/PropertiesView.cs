using System;

namespace JonCloud.Ztwedit.Views
{
    /// <summary>
    /// Displays the properties for the currently opened ROM.
    /// </summary>
    public partial class PropertiesView : UserControlBase
    {
        public PropertiesView()
        {
            InitializeComponent();
            this.Title = "Properties";
        }

        protected override void OnLoadData()
        {
            this.textBoxDirectoryName.DataBindings.Add("Text", this.MainMenu.Rom, "DirectoryName");
            this.textBoxFileName.DataBindings.Add("Text", this.MainMenu.Rom, "FileName");
            this.textBoxFileSize.DataBindings.Add("Text", this.MainMenu.Rom, "FileLength");
        }
    }
}
