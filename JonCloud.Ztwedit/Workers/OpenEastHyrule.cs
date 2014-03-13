using System.ComponentModel.Composition;

namespace JonCloud.Ztwedit.Workers
{
    [Export(typeof(IWorker))]
    [MenuBar(@"&View\&Overworld\&East Hyrule", false, true, MenuOrder = 1)]
    public class OpenEastHyrule : OpenOverworld
    {
        /// <summary>
        /// Gets the total length of the overworld.
        /// </summary>
        protected override int Length { get { return RomMap.EastHyruleLength; } }

        /// <summary>
        /// Gets the offset where the overworld map begins.
        /// </summary>
        protected override int Offset { get { return RomMap.EastHyruleOffset; } }

        /// <summary>
        /// Gets the title of the map being opened.
        /// </summary>
        protected override string Title { get { return "East Hyrule"; } }
    }
}
