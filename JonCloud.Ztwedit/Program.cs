using System;
using System.Text;
using System.Windows.Forms;

namespace JonCloud.Ztwedit
{
    static class Program
    {
        static void DisplayException(Exception ex)
        {
            StringBuilder message = new StringBuilder();
            while (ex != null)
            {
                message.AppendFormat("{0} - {1}\r\n", ex.GetType(), ex.Message);
                ex = ex.InnerException;
            }
            MessageBox.Show(message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            System.Diagnostics.Debugger.Launch();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainMenu());
            }
            catch (Exception ex)
            {
                DisplayException(ex);
            }
        }
    }
}
