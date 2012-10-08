using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using XmlParsersAndUi.Classes;
using System.Threading;
using XmlParsersAndUi.Controls;
using System.Text.RegularExpressions;
using DifferenceEngine;
using System.Collections;
using Automation.Common.Utils;
using Automation.Common;
using Automation.Backend;
using Automation.Common.Classes.Monitoring;

namespace XmlParsersAndUi.Forms {
    public partial class SecondLevelCleanupForm : Form {

        #region Contructor

        public SecondLevelCleanupForm() {
            InitializeComponent();
        }

        #endregion

        #region Variables

        DataSet AllCategories = new DataSet();
        DataSet AllAdvancedRecs = new DataSet();
        AdvancedRecomendation currentlySelectedEvent;
        List<AdvancedRecomendation> currentlyUsedCaptures = new List<AdvancedRecomendation>();
        BackGroundWorkerObject backGroundWorkerObject = new BackGroundWorkerObject();
        int totalFoundNodes = 0;
        private DiffEngineLevel _level;
        string outputDirectory;
        string BACKUP_DIRECTORY;
        Dictionary<int, AdvancedRecomendation> currentlyLoadedEvents;
        int CAPTURE_TOTAL_USAGE_COUNT;
        int REPLACEMENT_TOTAL_USAGE_COUNT;
        //mutex on the radio button event
        bool isNeeded = true;
        string CLEANUPFORM_EVENTS_SEARCH_PATTERN;

        #endregion

        #region Methods

        private void LoadAvailableAdvancedRecommendations() {
            lvAdvancedRules.Clear();
            DataSet dataSet = Advanced_Recommendation_Categories.GetAllAdvancedRecCategoriesAsDataset();
            foreach (DataRow dataRow in dataSet.Tables[0].Rows) {
                lvAdvancedRules.Groups.Add(dataRow["id"].ToString(), dataRow["categoryName"].ToString());
            }
            AllCategories = dataSet;

            DataSet newDataSet = Advanced_Recommendations.GetAllAdvancedRecsAsDataSet();
            currentlyLoadedEvents = new Dictionary<int, AdvancedRecomendation>();
            foreach (DataRow dataRow in newDataSet.Tables[0].Rows) {
                System.Windows.Forms.ListViewItem item = lvAdvancedRules.Items.Add(dataRow["id"].ToString(), dataRow["name"].ToString(), 0);
                item.Group = lvAdvancedRules.Groups[dataRow["categoryId"].ToString()];
                item.Tag = dataRow["id"].ToString();//tag holding the id of the rec
                item.ImageIndex = 1;
                AdvancedRecomendation capture = new AdvancedRecomendation();
                capture.CaptureEventId = Convert.ToInt32(item.Tag);
                capture.CaptureEventName = dataRow["name"].ToString();
                capture.CaptureEventDescription = dataRow["description"].ToString();
                capture.captureEventUsageCount = Convert.ToInt32(dataRow["usageCount"]);
                currentlyLoadedEvents.Add(Convert.ToInt32(item.Tag), capture);
            }
            AllAdvancedRecs = newDataSet;
            CAPTURE_TOTAL_USAGE_COUNT = Advanced_Recommendations.GetTotalAdvanceRecUsageCount();
        }

        private void SetupUiFromCapturePoint(AdvancedRecomendation capture) {
            txtRuleName.Text = capture.CaptureEventName;
            txtRuleDescription.Text = capture.CaptureEventDescription;
            SetPopularity(capture);
        }

        private void SetPopularity(AdvancedRecomendation capture) {
            srcPopularityAdded.m_hoverStar = 0;
            srcPopularityAdded.m_selectedStar = 0;
            srcPopularityAdded.Invalidate();
            double usagePercent = ((double)capture.captureEventUsageCount / CAPTURE_TOTAL_USAGE_COUNT) * 20;
            srcPopularityAdded.m_hoverStar = (int)usagePercent;
            srcPopularityAdded.m_selectedStar = (int)usagePercent;
            srcPopularityAdded.m_hovering = true;
            srcPopularityAdded.Invalidate();
        }

        private List<AdvancedRecomendation> AddCapturePointToList(List<AdvancedRecomendation> currentlyUsedCaptures, AdvancedRecomendation currentlySelectedEvent) {
            bool found = false;
            if (currentlyUsedCaptures.Count == 0) {
                currentlyUsedCaptures.Add(currentlySelectedEvent);
            } else {
                for (int i = 0; i < currentlyUsedCaptures.Count && !found; i++) {
                    if (currentlyUsedCaptures[i].CaptureEventId == currentlySelectedEvent.CaptureEventId) {
                        found = true;
                    }
                    if (!found && i == currentlyUsedCaptures.Count - 1) {
                        currentlyUsedCaptures.Add(currentlySelectedEvent);
                    }
                }
            }
            return currentlyUsedCaptures;
        }

        private List<AdvancedRecomendation> RemoveCapturePointFromList(List<AdvancedRecomendation> currentlyUsedCaptures, int captureEventId) {
            List<AdvancedRecomendation> UsedCaptures = new List<AdvancedRecomendation>();
            for (int i = 0; i < currentlyUsedCaptures.Count; i++) {
                if (currentlyUsedCaptures[i].CaptureEventId != captureEventId) {
                    UsedCaptures.Add(currentlyUsedCaptures[i]);
                }
            }
            return UsedCaptures;
        }

        private void ParseTargetedFile(AdvancedRecomendation captureEvent, string readText, ComplexCaptureMatchObject complexCaptureMatchObject, string fileName) {
            captureEvent = GetCapturePointListType(captureEvent);
            XDocument xdoc = XDocument.Parse(readText);
            List<string> foundEvents = new List<string>();
            if (captureEvent.capturePointListType == CapturePointListType.SimpleList) {
                List<XNode> foundNodes = ParseUsingSimpleList(captureEvent, xdoc, foundEvents);
                totalFoundNodes = totalFoundNodes + foundNodes.Count;
                if (foundNodes.Count > 0) {
                    FileAndNumberOfMatches fileAndNumberOfMatches = new FileAndNumberOfMatches();
                    fileAndNumberOfMatches.fileName = fileName;
                    fileAndNumberOfMatches.matchedNodes = foundNodes;
                    complexCaptureMatchObject.fileNamesHit.Add(fileAndNumberOfMatches);
                }
            } else {
                List<XNode> foundNodes = ParseUsingAdvancedList(captureEvent, xdoc);
                totalFoundNodes = totalFoundNodes + foundNodes.Count;
                if (foundNodes.Count > 0) {
                    FileAndNumberOfMatches fileAndNumberOfMatches = new FileAndNumberOfMatches();
                    fileAndNumberOfMatches.fileName = fileName;
                    fileAndNumberOfMatches.matchedNodes = foundNodes;
                    complexCaptureMatchObject.fileNamesHit.Add(fileAndNumberOfMatches);
                }
            }
        }

        private void FillDatagridWithResults(BackGroundWorkerObject aBackGroundWorkerObject) {
            for (int i = 0; i < aBackGroundWorkerObject.returnedComplexCaptureMatchObject.Count; i++) {
                int rowIndex = dgvSearchResult.Rows.Add();
                dgvSearchResult.Rows[rowIndex].Cells[0].Value = aBackGroundWorkerObject.returnedComplexCaptureMatchObject[i].captureEvent.CaptureEventName;
                dgvSearchResult.Rows[rowIndex].Cells[1].Value = aBackGroundWorkerObject.returnedComplexCaptureMatchObject[i].fileNamesHit.Count;//number of files hit
                dgvSearchResult.Rows[rowIndex].Cells[2].Value = GetTotalMatchesForCapture(aBackGroundWorkerObject.returnedComplexCaptureMatchObject[i].fileNamesHit);
                dgvSearchResult.Rows[rowIndex].Cells[3].Value = aBackGroundWorkerObject;
            }
        }

        private int GetTotalMatchesForCapture(List<FileAndNumberOfMatches> fileList) {
            int totalMatches = 0;
            for (int i = 0; i < fileList.Count; i++) {
                totalMatches = totalMatches + fileList[i].matchedNodes.Count;
            }
            return totalMatches;
        }

        private void StartParsingInput(List<AdvancedRecomendation> currentlyUsedCaptures, string readText, string fileName, ComplexCaptureMatchObject complexCaptureMatchObject) {
            XDocument xdoc = XDocument.Parse(readText);
            for (int i = 0; i < currentlyUsedCaptures.Count; i++) {
                complexCaptureMatchObject.captureEvent = currentlyUsedCaptures[i];
                currentlyUsedCaptures[i] = GetCapturePointListType(currentlyUsedCaptures[i]);
                List<string> foundEvents = new List<string>();
                if (currentlyUsedCaptures[i].capturePointListType == CapturePointListType.SimpleList) {
                    List<XNode> foundNodes = ParseUsingSimpleList(currentlyUsedCaptures[i], xdoc, foundEvents);
                    totalFoundNodes = totalFoundNodes + foundNodes.Count;
                    if (foundNodes.Count > 0) {
                        FileAndNumberOfMatches fileAndNumberOfMatches = new FileAndNumberOfMatches();
                        fileAndNumberOfMatches.fileName = fileName;
                        fileAndNumberOfMatches.matchedNodes = foundNodes;
                        complexCaptureMatchObject.fileNamesHit.Add(fileAndNumberOfMatches);
                    }
                } else {
                    List<XNode> foundNodes = ParseUsingAdvancedList(currentlyUsedCaptures[i], xdoc);
                    totalFoundNodes = totalFoundNodes + foundNodes.Count;
                    if (foundNodes.Count > 0) {
                        FileAndNumberOfMatches fileAndNumberOfMatches = new FileAndNumberOfMatches();
                        fileAndNumberOfMatches.fileName = fileName;
                        fileAndNumberOfMatches.matchedNodes = foundNodes;
                        complexCaptureMatchObject.fileNamesHit.Add(fileAndNumberOfMatches);
                    }
                }
            }
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

        private void SetupUiForReplacements() {
            lblFoundNodesCound.Visible = false;

            gbSelectedCapture.Visible = false;
            gbAdvancedRules.Visible = false;
            gbOperation.Visible = false;
            gbSearchResults.Visible = false;
            gbAvailableReplacements.Visible = true;
            gbSearchResults.Visible = true;

            btnStart.Visible = false;
            btnResetForm.Visible = false;
            btnBackToSearch.Location = btnResetForm.Location;
            btnBackToSearch.Visible = true;
            btnStartReplacementOp.Location = btnProceedToReplacement.Location;
            btnStartReplacementOp.Visible = true;

            FillDatagridWithResultsForRemap(backGroundWorkerObject);
        }

        private void FillDatagridWithResultsForRemap(BackGroundWorkerObject aBackGroundWorkerObject) {
            dgvResults.Rows.Clear();
            for (int i = 0; i < aBackGroundWorkerObject.returnedComplexCaptureMatchObject.Count; i++) {
                int rowIndex = dgvResults.Rows.Add();
                dgvResults.Rows[rowIndex].Cells[0].Value = aBackGroundWorkerObject.returnedComplexCaptureMatchObject[i].captureEvent.CaptureEventName;
                dgvResults.Rows[rowIndex].Cells[2].Value = GetTotalMatchesForCapture(aBackGroundWorkerObject.returnedComplexCaptureMatchObject[i].fileNamesHit);
                dgvResults.Rows[rowIndex].Cells[1].Value = aBackGroundWorkerObject.returnedComplexCaptureMatchObject[i];
            }
        }

     

        private string GetParametrizedRepFromGenericOne(ReplacementEvent replacementEvent, XNode xNode) {
            // may be a bug .... ex: with two view-selection under action performed
            List<NodeAndAttributeCouple> replaceableValues = GetReplacementParametersFromValue(replacementEvent.Value);
            string completedEvent = replacementEvent.Value;
            XElement element = XElement.Parse(xNode.ToString());
            for (int i = 0; i < replaceableValues.Count; i++) {
                if (string.Equals(replaceableValues[i].attrName, "TextValue", StringComparison.InvariantCultureIgnoreCase)) {
                    string textValue = element.DescendantsAndSelf(replaceableValues[i].nodeName).ElementAt(0).Value;
                    completedEvent = completedEvent.Replace("{TextValue}", textValue);
                } else {
                    string attrValue = element.DescendantsAndSelf(replaceableValues[i].nodeName).Attributes(replaceableValues[i].attrName).ElementAt(0).Value;
                    completedEvent = completedEvent.Replace("{" + replaceableValues[i].attrName + "}", attrValue);
                }

            }
            return completedEvent;
        }

        private string GetReplacementValueFromEvent(ReplacementEvent replacementEvent, XNode foundNode) {
            // may be a bug .... ex: with two view-selection under action performed
            string completedEvent = string.Empty;
            if (!string.Equals(replacementEvent.Value,"{EmptyString}")) {
                List<NodeAndAttributeCouple> replaceableValues = GetReplacementParametersFromValue(replacementEvent.Value);
                completedEvent = replacementEvent.Value;
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

        private void fillTree(List<string> filesToReplace) { // you allready had most of this
            // string[] drives = Environment.GetLogicalDrives();
            // foreach (string dr in drives) {
            TreeNode node = RecursiveDirWalk(txtInputDir.Text, filesToReplace);
            node.ImageIndex = node.SelectedImageIndex = 0; // drive icon
            node.Tag = txtInputDir.Text;
            tvAffectedFiles.Nodes.Add(node);
            //}
        }

        private TreeNode RecursiveDirWalk(string path, List<string> filesToReplace) {
            TreeNode node = new TreeNode(path.Substring(path.LastIndexOf('\\')));
            node.ImageIndex = node.SelectedImageIndex = 0; // dir icon
            node.Tag = path;
            string[] dirs = System.IO.Directory.GetDirectories(path);
            for (int t = 0; t < dirs.Length; t++) {
                node.Nodes.Add(RecursiveDirWalk(dirs[t], filesToReplace));
            }
            // Optional if you want files as well:
            string[] files = System.IO.Directory.GetFiles(path, CLEANUPFORM_EVENTS_SEARCH_PATTERN);
            for (int t = 0; t < files.Length; t++) {
                TreeNode tn = new TreeNode(System.IO.Path.GetFileName(files[t]));
                tn.Tag = files[t];
                tn.ImageIndex = tn.SelectedImageIndex = 1; // file icon
                if (filesToReplace.Contains(tn.Tag.ToString())) {
                    tn.ImageIndex = tn.SelectedImageIndex = 2;
                }
                node.Nodes.Add(tn);
            } // end of optional file part
            return node;
        }

        private void TextDiff(string sFile, string dFile) {
            _level = DiffEngineLevel.SlowPerfect;
            this.Cursor = Cursors.WaitCursor;
            DiffList_TextFile sLF = null;
            DiffList_TextFile dLF = null;
            try {
                sLF = new DiffList_TextFile(sFile);
                dLF = new DiffList_TextFile(dFile);
            } catch (Exception ex) {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "File Error");
                return;
            }
            try {
                double time = 0;
                DiffEngine de = new DiffEngine();
                time = de.ProcessDiff(sLF, dLF, _level);
                ArrayList rep = de.DiffReport();
                Results dlg = new Results(sLF, dLF, rep, time);
                // dlg.MdiParent = this.MdiParent;
                dlg.Text = Path.GetFileName(sFile);
                dlg.ShowDialog();
                dlg.Dispose();
            } catch (Exception ex) {
                this.Cursor = Cursors.Default;
                string tmp = string.Format("{0}{1}{1}***STACK***{1}{2}",
                                           ex.Message,
                                           Environment.NewLine,
                                           ex.StackTrace);
                MessageBox.Show(tmp, "Compare Error");
                return;
            }
            this.Cursor = Cursors.Default;
        }

        public static void Copy(string sourceDirectory, string targetDirectory) {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target) {
            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false) {
                Directory.CreateDirectory(target.FullName);
            }
            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.GetFiles()) {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }
            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories()) {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private void SetChildrenChecked(TreeNode treeNode, bool checkedState) {
            foreach (TreeNode item in treeNode.Nodes) {
                if (item.Checked != checkedState) {
                    item.Checked = checkedState;
                }
            }
        }

        #endregion

        #region Events

        private void button1_Click(object sender, EventArgs e) {

        }

        private void btnStart_Click(object sender, EventArgs e) {
            if (IsValidToStartSearching(txtInputDir.Text, currentlyUsedCaptures)) {
                btnStart.Enabled = false;
                outputDirectory = BACKUP_DIRECTORY + @"\output-" + DateTime.Now.Ticks + "-" + (new Random(DateTime.Now.Second)).Next(99999) + @"\" + Path.GetFileName(txtInputDir.Text);

                if (!Directory.Exists(outputDirectory)) {
                    Directory.CreateDirectory(outputDirectory);
                }

                Copy(txtInputDir.Text, outputDirectory);
                tvAffectedFiles.Nodes.Clear();

                bgwSearchForMatches = new BackgroundWorker();
                bgwSearchForMatches.WorkerReportsProgress = true;
                bgwSearchForMatches.DoWork += new DoWorkEventHandler(bgwSearchForMatches_DoWork);
                bgwSearchForMatches.ProgressChanged += new ProgressChangedEventHandler(bgwSearchForMatches_ProgressChanged);
                bgwSearchForMatches.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwSearchForMatches_RunWorkerCompleted);
                BackGroundWorkerObject backWorkerObject = new BackGroundWorkerObject();
                backWorkerObject.selectedCaptureEvents = currentlyUsedCaptures;

                string FolderToParse = string.Empty;

                pcProgress.Visible = true;
                pcProgress.Rotate = true;
                pcProgress.ForeColor = Color.DodgerBlue;
                FolderToParse = txtInputDir.Text;

                
          
                FileData[] files =  FastDirectoryEnumerator.GetFiles(FolderToParse,CLEANUPFORM_EVENTS_SEARCH_PATTERN, SearchOption.AllDirectories);
         
           
                  
                for (int i = 0; i < files.Length; i++) {
                	FileToParseObject fileToParse = new FileToParseObject(files[i].Path, false);
                    backWorkerObject.targetedFiles.Add(fileToParse);
                }
                bgwSearchForMatches.RunWorkerAsync(backWorkerObject);
                if (bgwSearchForMatches.IsBusy) {
                    pcProgress.Rotate = true;
                }
            }

        }

        private bool IsValidToStartSearching(string inputDir, List<AdvancedRecomendation> currentlyUsedCaptures) {
            if (string.IsNullOrEmpty(inputDir)) {
                FrontendUtils.ShowInformation("Input directory cannot be empty!", true);
                return false;
            } else if (!Directory.Exists(inputDir)) {
                FrontendUtils.ShowInformation("Input directory does not exist!", true);
                return false;
            } else if (currentlyUsedCaptures.Count < 1) {
                FrontendUtils.ShowInformation("No search patterns are selected!", true);
                return false;
            }
            return true;
        }

        private void bgwSearchForMatches_DoWork(object sender, DoWorkEventArgs e) {
            BackGroundWorkerObject bgWorkerObject = ((DoWorkEventArgs)e).Argument as BackGroundWorkerObject;

            // ComplexCaptureMatchObject complexCaptureMatchObject = new ComplexCaptureMatchObject();
            int Jcounter = 0;
            for (int i = 0; i < currentlyUsedCaptures.Count; i++) {
                ComplexCaptureMatchObject complexCaptureMatchObject = new ComplexCaptureMatchObject();

                complexCaptureMatchObject.captureEvent = Advanced_Recommendations.SelectAdvancedRecByIdAndIncrementUsage(currentlyUsedCaptures[i].CaptureEventId, currentlyUsedCaptures[i].captureEventUsageCount);

                for (int j = 0; j < bgWorkerObject.targetedFiles.Count; j++) {
                    string readText = string.Empty;
                    readText = FrontendUtils.ReadFile(bgWorkerObject.targetedFiles[j].fileName);
                    ParseTargetedFile(complexCaptureMatchObject.captureEvent, readText, complexCaptureMatchObject, bgWorkerObject.targetedFiles[j].fileName);
                    bgWorkerObject.targetedFiles[j].parsed = true;
                    bgwSearchForMatches.ReportProgress((int)Math.Round(((double)(((i) + (Jcounter))) / ((currentlyUsedCaptures.Count) * (bgWorkerObject.targetedFiles.Count + 1))) * 100, 0), bgWorkerObject);
                    Jcounter++;
                }
                bgWorkerObject.returnedComplexCaptureMatchObject.Add(complexCaptureMatchObject);
            }



            //for (int i = 0; i < bgWorkerObject.targetedFiles.Count; i++) {

            //    StartParsingInput(currentlyUsedCaptures, readText, fileName, complexCaptureMatchObject);

            //    bgWorkerObject.targetedFiles[i].parsed = true;
            //    bgWorkerObject.returnedComplexCaptureMatchObject.Add(complexCaptureMatchObject);
            //    bgwSearchForMatches.ReportProgress((int)Math.Round(((double)(i + 1) / bgWorkerObject.targetedFiles.Count) * 100, 0), bgWorkerObject);

            //}
            e.Result = bgWorkerObject;
        }

        private void lvAdvancedRules_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                //tag contains rec id
                //CaptureEvent capture = BackEndUtils.SelectAdvancedRecById((sender as ListView).SelectedItems[0].Tag);

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void lvAdvancedRules_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
            try {
                //tag contains rec id
                if ((sender as ListView).SelectedItems.Count != 0) {
                    //currentlySelectedEvent = BackEndUtils.SelectAdvancedRecById((sender as ListView).SelectedItems[0].Tag);
                    currentlySelectedEvent = currentlyLoadedEvents[Convert.ToInt32((sender as ListView).SelectedItems[0].Tag)];
                    SetupUiFromCapturePoint(currentlySelectedEvent);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        bool checkAndDoubleClickOnListViewMutex = false;

        private void chkUsed_CheckedChanged(object sender, EventArgs e) {
            try {
                if (!checkAndDoubleClickOnListViewMutex && ((sender as CheckBox) != null)) {
                    checkAndDoubleClickOnListViewMutex = true;
                    ChangeListViewItemCheckMode(lvAdvancedRules);
                    checkAndDoubleClickOnListViewMutex = false;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void lvAdvancedRules_MouseDoubleClick(object sender, MouseEventArgs e) {
            try {
                if (!checkAndDoubleClickOnListViewMutex && ((sender as ListView) != null)) {
                    checkAndDoubleClickOnListViewMutex = true;
                    ChangeListViewItemCheckMode(sender as ListView);
                    checkAndDoubleClickOnListViewMutex = false;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void ChangeListViewItemCheckMode(ListView listView) {
            //imageindex 0=> green
            //imageindex 1=> red
            if (listView.SelectedItems.Count > 0) {
                //lvAdvancedRules.SelectedItems[0].BackColor = lvAdvancedRules.SelectedItems[0].BackColor == Color.LightGreen ? Color.White : Color.LightGreen;
                System.Windows.Forms.ListViewItem selectedItem = listView.SelectedItems[0];
                selectedItem.ImageIndex = selectedItem.ImageIndex == 0 ? 1 : 0;

                if (selectedItem.ImageIndex == 0) {
                    currentlyUsedCaptures = AddCapturePointToList(currentlyUsedCaptures, currentlySelectedEvent);
                } else {
                    currentlyUsedCaptures = RemoveCapturePointFromList(currentlyUsedCaptures, currentlySelectedEvent.CaptureEventId);
                }
                //txtRuleName.Focus();
            }
        }

        private void bgwSearchForMatches_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            try {
                //e.ProgressPercentage;
                lblFoundNodesCound.Text = totalFoundNodes + "";
                pbPercentComplete.Value = e.ProgressPercentage;
            } catch (Exception ex) {
                throw;
            }
        }

        private void bgwSearchForMatches_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            try {
                pcProgress.Rotate = false;
                pcProgress.Clear();
                pcProgress.ForeColor = Color.White;


                pbPercentComplete.Visible = false;

                //dgvSearchResult.Visible = true;
                btnProceedToReplacement.Visible = true;
                btnProceedToReplacement.Focus();
                backGroundWorkerObject = e.Result as BackGroundWorkerObject;

                FillDatagridWithResults(backGroundWorkerObject);
                btnResetForm.Visible = true;

                DialogResult dialogResult = FrontendUtils.ShowConformation("Search completed, with " + lblFoundNodesCound.Text + " total hits!\n Proceed to replacement?");
                if (dialogResult == DialogResult.Yes) {
                    //REPLACEMENT_TOTAL_USAGE_COUNT = Advanced_Replacements.GetTotalAdvanceReplacementUsageCount();
                    SetupUiForReplacements();
                }

            } catch (Exception ex) {
                throw;
            }
        }

        private void dgvSearchResult_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                if (e.ColumnIndex == 3 && e.RowIndex > -1) {
                    ShowSearchDetailsForm form = new ShowSearchDetailsForm((dgvSearchResult[e.ColumnIndex, e.RowIndex].Value as BackGroundWorkerObject).returnedComplexCaptureMatchObject[e.RowIndex].captureEvent);
                    //form.MdiParent = this.MdiParent;
                    form.ShowDialog();
                    if (form.DialogResult == DialogResult.OK) {
                        (dgvSearchResult[e.ColumnIndex, e.RowIndex].Value as BackGroundWorkerObject).returnedComplexCaptureMatchObject[e.RowIndex].usedReplacementEvent = form.selectedReplacementEvent;
                        dgvSearchResult[e.ColumnIndex + 1, e.RowIndex].Value = true;
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnProceedToReplacement_Click(object sender, EventArgs e) {
            try {
                //testReplacements form = new testReplacements(backGroundWorkerObject);
                //form.MdiParent = this.MdiParent;
                //form.Show();
             //   REPLACEMENT_TOTAL_USAGE_COUNT = Advanced_Replacements.GetTotalAdvanceReplacementUsageCount();
                SetupUiForReplacements();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnResetForm_Click(object sender, EventArgs e) {
            try {
                btnStart.Enabled = true;

                currentlySelectedEvent = new AdvancedRecomendation();
                currentlyUsedCaptures = new List<AdvancedRecomendation>();
                backGroundWorkerObject = new BackGroundWorkerObject();
                totalFoundNodes = 0;

                lblFoundNodesCound.Text = 0 + "";

                dgvSearchResult.Rows.Clear();
                dgvSearchResult.Visible = false;

                btnProceedToReplacement.Visible = false;
                btnResetForm.Visible = false;

                pbPercentComplete.Visible = true;
                pbPercentComplete.Value = 0;


                LoadAvailableAdvancedRecommendations();
                pcProgress.Visible = false;
                pcProgress.Clear();
                pcProgress.Rotate = false;

                DataSet AllCategories = new DataSet();
                DataSet AllAdvancedRecs = new DataSet();

                lvAdvancedRules.Focus();


                txtRuleDescription.ResetText();
                txtRuleName.ResetText();

                srcPopularityAdded.m_hoverStar = 0;
                srcPopularityAdded.m_selectedStar = 0;
                srcPopularityAdded.Invalidate();

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void dgvResults_CellClick(object sender, DataGridViewCellEventArgs e) {
            try {
                pnlAvailableReplacements.Controls.Clear();
                if (e.RowIndex >=0) {               	
	                ComplexCaptureMatchObject complexCaptureMatchObject = dgvResults[1, e.RowIndex].Value as ComplexCaptureMatchObject;
	                List<ReplacementEvent> availableReplacements = Advanced_Replacements.GetAvailableReplacementsByCaptureId(complexCaptureMatchObject.captureEvent.CaptureEventId, BackEndUtils.GetSqlConnection());
	                int highestPopularity = -1;
	                
	                int totalUsageCount = 1;
	                
	                for (int j = 0; j < availableReplacements.Count; j++) {
	                	totalUsageCount = totalUsageCount + availableReplacements[j].usageCount;
	                }
	                
	                for (int i = 0; i < availableReplacements.Count; i++) {
	                    CustomizedReplacement customizedReplacement = new CustomizedReplacement();
	                    customizedReplacement.Click += new EventHandler(customizedReplacement_Click);
	                    customizedReplacement.Location = new System.Drawing.Point(3, 3 + (176 * (i)) + 6);
	                    customizedReplacement.Name = availableReplacements[i].name;
	                    customizedReplacement.repDescription = availableReplacements[i].description;
	                    customizedReplacement.repName = availableReplacements[i].name;
	                    customizedReplacement.repReplacement = availableReplacements[i].Value;
	                    customizedReplacement.replacementEvent = availableReplacements[i];
	                    customizedReplacement.Size = new System.Drawing.Size(558, 170);
	                    customizedReplacement.TabIndex = i;
	                    customizedReplacement.Visible = true;
	                    customizedReplacement.popularity = (int)(((double)availableReplacements[i].usageCount / totalUsageCount) * 20);
	                    customizedReplacement.rbSelectedReplacement.CheckedChanged += new EventHandler(rbSelectedReplacement_CheckedChanged);
	                    customizedReplacement.MouseClick += new MouseEventHandler(rbSelectedReplacement_CheckedChanged);
	                    pnlAvailableReplacements.Controls.Add(customizedReplacement);
	
	                    // this checks the replacement with highest popularity
	                    if (customizedReplacement.popularity > highestPopularity) {
	                        customizedReplacement.rbSelectedReplacement.Checked = true;
	                        highestPopularity = customizedReplacement.popularity;
	                        complexCaptureMatchObject.usedReplacementEvent = customizedReplacement.replacementEvent;
	                    }
	                }
	                pnlAvailableReplacements.Focus();
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void rbSelectedReplacement_CheckedChanged(object sender, EventArgs e) {
            try {
                RadioButton radio = (sender as RadioButton);
                if (radio != null) {
                    if (radio.Checked) {
                        for (int i = 0; i < pnlAvailableReplacements.Controls.Count; i++) {
                            if (pnlAvailableReplacements.Controls[i] is CustomizedReplacement) {
                                if (((CustomizedReplacement)pnlAvailableReplacements.Controls[i]).rbSelectedReplacement != radio) {
                                    ((CustomizedReplacement)pnlAvailableReplacements.Controls[i]).rbSelectedReplacement.Checked = false;
                                }
                            }
                        }
                        radio.Checked = true;
                    }
                }


                //if (isNeeded) {
                //    isNeeded = false;
                //    for (int i = 0; i < pnlAvailableReplacements.Controls.Count; i++) {
                //        if (pnlAvailableReplacements.Controls[i] is CustomizedReplacement) {
                //            ((CustomizedReplacement)pnlAvailableReplacements.Controls[i]).rbSelectedReplacement.Checked = false;
                //        }
                //    }
                //    RadioButton radio = (sender as RadioButton);
                //    if (radio != null) {
                //        radio.Checked = true;
                //        isNeeded = true;
                //        (dgvResults.SelectedRows[0].Cells[1].Value as ComplexCaptureMatchObject).usedReplacementEvent = ((sender as RadioButton).Parent as CustomizedReplacement).replacementEvent;
                //    }
                //}
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void customizedReplacement_Click(object sender, EventArgs e) {


        }

        private void btnBackToSearch_Click(object sender, EventArgs e) {
            try {
                gbSelectedCapture.Visible = true;

                gbOperation.Visible = true;

                gbSearchResults.Visible = true;

                gbAdvancedRules.Visible = true;

                gbAvailableReplacements.Visible = false;

                gbSearchResults.Visible = false;

                gbAffectedFiles.Visible = false;

                btnStart.Visible = true;

                btnResetForm.Visible = true;

                lblFoundNodesCound.Visible = true;

                btnBackToSearch.Location = btnResetForm.Location;

                btnBackToSearch.Visible = false;

                btnStartReplacementOp.Location = btnProceedToReplacement.Location;

                btnStartReplacementOp.Visible = false;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnStartReplacementOp_Click(object sender, EventArgs e) {
            tvAffectedFiles.Nodes.Clear();
            string inputDirectory = txtInputDir.Text;
            List<string> changedFiles = new List<string>();
            try {
                gbAvailableReplacements.Visible = false;
                gbAffectedFiles.Size = gbAvailableReplacements.Size;
                gbAffectedFiles.Location = gbAvailableReplacements.Location;
                // check replacement isnt null
                string oldReadFile = string.Empty;
                Regex regexForNewLines = new Regex("(\\r)*\\n(\\s)*");
                List<ComplexCaptureMatchObject> capturesAndReplacements = new List<ComplexCaptureMatchObject>();
                for (int i = 0; i < dgvResults.Rows.Count; i++) {
                    capturesAndReplacements.Add(dgvResults.Rows[i].Cells[1].Value as ComplexCaptureMatchObject);
                }

                for (int i = 0; i < capturesAndReplacements.Count; i++) {
                    if (capturesAndReplacements[i].usedReplacementEvent != null ) {
                        if (capturesAndReplacements[i].captureEvent.captureEventCategory != (int)AdvancedRecomendationCategory.Verbal) {
                            for (int j = 0; j < capturesAndReplacements[i].fileNamesHit.Count; j++) {
                                string readText = FrontendUtils.ReadFile(capturesAndReplacements[i].fileNamesHit[j].fileName);
                                readText = XDocument.Parse(readText).ToString();

                                readText = regexForNewLines.Replace(readText, "\n   ");
                                oldReadFile = FrontendUtils.FormatXml(readText);
                                for (int k = 0; k < capturesAndReplacements[i].fileNamesHit[j].matchedNodes.Count; k++) {
                                    string parametrizedReplacement = GetReplacementValueFromEvent(capturesAndReplacements[i].usedReplacementEvent, capturesAndReplacements[i].fileNamesHit[j].matchedNodes[k]);
                                    parametrizedReplacement = regexForNewLines.Replace(parametrizedReplacement, "\n   ");
                                    string foundNodes = capturesAndReplacements[i].fileNamesHit[j].matchedNodes[k].ToString();
                                    foundNodes = regexForNewLines.Replace(foundNodes, "\n   ");

                                    readText = readText.Replace(foundNodes, parametrizedReplacement);

                                }

                                readText = FrontendUtils.FormatXml(readText);
                                if (!string.Equals(oldReadFile, readText)) {
                                    changedFiles.Add(capturesAndReplacements[i].fileNamesHit[j].fileName);
                                    string fileSystemPathSource = capturesAndReplacements[i].fileNamesHit[j].fileName.Replace(inputDirectory, outputDirectory);
                                    FrontendUtils.WriteFile(fileSystemPathSource, oldReadFile);
                                }
                                FrontendUtils.WriteFile(capturesAndReplacements[i].fileNamesHit[j].fileName, readText);
                            }
                        }
                    }
                }
				
                
                
                gbAffectedFiles.Visible = true;
                fillTree(changedFiles);
                tvAffectedFiles.ExpandAll();
                FrontendUtils.ShowInformation("Replacement done!", false);
                
				
			                
                					
                	Advanced_Replacements.IncrementReplacementsListUsageById(capturesAndReplacements);
                
               
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void tvAffectedFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            try {
                string nodepath = tvAffectedFiles.SelectedNode.FullPath;
                string fileSystemPathReached = Directory.GetParent(txtInputDir.Text) + tvAffectedFiles.SelectedNode.FullPath;
                if (File.Exists(fileSystemPathReached)) {
                    string fileSystemPathSource = Directory.GetParent(outputDirectory) + tvAffectedFiles.SelectedNode.FullPath;

                    TextDiff(fileSystemPathSource, fileSystemPathReached);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void SecondLevelCleanupForm_Load(object sender, EventArgs e) {
            try {
                CLEANUPFORM_EVENTS_SEARCH_PATTERN = Application_Settings.GetAppConfigValueByKey(Application_Settings.ApplicationConfigKeys.CleanUpEventsSearchPattern) as string;
                if (!string.IsNullOrEmpty(MonitorObject.username)) {
                    MonitorObject.formAndAccessTime.Add(new FormAndAccessTime(this.Name, DateTime.Now));
                }

                BACKUP_DIRECTORY = Path.GetTempPath() + @"\Backup-" + DateTime.Now.Ticks;
                if (!Directory.Exists(BACKUP_DIRECTORY)) {
                    Directory.CreateDirectory(BACKUP_DIRECTORY);
                }
                LoadAvailableAdvancedRecommendations();
                pcProgress.Visible = false;
                pcProgress.Clear();
                pcProgress.Rotate = false;

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void tvAffectedFiles_AfterCheck(object sender, TreeViewEventArgs e) {
            try {
                SetChildrenChecked(e.Node, e.Node.Checked);

                if (e.Node.Parent != null) {
                    bool setParentChecked = true;
                    foreach (TreeNode node in e.Node.Parent.Nodes) {
                        if (node.Checked != e.Node.Checked) {
                            setParentChecked = false;
                            break;
                        }
                    }
                    if (setParentChecked) {
                        e.Node.Parent.Checked = e.Node.Checked;
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void lvAdvancedRules_KeyPress(object sender, KeyPressEventArgs e) {
            try {
                if (e.KeyChar == ' ') {
                    if ((sender as ListView) != null) {
                        ChangeListViewItemCheckMode(sender as ListView);
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        #endregion

        private void btnClearLvAdvancedRulesSelections_Click(object sender, EventArgs e) {
            try {
                ClearAllAdvancedRules();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void ClearAllAdvancedRules() {
            currentlyUsedCaptures = new List<AdvancedRecomendation>();
            LoadAvailableAdvancedRecommendations();
        }

        private void btnSelectAllLVAdvancedRulesItems_Click(object sender, EventArgs e) {
            try {
                SelectAllAvailableAdvancedRules();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void SelectAllAvailableAdvancedRules() {
            //0 => green
            //1 => red
            foreach (System.Windows.Forms.ListViewItem item in lvAdvancedRules.Items) {
                item.ImageIndex = 0;
                //currentlySelectedEvent = BackEndUtils.SelectAdvancedRecById(item.Tag);
                currentlySelectedEvent = currentlyLoadedEvents[Convert.ToInt32(item.Tag)];
                currentlyUsedCaptures = AddCapturePointToList(currentlyUsedCaptures, currentlySelectedEvent);
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
    }
}
