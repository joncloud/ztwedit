using System;
using System.Linq;
using JonCloud.Ztwedit.Views;

namespace JonCloud.Ztwedit.Workers
{
    /// <summary>
    /// Base class for opening overworld maps.
    /// </summary>
    public abstract class OpenOverworld : IWorker
    {
        /// <summary>
        /// Gets the total length of the overworld.
        /// </summary>
        protected abstract int Length { get; }

        /// <summary>
        /// Gets the offset where the overworld map begins.
        /// </summary>
        protected abstract int Offset { get; }

        /// <summary>
        /// Gets the title of the map being opened.
        /// </summary>
        protected abstract string Title { get; }

        /// <summary>
        /// Do work with the main menu.
        /// </summary>
        public void DoWork(IMainMenu mainMenu)
        {
            // Only allow one view per overworld.
            var existing = mainMenu.Views.OfType<OverworldMapView>().Where(v => v.Parameters["Offset"].Equals(this.Offset)).FirstOrDefault();
            if (existing != null)
            {
                mainMenu.ActiveView = existing;
                return;
            }

            // Create a new array to store a copy of the map in.
            var data = new byte[this.Length];
            Array.Copy(mainMenu.Rom.Data, this.Offset, data, 0, this.Length);

            // Load the overworld view.
            var view = new OverworldMapView();
            view.Parameters.Add("Data", data);
            view.Parameters.Add("Title", this.Title);
            view.Parameters.Add("Offset", this.Offset);
            mainMenu.Show(view);
        }
    }
}
