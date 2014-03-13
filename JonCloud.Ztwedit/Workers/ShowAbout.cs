using System.ComponentModel.Composition;
using System.Windows.Forms;

namespace JonCloud.Ztwedit.Workers
{
    /// <summary>
    /// Displays the about form.
    /// </summary>
    [Export(typeof(IWorker))]
    [MenuBar(@"&Help\&About", MenuOrder = 5)]
    public class ShowAbout : IWorker
    {
        /// <summary>
        /// Do work with the main menu.
        /// </summary>
        public void DoWork(IMainMenu mainMenu)
        {
            MessageBox.Show(
                        "Zelda II: Adventure of Link ROM Editor\r\nhttp://jon-cloud.net/ztwedit/",
                        "About",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
        }
    }
}
