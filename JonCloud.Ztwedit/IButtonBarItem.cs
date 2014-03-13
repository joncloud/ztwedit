
namespace JonCloud.Ztwedit
{
    public interface IButtonBarItem
    {
        bool ButtonBeginGroup { get; }
        bool ButtonEnabled { get; }
        string ButtonImage { get; }
        int ButtonOrder { get; }
        bool ButtonVisible { get; }
        string ToolTip { get; }
    }
}
