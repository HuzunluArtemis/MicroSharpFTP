using System;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Windows.Forms;

namespace MicroSharpFTP
{
    public partial class fAutomation : Form
    {
        public fAutomation()
        {
            InitializeComponent();
        }
        internal int SelectedAccount = 0;
        internal int SelectedAction = 0;
        private void fAutomation_Load(object sender, EventArgs e)
        {
            
            // dinamik

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Id");
            dt.Columns.Add("processname");
            DataRow r = dt.NewRow();
            r["Id"] = "1";
            r["processname"] = "Download";
            dt.Rows.Add(r);
            r = dt.NewRow();
            r["Id"] = "2";
            r["processname"] = "Upload";
            dt.Rows.Add(r);
            r = dt.NewRow();
            r["Id"] = "3";
            r["processname"] = "Rename";
            dt.Rows.Add(r);
            r = dt.NewRow();
            r["Id"] = "4";
            r["processname"] = "Delete";
            dt.Rows.Add(r);
            r = dt.NewRow();
            r["Id"] = "5";
            r["processname"] = "New Folder";
            dt.Rows.Add(r);
            r = dt.NewRow();



            cmbAutomation.DataSource = dt;
            cmbAutomation.DisplayMember = "processname";
            cmbAutomation.ValueMember = "Id";

            //This will set the ComboBox to "Supplier B"
            

            //
            //System.Drawing.Size y = new Size(626, 380);
            //this.MinimumSize = y;
            //this.Width = 626;
            // tooltipler
            toolTip1.SetToolTip(this.btnExpand, "Show/Hide Existing Automations");
            //
            this.Icon = resources.Goescat_Macaron;
            //
            DateTime a = new DateTime();
            a = DateTime.Now;
            a= a.AddDays(-7);
            dpChooseDate.MinDate =a ;
            // dakika saat için özel
            dpChooseDate.Format = DateTimePickerFormat.Custom;
            dpChooseDate.CustomFormat = "dd MMMM yyyy, '(Hour in 24 format)' H.mm:ss";
            //
            cmbAutomation.SelectedIndex = SelectedAction;
            //
            cmbForAccount.SelectedIndex = SelectedAccount;
            //
            ListAutomationsToListView();
            //
            if (ftp.AutoExpandAutomations)
            {
                Size h = new Size(708, 723);
                MinimumSize = h;
                MaximumSize = h;
                this.Size = h;
                btnExpand.Text = @"/\";
            }
            else
            {
                Size h = new Size(708, 403);
                MinimumSize = h;
                MaximumSize = h;
                this.Size = h;
                btnExpand.Text = @"\/";
            }
            
        }

        public void ListAutomationsToListView()
        {
            dgwAutomations.Rows.Clear();
            dgwAutomations.Refresh();

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
                        dgwAutomations.Rows.Add(new object[] {
                            r.GetValue(r.GetOrdinal("ID")),  // Or column name like this
                            r.GetValue(r.GetOrdinal("ForAccount")),
                            r.GetValue(r.GetOrdinal("Type")),
                            r.GetValue(r.GetOrdinal("FireTime")),
                            r.GetValue(r.GetOrdinal("Frrom")),
                            r.GetValue(r.GetOrdinal("Tto")),
                            r.GetValue(r.GetOrdinal("Notes")),
                            r.GetValue(r.GetOrdinal("Percent")),
                            r.GetValue(r.GetOrdinal("AddingTime"))
                        });
                    }
                    // düzenle
                    // Set your desired AutoSize Mode:
                    dgwAutomations.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    dgwAutomations.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    dgwAutomations.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgwAutomations.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgwAutomations.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    dgwAutomations.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    dgwAutomations.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                    dgwAutomations.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgwAutomations.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    //  dataGridView1.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                    // Now that DataGridView has calculated it's Widths; we can now store each column Width values.
                    for (int i = 0; i <= dgwAutomations.Columns.Count - 1; i++)
                    {
                        // Store Auto Sized Widths:
                        int colw = dgwAutomations.Columns[i].Width;

                        // Remove AutoSizing:
                        dgwAutomations.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                        // Set Width to calculated AutoSize value:
                        dgwAutomations.Columns[i].Width = colw;
                    }
                }
                connect.Close();
            }
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            string foraccount = this.cmbForAccount.GetItemText(cmbForAccount.SelectedItem);
            string process = this.cmbAutomation.GetItemText(cmbAutomation.SelectedItem);
            string from = this.txtFrom.Text;
            string to = this.txtTo.Text;
            string firetime = this.dpChooseDate.Value.ToString() ;
            string notes = this.txtNotes.Text;
            //
            if (cmbAutomation.GetItemText(cmbAutomation.SelectedItem)=="Delete" || cmbAutomation.GetItemText(cmbAutomation.SelectedItem) == "New Folder")
            {
                to = null;
            }
            //MessageBox.Show(process + from + to + firetime+notes);
            if (process !="" && process!=" " 
                && from!="" && from!=" "
                && firetime != "" && firetime != " ")
            {
                SaveAutomationToDatabase(process, from, to, firetime, notes,foraccount);
                //
                // MessageBox.Show("Saved.");
                ListAutomationsToListView();
                ftp.AutomationsDownloaded = false;
            }
            

        }
        private void SaveAutomationToDatabase(string process, string from, string to, string firetime, string notes, string foraccount)
            
            
        {
            string now = DateTime.Now.ToString();
            string firstadded = string.Empty;
            using (SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=" + @ftp.ProgramDataDir + @"\" + @ftp.FilenameAutomations))
            {
                
                string fromr = string.Empty;
                string tor = string.Empty;
                string foraccr = string.Empty;

                using (SQLiteCommand gom = new SQLiteCommand(con))
                {
                    string comm = "SELECT * FROM AutomationList WHERE [Frrom] = "
                + "'"
                + from
                + "'"
                + " AND [Tto] = "
                + "'"
                + to
                + "'"
                + " AND [ForAccount] = "
                + "'"
                + foraccount
                + "'";

                    gom.CommandText = comm;
                    gom.CommandType = CommandType.Text;
                    con.Open();
                    SQLiteDataReader r = gom.ExecuteReader();
                    

                    while (r.Read())
                    {
                        fromr = Convert.ToString(r["Frrom"]);
                        tor = Convert.ToString(r["Tto"]);
                        firstadded = Convert.ToString(r["AddingTime"]);
                        foraccr = Convert.ToString(r["ForAccount"]);
                    }
                    con.Close();
                }

                using (SQLiteCommand com = new SQLiteCommand(con))
                {

                    if (from == fromr && to == tor &&foraccr == foraccount) // aynı host ve kullanıcı adı var + hesap eklendi
                    {
                        string message = "Same automation found. Do you want to update it with new settings?" +
                            "\n(Added in: " + firstadded + ")";
                        const string caption = "Change Automation?";
                        DialogResult result = MessageBox.Show(message, caption,
                             MessageBoxButtons.YesNo,
                             MessageBoxIcon.Question);
                        switch (result)
                        {
                            case DialogResult.Yes:
                                con.Open();
                                using (SQLiteCommand fmd = con.CreateCommand())
                                {
                                    
                                    string comm = "UPDATE AutomationList SET Frrom = "
                                    + "'"
                                    + from
                                    + "', Tto = "
                                    + "'"
                                    + to
                                    + "', Type = "
                                    + "'"
                                    + process
                                    + "', FireTime = "
                                    + "'"
                                    + firetime
                                    + "', Notes = "
                                    + "'"
                                    + notes
                                    + "', AddingTime = "
                                    + "'"
                                    + now
                                    + "', ForAccount = "
                                    + "'"
                                    + foraccount
                                    + "'"
                                    + " WHERE Tto = "
                                    + "'"
                                    + to
                                    + "'"
                                    + " AND Frrom = "
                                    + "'"
                                    + from
                                    + "'"
                                    + " AND ForAccount = "
                                    + "'"
                                    + foraccount
                                    + "'";
                                    fmd.CommandText = comm;
                                    fmd.CommandType = CommandType.Text;
                                    fmd.ExecuteNonQuery();
                                }
                                con.Close();
                                string tolog = "Details changes for Account: "+ foraccount+ " From: " + from + ", To: " + to;
                                ftp.ResponseStatus = tolog;
                                break;
                            case DialogResult.No:
                               // dataviewden seçtir.
                                break;
                        }
                    }
                    else
                    {
                        // string command = @"INSERT INTO DatabaseList (Host,Username,Password,Port) Values ('denemebir.com','denemeuseri','denemepasswordu','denemeportu')";
                        string command = @"INSERT INTO AutomationList (Type,FireTime,Frrom,Tto,Notes,Percent,AddingTime,ForAccount) Values ('" + 
                            process + "','" + firetime + "','" + from + "','" + to + "','" + notes + "','" + null + "','" + now + "','" + foraccount + "')";
                        con.Open();
                        com.CommandText = command;
                        com.ExecuteNonQuery();      // Execute the query
                        con.Close();        // Close the connection to the database
                        
                        string tolog = "Saved Automation. Details: Account: " + foraccount + ", Type: " + process + ", FireTime: " + firetime + ", From: " + from + ", To: " + to;
                        if (notes == "" || notes == " ")
                        {
                            tolog += " (with no notes)";
                        }
                        else
                        {
                            tolog += " (with notes)";
                        }
                        tolog += " At: " + now;
                        ftp.ResponseStatus = tolog;
                    }

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonshowexists_Click(object sender, EventArgs e)
        {
            switch (this.Height)
            {
                case 723:
                    {
                        Size a = new Size(708, 403);
                        MinimumSize = a;
                        MaximumSize = a;
                        this.Size = a;
                        btnExpand.Text = @"\/";
                        break;
                    }

                case 403:
                    {
                        Size b = new Size(708, 723);
                        MinimumSize = b;
                        MaximumSize = b;
                        this.Size = b;
                        btnExpand.Text = @"/\";
                        break;
                    }
            }
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ListAutomationsToListView();
        }

        //
        private void DeleteSavedAutomationWithId(string id)
        {
            if (id == null)
            {
                
                return;
            }
           
            using (SQLiteConnection connect = new SQLiteConnection(@"data source = " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameAutomations))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    string comm = "DELETE FROM AutomationList WHERE ID = "
                    + "'"
                    + id
                    + "'";
                    fmd.CommandText = comm;
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                }
                connect.Close();
            }
            ListAutomationsToListView();
        }
        //

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgwAutomations.SelectedRows.Count!=0)
            {
                string id = dgwAutomations.SelectedRows[0].Cells[0].Value.ToString();

                if (ftp.ConfirmDeletingAutomation)
                {
                    //
                    string account = dgwAutomations.SelectedRows[0].Cells[1].Value.ToString();
                    string type = dgwAutomations.SelectedRows[0].Cells[2].Value.ToString();
                    string firetime = dgwAutomations.SelectedRows[0].Cells[3].Value.ToString();
                    string from = dgwAutomations.SelectedRows[0].Cells[4].Value.ToString();
                    string to = dgwAutomations.SelectedRows[0].Cells[5].Value.ToString();
                    string percent = dgwAutomations.SelectedRows[0].Cells[7].Value.ToString();
                    string addedtime = dgwAutomations.SelectedRows[0].Cells[8].Value.ToString();
                    //
                    string message = "Do you want to delete this from saved automations?: " +
                    Environment.NewLine +
                    Environment.NewLine +
                    // ayrıntılar
                    "ID: " + "\t\t" + id +
                    Environment.NewLine +
                    "Account: " + "\t" + account +
                    Environment.NewLine +
                    "Type: " + "\t\t" + type +
                    Environment.NewLine +
                    "FireTime: " + "\t" + firetime +
                    Environment.NewLine +
                    "From: " + "\t\t" + from +
                    Environment.NewLine +
                    "To: " + "\t\t" + to +
                    Environment.NewLine +
                    "AddedTime: " + "\t" + addedtime +
                    Environment.NewLine +
                    "Percent: " +"\t\t" +percent;
                    string caption = "Confirm Delete";
                    DialogResult result = MessageBox.Show(message, caption,
                         MessageBoxButtons.YesNo,
                         MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        DeleteSavedAutomationWithId(id);
                        
                    }
                }
                else
                {
                    DeleteSavedAutomationWithId(id);
                }

                ftp.AutomationsDownloaded = false;

            }
        }

        

      
         

        private void txtto_MouseUp(object sender, MouseEventArgs e)
        {
            if (cmbAutomation.GetItemText(cmbAutomation.SelectedItem) == "Download")
            {
                if (ftp.IsMiddleClick(e))
                {
                    if (!txtFrom.Text.EndsWith("/"))
                    {
                        SaveFileDialog s = new SaveFileDialog();

                        s.Title = "Select folder and enter filename";
                        if (s.ShowDialog() == DialogResult.OK)
                        {
                            txtTo.Text = s.FileName;
                        }
                    }
                    else
                    {
                        FolderBrowserDialog Klasor = new FolderBrowserDialog();
                        DialogResult a = Klasor.ShowDialog();
                        if (a == DialogResult.OK)
                        {
                            string y = Klasor.SelectedPath;
                            if (!y.EndsWith(@"\"))
                            {
                                y+=@"\";
                            }
                            txtTo.Text = y;
                        }
                    }
                } 

                
            }
        }

        private void txtfrom_MouseUp(object sender, MouseEventArgs e)
        {
            if (cmbAutomation.GetItemText(cmbAutomation.SelectedItem) == "Upload")
            {
                if (ftp.IsMiddleClick(e))
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog
                    {
                        Filter = "All files (*.*)|*.*",
                        RestoreDirectory = true,
                        Multiselect = false
                    };

                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        txtFrom.Text= openFileDialog1.FileName;
                    }

                }


            }
        }

        private void cmbAutomate_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbAutomation.GetItemText(cmbAutomation.SelectedItem))
            {
                case "Download":
                    toolTip1.SetToolTip(txtTo, "Click mouse middle button to select download folder and filename");
                    txtTo.Enabled = true;
                    lblTo.Enabled = true;
                    break;
                case "Upload":
                    toolTip1.SetToolTip(txtFrom, "Click mouse middle button to select to-upload filename");
                    txtTo.Enabled = true;
                    lblTo.Enabled = true;
                    break;
                case "Rename":
                    toolTip1.SetToolTip(txtFrom, "Fill here with remote filename");
                    toolTip1.SetToolTip(txtTo, "Fill here with new filename with extension");
                    txtTo.Enabled = true;
                    lblTo.Enabled = true;
                    break;
                case "Delete":
                    toolTip1.SetToolTip(txtFrom, "Remote to-delete folder or file full url (put \"/\" at the end if it is an folder)");
                    txtTo.Enabled = false;
                    lblTo.Enabled = false;
                    break;
                case "New Folder":
                    toolTip1.SetToolTip(txtFrom, "Fill with full adres of remote to-create folder");
                    txtTo.Enabled = false;
                    lblTo.Enabled = false;
                    break;
            }
        }

        private void txtFrom_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cmbAutomation.GetItemText(cmbAutomation.SelectedItem) == "Download")
            {

                SaveFileDialog s = new SaveFileDialog();

                s.Title = "Select folder and enter filename";
                if (s.ShowDialog() == DialogResult.OK)
                {
                    txtTo.Text = s.FileName;
                }

            }
            else if (cmbAutomation.GetItemText(cmbAutomation.SelectedItem) == "Upload")
            {
                SaveFileDialog s = new SaveFileDialog();

                s.Title = "Select folder and enter filename";
                if (s.ShowDialog() == DialogResult.OK)
                {
                    txtFrom.Text = s.FileName;
                }
            }
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            if (cmbAutomation.GetItemText(cmbAutomation.SelectedItem) == "Download")
            {

                FolderBrowserDialog Klasor = new FolderBrowserDialog();
                DialogResult a = Klasor.ShowDialog();
                if (a == DialogResult.OK)
                {
                    string selected = Klasor.SelectedPath;
                    if (!selected.EndsWith(@"\"))
                    {
                        selected += @"\";
                    }
                    txtTo.Text = selected;
                }

            }
            else if (cmbAutomation.GetItemText(cmbAutomation.SelectedItem) == "Upload")
            {
                FolderBrowserDialog Klasor = new FolderBrowserDialog();
                DialogResult a = Klasor.ShowDialog();
                if (a == DialogResult.OK)
                {
                    string selected = Klasor.SelectedPath;
                    if (!selected.EndsWith(@"\"))
                    {
                        selected += @"\";
                    }
                    txtFrom.Text = selected;
                }
            }

            //
            
            //
        }
    }
}
