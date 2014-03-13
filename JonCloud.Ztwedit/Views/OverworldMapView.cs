using System;
using System.Drawing;
using System.Windows.Forms;

namespace JonCloud.Ztwedit.Views
{
    /// <summary>
    /// Displays the overworld map and allows editing.
    /// </summary>
    public partial class OverworldMapView : UserControlBase
    {
        private int lastTile;
        private byte lastX;
        private byte lastY;
        private int offset;
        private OverworldMap map;
        private int selectedMouseButton = -1;
        private int[] selectedTileIndex = new int[2];
        private Bitmap[] tiles;

        public OverworldMapView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Changes the tile based on the selected image.
        /// </summary>
        private void ChangeTile(object sender, MouseEventArgs e)
        {
            // Get the selected index.
            int index = 0;
            if (sender is PictureBox)
            {
                index = (int)(sender as PictureBox).Tag;
            }

            // Use the left button.
            if (e.Button == MouseButtons.Left)
            {
                this.selectedTileIndex[0] = index;
                this.pictureBoxLeft.Image = this.tiles[this.selectedTileIndex[0]];
                this.pictureBoxLeft.Invalidate();
            }

            // Use the right button.
            else if (e.Button == MouseButtons.Right)
            {
                this.selectedTileIndex[1] = index;
                this.pictureBoxRight.Image = this.tiles[this.selectedTileIndex[1]];
                this.pictureBoxRight.Invalidate();
            }
        }

        /// <summary>
        /// Loads all necessary data.
        /// </summary>
        protected override void OnLoadData()
        {
            object instance;
            if (!this.Parameters.TryGetValue("Offset", out instance) ||
                !(instance is int))
            {
                throw new ApplicationException();
            }
            this.offset = (int)instance;

            // Load the map.
            if (!this.Parameters.TryGetValue("Data", out instance) ||
                !(instance is byte[]))
            {
                throw new ApplicationException();
            }
            this.map = new OverworldMap(instance as byte[]);

            // Disable the horizontal scroll bar.
            this.flowLayoutPanelTiles.HorizontalScroll.Enabled = false;
            this.flowLayoutPanelTiles.HorizontalScroll.Visible = false;

            // Convert the master image into individual tiles.
            var tileMaster = global::JonCloud.Ztwedit.Properties.Resources.OverworldTiles;
            this.tiles = new Bitmap[tileMaster.Width / 16];
            for (int i = 0; i < tiles.Length; i++)
            {
                var b = this.tiles[i] = new Bitmap(16, 16);
                using (var g = Graphics.FromImage(b))
                {
                    g.DrawImage(
                        tileMaster,
                        new Rectangle(0, 0, 16, 16),
                        new Rectangle(i * 16, 0, 16, 16),
                        GraphicsUnit.Pixel);
                }

                // Add the picture box to the available tiles.
                PictureBox box = new PictureBox
                {
                    Height = 32,
                    Image = b,
                    Margin = new Padding(0),
                    Padding = new Padding(0),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Tag = i,
                    Width = 32
                };
                box.MouseClick += new MouseEventHandler(ChangeTile);
                this.flowLayoutPanelTiles.Controls.Add(box);
            }

            // Store the first position as the last tile so it can be
            // changed first if the tile is actually different.
            this.lastTile = (byte)this.map[0, 0];

            // Update the tiles.
            this.ChangeTile(this, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));
            this.ChangeTile(this, new MouseEventArgs(MouseButtons.Right, 0, 0, 0, 0));

            // Render the map.
            this.RenderMap();
        }

        /// <summary>
        /// Renders the entire map to the screen.
        /// </summary>
        private void RenderMap()
        {
            // If the image is already set, then dispose of it.
            if (this.pictureBoxMap.Image != null)
            {
                var image = this.pictureBoxMap.Image;
                this.pictureBoxMap.Image = null;
                image.Dispose();
            }

            // Create a new image the size of the map.
            Bitmap bitmap = new Bitmap(this.pictureBoxMap.Width, this.map.Height * 16);
            this.pictureBoxMap.Image = bitmap;
            this.pictureBoxMap.Height = bitmap.Height;

            // Begin drawing to the screen.
            using (var g = Graphics.FromImage(bitmap))
            {
                // Iterate over each coordinate.
                for (byte y = 0; y < this.map.Height; y++)
                {
                    for (byte x = 0; x < this.map.Width; x++)
                    {
                        int targetX = x * 16;
                        int targetY = y * 16;

                        // Draw the tile.
                        g.DrawImage(this.tiles[(int)this.map[x, y]], targetX, targetY);
                    }
                }
            }

            this.pictureBoxMap.Invalidate();
        }

        /// <summary>
        /// Saves the local data back into the ROM.
        /// </summary>
        protected override void SaveData()
        {
            // Try to convert the map to a byte array.
            byte[] data;
            if (!this.map.ToByteArray(out data))
            {
                // Show a dialog warning the user that the tiles saved may not represent
                // what is on the screen due to file size restrictions.
                var result = MessageBox.Show(
                                        "Due to limitations of the ROM the number of unique tiles selected is not supported. Continuing will cause any tiles near the bottom to be removed and may cause corruption. Do you want to continue?",
                                        "Too Many Tiles",
                                        MessageBoxButtons.YesNo,
                                        MessageBoxIcon.Warning);
                if (result == DialogResult.No) { return; }
            }

            // Copy the data back into the ROM.
            Array.Copy(data, 0, this.MainMenu.Rom.Data, this.offset, data.Length);
        }

        /// <summary>
        /// Sets the current mouse button, and a tile at the current mouse position.
        /// </summary>
        private void pictureBoxMap_MouseDown(object sender, MouseEventArgs e)
        {
            // Select the left button.
            if (e.Button == MouseButtons.Left)
            {
                this.selectedMouseButton = 0;
            }

            // Select the right button.
            else if (e.Button == MouseButtons.Right)
            {
                this.selectedMouseButton = 1;
            }

            // Select no button.
            else
            {
                this.selectedMouseButton = -1;
            }

            this.pictureBoxMap_MouseMove(sender, e);
        }

        /// <summary>
        /// Sets a tile at the mouse position.
        /// </summary>
        private void pictureBoxMap_MouseMove(object sender, MouseEventArgs e)
        {
            // Do nothing if no button is pressed.
            if (this.selectedMouseButton == -1) { return; }

            // Get the coordinates.
            var x = (byte)(e.X / 16);
            var y = (byte)(e.Y / 16);
            var index = this.selectedTileIndex[this.selectedMouseButton];

            // Do nothing if the coordinate and the last tile are the same.
            if (x == this.lastX && y == this.lastY && index == this.lastTile) { return; }

            // Because the data is different set the flag.
            this.HasUnsavedChanges = true;

            // Update the data source.
            this.map[x, y] = (OverworldMapTile)index;

            // Draw the selected image to the screen.
            using (var g = Graphics.FromImage(this.pictureBoxMap.Image))
            {
                g.DrawImage(
                    this.tiles[index],
                    x * 16,
                    y * 16);
            }
            this.pictureBoxMap.Invalidate();

            // Store the last information.
            this.lastTile = index;
            this.lastX = x;
            this.lastY = y;
        }

        /// <summary>
        /// Selects no button.
        /// </summary>
        private void pictureBoxMap_MouseUp(object sender, MouseEventArgs e)
        {
            this.selectedMouseButton = -1;
        }
    }
}
