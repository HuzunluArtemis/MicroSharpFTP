using Microsoft.Win32;
using System;
using System.Data.SQLite;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MicroSharpFTP
{
    public partial class fSettings : Form
    {
        public fSettings()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e) => this.Close();

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (chkStartup.Checked) // key var mı bak varsa elleme yoksa elle.
            {
                if (!(ftp.RegistryValueExists() == "true"))
                    AddToStartup();
            }
            else
                RemoveFromStartup();
            //
            ftp.AutoConnectAtStartup = chkConnectStartup.Checked;
            ftp.AutoConnectingAdress = (string)cmbConnectStartup.SelectedValue;
            ftp.AutoExpandAutomations = chkAutoExpangAutomations.Checked;
            ftp.AutomationControl = chkAutomationControl.Checked;
            ftp.AutoSaveLogs = chkAutoSaveLogs.Checked;
            ftp.AutoScrollLogs = chkAutoScrollLogs.Checked;
            ftp.ConfirmDeletingAutomation = chkConfirmDeletingAutomation.Checked;
            ftp.ConfirmDeletingRemoteFile = chkDeleteRemoteFile.Checked;
            ftp.ConfirmDeletingSavedCredential = chkConfirmDeleteSavedCredentials.Checked;
            ftp.ConfirmExitingApp = chkConfirmExitingApp.Checked;
            ftp.DefaultPort = chkDefaultPort.Checked;
            ftp.DefaultPortInt = Convert.ToInt32(txtDefaultPort.Text);
            ftp.MinimizeSystemTrayWhenClosing = chkMinimizeTrayWhenClosing.Checked;
            ftp.PasswordProtectProgram = chkPasswordProtect.Checked;
            ftp.PasswordProtectStr = txtPasswordProtect.Text;
            ftp.PasswordProtectTray = chkPasswordTray.Checked;
            ftp.PasswordProtectTrayStr = txtPasswordTray.Text;
            ftp.StartInSystemTray = chkStartInSystemTray.Checked;

            //
            if (chkAutomationControl.Checked)
                ftp.AutomationControlMs = Convert.ToInt32(txtAutomationControl.Text);
            else
                ftp.AutomationControlMs = 1000;

            // saving to database
            using (SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=" + @ftp.ProgramDataDir + @"\" + @ftp.FilenameSettings))
            { 
            using (SQLiteCommand com = new SQLiteCommand(con))
            {
                con.Open();
                using (SQLiteCommand fmd = con.CreateCommand())
                {
                    string comm = "UPDATE Settings SET AutoConnectAtStartup = "
                    + "'"
                    + ftp.AutoConnectAtStartup
                    + "', AutoConnectingAdress = "
                    + "'"
                    + ftp.AutoConnectingAdress
                    + "', AutoExpandAutomations = "
                    + "'"
                    + ftp.AutoExpandAutomations
                    + "', AutomationControl = "
                    + "'"
                    + ftp.AutomationControl
                    + "', AutoSaveLogs = "
                    + "'"
                    + ftp.AutoSaveLogs
                    + "', AutoScrollLogs = "
                    + "'"
                    + ftp.AutoScrollLogs
                    + "', ConfirmDeletingAutomation = "
                    + "'"
                    + ftp.ConfirmDeletingAutomation
                    + "', ConfirmDeletingRemoteFile = "
                    + "'"
                    + ftp.ConfirmDeletingRemoteFile
                    + "', ConfirmDeletingSavedCredential = "
                    + "'"
                    + ftp.ConfirmDeletingSavedCredential
                    + "', ConfirmExitingApp = "
                    + "'"
                    + ftp.ConfirmExitingApp
                    + "', DefaultPort = "
                    + "'"
                    + ftp.DefaultPort
                    + "', DefaultPortInt = "
                    + "'"
                    + ftp.DefaultPortInt
                    + "', MinimizeSystemTrayWhenClosing = "
                    + "'"
                    + ftp.MinimizeSystemTrayWhenClosing
                    + "', PasswordProtectProgram = "
                    + "'"
                    + ftp.PasswordProtectProgram
                    + "', PasswordProtectStr = "
                    + "'"
                    + ftp.PasswordProtectStr
                    + "', PasswordProtectTray = "
                    + "'"
                    + ftp.PasswordProtectTray
                    + "', PasswordProtectTrayStr = "
                    + "'"
                    + ftp.PasswordProtectTrayStr
                    + "', StartInSystemTray = "
                    + "'"
                    + ftp.StartInSystemTray
                    + "', AutomationControlMs = "
                    + "'"
                    + ftp.AutomationControlMs
                    + "'"
                    + " WHERE OnlyOneRow = "
                    + "'"
                    + "1"
                    + "'";
                    fmd.CommandText = comm;
                    fmd.CommandType = System.Data.CommandType.Text;
                    fmd.ExecuteNonQuery();
                }
                con.Close();
            }
            }

            MessageBox.Show("Saved Changes.");
            this.Close();

        }

        /// <summary>
        /// Add application to Startup of windows
        /// </summary>
        /// <param name="appName"></param>
        /// <param name="path"></param>
        public static void AddToStartup()
        // https://yetanotherchris.dev/csharp/6-ways-to-get-the-current-directory-in-csharp/
        // https://stackoverflow.com/questions/674628/how-do-i-set-a-program-to-launch-at-startup
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey
                (@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                string appName = "MicroSharpFTP"; // was parameter

                key.SetValue(appName, Application.ExecutablePath);
                //MessageBox.Show("appname: " + appName + "\nstartuppath: " + Application.StartupPath);
            }
        }

        /// <summary>
        /// Remove application from Startup of windows
        /// </summary>
        /// <param name="appName"></param>
        public static void RemoveFromStartup()
        {
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey
                (@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
            {
                string appName = "MicroSharpFTP"; // was parameter
                key.DeleteValue(appName, false);
            }
        }

        
        private void fSettings_Load(object sender, EventArgs e)
        {
            this.Icon = resources.Goescat_Macaron;
            // this.StartPosition = FormStartPosition.CenterScreen;
            // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.form.icon?redirectedfrom=MSDN&view=netframework-4.8#System_Windows_Forms_Form_Icon
            Size size = new Size(499, 444);
            this.MaximumSize = size;
            this.MinimumSize = size;
        }

        private void chkConnectStartup_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConnectStartup.Checked)
            {
                cmbConnectStartup.Enabled = true;
            }
            else
            {
                cmbConnectStartup.Enabled = false;
               
            }
        }

      
        private void txtdefaultport_KeyUp(object sender, KeyEventArgs e)
        {
            ftp.KeyUpForNumber(txtDefaultPort);
        }

        private void txtdefaultport_KeyPress(object sender, KeyPressEventArgs e)
        {
            ftp.KeyPressForNumber(e, txtDefaultPort);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkdefaultport_CheckedChanged(object sender, EventArgs e)
        {
           
            
            txtDefaultPort.Enabled = chkDefaultPort.Checked;
        }

        private void chkAutomationControl_CheckedChanged(object sender, EventArgs e)
        {
            txtAutomationControl.Enabled = chkAutomationControl.Checked;
        }

        private void chkPasswordProtect_CheckedChanged(object sender, EventArgs e)
        {
            txtPasswordProtect.Enabled = chkPasswordProtect.Checked;
        }

        private void chkPasswordTray_CheckedChanged(object sender, EventArgs e)
        {
            txtPasswordTray.Enabled = chkPasswordTray.Checked;
        }

        private void btnLoadDefaults_Click(object sender, EventArgs e)
        {
            chkStartup.Checked = true;
            chkStartInSystemTray.Checked = true;
            chkConfirmDeleteSavedCredentials.Checked = true;
            chkDeleteRemoteFile.Checked = true;
            chkAutoScrollLogs.Checked = true;
            chkConnectStartup.Checked = false;
            chkDefaultPort.Checked = true;
            txtDefaultPort.Text = "21";
            chkAutomationControl.Checked = true;
            txtAutomationControl.Text = "1000";
            chkPasswordProtect.Checked = false;
            chkPasswordTray.Checked = false;
            chkMinimizeTrayWhenClosing.Checked = true;
            chkConfirmExitingApp.Checked = true;
            chkConfirmDeletingAutomation.Checked = true;
            chkAutoExpangAutomations.Checked = true;
            chkAutoSaveLogs.Checked = true;
        }

        private void btnImportSettings_Click(object sender, EventArgs e)
        {
            ImportDatabase(ftp.FilenameSettings);
        }

        private void btnImportAutomations_Click(object sender, EventArgs e)
        {
            ImportDatabase(ftp.FilenameAutomations);
        }

        private void btnImportCredentials_Click(object sender, EventArgs e)
        {
            ImportDatabase(ftp.FilenameCredentials);
        }

        private static void ImportDatabase(string databasename)
        {
            DialogResult a = MessageBox.Show("Do you want to overwrite to your " + databasename + "?" + Environment.NewLine + "Requires restart app.", "Overwriting to " + databasename, buttons: MessageBoxButtons.OKCancel);
            if (a == DialogResult.OK)
            {

                OpenFileDialog openFileDialog1 = new OpenFileDialog
                {
                    Filter = "Database File (.db)|*.db",
                    RestoreDirectory = true,
                    Multiselect = false
                };

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {

                    string sourceFile = openFileDialog1.FileName;
                    string destinationFile = ftp.ProgramDataDir + @"\" + databasename;
                    try
                    {
                        // Copying source file's contents to
                        // destination file
                        File.Copy(sourceFile, destinationFile, true);
                        MessageBox.Show("Succesfully imported " + databasename + " App will close now. You can re-open.");
                        Application.Exit();
                    }
                    catch (IOException iox)
                    {
                        MessageBox.Show(iox.Message);
                    }
                }


            }
        }

        
    }
}
