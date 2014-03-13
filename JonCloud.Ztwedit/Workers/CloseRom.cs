using System.ComponentModel.Composition;
using System.Linq;

namespace JonCloud.Ztwedit.Workers
{
    /// <summary>
    /// Closes the ROM.
    /// </summary>
    [Export(typeof(IWorker))]
    [MenuBar(@"&File\&Close", false, true, MenuBeginGroup = true, MenuOrder = 1)]
    public class CloseRom : IWorker
    {
        /// <summary>
        /// Do work with the main menu.
        /// </summary>
        public void DoWork(IMainMenu mainMenu)
        {
            // If any view cannot be closed then return.
            foreach (var view in mainMenu.Views.ToArray())
            {
                if (!mainMenu.Close(view)) { return; }
            }

            // Close the rom.
            mainMenu.Rom.Close();

            // Disable any button that is related to the ROM being open.
            mainMenu.GetButtonItem("Save").Enabled = false;
            mainMenu.GetButtonItem("Save All").Enabled = false;
            mainMenu.GetButtonItem("Properties").Enabled = false;
            mainMenu.GetMenuItem(@"&File\&Close").Enabled = false;
            mainMenu.GetMenuItem(@"&File\&Save").Enabled = false;
            mainMenu.GetMenuItem(@"&File\Save &All").Enabled = false;
            mainMenu.GetMenuItem(@"&View\&Properties").Enabled = false;
            mainMenu.GetMenuItem(@"&View\&Overworld\&East Hyrule").Enabled = false;
            mainMenu.GetMenuItem(@"&View\&Overworld\&West Hyrule").Enabled = false;
            mainMenu.GetMenuItem(@"&View\&Overworld\&Maze Island").Enabled = false;
            mainMenu.GetMenuItem(@"&View\&Overworld\&Death Mountain").Enabled = false;
        }
    }
}
