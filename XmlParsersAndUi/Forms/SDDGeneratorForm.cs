using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XmlParsersAndUi.Classes;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using System.Xml;
using System.IO;
using Automation.Common.Utils;
using Automation.Common;
using Automation.Backend;
using Automation.Common.Classes.Monitoring;

namespace XmlParsersAndUi.Forms {
    public partial class SDDGeneratorForm : Form {

        public SDDGeneratorForm() {
            InitializeComponent();
        }

        private void btnStartOperation_Click(object sender, EventArgs e) {
            try {
                btnStartOperation.Enabled = false;
                List<AdvancedRecomendation> allCaptureEvents = Advanced_Recomendations_TextConv.GetAllAdvancedRecsAsListTextConv();
                BackGroundWorkerObject workerObject = new BackGroundWorkerObject();
                workerObject.selectedCaptureEvents = allCaptureEvents;
                workerObject.targetedFiles = new List<FileToParseObject>();
                workerObject.targetedFiles.Add(new FileToParseObject(txtInputFile.Text, false));
                if (IsValidToStartOperations(txtInputFile.Text)) {
                    bwSearchReplace.RunWorkerAsync(workerObject);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private bool IsValidToStartOperations(string inputFile) {
            if (!File.Exists(inputFile)) {
                FrontendUtils.ShowError("Input file doesnt exist", new Exception());
                return false;
            }
            return true;
        }

        #region Background Work

        private void bwSearchReplace_DoWork(object sender, DoWorkEventArgs e) {
            BackGroundWorkerObject workerObjec = e.Argument as BackGroundWorkerObject;
            List<string> returnedTextFromMacro = SearchAndGenerate(workerObjec.targetedFiles[0].fileName, workerObjec.selectedCaptureEvents);
            e.Result = returnedTextFromMacro;
        }

        private void bwSearchReplace_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            try {
                List<string> replacedEvents = e.Result as List<string>;
                tvOutputSteps.Nodes.Clear();
                dgvOutputResults.Rows.Clear();
                Regex regex = new Regex("EventID.*?=.*?\"(\\d+)\"");

                for (int i = 0; i < replacedEvents.Count; i++) {
                    if (replacedEvents[i].Contains("EventID")) {
                        tvOutputSteps.Nodes.Add(i.ToString(), "Event ID " + regex.Match(replacedEvents[i]).Groups[1].Value + " Skipped!", 0);

                    } else {
                        tvOutputSteps.Nodes.Add(i.ToString(), replacedEvents[i], 1);

                    }
                    dgvOutputResults.Rows.Add(new object[] { i + 1, replacedEvents[i] });
                }
                btnStartOperation.Enabled = true;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        #endregion

        private void btnBrowse_Click(object sender, EventArgs e) {
            try {
                OpenFileDialog dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtInputFile.Text = dialog.FileName;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        #region Search Code

        private List<string> SearchAndGenerate(string fileName, List<AdvancedRecomendation> selectedCaptureEvents) {
            List<string> textGenerated = new List<string>();
            string fileRead = FrontendUtils.ReadFile(fileName);
            fileRead = fileRead.Replace("<!DOCTYPE MXClientScript>", "");
            if (fileRead.Contains("LoginInfo")) {
                Regex regUsername = new Regex("<UserName>(.*?)</UserName>");
                Regex regPasswrod = new Regex("<Password>(.*?)</Password>");
                Regex regGroupName = new Regex("<GroupName>(.*?)</GroupName>");
                Regex regDirectAccess = new Regex("<DirectAccess.*?>(.*?)</DirectAccess>");

                textGenerated.Add("Login as " + regUsername.Match(fileRead).Groups[1].Value + "/"
                    + regPasswrod.Match(fileRead).Groups[1].Value + "/" + regGroupName.Match(fileRead).Groups[1].Value);

                if (regDirectAccess.Match(fileRead).Groups[1].Value != string.Empty) {
                    textGenerated.Add("Open " + regDirectAccess.Match(fileRead).Groups[1].Value + " From the Menu");
                }
            }
            for (int i = 0; i < selectedCaptureEvents.Count; i++) {
                fileRead = ParseTargetedFile(selectedCaptureEvents[i], fileRead);
            }

            XDocument xdoc = XDocument.Parse(fileRead);

            IEnumerable<XNode> nodes = xdoc.Descendants("Events").Nodes();
            Regex regex = new Regex("&lt;!--(.*?)--&gt");
            foreach (XNode node in nodes) {
                if (node.NodeType != XmlNodeType.Comment) {
                    if (node.ToString().Contains("EventID")) {
                        textGenerated.Add(node.ToString());
                    } else {
                        MatchCollection collection = regex.Matches(node.ToString());
                        foreach (Match match in collection) {
                            textGenerated.Add(match.Groups[1].Value);
                        }
                    }
                }
            }
            return textGenerated;
        }

        private string ParseTargetedFile(AdvancedRecomendation captureEvent, string readText) {
            captureEvent = GetCapturePointListType(captureEvent);
            XDocument xdoc = XDocument.Parse(readText);
            List<string> foundEvents = new List<string>();
            List<XNode> foundNodes = new List<XNode>();
            if (captureEvent.capturePointListType == CapturePointListType.SimpleList) {
                foundNodes = ParseUsingSimpleList(captureEvent, xdoc, foundEvents);
                if (foundNodes.Count > 0) {
                    FileAndNumberOfMatches fileAndNumberOfMatches = new FileAndNumberOfMatches();
                    fileAndNumberOfMatches.matchedNodes = foundNodes;

                }
            } else {
                foundNodes = ParseUsingAdvancedList(captureEvent, xdoc);
                if (foundNodes.Count > 0) {
                    FileAndNumberOfMatches fileAndNumberOfMatches = new FileAndNumberOfMatches();
                    fileAndNumberOfMatches.matchedNodes = foundNodes;
                }
            }
            ReplaceFoundNodes(captureEvent.Replacement, foundNodes);
            return xdoc.ToString();
        }

        private void ReplaceFoundNodes(ReplacementEvent replacementEvent, List<XNode> foundNodes) {
            foreach (XNode foundNode in foundNodes) {
                try {
                    foundNode.ReplaceWith("<!-- " + GetReplacementValueFromEvent(replacementEvent, foundNode).Trim() + " -->");

                } catch (Exception ex) {
                    // replacement failed
                }
            }
        }

        private string GetReplacementValueFromEvent(ReplacementEvent replacementEvent, XNode foundNode) {
            // may be a bug .... ex: with two view-selection under action performed 
            List<NodeAndAttributeCouple> replaceableValues = GetReplacementParametersFromValue(replacementEvent.Value);
            string completedEvent = replacementEvent.Value;
            XElement element = XElement.Parse(foundNode.ToString());
            for (int i = 0; i < replaceableValues.Count; i++) {
                if (string.Equals(replaceableValues[i].attrName, "TextValue", StringComparison.InvariantCultureIgnoreCase)) {
                    string textValue = element.DescendantsAndSelf(replaceableValues[i].nodeName).ElementAt(0).Value.Trim();

                    if (completedEvent.Contains("{" + replaceableValues[i].nodeName + ":TextValue}")) {
                        completedEvent = completedEvent.Replace("{" + replaceableValues[i].nodeName + ":TextValue}", textValue);
                    } else {
                        completedEvent = completedEvent.Replace("{TextValue}", textValue);
                    }

                } else {
                    if (element.DescendantsAndSelf(replaceableValues[i].nodeName).Attributes(replaceableValues[i].attrName).Count() >= replaceableValues[i].index) {
                        string attrValue = element.DescendantsAndSelf(replaceableValues[i].nodeName).Attributes(replaceableValues[i].attrName).ElementAt(replaceableValues[i].index).Value.Trim();
                        if (completedEvent.Contains("{" + replaceableValues[i].nodeName + ":" + replaceableValues[i].attrName + "}")) {
                            completedEvent = completedEvent.Replace("{" + replaceableValues[i].nodeName + ":" + replaceableValues[i].attrName + "}", attrValue);
                        } else if (completedEvent.Contains("{" + replaceableValues[i].nodeName + ":" + replaceableValues[i].attrNameWithAt + "}")) {
                            completedEvent = completedEvent.Replace("{" + replaceableValues[i].nodeName + ":" + replaceableValues[i].attrNameWithAt + "}", attrValue);
                        } else if (completedEvent.Contains("{" + replaceableValues[i].attrName + "}")) {
                            completedEvent = completedEvent.Replace("{" + replaceableValues[i].attrName + "}", attrValue);
                        }
                    }
                }
            }
            return completedEvent;
        }

        private List<NodeAndAttributeCouple> GetReplacementParametersFromValue(string replacementValue) {
            List<NodeAndAttributeCouple> couples = new List<NodeAndAttributeCouple>();
            List<string> caughtParameters = new List<string>();


            Regex regex = new Regex("\\{(.*?)\\}", RegexOptions.Compiled);

            foreach (Match match in regex.Matches(replacementValue)) {
                caughtParameters.Add(match.Groups[1].Value);
            }

            for (int i = 0; i < caughtParameters.Count; i++) {
                Regex firstRegex = new Regex(".*(<(.*)?\\{)" + caughtParameters[i]);
                string firstMatch = firstRegex.Match(replacementValue).Groups[1].Value;
                Regex secondRegex = new Regex("<(.*?)\\s");
                string nodeName = secondRegex.Match(firstMatch).Groups[1].Value;
                NodeAndAttributeCouple couple = new NodeAndAttributeCouple();
                if (caughtParameters[i].Contains(':')) {
                    couple.nodeName = caughtParameters[i].Split(new char[] { ':' })[0];
                    couple.attrName = caughtParameters[i].Split(new char[] { ':' })[1];
                    if (couple.attrName.Split(new char[] { '@' }).Length > 1) {
                        couple.attrNameWithAt = couple.attrName;
                        couple.index = Convert.ToInt32(couple.attrName.Split(new char[] { '@' })[1]);
                        couple.attrName = couple.attrName.Split(new char[] { '@' })[0];
                    }
                    couples.Add(couple);
                } else {
                    couple.nodeName = nodeName;
                    couple.attrName = caughtParameters[i];
                    couples.Add(couple);
                }

            }
            return couples;
        }

        private AdvancedRecomendation GetCapturePointListType(AdvancedRecomendation captureEvent) {
            List<CustomTreeNode> list = captureEvent.CaptureEventCapturePointsList;
            captureEvent.capturePointListType = CapturePointListType.SimpleList;
            for (int listCount = 1; listCount < list.Count; listCount++) {
                if (list[listCount - 1].nodeLevel > list[listCount].nodeLevel) {
                    captureEvent.capturePointListType = CapturePointListType.ListWithMutlipleDesc;
                    return captureEvent;
                }
            }
            return captureEvent;
        }

        private List<XNode> ParseUsingSimpleList(AdvancedRecomendation captureEvent, XDocument xdoc, List<string> foundEvents) {
            List<XNode> foundNodes = new List<XNode>();
            switch (captureEvent.CaptureEventCapturePointsList.Count) {
                case 1:
                    var q1 = from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                             where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                             select new {
                                 elements = c1.DescendantNodesAndSelf()
                             };
                    for (int i = 0; i < q1.Count(); i++) {
                        foundEvents.Add(q1.ElementAt(i).elements.ElementAt(0).ToString());
                        foundNodes.Add(q1.ElementAt(i).elements.ElementAt(0));
                    }
                    break;
                case 2:
                    var q2 = from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                             where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                             from c2 in c1.Elements(captureEvent.CaptureEventCapturePointsList[1].Text)
                             where AllAttributesAvailable(c2, captureEvent.CaptureEventCapturePointsList[1].customizedAttributeCollection)
                             select new {
                                 elements = c1.DescendantNodesAndSelf()
                             };
                    for (int i = 0; i < q2.Count(); i++) {
                        foundEvents.Add(q2.ElementAt(i).elements.ElementAt(0).ToString());
                        foundNodes.Add(q2.ElementAt(i).elements.ElementAt(0));
                    }
                    break;
                case 3:
                    var q3 = from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                             where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                             from c2 in c1.Elements(captureEvent.CaptureEventCapturePointsList[1].Text)
                             where AllAttributesAvailable(c2, captureEvent.CaptureEventCapturePointsList[1].customizedAttributeCollection)
                             from c3 in c2.Elements(captureEvent.CaptureEventCapturePointsList[2].Text)
                             where AllAttributesAvailable(c3, captureEvent.CaptureEventCapturePointsList[2].customizedAttributeCollection)
                             select new {
                                 elements = c1.DescendantNodesAndSelf()
                             };
                    for (int i = 0; i < q3.Count(); i++) {
                        foundEvents.Add(q3.ElementAt(i).elements.ElementAt(0).ToString());
                        foundNodes.Add(q3.ElementAt(i).elements.ElementAt(0));
                    }
                    break;
                case 4:
                    var q4 = from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                             where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                             from c2 in c1.Elements(captureEvent.CaptureEventCapturePointsList[1].Text)
                             where AllAttributesAvailable(c2, captureEvent.CaptureEventCapturePointsList[1].customizedAttributeCollection)
                             from c3 in c2.Elements(captureEvent.CaptureEventCapturePointsList[2].Text)
                             where AllAttributesAvailable(c3, captureEvent.CaptureEventCapturePointsList[2].customizedAttributeCollection)
                             from c4 in c3.Elements(captureEvent.CaptureEventCapturePointsList[3].Text)
                             where AllAttributesAvailable(c4, captureEvent.CaptureEventCapturePointsList[3].customizedAttributeCollection)
                             select new {
                                 elements = c1.DescendantNodesAndSelf()
                             };
                    for (int i = 0; i < q4.Count(); i++) {
                        foundEvents.Add(q4.ElementAt(i).elements.ElementAt(0).ToString());
                        foundNodes.Add(q4.ElementAt(i).elements.ElementAt(0));
                    }
                    break;
            }
            return foundNodes;
        }

        private bool AllAttributesAvailable(XElement c1, List<CustomizedAttribute> list) {
            bool found = true;

            for (int i = 0; i < list.Count && found; i++) {
                if (string.IsNullOrEmpty(list[i].attrName)) {
                    return true;
                } else if (c1.Attribute(list[i].attrName) == null) {
                    found = false;
                }
                    //else if (!string.Equals(c1.Attribute(list[i].attrName).Value, list[i].attrValue)) {
                    //    found = false;
                    //}
                else {
                    Regex regex = new Regex(list[i].attrValue);
                    if (regex.Matches(c1.Attribute(list[i].attrName).Value).Count > 0) {
                        found = true;
                    } else {
                        found = false;
                    }
                }
            }
            return found;
        }

        private List<XNode> ParseUsingAdvancedList(AdvancedRecomendation captureEvent, XDocument xdoc) {
            var test21 = from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                         where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                         select new {
                             elements = c1.DescendantNodesAndSelf()
                         };
            List<bool> foundlist = new List<bool>();
            for (int i = 0; i < test21.Count(); i++) {
                bool found = true;
                XNode node = test21.ElementAt(i).elements.ElementAt(0);
                XmlReader Xreader = node.CreateReader();
                Xreader.Read();
                while (Xreader.Read() && found) {
                    if (Xreader.NodeType == XmlNodeType.Element) {
                        for (int listLength = 1; found && listLength < captureEvent.CaptureEventCapturePointsList.Count; listLength++) {//Xreader.Name;
                            if (!captureEvent.CaptureEventCapturePointsList[listLength].nodeVisited && string.Equals(captureEvent.CaptureEventCapturePointsList[listLength].Text, Xreader.Name)) {
                                captureEvent.CaptureEventCapturePointsList[listLength].nodeVisited = true;
                                #region Loop Thru attributes
                                for (int attrCoun = 0; found && attrCoun < captureEvent.CaptureEventCapturePointsList[listLength].customizedAttributeCollection.Count; attrCoun++) {
                                    CustomizedAttribute customizedAttribute = captureEvent.CaptureEventCapturePointsList[listLength].customizedAttributeCollection[attrCoun];
                                    string attributeValueFromXml = Xreader.GetAttribute(customizedAttribute.attrName);
                                    if (string.IsNullOrEmpty(attributeValueFromXml) && !string.IsNullOrEmpty(customizedAttribute.attrName)) {
                                        found = false;
                                    } else if (!string.IsNullOrEmpty(customizedAttribute.attrName)) {
                                        Regex regex = new Regex(customizedAttribute.attrValue);
                                        if (regex.Matches(attributeValueFromXml).Count > 0) {
                                            found = true;
                                        } else {
                                            found = false;
                                        }
                                    }
                                    //else if (!string.Equals(attributeValueFromXml, customizedAttribute.attrValue) && !string.IsNullOrEmpty(customizedAttribute.attrName)) {
                                    //    found = false;
                                    //}
                                }
                                listLength = captureEvent.CaptureEventCapturePointsList.Count;
                                #endregion
                            }
                        }
                    }
                }
                foundlist.Add(found);
            }
            //txtFoundEvents.Text = string.Empty;
            List<XNode> foundNodes = new List<XNode>();
            for (int k = 0; k < foundlist.Count; k++) {
                if (foundlist[k]) {
                    XNode node = test21.ElementAt(k).elements.ElementAt(0);
                    foundNodes.Add(node);
                    //txtFoundEvents.Text = txtFoundEvents.Text + (string.IsNullOrEmpty(txtFoundEvents.Text) ? "" : "\r\n") + FrontendUtils.FormatXml(node.ToString());
                }
            }
            return foundNodes;
        }

        #endregion

        #region Export To Excel Code

        private void btnExport_Click(object sender, EventArgs e) {
            // FastExportingMethod.ExportToExcel(set, fileName);
            btnExport.Enabled = false;
            SaveFileDialog dial = new SaveFileDialog();
            dial.AddExtension = true;
            dial.DefaultExt = ".xls";
            dial.Filter = "Excel Files (*.xls)|*.xls";
            if (dial.ShowDialog() == DialogResult.OK) {
                DataSet set = new DataSet("Testcase Macro Events");
                DataTable tableInGrid = GetDataTableFromGrid();
                set.Tables.Add(tableInGrid);
                bwExportExcel.RunWorkerAsync(new object[] { set, dial.FileName });

            }
        }

        private DataTable GetDataTableFromGrid() {
            DataTable table = GetDataTable("Step Events", new List<string> { "Step Number", "Operation" });
            foreach (DataGridViewRow row in dgvOutputResults.Rows) {
                //# Operation filePath
                if (row.Visible) {
                    object[] values = new object[] { row.Cells[0].Value, row.Cells[1].Value };
                    table.Rows.Add(values);
                }

            }

            return table;
        }

        private DataTable GetDataTable(string tableName, List<string> columnNames) {
            DataTable dataTable = new DataTable(tableName);
            for (int i = 0; i < columnNames.Count; i++) {
                dataTable.Columns.Add(columnNames[i]);
            }
            return dataTable;
        }

        private void bwExportExcel_DoWork(object sender, DoWorkEventArgs e) {
            object[] arguments = e.Argument as object[];
            FastExportingMethod.ExportToExcel(arguments[0] as DataSet, arguments[1].ToString());
        }

        private void bwExportExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            FrontendUtils.ShowInformation("Export Completed", false);
            btnExport.Enabled = true;
        }

        #endregion

        private void btnReset_Click(object sender, EventArgs e) {
            try {
                txtInputFile.ResetText();
                tvOutputSteps.Nodes.Clear();
                dgvOutputResults.Rows.Clear();
                btnStartOperation.Enabled = true;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void SDDGeneratorForm_Load(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(MonitorObject.username)) {
                    MonitorObject.formAndAccessTime.Add(new FormAndAccessTime(this.Name, DateTime.Now));
                }
            } catch (Exception) {

            }
        }


    }
}
