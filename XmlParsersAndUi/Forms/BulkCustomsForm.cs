using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;
using Utilities.WinForms;
using XmlParsersAndUi.Classes;
using Automation.Common.Utils;
using Automation.Common.Classes.Monitoring;

namespace XmlParsersAndUi {
    public partial class BulkCustomsForm : Form {

        public BulkCustomsForm() {
            InitializeComponent();
        }

        #region Methods

        private void UpdateEventsFilesStepsToFastMode(List<string> goodFiles) {
            List<string> untouchedEventsFiles = new List<string>();
            for (int i = 0; i < goodFiles.Count; i++) {
                StreamReader reader = new StreamReader(Directory.GetParent(goodFiles[i]) + @"\eventsfiles.xml");
                string fileText = string.Empty;
                try {
                    fileText = reader.ReadToEnd();
                } finally {
                    reader.Close();
                }
                try {
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(fileText);
                    XmlNodeList stepNodes = doc.GetElementsByTagName("Step");
                    for (int j = 0; j < stepNodes.Count; j++) {
                        if (stepNodes[j].Attributes["customs"] != null) {
                            if (stepNodes[j].Attributes["customs"].Value.Contains(Path.GetFileName(Path.GetFileName(goodFiles[i])))) {
                                if (stepNodes[j].Attributes["fast"] == null && stepNodes[j].Attributes["Fast"] == null && chkConvertFast.Checked) {
                                    XmlAttribute attribute = stepNodes[j].OwnerDocument.CreateAttribute("Fast");
                                    attribute.Value = "Y";
                                    stepNodes[j].Attributes.Append(attribute);
                                    if (!untouchedEventsFiles.Contains(Directory.GetParent(goodFiles[i]) + @"\eventsfiles.xml")) {
                                        untouchedEventsFiles.Add(Directory.GetParent(goodFiles[i]) + @"\eventsfiles.xml");
                                    }
                                    untouchedEventsFiles.Add(goodFiles[i]);
                                }
                            }
                        }
                    }
                    StreamWriter writer = new StreamWriter(Directory.GetParent(goodFiles[i]) + @"\eventsfiles.xml", false);
                    try {
                        writer.Write(doc.InnerXml);
                    } finally {
                        writer.Close();
                    }
                } catch (Exception ex) {
                    FrontendUtils.ShowError("The eventsfile is not a valid xml document and will be skipped.\r\n [" + Directory.GetParent(goodFiles[i]) + @"\eventsfiles.xml] " + ex.Message, ex);
                }
            }
            string finalResult = string.Join("\r\n", untouchedEventsFiles.ToArray());
            FrontendUtils.LogError(finalResult, null);
        }

        private static void AddPatternToCustoms(List<string> goodFiles, string customToAdd) {
            HashSet<string> Hs = new HashSet<string>();
            for (int i = 0; i < goodFiles.Count; i++) {
                try {
                    if (File.Exists(goodFiles[i])) {
                        StreamReader reader = new StreamReader(goodFiles[i]);
                        string fileText = string.Empty;
                        try {
                            fileText = reader.ReadToEnd();
                        } finally {
                            if (reader != null) {
                                reader.Close();
                                reader.Dispose();
                            }
                        }
                        fileText = fileText.Replace("<Customs>", "<Customs>" + customToAdd);
                        //write new customs file
                        StreamWriter writer = new StreamWriter(goodFiles[i], false);
                        try {
                            writer.Write(fileText);
                        } finally {
                            if (writer != null) {
                                writer.Flush();
                                writer.Close();
                                writer.Dispose();
                            }
                        }
                    } else { 
                        // log error 
                        FrontendUtils.LogError("File does not exist " + goodFiles[i], new FileNotFoundException());
                    }
                } catch (Exception ex) {
                    FrontendUtils.ShowError(ex.Message, ex);
                }
            }
        }

        private List<string> GetApplicableCustomFiles(string[] applicativeFiles) {
            List<string> goodFiles = new List<string>();
            Regex regex = new Regex(txtFocusCode.Text);
            for (int i = 0; i < applicativeFiles.Length; i++) {
                StreamReader reader = new StreamReader(applicativeFiles[i]);
                string readText = string.Empty;
                try {
                    readText = reader.ReadToEnd();
                } finally {
                    reader.Close();
                }
                if (regex.IsMatch(readText)) {
                    string fileName = Path.GetFileNameWithoutExtension(applicativeFiles[i]).Substring(0, Path.GetFileNameWithoutExtension(applicativeFiles[i]).IndexOf('_'));
                    //filename is like step3 now
                    if (!goodFiles.Contains(Directory.GetParent(applicativeFiles[i]) + @"\" + fileName + "_customs.xml")) {
                        goodFiles.Add(Directory.GetParent(applicativeFiles[i]) + @"\" + fileName + "_customs.xml");
                    }
                }
            }
            return goodFiles;
        }

        private bool IsValidToStart(string inputDir, string focusCode, string custom) {
            if (string.IsNullOrEmpty(inputDir)) {
                FrontendUtils.ShowError("Please supply an input directory", null);
                return false;
            }
            if (!Directory.Exists(inputDir)) {
                FrontendUtils.ShowError("The input directory does not exist", null);
                return false;
            }
            if (string.IsNullOrEmpty(focusCode)) {
                FrontendUtils.ShowError("Please supply a focus code", null);
                return false;
            }
            if (string.IsNullOrEmpty(custom)) {
                FrontendUtils.ShowError("Please supply a custom path", null);
                return false;
            }
            return true;
        }

        #endregion

        #region Events

        private void btnStart_Click(object sender, EventArgs e) {
            try {
                if (IsValidToStart(txtInputDir.Text, txtFocusCode.Text, txtCustom.Text)) {
                    MainForm.appProcessing = true;
                    string[] applicativeFiles = Directory.GetFiles(txtInputDir.Text, "*gui.xml", SearchOption.AllDirectories);
                    List<string> goodFiles = GetApplicableCustomFiles(applicativeFiles);
                    //add to customs now
                    string customToAdd = txtCustom.Text;
                    AddPatternToCustoms(goodFiles, customToAdd);
                    //handle events files now
                    UpdateEventsFilesStepsToFastMode(goodFiles);
                    MainForm.appProcessing = false;
                    FrontendUtils.ShowInformation("Bulk customs completed, parsed [" + goodFiles.Count + "] applicable custom files.",false);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtInputDir.Text = dialog.SelectedPath;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            try {
                txtInputDir.Text = string.Empty;
                txtFocusCode.Text = string.Empty;
                txtCustom.Text = string.Empty;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void chkConvertFast_CheckedChanged(object sender, EventArgs e) {
            try {
                if (chkConvertFast.Checked) {
                    if ((FrontendUtils.ShowConformation("Enabling this option may induce new " +
                                "differences due to the comparison mode change." +
                                "\nAre you sure you want to proceed?")) == DialogResult.Yes) {
                        chkConvertFast.Checked = true;
                    } else {
                        chkConvertFast.Checked = false;
                    }
                }

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void BulkCustomsForm_Load(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(MonitorObject.username)) {
                MonitorObject.formAndAccessTime.Add(new FormAndAccessTime(this.Name, DateTime.Now));
            }
        }

        #endregion

    }
}
