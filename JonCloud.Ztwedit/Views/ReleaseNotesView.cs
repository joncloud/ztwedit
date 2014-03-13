using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using JonCloud.Ztwedit.Properties;

namespace JonCloud.Ztwedit.Views
{
    /// <summary>
    /// Displays all release notes in the application.
    /// </summary>
    public partial class ReleaseNotesView : Form
    {
        private BindingSource bindingSource;
        private ReleaseNotes[] releaseNotes;

        public ReleaseNotesView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Closes this form.
        /// </summary>
        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Do not continue in design mode.
            if (this.DesignMode) { return; }

            // Get the icon for the form.
            this.Icon = Icon.FromHandle(Resources.Notes.GetHicon());

            // Load any release notes that exist in resources.
            this.releaseNotes = typeof(ReleaseNotesView).Assembly.GetManifestResourceNames()
                                                                 .Where(s => s.Contains("Version"))
                                                                 .Select(s => new ReleaseNotes(s))
                                                                 .OrderByDescending(n => n.Version)
                                                                 .ToArray();

            // Bind the textbox to the release notes.
            this.bindingSource = new BindingSource(this.releaseNotes, null);
            this.textBoxNotes.DataBindings.Add("Text", this.bindingSource, "Notes", false, DataSourceUpdateMode.OnPropertyChanged);

            // Add all release notes to the list view.
            this.listViewVersions.Items.AddRange(this.releaseNotes.Select(n => new ListViewItem(n.Version)).ToArray());
        }

        /// <summary>
        /// Updates the binding source's position.
        /// </summary>
        private void listViewVersions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.listViewVersions.SelectedIndices.Count > 0)
            {
                this.bindingSource.Position = this.listViewVersions.SelectedIndices[0];
            }
        }

        public class ReleaseNotes
        {
            private static readonly Regex VersionExpression = new Regex("Version_(?<Major>\\d)_(?<Minor>\\d)_(?<Revision>\\d)", RegexOptions.Compiled | RegexOptions.IgnoreCase);

            public ReleaseNotes(string resourceName)
            {
                var match = VersionExpression.Match(resourceName);
                this.Version = string.Format(
                                        "{0}.{1}.{2}",
                                        match.Groups["Major"].Value,
                                        match.Groups["Minor"].Value,
                                        match.Groups["Revision"].Value);
                using (var stream = typeof(ReleaseNotes).Assembly.GetManifestResourceStream(resourceName))
                using (var reader = new StreamReader(stream))
                {
                    this.Notes = reader.ReadToEnd();
                }
            }

            public string Notes { get; set; }
            public string Version { get; set; }
        }
    }
}
