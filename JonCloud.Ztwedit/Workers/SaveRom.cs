using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace JonCloud.Ztwedit.Workers
{
    [ButtonBar("Save", "Save", false, true, ButtonOrder = 1)]
    [Export(typeof(IWorker))]
    [MenuBar(@"&File\&Save", false, true, MenuBeginGroup = true, MenuImage = "Save", MenuOrder = 2)]
    public class SaveRom : SaveAll
    {
        /// <summary>
        /// Do work with the main menu.
        /// </summary>
        public override void DoWork(IMainMenu mainMenu)
        {
            // Save all open views.
            base.DoWork(mainMenu);

            // Save the rom.
            mainMenu.Rom.Save(mainMenu.Rom.FileInfo.FullName);
        }
    }
}
