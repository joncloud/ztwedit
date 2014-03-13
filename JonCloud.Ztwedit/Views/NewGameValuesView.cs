using System;
using System.Text;
using System.Windows.Forms;

namespace JonCloud.Ztwedit.Views
{
    /// <summary>
    /// View for editing new game values.
    /// </summary>
    public partial class NewGameValuesView : UserControlBase
    {
        private BindingSource bindingSource;
        private NewGameValues newGameValues;

        public NewGameValuesView()
        {
            InitializeComponent();
            this.Title = "New Game Values";
        }

        /// <summary>
        /// Binds a control to a property on a data source.
        /// </summary>
        private void BindControl(Control control, string controlProperty, string dataSourceProperty)
        {
            var binding = control.DataBindings.Add(controlProperty, this.bindingSource, dataSourceProperty, false, DataSourceUpdateMode.OnPropertyChanged);
            binding.Parse += (sender, e) => this.HasUnsavedChanges = true;
        }

        private void ListViewItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var thunk = e.Item.Tag as Action<ListViewItem>;
            thunk(e.Item);
            this.HasUnsavedChanges = true;
        }

        protected override void OnLoadData()
        {
            // Get the data to manipulate.
            object instance;
            if (!this.Parameters.TryGetValue("Data", out instance) ||
                !(instance is byte[]))
            {
                throw new ApplicationException();
            }

            // Load a strong typed model.
            this.newGameValues = new NewGameValues(instance as byte[]);
            this.bindingSource = new BindingSource(this.newGameValues, null);

            // Bind the bindable controls.
            this.BindControl(this.numericUpDownCrystals, "Text", "Crystals");
            this.BindControl(this.numericUpDownHeartContainers, "Text", "HeartContainers");
            this.BindControl(this.numericUpDownLives, "Text", "Lives");
            this.BindControl(this.numericUpDownMagicContainers, "Text", "MagicContainers");
            this.BindControl(this.checkBoxDownwardThrust, "Checked", "DownwardThrust");
            this.BindControl(this.checkBoxUpwardThrust, "Checked", "UpwardThrust");

            // Manually bind the list views.
            int i = 0;
            ListView view = null;
            Action<bool, Action<ListViewItem>> setTag = (v, t) =>
            {
                ListViewItem item = view.Items[i++];
                item.Checked = v;
                item.Tag = t;
            };

            view = this.listViewItems;
            setTag(this.newGameValues.Boots, new Action<ListViewItem>(l => this.newGameValues.Boots = l.Checked));
            setTag(this.newGameValues.Candle, new Action<ListViewItem>(l => this.newGameValues.Candle = l.Checked));
            setTag(this.newGameValues.Cross, new Action<ListViewItem>(l => this.newGameValues.Cross = l.Checked));
            setTag(this.newGameValues.Flute, new Action<ListViewItem>(l => this.newGameValues.Flute = l.Checked));
            setTag(this.newGameValues.Hammer, new Action<ListViewItem>(l => this.newGameValues.Hammer = l.Checked));
            setTag(this.newGameValues.HandyGlove, new Action<ListViewItem>(l => this.newGameValues.HandyGlove = l.Checked));
            setTag(this.newGameValues.MagicalKey, new Action<ListViewItem>(l => this.newGameValues.MagicalKey = l.Checked));
            setTag(this.newGameValues.Raft, new Action<ListViewItem>(l => this.newGameValues.Raft = l.Checked));

            i = 0;
            view = this.listViewMagic;
            setTag(this.newGameValues.FairyMagic, new Action<ListViewItem>(l => this.newGameValues.FairyMagic = l.Checked));
            setTag(this.newGameValues.FireMagic, new Action<ListViewItem>(l => this.newGameValues.FireMagic = l.Checked));
            setTag(this.newGameValues.JumpMagic, new Action<ListViewItem>(l => this.newGameValues.JumpMagic = l.Checked));
            setTag(this.newGameValues.LifeMagic, new Action<ListViewItem>(l => this.newGameValues.LifeMagic = l.Checked));
            setTag(this.newGameValues.ReflectMagic, new Action<ListViewItem>(l => this.newGameValues.ReflectMagic = l.Checked));
            setTag(this.newGameValues.ShieldMagic, new Action<ListViewItem>(l => this.newGameValues.ShieldMagic = l.Checked));
            setTag(this.newGameValues.SpellMagic, new Action<ListViewItem>(l => this.newGameValues.SpellMagic = l.Checked));
            setTag(this.newGameValues.ThunderMagic, new Action<ListViewItem>(l => this.newGameValues.ThunderMagic = l.Checked));

            this.HasUnsavedChanges = false;
        }

        protected override void SaveData()
        {
            this.bindingSource.EndEdit();

            StringBuilder warnings = new StringBuilder();

            // Warn when loading more than normal heart containers.
            if (this.newGameValues.HeartContainers > (byte)0x4)
            {
                warnings.AppendLine("Starting off with heart containers larger than 4 can cause unknown results when picking up more heart containers in game.");
            }
            if (this.newGameValues.MagicContainers > (byte)0x4)
            {
                warnings.AppendLine("Starting off with magic containers larger than 4 can cause unknown results when picking up more magic containers in game.");
            }

            // Display any warnings.
            if (warnings.Length > 0)
            {
                warnings.AppendLine();
                warnings.AppendLine("Do you want to save anyways?");
                var result = MessageBox.Show(
                                            warnings.ToString(),
                                            "Warnings",
                                            MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    this.HasUnsavedChanges = true;
                    return;
                }
            }

            this.newGameValues.UpdateByteArray(this.MainMenu.Rom.Data);
        }
    }
}
