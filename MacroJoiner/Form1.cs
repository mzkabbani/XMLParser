using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace MacroJoiner {
    public partial class Form1 : Form {

        public Form1() {
            InitializeComponent();
        }
        //new version of template unchanged

        private void btnStart_Click(object sender, EventArgs e) {
            try {
                string allFilesText = "<MXClientScript><Events>";
                string[] applicableFiles = Directory.GetFiles(txtInputDir.Text, "eventsfiles.xml",SearchOption.AllDirectories);
                for (int i = 0; i < applicableFiles.Length; i++) {

                    if (!applicableFiles[i].Contains("__")) {
                        List<string> joinedFilesBySession = JoinRespectiveEvents(applicableFiles[i]);
                        if (!chkAllOneFile.Checked) {
                        Directory.CreateDirectory(txtOutputDir.Text + "/macro" + i);                        
                            for (int j = 0; j < joinedFilesBySession.Count; j++) {
                                string ouputdirBySession = txtOutputDir.Text + "/macro" + i + "/session" + j;
                                Directory.CreateDirectory(ouputdirBySession);
                                WriteFile(ouputdirBySession + "/macro.xml", joinedFilesBySession[j]);
                            }
                        } else {
                            for (int j = 0; j < joinedFilesBySession.Count; j++) {
                                string ouputdirBySession = txtOutputDir.Text;
                                Directory.CreateDirectory(ouputdirBySession);
                                allFilesText = allFilesText +
                                    joinedFilesBySession[j].Replace("<MXClientScript>", "").Replace("<Events>", "").Replace("</MXClientScript>", "").Replace("</Events>", "");
                                          }
                        }

                    } 
                }
                if (chkAllOneFile.Checked) {
                    WriteFile(txtOutputDir.Text + "/macro.xml", allFilesText + "</Events></MXClientScript>");
                    
                }   
                MessageBox.Show("DONE!");
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void WriteFile(string path, string text) {
            StreamWriter writer = new StreamWriter(path);
            try {
                writer.Write(text);
            } finally {
                if (writer != null) {
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }
            }

        }

        private List<string> JoinRespectiveEvents(string eventsFilePath) {
            string joinedFile = string.Empty;

            StreamReader reader = new StreamReader(eventsFilePath);
            string eventsFileText = string.Empty;
            try {
                eventsFileText = reader.ReadToEnd();
            } finally {

            }

            XElement element = XElement.Parse(eventsFileText);
            IEnumerable<XElement> stepElements = element.DescendantsAndSelf("Step");


            //  List<string> stepEventPath = new List<string>();
            Dictionary<string, string> sessionKeyAndStepEvent = new Dictionary<string, string>();
            string globalSessionKey = "genericSession";

            for (int i = 0; i < stepElements.Count(); i++) {

                if (stepElements.ElementAt(i).Attributes("events") != null) {
                    //stepEventPath.Add(stepElements.ElementAt(i).Attributes("events").ElementAt(0).Value);
                    if (stepElements.ElementAt(i).Attributes("sessionKey").Count() == 0) {
                        sessionKeyAndStepEvent.Add(stepElements.ElementAt(i).Attributes("events").ElementAt(0).Value, globalSessionKey);
                    } else {
                        sessionKeyAndStepEvent.Add(stepElements.ElementAt(i).Attributes("events").ElementAt(0).Value, stepElements.ElementAt(i).Attributes("sessionKey").ElementAt(0).Value);
                    }
                }
            }


            Dictionary<string, List<string>> sessionKeyAndRespectiveFiles = new Dictionary<string, List<string>>();
            for (int i = 0; i < sessionKeyAndStepEvent.Count; i++) {
                if (!sessionKeyAndRespectiveFiles.ContainsKey(sessionKeyAndStepEvent.ElementAt(i).Value)) {
                    sessionKeyAndRespectiveFiles.Add(sessionKeyAndStepEvent.ElementAt(i).Value, new List<string>());
                    sessionKeyAndRespectiveFiles[sessionKeyAndStepEvent.ElementAt(i).Value].Add(sessionKeyAndStepEvent.ElementAt(i).Key);
                } else {
                    sessionKeyAndRespectiveFiles[sessionKeyAndStepEvent.ElementAt(i).Value].Add(sessionKeyAndStepEvent.ElementAt(i).Key);
                }
            }

            List<string> joinedFiles = new List<string>();
            for (int i = 0; i < sessionKeyAndRespectiveFiles.Count; i++) {
                string joinedFileBySessionKey = string.Empty;
                for (int j = 0; j < sessionKeyAndRespectiveFiles.ElementAt(i).Value.Count; j++) {
                    string fileName = sessionKeyAndRespectiveFiles.ElementAt(i).Value[j];
                    //filename may be  step2_events.xml or 1.2.3.4.5step2_events.xml
                    string[] fileNameSplit = fileName.Split('.');

                    fileName = fileNameSplit[fileNameSplit.Length - 2] + "." + fileNameSplit[fileNameSplit.Length - 1];

                    string parentDirectoryOfEventFile = Directory.GetParent(eventsFilePath).FullName;

                    string readstepEvents = ReadFile(parentDirectoryOfEventFile + "/" + fileName);
                    if (j == 0) {
                        joinedFileBySessionKey = readstepEvents;
                    } else {
                        string cleanedStepEvents = readstepEvents.Replace("<Events>", "").Replace("<MXClientScript>", "");
                        joinedFileBySessionKey = joinedFileBySessionKey.Replace("<Events/>", "<Events></Events>");
                        joinedFileBySessionKey = joinedFileBySessionKey.Replace("<Events />", "<Events></Events>");
                        joinedFileBySessionKey = joinedFileBySessionKey.Replace("</Events>", "").Replace("</MXClientScript>", "") + cleanedStepEvents;
                    }
                }
                joinedFiles.Add(joinedFileBySessionKey);
            }

            return joinedFiles;
        }

        public string ReadFile(string filePath) {
            string readText = string.Empty;
            StreamReader reader = new StreamReader(filePath);
            try {
                readText = reader.ReadToEnd();
            } finally {
                reader.Close();
            }

            Regex regex = new Regex("<\\?.*\\?>");
            readText = regex.Replace(readText, "");

            return readText;
        }

        private void btnBrowseInDir_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtInputDir.Text = dialog.SelectedPath;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnBrowseOutDir_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtOutputDir.Text = dialog.SelectedPath;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            txtOutputDir.Clear();
            txtInputDir.Clear();
        }

        private void btnShowOutput_Click(object sender, EventArgs e) {
            try {
                if (Directory.Exists(txtOutputDir.Text)) {
                    Process.Start(txtOutputDir.Text);
                } else {
                    MessageBox.Show("The output directory does not exist");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
