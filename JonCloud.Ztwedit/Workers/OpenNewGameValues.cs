using System;
using System.ComponentModel.Composition;
using System.Linq;
using JonCloud.Ztwedit.Views;

namespace JonCloud.Ztwedit.Workers
{
    /// <summary>
    /// Opens the properties view.
    /// </summary>
    [Export(typeof(IWorker))]
    [MenuBar(@"&View\&New Game Values", false, true, MenuOrder = 1)]
    public class OpenNewGameValues : IWorker
    {
        /// <summary>
        /// Do work with the main menu.
        /// </summary>
        public virtual void DoWork(IMainMenu mainMenu)
        {
            // Only show the new game values view once.
            var existing = mainMenu.Views.OfType<NewGameValuesView>().FirstOrDefault();
            if (existing != null)
            {
                mainMenu.ActiveView = existing;
                return;
            }
            var view = new NewGameValuesView();
            var data = new byte[RomMap.NewGameValuesLength];
            Array.Copy(mainMenu.Rom.Data, RomMap.NewGameValuesOffset, data, 0, data.Length);
            view.Parameters.Add("Data", data);
            mainMenu.Show(view);
        }
    }
}
