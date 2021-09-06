using System;
using System.Windows.Forms;

namespace MicroSharpFTP
{
    public partial class fNewFolderAndRename : Form
    {
        internal string Host, UserName, Password, Port;
        internal string Mode = string.Empty;
        internal string FilenameForRename = string.Empty;

        public fNewFolderAndRename()
        {
            InitializeComponent();
            
        }

        private void fNewFolder_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void mNewFolder_Load(object sender, EventArgs e)
        {
            this.Icon = resources.Goescat_Macaron;
        }

        private void buttoncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttoncreate_Click(object sender, EventArgs e)
        {

            //
            /* Create Object Instance */
            string FTPDosyaYolu = "ftp://" + Host + ":" + Port;
            ftp ftpClient = new ftp(@FTPDosyaYolu, UserName, Password);
            if (Mode=="newfolder")
            {
                try
                {
                    ftp.ResponseStatus = ftpClient.CreateDirectory(txtProcess.Text);
                    this.Close();
                    ftp.DidUserClosed = false;
                    
                }
                catch (Exception ex)
                {
                    ftp.ResponseStatus = ex.ToString();
                   
                }
            }
            else if (Mode=="rename")
            {
                try
                {
                    ftp.ResponseStatus = ftpClient.RenameFileOrFolder(FilenameForRename,txtProcess.Text,false);
                    this.Close();
                    ftp.DidUserClosed = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


        }
    }
}
