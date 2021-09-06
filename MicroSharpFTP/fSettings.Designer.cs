
namespace MicroSharpFTP
{
    partial class fSettings
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
            this.chkStartup = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblWarningStartup = new System.Windows.Forms.Label();
            this.chkAutoScrollLogs = new System.Windows.Forms.CheckBox();
            this.chkConnectStartup = new System.Windows.Forms.CheckBox();
            this.cmbConnectStartup = new System.Windows.Forms.ComboBox();
            this.chkConfirmDeleteSavedCredentials = new System.Windows.Forms.CheckBox();
            this.chkDefaultPort = new System.Windows.Forms.CheckBox();
            this.txtDefaultPort = new System.Windows.Forms.TextBox();
            this.chkDeleteRemoteFile = new System.Windows.Forms.CheckBox();
            this.chkStartInSystemTray = new System.Windows.Forms.CheckBox();
            this.chkMinimizeTrayWhenClosing = new System.Windows.Forms.CheckBox();
            this.chkConfirmExitingApp = new System.Windows.Forms.CheckBox();
            this.chkConfirmDeletingAutomation = new System.Windows.Forms.CheckBox();
            this.chkAutoExpangAutomations = new System.Windows.Forms.CheckBox();
            this.chkAutomationControl = new System.Windows.Forms.CheckBox();
            this.txtAutomationControl = new System.Windows.Forms.TextBox();
            this.chkPasswordProtect = new System.Windows.Forms.CheckBox();
            this.txtPasswordProtect = new System.Windows.Forms.TextBox();
            this.chkPasswordTray = new System.Windows.Forms.CheckBox();
            this.txtPasswordTray = new System.Windows.Forms.TextBox();
            this.chkAutoSaveLogs = new System.Windows.Forms.CheckBox();
            this.btnLoadDefaults = new System.Windows.Forms.Button();
            this.btnImportSettings = new System.Windows.Forms.Button();
            this.btnImportAutomations = new System.Windows.Forms.Button();
            this.btnImportCredentials = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkStartup
            // 
            this.chkStartup.AutoSize = true;
            this.chkStartup.Location = new System.Drawing.Point(12, 12);
            this.chkStartup.Name = "chkStartup";
            this.chkStartup.Size = new System.Drawing.Size(139, 17);
            this.chkStartup.TabIndex = 1;
            this.chkStartup.Text = "Start at windows startup";
            this.chkStartup.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(326, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(71, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(403, 371);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(71, 23);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblWarningStartup
            // 
            this.lblWarningStartup.AutoSize = true;
            this.lblWarningStartup.ForeColor = System.Drawing.Color.DarkRed;
            this.lblWarningStartup.Location = new System.Drawing.Point(250, 12);
            this.lblWarningStartup.Name = "lblWarningStartup";
            this.lblWarningStartup.Size = new System.Drawing.Size(220, 26);
            this.lblWarningStartup.TabIndex = 3;
            this.lblWarningStartup.Text = "<- maybe you changed app location or name.\r\nre check this box to save changes.";
            this.lblWarningStartup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWarningStartup.Visible = false;
            // 
            // chkAutoScrollLogs
            // 
            this.chkAutoScrollLogs.AutoSize = true;
            this.chkAutoScrollLogs.Location = new System.Drawing.Point(12, 104);
            this.chkAutoScrollLogs.Name = "chkAutoScrollLogs";
            this.chkAutoScrollLogs.Size = new System.Drawing.Size(126, 17);
            this.chkAutoScrollLogs.TabIndex = 5;
            this.chkAutoScrollLogs.Text = "Auto scroll down logs";
            this.chkAutoScrollLogs.UseVisualStyleBackColor = true;
            // 
            // chkConnectStartup
            // 
            this.chkConnectStartup.AutoSize = true;
            this.chkConnectStartup.Location = new System.Drawing.Point(12, 127);
            this.chkConnectStartup.Name = "chkConnectStartup";
            this.chkConnectStartup.Size = new System.Drawing.Size(139, 17);
            this.chkConnectStartup.TabIndex = 6;
            this.chkConnectStartup.Text = "Connect host at startup:";
            this.chkConnectStartup.UseVisualStyleBackColor = true;
            this.chkConnectStartup.CheckedChanged += new System.EventHandler(this.chkConnectStartup_CheckedChanged);
            // 
            // cmbConnectStartup
            // 
            this.cmbConnectStartup.BackColor = System.Drawing.Color.Lavender;
            this.cmbConnectStartup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConnectStartup.Enabled = false;
            this.cmbConnectStartup.FormattingEnabled = true;
            this.cmbConnectStartup.Location = new System.Drawing.Point(253, 126);
            this.cmbConnectStartup.Name = "cmbConnectStartup";
            this.cmbConnectStartup.Size = new System.Drawing.Size(221, 21);
            this.cmbConnectStartup.TabIndex = 7;
            // 
            // chkConfirmDeleteSavedCredentials
            // 
            this.chkConfirmDeleteSavedCredentials.AutoSize = true;
            this.chkConfirmDeleteSavedCredentials.Location = new System.Drawing.Point(12, 58);
            this.chkConfirmDeleteSavedCredentials.Name = "chkConfirmDeleteSavedCredentials";
            this.chkConfirmDeleteSavedCredentials.Size = new System.Drawing.Size(169, 17);
            this.chkConfirmDeleteSavedCredentials.TabIndex = 3;
            this.chkConfirmDeleteSavedCredentials.Text = "Confirm when delete saved ftp";
            this.chkConfirmDeleteSavedCredentials.UseVisualStyleBackColor = true;
            // 
            // chkDefaultPort
            // 
            this.chkDefaultPort.AutoSize = true;
            this.chkDefaultPort.Location = new System.Drawing.Point(12, 150);
            this.chkDefaultPort.Name = "chkDefaultPort";
            this.chkDefaultPort.Size = new System.Drawing.Size(190, 17);
            this.chkDefaultPort.TabIndex = 8;
            this.chkDefaultPort.Text = "Default port (Recommended \"21\"):";
            this.chkDefaultPort.UseVisualStyleBackColor = true;
            this.chkDefaultPort.CheckedChanged += new System.EventHandler(this.chkdefaultport_CheckedChanged);
            // 
            // txtDefaultPort
            // 
            this.txtDefaultPort.BackColor = System.Drawing.Color.Lavender;
            this.txtDefaultPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDefaultPort.Enabled = false;
            this.txtDefaultPort.Location = new System.Drawing.Point(253, 148);
            this.txtDefaultPort.Name = "txtDefaultPort";
            this.txtDefaultPort.Size = new System.Drawing.Size(221, 20);
            this.txtDefaultPort.TabIndex = 9;
            this.txtDefaultPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdefaultport_KeyPress);
            this.txtDefaultPort.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdefaultport_KeyUp);
            // 
            // chkDeleteRemoteFile
            // 
            this.chkDeleteRemoteFile.AutoSize = true;
            this.chkDeleteRemoteFile.Location = new System.Drawing.Point(12, 81);
            this.chkDeleteRemoteFile.Name = "chkDeleteRemoteFile";
            this.chkDeleteRemoteFile.Size = new System.Drawing.Size(173, 17);
            this.chkDeleteRemoteFile.TabIndex = 4;
            this.chkDeleteRemoteFile.Text = "Confirm when delete remote file";
            this.chkDeleteRemoteFile.UseVisualStyleBackColor = true;
            // 
            // chkStartInSystemTray
            // 
            this.chkStartInSystemTray.AutoSize = true;
            this.chkStartInSystemTray.Location = new System.Drawing.Point(12, 35);
            this.chkStartInSystemTray.Name = "chkStartInSystemTray";
            this.chkStartInSystemTray.Size = new System.Drawing.Size(114, 17);
            this.chkStartInSystemTray.TabIndex = 2;
            this.chkStartInSystemTray.Text = "Start in system tray";
            this.chkStartInSystemTray.UseVisualStyleBackColor = true;
            this.chkStartInSystemTray.CheckedChanged += new System.EventHandler(this.chkConnectStartup_CheckedChanged);
            // 
            // chkMinimizeTrayWhenClosing
            // 
            this.chkMinimizeTrayWhenClosing.AutoSize = true;
            this.chkMinimizeTrayWhenClosing.Location = new System.Drawing.Point(12, 242);
            this.chkMinimizeTrayWhenClosing.Name = "chkMinimizeTrayWhenClosing";
            this.chkMinimizeTrayWhenClosing.Size = new System.Drawing.Size(183, 17);
            this.chkMinimizeTrayWhenClosing.TabIndex = 16;
            this.chkMinimizeTrayWhenClosing.Text = "Minimize to tray instead of closing";
            this.chkMinimizeTrayWhenClosing.UseVisualStyleBackColor = true;
            this.chkMinimizeTrayWhenClosing.CheckedChanged += new System.EventHandler(this.chkConnectStartup_CheckedChanged);
            // 
            // chkConfirmExitingApp
            // 
            this.chkConfirmExitingApp.AutoSize = true;
            this.chkConfirmExitingApp.Location = new System.Drawing.Point(12, 265);
            this.chkConfirmExitingApp.Name = "chkConfirmExitingApp";
            this.chkConfirmExitingApp.Size = new System.Drawing.Size(144, 17);
            this.chkConfirmExitingApp.TabIndex = 17;
            this.chkConfirmExitingApp.Text = "Confirm when exiting app";
            this.chkConfirmExitingApp.UseVisualStyleBackColor = true;
            this.chkConfirmExitingApp.CheckedChanged += new System.EventHandler(this.chkConnectStartup_CheckedChanged);
            // 
            // chkConfirmDeletingAutomation
            // 
            this.chkConfirmDeletingAutomation.AutoSize = true;
            this.chkConfirmDeletingAutomation.Location = new System.Drawing.Point(12, 288);
            this.chkConfirmDeletingAutomation.Name = "chkConfirmDeletingAutomation";
            this.chkConfirmDeletingAutomation.Size = new System.Drawing.Size(185, 17);
            this.chkConfirmDeletingAutomation.TabIndex = 18;
            this.chkConfirmDeletingAutomation.Text = "Confirm when deleting automation";
            this.chkConfirmDeletingAutomation.UseVisualStyleBackColor = true;
            this.chkConfirmDeletingAutomation.CheckedChanged += new System.EventHandler(this.chkConnectStartup_CheckedChanged);
            // 
            // chkAutoExpangAutomations
            // 
            this.chkAutoExpangAutomations.AutoSize = true;
            this.chkAutoExpangAutomations.Location = new System.Drawing.Point(12, 311);
            this.chkAutoExpangAutomations.Name = "chkAutoExpangAutomations";
            this.chkAutoExpangAutomations.Size = new System.Drawing.Size(207, 17);
            this.chkAutoExpangAutomations.TabIndex = 19;
            this.chkAutoExpangAutomations.Text = "Auto-expend active automations panel";
            this.chkAutoExpangAutomations.UseVisualStyleBackColor = true;
            this.chkAutoExpangAutomations.CheckedChanged += new System.EventHandler(this.chkConnectStartup_CheckedChanged);
            // 
            // chkAutomationControl
            // 
            this.chkAutomationControl.AutoSize = true;
            this.chkAutomationControl.Location = new System.Drawing.Point(12, 173);
            this.chkAutomationControl.Name = "chkAutomationControl";
            this.chkAutomationControl.Size = new System.Drawing.Size(235, 17);
            this.chkAutomationControl.TabIndex = 10;
            this.chkAutomationControl.Text = "Automation control (Recommended \"1000\"):";
            this.chkAutomationControl.UseVisualStyleBackColor = true;
            this.chkAutomationControl.CheckedChanged += new System.EventHandler(this.chkAutomationControl_CheckedChanged);
            // 
            // txtAutomationControl
            // 
            this.txtAutomationControl.BackColor = System.Drawing.Color.Lavender;
            this.txtAutomationControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtAutomationControl.Enabled = false;
            this.txtAutomationControl.Location = new System.Drawing.Point(253, 171);
            this.txtAutomationControl.MaxLength = 50;
            this.txtAutomationControl.Name = "txtAutomationControl";
            this.txtAutomationControl.Size = new System.Drawing.Size(221, 20);
            this.txtAutomationControl.TabIndex = 11;
            this.txtAutomationControl.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtdefaultport_KeyPress);
            this.txtAutomationControl.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtdefaultport_KeyUp);
            // 
            // chkPasswordProtect
            // 
            this.chkPasswordProtect.AutoSize = true;
            this.chkPasswordProtect.Location = new System.Drawing.Point(12, 196);
            this.chkPasswordProtect.Name = "chkPasswordProtect";
            this.chkPasswordProtect.Size = new System.Drawing.Size(179, 17);
            this.chkPasswordProtect.TabIndex = 12;
            this.chkPasswordProtect.Text = "Password protect while opening:";
            this.chkPasswordProtect.UseVisualStyleBackColor = true;
            this.chkPasswordProtect.CheckedChanged += new System.EventHandler(this.chkPasswordProtect_CheckedChanged);
            // 
            // txtPasswordProtect
            // 
            this.txtPasswordProtect.BackColor = System.Drawing.Color.Lavender;
            this.txtPasswordProtect.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordProtect.Enabled = false;
            this.txtPasswordProtect.Location = new System.Drawing.Point(253, 194);
            this.txtPasswordProtect.MaxLength = 100;
            this.txtPasswordProtect.Name = "txtPasswordProtect";
            this.txtPasswordProtect.Size = new System.Drawing.Size(221, 20);
            this.txtPasswordProtect.TabIndex = 13;
            // 
            // chkPasswordTray
            // 
            this.chkPasswordTray.AutoSize = true;
            this.chkPasswordTray.Location = new System.Drawing.Point(12, 219);
            this.chkPasswordTray.Name = "chkPasswordTray";
            this.chkPasswordTray.Size = new System.Drawing.Size(210, 17);
            this.chkPasswordTray.TabIndex = 14;
            this.chkPasswordTray.Text = "Password protect while opening in tray:";
            this.chkPasswordTray.UseVisualStyleBackColor = true;
            this.chkPasswordTray.CheckedChanged += new System.EventHandler(this.chkPasswordTray_CheckedChanged);
            // 
            // txtPasswordTray
            // 
            this.txtPasswordTray.BackColor = System.Drawing.Color.Lavender;
            this.txtPasswordTray.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordTray.Enabled = false;
            this.txtPasswordTray.Location = new System.Drawing.Point(253, 216);
            this.txtPasswordTray.MaxLength = 100;
            this.txtPasswordTray.Name = "txtPasswordTray";
            this.txtPasswordTray.Size = new System.Drawing.Size(221, 20);
            this.txtPasswordTray.TabIndex = 15;
            // 
            // chkAutoSaveLogs
            // 
            this.chkAutoSaveLogs.AutoSize = true;
            this.chkAutoSaveLogs.Location = new System.Drawing.Point(12, 334);
            this.chkAutoSaveLogs.Name = "chkAutoSaveLogs";
            this.chkAutoSaveLogs.Size = new System.Drawing.Size(150, 17);
            this.chkAutoSaveLogs.TabIndex = 21;
            this.chkAutoSaveLogs.Text = "Auto-save logs (to logs.txt)";
            this.chkAutoSaveLogs.UseVisualStyleBackColor = true;
            // 
            // btnLoadDefaults
            // 
            this.btnLoadDefaults.Location = new System.Drawing.Point(233, 371);
            this.btnLoadDefaults.Name = "btnLoadDefaults";
            this.btnLoadDefaults.Size = new System.Drawing.Size(87, 23);
            this.btnLoadDefaults.TabIndex = 24;
            this.btnLoadDefaults.Text = "Load Defaults";
            this.btnLoadDefaults.UseVisualStyleBackColor = true;
            this.btnLoadDefaults.Click += new System.EventHandler(this.btnLoadDefaults_Click);
            // 
            // btnImportSettings
            // 
            this.btnImportSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportSettings.ForeColor = System.Drawing.Color.Maroon;
            this.btnImportSettings.Location = new System.Drawing.Point(367, 265);
            this.btnImportSettings.Name = "btnImportSettings";
            this.btnImportSettings.Size = new System.Drawing.Size(107, 23);
            this.btnImportSettings.TabIndex = 25;
            this.btnImportSettings.Text = "Import Settings";
            this.btnImportSettings.UseVisualStyleBackColor = true;
            this.btnImportSettings.Click += new System.EventHandler(this.btnImportSettings_Click);
            // 
            // btnImportAutomations
            // 
            this.btnImportAutomations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportAutomations.ForeColor = System.Drawing.Color.Maroon;
            this.btnImportAutomations.Location = new System.Drawing.Point(367, 294);
            this.btnImportAutomations.Name = "btnImportAutomations";
            this.btnImportAutomations.Size = new System.Drawing.Size(107, 23);
            this.btnImportAutomations.TabIndex = 25;
            this.btnImportAutomations.Text = "Import Automations";
            this.btnImportAutomations.UseVisualStyleBackColor = true;
            this.btnImportAutomations.Click += new System.EventHandler(this.btnImportAutomations_Click);
            // 
            // btnImportCredentials
            // 
            this.btnImportCredentials.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImportCredentials.ForeColor = System.Drawing.Color.Maroon;
            this.btnImportCredentials.Location = new System.Drawing.Point(367, 323);
            this.btnImportCredentials.Name = "btnImportCredentials";
            this.btnImportCredentials.Size = new System.Drawing.Size(107, 23);
            this.btnImportCredentials.TabIndex = 25;
            this.btnImportCredentials.Text = "Import Credentials";
            this.btnImportCredentials.UseVisualStyleBackColor = true;
            this.btnImportCredentials.Click += new System.EventHandler(this.btnImportCredentials_Click);
            // 
            // fSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Lavender;
            this.ClientSize = new System.Drawing.Size(483, 405);
            this.Controls.Add(this.btnImportCredentials);
            this.Controls.Add(this.btnImportAutomations);
            this.Controls.Add(this.btnImportSettings);
            this.Controls.Add(this.btnLoadDefaults);
            this.Controls.Add(this.txtPasswordTray);
            this.Controls.Add(this.txtPasswordProtect);
            this.Controls.Add(this.txtAutomationControl);
            this.Controls.Add(this.txtDefaultPort);
            this.Controls.Add(this.chkPasswordProtect);
            this.Controls.Add(this.chkAutomationControl);
            this.Controls.Add(this.chkDefaultPort);
            this.Controls.Add(this.chkDeleteRemoteFile);
            this.Controls.Add(this.chkConfirmDeleteSavedCredentials);
            this.Controls.Add(this.cmbConnectStartup);
            this.Controls.Add(this.chkAutoExpangAutomations);
            this.Controls.Add(this.chkConfirmDeletingAutomation);
            this.Controls.Add(this.chkConfirmExitingApp);
            this.Controls.Add(this.chkAutoSaveLogs);
            this.Controls.Add(this.chkPasswordTray);
            this.Controls.Add(this.chkMinimizeTrayWhenClosing);
            this.Controls.Add(this.chkStartInSystemTray);
            this.Controls.Add(this.chkConnectStartup);
            this.Controls.Add(this.chkAutoScrollLogs);
            this.Controls.Add(this.lblWarningStartup);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkStartup);
            this.Name = "fSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings for MicroSharpFTP";
            this.Load += new System.EventHandler(this.fSettings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.CheckBox chkStartup;
        internal System.Windows.Forms.Label lblWarningStartup;
        internal System.Windows.Forms.CheckBox chkAutoScrollLogs;
        internal System.Windows.Forms.CheckBox chkConnectStartup;
        internal System.Windows.Forms.ComboBox cmbConnectStartup;
        internal System.Windows.Forms.CheckBox chkConfirmDeleteSavedCredentials;
        internal System.Windows.Forms.CheckBox chkDefaultPort;
        internal System.Windows.Forms.TextBox txtDefaultPort;
        internal System.Windows.Forms.CheckBox chkDeleteRemoteFile;
        internal System.Windows.Forms.CheckBox chkStartInSystemTray;
        internal System.Windows.Forms.CheckBox chkMinimizeTrayWhenClosing;
        internal System.Windows.Forms.CheckBox chkConfirmExitingApp;
        internal System.Windows.Forms.CheckBox chkConfirmDeletingAutomation;
        internal System.Windows.Forms.CheckBox chkAutoExpangAutomations;
        internal System.Windows.Forms.CheckBox chkAutomationControl;
        internal System.Windows.Forms.TextBox txtAutomationControl;
        internal System.Windows.Forms.CheckBox chkPasswordProtect;
        internal System.Windows.Forms.TextBox txtPasswordProtect;
        internal System.Windows.Forms.CheckBox chkPasswordTray;
        internal System.Windows.Forms.TextBox txtPasswordTray;
        internal System.Windows.Forms.CheckBox chkAutoSaveLogs;
        private System.Windows.Forms.Button btnLoadDefaults;
        private System.Windows.Forms.Button btnImportSettings;
        private System.Windows.Forms.Button btnImportAutomations;
        private System.Windows.Forms.Button btnImportCredentials;
    }
}