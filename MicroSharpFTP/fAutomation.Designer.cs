
namespace MicroSharpFTP
{
    partial class fAutomation
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
            this.dpChooseDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbAutomation = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.labelfrom = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnExpand = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgwAutomations = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FireTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Frrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Notes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Percent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AddingTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsAutomation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblActiveAutomations = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbForAccount = new System.Windows.Forms.ComboBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnSelectFolder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgwAutomations)).BeginInit();
            this.cmsAutomation.SuspendLayout();
            this.SuspendLayout();
            // 
            // dpChooseDate
            // 
            this.dpChooseDate.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpChooseDate.Location = new System.Drawing.Point(88, 65);
            this.dpChooseDate.Name = "dpChooseDate";
            this.dpChooseDate.Size = new System.Drawing.Size(595, 20);
            this.dpChooseDate.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Choose date:";
            // 
            // cmbAutomation
            // 
            this.cmbAutomation.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbAutomation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAutomation.FormattingEnabled = true;
            this.cmbAutomation.Location = new System.Drawing.Point(88, 39);
            this.cmbAutomation.Name = "cmbAutomation";
            this.cmbAutomation.Size = new System.Drawing.Size(595, 21);
            this.cmbAutomation.TabIndex = 2;
            this.cmbAutomation.SelectedIndexChanged += new System.EventHandler(this.cmbAutomate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Automate:";
            // 
            // txtFrom
            // 
            this.txtFrom.BackColor = System.Drawing.Color.Lavender;
            this.txtFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtFrom.Location = new System.Drawing.Point(88, 90);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(537, 20);
            this.txtFrom.TabIndex = 4;
            this.txtFrom.TextChanged += new System.EventHandler(this.txtFrom_TextChanged);
            this.txtFrom.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtfrom_MouseUp);
            // 
            // labelfrom
            // 
            this.labelfrom.AutoSize = true;
            this.labelfrom.Location = new System.Drawing.Point(9, 90);
            this.labelfrom.Name = "labelfrom";
            this.labelfrom.Size = new System.Drawing.Size(33, 13);
            this.labelfrom.TabIndex = 1;
            this.labelfrom.Text = "From:";
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(9, 115);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 1;
            this.lblTo.Text = "To:";
            // 
            // txtTo
            // 
            this.txtTo.BackColor = System.Drawing.Color.Lavender;
            this.txtTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTo.Location = new System.Drawing.Point(88, 115);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(537, 20);
            this.txtTo.TabIndex = 5;
            this.txtTo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txtto_MouseUp);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(527, 307);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(608, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.BackColor = System.Drawing.Color.Lavender;
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Location = new System.Drawing.Point(88, 140);
            this.txtNotes.MaxLength = 5000;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(595, 161);
            this.txtNotes.TabIndex = 6;
            // 
            // btnExpand
            // 
            this.btnExpand.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpand.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnExpand.Location = new System.Drawing.Point(9, 336);
            this.btnExpand.Margin = new System.Windows.Forms.Padding(0);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(674, 20);
            this.btnExpand.TabIndex = 9;
            this.btnExpand.Text = "\\/";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.buttonshowexists_Click);
            // 
            // dgwAutomations
            // 
            this.dgwAutomations.AllowUserToAddRows = false;
            this.dgwAutomations.AllowUserToDeleteRows = false;
            this.dgwAutomations.BackgroundColor = System.Drawing.Color.Lavender;
            this.dgwAutomations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgwAutomations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwAutomations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Account,
            this.Type,
            this.FireTime,
            this.Frrom,
            this.Tto,
            this.Notes,
            this.Percent,
            this.AddingTime});
            this.dgwAutomations.ContextMenuStrip = this.cmsAutomation;
            this.dgwAutomations.Location = new System.Drawing.Point(10, 388);
            this.dgwAutomations.MultiSelect = false;
            this.dgwAutomations.Name = "dgwAutomations";
            this.dgwAutomations.ReadOnly = true;
            this.dgwAutomations.RowHeadersVisible = false;
            this.dgwAutomations.RowHeadersWidth = 20;
            this.dgwAutomations.RowTemplate.Height = 21;
            this.dgwAutomations.RowTemplate.ReadOnly = true;
            this.dgwAutomations.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgwAutomations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwAutomations.ShowEditingIcon = false;
            this.dgwAutomations.Size = new System.Drawing.Size(673, 286);
            this.dgwAutomations.TabIndex = 10;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Account
            // 
            this.Account.HeaderText = "Account";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            // 
            // Type
            // 
            this.Type.HeaderText = "Type";
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // FireTime
            // 
            this.FireTime.HeaderText = "FireTime";
            this.FireTime.Name = "FireTime";
            this.FireTime.ReadOnly = true;
            // 
            // Frrom
            // 
            this.Frrom.HeaderText = "From";
            this.Frrom.Name = "Frrom";
            this.Frrom.ReadOnly = true;
            // 
            // Tto
            // 
            this.Tto.HeaderText = "To";
            this.Tto.Name = "Tto";
            this.Tto.ReadOnly = true;
            // 
            // Notes
            // 
            this.Notes.HeaderText = "Notes";
            this.Notes.Name = "Notes";
            this.Notes.ReadOnly = true;
            // 
            // Percent
            // 
            this.Percent.HeaderText = "%";
            this.Percent.Name = "Percent";
            this.Percent.ReadOnly = true;
            // 
            // AddingTime
            // 
            this.AddingTime.HeaderText = "AddingTime";
            this.AddingTime.Name = "AddingTime";
            this.AddingTime.ReadOnly = true;
            // 
            // cmsAutomation
            // 
            this.cmsAutomation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.refreshToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.cmsAutomation.Name = "cmsAutomation";
            this.cmsAutomation.Size = new System.Drawing.Size(114, 48);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // lblActiveAutomations
            // 
            this.lblActiveAutomations.AutoSize = true;
            this.lblActiveAutomations.Location = new System.Drawing.Point(8, 366);
            this.lblActiveAutomations.Name = "lblActiveAutomations";
            this.lblActiveAutomations.Size = new System.Drawing.Size(101, 13);
            this.lblActiveAutomations.TabIndex = 11;
            this.lblActiveAutomations.Text = "Active Automations:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(25, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "For:";
            // 
            // cmbForAccount
            // 
            this.cmbForAccount.BackColor = System.Drawing.Color.Lavender;
            this.cmbForAccount.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmbForAccount.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbForAccount.FormattingEnabled = true;
            this.cmbForAccount.Location = new System.Drawing.Point(88, 12);
            this.cmbForAccount.Name = "cmbForAccount";
            this.cmbForAccount.Size = new System.Drawing.Size(595, 21);
            this.cmbForAccount.TabIndex = 1;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(631, 90);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(52, 20);
            this.btnSelectFile.TabIndex = 12;
            this.btnSelectFile.Text = "File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSelectFolder
            // 
            this.btnSelectFolder.Location = new System.Drawing.Point(631, 115);
            this.btnSelectFolder.Name = "btnSelectFolder";
            this.btnSelectFolder.Size = new System.Drawing.Size(52, 20);
            this.btnSelectFolder.TabIndex = 13;
            this.btnSelectFolder.Text = "Folder";
            this.btnSelectFolder.UseVisualStyleBackColor = true;
            this.btnSelectFolder.Click += new System.EventHandler(this.btnSelectFolder_Click);
            // 
            // fAutomation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(692, 684);
            this.Controls.Add(this.btnSelectFolder);
            this.Controls.Add(this.btnSelectFile);
            this.Controls.Add(this.lblActiveAutomations);
            this.Controls.Add(this.dgwAutomations);
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.dpChooseDate);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.cmbForAccount);
            this.Controls.Add(this.cmbAutomation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.labelfrom);
            this.Name = "fAutomation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automations for MicroSharpFTP ";
            this.Load += new System.EventHandler(this.fAutomation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgwAutomations)).EndInit();
            this.cmsAutomation.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelfrom;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.ToolTip toolTip1;
        internal System.Windows.Forms.DateTimePicker dpChooseDate;
        internal System.Windows.Forms.ComboBox cmbAutomation;
        internal System.Windows.Forms.TextBox txtFrom;
        internal System.Windows.Forms.TextBox txtTo;
        internal System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.DataGridView dgwAutomations;
        private System.Windows.Forms.Label lblActiveAutomations;
        private System.Windows.Forms.ContextMenuStrip cmsAutomation;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.ComboBox cmbForAccount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Account;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn FireTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Frrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Notes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Percent;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddingTime;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Button btnSelectFolder;
    }
}