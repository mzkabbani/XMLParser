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
using System.Xml;
using System.Data.SqlClient;
using System.Data.Odbc;

namespace CustomsRefactoring {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        List<string> customFiles = new List<string>();
        private void Form1_Load(object sender, EventArgs e) {
            try {
                cmbRefactorType.SelectedItem = cmbRefactorType.Items[0];
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
                
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK) {
                txtInputDir.Text = dialog.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e) {
            try {
                // get all valid custom files with additionalTolerance and linux
                //customFiles = ParseCustomFiles(txtInputDir.Text);
                //SplitCustomFiles(customFiles);

                string[] applicativeFiles = Directory.GetFiles(txtInputDir.Text, "*gui.xml", SearchOption.AllDirectories);
                List<string> goodFiles = new List<string>();
                for (int i = 0; i < applicativeFiles.Length; i++) {
                    StreamReader reader = new StreamReader(applicativeFiles[i]);
                    string readText = string.Empty;
                    try {
                        readText = reader.ReadToEnd();
                    } finally {
                        reader.Close();

                    }

                    if (readText.Contains("_ebx_textarea___Summary___0")) {
                        string fileName = Path.GetFileNameWithoutExtension(applicativeFiles[i]).Substring(0, Path.GetFileNameWithoutExtension(applicativeFiles[i]).IndexOf('_'));
                        //filename is like step3 now

                        goodFiles.Add(Directory.GetParent(applicativeFiles[i]) + @"\" + fileName + "_customs.xml");
                    }

                }


                //add to customs now
                for (int i = 0; i < goodFiles.Count; i++) {
                    StreamReader reader = new StreamReader(goodFiles[i]);
                    string fileText = string.Empty;
                    try {
                        fileText = reader.ReadToEnd();
                    } finally {
                        reader.Close();
                    }

                    fileText = fileText.Replace("<Customs>", "<Customs><Path>//Component[@Code='_ebx_textarea___Summary___0']//Cell/text()</Path>");

                    //write new customs file

                    StreamWriter writer = new StreamWriter(goodFiles[i], false);
                    try {
                        writer.Write(fileText);

                    } finally {
                        writer.Close();
                    }

                }

                //handle events files now
                for (int i = 0; i < goodFiles.Count; i++) {
                    StreamReader reader = new StreamReader(Directory.GetParent(goodFiles[i]) + @"\eventsfiles.xml");
                    string fileText = string.Empty;
                    try {
                        fileText = reader.ReadToEnd();
                    } finally {
                        reader.Close();
                    }
                    fileText = fileText.Replace(Path.GetFileName(goodFiles[i]) + "\"", Path.GetFileName(goodFiles[i]) + "\"" + " Fast=\"Y\"");

                    StreamWriter writer = new StreamWriter(Directory.GetParent(goodFiles[i]) + @"\eventsfiles.xml", false);
                    try {
                        writer.Write(fileText);

                    } finally {
                        writer.Close();
                    }


                }




            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void SplitCustomFiles(List<string> customFiles) {

            Dictionary<string, string> customFilesWithText = new Dictionary<string, string>();
            for (int i = 0; i < customFiles.Count; i++) {
                StreamReader reader = new StreamReader(customFiles[i]);
                try {
                    customFilesWithText.Add(customFiles[i], reader.ReadToEnd());
                } finally {
                    if (reader != null) {
                        reader.Close();
                        reader.Dispose();
                    }
                }
                LogOperation(i + "-Loaded File: " + customFiles[i]);
            }

            for (int i = 0; i < customFilesWithText.Count(); i++) {
                LogOperation(i + "-Operating on File: " + customFiles[i]);
                XDocument xmlDocument = XDocument.Parse(customFilesWithText[customFiles[i]]);
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(customFilesWithText[customFiles[i]]);

                XmlNodeList pathNodes = xDoc.DocumentElement.ChildNodes;
                List<CustomFilePaths> allCustomFilePath = new List<CustomFilePaths>();

                List<string> keyNames = new List<string>();
                List<string> keyValues = new List<string>();
                string customFileNameNewKeyValue = string.Empty;
                string customFileNameNewKeyName = string.Empty;
                for (int j = 0; j < pathNodes.Count; j++) {
                    CustomFilePaths customFilePaths = new CustomFilePaths();
                    if (pathNodes[j].Attributes["Tolerance"] != null && pathNodes[j].NodeType != XmlNodeType.Comment) {

                        // have the tolerances for normal and additional

                        customFilePaths.innitialTolerance = pathNodes[j].Attributes["Tolerance"].Value;
                        customFilePaths.xPath = pathNodes[j].InnerText;
                        customFilePaths.isAdditionalTolerance = false;
                        if (pathNodes[j].ChildNodes.Count > 1) {
                            customFilePaths.additionalTolerance = pathNodes[j].ChildNodes[1].ChildNodes[0].Attributes["additionalTolerance"].Value;
                            customFilePaths.keyName = pathNodes[j].ChildNodes[1].ChildNodes[0].Attributes["keyName"].Value;
                            customFilePaths.keyValue = pathNodes[j].ChildNodes[1].ChildNodes[0].Attributes["keyValue"].Value;
                            customFilePaths.isAdditionalTolerance = true;
                            if (customFileNameNewKeyName != customFilePaths.keyName) {
                                keyNames.Add(customFilePaths.keyName);
                                keyValues.Add(customFilePaths.keyValue);
                                customFileNameNewKeyName = customFilePaths.keyName;
                            }
                        }
                    } else if (string.Equals(pathNodes[j].Name, "Path") && pathNodes[j].NodeType != XmlNodeType.Comment) {
                        // ignore and not tolerance
                        customFilePaths.isAdditionalTolerance = false;
                        customFilePaths.isIgnore = true;
                        customFilePaths.xPath = pathNodes[j].InnerText;

                    } else if ((string.Equals(pathNodes[j].Name, "IgnoreExpectedLeftovers") || string.Equals(pathNodes[j].Name, "IgnoreReachedLeftovers")) && pathNodes[j].NodeType != XmlNodeType.Comment) {
                        customFilePaths.isAdditionalTolerance = false;
                        customFilePaths.isIgnore = true;
                        customFilePaths.allText = pathNodes[j].OuterXml;

                    }
                    // need to add stuff for all possible nodes in custom file!!
                    allCustomFilePath.Add(customFilePaths);


                }
                //    if (keyNames.Count == 1 && string.Equals(keyNames[0], "${os.name}")) {//temp
                LogOperation(i + "-Splitting Customs on File: " + customFiles[i]);
                WriteSplitCustomFiles(customFiles[i], allCustomFilePath, keyValues);
                LogOperation(i + "-Updating Events File: " + Directory.GetParent(customFiles[i]) + @"\eventsfiles.xml");
                UpdateEventsFile(customFiles[i], keyNames);
                LogOperation(i + "-Done with Customs File: " + customFiles[i]);
                // }
            }

        }

        private void LogOperation(string logText) {
            txtLogs.Text = txtLogs.Text + "\r\n" + logText;
        }

        private void UpdateEventsFile(string oldCustomFilePath, List<string> keyNames) {
            StreamReader eventsFileReader = new StreamReader(Directory.GetParent(oldCustomFilePath) + @"\eventsfiles.xml");
            string eventsFileText;
            try {
                eventsFileText = eventsFileReader.ReadToEnd();
            } finally {
                if (eventsFileReader != null) {
                    eventsFileReader.Close();
                    eventsFileReader.Dispose();
                }
            }
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(eventsFileText);
            XmlNodeList stepsNodes = xDoc.DocumentElement.ChildNodes;
            for (int i = 0; i < stepsNodes.Count; i++) {

                if (stepsNodes[i].NodeType != XmlNodeType.Comment) {
                    if (stepsNodes[i].Attributes["customs"] != null) {
                        if (stepsNodes[i].Attributes["customs"].Value.Contains(Path.GetFileName(oldCustomFilePath))) {
                            string oldCustomsPathValue = stepsNodes[i].Attributes["customs"].Value;
                            stepsNodes[i].Attributes["customs"].Value = oldCustomsPathValue.Replace("_", "_${customType}");
                        }
                    }
                }
            }

            StreamWriter writer = new StreamWriter(Directory.GetParent(oldCustomFilePath) + @"\eventsfiles.xml");
            try {
                writer.Write(xDoc.InnerXml);
            } finally {
                if (writer != null) {
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();

                }
            }

        }

        private void WriteSplitCustomFiles(string originalCustomFilePath, List<CustomFilePaths> allCustomFilePaths, List<string> keyValues) {
            string customFileName = Path.GetFileName(originalCustomFilePath);
            string customFileParentDirectoryPath = Directory.GetParent(originalCustomFilePath).FullName;

            StreamWriter writer = new StreamWriter(customFileParentDirectoryPath + @"\" + customFileName, false);
            try {
                writer.WriteLine("<Customs>");
                for (int i = 0; i < allCustomFilePaths.Count; i++) {
                    if (!allCustomFilePaths[i].isAdditionalTolerance) {

                        if (!allCustomFilePaths[i].isIgnore) {

                            writer.WriteLine("<Path Tolerance=\"" + allCustomFilePaths[i].innitialTolerance + "\" >" + allCustomFilePaths[i].xPath + "</Path>");


                        } else {
                            if (!string.IsNullOrEmpty(allCustomFilePaths[i].allText)) {
                                writer.WriteLine(allCustomFilePaths[i].allText);

                            } else {
                                writer.WriteLine("<Path>" + allCustomFilePaths[i].xPath + "</Path>");
                            }
                        }
                    } else if (allCustomFilePaths[i].isAdditionalTolerance && !string.Equals(allCustomFilePaths[i].keyName, "${os.name}")) {
                        writer.WriteLine("<Path Tolerance=\"" + allCustomFilePaths[i].innitialTolerance + "\" >" + allCustomFilePaths[i].xPath +
                            "<AdditionalTolerances><AdditionalTolerance additionalTolerance=\"" +
                            allCustomFilePaths[i].additionalTolerance +
                            "\" keyName=\"" + allCustomFilePaths[i].keyName +
                            "\" keyValue=\"" + allCustomFilePaths[i].keyValue + "\" /> </AdditionalTolerances>" + "</Path>");

                    } else if (allCustomFilePaths[i].isAdditionalTolerance && !string.Equals(allCustomFilePaths[i].innitialTolerance, "0")) {
                        writer.WriteLine("<Path Tolerance=\"" + allCustomFilePaths[i].innitialTolerance + "\" >" + allCustomFilePaths[i].xPath + "</Path>");
                    }
                }
                writer.WriteLine("</Customs>");
            } finally {
                if (writer != null) {
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }
            }

            // for (int j = 0; j < keyValues.Count; j++) {
            StreamWriter writerAdditionalTolerances = new StreamWriter(customFileParentDirectoryPath + @"\" + customFileName.Replace("_", "_Linux"), false);

            try {
                writerAdditionalTolerances.WriteLine("<Customs>");
                for (int i = 0; i < allCustomFilePaths.Count; i++) {
                    if (allCustomFilePaths[i].isAdditionalTolerance && string.Equals(allCustomFilePaths[i].keyName, "${os.name}")) {
                        writerAdditionalTolerances.WriteLine("<Path Tolerance=\"" + allCustomFilePaths[i].additionalTolerance + "\" >" + allCustomFilePaths[i].xPath + "</Path>");
                    } else if (!allCustomFilePaths[i].isAdditionalTolerance) {
                        if (!allCustomFilePaths[i].isIgnore) {

                            writerAdditionalTolerances.WriteLine("<Path Tolerance=\"" + allCustomFilePaths[i].innitialTolerance + "\" >" + allCustomFilePaths[i].xPath + "</Path>");


                        } else {
                            if (!string.IsNullOrEmpty(allCustomFilePaths[i].allText)) {
                                writerAdditionalTolerances.WriteLine(allCustomFilePaths[i].allText);

                            } else {
                                writerAdditionalTolerances.WriteLine("<Path>" + allCustomFilePaths[i].xPath + "</Path>");
                            }
                        }
                    } else if (allCustomFilePaths[i].isAdditionalTolerance && !string.Equals(allCustomFilePaths[i].keyName, "${os.name}")) {
                        writerAdditionalTolerances.WriteLine("<Path Tolerance=\"" + allCustomFilePaths[i].innitialTolerance + "\" >" + allCustomFilePaths[i].xPath +
                            "<AdditionalTolerances><AdditionalTolerance additionalTolerance=\"" +
                            allCustomFilePaths[i].additionalTolerance +
                            "\" keyName=\"" + allCustomFilePaths[i].keyName +
                            "\" keyValue=\"" + allCustomFilePaths[i].keyValue + "\" /> </AdditionalTolerances>" + "</Path>");

                    }
                }
                writerAdditionalTolerances.WriteLine("</Customs>");
            } finally {
                if (writerAdditionalTolerances != null) {
                    writerAdditionalTolerances.Flush();
                    writerAdditionalTolerances.Close();
                    writerAdditionalTolerances.Dispose();
                }
            }
            //  }
        }

        private List<string> ParseCustomFiles(string inputDirPath) {
            List<string> compliantCustomFiles = new List<string>();
            try {
                string[] allCustomFiles = Directory.GetFiles(inputDirPath, "*customs.xml", SearchOption.AllDirectories);
                for (int i = 0; i < allCustomFiles.Length; i++) {
                    StreamReader reader = new StreamReader(allCustomFiles[i]);
                    try {
                        string readText = reader.ReadToEnd();
                        if (readText.Contains("AdditionalTolerance") && readText.Contains("Linux")) {
                            compliantCustomFiles.Add(allCustomFiles[i]);
                        }
                    } finally {
                        if (reader != null) {
                            reader.Close();
                            reader.Dispose();
                        }
                    }
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
            return compliantCustomFiles;
        }

        private void btnTest_Click(object sender, EventArgs e) {

            try {
                OdbcConnection conn = new OdbcConnection();
                conn.ConnectionString = txtConnString.Text;
                conn.Open();
                
                try {
                    conn.Open();
                    MessageBox.Show("Conn established");
                } finally {
                    conn.Close();
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
