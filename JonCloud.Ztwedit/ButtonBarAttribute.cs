using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;

namespace JonCloud.Ztwedit
{
    [AttributeUsage(AttributeTargets.Class)]
    [MetadataAttribute]
    public class ButtonBarAttribute : Attribute, IButtonBarItem
    {
        public ButtonBarAttribute(string text, string image)
            : this(text, image, true, true)
        {
        }

        public ButtonBarAttribute(string text, string image, bool enabled, bool visible)
        {
            this.ButtonEnabled = enabled;
            this.ButtonImage = image;
            this.ToolTip = text;
            this.ButtonVisible = visible;
        }

        public bool ButtonBeginGroup { get; set; }
        public bool ButtonEnabled { get; private set; }
        public string ButtonImage { get; private set; }
        public int ButtonOrder { get; set; }
        public string ToolTip { get; private set; }
        public bool ButtonVisible { get; private set; }
    }
}
