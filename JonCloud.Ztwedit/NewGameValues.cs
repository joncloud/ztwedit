
namespace JonCloud.Ztwedit
{
    public class NewGameValues
    {
        public NewGameValues(byte[] data)
        {
            int i = 0;

            // Load magic.
            this.ShieldMagic = (data[i++] != 0x0);
            this.JumpMagic = (data[i++] != 0x0);
            this.LifeMagic = (data[i++] != 0x0);
            this.FairyMagic = (data[i++] != 0x0);
            this.FireMagic = (data[i++] != 0x0);
            this.ReflectMagic = (data[i++] != 0x0);
            this.SpellMagic = (data[i++] != 0x0);
            this.ThunderMagic = (data[i++] != 0x0);

            // Load life/magic.
            this.MagicContainers = data[i++];
            this.HeartContainers = data[i++];

            // Load items.
            this.Candle = (data[i++] != 0x0);
            this.HandyGlove = (data[i++] != 0x0);
            this.Raft = (data[i++] != 0x0);
            this.Boots = (data[i++] != 0x0);
            this.Flute = (data[i++] != 0x0);
            this.Cross = (data[i++] != 0x0);
            this.Hammer = (data[i++] != 0x0);
            this.MagicalKey = (data[i++] != 0x0);

            // Load crystals.
            i += 8;
            this.Crystals = data[i++];

            // Load techniques.
            byte techniques = data[i++];
            this.DownwardThrust = ((techniques & 0x10) == 0x10);
            this.UpwardThrust = ((techniques & 0x04) == 0x04);

            // Load lives.
            this.Lives = (data[data.Length - 1]);
        }

        public bool Boots { get; set; }
        public bool Candle { get; set; }
        public bool Cross { get; set; }
        public byte Crystals { get; set; }
        public bool DownwardThrust { get; set; }
        public bool FairyMagic { get; set; }
        public bool FireMagic { get; set; }
        public bool Flute { get; set; }
        public bool Hammer { get; set; }
        public bool HandyGlove { get; set; }
        public byte HeartContainers { get; set; }
        public bool JumpMagic { get; set; }
        public bool LifeMagic { get; set; }
        public byte Lives { get; set; }
        public bool MagicalKey { get; set; }
        public byte MagicContainers { get; set; }
        public bool Raft { get; set; }
        public bool ReflectMagic { get; set; }
        public bool ShieldMagic { get; set; }
        public bool SpellMagic { get; set; }
        public bool ThunderMagic { get; set; }
        public bool UpwardThrust { get; set; }

        public void UpdateByteArray(byte[] data)
        {
            int i = RomMap.NewGameValuesOffset;

            // Save the magic.
            data[i++] = (byte)(this.ShieldMagic ? 0x1 : 0x0);
            data[i++] = (byte)(this.JumpMagic ? 0x1 : 0x0);
            data[i++] = (byte)(this.LifeMagic ? 0x1 : 0x0);
            data[i++] = (byte)(this.FairyMagic ? 0x1 : 0x0);
            data[i++] = (byte)(this.FireMagic ? 0x1 : 0x0);
            data[i++] = (byte)(this.ReflectMagic ? 0x1 : 0x0);
            data[i++] = (byte)(this.SpellMagic ? 0x1 : 0x0);
            data[i++] = (byte)(this.ThunderMagic ? 0x1 : 0x0);

            // Save life/magic.
            data[i++] = this.MagicContainers;
            data[i++] = this.HeartContainers;

            // Save the items.
            data[i++] = (byte)(this.Candle ? 0x1 : 0x0);
            data[i++] = (byte)(this.HandyGlove ? 0x1 : 0x0);
            data[i++] = (byte)(this.Raft ? 0x1 : 0x0);
            data[i++] = (byte)(this.Boots ? 0x1 : 0x0);
            data[i++] = (byte)(this.Flute ? 0x1 : 0x0);
            data[i++] = (byte)(this.Cross ? 0x1 : 0x0);
            data[i++] = (byte)(this.Hammer ? 0x1 : 0x0);
            data[i++] = (byte)(this.MagicalKey ? 0x1 : 0x0);

            // Save crystals.
            i += 8;
            data[i++] = this.Crystals;

            // Save techniques.
            byte techniques = 0x0;
            if (this.DownwardThrust) { techniques |= 0x10; }
            if (this.UpwardThrust) { techniques |= 0x04; }
            data[i++] = techniques;

            // Save lives.
            data[RomMap.NewGameValuesOffset + RomMap.NewGameValuesLength - 1] = this.Lives;
        }
    }
}
