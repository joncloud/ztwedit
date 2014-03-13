using System.ComponentModel.Composition;
using JonCloud.Ztwedit.Views;

namespace JonCloud.Ztwedit.Workers
{
    /// <summary>
    /// Shows release notes.
    /// </summary>
    [Export(typeof(IWorker))]
    [MenuBar(@"&Help\&Release Notes", MenuOrder = 5)]
    public class ShowReleaseNotes : IWorker
    {
        /// <summary>
        /// Do work with the main menu.
        /// </summary>
        public void DoWork(IMainMenu mainMenu)
        {
            // Shows the release notes view.
            using (var dialog = new ReleaseNotesView())
            {
                dialog.ShowDialog();
            }
        }
    }
}
