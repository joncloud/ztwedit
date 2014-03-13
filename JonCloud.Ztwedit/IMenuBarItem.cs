
namespace JonCloud.Ztwedit
{
    public interface IMenuBarItem
    {
        bool MenuEnabled { get; }
        bool MenuBeginGroup { get; }
        string MenuImage { get; }
        int MenuOrder { get; }
        string MenuPath { get; }
        string[] MenuPaths { get; }
        bool MenuVisible { get; }
    }
}
