using System;
using System.IO;
using System.Windows.Forms;

namespace JonCloud.Ztwedit
{
    /// <summary>
    /// Describes the Zelda 2 ROM as a very basic instance.
    /// </summary>
    public class Rom
    {
        public Rom() { }

        /// <summary>
        /// Gets the complete array of data for the ROM.
        /// </summary>
        public byte[] Data { get; private set; }

        /// <summary>
        /// Gets the full path to the loaded ROM's directory.
        /// </summary>
        public string DirectoryName
        {
            get { return (this.FileInfo != null ? this.FileInfo.DirectoryName : string.Empty); }
        }

        /// <summary>
        /// Gets the file info pointing to the ROM.
        /// </summary>
        public FileInfo FileInfo { get; private set; }

        /// <summary>
        /// Gets the total length of the ROM as hexadecimal.
        /// </summary>
        public string FileLength
        {
            get { return (this.FileInfo != null ? string.Format("0x{0:x}", this.FileInfo.Length) : string.Empty); }
        }

        /// <summary>
        /// Gets the name of the ROM loaded.
        /// </summary>
        public string FileName
        {
            get { return (this.FileInfo != null ? this.FileInfo.Name : string.Empty); }
        }

        /// <summary>
        /// Displays a dialog to let the user continue loading if the ROM does not match on length.
        /// </summary>
        /// <returns>True if the user accepts, otherwise false.</returns>
        private bool AllowLength()
        {
            DialogResult result = MessageBox.Show(
                                                "The selected file does not match the expected length of the ROM. Are you sure you want to continue?",
                                                "Invalid File",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            return (result == DialogResult.Yes);
        }

        /// <summary>
        /// Closes the current file.
        /// </summary>
        public void Close()
        {
            this.Data = null;
            this.FileInfo = null;
        }

        /// <summary>
        /// Loads a rom from disk.
        /// </summary>
        /// <param name="fileName">Path to the file on disk to load.</param>
        /// <returns>True if the file was loaded, and validated, otherwise false.</returns>
        public bool Load(string fileName)
        {
            // Validate the arguments.
            if (string.IsNullOrWhiteSpace(fileName)) { throw new ArgumentNullException("fileName"); }
            
            // Look up the file.
            this.FileInfo = new FileInfo(fileName);

            // New the array.
            this.Data = new byte[RomMap.RomLength];

            bool result;
            string message;

            try
            {
                // Open the rom.
                using (var stream = File.OpenRead(this.FileInfo.FullName))
                {
                    // Match on length.
                    if (stream.Length != RomMap.RomLength &&
                        !this.AllowLength())
                    {
                        message = "File does not match expected length.";
                        result = false;
                    }

                    // Read in the file.  It is safe to read in all at once
                    // because the size is very small, and it is being read
                    // in from disk.
                    else
                    {
                        stream.Read(this.Data, 0, (int)Math.Min(RomMap.RomLength, stream.Length));
                        result = true;
                        message = null;
                    }
                }
            }
            catch (IOException)
            {
                result = false;
                message = "Unable to read the file from disk.";
                throw;
            }
            catch (UnauthorizedAccessException)
            {
                result = false;
                message = "Unable to access the file.";
            }
            catch (NotSupportedException)
            {
                result = false;
                message = "Unsupported read from disk.";
            }

            // If there is a message then show it.
            if (message != null)
            {
                MessageBox.Show(
                            message,
                            "Error Loading",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            }

            // Return the result.
            return result;
        }

        /// <summary>
        /// Saves a rom to disk.
        /// </summary>
        /// <param name="fileName">Path to the file to save to disk.</param>
        public void Save(string fileName)
        {
            // Open the file to save to.
            using (var stream = File.OpenWrite(fileName))
            {
                // Save the data to disk.
                stream.Write(this.Data, 0, (int)Math.Min(this.Data.Length, stream.Length));
            }
        }
    }
}
