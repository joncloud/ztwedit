using System.ComponentModel.Composition;

namespace JonCloud.Ztwedit.Workers
{
    /// <summary>
    /// Opens the Death Mountain Overworld layout.
    /// </summary>
    [Export(typeof(IWorker))]
    [MenuBar(@"&View\&Overworld\&Death Mountain", false, true, MenuOrder = 1)]
    public class OpenDeathMountain : OpenOverworld
    {
        /// <summary>
        /// Gets the total length of the overworld.
        /// </summary>
        protected override int Length { get { return RomMap.DeathMountainLength; } }

        /// <summary>
        /// Gets the offset where the overworld map begins.
        /// </summary>
        protected override int Offset { get { return RomMap.DeathMountainOffset; } }

        /// <summary>
        /// Gets the title of the map being opened.
        /// </summary>
        protected override string Title { get { return "Death Mountain"; } }
    }
}
