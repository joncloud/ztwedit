
namespace JonCloud.Ztwedit
{
    /// <summary>
    /// Group for all offsets and lengths for the ROM.
    /// </summary>
    public static class RomMap
    {
        /// <summary>
        /// The total length of the ROM image.
        /// </summary>
        public const int RomLength = 0x40C8A;

        /// <summary>
        /// The total length of Death Mountain.
        /// </summary>
        public const int DeathMountainLength = 0x02E6;

        /// <summary>
        /// The offset where Death Mountain starts.
        /// </summary>
        public const int DeathMountainOffset = 0x665C;

        /// <summary>
        /// The total length of East Hyrule.
        /// </summary>
        public const int EastHyruleLength = 0x0319;

        /// <summary>
        /// The offset where East Hyrule Starts.
        /// </summary>
        public const int EastHyruleOffset = 0x9056;

        /// <summary>
        /// The total length of Maze Island.
        /// </summary>
        public const int MazeIslandLength = 0x02E6;

        /// <summary>
        /// The offset where Maze Island starts.
        /// </summary>
        public const int MazeIslandOffset = 0xA65C;

        /// <summary>
        /// The total length of New Game Values.
        /// </summary>
        public const int NewGameValuesLength = 0x4873;

        /// <summary>
        /// The offset where New Game Values starts.
        /// </summary>
        public const int NewGameValuesOffset = 0x17AF7;

        /// <summary>
        /// The total length of West Hyrule.
        /// </summary>
        public const int WestHyruleLength = 0x0320;

        /// <summary>
        /// The offset where West Hyrule starts.
        /// </summary>
        public const int WestHyruleOffset = 0x506C;
    }
}
