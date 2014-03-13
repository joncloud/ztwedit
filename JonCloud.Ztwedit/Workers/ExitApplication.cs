using System.ComponentModel.Composition;

namespace JonCloud.Ztwedit.Workers
{
    /// <summary>
    /// Exits the application.
    /// </summary>
    [Export(typeof(IWorker))]
    [MenuBar(@"&File\&Exit", MenuBeginGroup = true, MenuOrder = 4)]
    public class ExitApplication : IWorker
    {
        /// <summary>
        /// Do work with the main menu.
        /// </summary>
        public void DoWork(IMainMenu mainMenu)
        {
            // Close the main menu's form.
            mainMenu.Form.Close();
        }
    }
}
