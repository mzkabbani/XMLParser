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
using System.Text.RegularExpressions;
using Automation.Common.Utils;
using Automation.Common.Classes.Monitoring;

namespace XmlParsersAndUi.Forms {

    public partial class FTPDownloaderForm : Form {

        public FTPDownloaderForm() {
            InitializeComponent();
        }

        private void btnBrowseFileList_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtInputFileList.Text = dialog.FileName;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnBrowseOutputFolder_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtOutputFolder.Text = dialog.SelectedPath;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnStartDownload_Click(object sender, EventArgs e) {
            try {
                btnStartDownload.Enabled = false;
                List<string> fileList = ParseInputFileList(txtInputFileList.Text.Trim());
                DownloadFileList(fileList, txtHost.Text, txtRemoteLocation.Text, txtOutputFolder.Text);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
            btnStartDownload.Enabled = true;
        }

        private void DownloadFileList(List<string> fileList, string remoteHost, string remoteLocation, string localLocation) {
            FtpConnection connection = new FtpConnection(remoteHost, "mxftp", "mxftp");
            string localFileName = Path.GetTempFileName();
            string currentProcessedFile = string.Empty;
            try {
                try {
                    try {
                        connection.Open();
                    } catch (Exception ex) {
                        FrontendUtils.ShowError(ex.Message, ex);
                    }
                    connection.Login();
                    connection.SetCurrentDirectory(remoteLocation);
                    //Path.GetTempFileName
                    connection.SetLocalDirectory(localLocation);
                    for (int i = 0; i < fileList.Count; i++) {
                        currentProcessedFile = fileList[i];
                        string localDownloadPath = string.Empty;
                        if (fileList[i].StartsWith("/")) {
                            localDownloadPath = Path.GetDirectoryName(localLocation + fileList[i]);
                        } else {
                            localDownloadPath = Path.GetDirectoryName(localLocation + "/" + fileList[i]);
                        }
                        if (!Directory.Exists(localDownloadPath)) {
                            Directory.CreateDirectory(localDownloadPath);
                        }
                        connection.GetFile(fileList[i], false);
                    }
                } finally {
                    connection.Close();
                    connection.Dispose();
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError("Stopped @"+currentProcessedFile+"!\n"+ex.Message, ex);
            }
        }

        private List<string> ParseInputFileList(string fileName) {
            List<string> fileList = new List<string>();
            StreamReader reader = new StreamReader(fileName);
            try {
                string line = string.Empty;
                while ((line = reader.ReadLine()) != null) {
                    fileList.Add(line);
                }
            } finally {
                if (reader != null) {
                    reader.Close();
                    reader.Dispose();
                }
            }
            return fileList;
        }

        private void btnResetForm_Click(object sender, EventArgs e) {
            try {
                ResetFormText(groupBox1.Controls);
                ResetFormText(groupBox2.Controls);
            } catch (Exception ex) {

                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void ResetFormText(Control.ControlCollection controlCollection) {
            foreach (Control control in controlCollection) {
                 if(control is TextBox){
                     ((TextBox)control).Clear();
                 }
            }
        }

        private void txtRemoteLocation_TextChanged(object sender, EventArgs e) {
            try {
                string remoteLocation = txtRemoteLocation.Text.Trim();
                if (string.IsNullOrEmpty(remoteLocation)) {
                    return;
                }
                string[] splitter = new string[] { @"/" };
                string[] remoteLocationSplit = remoteLocation.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                remoteLocation = Regex.Match(remoteLocationSplit[0], @"[a-zA-Z]+[0-9]+[a-zA-Z]+|[a-zA-Z]+", RegexOptions.Compiled).Value;
                txtHost.Text = remoteLocation;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void FTPDownloaderForm_Load(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(MonitorObject.username)) {
                    MonitorObject.formAndAccessTime.Add(new FormAndAccessTime(this.Name, DateTime.Now));
                }
            } catch (Exception) {
                
            }
        }
    }
}
