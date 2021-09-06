using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace MicroSharpFTP
{
    public partial class fLogin : Form
    {
        public fLogin()
        {
            
            InitializeComponent();
        }
        internal static string type = "starting";
        private void fLogin_Load(object sender, EventArgs e)
        {
            
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Icon = resources.Goescat_Macaron;
            txtPassword.UseSystemPasswordChar = true;
            Size a = new Size(303, 349);
            this.MaximumSize = a;
            this.MinimumSize = a;

        }



        private bool mouseDown;
        private Point lastLocation;

        private void DragMouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void DragMouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void DragMouseUp(object sender, MouseEventArgs e)
        {
            if (ftp.IsMiddleClick(e))
            {
                DialogResult a = MessageBox.Show(ftp.AboutText, ftp.AboutTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
                if (a == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(ftp.ProgramRepo);
                }
            }
            
                mouseDown = false;
            
            
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (type== "starting")
            {
                if (txtPassword.Text == ftp.PasswordProtectStr)
                {
                    lblPassword.ForeColor = Color.ForestGreen;
                    fClient fClient = new fClient();
                    fClient.Show();
                    this.Hide();
                }
                else
                {
                    lblPassword.ForeColor = Color.DarkRed;
                }
            }
            else if (type == "tray")
            {
                if (txtPassword.Text == ftp.PasswordProtectTrayStr)
                {
                    lblPassword.ForeColor = Color.ForestGreen;
                    foreach (Form f in Application.OpenForms)    //it will return all the open forms
                    {
                        if (!(f.Text== "Login to MicroSharpFTP"))
                        {
                            f.Visible = true;
                        }
                        
                    }
                    this.Close();
                }
                else
                {
                    lblPassword.ForeColor = Color.DarkRed;
                }
            }
        }

        private void fLogin_Shown(object sender, EventArgs e)
        {
            
                

            
        }

        private void showMicroSharpFTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void aboutMicroSharpFTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show(ftp.AboutText, ftp.AboutTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (a == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(ftp.ProgramRepo);
            }
        }

        private void exitMicroSharpFTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmsMain_Opening(object sender, CancelEventArgs e)
        {

        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
