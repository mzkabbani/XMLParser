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
using Automation.Common.Utils;

namespace XmlParsersAndUi.Forms {
    public partial class Multi_TestCaseForm : Form {
        public Multi_TestCaseForm() {
            InitializeComponent();
        }



        private void StartSplittingFile(string fileName, string sessionKey, out List<checkboxItems> items) {
            if (!Directory.Exists(txtOutputDir.Text)) {
                Directory.CreateDirectory(txtOutputDir.Text);
            }
            string fileRead = string.Empty;

            items = new List<checkboxItems>();
            StreamReader reader = new StreamReader(fileName);
            string eventsFile = "<Steps label=\"Automatically Generated\">";
            try {
                fileRead = reader.ReadToEnd();
                MatchCollection collection = Regex.Matches(fileRead, "<Comment.*EventID=\"(\\d+)\".*>(.*)</Comment>");
                List<string> matches = new List<string>();
                Dictionary<string, string> matchesAndId = new Dictionary<string, string>();
                for (int i = 0; i < collection.Count; i++) {
                    matches.Add(collection[i].Groups[2].ToString());
                    matchesAndId.Add(collection[i].Groups[1].ToString(), collection[i].Groups[2].ToString());
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
                            item.stepTitle = collection[j].Groups[2].ToString();
                            if (j == 0) {
                                item.startStepId = 0;
                            } else {
                                item.startStepId = items[j-1].endStepId+1;
                            }
                            item.endStepId = Convert.ToInt32(collection[j].Groups[1].Value);
                            item.stepEvents = splitArray[j];
                            items.Add(item);
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

                            //remove customs and gui for exit step
                            File.Delete(txtOutputDir.Text + @"\step" + (j + 1) + "_gui.xml");
                            File.Delete(txtOutputDir.Text + @"\step" + (j + 1) + "_gui.xml");
                            checkboxItems item = new checkboxItems();
                            item.filepath = txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml";
                            item.stepName = "step" + (j + 1) + "_events.xml";
                            item.startStepId = items[j - 1].endStepId + 1;
                            item.endStepId= 999;
                            item.stepTitle = "Exit";
                            item.stepEvents = splitArray[j];
                            items.Add(item);
                            // chkLstAllStepEvents.Items.Add(item);
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

        string oldEventsFile = string.Empty;

        private void btnStart_Click(object sender, EventArgs e) {
            string[] directories = Directory.GetDirectories(txtInputDir.Text);
            string buildPartText = "<automation.runtasks tasksteptitle=\"${partTitle}\"><sequential>${buildText}</sequential></automation.runtasks>";
            string completeBuild = "";
            for (int i = 0; i < directories.Length; i++) {
                string[] textFile = Directory.GetFiles(directories[i], "*.txt");
                string[] xmlFile = Directory.GetFiles(directories[i], "*.xml");
                List<checkboxItems> items = new List<checkboxItems>();
                StartSplittingFile(xmlFile[0], "1313", out items);

                string configRead = FrontendUtils.ReadFile(textFile[0]);
                string[] parts = configRead.Split(new string[] { "\n"},StringSplitOptions.RemoveEmptyEntries);
                string buildText = string.Empty;
                string testCaseFolderName = Path.GetFileNameWithoutExtension(directories[i]);
                for (int j = 0; j < parts.Length; j++) {
                    //part like {parenttitle}{1:3}
                    Regex regex = new Regex("\\{(.*?)\\}\\{(\\d+):(\\d+)\\}");
                    List<checkboxItems> selectedItems = GetSelectedItems(regex.Match(parts[j]).Groups[2].Value, regex.Match(parts[j]).Groups[3].Value,items);
                    
                    
                    GenerateSplitFile(selectedItems, "sessionKey" + i, (j + 1) + "-" + regex.Match(parts[j]).Groups[1].Value.Replace(" ", "_"), 1, testCaseFolderName);
                    for (int l = 0; l < selectedItems.Count; l++) {
                        CleanOutputDir(selectedItems[l]);
                    }
                    buildText = buildText +
                        "<automation.macroplayback eventsfile=\""+
                        "${datastore}.macros." + testCaseFolderName.Replace(" ","_") + "." + (j + 1) + "-" + regex.Match(parts[j]).Groups[1].Value.Replace(" ", "_") + ".eventsfiles.xml\"" +
                        " kernelsteptitle=\"" + regex.Match(parts[j]).Groups[1].Value + "\" createstep=\"false\" />\r\n";
                }
                completeBuild = completeBuild + "\n\n\n"+buildPartText.Replace("${partTitle}", testCaseFolderName).Replace("${buildText}", buildText);
                //FrontendUtils.WriteFile(directories[i] + @"\buildFile.txt", buildText);
         
                //List<checkboxItems> selectedItems = new List<checkboxItems>();
                //GenerateSplitFile(selectedItems, "sessionKey", "outFolderName", 1);
            }
            FrontendUtils.WriteFile(txtOutputDir.Text + @"\buildFile.txt", completeBuild);
     
        }

        private List<checkboxItems> GetSelectedItems(string from, string to, List<checkboxItems> items) {
            int fromEvent = Convert.ToInt32(from);
            int toEvent = Convert.ToInt32(to);
            List<checkboxItems> returnedItems = new List<checkboxItems>();

            for (int i = 0; i < items.Count; i++) {
                if ((items[i].startStepId >= fromEvent) && (items[i].endStepId <= toEvent)) {
                    returnedItems.Add(items[i]);
                }


            }

            return returnedItems;


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

        private void GenerateSplitFile(List<checkboxItems> selectedItems, string sessionKey, string folderName, int startIndex, string testCaseFolderName) {
            string eventsFileDirectory = Directory.GetParent(selectedItems[0].filepath)+@"\"+testCaseFolderName.Replace(" " ,"_") + @"\" + folderName;
            Directory.CreateDirectory(eventsFileDirectory);

            string eventsFileText = "<Steps label=\"Automatically Generated\">";


            for (int i = startIndex - 1, j = 0; i < (selectedItems.Count + startIndex - 1); i++, j++) {
                WriteCustomsFile(eventsFileDirectory, i + 1);
                WriteGuiFile(eventsFileDirectory, i + 1);
                WriteStepEventFile(eventsFileDirectory, i + 1, selectedItems[j]);
                if (string.Equals(selectedItems[j].stepTitle, "Exit")) {
                    if (string.IsNullOrEmpty(sessionKey)) {
                        eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" label=\"Exit\" events=\"step" + (i + 1) + "_events.xml\" ></Step>";
                    } else {
                        eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"Exit\" events=\"step" + (i + 1) + "_events.xml\" ></Step>";
                    }
                } else {
                    if (!string.IsNullOrEmpty(sessionKey)) {
                        eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"" + selectedItems[j].stepTitle + "\" events=\"step" + (i + 1) + "_events.xml\" gui=\"step" + (i + 1) + "_gui.xml\" customs=\"step" + (i + 1) + "_customs.xml\"></Step>";
                    } else {
                        eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" label=\"" + selectedItems[j].stepTitle + "\" events=\"step" + (i + 1) + "_events.xml\" gui=\"step" + (i + 1) + "_gui.xml\" customs=\"step" + (i + 1) + "_customs.xml\"></Step>";

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
                guiWriter.Write("<GuiRoot MXRequest=\"GetFullTree\"></GuiRoot>");
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

    }
}
