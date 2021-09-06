using System;
using System.Windows.Forms;

namespace MicroSharpFTP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ftp.GetSettingsFromSettingsDatabase();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string v = ftp.CreateSettingsDatabase();
            if (ftp.PasswordProtectProgram)
            {
                Application.Run(new fLogin());
            }
            else
            {
                Application.Run(new fClient());
            }
            
        }
    }
}
