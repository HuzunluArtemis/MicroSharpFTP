
namespace MicroSharpFTP
{
    partial class fClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("/");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fClient));
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lblHost = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.gbConnect = new System.Windows.Forms.GroupBox();
            this.btnSaveCredentials = new System.Windows.Forms.Button();
            this.btnConnectSaveCredentials = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.cmbSavedCredentials = new System.Windows.Forms.ComboBox();
            this.lwLocalFiles = new System.Windows.Forms.ListView();
            this.dosyaadi = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.size = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsLocalFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uploadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automateUploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.twLocalFolders = new System.Windows.Forms.TreeView();
            this.cmsLocalFolders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelust = new System.Windows.Forms.Panel();
            this.lblLogger = new System.Windows.Forms.Label();
            this.lblautomations = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.lblAllBytes = new System.Windows.Forms.Label();
            this.lblAllProgress = new System.Windows.Forms.Label();
            this.lblCurrentBytes = new System.Windows.Forms.Label();
            this.lblCurrentProgress = new System.Windows.Forms.Label();
            this.lblOverall = new System.Windows.Forms.Label();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.prgCurrent = new System.Windows.Forms.ProgressBar();
            this.prgOverall = new System.Windows.Forms.ProgressBar();
            this.grbSaved = new System.Windows.Forms.GroupBox();
            this.btnDeleteSelectedCredentials = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.btnAutomations = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.cmbRemote = new System.Windows.Forms.ComboBox();
            this.cmbLocal = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblLocal = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tlremoteall = new System.Windows.Forms.TableLayoutPanel();
            this.twRemoteFolders = new System.Windows.Forms.TreeView();
            this.tlremotetextbox = new System.Windows.Forms.TableLayoutPanel();
            this.lblRemote = new System.Windows.Forms.Label();
            this.lwRemoteFiles = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsRemoteFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToClipboardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullLinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flielistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.txtLogger = new System.Windows.Forms.TextBox();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmsMain = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showMicroSharpFTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.microSharpFTPSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMicroSharpFTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMicroSharpFTPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tAutomations = new System.Windows.Forms.Timer(this.components);
            this.tLogs = new System.Windows.Forms.Timer(this.components);
            this.refreshToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.automateUploadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.automateDownloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbConnect.SuspendLayout();
            this.cmsLocalFiles.SuspendLayout();
            this.cmsLocalFolders.SuspendLayout();
            this.panelust.SuspendLayout();
            this.grbSaved.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tlremoteall.SuspendLayout();
            this.tlremotetextbox.SuspendLayout();
            this.cmsRemoteFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.cmsMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUsername
            // 
            this.txtUsername.BackColor = System.Drawing.Color.Lavender;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsername.Location = new System.Drawing.Point(222, 19);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(108, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.Lavender;
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPassword.Location = new System.Drawing.Point(398, 19);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(108, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtHost
            // 
            this.txtHost.BackColor = System.Drawing.Color.Lavender;
            this.txtHost.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHost.Location = new System.Drawing.Point(44, 19);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(108, 20);
            this.txtHost.TabIndex = 1;
            // 
            // lblHost
            // 
            this.lblHost.AutoSize = true;
            this.lblHost.Location = new System.Drawing.Point(6, 22);
            this.lblHost.Name = "lblHost";
            this.lblHost.Size = new System.Drawing.Size(32, 13);
            this.lblHost.TabIndex = 4;
            this.lblHost.Text = "Host:";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(158, 22);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(58, 13);
            this.lblUsername.TabIndex = 4;
            this.lblUsername.Text = "Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(336, 22);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // txtPort
            // 
            this.txtPort.BackColor = System.Drawing.Color.Lavender;
            this.txtPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPort.Location = new System.Drawing.Point(547, 19);
            this.txtPort.MaxLength = 5;
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(61, 20);
            this.txtPort.TabIndex = 4;
            this.txtPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtport_KeyPress);
            this.txtPort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtport_KeyUp);
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(512, 22);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 13);
            this.lblPort.TabIndex = 4;
            this.lblPort.Text = "Port:";
            // 
            // gbConnect
            // 
            this.gbConnect.Controls.Add(this.lblHost);
            this.gbConnect.Controls.Add(this.btnSaveCredentials);
            this.gbConnect.Controls.Add(this.btnConnectSaveCredentials);
            this.gbConnect.Controls.Add(this.btnConnect);
            this.gbConnect.Controls.Add(this.txtUsername);
            this.gbConnect.Controls.Add(this.txtPassword);
            this.gbConnect.Controls.Add(this.txtHost);
            this.gbConnect.Controls.Add(this.lblPort);
            this.gbConnect.Controls.Add(this.txtPort);
            this.gbConnect.Controls.Add(this.lblUsername);
            this.gbConnect.Controls.Add(this.lblPassword);
            this.gbConnect.Location = new System.Drawing.Point(12, 12);
            this.gbConnect.Name = "gbConnect";
            this.gbConnect.Size = new System.Drawing.Size(945, 53);
            this.gbConnect.TabIndex = 7;
            this.gbConnect.TabStop = false;
            this.gbConnect.Text = "Connect with new Credentials";
            // 
            // btnSaveCredentials
            // 
            this.btnSaveCredentials.Location = new System.Drawing.Point(723, 18);
            this.btnSaveCredentials.Name = "btnSaveCredentials";
            this.btnSaveCredentials.Size = new System.Drawing.Size(103, 23);
            this.btnSaveCredentials.TabIndex = 6;
            this.btnSaveCredentials.Text = "Save Credentials";
            this.btnSaveCredentials.UseVisualStyleBackColor = true;
            this.btnSaveCredentials.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnConnectSaveCredentials
            // 
            this.btnConnectSaveCredentials.Location = new System.Drawing.Point(832, 18);
            this.btnConnectSaveCredentials.Name = "btnConnectSaveCredentials";
            this.btnConnectSaveCredentials.Size = new System.Drawing.Size(103, 23);
            this.btnConnectSaveCredentials.TabIndex = 7;
            this.btnConnectSaveCredentials.Text = "Connect && Save";
            this.btnConnectSaveCredentials.UseVisualStyleBackColor = true;
            this.btnConnectSaveCredentials.Click += new System.EventHandler(this.btnConnectSave_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(614, 18);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(103, 23);
            this.btnConnect.TabIndex = 5;
            this.btnConnect.Text = "Only Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.buttonconnect_Click);
            // 
            // cmbSavedCredentials
            // 
            this.cmbSavedCredentials.BackColor = System.Drawing.Color.Lavender;
            this.cmbSavedCredentials.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSavedCredentials.FormattingEnabled = true;
            this.cmbSavedCredentials.Location = new System.Drawing.Point(9, 19);
            this.cmbSavedCredentials.Name = "cmbSavedCredentials";
            this.cmbSavedCredentials.Size = new System.Drawing.Size(383, 21);
            this.cmbSavedCredentials.TabIndex = 8;
            this.cmbSavedCredentials.SelectedIndexChanged += new System.EventHandler(this.cmbSaved_SelectedIndexChanged);
            // 
            // lwLocalFiles
            // 
            this.lwLocalFiles.BackColor = System.Drawing.Color.Lavender;
            this.lwLocalFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lwLocalFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dosyaadi,
            this.size,
            this.columnHeader8,
            this.columnHeader9});
            this.lwLocalFiles.ContextMenuStrip = this.cmsLocalFiles;
            this.lwLocalFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.lwLocalFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwLocalFiles.FullRowSelect = true;
            this.lwLocalFiles.HideSelection = false;
            this.lwLocalFiles.Location = new System.Drawing.Point(0, 0);
            this.lwLocalFiles.Margin = new System.Windows.Forms.Padding(0);
            this.lwLocalFiles.Name = "lwLocalFiles";
            this.lwLocalFiles.Size = new System.Drawing.Size(559, 222);
            this.lwLocalFiles.TabIndex = 16;
            this.lwLocalFiles.UseCompatibleStateImageBehavior = false;
            this.lwLocalFiles.View = System.Windows.Forms.View.Details;
            this.lwLocalFiles.SelectedIndexChanged += new System.EventHandler(this.lwLocalFiles_SelectedIndexChanged);
            this.lwLocalFiles.Click += new System.EventHandler(this.listView1_Click);
            // 
            // dosyaadi
            // 
            this.dosyaadi.Text = "Filename";
            this.dosyaadi.Width = 137;
            // 
            // size
            // 
            this.size.Text = "Size";
            this.size.Width = 83;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Extension";
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Modified Time";
            // 
            // cmsLocalFiles
            // 
            this.cmsLocalFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadToolStripMenuItem1,
            this.refreshToolStripMenuItem,
            this.automateUploadToolStripMenuItem});
            this.cmsLocalFiles.Name = "contextMenuStriplocal";
            this.cmsLocalFiles.Size = new System.Drawing.Size(169, 70);
            this.cmsLocalFiles.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLocalFiles_Opening);
            // 
            // uploadToolStripMenuItem1
            // 
            this.uploadToolStripMenuItem1.Name = "uploadToolStripMenuItem1";
            this.uploadToolStripMenuItem1.Size = new System.Drawing.Size(168, 22);
            this.uploadToolStripMenuItem1.Text = "Upload";
            this.uploadToolStripMenuItem1.Click += new System.EventHandler(this.uploadToolStripMenuItem1_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // automateUploadToolStripMenuItem
            // 
            this.automateUploadToolStripMenuItem.Name = "automateUploadToolStripMenuItem";
            this.automateUploadToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
            this.automateUploadToolStripMenuItem.Text = "Automate Upload";
            this.automateUploadToolStripMenuItem.Click += new System.EventHandler(this.automateUploadToolStripMenuItem_Click);
            // 
            // twLocalFolders
            // 
            this.twLocalFolders.BackColor = System.Drawing.Color.Lavender;
            this.twLocalFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.twLocalFolders.ContextMenuStrip = this.cmsLocalFolders;
            this.twLocalFolders.Cursor = System.Windows.Forms.Cursors.Default;
            this.twLocalFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twLocalFolders.HideSelection = false;
            this.twLocalFolders.Location = new System.Drawing.Point(0, 27);
            this.twLocalFolders.Margin = new System.Windows.Forms.Padding(0);
            this.twLocalFolders.Name = "twLocalFolders";
            this.twLocalFolders.Size = new System.Drawing.Size(559, 187);
            this.twLocalFolders.TabIndex = 15;
            this.twLocalFolders.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeExpand);
            this.twLocalFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // cmsLocalFolders
            // 
            this.cmsLocalFolders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadToolStripMenuItem,
            this.refreshToolStripMenuItem1,
            this.automateUploadToolStripMenuItem1});
            this.cmsLocalFolders.Name = "cmsLocalFolders";
            this.cmsLocalFolders.Size = new System.Drawing.Size(169, 70);
            this.cmsLocalFolders.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLocalFolders_Opening);
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click_1);
            // 
            // panelust
            // 
            this.panelust.Controls.Add(this.lblLogger);
            this.panelust.Controls.Add(this.lblautomations);
            this.panelust.Controls.Add(this.lblTime);
            this.panelust.Controls.Add(this.lblAllBytes);
            this.panelust.Controls.Add(this.lblAllProgress);
            this.panelust.Controls.Add(this.lblCurrentBytes);
            this.panelust.Controls.Add(this.lblCurrentProgress);
            this.panelust.Controls.Add(this.lblOverall);
            this.panelust.Controls.Add(this.lblCurrent);
            this.panelust.Controls.Add(this.prgCurrent);
            this.panelust.Controls.Add(this.prgOverall);
            this.panelust.Controls.Add(this.grbSaved);
            this.panelust.Controls.Add(this.btnAbout);
            this.panelust.Controls.Add(this.btnAutomations);
            this.panelust.Controls.Add(this.btnSettings);
            this.panelust.Controls.Add(this.gbConnect);
            this.panelust.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelust.Location = new System.Drawing.Point(0, 0);
            this.panelust.Name = "panelust";
            this.panelust.Size = new System.Drawing.Size(1139, 128);
            this.panelust.TabIndex = 13;
            // 
            // lblLogger
            // 
            this.lblLogger.AutoSize = true;
            this.lblLogger.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblLogger.Location = new System.Drawing.Point(583, 105);
            this.lblLogger.Name = "lblLogger";
            this.lblLogger.Size = new System.Drawing.Size(49, 13);
            this.lblLogger.TabIndex = 21;
            this.lblLogger.Text = "Logger...";
            this.lblLogger.TextChanged += new System.EventHandler(this.lblTime_TextChanged);
            // 
            // lblautomations
            // 
            this.lblautomations.AutoSize = true;
            this.lblautomations.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblautomations.Location = new System.Drawing.Point(583, 89);
            this.lblautomations.Name = "lblautomations";
            this.lblautomations.Size = new System.Drawing.Size(74, 13);
            this.lblautomations.TabIndex = 21;
            this.lblautomations.Text = "Automations...";
            this.lblautomations.TextChanged += new System.EventHandler(this.lblTime_TextChanged);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Location = new System.Drawing.Point(583, 73);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(39, 13);
            this.lblTime.TabIndex = 21;
            this.lblTime.Text = "Time...";
            this.lblTime.TextChanged += new System.EventHandler(this.lblTime_TextChanged);
            // 
            // lblAllBytes
            // 
            this.lblAllBytes.AutoSize = true;
            this.lblAllBytes.Location = new System.Drawing.Point(1034, 81);
            this.lblAllBytes.Name = "lblAllBytes";
            this.lblAllBytes.Size = new System.Drawing.Size(98, 13);
            this.lblAllBytes.TabIndex = 20;
            this.lblAllBytes.Text = "1023 MB/1023 MB";
            // 
            // lblAllProgress
            // 
            this.lblAllProgress.AutoSize = true;
            this.lblAllProgress.Location = new System.Drawing.Point(998, 81);
            this.lblAllProgress.Name = "lblAllProgress";
            this.lblAllProgress.Size = new System.Drawing.Size(36, 13);
            this.lblAllProgress.TabIndex = 20;
            this.lblAllProgress.Text = "100 %";
            // 
            // lblCurrentBytes
            // 
            this.lblCurrentBytes.AutoSize = true;
            this.lblCurrentBytes.Location = new System.Drawing.Point(1034, 107);
            this.lblCurrentBytes.Name = "lblCurrentBytes";
            this.lblCurrentBytes.Size = new System.Drawing.Size(98, 13);
            this.lblCurrentBytes.TabIndex = 20;
            this.lblCurrentBytes.Text = "1023 MB/1023 MB";
            // 
            // lblCurrentProgress
            // 
            this.lblCurrentProgress.AutoSize = true;
            this.lblCurrentProgress.Location = new System.Drawing.Point(998, 107);
            this.lblCurrentProgress.Name = "lblCurrentProgress";
            this.lblCurrentProgress.Size = new System.Drawing.Size(36, 13);
            this.lblCurrentProgress.TabIndex = 20;
            this.lblCurrentProgress.Text = "100 %";
            // 
            // lblOverall
            // 
            this.lblOverall.AutoSize = true;
            this.lblOverall.Location = new System.Drawing.Point(709, 81);
            this.lblOverall.Name = "lblOverall";
            this.lblOverall.Size = new System.Drawing.Size(43, 13);
            this.lblOverall.TabIndex = 20;
            this.lblOverall.Text = "Overall:";
            // 
            // lblCurrent
            // 
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(708, 107);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(44, 13);
            this.lblCurrent.TabIndex = 20;
            this.lblCurrent.Text = "Current:";
            // 
            // prgCurrent
            // 
            this.prgCurrent.Location = new System.Drawing.Point(758, 104);
            this.prgCurrent.Name = "prgCurrent";
            this.prgCurrent.Size = new System.Drawing.Size(234, 18);
            this.prgCurrent.TabIndex = 19;
            // 
            // prgOverall
            // 
            this.prgOverall.Location = new System.Drawing.Point(758, 80);
            this.prgOverall.Name = "prgOverall";
            this.prgOverall.Size = new System.Drawing.Size(234, 18);
            this.prgOverall.TabIndex = 19;
            // 
            // grbSaved
            // 
            this.grbSaved.Controls.Add(this.cmbSavedCredentials);
            this.grbSaved.Controls.Add(this.btnDeleteSelectedCredentials);
            this.grbSaved.Location = new System.Drawing.Point(12, 71);
            this.grbSaved.Name = "grbSaved";
            this.grbSaved.Size = new System.Drawing.Size(564, 49);
            this.grbSaved.TabIndex = 18;
            this.grbSaved.TabStop = false;
            this.grbSaved.Text = "Connect with saved Credentials";
            // 
            // btnDeleteSelectedCredentials
            // 
            this.btnDeleteSelectedCredentials.Location = new System.Drawing.Point(398, 17);
            this.btnDeleteSelectedCredentials.Name = "btnDeleteSelectedCredentials";
            this.btnDeleteSelectedCredentials.Size = new System.Drawing.Size(158, 23);
            this.btnDeleteSelectedCredentials.TabIndex = 9;
            this.btnDeleteSelectedCredentials.Text = "Delete Selected Credentials";
            this.btnDeleteSelectedCredentials.UseVisualStyleBackColor = true;
            this.btnDeleteSelectedCredentials.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Image = global::MicroSharpFTP.resources.information_icon;
            this.btnAbout.Location = new System.Drawing.Point(1079, 17);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(48, 48);
            this.btnAbout.TabIndex = 12;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnAutomations
            // 
            this.btnAutomations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAutomations.Image = global::MicroSharpFTP.resources._2639772_automation_icon;
            this.btnAutomations.Location = new System.Drawing.Point(971, 17);
            this.btnAutomations.Name = "btnAutomations";
            this.btnAutomations.Size = new System.Drawing.Size(48, 48);
            this.btnAutomations.TabIndex = 10;
            this.btnAutomations.UseVisualStyleBackColor = true;
            this.btnAutomations.Click += new System.EventHandler(this.btnAutomation_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Image = global::MicroSharpFTP.resources._3669250_settings_ic_icon;
            this.btnSettings.Location = new System.Drawing.Point(1025, 17);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(48, 48);
            this.btnSettings.TabIndex = 11;
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // cmbRemote
            // 
            this.cmbRemote.BackColor = System.Drawing.Color.Lavender;
            this.cmbRemote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbRemote.FormattingEnabled = true;
            this.cmbRemote.Location = new System.Drawing.Point(50, 3);
            this.cmbRemote.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cmbRemote.Name = "cmbRemote";
            this.cmbRemote.Size = new System.Drawing.Size(520, 21);
            this.cmbRemote.TabIndex = 17;
            this.cmbRemote.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Comboremote_KeyPress);
            // 
            // cmbLocal
            // 
            this.cmbLocal.BackColor = System.Drawing.Color.Lavender;
            this.cmbLocal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbLocal.FormattingEnabled = true;
            this.cmbLocal.Location = new System.Drawing.Point(50, 3);
            this.cmbLocal.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.cmbLocal.Name = "cmbLocal";
            this.cmbLocal.Size = new System.Drawing.Size(503, 21);
            this.cmbLocal.TabIndex = 14;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(7)))), ((int)(((byte)(17)))));
            this.panel1.Controls.Add(this.splitContainer3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1139, 440);
            this.panel1.TabIndex = 14;
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.Lavender;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.panel4);
            this.splitContainer3.Size = new System.Drawing.Size(1139, 440);
            this.splitContainer3.SplitterDistance = 559;
            this.splitContainer3.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.splitContainer1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(559, 440);
            this.panel3.TabIndex = 10;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Lavender;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lwLocalFiles);
            this.splitContainer1.Size = new System.Drawing.Size(559, 440);
            this.splitContainer1.SplitterDistance = 214;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.twLocalFolders, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(559, 214);
            this.tableLayoutPanel2.TabIndex = 21;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.Color.Lavender;
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.cmbLocal, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblLocal, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 0);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(553, 27);
            this.tableLayoutPanel3.TabIndex = 19;
            // 
            // lblLocal
            // 
            this.lblLocal.AutoSize = true;
            this.lblLocal.BackColor = System.Drawing.Color.Lavender;
            this.lblLocal.Location = new System.Drawing.Point(0, 5);
            this.lblLocal.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblLocal.Name = "lblLocal";
            this.lblLocal.Size = new System.Drawing.Size(36, 13);
            this.lblLocal.TabIndex = 13;
            this.lblLocal.Text = "Local:";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.Controls.Add(this.splitContainer2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(576, 440);
            this.panel4.TabIndex = 11;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Lavender;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tlremoteall);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lwRemoteFiles);
            this.splitContainer2.Size = new System.Drawing.Size(576, 440);
            this.splitContainer2.SplitterDistance = 214;
            this.splitContainer2.TabIndex = 0;
            // 
            // tlremoteall
            // 
            this.tlremoteall.ColumnCount = 1;
            this.tlremoteall.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlremoteall.Controls.Add(this.twRemoteFolders, 0, 1);
            this.tlremoteall.Controls.Add(this.tlremotetextbox, 0, 0);
            this.tlremoteall.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlremoteall.Location = new System.Drawing.Point(0, 0);
            this.tlremoteall.Name = "tlremoteall";
            this.tlremoteall.RowCount = 2;
            this.tlremoteall.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tlremoteall.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlremoteall.Size = new System.Drawing.Size(576, 214);
            this.tlremoteall.TabIndex = 20;
            // 
            // twRemoteFolders
            // 
            this.twRemoteFolders.BackColor = System.Drawing.Color.Lavender;
            this.twRemoteFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.twRemoteFolders.Cursor = System.Windows.Forms.Cursors.Default;
            this.twRemoteFolders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.twRemoteFolders.FullRowSelect = true;
            this.twRemoteFolders.HideSelection = false;
            this.twRemoteFolders.Location = new System.Drawing.Point(0, 27);
            this.twRemoteFolders.Margin = new System.Windows.Forms.Padding(0);
            this.twRemoteFolders.Name = "twRemoteFolders";
            treeNode5.Name = "Node0";
            treeNode5.Text = "/";
            this.twRemoteFolders.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.twRemoteFolders.PathSeparator = "/";
            this.twRemoteFolders.Size = new System.Drawing.Size(576, 187);
            this.twRemoteFolders.TabIndex = 18;
            this.twRemoteFolders.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeViewremote_AfterSelect);
            // 
            // tlremotetextbox
            // 
            this.tlremotetextbox.BackColor = System.Drawing.Color.Lavender;
            this.tlremotetextbox.ColumnCount = 2;
            this.tlremotetextbox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlremotetextbox.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlremotetextbox.Controls.Add(this.cmbRemote, 1, 0);
            this.tlremotetextbox.Controls.Add(this.lblRemote, 0, 0);
            this.tlremotetextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlremotetextbox.Location = new System.Drawing.Point(3, 0);
            this.tlremotetextbox.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.tlremotetextbox.Name = "tlremotetextbox";
            this.tlremotetextbox.RowCount = 1;
            this.tlremotetextbox.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlremotetextbox.Size = new System.Drawing.Size(570, 27);
            this.tlremotetextbox.TabIndex = 19;
            // 
            // lblRemote
            // 
            this.lblRemote.AutoSize = true;
            this.lblRemote.Location = new System.Drawing.Point(0, 5);
            this.lblRemote.Margin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblRemote.Name = "lblRemote";
            this.lblRemote.Size = new System.Drawing.Size(47, 13);
            this.lblRemote.TabIndex = 13;
            this.lblRemote.Text = "Remote:";
            // 
            // lwRemoteFiles
            // 
            this.lwRemoteFiles.AllowDrop = true;
            this.lwRemoteFiles.BackColor = System.Drawing.Color.Lavender;
            this.lwRemoteFiles.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lwRemoteFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.lwRemoteFiles.ContextMenuStrip = this.cmsRemoteFiles;
            this.lwRemoteFiles.Cursor = System.Windows.Forms.Cursors.Default;
            this.lwRemoteFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lwRemoteFiles.HideSelection = false;
            this.lwRemoteFiles.Location = new System.Drawing.Point(0, 0);
            this.lwRemoteFiles.Name = "lwRemoteFiles";
            this.lwRemoteFiles.Size = new System.Drawing.Size(576, 222);
            this.lwRemoteFiles.TabIndex = 19;
            this.lwRemoteFiles.UseCompatibleStateImageBehavior = false;
            this.lwRemoteFiles.View = System.Windows.Forms.View.Details;
            this.lwRemoteFiles.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewftpfiles_ItemDrag);
            this.lwRemoteFiles.SelectedIndexChanged += new System.EventHandler(this.lwRemoteFiles_SelectedIndexChanged);
            this.lwRemoteFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewftpfiles_DragDrop);
            this.lwRemoteFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewftpfiles_DragEnter);
            this.lwRemoteFiles.DragLeave += new System.EventHandler(this.listViewftpfiles_DragLeave);
            this.lwRemoteFiles.DoubleClick += new System.EventHandler(this.ListViewftpfiles_DoubleClick);
            this.lwRemoteFiles.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewftpfiles_MouseDown);
            this.lwRemoteFiles.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listViewftpfiles_MouseMove);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 102;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Permissions";
            this.columnHeader2.Width = 86;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Size";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Modified Time";
            this.columnHeader4.Width = 115;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Inode";
            this.columnHeader5.Width = 73;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Owner";
            this.columnHeader6.Width = 61;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Group";
            // 
            // cmsRemoteFiles
            // 
            this.cmsRemoteFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newFolderToolStripMenuItem,
            this.renewToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.renameToolStripMenuItem,
            this.copyToClipboardToolStripMenuItem,
            this.automateDownloadToolStripMenuItem});
            this.cmsRemoteFiles.Name = "contextMenuStrip1";
            this.cmsRemoteFiles.Size = new System.Drawing.Size(185, 180);
            this.cmsRemoteFiles.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.newFolderToolStripMenuItem.Text = "New Folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // renewToolStripMenuItem
            // 
            this.renewToolStripMenuItem.Name = "renewToolStripMenuItem";
            this.renewToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.renewToolStripMenuItem.Text = "Refresh";
            this.renewToolStripMenuItem.Click += new System.EventHandler(this.renewToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            this.downloadToolStripMenuItem.Click += new System.EventHandler(this.downloadToolStripMenuItem_Click);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // copyToClipboardToolStripMenuItem
            // 
            this.copyToClipboardToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fullLinkToolStripMenuItem,
            this.flielistToolStripMenuItem});
            this.copyToClipboardToolStripMenuItem.Name = "copyToClipboardToolStripMenuItem";
            this.copyToClipboardToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.copyToClipboardToolStripMenuItem.Text = "Copy to clipboard";
            // 
            // fullLinkToolStripMenuItem
            // 
            this.fullLinkToolStripMenuItem.Name = "fullLinkToolStripMenuItem";
            this.fullLinkToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.fullLinkToolStripMenuItem.Text = "Full link";
            this.fullLinkToolStripMenuItem.Click += new System.EventHandler(this.fullLinkToolStripMenuItem_Click);
            // 
            // flielistToolStripMenuItem
            // 
            this.flielistToolStripMenuItem.Name = "flielistToolStripMenuItem";
            this.flielistToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.flielistToolStripMenuItem.Text = "File list";
            this.flielistToolStripMenuItem.Click += new System.EventHandler(this.flielistToolStripMenuItem_Click);
            // 
            // splitContainer4
            // 
            this.splitContainer4.BackColor = System.Drawing.Color.Lavender;
            this.splitContainer4.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 128);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.txtLogger);
            this.splitContainer4.Size = new System.Drawing.Size(1139, 558);
            this.splitContainer4.SplitterDistance = 440;
            this.splitContainer4.TabIndex = 15;
            // 
            // txtLogger
            // 
            this.txtLogger.BackColor = System.Drawing.Color.Lavender;
            this.txtLogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLogger.Location = new System.Drawing.Point(0, 0);
            this.txtLogger.Multiline = true;
            this.txtLogger.Name = "txtLogger";
            this.txtLogger.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLogger.Size = new System.Drawing.Size(1139, 114);
            this.txtLogger.TabIndex = 20;
            this.txtLogger.TextChanged += new System.EventHandler(this.txtLogger_TextChanged);
            this.txtLogger.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.cmsMain;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "MicroSharpFTP";
            this.notifyIcon.Visible = true;
            this.notifyIcon.Click += new System.EventHandler(this.notifyIcon1_Click);
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // cmsMain
            // 
            this.cmsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showMicroSharpFTPToolStripMenuItem,
            this.microSharpFTPSettingsToolStripMenuItem,
            this.aboutMicroSharpFTPToolStripMenuItem,
            this.exitMicroSharpFTPToolStripMenuItem});
            this.cmsMain.Name = "contextMenuStripMicroSharpFTP";
            this.cmsMain.Size = new System.Drawing.Size(200, 92);
            this.cmsMain.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripMicroSharpFTP_Opening);
            // 
            // showMicroSharpFTPToolStripMenuItem
            // 
            this.showMicroSharpFTPToolStripMenuItem.Name = "showMicroSharpFTPToolStripMenuItem";
            this.showMicroSharpFTPToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.showMicroSharpFTPToolStripMenuItem.Text = "Hide MicroSharpFTP";
            this.showMicroSharpFTPToolStripMenuItem.Click += new System.EventHandler(this.showMicroSharpFTPToolStripMenuItem_Click);
            // 
            // microSharpFTPSettingsToolStripMenuItem
            // 
            this.microSharpFTPSettingsToolStripMenuItem.Name = "microSharpFTPSettingsToolStripMenuItem";
            this.microSharpFTPSettingsToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.microSharpFTPSettingsToolStripMenuItem.Text = "MicroSharpFTP Settings";
            this.microSharpFTPSettingsToolStripMenuItem.Click += new System.EventHandler(this.microSharpFTPSettingsToolStripMenuItem_Click);
            // 
            // aboutMicroSharpFTPToolStripMenuItem
            // 
            this.aboutMicroSharpFTPToolStripMenuItem.Name = "aboutMicroSharpFTPToolStripMenuItem";
            this.aboutMicroSharpFTPToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.aboutMicroSharpFTPToolStripMenuItem.Text = "About MicroSharpFTP";
            this.aboutMicroSharpFTPToolStripMenuItem.Click += new System.EventHandler(this.aboutMicroSharpFTPToolStripMenuItem_Click);
            // 
            // exitMicroSharpFTPToolStripMenuItem
            // 
            this.exitMicroSharpFTPToolStripMenuItem.Name = "exitMicroSharpFTPToolStripMenuItem";
            this.exitMicroSharpFTPToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.exitMicroSharpFTPToolStripMenuItem.Text = "Quit MicroSharpFTP";
            this.exitMicroSharpFTPToolStripMenuItem.Click += new System.EventHandler(this.exitMicroSharpFTPToolStripMenuItem_Click);
            // 
            // tAutomations
            // 
            this.tAutomations.Enabled = true;
            this.tAutomations.Interval = 1000;
            this.tAutomations.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // tLogs
            // 
            this.tLogs.Tick += new System.EventHandler(this.tLogs_Tick);
            // 
            // refreshToolStripMenuItem1
            // 
            this.refreshToolStripMenuItem1.Name = "refreshToolStripMenuItem1";
            this.refreshToolStripMenuItem1.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem1.Text = "Refresh";
            this.refreshToolStripMenuItem1.Click += new System.EventHandler(this.refreshToolStripMenuItem1_Click);
            // 
            // automateUploadToolStripMenuItem1
            // 
            this.automateUploadToolStripMenuItem1.Name = "automateUploadToolStripMenuItem1";
            this.automateUploadToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.automateUploadToolStripMenuItem1.Text = "Automate Upload";
            this.automateUploadToolStripMenuItem1.Click += new System.EventHandler(this.automateUploadToolStripMenuItem1_Click);
            // 
            // automateDownloadToolStripMenuItem
            // 
            this.automateDownloadToolStripMenuItem.Name = "automateDownloadToolStripMenuItem";
            this.automateDownloadToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.automateDownloadToolStripMenuItem.Text = "Automate Download";
            this.automateDownloadToolStripMenuItem.Click += new System.EventHandler(this.automateDownloadToolStripMenuItem_Click);
            // 
            // fClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(1139, 686);
            this.Controls.Add(this.splitContainer4);
            this.Controls.Add(this.panelust);
            this.MinimumSize = new System.Drawing.Size(1155, 725);
            this.Name = "fClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MicroSharpFTP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fClient_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.fClient_Shown);
            this.StyleChanged += new System.EventHandler(this.fClient_StyleChanged);
            this.gbConnect.ResumeLayout(false);
            this.gbConnect.PerformLayout();
            this.cmsLocalFiles.ResumeLayout(false);
            this.cmsLocalFolders.ResumeLayout(false);
            this.panelust.ResumeLayout(false);
            this.panelust.PerformLayout();
            this.grbSaved.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.tlremoteall.ResumeLayout(false);
            this.tlremotetextbox.ResumeLayout(false);
            this.tlremotetextbox.PerformLayout();
            this.cmsRemoteFiles.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            this.cmsMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label lblHost;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.GroupBox gbConnect;
        private System.Windows.Forms.ListView lwLocalFiles;
        private System.Windows.Forms.ColumnHeader dosyaadi;
        private System.Windows.Forms.ColumnHeader size;
        private System.Windows.Forms.TreeView twLocalFolders;
        private System.Windows.Forms.Panel panelust;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView twRemoteFolders;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.ComboBox cmbRemote;
        private System.Windows.Forms.ComboBox cmbLocal;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ContextMenuStrip cmsRemoteFiles;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        internal System.Windows.Forms.ListView lwRemoteFiles;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.ComboBox cmbSavedCredentials;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Button btnSaveCredentials;
        private System.Windows.Forms.Button btnConnectSaveCredentials;
        internal System.Windows.Forms.TextBox txtLogger;
        private System.Windows.Forms.GroupBox grbSaved;
        private System.Windows.Forms.ToolStripMenuItem renewToolStripMenuItem;
        private System.Windows.Forms.Button btnDeleteSelectedCredentials;
        private System.Windows.Forms.TableLayoutPanel tlremotetextbox;
        private System.Windows.Forms.TableLayoutPanel tlremoteall;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblLocal;
        private System.Windows.Forms.Label lblRemote;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.Label lblOverall;
        private System.Windows.Forms.Label lblCurrent;
        internal System.Windows.Forms.ProgressBar prgOverall;
        internal System.Windows.Forms.ProgressBar prgCurrent;
        private System.Windows.Forms.Label lblAllProgress;
        private System.Windows.Forms.Label lblCurrentProgress;
        private System.Windows.Forms.Label lblAllBytes;
        private System.Windows.Forms.Label lblCurrentBytes;
        private System.Windows.Forms.ContextMenuStrip cmsLocalFiles;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip cmsMain;
        private System.Windows.Forms.ToolStripMenuItem showMicroSharpFTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitMicroSharpFTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem microSharpFTPSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutMicroSharpFTPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.Button btnAutomations;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem automateUploadToolStripMenuItem;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer tAutomations;
        private System.Windows.Forms.Label lblautomations;
        private System.Windows.Forms.ToolStripMenuItem copyToClipboardToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullLinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem flielistToolStripMenuItem;
        private System.Windows.Forms.Timer tLogs;
        private System.Windows.Forms.Label lblLogger;
        private System.Windows.Forms.ContextMenuStrip cmsLocalFolders;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem automateUploadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem automateDownloadToolStripMenuItem;
    }
}

