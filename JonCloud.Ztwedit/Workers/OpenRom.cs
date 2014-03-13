using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace JonCloud.Ztwedit.Workers
{
    /// <summary>
    /// Opens the ROM.
    /// </summary>
    [ButtonBar("Open", "Open")]
    [Export(typeof(IWorker))]
    [MenuBar(@"&File\&Open", MenuImage = "Open")]
    public class OpenRom : OpenProperties
    {
        /// <summary>
        /// Do work with the main menu.
        /// </summary>
        public override void DoWork(IMainMenu mainMenu)
        {
            // Show the open file dialog and try and load the ROM.
            using (var dialog = new OpenFileDialog())
            {
                // Only continue if the user chose a file.
                if (dialog.ShowDialog() != DialogResult.OK) { return; }

                // Try and load the rom.
                if (!mainMenu.Rom.Load(dialog.FileName)) { return; }

                // Enable the menu items.
                mainMenu.GetButtonItem("Save").Enabled = true;
                mainMenu.GetButtonItem("Save All").Enabled = true;
                mainMenu.GetButtonItem("Properties").Enabled = true;
                mainMenu.GetMenuItem(@"&File\&Close").Enabled = true;
                mainMenu.GetMenuItem(@"&File\&Save").Enabled = true;
                mainMenu.GetMenuItem(@"&File\Save &All").Enabled = true;
                mainMenu.GetMenuItem(@"&View\&New Game Values").Enabled = true;
                mainMenu.GetMenuItem(@"&View\&Properties").Enabled = true;
                mainMenu.GetMenuItem(@"&View\&Overworld\&East Hyrule").Enabled = true;
                mainMenu.GetMenuItem(@"&View\&Overworld\&West Hyrule").Enabled = true;
                mainMenu.GetMenuItem(@"&View\&Overworld\&Maze Island").Enabled = true;
                mainMenu.GetMenuItem(@"&View\&Overworld\&Death Mountain").Enabled = true;

                // Show the Properties view.
                base.DoWork(mainMenu);
            }
        }
    }
}
