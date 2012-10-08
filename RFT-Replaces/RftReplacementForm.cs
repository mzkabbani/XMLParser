using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FtpLib;
using System.Diagnostics;
using System.Security.AccessControl;
using System.Threading;
using System.Text.RegularExpressions;
using AlexPilotti.FTPS.Client;
using System.Net;
using System.Net.Security;


namespace XmlParsersAndUi {
    public partial class RftReplacementForm : Form {

        String ScriptName = string.Empty;
       // string downloadDir = Path.GetTempPath() + @"\"+DateTime.Now.Minute+DateTime.Now.Millisecond+@"Downloads\";
        string downloadDir = Path.GetTempPath() + @"\Downloads\";
        public RftReplacementForm() {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, EventArgs e) {
            try {
                if (IsValidToReplace(txtRemoteDest.Text, txtDest.Text)) {
                    ReplaceFiles(txtRemoteDest.Text, txtDest.Text);
                    
                }

            } catch (Exception ex) {
                
                MessageBox.Show(ex.Message);
            }
        }


        public void GetFilesWithFTPNewMode(string host, string remoteLocation) {
            FTPSClient client = new FTPSClient();
            try {
                client.Connect(host,ESSLSupportMode.All);
                try {
                    client.SetCurrentDirectory(remoteLocation);
                    ScriptName = client.GetCurrentDirectory();
                    string localDownloadDirectory = downloadDir + ScriptName;

                    client.GetFiles(localDownloadDirectory, "*.log", EPatternStyle.Wildcard, false);

                } catch (Exception ex) {

                }
            } finally {                
                client.Close();
                client.Dispose();
            }
        }

        private void ReplaceFiles(string sourceDir, string destinationDir) {
            //QAService_MarkingTable2act.rftvp
            string[] sourceFilesNames = Directory.GetFiles(sourceDir, "*act.rftvp");
            List<string> notReplacedFiles = new List<string>();
            string fileText = string.Empty;
            for (int i = 0; i < sourceFilesNames.Length; i++) {
                FileInfo fileInfo = new FileInfo(sourceFilesNames[i]);
                StreamReader reader = new StreamReader(fileInfo.FullName);
                try {
                    fileText = reader.ReadToEnd();
                } finally {
                    if (reader != null) {
                        
                        reader.Close();
                        reader.Dispose();
                    }
                }

                string sourceFileName = fileInfo.Name;

                string destinationFileName = SearchAndReplace(sourceFileName, destinationDir);

                if (!string.IsNullOrEmpty(destinationFileName)) {
                    // to check if file has regex
                    StreamReader destinationFileReader = new StreamReader(destinationFileName);
                    string destinationFileText = string.Empty;
                    try {
                        destinationFileText = destinationFileReader.ReadToEnd();
                    } finally {
                        
                        destinationFileReader.Close();
                        destinationFileReader.Dispose();
                    }

                    if (!destinationFileText.Contains("RegExp")) {

                        StreamWriter writer = new StreamWriter(destinationFileName);
                        try {
                            writer.Write(fileText);
                        } finally {
                            if(writer !=null){
                                writer.Flush();
                                writer.Close();
                                writer.Dispose();
                            }
                            
                        }
                        txtLogText.Text = txtLogText.Text + "\r\nReplaced: " + destinationFileName;
                    } else {
                        notReplacedFiles.Add(destinationFileName);
                    }
                }
            }

            if (notReplacedFiles.Count > 0) {
                txtLogText.Text = txtLogText.Text + "\r\nFiles Containing REGEX:";
                for (int j = 0; j < notReplacedFiles.Count; j++) {
                    txtLogText.Text = txtLogText.Text + "\r\n" + notReplacedFiles[j];
                }
            }
        }

        private void GetFilesByFtp(string host, string remoteLocation) {
            List<string> remoteFiles = new List<string>();
            string localDownloadDirectory = string.Empty;
            FtpConnection connection = new FtpConnection(host, "mxftp", "mxftp");
            try {
                try {
                    connection.Open();
                } catch (Exception ex) {
                    MessageBox.Show(ex.Message);
                }

                connection.Login();
                connection.SetCurrentDirectory(remoteLocation);
                FtpFileInfo[] ftpFileInfo = connection.GetFiles("*act.rftvp");
                ScriptName = connection.GetCurrentDirectoryInfo().Name;

                localDownloadDirectory = downloadDir + ScriptName;
                 //if(Directory.Exists(localDownloadDirectory)){
              //       Directory.Delete(localDownloadDirectory,true);
             //     }
                DirectoryInfo downloadDirectoryInfo = Directory.CreateDirectory(localDownloadDirectory);
                connection.SetLocalDirectory(downloadDirectoryInfo.FullName);
                for (int i = 0; i < ftpFileInfo.Length; i++) {
                    connection.GetFile(ftpFileInfo[i].Name, false);
                }
            } finally {
                connection.SetLocalDirectory(Path.GetTempPath());
                connection.Close();
                connection.Dispose();
                
            }
            ReplaceFiles(localDownloadDirectory, txtDest.Text);


            //deleting local files
            //Directory.Delete(localDownloadDirectory);
        }

        private string SearchAndReplace(string sourceFileName, string destinationDir) {
            string destFileName = string.Empty;
            //QAService_MarkingTable2act.rftvp | QAServices.QAService_MarkingTable2.base.rftvp
            //source                           | destination
            string[] destinationFilesNames = Directory.GetFiles(destinationDir, "*.base.rftvp");
            for (int i = 0; i < destinationFilesNames.Length; i++) {
                FileInfo destFileInfo = new FileInfo(destinationFilesNames[i]);
                if (string.Equals(destFileInfo.Name.Split('.')[0], ScriptName) && string.Equals(destFileInfo.Name.Split('.')[1], sourceFileName.Split('.')[0].Substring(0, sourceFileName.Split('.')[0].Length - 3))) {
                    return destinationFilesNames[i];
                }

            }

            return destFileName;
        }

        private bool IsValidToReplace(string source, string destination) {

            if (string.Equals(source, destination)) {
                MessageBox.Show("Source and destination are the same!");
                return false;
            }
            if (!Directory.Exists(source)) {
                MessageBox.Show("Source directory does not exist");
                return false;
            }
            if (!Directory.Exists(destination)) {
                MessageBox.Show("Destination directory does not exist");
                return false;
            }


            return true;
        }

        private void btnReset_Click(object sender, EventArgs e) {
            try {
                txtDest.Text = "";
                txtRemoteDest.Text = "";

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e) {
            txtLogText.Text = string.Empty;
        }

        //private void btnBrowseSrc_Click(object sender, EventArgs e) {
        //    FolderBrowserDialog dialog = new FolderBrowserDialog();
        //    DialogResult result =  dialog.ShowDialog();
        //    if(result == DialogResult.OK){
        //        txtSource.Text = dialog.SelectedPath;
        //    }

        //}

        private void btnBrowseDes_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                txtDest.Text = dialog.SelectedPath;
            }
        }
        bool canOpen = false;
        private void btnFtp_Click(object sender, EventArgs e) {
            try {
                //Directory.CreateDirectory(downloadDir);
               // downloadDir = Path.GetTempPath() + @"\" + DateTime.Now.Minute + DateTime.Now.Millisecond + @"Downloads\";
                if(Directory.Exists(downloadDir)){
                    Directory.Delete(downloadDir, true);
                }
                
                GetFilesByFtp(txtServer.Text, txtRemoteDest.Text);
                canOpen = true;
                MessageBox.Show("Screen update completed!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

           
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                if (canOpen) {
                    Process.Start(downloadDir);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            
                if (!Directory.Exists(downloadDir)) {
                    Directory.CreateDirectory(downloadDir);
                }
            
        }

        private void txtRemoteDest_TextChanged(object sender, EventArgs e) {
            try {
                string remoteLocation = txtRemoteDest.Text;
                if(string.IsNullOrEmpty(remoteLocation)){
                    return;
                }
                string[] splitter = new string[]{@"/"};
                string[] remoteLocationSplit  = remoteLocation.Split(splitter,StringSplitOptions.RemoveEmptyEntries);
                remoteLocation = Regex.Match(remoteLocationSplit[0], @"[a-zA-Z]+[0-9]+[a-zA-Z]+|[a-zA-Z]+", RegexOptions.Compiled).Value;
                txtServer.Text = remoteLocation;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) {
            GetFilesWithFTPNewMode(txtServer.Text, txtRemoteDest.Text);
        }
    }
}
