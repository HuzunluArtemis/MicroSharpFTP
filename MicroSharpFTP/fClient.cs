using System;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Data;
using System.Drawing;
using System.Globalization;

namespace MicroSharpFTP
{

    public partial class fClient : Form
    {

        public fClient() // inşaatçı
        {
            InitializeComponent();

            tAutomations.Interval = ftp.AutomationControlMs;

        }



        private void Form1_Load(object sender, EventArgs e)
        {
            /// get logger details +
            txtPassword.UseSystemPasswordChar = true;
            tLogs.Enabled = ftp.AutoSaveLogs;
            /// get logger details -

            // tooltipler
            toolTip.SetToolTip(this.btnAbout, "About of MicroSharpFTP / Licenses");
            toolTip.SetToolTip(this.btnSettings, "MicroSharpFTP Settings");
            toolTip.SetToolTip(this.txtLogger, "MicroSharpFTP Logger");
            toolTip.SetToolTip(this.btnAutomations, "MicroSharpFTP Automations");
            //


            //
            twRemoteFolders.Enabled = false;
            ftp.Logger("MicroSharpFTP Started. Logger Started:", txtLogger);
            if (ftp.AutoSaveLogs)
                ftp.Logger("Logs saving enabled. Path: " + ftp.ProgramDataDir + @"\" + ftp.FilenameLogs, txtLogger);
            this.Icon = resources.Goescat_Macaron;

            // this.StartPosition = FormStartPosition.CenterScreen;
            //get a list of the drives
            ListLocalDrives();
            ///* Delete a File */
            //ftpClient.delete("etc/test.txt");

            ///* Rename a File */
            //ftpClient.rename("etc/test.txt", "test2.txt");

            ///* Create a New Directory */
            //ftpClient.createDirectory("etc/test");

            ///* Get the Date/Time a File was Created */
            //string fileDateTime = ftpClient.getFileCreatedDateTime("etc/test.txt");
            //Console.WriteLine(fileDateTime);

            ///* Get the Size of a File */
            //string fileSize = ftpClient.getFileSize("etc/test.txt");
            //Console.WriteLine(fileSize);

            ///* Get Contents of a Directory (Names Only) */
            //string[] simpleDirectoryListing = ftpClient.directoryListDetailed("/etc");
            //for (int i = 0; i < simpleDirectoryListing.Count(); i++) { Console.WriteLine(simpleDirectoryListing[i]); }

            ///* Get Contents of a Directory with Detailed File/Directory Info */
            //string[] detailDirectoryListing = ftpClient.directoryListDetailed("/etc");
            //for (int i = 0; i < detailDirectoryListing.Count(); i++) { Console.WriteLine(detailDirectoryListing[i]); }
            ///* Release Resources */
            //ftpClient = null;
            //
            CreateAutomationsDatabase();
            CreateCredentialsDatabase();
            string v = ftp.CreateSettingsDatabase();
            if (v != null)
                ftp.Logger(v, txtLogger);
            //
            //
            // eğer programlanmış birşey yoksa autoconnect yapılacak
            //savetodb("ftpupload.net", "epiz_29296641", "rZr2QIMkLU6evo");


            ListSavedFtpstoCombobox();

            string GetOperatingSystemInfo = SystemInfo.GetOperatingSystemInfo();
            if (GetOperatingSystemInfo != null)
                ftp.Logger(GetOperatingSystemInfo, txtLogger);
        }

        private void ListLocalDrives()
        {
            twLocalFolders.Nodes.Clear();
            string[] drives = Environment.GetLogicalDrives();

            foreach (string drive in drives)
            {
                DriveInfo di = new DriveInfo(drive);
                int driveImage;

                switch (di.DriveType)    //set the drive's icon
                {
                    case DriveType.CDRom:
                        driveImage = 3;
                        break;
                    case DriveType.Network:
                        driveImage = 6;
                        break;
                    case DriveType.NoRootDirectory:
                        driveImage = 8;
                        break;
                    case DriveType.Unknown:
                        driveImage = 8;
                        break;
                    default:
                        driveImage = 2;
                        break;
                }

                // TreeNode node = new TreeNode(drive.Substring(0, 1), driveImage, driveImage);
                // \\: ları göstermeyen kod
                TreeNode node = new TreeNode(drive, driveImage, driveImage);
                node.Tag = drive;

                if (di.IsReady == true)
                    node.Nodes.Add("...");

                twLocalFolders.Nodes.Add(node);
            }
        }

        //

        internal void CreateCredentialsDatabase()
        {

            if (!File.Exists(@ftp.ProgramDataDir + @"\" + @ftp.FilenameCredentials))
            {

                string createTableQuery = @"CREATE TABLE IF NOT EXISTS [DatabaseList] (
                          [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                          [Host] VARCHAR(1024)  NOT NULL,
                          [Username] VARCHAR(1024)  NOT NULL,
                          [Password] VARCHAR(1024)  NOT NULL,
                          [Port] INTEGER(5)  NULL
                          )";
                if (!Directory.Exists(@ftp.ProgramDataDir))
                {
                    Directory.CreateDirectory(@ftp.ProgramDataDir);
                }

                System.Data.SQLite.SQLiteConnection.CreateFile(@ftp.ProgramDataDir + @"\" + @ftp.FilenameCredentials);

                ftp.Logger("FTP List database not found. Created: " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameCredentials, txtLogger);
                // https://www.fluxbytes.com/csharp/how-to-create-and-connect-to-an-sqlite-database-in-c/
                using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=" + @ftp.ProgramDataDir + @"\" + @ftp.FilenameCredentials))
                {
                    using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(con))
                    {
                        con.Open();                             // Open the connection to the database

                        com.CommandText = createTableQuery;     // Set CommandText to our query that will create the table
                        com.ExecuteNonQuery();                  // Execute the query

                        //com.CommandText = "INSERT INTO DatabaseList (Host,Username,Password,Port) Values ('denemebir.com','denemeuseri','denemepasswordu','denemeportu')";

                        con.Close();        // Close the connection to the database
                    }
                }
            }
            else if (File.Exists(@ftp.ProgramDataDir + @"\" + @ftp.FilenameCredentials)) // db varsa
            {
                ftp.Logger("FTP List database found. Connected: " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameCredentials, txtLogger);
            }
        }

        public void ListSavedFtpstoCombobox()
        {
            List<string> ImportedFiles = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"data source = " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameCredentials))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"SELECT DISTINCT * FROM DatabaseList";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    cmbSavedCredentials.DisplayMember = "Host";
                    cmbSavedCredentials.ValueMember = "ID";
                    while (r.Read())
                    {
                        string a = Convert.ToString(r["Host"]);
                        a += " -> ";
                        a += Convert.ToString(r["Username"]);
                        ImportedFiles.Add(a);
                    }
                }
                connect.Close();
            }
            // List<string>  //  return ImportedFiles;
            cmbSavedCredentials.DataSource = ImportedFiles;
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo directoryInfo)
        {
            var directoryNode = new TreeNode(directoryInfo.Name);
            foreach (var directory in directoryInfo.GetDirectories())
                directoryNode.Nodes.Add(CreateDirectoryNode(directory));
            foreach (var file in directoryInfo.GetFiles())
                directoryNode.Nodes.Add(new TreeNode(file.Name));
            return directoryNode;
        }



        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes.Count > 0)
            {
                if (e.Node.Nodes[0].Text == "..." && e.Node.Nodes[0].Tag == null)
                {
                    e.Node.Nodes.Clear();

                    //get the list of sub direcotires
                    string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                    //add files of rootdirectory
                    DirectoryInfo rootDir = new DirectoryInfo(e.Node.Tag.ToString());
                    //foreach (var file in rootDir.GetFiles())
                    //{
                    //    TreeNode n = new TreeNode(file.Name, 13, 13);
                    //    e.Node.Nodes.Add(n);
                    //}

                    foreach (string dir in dirs)
                    {
                        DirectoryInfo di = new DirectoryInfo(dir);
                        TreeNode node = new TreeNode(di.Name, 0, 1);

                        try
                        {
                            //keep the directory's full path in the tag for use later
                            node.Tag = dir;

                            //if the directory has sub directories add the place holder
                            if (di.GetDirectories().Count() > 0)
                                node.Nodes.Add(null, "...", 0, 0);

                            //foreach (var file in di.GetFiles())
                            //{
                            //    TreeNode n = new TreeNode(file.Name, 13, 13);
                            //    node.Nodes.Add(n);
                            //}

                        }
                        catch (UnauthorizedAccessException)
                        {
                            //display a locked folder icon
                            node.ImageIndex = 12;
                            node.SelectedImageIndex = 12;
                        }
                        catch (Exception ex)
                        {
                            ftp.Logger("Error: " + ex.Message, txtLogger);
                        }
                        finally
                        {
                            e.Node.Nodes.Add(node);
                        }
                    }
                }
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (twLocalFolders.SelectedNode == null)
            {
                return;
            }
            lwLocalFiles.Items.Clear();
            //TreeNode MySelectedNode = e.Node;
            TreeNode MySelectedNode = twLocalFolders.SelectedNode;
            // Get Selected Node Path
            // MessageBox.Show( MySelectedNode.FullPath);

            string @secilen = twLocalFolders.SelectedNode.FullPath;
            try
            {
                string[] files = Directory.GetFiles(secilen);
                foreach (string file in files)
                {
                    FileInfo fi = new FileInfo(file);
                    string fileName = Path.GetFileName(file);
                    string filesize = ftp.BytesToString(fi.Length);
                    string type = fi.Extension;
                    DateTime modified = fi.LastWriteTime;
                    string lmod = modified.ToString("yyyy-mm-dd hh:mm");
                    string[] row = { fileName, filesize, type, lmod };
                    ListViewItem item = new ListViewItem(row)
                    {
                        Tag = file
                    };

                    var listViewItem = new ListViewItem(row);
                    lwLocalFiles.Items.Add(item);

                }
                ResizeListViewColumns(lwLocalFiles);
            }
            catch (UnauthorizedAccessException) // yetkisiz erişim için
            {
                FileAttributes attr = new FileInfo(secilen).Attributes;
                ftp.Logger("UnAuthorizedAccessException: Unable to access file.", txtLogger);
                if ((attr & FileAttributes.ReadOnly) > 0)
                    MessageBox.Show("The file is read-only.");
            }


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            openFileDialog.Filter = "All Files (*.*)|*.*";
            openFileDialog.FilterIndex = 1;
            openFileDialog.Multiselect = false;
            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                cmbLocal.Text = openFileDialog.FileName;
                string[] arrAllFiles = openFileDialog.FileNames; //used when Multiselect = true           
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("boş");

        }

        private void listView1_Click(object sender, EventArgs e)
        {
            string path = (string)lwLocalFiles.SelectedItems[0].Tag;
            path = path.Replace(@"\\", @"\");
            cmbLocal.Text = path;

        }



        private void buttonconnect_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting; // işlem yapılıyor

            listFtptoRemoteTreeView();
            listFtptoRemoteListView(".");
            ResizeListViewColumns(lwRemoteFiles);

            Cursor.Current = Cursors.Default; // işlem bitti
        }

        private void listFtptoRemoteListView(string directory)
        {
            string host = txtHost.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            // string FTPDosyaYolu = "ftp:/88.88.88.88:8888//FTP_Files";

            if (txtPort.Text == "" || txtPort.Text == " ")
            {
                txtPort.Text = ftp.DefaultPortInt.ToString();
            }
            string port = txtPort.Text;
            string FTPDosyaYolu = "ftp://" + host + ":" + port;
            //
            /* Create Object Instance */
            ftp ftpClient = new ftp(@FTPDosyaYolu, username, password);
            ftpClient.DetailedDirectoryListToListview(directory, lwRemoteFiles, cmbRemote);
        }

        private void ResizeListViewColumns(ListView lv)
        {
            foreach (ColumnHeader column in lv.Columns)
            {
                if (column.Index != 0 && column.Index != (lv.Columns.Count
                    - 1))
                {
                    column.Width = -2;
                }
                if (column.Index == 0)
                {
                    column.Width = 180;
                }
                // sonuncu -1 olsun
                if (column.Index == (lv.Columns.Count
                    - 1))
                {
                    column.Width = -1;
                }
            }
        }



        private void ListViewftpfiles_DoubleClick(object sender, EventArgs e)
        {
            if (lwRemoteFiles.SelectedItems.Count == 0)
            {
                return;
            }
            // string path = (string)listViewftpfiles.SelectedItems[0].Text;
            string host = txtHost.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            // string FTPDosyaYolu = "ftp:/88.88.88.88:8888//FTP_Files";

            string port = txtPort.Text;
            string FTPDosyaYolu = "ftp://" + host + ":" + port;
            //
            /* Create Object Instance */
            ftp ftpClient = new ftp(@FTPDosyaYolu, username, password);
            //

            //
            if (ftp.ToGoRenew) // true ise yenile
            {
                ftp.ToGoRenew = false;
                ftpClient.DetailedDirectoryListToListview(ftp.ActiveDirectory, lwRemoteFiles, cmbRemote);
                return;
            }
            else
            {
                string pat = lwRemoteFiles.SelectedItems[0].SubItems[1].Text;

                //
                if (ftp.IsDirWithPermissions(pat))
                {
                    string folder = lwRemoteFiles.SelectedItems[0].SubItems[0].Text;
                    //MessageBox.Show("is an folder");

                    if (folder == ".")
                    {
                        ftpClient.DetailedDirectoryListToListview(".", lwRemoteFiles, cmbRemote);
                        ftp.ActiveDirectory = ".";
                        // en tepeye çıkar
                    }
                    else if (folder == "..")
                    {
                        // MessageBox.Show("üst klasöre çıkarakcak.");
                        //ftpClient.directoryListDetailedtolistview("..", listViewftpfiles, comboremote);
                        //ftp.activedirectory = comboremote.Text;
                        // regex ile son slash silinecek
                        // \/(?:.(?!\/))+$ 
                        // düzenledim (?!\/)(?:.(?!\/))+$ bu ilk slaşı almıyor
                        // https://www.quora.com/What-is-a-regular-expression-that-finds-strings-where-the-first-character-is-the-same-as-the-last-character

                        // sonunda / olunca algılamaz çözüm regexle bulmaya çalışılacak

                        ftp.ActiveDirectory = Regex.Replace(ftp.ActiveDirectory, @"\/(?:.(?!\/))+$", "");
                        ftpClient.DetailedDirectoryListToListview(ftp.ActiveDirectory, lwRemoteFiles, cmbRemote);
                        ResizeListViewColumns(lwRemoteFiles);
                    }
                    else
                    {
                        if (ftp.ActiveDirectory == "." | ftp.ActiveDirectory == "..")
                        {
                            ftp.ActiveDirectory = "";
                        }
                        ftp.ActiveDirectory += "/" + folder;

                        ftpClient.DetailedDirectoryListToListview(ftp.ActiveDirectory, lwRemoteFiles, cmbRemote);

                        ResizeListViewColumns(lwRemoteFiles);
                    }

                }
                else
                {
                    //MessageBox.Show("is an file");

                    string todownload = ftp.ActiveDirectory + '/' + lwRemoteFiles.SelectedItems[0].Text;
                    SaveFileDialog s = new SaveFileDialog();
                    s.FileName = lwRemoteFiles.SelectedItems[0].Text;
                    s.Title = "Download File: " + lwRemoteFiles.SelectedItems[0].Text;
                    //s.ShowDialog(this);

                    if (s.ShowDialog() == DialogResult.OK)
                    {

                        Cursor = Cursors.AppStarting;
                        ftp.Logger("Download started: " + todownload + " to: " + s.FileName, txtLogger);
                        string a = ftpClient.DownloadFile(todownload, s.FileName, progressBar: prgCurrent, lblCurrentProgress, lblCurrentBytes);

                        ftp.Logger(a, txtLogger);
                        Cursor = Cursors.Default;
                    }
                }

            }
        }





        private void newFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string suankifolder = ftp.ActiveDirectory;
            if (lwRemoteFiles.SelectedItems.Count != 0)
            {
                if (lwRemoteFiles.SelectedItems[0].Text != "." && lwRemoteFiles.SelectedItems[0].Text != "..")
                {
                    string pat = lwRemoteFiles.SelectedItems[0].SubItems[1].Text;

                    if (ftp.IsDirWithPermissions(pat))
                    {
                        if (!pat.EndsWith("/"))
                        {
                            pat += "/";
                        }
                        if (!suankifolder.EndsWith("/"))
                        {
                            suankifolder += "/";

                        }
                        suankifolder += lwRemoteFiles.SelectedItems[0].Text;

                    }
                }
                else
                {
                    suankifolder = "/";
                }
            }
            fNewFolderAndRename m = new fNewFolderAndRename();
            m.txtProcess.Text = suankifolder + '/';
            m.Mode = "newfolder";
            m.txtProcess.SelectionStart = m.txtProcess.Text.Length;
            m.txtProcess.SelectionLength = 0;
            m.Host = txtHost.Text;
            m.UserName = txtUsername.Text;
            m.Password = txtPassword.Text;
            m.Port = txtPort.Text;
            // string FTPDosyaYolu = "ftp:/88.88.88.88:8888//FTP_Files";

            m.ShowDialog(this);
            // MessageBox.Show("is an folder");

            if (!ftp.DidUserClosed) // cancele tıklandığında alttaki işlemleri yapmasın
            {
                RefreshRemoteList(); // daha performanslı
                                     // önceden alttaydı bunlar:
                ftp.DidUserClosed = true;
                listFtptoRemoteTreeView();
                //
                // expand to full path
                // selectLastNode();
                // çok zaman alıyor
            }
            RefreshRemoteList();



        }

        private void selectLastNode()
        {
            string path = ftp.ActiveDirectory;

            List<string> path_list = path.Split('/').ToList();
            if (path_list[0] == null || path_list[0] == "")
                path_list[0] = "/";
            foreach (TreeNode node in twRemoteFolders.Nodes)
            {

                if (node.Text == path_list[0])
                    ExpandMyLitleBoys(twRemoteFolders, node, path_list);
            }
        }

        private void ExpandMyLitleBoys(TreeView tree, TreeNode node, List<string> path)
        {
            path.RemoveAt(0);

            node.Expand();
            tree.SelectedNode = node; // sonuncuyu seç

            if (path.Count == 0)
                return;

            foreach (TreeNode mynode in node.Nodes)
                if (mynode.Text == path[0])
                {
                    ExpandMyLitleBoys(tree, mynode, path); //recursive call

                    break;
                }

        }


        private void Comboremote_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                //MessageBox.Show("is an folder");
                string host = txtHost.Text;
                string username = txtUsername.Text;
                string password = txtPassword.Text;
                // string FTPDosyaYolu = "ftp:/88.88.88.88:8888//FTP_Files";

                string port = txtPort.Text;
                string FTPDosyaYolu = "ftp://" + host + ":" + port;
                //
                ftp ftpClient = new ftp(@FTPDosyaYolu, username, password);
                ftp.ActiveDirectory = cmbRemote.Text;

                ftp.ActiveDirectory = ftp.slashfix(ftp.ActiveDirectory);
                ftpClient.DetailedDirectoryListToListview(ftp.ActiveDirectory, lwRemoteFiles, cmbRemote);
            }
        }





        private void listFtptoRemoteTreeView()
        {
            //treeViewremote.Nodes[0].Nodes.Add("Child 1");
            //treeViewremote.Nodes[0].Nodes.Add("Child 2");
            //treeViewremote.Nodes[0].Nodes[1].Nodes.Add("Grandchild");
            //treeViewremote.Nodes[0].Nodes[1].Nodes[0].Nodes.Add("Great Grandchild");
            // https://bytes.com/topic/net/answers/841303-treeview-populated-string-array

            //try
            //{
            //    treeViewremote.Nodes.Clear();
            //    //treeViewremote.BeginUpdate();
            //    treeViewremote.Nodes.Add("/");
            //    int dizibuyuklugu = listViewftpfiles.Items.Count;
            //    string[] itemler = new string[listViewftpfiles.Items.Count];

            //    for (int i = 1; i <= listViewftpfiles.Items.Count; i++)
            //    {
            //        string pato = listViewftpfiles.Items[i - 1].SubItems[1].Text;
            //        if (ftp.isdir(pato))
            //        {
            //            itemler[i - 1] = listViewftpfiles.Items[i - 1].SubItems[0].Text;
            //        }
            //    }
            //    for (int i = 0; i < itemler.Length; i++)
            //    {
            //        if (itemler[i] != null)
            //        {
            //            treeViewremote.Nodes[0].Nodes.Add(itemler[i]);
            //        }
            //    }
            //    //treeViewremote.EndUpdate();
            //}
            //catch (Exception ex)
            //{

            //    MessageBox.Show(ex.ToString());
            //}

            // yeni
            string host = txtHost.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            // string FTPDosyaYolu = "ftp:/88.88.88.88:8888//FTP_Files";

            string port = txtPort.Text;
            string FTPDosyaYolu = "ftp://" + host + ":" + port;
            //
            /* Create Object Instance */
            ftp ftpClient = new ftp(@FTPDosyaYolu, username, password);
            twRemoteFolders.Nodes.Clear();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            string rootDirectory = "/";
            var node = new TreeNode(rootDirectory) { Tag = "/" };
            stack.Push(node);
            ftp.Logger("Connected. Transferring folders to TreeView.", txtLogger);
            while (stack.Count > 0)
            {
                try
                {
                    TreeNode currentNode = stack.Pop();
                    ftp.FileStruct[] directoryInfo = ftpClient.ListDirectory((string)currentNode.Tag);
                    foreach (var directory in directoryInfo)
                    {
                        if (directory.IsDirectory && directory.Name != "?")
                        {
                            var childDirectoryNode = new TreeNode(directory.Name) { Tag = currentNode.Tag + directory.Name + '/' };
                            currentNode.Nodes.Add(childDirectoryNode);
                            stack.Push(childDirectoryNode);
                        }
                    }
                    foreach (var file in directoryInfo)
                        if (!file.IsDirectory && file.Name != "?")
                            currentNode.Nodes.Add(new TreeNode(file.Name) { Tag = currentNode.Tag + file.Name + "/f" }); ; //пометка f в конце пути означает, что это файл!
                }
                catch (Exception ex)
                {
                    ftp.Logger("Error: " + ex.Message, txtLogger);
                }
            }

            twRemoteFolders.Nodes.Add(node);
            ftp.Logger("Transferring folders to TreeView finished.", txtLogger);
            twRemoteFolders.Enabled = true; // eklenince etkinleştir.
        }

        private void treeViewremote_AfterSelect(object sender, TreeViewEventArgs e)
        {


            Cursor.Current = Cursors.AppStarting; // işlem yapılıyor

            string secilen = ftp.slashfix(e.Node.FullPath);
            listFtptoRemoteListView(secilen);

            Cursor.Current = Cursors.Default; // işlem bitti
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // boşsa açma
            if (lwRemoteFiles.Items.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            ftp.GetSettingsFromSettingsDatabase();
            // ftp.Logger("Settings opened.", txtLogger);
            fSettings f = new fSettings();
            if (ftp.RegistryValueExists() == "true") // veritabanına yollanacak // dinamik kontrol vtye gerek gerek kalmadı
                f.chkStartup.Checked = true;
            else if (ftp.RegistryValueExists() == "diff")
                f.lblWarningStartup.Visible = true;
            else
                f.chkStartup.Checked = false;
            f.chkAutomationControl.Checked = ftp.AutomationControl;
            f.chkAutoExpangAutomations.Checked = ftp.AutoExpandAutomations;
            f.chkAutoSaveLogs.Checked = ftp.AutoSaveLogs;
            f.chkAutoScrollLogs.Checked = ftp.AutoScrollLogs;
            f.chkConfirmDeleteSavedCredentials.Checked = ftp.ConfirmDeletingSavedCredential;
            f.chkConfirmDeletingAutomation.Checked = ftp.ConfirmDeletingAutomation;
            f.chkConfirmExitingApp.Checked = ftp.ConfirmExitingApp;
            f.chkConnectStartup.Checked = ftp.AutoConnectAtStartup;
            f.chkDefaultPort.Checked = ftp.DefaultPort;
            f.chkDeleteRemoteFile.Checked = ftp.ConfirmDeletingRemoteFile;
            f.chkMinimizeTrayWhenClosing.Checked = ftp.MinimizeSystemTrayWhenClosing;
            f.chkPasswordProtect.Checked = ftp.PasswordProtectProgram;
            f.chkPasswordTray.Checked = ftp.PasswordProtectTray;
            f.chkStartInSystemTray.Checked = ftp.StartInSystemTray;
            f.cmbConnectStartup.DataSource = cmbSavedCredentials.DataSource;
            f.txtAutomationControl.Text = ftp.AutomationControlMs.ToString();
            f.txtDefaultPort.Text = ftp.DefaultPortInt.ToString();
            f.txtPasswordProtect.Text = ftp.PasswordProtectStr;
            f.txtPasswordTray.Text = ftp.PasswordProtectTrayStr;
            //
            f.ShowDialog(owner: this);
            //

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }



        internal void SaveCredentialToDatabase(string host, string username, string password, string port = "default")
        {
            if (port == "default")
            {
                port = ftp.DefaultPortInt.ToString();
            }
            if (host != "" && username != "" && password != "" && host != " " && username != " " && password != " ")
            {

                using (SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=" + @ftp.ProgramDataDir + @"\" + @ftp.FilenameCredentials))
                {
                    string hostr = string.Empty;
                    string usernamer = string.Empty;

                    using (SQLiteCommand gom = new SQLiteCommand(con))
                    {
                        string comm = "SELECT * FROM DatabaseList WHERE Host = "
                    + "'"
                    + host
                    + "'"
                    + " AND Username = "
                    + "'"
                    + username
                    + "'";

                        gom.CommandText = comm;
                        gom.CommandType = CommandType.Text;
                        con.Open();
                        SQLiteDataReader r = gom.ExecuteReader();
                        cmbSavedCredentials.DisplayMember = "Host";
                        cmbSavedCredentials.ValueMember = "ID";

                        while (r.Read())
                        {
                            hostr = Convert.ToString(r["Host"]);
                            usernamer = Convert.ToString(r["Username"]);
                        }
                        con.Close();
                    }

                    using (SQLiteCommand com = new SQLiteCommand(con))
                    {

                        if (host == hostr && username == usernamer) // aynı host ve kullanıcı adı var
                        {
                            const string message = "Same host and username found." +
                                "Do you want to change the password (and port) with new values?";
                            const string caption = "Change Password?";
                            DialogResult result = MessageBox.Show(message, caption,
                                 MessageBoxButtons.YesNo,
                                 MessageBoxIcon.Question);
                            switch (result)
                            {
                                case DialogResult.Yes:
                                    con.Open();
                                    using (SQLiteCommand fmd = con.CreateCommand())
                                    {
                                        string comm = "UPDATE DatabaseList SET Host = "
                                        + "'"
                                        + host
                                        + "', Username = "
                                        + "'"
                                        + username
                                        + "', Password = "
                                        + "'"
                                        + password
                                        + "', Port = "
                                        + "'"
                                        + port
                                        + "'"
                                        + " WHERE Host = "
                                        + "'"
                                        + host
                                        + "'"
                                        + " AND Username = "
                                        + "'"
                                        + username
                                        + "'";
                                        fmd.CommandText = comm;
                                        fmd.CommandType = CommandType.Text;
                                        fmd.ExecuteNonQuery();
                                    }
                                    con.Close();
                                    ftp.Logger("Password changed for host: " + host + " username: " + username, txtLogger);
                                    break;
                                case DialogResult.No:
                                    string selitem = host + " -> " + username;
                                    cmbSavedCredentials.SelectedItem = selitem;
                                    ftp.Logger("Password not changed. Transferred your ftp details from list for you.", txtLogger);
                                    break;
                            }
                        }
                        else
                        {
                            // string command = @"INSERT INTO DatabaseList (Host,Username,Password,Port) Values ('denemebir.com','denemeuseri','denemepasswordu','denemeportu')";
                            string command = @"INSERT INTO DatabaseList (Host,Username,Password,Port) Values ('" + host + "','" + username + "','" + password + "','" + port + "')";
                            con.Open();
                            com.CommandText = command;
                            com.ExecuteNonQuery();      // Execute the query
                            con.Close();        // Close the connection to the database
                            ftp.Logger("Saved new credentials. Host: " + host + " Username: " + username, txtLogger);
                        }

                    }
                }
            }
            else
            {
                ftp.Logger("Please fix your syntax. You entered." +
                    $"host: \"" + host + "\"" + ", " +
                    $"username: \"" + username + "\"" + ", " +
                    // $"password: \"" + password + "\"" + ", " +
                    $"port: \"" + port + "\"", txtLogger);
                return;
            }
        }

        

        

        private void btnInfo_Click(object sender, EventArgs e)
        {
            DialogResult a = MessageBox.Show(ftp.AboutText, ftp.AboutTitle, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information);
            if (a == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(ftp.ProgramRepo);
            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtPort.Text == "" || txtPort.Text == " ")
            {
                txtPort.Text = ftp.DefaultPortInt.ToString();
            }
            SaveCredentialToDatabase(txtHost.Text, txtUsername.Text, txtPassword.Text, txtPort.Text);
            ListSavedFtpstoCombobox();
        }

        private void txtport_KeyPress(object sender, KeyPressEventArgs e)
        {
            ftp.KeyPressForNumber(e, txtPort);
        }

        private void txtport_KeyUp(object sender, KeyEventArgs e)
        {
            ftp.KeyUpForNumber(txtPort);


        }

        private void renewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshRemoteList();
        }

        private void RefreshRemoteList() // daha hızlı.
        {
            Cursor.Current = Cursors.AppStarting; // işlem yapılıyor
            ftp.ToGoRenew = true;
            ListViewftpfiles_DoubleClick(null, null);
            Cursor.Current = Cursors.Default; // işlem bitti
        }

        private void cmbSaved_SelectedIndexChanged(object sender, EventArgs e)
        {

            getFTPdetailsToTextboxesWithHostandPassword((string)cmbSavedCredentials.SelectedValue);
        }



        private void getFTPdetailsToTextboxesWithHostandPassword(string all)
        {
            string[] seperator = { " -> " };
            string[] strlist = all.Split(seperator,
               StringSplitOptions.RemoveEmptyEntries);
            using (SQLiteConnection connect = new SQLiteConnection(@"data source = " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameCredentials))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    string comm = "SELECT * FROM DatabaseList WHERE Host = "
                    + "'"
                    + strlist[0]
                    + "'"
                    + " AND Username = "
                    + "'"
                    + strlist[1]
                    + "'";
                    fmd.CommandText = comm;
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    cmbSavedCredentials.DisplayMember = "Host";
                    cmbSavedCredentials.ValueMember = "ID";
                    while (r.Read())
                    {
                        txtHost.Text = Convert.ToString(r["Host"]);
                        txtUsername.Text = Convert.ToString(r["Username"]);
                        txtPassword.Text = Convert.ToString(r["Password"]);
                        txtPort.Text = Convert.ToString(r["Port"]);
                    }
                }
                connect.Close();
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            if (ftp.ConfirmDeletingSavedCredential)
            {
                string message = "Do you want to delete this from saved credentials?: " +
                    Environment.NewLine +
                    Environment.NewLine +
                    cmbSavedCredentials.SelectedValue;
                string caption = "Confirm Delete";
                DialogResult result = MessageBox.Show(message, caption,
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    DeleteSelectedFtpCredentials((string)cmbSavedCredentials.SelectedValue);

                }
            }
            else
            {
                DeleteSelectedFtpCredentials((string)cmbSavedCredentials.SelectedValue);

            }



        }

        private void DeleteSelectedFtpCredentials(string all)
        {
            if (all == null)
            {
                ftp.Logger("There is no any credentials registered. Please add one.", txtLogger);
                return;
            }
            string[] seperator = { " -> " };
            String[] strlist = all.Split(seperator,
               StringSplitOptions.RemoveEmptyEntries);
            using (SQLiteConnection connect = new SQLiteConnection(@"data source = " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameSettings))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    string comm = "DELETE FROM DatabaseList WHERE Host = "
                    + "'"
                    + strlist[0]
                    + "'"
                    + " AND Username = "
                    + "'"
                    + strlist[1]
                    + "'";
                    fmd.CommandText = comm;
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                }
                connect.Close();
            }
            ListSavedFtpstoCombobox();
        }

        private void txtLogger_TextChanged(object sender, EventArgs e)
        {
            if (ftp.AutoScrollLogs)
            {
                txtLogger.SelectionStart = txtLogger.Text.Length;
                txtLogger.ScrollToCaret();
            }
            if (ftp.AutoSaveLogs)
            {
                string path = ftp.ProgramDataDir + @"\" + ftp.FilenameLogs;

                using (StreamWriter sw = new StreamWriter(File.Open(path, System.IO.FileMode.Append)))
                {
                    int max = txtLogger.Lines.Count();
                    sw.WriteLine(txtLogger.Lines[max - 2]);
                }
            }
            
        }

        public void wait(int milliseconds)
        {
            var timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;

            // Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();

            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                // Console.WriteLine("stop wait timer");
            };

            while (timer1.Enabled)
            {
                Application.DoEvents();
            }
        }
        private void fClient_Shown(object sender, EventArgs e)
        {

            if (ftp.AutoConnectAtStartup)
            {

                Cursor = Cursors.AppStarting;
                wait(50);
                ftp.Logger("Auto connecting at startup enabled. Trying to connect. (You can change this setting in settings.)", txtLogger);
                string aconnect = null;
                using (SQLiteConnection con = new SQLiteConnection("data source=" + @ftp.ProgramDataDir + @"\" + @ftp.FilenameSettings))
                {
                    using (SQLiteCommand gom = new SQLiteCommand(con))
                    {
                        string comm = "SELECT * FROM Settings WHERE OnlyOneRow = "
                    + "'"
                    + "1"
                    + "'";

                        gom.CommandText = comm;
                        gom.CommandType = CommandType.Text;
                        con.Open();
                        SQLiteDataReader r = gom.ExecuteReader();

                        while (r.Read())
                        {
                            aconnect = Convert.ToString(r["AutoConnectingAdress"]);
                        }
                        con.Close();
                    }
                }
                ftp.Logger("Auto connect adress: " + aconnect, txtLogger);
                string[] seperator = { " -> " };

                ftp.AutoConnectingAdress = aconnect;
                string[] strlist = aconnect.Split(seperator,
                   StringSplitOptions.RemoveEmptyEntries);
                string host = string.Empty;
                string username = string.Empty;
                string password = string.Empty;
                string port = string.Empty;
                using (SQLiteConnection con = new SQLiteConnection("data source=" + @ftp.ProgramDataDir + @"\" + @ftp.FilenameCredentials))
                {
                    using (SQLiteCommand gom = new SQLiteCommand(con))
                    {
                        string comm = "SELECT * FROM DatabaseList WHERE Host = "
                    + "'"
                    + strlist[0]
                    + "'"
                    + " AND Username = "
                    + "'"
                    + strlist[1]
                    + "'";

                        gom.CommandText = comm;
                        gom.CommandType = CommandType.Text;
                        con.Open();
                        SQLiteDataReader r = gom.ExecuteReader();
                        cmbSavedCredentials.DisplayMember = "Host";
                        cmbSavedCredentials.ValueMember = "ID";
                        getFTPdetailsToTextboxesWithHostandPassword(aconnect);
                        while (r.Read())
                        {
                            host = Convert.ToString(r["Host"]);
                            username = Convert.ToString(r["Username"]);
                            password = Convert.ToString(r["Password"]);
                            port = Convert.ToString(r["Port"]);
                        }
                        con.Close();
                    }
                }
                txtHost.Text = host;
                txtUsername.Text = username;
                txtPassword.Text = password;
                txtPort.Text = port;
                listFtptoRemoteTreeView();
                listFtptoRemoteListView(".");
                ResizeListViewColumns(lwRemoteFiles);
                ftp.Logger("Auto connect finished.", txtLogger);
                Cursor = Cursors.Default;
                ListSavedFtpstoCombobox();

            }


        }



        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lwRemoteFiles.SelectedItems.Count != 0)
            {
                string pat = lwRemoteFiles.SelectedItems[0].SubItems[1].Text;
                string todelete = ftp.ActiveDirectory + "/" + lwRemoteFiles.SelectedItems[0].Text;
                if (ftp.ConfirmDeletingRemoteFile)
                {

                    if (lwRemoteFiles.SelectedItems[0].Text != "." && lwRemoteFiles.SelectedItems[0].Text != "..")
                    {

                        string message = "Do you want to delete this file?: " +
                    Environment.NewLine +
                    Environment.NewLine +
                    todelete;
                        string caption = "Confirm Delete";
                        DialogResult result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            string host = txtHost.Text;
                            string username = txtUsername.Text;
                            string password = txtPassword.Text;
                            // string FTPDosyaYolu = "ftp:/88.88.88.88:8888//FTP_Files";

                            string port = txtPort.Text;
                            string FTPDosyaYolu = "ftp://" + host + ":" + port;
                            //
                            /* Create Object Instance */
                            ftp ftpClient = new ftp(@FTPDosyaYolu, username, password);
                            if (ftp.IsDirWithPermissions(pat))
                            {
                                ftpClient.DeleteFileOrFolder(todelete, false);
                            }
                            else
                            {
                                ftpClient.DeleteFileOrFolder(todelete, true);
                            }

                            ftp.Logger("Deleted: " + todelete, txtLogger);
                            RefreshRemoteList();
                        }



                    }

                }
                else
                {
                    string host = txtHost.Text;
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;
                    // string FTPDosyaYolu = "ftp:/88.88.88.88:8888//FTP_Files";

                    string port = txtPort.Text;
                    string FTPDosyaYolu = "ftp://" + host + ":" + port;
                    //
                    /* Create Object Instance */
                    ftp ftpClient = new ftp(@FTPDosyaYolu, username, password);
                    if (ftp.IsDirWithPermissions(pat))
                    {
                        ftpClient.DeleteFileOrFolder(todelete, false);
                    }
                    else
                    {
                        ftpClient.DeleteFileOrFolder(todelete, true);
                    }
                    ftp.Logger("Deleted: " + todelete, txtLogger);
                    RefreshRemoteList();
                }
                if (ftp.ResponseStatus != null)
                {
                    ftp.Logger("Server sent: " + ftp.ResponseStatus, txtLogger);
                    ftp.ResponseStatus = null;

                }

            }
            else
            {
                ftp.Logger("You did not selected anythign for delete.", txtLogger);
            }
        }

        private void downloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lwRemoteFiles.SelectedItems.Count == 0)
            {
                ftp.Logger("Nothing selected for download.", txtLogger);
                return;

            }
            if (ftp.IsDirWithPermissions(lwRemoteFiles.SelectedItems[0].SubItems[1].Text))
            {
                ftp.ListForFilenames.Clear();
                ftp.ListForFileSizes.Clear();

                ftp.Logger("Getting files from selected folder...", txtLogger);
                string selectedfolderadress = ftp.ActiveDirectory + '/' + lwRemoteFiles.SelectedItems[0].Text;
                GetFileAdresses(selectedfolderadress);
                if (ftp.ListForFilenames.Count < 1)
                {
                    return;
                }
                FolderBrowserDialog Klasor = new FolderBrowserDialog();
                DialogResult a = Klasor.ShowDialog();
                if (a == DialogResult.OK)
                {
                    // MessageBox.Show(s.FileName);
                    string host = txtHost.Text;
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;
                    // string FTPDosyaYolu = "ftp:/88.88.88.88:8888//FTP_Files";

                    string port = txtPort.Text;
                    string FTPDosyaYolu = "ftp://" + host + ":" + port;
                    //
                    /* Create Object Instance */
                    ftp ftpClient = new ftp(@FTPDosyaYolu, username, password);

                    string local = Klasor.SelectedPath;
                    Cursor = Cursors.AppStarting;

                    ftp.Logger("Folder downloading started from: " + selectedfolderadress + "To: " + local, txtLogger);
                    ftpClient.DownloadFolder(prgOverall, lblAllProgress, lblAllBytes, local, prgCurrent, lblCurrentProgress, lblCurrentBytes);
                    ftp.Logger("Folder downloading finished from: " + selectedfolderadress + "To: " + local, txtLogger);
                    Cursor = Cursors.Default;

                }

                ftp.ListForFilenames.Clear();
                ftp.ListForFileSizes.Clear();
            }
            else
            {
                string todownload = ftp.ActiveDirectory + '/' + lwRemoteFiles.SelectedItems[0].Text;
                SaveFileDialog s = new SaveFileDialog();
                s.FileName = lwRemoteFiles.SelectedItems[0].Text;
                s.Title = "Download File: " + lwRemoteFiles.SelectedItems[0].Text;
                //s.ShowDialog(this);

                if (s.ShowDialog() == DialogResult.OK)
                {
                    // MessageBox.Show(s.FileName);
                    string host = txtHost.Text;
                    string username = txtUsername.Text;
                    string password = txtPassword.Text;
                    // string FTPDosyaYolu = "ftp:/88.88.88.88:8888//FTP_Files";

                    string port = txtPort.Text;
                    string FTPDosyaYolu = "ftp://" + host + ":" + port;
                    //
                    /* Create Object Instance */
                    ftp ftpClient = new ftp(@FTPDosyaYolu, username, password);
                    ///* Download a File */
                    Cursor = Cursors.AppStarting;
                    ftp.Logger("Download started: " + todownload + " to: " + s.FileName, txtLogger);
                    string a = ftpClient.DownloadFile(todownload, s.FileName, progressBar: prgCurrent, lblCurrentProgress, lblCurrentBytes);

                    ftp.Logger(a, txtLogger);
                    Cursor = Cursors.Default;
                }
            }
        }

        private void uploadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lwLocalFiles.SelectedItems.Count == 0)
            {
                ftp.Logger("You did not selected anything for upload.", txtLogger);
                return;
            }
            // MessageBox.Show(s.FileName);
            string host = txtHost.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            // string FTPDosyaYolu = "ftp:/88.88.88.88:8888//FTP_Files";

            string port = txtPort.Text;
            string FTPDosyaYolu = "ftp://" + host + ":" + port;
            //
            /* Create Object Instance */
            ftp ftpClient = new ftp(@FTPDosyaYolu, username, password);
            string toupload = cmbLocal.Text;
            Cursor = Cursors.AppStarting;
            ftp.Logger("Upload started: " + toupload + " to: " + ftp.ActiveDirectory, txtLogger);
            string v = ftpClient.UploadFile(lwLocalFiles.SelectedItems[0].Text, toupload, prgCurrent, lblCurrentProgress, lblCurrentBytes);
            ftp.Logger(v, txtLogger);

            RefreshRemoteList();
            Cursor = Cursors.Default;

        }



        private void listViewftpfiles_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files != null)
            {


                MessageBox.Show(files[0]);
            }

        }

        private void listViewftpfiles_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
            if (ftp.ActiveDirectory == null || ftp.ActiveDirectory == "" || ftp.ActiveDirectory == " ")
            {
                fClient.ActiveForm.Text = "MicroSharpFTP - Not connected yet. You can't upload anything to nowhere.";
            }
            else
            {
                fClient.ActiveForm.Text = "MicroSharpFTP - Upload file to: " + ftp.ActiveDirectory + " ?";
            }

        }

        private void listViewftpfiles_DragLeave(object sender, EventArgs e)
        {
            fClient.ActiveForm.Text = "MicroSharpFTP";
        }

        private void listViewftpfiles_ItemDrag(object sender, ItemDragEventArgs e)
        {
            //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            //messageBoxCS.AppendFormat("{0} = {1}", "Button", e.Button);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Item", listViewftpfiles.SelectedItems[0]);
            //messageBoxCS.AppendLine();
            //MessageBox.Show(messageBoxCS.ToString(), "ItemDrag Event");
        }

        private void listViewftpfiles_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void listViewftpfiles_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            treeView1_AfterSelect(null, null);
        }

        private void showMicroSharpFTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormShowHide();
        }

        

        private void notifyIcon1_Click(object sender, EventArgs e)
        {


        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                FormShowHide();
            }
        }

        private void exitMicroSharpFTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AppQuiting();
        }

        private static void AppQuiting()
        {
            if (ftp.ConfirmExitingApp)
            {
                const string message = "Do you really want to exit from MicroSharpFTP?";
                const string caption = "You're Quiting";
                DialogResult result = MessageBox.Show(message, caption,
                     MessageBoxButtons.YesNo,
                     MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Application.Exit();
                }

            }
            else
            {
                Application.Exit();
            }
        }

        internal void FormShowHide()
        {

            if (this.Visible == true)
            {
                foreach (Form f in Application.OpenForms)    //it will return all the open forms
                {
                    f.Visible = false;
                }
            }
            else
            {
                if (ftp.PasswordProtectTray)
                {
                    fLogin fLogin = new fLogin();
                    fLogin.type = "tray";
                    fLogin.Show();
                    if (fLogin.type == "ok")
                    {
                        foreach (Form f in Application.OpenForms)    //it will return all the open forms
                        {
                            if (!(f.Text == "Login to MicroSharpFTP"))
                            {
                                f.Visible = true;
                            }
                        }
                    }
                }
                else
                {
                    foreach (Form f in Application.OpenForms)    //it will return all the open forms
                    {
                        if (!(f.Text == "Login to MicroSharpFTP"))
                        {
                            f.Visible = true;
                        }
                    }
                }


            }
        }

        private void fClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing) // user kapatıyorsa
            {
                e.Cancel = true;
                if (ftp.MinimizeSystemTrayWhenClosing)
                {
                    FormShowHide();
                    notifyIcon.ShowBalloonTip(3000, "Closed to here", "You can access MicroSharpFTP in system tray. You can change this setting in settings.", ToolTipIcon.Info);
                }
                else
                {
                    AppQuiting();
                }
            }

        }

        private void fClient_StyleChanged(object sender, EventArgs e)
        {

        }

        private void microSharpFTPSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            btnSettings_Click(null, null);
        }

        private void aboutMicroSharpFTPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = true;
            btnInfo_Click(null, null);
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lwRemoteFiles.SelectedItems.Count == 1)
            {

                string toupload = cmbLocal.Text;
                Cursor = Cursors.AppStarting;
                string secilen = lwRemoteFiles.SelectedItems[0].Text;
                //
                fNewFolderAndRename ren = new fNewFolderAndRename();
                ren.txtProcess.Text = secilen;

                ren.Host = txtHost.Text;
                ren.UserName = txtUsername.Text;
                ren.Password = txtPassword.Text;
                ren.Port = txtPort.Text;
                ren.Mode = "rename";
                //

                ren.btnCreate.Text = "Rename";
                ren.Text = "Rename";
                ren.FilenameForRename = secilen;
                ren.lblProcess.Text = "Rename: " + secilen;
                ftp.Logger("Renaming: " + ftp.ActiveDirectory + '/' + secilen, txtLogger);
                ren.ShowDialog(this);
                if (!ftp.DidUserClosed) //cancele tıklandığında alttaki işlemleri yapmasın
                {
                    ftp.Logger("Server sent: " + ftp.ResponseStatus, txtLogger);
                    ftp.ResponseStatus = null;
                    RefreshRemoteList(); // daha performanslı
                    // önceden alttaydı bunlar:
                    ftp.DidUserClosed = true;
                    listFtptoRemoteTreeView();
                    //
                    //expand to full path
                    // selectLastNode();
                    // çok zaman alıyor

                }

                // ftp.Logger(v, txtLogger);
                Cursor = Cursors.Default;
            }
            else
            {
                ftp.Logger("You did not selected anythign for rename.", txtLogger);
            }
        }

        private void btnAutomation_Click(object sender, EventArgs e)
        {
            // ftp.Logger("Automations panel opened.", txtLogger);
            // db kontrol

            /// db kontrol
            fAutomation f = new fAutomation();

            f.cmbForAccount.DataSource = this.cmbSavedCredentials.DataSource;
            f.SelectedAccount = cmbSavedCredentials.SelectedIndex;
            f.Show();



        }
        internal void CreateAutomationsDatabase()
        {

            if (!File.Exists(@ftp.ProgramDataDir + @"\" + @ftp.FilenameAutomations))
            {

                string createTableQuery = @"CREATE TABLE IF NOT EXISTS [AutomationList] (
                          [ID] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                          [ForAccount] VARCHAR(5000) NOT NULL,
                          [Type] VARCHAR(1024)  NOT NULL,
                          [FireTime] VARCHAR(50) NOT NULL,
                          [Frrom] VARCHAR(5000) NULL,
                          [Tto] VARCHAR(5000) NULL,
                          [Notes] VARCHAR(5000) NULL,
                          [Percent] INTEGER(3) NULL,
                          [AddingTime] VARCHAR(50) NOT NULL
                          )";
                if (!Directory.Exists(@ftp.ProgramDataDir))
                {
                    Directory.CreateDirectory(@ftp.ProgramDataDir);
                }

                System.Data.SQLite.SQLiteConnection.CreateFile(@ftp.ProgramDataDir + @"\" + @ftp.FilenameAutomations);

                ftp.Logger("Automation database not found. Created: " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameAutomations, txtLogger);
                // https://www.fluxbytes.com/csharp/how-to-create-and-connect-to-an-sqlite-database-in-c/
                using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=" + @ftp.ProgramDataDir + @"\" + @ftp.FilenameAutomations))
                {
                    using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(con))
                    {
                        con.Open();                             // Open the connection to the database

                        com.CommandText = createTableQuery;     // Set CommandText to our query that will create the table
                        com.ExecuteNonQuery();                  // Execute the query

                        com.CommandText = "INSERT INTO DatabaseList (Host,Username,Password,Port) Values ('denemebir.com','denemeuseri','denemepasswordu','denemeportu')";

                        con.Close();        // Close the connection to the database
                    }
                }
            }
            else if (File.Exists(@ftp.ProgramDataDir + @"\" + @ftp.FilenameSettings)) // db varsa
            {
                ftp.Logger("Automation database found. Connected: " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameAutomations, txtLogger);
            }
        }

        private void automateUploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAutomation f = new fAutomation();
            f.SelectedAction = 1;
            f.SelectedAccount = cmbSavedCredentials.SelectedIndex;
            if (ftp.ActiveDirectory != null || ftp.ActiveDirectory != "" || ftp.ActiveDirectory != " ")
            {
                f.txtTo.Text = ftp.ActiveDirectory;
            }
            f.txtFrom.Text = cmbLocal.Text;
            f.cmbForAccount.DataSource = cmbSavedCredentials.DataSource;
            f.Show();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //lblTime.Text = DateTime.Now.ToString("dd-MMM-yyyy hh:mm:ss tt");
            lblTime.Text = DateTime.Now.ToString();
        }

        private void lblTime_TextChanged(object sender, EventArgs e)
        {
            if (ftp.AutoSaveLogs)
            {
                lblLogger.Text = "Auto-Saving Logs";
                lblLogger.ForeColor= Color.ForestGreen;
            }
            else
            {
                lblLogger.Text = "Not Auto-Saving Logs";
                lblLogger.ForeColor = Color.DarkRed;
            }
            if (ftp.AutomationControl)
            {
                lblautomations.Text = "Automations Enabled";
                lblautomations.ForeColor = Color.ForestGreen;
            }
            else
            {
                lblautomations.Text = "Automations Disabled";
                lblautomations.ForeColor = Color.DarkRed;
            }


            if (ftp.ResponseStatus != null && ftp.ResponseStatus != "" && ftp.ResponseStatus != " ")
            {
                ftp.Logger(ftp.ResponseStatus, txtLogger);
                ftp.ResponseStatus = null;
            }

            if (!ftp.AutomationsDownloaded) // otomasyonlar indirilmediyse indir // yeni ekleme yapıldığında false yapılacak.
            {
                using (SQLiteConnection connect = new SQLiteConnection(@"data source = " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameAutomations))
                {

                    connect.Open();
                    using (SQLiteCommand fmd = connect.CreateCommand())
                    {
                        fmd.CommandText = @"SELECT DISTINCT * FROM AutomationList";
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader r = fmd.ExecuteReader();
                        while (r.Read())
                        {
                            ftp.IDList.Add(Convert.ToString(r["ID"]));
                            ftp.TimeList.Add(Convert.ToString(r["FireTime"]));
                            ftp.PercentList.Add(Convert.ToString(r["Percent"]));
                        }
                    }
                    connect.Close();
                }
                ftp.AutomationsDownloaded = true;

            }
            else
            {
                if (ftp.AutomationControl)
                {
                    automations();
                }

            }

        }

        internal void automations()
        {
            //
            if (ftp.IDList.Count > 0) // otomasyon varsa
            {
                for (int i = 0; i < ftp.IDList.Count; i++)
                {

                    if (DateTime.Now.ToString() == ftp.TimeList[i])
                    {
                        if (ftp.PercentList[i] != "100") // işlem tamamsa yapma
                        {
                            //ftp.Logger(ftp.timelist[i] + "  -  " + ftp.idlist[i] + "  -  " + "zamanı.", txtLogger);
                            // işlemi gerçekleştir. // ayrı fonksiyon
                            doProcess(ftp.IDList[i]);
                        }

                    }
                    else
                    {
                        //ftp.Logger(ftp.timelist[i] + "  -  " + ftp.idlist[i] + "  -  " + "zamanı değil.", txtLogger);
                    }


                }
            }
        }

        //
        internal void updateProcessPercent(string percent, string id)
        {
            percent = percent.Replace("%", "");
            percent = percent.Replace(" %", "");
            percent = percent.Replace("% ", "");
            using (SQLiteConnection connect = new SQLiteConnection(@"data source = " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameAutomations))
            {

                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    string comm = "UPDATE AutomationList SET Percent = "
                                        + "'"
                                        + percent
                                        + "'"
                                        + "WHERE ID = '"
                                        + id
                                        + "'";
                    //
                    fmd.CommandText = comm;
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();

                }
                connect.Close();
            }
        }
        //

        internal void doProcess(string id) // işlem idsi yeterli. // başarısız olursa yazdırsın. // başarılı olursa yazdısın.
        {

            //
            string account = string.Empty;
            string type = string.Empty;
            string from = string.Empty;
            string to = string.Empty;
            string percent = string.Empty;

            using (SQLiteConnection connect = new SQLiteConnection(@"data source = " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameAutomations))
            {

                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    string com = @"SELECT DISTINCT * FROM AutomationList WHERE ID = '";
                    com += id;
                    com += "'";
                    fmd.CommandText = com;
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        account = Convert.ToString(r["ForAccount"]);
                        type = Convert.ToString(r["Type"]);
                        from = Convert.ToString(r["Frrom"]);
                        to = Convert.ToString(r["Tto"]);
                        percent = Convert.ToString(r["Percent"]);
                    }
                }
                connect.Close();
            }
            if (percent == "100")
            {
                return;
            }
            getFTPdetailsToTextboxesWithHostandPassword(account); // bağlanma ayrtıntıları oto girilir.
            string host = txtHost.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            // string FTPDosyaYolu = "ftp:/88.88.88.88:8888//FTP_Files";

            if (txtPort.Text == "" || txtPort.Text == " ")
            {
                txtPort.Text = ftp.DefaultPortInt.ToString();
            }
            string port = txtPort.Text;
            string FTPDosyaYolu = "ftp://" + host + ":" + port;
            //
            /* Create Object Instance */
            ftp ftpClient = new ftp(@FTPDosyaYolu, username, password);
            switch (type)
            {
                case "Download":
                    {
                        // listFtptoRemoteTreeView();
                        ftp.Logger("Automatic for download started  for id: " + id, txtLogger);
                        // listFtptoRemoteListView(to);
                        // ResizeListViewColumns(listViewftpfiles);
                        //
                        Cursor = Cursors.AppStarting;
                        
                        if (!from.EndsWith("/"))
                        {
                            string v = null;
                            try
                            {
                                v = ftpClient.DownloadFile(from, to, prgCurrent, lblCurrentProgress, lblCurrentBytes);
                            }
                            catch (Exception)
                            {

                                v = "Download finished unsuccesfully.";
                                updateProcessPercent("0", id);
                            }
                            ftp.Logger(v, txtLogger);

                        }
                        else
                        {
                            try
                            {
                                GetFileAdresses(from);
                                ftpClient.DownloadFolder(prgOverall, lblAllProgress, lblAllBytes, to, prgCurrent, lblCurrentProgress, lblCurrentBytes);
                                ftp.Logger("Download succesfully from: " + from + ", to: "+to + ", id: " + id, txtLogger);
                            }
                            catch (Exception)
                            {

                                ftp.Logger("Download unsuccesfully from: " + from + ", to: " + to + ", id: " + id, txtLogger);
                                updateProcessPercent("0", id);
                            }
                            
                        }
                        
                        // refreshRemoteList();
                        Cursor = Cursors.Default;
                        ftp.Logger("Automatic download finished for id: " + id, txtLogger);
                        updateProcessPercent(lblCurrentProgress.Text, id);
                        break;
                    }
                case "Upload":
                    {
                        // listFtptoRemoteTreeView();
                        ftp.Logger("Automatic for upload started  for id: " + id, txtLogger);
                        // listFtptoRemoteListView(to);
                        // ResizeListViewColumns(listViewftpfiles);
                        //
                        Cursor = Cursors.AppStarting;
                        ftp.ActiveDirectory = to;
                        if (!from.EndsWith(@"\"))
                        {
                            try
                            {
                                FileInfo fileInfo = new FileInfo(from);
                                string touploadname = fileInfo.Name;
                                string v = ftpClient.UploadFile(touploadname, from, prgCurrent, lblCurrentProgress, lblCurrentBytes);
                                ftp.Logger(v, txtLogger);
                            }
                            catch (Exception)
                            {

                                ftp.Logger("Upload unsuccesfully from: " + from + ", to:" + to + ", id: " + id, txtLogger);
                                updateProcessPercent("0", id);
                            }
                            
                        }
                        else
                        {
                            try
                            {
                                ftpClient.UploadFolder(prgOverall, lblAllProgress, lblAllBytes, ftp.ActiveDirectory, from, prgCurrent, lblCurrentBytes, lblAllBytes);
                                ftp.Logger("Uploading folder succesfully from: " + from + ", to: " + ftp.ActiveDirectory + ", id: " +id, txtLogger);
                            }
                            catch (Exception)
                            {
                                ftp.Logger("Uploading folder unsuccesfully from : " + from + ", to: " + ftp.ActiveDirectory + ", id: " + id, txtLogger);
                                updateProcessPercent("0", id);
                            }
                            
                        }
                        
                        // refreshRemoteList();
                        Cursor = Cursors.Default;
                        ftp.Logger("Automatic for upload finished for id: " + id, txtLogger);
                        updateProcessPercent(lblCurrentProgress.Text, id);
                        break;
                    }
                case "Rename":
                    {
                        // listFtptoRemoteTreeView();
                        ftp.Logger("Automatic for rename started  for id: " + id, txtLogger);
                        // listFtptoRemoteListView(to);
                        // ResizeListViewColumns(listViewftpfiles);
                        //
                        Cursor = Cursors.AppStarting;
                        //
                        ftp.Logger("Renaming: " + from, txtLogger);
                        //
                        string ret = ftpClient.RenameFileOrFolder(from, to, true);

                        ftp.Logger(ret, txtLogger);
                        if (ret.StartsWith("250"))
                        {
                            updateProcessPercent("100", id);
                        }
                        else
                        {
                            updateProcessPercent("0", id);
                        }
                        // refreshRemoteList();
                        Cursor = Cursors.Default;
                        ftp.Logger("Automatic for rename finished for id: " + id, txtLogger);
                        updateProcessPercent(lblCurrentProgress.Text, id);
                        break;
                    }
                case "Delete":
                    {
                        // listFtptoRemoteTreeView();
                        ftp.Logger("Automatic for delete started  for id: " + id, txtLogger);
                        // listFtptoRemoteListView(to);
                        // ResizeListViewColumns(listViewftpfiles);
                        //
                        Cursor = Cursors.AppStarting;
                        //
                        ftp.Logger("Deleting: " + from, txtLogger);
                        //
                        bool isdir = from.EndsWith("/");
                        string ret = ftpClient.DeleteFileOrFolder(from, !isdir);

                        ftp.Logger(ret, txtLogger);
                        if (ret.StartsWith("250"))
                        {
                            updateProcessPercent("100", id);
                        }
                        else
                        {
                            updateProcessPercent("0", id);
                        }
                        // refreshRemoteList();
                        Cursor = Cursors.Default;
                        ftp.Logger("Automatic for delete finished for id: " + id, txtLogger);
                        updateProcessPercent(lblCurrentProgress.Text, id);
                        break;
                    }
                case "New Folder":
                    {
                        // listFtptoRemoteTreeView();
                        ftp.Logger("Automatic for new folder started  for id: " + id, txtLogger);
                        // listFtptoRemoteListView(to);
                        // ResizeListViewColumns(listViewftpfiles);
                        //
                        Cursor = Cursors.AppStarting;
                        //
                        string ret = ftpClient.CreateDirectory(from);
                        ftp.Logger(ret, txtLogger);
                        if (ret.StartsWith("257"))
                        {
                            updateProcessPercent("100", id);
                        }
                        else
                        {
                            updateProcessPercent("0", id);
                        }
                        // refreshRemoteList();
                        Cursor = Cursors.Default;
                        ftp.Logger("Automatic for new folder finished for id: " + id, txtLogger);
                        updateProcessPercent(lblCurrentProgress.Text, id);
                        break;
                    }

                default:
                    ftp.Logger("Type was invalid.", txtLogger);
                    break;
            }

        }

        private void copyFullLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {


        }

        private void denemeToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }



        private void GetFileAdresses(string dir)
        {
            Cursor = Cursors.AppStarting;
            if (!dir.EndsWith("/"))
            {
                dir += "/";
            }
            IFormatProvider culture = CultureInfo.GetCultureInfo("en-us");
            string host = txtHost.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            string port = txtPort.Text;
            string FTPDosyaYolu = "ftp://" + host + ":" + port;
            ftp ftpClient = new ftp(@FTPDosyaYolu, username, password);
            string[] listedselecteddir = ftpClient.DetailedDirectoryList(dir); // aktif dir + / + klasör adı

            string pattern = @"^([\w-]+)\s+(\d+)\s+(\w+)\s+(\w+)\s+(\d+)\s+" +
                    @"(\w+\s+\d+\s+\d+|\w+\s+\d+\s+\d+:\d+)\s+(.+)$";
            Regex regex = new Regex(pattern);


            for (int i = 0; i < listedselecteddir.Length; i++)
            {
                Match match = regex.Match(listedselecteddir[i]);

                if (listedselecteddir[i] == null
                    || listedselecteddir[i] == string.Empty
                    || listedselecteddir[i] == ""
                    || listedselecteddir[i] == " "
                    || match.Groups[7].Value == "."
                    || match.Groups[7].Value == "..")
                {
                    continue;
                }
                if (match.Groups[7].Value != "." && match.Groups[7].Value != ".." && ftp.IsDirWithPermissions(match.Groups[1].Value))
                {
                    GetFileAdresses(dir + match.Groups[7].Value);
                }
                else
                {

                    string ad = dir;
                    ad += match.Groups[7].Value; // isim

                    long boyut = long.Parse(match.Groups[5].Value, culture);

                    if (ad != null)
                    {
                        ftp.ListForFilenames.Add(ad);
                        ftp.ListForFileSizes.Add(boyut);
                    }

                }



            }
            Cursor = Cursors.Default;
        }

        private void createFilelistForThisFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fullLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lwRemoteFiles.SelectedItems.Count != 0)
            {
                string fullname = cmbRemote.Text + "/" + lwRemoteFiles.SelectedItems[0].Text;
                string pat = lwRemoteFiles.SelectedItems[0].SubItems[1].Text;
                if (ftp.IsDirWithPermissions(pat))
                {
                    fullname += "/";
                }
                Clipboard.SetText(fullname);
                ftp.Logger("Copied to clipboard: " + fullname, txtLogger);
            }
            else
            {
                Clipboard.SetText(ftp.ActiveDirectory);
                ftp.Logger("Copied to clipboard: " + ftp.ActiveDirectory, txtLogger);
            }
        }

        private void flielistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lwRemoteFiles.SelectedItems.Count != 0)
            {
                string pat = lwRemoteFiles.SelectedItems[0].SubItems[1].Text;
                string suankifolder = ftp.ActiveDirectory;
                if (lwRemoteFiles.SelectedItems[0].Text == "..")
                {
                    ftp.Logger("You cannot create file list for \"..\". Please go a top folder and create again.", txtLogger);
                    return;
                }
                if (ftp.IsDirWithPermissions(pat))
                {
                    ftp.ListForFilenames.Clear();
                    ftp.ListForFileSizes.Clear();
                    string selectedfolderadress = ftp.ActiveDirectory + '/' + lwRemoteFiles.SelectedItems[0].Text;
                    GetFileAdresses(selectedfolderadress);
                    string towrite = null;
                    for (int i = 0; i < ftp.ListForFilenames.Count; i++)
                    {
                        towrite += "File: " + ftp.ListForFilenames[i] + " | Size: " + ftp.BytesToString(ftp.ListForFileSizes[i]) + Environment.NewLine;
                    }
                    Clipboard.SetText(towrite);
                    ftp.Logger("Filenames copied to clipboard for: " + selectedfolderadress, txtLogger);
                    ftp.ListForFilenames.Clear();
                    ftp.ListForFileSizes.Clear();
                }
                else
                {
                    ftp.Logger("Select a folder to create file-list. The selected was not a folder: " + ftp.ActiveDirectory + "/" + lwRemoteFiles.SelectedItems[0].Text, txtLogger);
                }

            }
            else
            {
                ftp.ListForFilenames.Clear();
                ftp.ListForFileSizes.Clear();
                string selectedfolderadress = ftp.ActiveDirectory;
                GetFileAdresses(selectedfolderadress);
                string towrite = null;
                for (int i = 0; i < ftp.ListForFilenames.Count; i++)
                {
                    towrite += "File: " + ftp.ListForFilenames[i] + " | Size: " + ftp.BytesToString(ftp.ListForFileSizes[i]) + Environment.NewLine;
                }
                Clipboard.SetText(towrite);
                ftp.Logger("Filenames copied to clipboard for: " + selectedfolderadress, txtLogger);
                ftp.ListForFilenames.Clear();
                ftp.ListForFileSizes.Clear();
            }
        }

        private void contextMenuStripMicroSharpFTP_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (Form f in Application.OpenForms)    //it will return all the open forms
            {

                if (f.Text.StartsWith("MicroSharpFTP"))
                {
                    if (f.Visible == true)
                    {
                        cmsMain.Items[0].Text = "Hide MicroSharpFTP";
                    }
                    else
                    {
                        cmsMain.Items[0].Text = "Show MicroSharpFTP";
                    }
                }
            }
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnConnectSave_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.AppStarting; // işlem yapılıyor
            if (txtPort.Text == "" || txtPort.Text == " ")
            {
                txtPort.Text = ftp.DefaultPortInt.ToString();
            }
            SaveCredentialToDatabase(txtHost.Text, txtUsername.Text, txtPassword.Text, txtPort.Text);
            listFtptoRemoteTreeView();
            listFtptoRemoteListView(".");
            ResizeListViewColumns(lwRemoteFiles);
            ListSavedFtpstoCombobox();
            Cursor.Current = Cursors.Default; // işlem bitti
        }

        private void tLogs_Tick(object sender, EventArgs e)
        {
            
        }

        private void lwRemoteFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lwLocalFiles_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmsLocalFolders_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void uploadToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
         
            Cursor = Cursors.AppStarting;
            ftp.ListForFilenamesU.Clear();
            ftp.ListForFileSizesU.Clear();
            //
            if (twLocalFolders.SelectedNode == null)
            {
                return;
            }
           
            string @folder = twLocalFolders.SelectedNode.FullPath;
            ftp.Logger("Folder Uploading Started: " + folder, txtLogger);
            string host = txtHost.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;
            // string FTPDosyaYolu = "ftp:/88.88.88.88:8888//FTP_Files";

            string port = txtPort.Text;
            string FTPDosyaYolu = "ftp://" + host + ":" + port;
            //
            /* Create Object Instance */
            new ftp(FTPDosyaYolu, username, password).UploadFolder(prgOverall, lblAllProgress, lblAllBytes, ftp.ActiveDirectory, @folder, prgCurrent, lblCurrentBytes, lblAllBytes);
            RefreshRemoteList();
            ftp.Logger("Folder Uploading Finished: " + folder, txtLogger);
            Cursor = Cursors.Default;
        }

        private void refreshToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ListLocalDrives();
        }

        private void automateUploadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            fAutomation f = new fAutomation
            {
                SelectedAction = 1,
                SelectedAccount = cmbSavedCredentials.SelectedIndex
            };
            if (ftp.ActiveDirectory != null || ftp.ActiveDirectory != "" || ftp.ActiveDirectory != " ")
            {
                string uzak = ftp.ActiveDirectory;
                if (!uzak.EndsWith(@"/"))
                {
                    uzak += @"/";
                }
                f.txtTo.Text = uzak;
            }
            string yakin = @twLocalFolders.SelectedNode.FullPath;
            yakin = yakin.Replace(@":\\", @":\");
            if (!yakin.EndsWith(@"\"))
            {
                yakin += @"\";
            }
            f.txtFrom.Text = yakin;
            f.cmbForAccount.DataSource = cmbSavedCredentials.DataSource;
            f.Show();
        }

        private void cmsLocalFiles_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void automateDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAutomation f = new fAutomation
            {
                SelectedAction = 0,
                SelectedAccount = cmbSavedCredentials.SelectedIndex
            };
            if (ftp.ActiveDirectory != null || ftp.ActiveDirectory != "" || ftp.ActiveDirectory != " ")
            {
                string aktif = ftp.ActiveDirectory;
                if (!aktif.EndsWith("/"))
                    aktif += "/";
                string pat = lwRemoteFiles.SelectedItems[0].SubItems[1].Text;
                aktif+= lwRemoteFiles.SelectedItems[0].Text;
                if (ftp.IsDirWithPermissions(pat))
                {
                    aktif += "/";
                }

                f.txtFrom.Text = aktif;

            }
            f.cmbForAccount.DataSource = cmbSavedCredentials.DataSource;
            f.Show();
        }
    }
}
