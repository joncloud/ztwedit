using System;

namespace JonCloud.Ztwedit
{
    /// <summary>
    /// Represents an overworld map.
    /// </summary>
    public class OverworldMap
    {
        private const int MaximumWidth = 64;
        private const byte MaximumLength = 0x10;
        private const byte LengthMask = 0xF0;
        private const byte TypeMask = 0x0F;
        private const byte Empty = 0x00;

        private int dataWidth;
        private OverworldMapTile[] tiles;

        public OverworldMap(byte[] data)
        {
            // Make sure that the data is valid.
            if (data == null) { throw new ArgumentNullException("data"); }
            if (data.Length == 0) { throw new ArgumentException("data"); }

            // Store the values locally.
            this.dataWidth = data.Length;
            this.tiles = new OverworldMapTile[this.dataWidth * MaximumLength];

            int i = 0;
            byte x = 0;
            byte y = 0;
            do
            {
                // Get the current byte.
                byte current = data[i];

                // Determine the run-length by taking the length mask,
                // shifting by four and adding one.
                byte length = (byte)(((current & LengthMask) >> 4) + 1);

                // Get the type by using the type mask.
                byte type = (byte)(current & TypeMask);

                // While there is still a length remaining.
                while (length-- > 0)
                {
                    // Assign the current coordinate to the type by type casting.
                    this[x, y] = (OverworldMapTile)type;

                    // Increment the x coordinate.
                    x++;

                    // When the x coordinate is off the edge, reset it
                    // and increment the y coordinate.
                    if (x >= MaximumWidth)
                    {
                        x = 0;
                        y++;
                    }
                }

                // Continue reading while there is still data to be processed.
            } while (++i < this.dataWidth);

            // Assign the height to be y + 1.
            this.Height = ++y;
        }

        /// <summary>
        /// Gets or sets the tile at a specific position.
        /// </summary>
        public OverworldMapTile this[byte x, byte y]
        {
            get { return this.tiles[GetIndex(x, y)]; }
            set { this.tiles[GetIndex(x, y)] = value; }
        }

        /// <summary>
        /// Gets the maximum height of the map.
        /// </summary>
        public byte Height { get; private set; }

        /// <summary>
        /// Gets the maximum width of the map.
        /// </summary>
        public byte Width { get { return MaximumWidth; } }

        /// <summary>
        /// Gets the one dimensional index from an x and y coordinate.
        /// </summary>
        private static int GetIndex(byte x, byte y)
        {
            return y * MaximumWidth + x;
        }

        /// <summary>
        /// Tries to convert the map to a byte array.
        /// </summary>
        /// <param name="data">Ouptut data converted back into proprietary format.</param>
        /// <returns>True when everything was saved into the array, otherwise false when the map is too large to fit into the array.</returns>
        public bool ToByteArray(out byte[] data)
        {
            // Create a new array with the size of the original.
            data = new byte[this.dataWidth];
            int tileIndex = 0;
            int byteIndex = 0;

            do
            {
                byte length = 0;
                byte? type = null;

                // If the current type has not been initialized, or the
                // current tile is the same tile as the type.  Also
                // make sure that the length is no longer than the length
                // that can be saved in the format (0x10).
                while (!type.HasValue ||
                        (tileIndex < this.tiles.Length &&
                        (byte)this.tiles[tileIndex] == type.Value &&
                        length < MaximumLength))
                {
                    // Assign the current type.
                    if (!type.HasValue) { type = (byte)this.tiles[tileIndex]; }

                    // Increment the position of the pointer, and increment the length.
                    tileIndex++;
                    length++;
                }

                // Decrement the length by one, because the value stored is
                // converted to (length + 1).
                length--;
                
                // Assign the current byte to be the length shifted left
                // by four, and add the type into it.
                data[byteIndex++] = (byte)((length << 4) + type.Value);

                // If the total number of tiles is longer than the allotted
                // array, then return false.
                if (byteIndex >= data.Length) { return false; }

                // Continue while there is still data to be processed.
            } while (tileIndex < this.tiles.Length);

            return true;
        }
    }
}
