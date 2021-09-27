using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MicroSharpFTP
{
    class ftp
    {
        // get required strings and settings from database
        internal readonly static string AboutText = "Copyright © 2021 MicroSharpFTP by HuzunluArtemis" + Environment.NewLine + Environment.NewLine + "Github/Gitlab: @HuzunluArtemis" + Environment.NewLine + "Telegram Channel: @HuzunluArtemis" + Environment.NewLine + "License: https://www.gnu.org/licenses/gpl-3.0" + Environment.NewLine + Environment.NewLine + "MicroSharpFTP is Free Software: You can use, study share and improve it at your will. Specifically you can redistribute and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version." + Environment.NewLine + Environment.NewLine + "Do you want to go source code?";
        internal readonly static string AboutTitle = "About MicroSharpFTP";
        internal readonly static string FilenameAutomations = "MicroSharpFTP.AutomationList.db";
        internal readonly static string FilenameCredentials = "MicroSharpFTP.CredentialList.db";
        internal readonly static string FilenameSettings = "MicroSharpFTP.Settings.db";
        internal readonly static string FilenameLogs = "MicroSharpFTP.Logs.txt";
        internal readonly static string ProgramDataDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\MicroSharpFTP";
        internal readonly static string ProgramRepo = "https://github.com/HuzunluArtemis/MicroSharpFTP";

        internal static bool AutoConnectAtStartup = false; // vtye aktar
        internal static bool AutoExpandAutomations = true; // vtye aktar
        internal static bool AutomationControl = true; // vtye aktar  otomasyon kontrolü
        internal static bool AutomationsDownloaded = false; // vtye aktar // başta otomasyonları çek tek seferde.
        internal static bool AutoSaveLogs = true; // vtye aktar
        internal static bool AutoScrollLogs = true; // vtye aktar
        internal static bool ConfirmDeletingAutomation = true; // vtye aktar
        internal static bool ConfirmDeletingRemoteFile = true; // vtye aktar
        internal static bool ConfirmDeletingSavedCredential = true; // vtye aktar
        internal static bool ConfirmExitingApp = false; // vtye aktar
        internal static bool DefaultPort = true; // vtye aktar
        internal static bool DidUserClosed = true;
        internal static bool MinimizeSystemTrayWhenClosing = false; // vtye aktar
        internal static bool PasswordProtectProgram = true; // vtye aktar  password while entering program
        internal static bool PasswordProtectTray = true; // vtye aktar  password while entering program
        internal static bool StartInSystemTray = false; // vtye aktar
        internal static bool ToGoRenew = false; // yenileme
        internal static int AutomationControlMs = 1000; // vtye aktar
        internal static int DefaultPortInt = 21; // vtye aktar
        internal static string ActiveDirectory = string.Empty;
        internal static string AutoConnectingAdress = null;
        internal static string PasswordProtectStr = "abc";// string.Empty;
        internal static string PasswordProtectTrayStr = "abcd";// string.Empty;
        internal static string ResponseStatus = null;
        // for automations
        internal static List<string> IDList = new List<string>();
        internal static List<string> PercentList = new List<string>();
        internal static List<string> TimeList = new List<string>();
        // for dir downloading
        internal static List<string> ListForFilenames = new List<string>(); // isimleri biriktir
        internal static List<long> ListForFileSizes = new List<long>(); // boyutları biriktir
        // for dir upload
        internal static List<string> ListForFilenamesU = new List<string>(); // isimleri biriktir
        internal static List<long> ListForFileSizesU = new List<long>(); // boyutları biriktir
        // for ftp class
        private string host = null;
        private string user = null;
        private string pass = null;
        private FtpWebRequest ftpRequest = null;
        private FtpWebResponse ftpResponse = null;
        private Stream ftpStream = null;

        //
        
        //
        internal static void GetSettingsFromSettingsDatabase()
        {
            if (!File.Exists(@ftp.ProgramDataDir + @"\" + @ftp.FilenameSettings))
            {
                CreateSettingsDatabase();
            }
                using (SQLiteConnection connect = new SQLiteConnection(@"data source = " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameSettings))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    string comm = "SELECT * FROM Settings WHERE OnlyOneRow = '1'";
                    fmd.CommandText = comm;
                    fmd.CommandType = System.Data.CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        
                        ftp.DefaultPortInt = Convert.ToInt32(r["DefaultPortInt"]);
                        ftp.PasswordProtectStr = Convert.ToString(r["PasswordProtectStr"]);
                        ftp.AutoConnectAtStartup = Convert.ToBoolean(r["AutoConnectAtStartup"]);
                        ftp.PasswordProtectTray = Convert.ToBoolean(r["PasswordProtectTray"]);
                        ftp.PasswordProtectTrayStr = Convert.ToString(r["PasswordProtectTrayStr"]);
                        ftp.AutoExpandAutomations = Convert.ToBoolean(r["AutoExpandAutomations"]);
                        ftp.AutomationControl = Convert.ToBoolean(r["AutomationControl"]);
                        ftp.AutoSaveLogs = Convert.ToBoolean(r["AutoSaveLogs"]);
                        ftp.AutoScrollLogs = Convert.ToBoolean(r["AutoScrollLogs"]);
                        ftp.ConfirmDeletingAutomation = Convert.ToBoolean(r["ConfirmDeletingAutomation"]);
                        ftp.ConfirmDeletingRemoteFile = Convert.ToBoolean(r["ConfirmDeletingRemoteFile"]);
                        ftp.ConfirmDeletingSavedCredential = Convert.ToBoolean(r["ConfirmDeletingSavedCredential"]);
                        ftp.ConfirmExitingApp = Convert.ToBoolean(r["ConfirmExitingApp"]);
                        ftp.DefaultPort = Convert.ToBoolean(r["DefaultPort"]);
                        ftp.StartInSystemTray = Convert.ToBoolean(r["StartInSystemTray"]);
                        ftp.PasswordProtectProgram = Convert.ToBoolean(r["PasswordProtectProgram"]);
                        ftp.MinimizeSystemTrayWhenClosing = Convert.ToBoolean(r["MinimizeSystemTrayWhenClosing"]);
                        ftp.AutomationControlMs = Convert.ToInt32(r["AutomationControlMs"]);
                    }
                }
                connect.Close();
            }
        }

        /* Construct Object */
        public ftp(string hostIP, string userName, string password)

        {
            host = hostIP; user = userName; pass = password;
            GetSettingsFromSettingsDatabase();
        }

        internal static string CreateSettingsDatabase()
        {

            if (!File.Exists(@ftp.ProgramDataDir + @"\" + @ftp.FilenameSettings))
            {


                if (!Directory.Exists(@ftp.ProgramDataDir))
                {
                    Directory.CreateDirectory(@ftp.ProgramDataDir);

                }

                System.Data.SQLite.SQLiteConnection.CreateFile(@ftp.ProgramDataDir + @"\" + @ftp.FilenameSettings);

                
                // https://www.fluxbytes.com/csharp/how-to-create-and-connect-to-an-sqlite-database-in-c/
                using (System.Data.SQLite.SQLiteConnection con = new System.Data.SQLite.SQLiteConnection("data source=" + @ftp.ProgramDataDir + @"\" + @ftp.FilenameSettings))
                {
                    using (System.Data.SQLite.SQLiteCommand com = new System.Data.SQLite.SQLiteCommand(con))
                    {
                        con.Open();                             // Open the connection to the database
                        //
                        string createTableQuery = @"CREATE TABLE IF NOT EXISTS [Settings] (
                    [OnlyOneRow] INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT,
                    [AutoConnectAtStartup] VARCHAR(1) NOT NULL,
                    [AutoConnectingAdress] VARCHAR(1000) NULL,
                    [AutoExpandAutomations] VARCHAR(1) NOT NULL,
                    [AutomationControl] VARCHAR(1) NOT NULL,
                    [AutoSaveLogs] VARCHAR(1) NOT NULL,
                    [AutoScrollLogs] VARCHAR(1) NOT NULL,
                    [ConfirmDeletingAutomation] VARCHAR(1) NOT NULL,
                    [ConfirmDeletingRemoteFile] VARCHAR(1) NOT NULL,
                    [ConfirmDeletingSavedCredential] VARCHAR(1) NOT NULL,
                    [ConfirmExitingApp] VARCHAR(1) NOT NULL,
                    [DefaultPortInt] VARCHAR(8) NOT NULL,
                    [DefaultPort] VARCHAR(1) NOT NULL,
                    [MinimizeSystemTrayWhenClosing] VARCHAR(1) NOT NULL,
                    [PasswordProtectStr] VARCHAR(100) NULL,
                    [PasswordProtectTray] VARCHAR(1) NOT NULL,
                    [PasswordProtectTrayStr] VARCHAR(100) NULL,
                    [StartInSystemTray] VARCHAR(1) NOT NULL,
                    [AutomationControlMs] VARCHAR(15) NOT NULL,
                    [PasswordProtectProgram] VARCHAR(1) NOT NULL)";
                        com.CommandText = createTableQuery;     // Set CommandText to our query that will create the table
                        com.ExecuteNonQuery();                  // Execute the query
                        //
                        string command = @"INSERT INTO Settings (AutoConnectAtStartup, AutoConnectingAdress, AutoExpandAutomations, AutomationControl, AutoSaveLogs, AutoScrollLogs, ConfirmDeletingAutomation, ConfirmDeletingRemoteFile, ConfirmDeletingSavedCredential, ConfirmExitingApp, DefaultPortInt, DefaultPort, MinimizeSystemTrayWhenClosing, PasswordProtectProgram, PasswordProtectStr, PasswordProtectTray, PasswordProtectTrayStr, StartInSystemTray, AutomationControlMs, PasswordProtectProgram) Values ('False', '', 'False', 'False', 'True', 'True', 'True', 'True', 'True', 'False', '21', 'True', 'True', 'False', '', 'False', '', 'False', '1000', 'False')";
                        com.CommandText = command;
                        com.ExecuteNonQuery();
                        con.Close();        // Close the connection to the database
                    }
                    return "Settings database not found. Created: " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameSettings;
                }

            }
            else if (File.Exists(@ftp.ProgramDataDir + @"\" + @ftp.FilenameSettings)) // db varsa
            {
                return "Settings database found. Connected: " + @ftp.ProgramDataDir + @"\" + @ftp.FilenameSettings;
            }
            else
            {
                return null;
            }
        }

        //
        //public void download(string remoteFile, string localFile)
        //{
        //    try
        //    {
        //        /* Create an FTP Request */
        //        ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + remoteFile);
        //        /* Log in to the FTP Server with the User Name and Password Provided */
        //        ftpRequest.Credentials = new NetworkCredential(user, pass);
        //        /* When in doubt, use these options */
        //        ftpRequest.UseBinary = true;
        //        ftpRequest.UsePassive = true;
        //        ftpRequest.KeepAlive = true;
        //        /* Specify the Type of FTP Request */
        //        ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
        //        /* Establish Return Communication with the FTP Server */
        //        ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
        //        /* Get the FTP Server's Response Stream */
        //        ftpStream = ftpResponse.GetResponseStream();
        //        /* Open a File Stream to Write the Downloaded File */
        //        FileStream localFileStream = new FileStream(localFile, FileMode.Create);
        //        /* Buffer for the Downloaded Data */
        //        byte[] byteBuffer = new byte[bufferSize];
        //        int bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
        //        /* Download the File by Writing the Buffered Data Until the Transfer is Complete */
        //        try
        //        {
        //            while (bytesRead > 0)
        //            {
        //                localFileStream.Write(byteBuffer, 0, bytesRead);
        //                bytesRead = ftpStream.Read(byteBuffer, 0, bufferSize);
        //            }
        //        }
        //        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        //        /* Resource Cleanup */
        //        localFileStream.Close();
        //        ftpStream.Close();
        //        ftpResponse.Close();
        //        ftpRequest = null;
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        //    return;
        //}

        ////eski download fonksiyonu


        // yeni yazdım
        /* Download File */
        //
        internal void UploadFolder(ProgressBar allprg, Label alllbl, Label lblallbytes, string uploaddir,
            string @selectedlocaldir, ProgressBar currentper, Label currentlbl, Label labelbytes)
        {
            
            List<string> filenameyalin = new List<string>();
            //  = ftp.ListForFilenamesU;
            int totalsize = 0;
            if (!uploaddir.EndsWith("/"))
                uploaddir += "/";
            int livesize = 0;
            DirectoryInfo di = new DirectoryInfo(@selectedlocaldir);
            FileInfo[] files = di.GetFiles();
            foreach (FileInfo item in files)
            {
                ftp.ListForFilenamesU.Add(item.FullName);
                ftp.ListForFileSizesU.Add(item.Length);
                filenameyalin.Add(item.Name);
            }
            allprg.Maximum = 100;

            for (int i = 0; i < ListForFileSizesU.Count; i++)
            {
                totalsize +=  Convert.ToInt32( ftp.ListForFileSizesU[i]);
            }
            
            
            allprg.Maximum = totalsize;
            for (int i = 0; i < ftp.ListForFilenamesU.Count; i++)
            {
                alllbl.Refresh();
                allprg.Refresh();
                currentper.Refresh();
                lblallbytes.Refresh();
                string az = UploadFile(filenameyalin[i] ,ListForFilenamesU[i],currentper,currentlbl,currentlbl);
                
                livesize += Convert.ToInt32(ftp.ListForFileSizesU[i]);
                lblallbytes.Text = ftp.BytesToString(livesize) + @"/" + ftp.BytesToString(totalsize);
                try
                {
                    allprg.Invoke((MethodInvoker)(() => allprg.Value += Convert.ToInt32(ftp.ListForFileSizesU[i])));
                }
                catch (Exception)
                {

                    allprg.Maximum = 100;
                    allprg.Value = 100;
                }
                
                int percent = (int)(allprg.Value / (double)allprg.Maximum * 100);
                alllbl.Text = percent.ToString() + " %";
                alllbl.Refresh();
                allprg.Refresh();
                currentper.Refresh();
                lblallbytes.Refresh();

            }
            //filenameyalin.Clear();
            ftp.ListForFilenamesU.Clear();
            ftp.ListForFileSizesU.Clear();
            totalsize = 0;
            livesize = 0;
        }
        internal void DownloadFolder(ProgressBar allprg, Label alllbl, Label lblallbytes, string downdir, ProgressBar currentper, Label currentlbl, Label labelbytes)
        {
            
            List<string> filenameyalin = new List<string>();
            filenameyalin = ftp.ListForFilenames;
            int totalsize = 0;
            int livesize = 0;
            for (int i = 0; i < ftp.ListForFileSizes.Count; i++)
            {
                totalsize += Convert.ToInt32(ftp.ListForFileSizes[i]);
            }
            allprg.Maximum = totalsize;
            for (int i = 0; i < ftp.ListForFilenames.Count; i++)
            {
                string a = ListForFilenames[i];
                filenameyalin[i] = ListForFilenames[i];
                Match match = Regex.Match(filenameyalin[i], @"\/(?:.(?!\/))+$");
                match.Value.Replace("/", "");
                filenameyalin[i] = match.Value;
                string b = downdir + @"\" + ListForFilenames[i];
                string az = DownloadFile(a,b, currentper, currentlbl,labelbytes);
                int percent = (int)(allprg.Value / (double)allprg.Maximum * 100);
                alllbl.Text = percent.ToString() + " %";
                livesize += Convert.ToInt32( ftp.ListForFileSizes[i]);
                lblallbytes.Text = ftp.BytesToString(livesize) + @"/" + ftp.BytesToString(totalsize);
                try
                {
                    allprg.Invoke((MethodInvoker)(() => allprg.Value += Convert.ToInt32(ftp.ListForFileSizes[i])));
                }
                catch (Exception)
                {
                    allprg.Maximum = 100;
                    allprg.Value = 100;
                }
                
                allprg.Refresh();
                alllbl.Refresh();
                lblallbytes.Refresh();
                currentper.Refresh();
            }
            filenameyalin.Clear();
            ftp.ListForFilenames.Clear();
            ftp.ListForFileSizes.Clear();
        }
        //
        public string DownloadFile(string remoteFile, string localFile, ProgressBar progressBar,Label currentpercentage,Label labelbytes)
        {
            try
            {
                /* Create an FTP Request */
                string url= host + remoteFile;
                /* Log in to the FTP Server with the User Name and Password Provided */
                NetworkCredential credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                /* Specify the Type of FTP Request */
                // Query size of the file to be downloaded
                WebRequest sizeRequest = WebRequest.Create(url);
                sizeRequest.Credentials = credentials;
                sizeRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                int size = (int)sizeRequest.GetResponse().ContentLength; // dosya boyutu bayt

                progressBar.Invoke(
                    (MethodInvoker)(() => progressBar.Maximum = size));

                // Download the file
                WebRequest request = WebRequest.Create(url);
                request.Credentials = credentials;
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                
                using (Stream ftpStream = request.GetResponse().GetResponseStream())
                using (Stream fileStream = File.Create(localFile))
                {
                    byte[] buffer = new byte[10240];
                    int read;
                    int per=0;
                    
                    while ((read = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, read);
                        int position = (int)fileStream.Position;
                        progressBar.Invoke((MethodInvoker)(() => progressBar.Value = position));
                        //currentpercentage.Invoke((MethodInvoker)(() => currentpercentage.Text = position.ToString()));
                        //currentpercentage.Text = position.ToString();
                        // https://www.dreamincode.net/forums/topic/62979-add-the-percent-into-a-progress-bar/
                        progressBar.Refresh();
                        int percent = (int)(progressBar.Value / (double)progressBar.Maximum * 100);
                        //progressBar.CreateGraphics().DrawString(
                        //    percent.ToString() + " %",
                        //    new Font("Arial", (float)8.25, FontStyle.Regular),
                        //    Brushes.Black,
                        //    new PointF(progressBar.Width / 2 - 10, progressBar.Height / 2 - 7));
                        
                        currentpercentage.Refresh();
                        labelbytes.Refresh();
                        currentpercentage.Text = percent.ToString() + " %";
                        labelbytes.Text = BytesToString( position) + "/" +  BytesToString( size);
                        per = percent;
                    }
                    
                    
                    if (per == 100)
                    {
                        return "Succesfully downloaded: " + url + " to: " + localFile;
                    }
                    else
                    {
                        return "Downloaded error: " + url + " to: " + localFile;
                    }

                    
                }
                
            }
            catch (Exception ex) {
                //MessageBox.Show(ex.ToString());
                return "Exception -> " + ex.ToString();
            }
            
        }

        //

        
       //

        public string UploadFile(string remoteFile, string localFile, ProgressBar progressBar, Label currentpercentage, Label labelbytes) // yeni yazdım
        {
            try
            {
                string url = host + ActiveDirectory + "/"+  remoteFile; // yüklerken yeniden adlandırma yapılabilir // sonra yapılacak
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
                request.Credentials = new NetworkCredential(user,pass);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                FileInfo fileInfo = new FileInfo(localFile);
                int size = (int)fileInfo.Length;
                using (Stream fileStream = File.OpenRead(localFile))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    progressBar.Invoke(  (MethodInvoker)delegate {  progressBar.Maximum = (int)fileStream.Length;  });

                    byte[] buffer = new byte[10240];
                    int read;
                    int per = 0;
                    while ((read = fileStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        ftpStream.Write(buffer, 0, read);
                        int position = (int)fileStream.Position;
                        progressBar.Invoke( (MethodInvoker)delegate { progressBar.Value = (int)fileStream.Position;});
                        progressBar.Refresh();
                        int percent = (int)(progressBar.Value / (double)progressBar.Maximum * 100);
                        //progressBar.CreateGraphics().DrawString(
                        //    percent.ToString() + " %",
                        //    new Font("Arial", (float)8.25, FontStyle.Regular),
                        //    Brushes.Black,
                        //    new PointF(progressBar.Width / 2 - 10, progressBar.Height / 2 - 7));

                        currentpercentage.Refresh();
                        labelbytes.Refresh();
                        currentpercentage.Text = percent.ToString() + " %";
                        labelbytes.Text = BytesToString(position) + "/" + BytesToString(size);
                        per = percent;
                    }
                    if (per == 100)
                    {
                        return "Succesfully uploaded: " + localFile + " to: " + url;
                    }
                    else
                    {
                        return "Upload error: " + localFile + " to: " + url;
                    }
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
                return "Exception -> " + ex.ToString();
            }

        }
        //
        //logger
        internal static void Logger(string log,TextBox textBox)
        {
            int caretPos = textBox.Text.Length;
            textBox.Text += DateTime.Now + " - " + log + Environment.NewLine;
            textBox.Text = textBox.Text.Replace(Environment.NewLine + Environment.NewLine, Environment.NewLine);


        }
        /* Upload File */
        // eski 
        //public void upload(string remoteFile, string localFile)
        //{
        //    try
        //    {
        //        /* Create an FTP Request */
        //        ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + remoteFile);
                
        //        /* Log in to the FTP Server with the User Name and Password Provided */
        //        ftpRequest.Credentials = new NetworkCredential(user, pass);
        //        /* When in doubt, use these options */
        //        ftpRequest.UseBinary = false;
        //        ftpRequest.UsePassive = true;
        //        ftpRequest.KeepAlive = false;
        //        /* Specify the Type of FTP Request */
        //        ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
        //        /* Establish Return Communication with the FTP Server */
        //        ftpStream = ftpRequest.GetRequestStream();
        //        /* Open a File Stream to Read the File for Upload */
        //        FileStream localFileStream = new FileStream(localFile, FileMode.Open);
        //        /* Buffer for the Downloaded Data */
        //        byte[] byteBuffer = new byte[bufferSize];
        //        int bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
        //        /* Upload the File by Sending the Buffered Data Until the Transfer is Complete */
        //        try
        //        {
        //            while (bytesSent != 0)
        //            {
        //                ftpStream.Write(byteBuffer, 0, bytesSent);
        //                bytesSent = localFileStream.Read(byteBuffer, 0, bufferSize);
        //            }
        //        }
        //        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        //        /* Resource Cleanup */
        //        localFileStream.Close();
        //        ftpStream.Close();
        //        ftpRequest = null;
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        //    return;
        //}

        /* Delete File */
        public string DeleteFileOrFolder(string deleteFile, bool isfile) // folderle birleştirildi
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + deleteFile);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                if (!isfile)
                {
                    ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
                }
                else
                {
                    ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                }
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpStream = ftpResponse.GetResponseStream();
                
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
                return ftpResponse.StatusDescription;

                // klasör dolu olduğunda hata veriyor. döngü kurulması lazım. #fix

            }
            catch (Exception ex) { return ex.ToString(); }
        }

        //
        


        /* Rename File */
        public string RenameFileOrFolder(string currentFileNameAndPath, string newFileName, bool isPathAndFilename)
        {
            try
            {
                /* Create an FTP Request */
                if (isPathAndFilename)
                {
                    ftpRequest = (FtpWebRequest)WebRequest.Create(host+ currentFileNameAndPath);
                }
                else
                {
                    ftpRequest = (FtpWebRequest)WebRequest.Create(host + ActiveDirectory + '/' + currentFileNameAndPath);
                }
                
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.Rename;
                /* Rename the File */
                ftpRequest.RenameTo = newFileName;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
                return ftpResponse.StatusDescription;
            }
            catch (Exception ex) { return ex.ToString(); }
        }

        /* Create a New Directory on the FTP Server */
        public string CreateDirectory(string newDirectory)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)WebRequest.Create(host + '/' + newDirectory);
                /* Log in to the FTP Server with the User Name and Password Provided */
                
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Resource Cleanup */
                ftpResponse.Close();
                ftpRequest = null;
                return ftpResponse.StatusDescription;
            }
            catch (Exception ex) {return ex.ToString();
            }
        }

        //

        public string GetFileSize(string fileName)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + '/' + fileName);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.GetFileSize;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string fileInfo = null;
                /* Read the Full Response Stream */
                try { while (ftpReader.Peek() != -1) { fileInfo = ftpReader.ReadToEnd(); } }

                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return File Size */
                return fileInfo;
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return "";
        }

        /* List Directory Contents File/Folder Name Only */
        internal static void KeyPressForNumber(KeyPressEventArgs e, TextBox textBox)
        {
            //https://stackoverflow.com/questions/17466575/negative-numbers-in-c-sharp-textbox
            Regex reg = new Regex(@"^-?\d+[.]?\d*$");
            if (char.IsControl(e.KeyChar)) return;
            if (!reg.IsMatch(textBox.Text.Insert(textBox.SelectionStart, e.KeyChar.ToString()) + "1")) e.Handled = true;
        }

        internal static void KeyUpForNumber(TextBox textBox)
        {
            textBox.MaxLength =5;
            if (textBox.Text != "" && !textBox.Text.StartsWith("-"))
            {
                if (Convert.ToInt32(textBox.Text) > 65535)
                {
                    textBox.Text = "65535";
                    // https://stackoverflow.com/questions/113224/what-is-the-largest-tcp-ip-network-port-number-allowable-for-ipv4
                    // https://serverfault.com/questions/103626/what-is-the-maximum-port-number
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
        }
        //
        //public string[] DirectoryListSimple(string directory)
        //{
        //    try
        //    {
        //        /* Create an FTP Request */
        //        ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
        //        /* Log in to the FTP Server with the User Name and Password Provided */
        //        ftpRequest.Credentials = new NetworkCredential(user, pass);
        //        /* When in doubt, use these options */
        //        ftpRequest.UseBinary = true;
        //        ftpRequest.UsePassive = true;
        //        ftpRequest.KeepAlive = true;
        //        /* Specify the Type of FTP Request */
        //        ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;
        //        /* Establish Return Communication with the FTP Server */
        //        ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
        //        /* Establish Return Communication with the FTP Server */
        //        ftpStream = ftpResponse.GetResponseStream();
        //        /* Get the FTP Server's Response Stream */
        //        StreamReader ftpReader = new StreamReader(ftpStream);
        //        /* Store the Raw Response */
        //        string directoryRaw = null;
        //        /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
        //        try { while (ftpReader.Peek() != -1) { directoryRaw += ftpReader.ReadLine() + "|"; } }
        //        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        //        /* Resource Cleanup */
        //        ftpReader.Close();
        //        ftpStream.Close();
        //        ftpResponse.Close();
        //        ftpRequest = null;
        //        /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
        //        try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
        //        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        //    /* Return an Empty string Array if an Exception Occurs */
        //    return new string[] { "" };
        //}

        /* List Directory Contents in Detail (Name, Size, Created, etc.) */
        internal string[] DetailedDirectoryList(string directory)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                string directoryRaw = null;
                /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */
                try { 
                    while (ftpReader.Peek() != -1) {
                        directoryRaw += ftpReader.ReadLine() + "|";
                    } 
                }
                catch (Exception ex) { 
                    MessageBox.Show(ex.ToString()); 
                }
                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                //
                // Clipboard.SetText(directoryRaw);
                //
                try { string[] directoryList = directoryRaw.Split("|".ToCharArray()); return directoryList; }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
            return new string[] { "" };
        }
        // ben yazdım


        internal static bool IsMiddleClick(MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Middle:
                    return true;
                default:
                    return false;
            }
        }

        //
        public void DetailedDirectoryListToListview(string directory, ListView listView, ComboBox gosterim)
        {
            try
            {
                /* Create an FTP Request */
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(host + "/" + directory);
                // gosterim.Text = "/" + directory;
                gosterim.Text = directory;
                ActiveDirectory = directory;
                /* Log in to the FTP Server with the User Name and Password Provided */
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                /* When in doubt, use these options */
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                /* Specify the Type of FTP Request */
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
                /* Establish Return Communication with the FTP Server */
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                /* Establish Return Communication with the FTP Server */
                ftpStream = ftpResponse.GetResponseStream();
                /* Get the FTP Server's Response Stream */
                StreamReader ftpReader = new StreamReader(ftpStream);
                /* Store the Raw Response */
                // ben ekledim
                listView.Items.Clear(); // önce temizle
                listView.FullRowSelect = true; // tam seçim
                //while (!ftpReader.EndOfStream)
                //{
                //    listView.Items.Add(ftpReader.ReadLine());
                //}
                // ben ekledim link temizleme
                ftp.ActiveDirectory = Regex.Replace(ftp.ActiveDirectory, @"^(\/\/)+", @"/");
                // ftp.activedirectory = Regex.Replace(ftp.activedirectory, @"\/{1}$+", ""); // sonraki / işaretini temizle
                // gereksiz
                //
                string pattern =
                    @"^([\w-]+)\s+(\d+)\s+(\w+)\s+(\w+)\s+(\d+)\s+" +
                    @"(\w+\s+\d+\s+\d+|\w+\s+\d+\s+\d+:\d+)\s+(.+)$";
                Regex regex = new Regex(pattern);
                IFormatProvider culture = CultureInfo.GetCultureInfo("en-us");
                string[] hourMinFormats =
                    new[] { "MMM dd HH:mm", "MMM dd H:mm", "MMM d HH:mm", "MMM d H:mm" };
                string[] yearFormats =
                    new[] { "MMM dd yyyy", "MMM d yyyy" };

                while (!ftpReader.EndOfStream)
                {
                    string line = ftpReader.ReadLine();
                    Match match = regex.Match(line);
                    string permissions = match.Groups[1].Value;
                    int inode = int.Parse(match.Groups[2].Value, culture);
                    string owner = match.Groups[3].Value;
                    string group = match.Groups[4].Value;
                    long size = long.Parse(match.Groups[5].Value, culture);
                    DateTime modified;
                    string s = Regex.Replace(match.Groups[6].Value, @"\s+", " ");

                    string[] formats = (s.IndexOf(':') >= 0) ? hourMinFormats : yearFormats;
                    modified = DateTime.ParseExact(s, formats, culture, DateTimeStyles.None);
                    string name = match.Groups[7].Value;
                    //string[] row = { name, permissions, size.ToString(), modified.ToString("yyyy-mm-dd hh:mm"), inode.ToString(),owner,group};
                    // added humanbytes
                    string[] row = { name, permissions, BytesToString(size), modified.ToString("yyyy-mm-dd hh:mm"), inode.ToString(), owner, group };
                    var listViewItem = new ListViewItem(row);
                    listView.Items.Add(listViewItem);
                    //Console.WriteLine(
                    //    "{0,-16} permissions = {1}  size = {2, 9}  modified = {3}",
                    //    name, permissions, size, modified.ToString("yyyy-mm-dd hh:mm")
                    //    );
                }
                /* Read Each Line of the Response and Append a Pipe to Each Line for Easy Parsing */

                /* Resource Cleanup */
                ftpReader.Close();
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;
                /* Return the Directory Listing as a string Array by Parsing 'directoryRaw' with the Delimiter you Append (I use | in This Example) */
                //
                // Clipboard.SetText(directoryRaw);
                //
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            /* Return an Empty string Array if an Exception Occurs */
        }

        //

        //
        internal static string BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0 " + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + " " + suf[place];
        }
        //
        internal static bool IsDirWithPermissions(string permregex)
        {

            string patterndir = @"^(d)";
            string patternfile = @"^(-)";
            if (Regex.IsMatch(permregex, patterndir))
            {
                return true;
            }
            else if (Regex.IsMatch(permregex, patternfile))
            {
                return false;
            }
            else
            {
                return false;
            }
        }
        //
        public struct FileStruct
        {
            public string Flags;
            public string Owner;
            public bool IsDirectory;
            public string CreateTime;
            public string Name;
        }
        //
        public FileStruct[] ListDirectory(string path)
        // https://stackoverflow.com/questions/18830900/c-sharp-populate-treeview-with-ftp-server-directories
        {
            
            if (path == null || path == "")
            {
                path = "/";
            }
            //
            //Создаем объект запроса
            ftpRequest = (FtpWebRequest)WebRequest.Create(host + path);
            //логин и пароль
            ftpRequest.Credentials = new NetworkCredential(user, pass);
            //команда фтп LIST
            ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

            //Получаем входящий поток
            ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();

            //переменная для хранения всей полученной информации
            string content = "";

            StreamReader sr = new StreamReader(ftpResponse.GetResponseStream(), System.Text.Encoding.ASCII);
            content = sr.ReadToEnd();
            sr.Close();
            ftpResponse.Close();

            DirectoryListParser parser = new DirectoryListParser(content);
            return parser.DirectoryList;
            
        }
        //
        public class DirectoryListParser
        {
            private List<FileStruct> _myListArray;

            public FileStruct[] FullListing
            {
                get
                {
                    return _myListArray.ToArray();
                }
            }

            public FileStruct[] FileList
            {
                get
                {
                    List<FileStruct> _fileList = new List<FileStruct>();
                    foreach (FileStruct thisstruct in _myListArray)
                    {
                        if (!thisstruct.IsDirectory)
                        {
                            _fileList.Add(thisstruct);
                        }
                    }
                    return _fileList.ToArray();
                }
            }

            public FileStruct[] DirectoryList
            {
                get
                {
                    List<FileStruct> _dirList = new List<FileStruct>();
                    foreach (FileStruct thisstruct in _myListArray)
                    {
                        if (thisstruct.IsDirectory)
                        {
                            _dirList.Add(thisstruct);
                        }
                    }
                    return _dirList.ToArray();
                }
            }

            public DirectoryListParser(string responseString)
            {
                _myListArray = GetList(responseString);
            }
            //
            public enum FileListStyle
            {
                UnixStyle,
                WindowsStyle,
                Unknown
            }
            //
            private List<FileStruct> GetList(string datastring)
            {
                List<FileStruct> myListArray = new List<FileStruct>();
                string[] dataRecords = datastring.Split('\n');
                //Получаем стиль записей на сервере
                FileListStyle _directoryListStyle = GuessFileListStyle(dataRecords);
                foreach (string s in dataRecords)
                {
                    if (_directoryListStyle != FileListStyle.Unknown && s != "")
                    {
                        FileStruct f = new FileStruct();
                        f.Name = "..";
                        switch (_directoryListStyle)
                        {
                            case FileListStyle.UnixStyle:
                                f = ParseFileStructFromUnixStyleRecord(s);
                                break;

                            case FileListStyle.WindowsStyle:
                                f = ParseFileStructFromWindowsStyleRecord(s);
                                break;
                        }
                        if (f.Name != "" && f.Name != "." && f.Name != "..")
                        {
                            myListArray.Add(f);
                        }
                    }
                }
                return myListArray;
            }

            //Парсинг, если фтп сервера работает на Windows
            private FileStruct ParseFileStructFromWindowsStyleRecord(string Record)
            {
                //Предположим стиль записи 02-03-04  07:46PM       <DIR>     Append
                FileStruct f = new FileStruct();
                string processstr = Record.Trim();
                //Получаем дату
                string dateStr = processstr.Substring(0, 8);
                processstr = (processstr.Substring(8, processstr.Length - 8)).Trim();
                //Получаем время
                string timeStr = processstr.Substring(0, 7);
                processstr = (processstr.Substring(7, processstr.Length - 7)).Trim();
                f.CreateTime = dateStr + " " + timeStr;
                //Это папка или нет
                if (processstr.Substring(0, 5) == "<DIR>")
                {
                    f.IsDirectory = true;
                    processstr = (processstr.Substring(5, processstr.Length - 5)).Trim();
                }
                else
                {
                    string[] strs = processstr.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    processstr = strs[1];
                    f.IsDirectory = false;
                }
                //Остальное содержмое строки представляет имя каталога/файла
                f.Name = processstr;
                return f;
            }

            //Получаем на какой ОС работает фтп-сервер - от этого будет зависеть дальнейший парсинг
            public FileListStyle GuessFileListStyle(string[] recordList)
            {
                foreach (string s in recordList)
                {
                    //Если соблюдено условие, то используется стиль Unix
                    if (s.Length > 10
                        && Regex.IsMatch(s.Substring(0, 10), "(-|d)((-|r)(-|w)(-|x)){3}"))
                    {
                        return FileListStyle.UnixStyle;
                    }
                    //Иначе стиль Windows
                    else if (s.Length > 8
                        && Regex.IsMatch(s.Substring(0, 8), "[0-9]{2}-[0-9]{2}-[0-9]{2}"))
                    {
                        return FileListStyle.WindowsStyle;
                    }
                }
                return FileListStyle.Unknown;
            }

            //Если сервер работает на nix-ах
            private FileStruct ParseFileStructFromUnixStyleRecord(string record)
            {
                //Предположим. тчо запись имеет формат dr-xr-xr-x   1 owner    group    0 Nov 25  2002 bussys
                FileStruct f = new FileStruct();
                if (record[0] == '-' || record[0] == 'd')
                {// правильная запись файла
                    string processstr = record.Trim();
                    f.Flags = processstr.Substring(0, 9);
                    f.IsDirectory = (f.Flags[0] == 'd');
                    processstr = (processstr.Substring(11)).Trim();
                    //отсекаем часть строки
                    _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
                    f.Owner = _cutSubstringFromStringWithTrim(ref processstr, ' ', 0);
                    f.CreateTime = getCreateTimeString(record);
                    //Индекс начала имени файла
                    int fileNameIndex = record.IndexOf(f.CreateTime) + f.CreateTime.Length;
                    //Само имя файла
                    f.Name = record.Substring(fileNameIndex).Trim();
                }
                else
                {
                    f.Name = "";
                }
                return f;
            }

            private string getCreateTimeString(string record)
            {
                //Получаем время
                string month = "(jan|feb|mar|apr|may|jun|jul|aug|sep|oct|nov|dec)";
                string space = @"(\040)+";
                string day = "([0-9]|[1-3][0-9])";
                string year = "[1-2][0-9]{3}";
                string time = "[0-9]{1,2}:[0-9]{2}";
                Regex dateTimeRegex = new Regex(month + space + day + space + "(" + year + "|" + time + ")", RegexOptions.IgnoreCase);
                Match match = dateTimeRegex.Match(record);
                return match.Value;
            }

            private string _cutSubstringFromStringWithTrim(ref string s, char c, int startIndex)
            {
                int pos1 = s.IndexOf(c, startIndex);
                string retString = s.Substring(0, pos1);
                s = (s.Substring(pos1)).Trim();
                return retString;
            }
        }
        //
        internal static string RegistryValueExists() // düzenlendi.
                                                     // https://stackoverflow.com/questions/18232972/how-to-read-value-of-a-registry-key-c-sharp
                                                     // https://stackoverflow.com/questions/4276138/how-to-check-if-a-registry-value-exists-using-c 
        {
            try
            {
                using (Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey
                (@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true))
                {
                    if (key != null)
                    {
                        Object o = key.GetValue("MicroSharpFTP");
                        if (o != null)
                        {
                            if (o.ToString() == Application.ExecutablePath)
                            {
                                return "true";
                            }
                            else
                            {
                                return "diff";
                            }
                        }
                        else
                        {
                            return "false";
                        }
                    }
                    else
                    {
                        return "false";
                    }
                }
            }
            catch (Exception ex)  //just for demonstration...it's always best to handle specific exceptions
            {
                //react appropriately
                MessageBox.Show(ex.ToString());
                return "false";
            }
        }
        //
        internal static string slashfix(string slashed)
        {

            return Regex.Replace(slashed, @"^(\/\/)+", @"/");
        }
    }
}
