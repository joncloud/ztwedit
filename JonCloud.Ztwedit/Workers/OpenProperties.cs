using System.ComponentModel.Composition;
using System.Linq;
using JonCloud.Ztwedit.Views;

namespace JonCloud.Ztwedit.Workers
{
    /// <summary>
    /// Opens the properties view.
    /// </summary>
    [ButtonBar("Properties", "Properties", false, true, ButtonBeginGroup = true, ButtonOrder = 4)]
    [Export(typeof(IWorker))]
    [MenuBar(@"&View\&Properties", false, true, MenuImage = "Properties")]
    public class OpenProperties : IWorker
    {
        /// <summary>
        /// Do work with the main menu.
        /// </summary>
        public virtual void DoWork(IMainMenu mainMenu)
        {
            // Only show the properties view once.
            var view = mainMenu.Views.OfType<PropertiesView>().FirstOrDefault();
            if (view != null)
            {
                mainMenu.ActiveView = view;
                return;
            }
            mainMenu.Show(new PropertiesView());
        }
    }
}
