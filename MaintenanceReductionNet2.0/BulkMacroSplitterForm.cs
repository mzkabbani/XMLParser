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
using System.Diagnostics;
using System.Xml;

namespace XmlParsersAndUi {
    public partial class BulkMacroSplitterForm : Form {
        public BulkMacroSplitterForm() {
            InitializeComponent();
        }

        private void btnSplitFile_Click(object sender, EventArgs e) {
            try {
                StartSplittingFile();
                MessageBox.Show("Splitting done!");
                btnSplitFile.Enabled = false;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
        string oldEventsFile = string.Empty;
        private void StartSplittingFile() {
            if (!Directory.Exists(txtOutputDir.Text)) {
                Directory.CreateDirectory(txtOutputDir.Text);
            }

            string sessionKey = string.Empty;
            sessionKey = txtSessionKey.Text.Trim();
            string fileRead = string.Empty;
            StreamReader reader = new StreamReader(txtDirectory.Text);
            string eventsFile = "<Steps label=\"Automatically Generated\">";
            try {
                fileRead = reader.ReadToEnd();
                MatchCollection collection = Regex.Matches(fileRead, "<Comment.*>(.*)</Comment>");
                List<string> matches = new List<string>();
                for (int i = 0; i < collection.Count; i++) {
                    matches.Add(collection[i].Groups[1].ToString());
                    //     txtOutput.Text = txtOutput.Text + "\r\n" + collection[i].Groups[1].ToString();
                }


                string newFileRead = Regex.Replace(fileRead, "<Comment.*</Comment>", "</Events></MXClientScript><!-- --><MXClientScript><Events>");
                string[] test = new string[] { "<!-- -->" };
                string[] splitArray = newFileRead.Split(test, StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < splitArray.Length; j++) {
                    if (j < collection.Count) {
                        StreamWriter writer = new StreamWriter(txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml");
                        StreamWriter guiWriter = new StreamWriter(txtOutputDir.Text + @"\step" + (j + 1) + "_gui.xml");
                        StreamWriter customsWriter = new StreamWriter(txtOutputDir.Text + @"\step" + (j + 1) + "_customs.xml");
                        try {
                            guiWriter.Write(" ");
                            customsWriter.Write(@"<Customs></Customs>");
                            writer.Write(splitArray[j]);
                            if (string.IsNullOrEmpty(sessionKey)) {

                                eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" label=\"" + collection[j].Groups[1].ToString() + "\" events=\"step" + (j + 1) + "_events.xml\" gui=\"step" + (j + 1) + "_gui.xml\" customs=\"step" + (j + 1) + "_customs.xml\"></Step>";

                            } else {
                                eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"" + collection[j].Groups[1].ToString() + "\" events=\"step" + (j + 1) + "_events.xml\" gui=\"step" + (j + 1) + "_gui.xml\" customs=\"step" + (j + 1) + "_customs.xml\"></Step>";

                            }
                            checkboxItems item = new checkboxItems();
                            item.filepath = txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml";
                            item.stepName = "step" + (j + 1) + "_events.xml";
                            item.stepTitle = collection[j].Groups[1].ToString();
                            item.stepEvents = splitArray[j];
                            chkLstAllStepEvents.Items.Add(item);
                        } finally {
                            if (writer != null) {
                                writer.Close();
                            }
                            if (guiWriter != null) {
                                guiWriter.Close();
                            }
                            if (customsWriter != null) {
                                customsWriter.Close();
                            }
                        }
                    } else {
                        StreamWriter writer = new StreamWriter(txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml");
                        try {

                            writer.Write(splitArray[j]);

                            if (string.IsNullOrEmpty(sessionKey)) {

                                eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" label=\"Exit\" events=\"step" + (j + 1) + "_events.xml\"></Step>";

                            } else {
                                eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"Exit\" events=\"step" + (j + 1) + "_events.xml\"></Step>";


                            }
                            checkboxItems item = new checkboxItems();
                            item.filepath = txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml";
                            item.stepName = "step" + (j + 1) + "_events.xml";
                            item.stepTitle = "Exit";
                            item.stepEvents = splitArray[j];
                            chkLstAllStepEvents.Items.Add(item);
                        } finally {
                            if (writer != null) {
                                writer.Close();
                            }
                        }

                    }

                }
            } finally {
                if (reader != null) {
                    reader.Close();
                }
            }


            StreamWriter eventsfilesWriter = new StreamWriter(txtOutputDir.Text + @"\eventsfiles.xml");
            try {
                eventsFile = eventsFile + "</Steps>";
                eventsfilesWriter.Write(eventsFile);
                oldEventsFile = eventsFile;
            } finally {
                if (eventsfilesWriter != null) {
                    eventsfilesWriter.Close();
                }
            }
        }

        private void btnShowOutput_Click(object sender, EventArgs e) {
            if (Directory.Exists(txtOutputDir.Text)) {
                Process.Start(txtOutputDir.Text);
            } else {

                MessageBox.Show("The output directory does not exist yet");
            }
        }

        string fsEventsFile = string.Empty;

        // int groupNumber = 0;
        private void btnGroup_Click(object sender, EventArgs e) {
            try {

                chkFsEvents.Enabled = false;

                if (chkLstAllStepEvents.Items.Count == 0) {
                    MessageBox.Show("There is no steps to group!");
                    return;
                }

                List<checkboxItems> selectedItems = new List<checkboxItems>();
                System.Windows.Forms.CheckedListBox.CheckedItemCollection checkedCollection = chkLstAllStepEvents.CheckedItems;
                for (int i = 0; i < checkedCollection.Count; i++) {
                    selectedItems.Add(checkedCollection[i] as checkboxItems);
                }


                SessionKeyAndTitleForm form = new SessionKeyAndTitleForm(txtOutputDir.Text);
                DialogResult result = form.ShowDialog();
                SetDefaultFormValues(form);
                if (result == DialogResult.OK) {                    
                    
                    File.Delete(Directory.GetParent(selectedItems[0].filepath) + @"\eventsfiles.xml");
                    
                        for (int i = 0; i < selectedItems.Count; i++) {
                        CleanOutputDir(selectedItems[i]);
                        chkLstAllStepEvents.Items.Remove(selectedItems[i]);


                    }
                    GenerateSplitFile(selectedItems, form.Controls["txtSessionKey"].Text, form.Controls["txtTitle"].Text);
                   // if(chkFsEvents.Checked){
                  //     fsEventsFile = PrepareFsEventsFile(selectedItems,oldEventsFile);
                 //      oldEventsFile = fsEventsFile;
                 //   }
                    CreateBuildXmlFile(form.Controls["txtTitle"].Text, form.Controls["txtTitle"].Text + @"\eventsfiles.xml");


                    //groupNumber++;
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private string PrepareFsEventsFile(List<checkboxItems> selectedItems, string oldEventsFile) {
            string preparedEventsFile = string.Empty;
            XmlDocument xDoc = new XmlDocument();
            xDoc.LoadXml(oldEventsFile);

            for (int i = 0; i < selectedItems.Count; i++) {
                XmlNode requestedNode = GetRespectiveChildNode(selectedItems[i], xDoc);    
            }

            return preparedEventsFile;
        }

        private XmlNode GetRespectiveChildNode(checkboxItems selectedItem, XmlDocument xDoc) {
            XmlNode node = null;

            for (int i = 0; i < xDoc.DocumentElement.ChildNodes.Count; i++) {
            //    if (xDoc.DocumentElement.ChildNodes[i]) {
                
            //    }
            }

            return node;
        }

        private static void SetDefaultFormValues(SessionKeyAndTitleForm form) {
            Random random = new Random(DateTime.Now.Millisecond);
            form.Controls["txtSessionKey"].Text = random.Next(8999).ToString();
        }

        private void CleanOutputDir(checkboxItems checkboxItems) {
            File.Delete(checkboxItems.filepath);
            string parentDirectory = Directory.GetParent(checkboxItems.filepath).ToString();
            if (File.Exists(parentDirectory + @"\" + Path.GetFileName(checkboxItems.filepath).Replace("events", "customs"))) {
                File.Delete(parentDirectory + @"\" + Path.GetFileName(checkboxItems.filepath).Replace("events", "customs"));
            }
            if (File.Exists(parentDirectory + @"\" + Path.GetFileName(checkboxItems.filepath).Replace("events", "gui"))) {
                File.Delete(parentDirectory + @"\" + Path.GetFileName(checkboxItems.filepath).Replace("events", "gui"));
            }
        }

        private void CreateBuildXmlFile(string parentTitle, string pathOfEventsFile) {
            //writer.Write("<project default=\"allSequence\"><target name=\"allSequence\"><automation.macroplayback eventsfile=\"${datastore}." + pathOfEventsFile + " kernelsteptitle=\"" + parentTitle + "\" createstep=\"false\" />  </target></project>");

        }

        private void GenerateSplitFile(List<checkboxItems> selectedItems, string sessionKey, string folderName) {
            string eventsFileDirectory = Directory.GetParent(selectedItems[0].filepath) + @"\" + folderName;
            Directory.CreateDirectory(eventsFileDirectory);

            string eventsFileText = "<Steps label=\"Automatically Generated\">";


            for (int i = 0; i < selectedItems.Count; i++) {
                WriteCustomsFile(eventsFileDirectory, i + 1);
                WriteGuiFile(eventsFileDirectory, i + 1);
                WriteStepEventFile(eventsFileDirectory, i + 1, selectedItems[i]);
                if (string.Equals(selectedItems[i].stepTitle, "Exit")) {
                    if (string.IsNullOrEmpty(sessionKey)) {
                        eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" label=\"Exit\" events=\"step" + (i + 1) + "_events.xml\" ></Step>";
                    } else {
                        eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"Exit\" events=\"step" + (i + 1) + "_events.xml\" ></Step>";
                    }
                } else {
                    if (string.IsNullOrEmpty(sessionKey)) {
                        eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"" + selectedItems[i].stepTitle + "\" events=\"step" + (i + 1) + "_events.xml\" gui=\"step" + (i + 1) + "_gui.xml\" customs=\"step" + (i + 1) + "_customs.xml\"></Step>";
                    } else {
                        eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" label=\"" + selectedItems[i].stepTitle + "\" events=\"step" + (i + 1) + "_events.xml\" gui=\"step" + (i + 1) + "_gui.xml\" customs=\"step" + (i + 1) + "_customs.xml\"></Step>";
                    
                    }
                }
            }
            WriteEventsFile(sessionKey, eventsFileDirectory, eventsFileText);

        }

        private void WriteStepEventFile(string eventsFileDirectory, int stepNumber, checkboxItems checkboxItems) {
            StreamWriter writer = new StreamWriter(eventsFileDirectory + @"\step" + stepNumber + "_events.xml");
            try {
                writer.Write(checkboxItems.stepEvents);
            } finally {
                if (writer != null) {
                    writer.Flush();
                    writer.Close();
                    writer.Dispose();
                }
            }
        }

        private void WriteGuiFile(string eventsFileDirectory, int guiNumber) {
            StreamWriter guiWriter = new StreamWriter(eventsFileDirectory + @"\step" + guiNumber + "_gui.xml");
            try {
                guiWriter.Write("");
            } finally {
                if (guiWriter != null) {
                    guiWriter.Flush();
                    guiWriter.Close();
                    guiWriter.Dispose();
                }
            }
        }

        private void WriteCustomsFile(string eventsFileDirectory, int customsNumber) {
            StreamWriter customsWriter = new StreamWriter(eventsFileDirectory + @"\step" + customsNumber + "_customs.xml");
            try {
                customsWriter.Write(@"<Customs></Customs>");
            } finally {
                if (customsWriter != null) {
                    customsWriter.Flush();
                    customsWriter.Close();
                    customsWriter.Dispose();
                }
            }

        }

        private void WriteEventsFile(string sessionKey, string eventsFileDirectory, string eventsFileText) {
            StreamWriter eventsfilesWriter = new StreamWriter(eventsFileDirectory + @"\eventsfiles.xml");
            try {
                eventsFileText = eventsFileText + "</Steps>";
                eventsfilesWriter.Write(eventsFileText);
            } finally {
                if (eventsfilesWriter != null) {
                    eventsfilesWriter.Flush();
                    eventsfilesWriter.Close();
                    eventsfilesWriter.Dispose();
                }
            }

        }
        bool check = true;
        private void btnSelectAll_Click(object sender, EventArgs e) {
            try {

                for (int i = 0; i < chkLstAllStepEvents.Items.Count; i++) {
                    chkLstAllStepEvents.SetItemChecked(i, check);
                }
                check = !check;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            btnSplitFile.Enabled = true;
            chkLstAllStepEvents.Items.Clear();

        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();

                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtDirectory.Text = dialog.FileName;
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnOutputDir_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtOutputDir.Text = dialog.SelectedPath;
                }

            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtDirectory_TextChanged(object sender, EventArgs e) {
            string outputDir = Directory.GetParent(txtDirectory.Text) + @"\output";
            if (!Directory.Exists(outputDir)) {
                Directory.Exists(outputDir);
            }
            txtOutputDir.Text = outputDir;
        }

        private void BulkMacroSplitterForm_Load(object sender, EventArgs e) {
            //    Random random = new Random(DateTime.Now.Millisecond);
            //  txtSessionKey.Text = random.Next(8999).ToString();
        }
    }
}
