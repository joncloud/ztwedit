
namespace JonCloud.Ztwedit
{
    /// <summary>
    /// Provides an interface for a class that does a small amount of work.
    /// </summary>
    public interface IWorker
    {
        /// <summary>
        /// Do work with the main menu.
        /// </summary>
        void DoWork(IMainMenu mainMenu);
    }
}
