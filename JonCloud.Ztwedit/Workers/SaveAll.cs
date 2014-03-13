using System.ComponentModel.Composition;

namespace JonCloud.Ztwedit.Workers
{
    /// <summary>
    /// Saves all open views.
    /// </summary>
    [ButtonBar("Save All", "SaveAll", false, true, ButtonOrder = 2)]
    [Export(typeof(IWorker))]
    [MenuBar(@"&File\Save &All", false, true, MenuBeginGroup = true, MenuImage = "SaveAll", MenuOrder = 3)]
    public class SaveAll : IWorker
    {
        /// <summary>
        /// Do work with the main menu.
        /// </summary>
        public virtual void DoWork(IMainMenu mainMenu)
        {
            // Save any views that are open.
            foreach (var view in mainMenu.Views)
            {
                view.Save();
            }
        }
    }
}
