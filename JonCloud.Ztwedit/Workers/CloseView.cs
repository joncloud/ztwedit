using System.ComponentModel.Composition;

namespace JonCloud.Ztwedit.Workers
{
    /// <summary>
    /// Closes the current view.
    /// </summary>
    [Export(typeof(IWorker))]
    [MenuBar(@"&File\Close &Document", false, true, MenuOrder = 1)]
    public class CloseView : IWorker
    {
        /// <summary>
        /// Do work with the main menu.
        /// </summary>
        public void DoWork(IMainMenu mainMenu)
        {
            // If there is an active view then cloes it.
            var view = mainMenu.ActiveView;
            if (view != null) { mainMenu.Close(view); }
        }
    }
}
