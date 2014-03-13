using System.ComponentModel.Composition;

namespace JonCloud.Ztwedit.Workers
{
    [Export(typeof(IWorker))]
    [MenuBar(@"&View\&Overworld\&Maze Island", false, true, MenuOrder = 1)]
    public class OpenMazeIsland : OpenOverworld
    {
        /// <summary>
        /// Gets the total length of the overworld.
        /// </summary>
        protected override int Length { get { return RomMap.MazeIslandLength; } }

        /// <summary>
        /// Gets the offset where the overworld map begins.
        /// </summary>
        protected override int Offset { get { return RomMap.MazeIslandOffset; } }

        /// <summary>
        /// Gets the title of the map being opened.
        /// </summary>
        protected override string Title { get { return "Maze Island"; } }
    }
}
