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
using System.Data.SqlServerCe;
using System.Text.RegularExpressions;
using XmlParsersAndUi.Classes;
using Automation.Common.Utils;
using Automation.Common;
using Automation.Backend;
using Automation.Common.Classes.Monitoring;

namespace XmlParsersAndUi.Forms {
    public partial class MacroConverterConfForm : Form {
        
        public MacroConverterConfForm() {
            InitializeComponent();
        }

        private void MacroConverter_Load(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(MonitorObject.username)) {
                    MonitorObject.formAndAccessTime.Add(new FormAndAccessTime(this.Name, DateTime.Now));
                }
            } catch (Exception) {

            }
            LoadAvailableARtoList();
            SetAllCombos();
            BindCombos();
            if (lbAdvancedCE.Items.Count > 0) {
                lbAdvancedCE.SelectedIndex = 0;
            }
        }

        XDocument xmlDocument;
        //this list will contain the capture event
        List<CustomTreeNode> captureEventNodes = new List<CustomTreeNode>();


        #region Methods

        private void ParseEvent(string eventMacro) {
            xmlDocument = XDocument.Parse(eventMacro);
            populateTreeviewSingleEvent(xmlDocument.ToString());
            //IEnumerable<XElement> childred = 
            //       object patterns = xmlDocument.XPathEvaluate(@"MXClientScript\Events");
            IEnumerable<XElement> children = xmlDocument.Elements();
        }

        private void ParseEventFromDatabase(AdvancedRecomendation captureEvent) {
            xmlDocument = XDocument.Parse(captureEvent.CaptureEventEventText);
            populateTreeviewSingleEventFromDatabase(xmlDocument.ToString(), captureEvent);
            //IEnumerable<XElement> childred = 
            //       object patterns = xmlDocument.XPathEvaluate(@"MXClientScript\Events");
            IEnumerable<XElement> children = xmlDocument.Elements();
        }

        private void populateTreeviewSingleEventFromDatabase(string document, AdvancedRecomendation captureEvent) {
            try {
                //Just a good practice -- change the cursor to a 
                //wait cursor while the nodes populate
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(document);
                this.Cursor = Cursors.WaitCursor;
                //First, we'll load the Xml document                   
                //Now, clear out the treeview, 
                //and add the first (root) node
                tvOutput.Nodes.Clear();//captureEvent.CaptureEventCapturePointsList[i]
                CustomTreeNode customRootNode = new CustomTreeNode(xDoc.DocumentElement.Name, xDoc.DocumentElement.Attributes);
                customRootNode.isNodeUsed = true;
                customRootNode.customizedAttributeCollection = captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection;
                tvOutput.Nodes.Add(customRootNode);
                TreeNode tNode = new TreeNode();
                tNode = (TreeNode)tvOutput.Nodes[0];
                //We make a call to addTreeNode, 
                //where we'll add all of our nodes
                addTreeNodeForSingleEventFromDatabase(xDoc.DocumentElement, tNode, captureEvent, 1, 0, 0, 0);
                //Expand the treeview to show all nodes
                tvOutput.ExpandAll();
            } catch (XmlException xExc)
                //Exception is thrown is there is an error in the Xml
             {
                FrontendUtils.ShowError(xExc.Message, xExc);
            } catch (Exception ex) //General exception
             {
                FrontendUtils.ShowError(ex.Message, ex);
            } finally {
                this.Cursor = Cursors.Default; //Change the cursor back
            }
        }

        private void addTreeNodeForSingleEventFromDatabase(XmlNode xmlNode, TreeNode treeNode, AdvancedRecomendation captureEvent, int level, int index, int parentLevel, int parentIndex) {
            int newParentLevel = 0;
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes) //The current node has children
                {
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0, j = 0; x <= xNodeList.Count - 1; x++, j++)
                //Loop through the child nodes
                 {
                    xNode = xmlNode.ChildNodes[x];
                    if (xNode.NodeType != XmlNodeType.Text) {
                        CustomTreeNode customTreeNode = new CustomTreeNode(xNode.Name, xNode.Attributes);
                        int currentIndex = j;
                        customTreeNode = GetRespectiveCapturePoint(customTreeNode, captureEvent, xNode, currentIndex, level, parentIndex, parentLevel);
                        treeNode.Nodes.Add(customTreeNode);
                        //nodeIncludedText
                        tNode = treeNode.Nodes[j];
                        newParentLevel = level;
                        int newParentIndex = currentIndex;
                        if (xNode.HasChildNodes) {
                            //addTreeNodeForSingleEventFromDatabase(xNode, tNode, captureEvent, level + 1, 0, newParentIndex, newParentLevel);
                            int indextElementTypeOnly = 0;
                            for (int i = 0; i < xNode.ChildNodes.Count; i++) {
                                XmlNode childNode = xNode.ChildNodes[i];
                                if (childNode.NodeType != XmlNodeType.Text) {
                                    
                                    customTreeNode = new CustomTreeNode(childNode.Name, childNode.Attributes);
                                    currentIndex = i;
                                    customTreeNode = GetRespectiveCapturePoint(customTreeNode, captureEvent, childNode, indextElementTypeOnly, level + 1, j, level);
                                    tNode.Nodes.Add(customTreeNode);
                                    indextElementTypeOnly++;
                                }
                            }
                        }
                    } else {
                        j = x - 1;
                    }
                }

            } else { //No children, so add the outer xml (trimming off whitespace)
                // treeNode.Text = xmlNode.Name;
                // treeNode.Text = xmlNode.Attributes["name"].Value;
                treeNode.Text = xmlNode.Attributes["name"] == null ? xmlNode.Name : xmlNode.Attributes["name"].Value;
            }
        }




        List<string> captureNodesSelectedNames = new List<string>();

        private CustomTreeNode GetRespectiveCapturePoint(CustomTreeNode customTreeNode, AdvancedRecomendation captureEvent, XmlNode xNode, int index, int level, int parentIndex, int parentLevel) {
            for (int i = 1; i < captureEvent.CaptureEventCapturePointsList.Count; i++) {
                if (captureEvent.CaptureEventCapturePointsList[i].nodeIndex == index &&
                    captureEvent.CaptureEventCapturePointsList[i].nodeLevel == level &&
                    captureEvent.CaptureEventCapturePointsList[i].parentIndex == parentIndex &&
                    captureEvent.CaptureEventCapturePointsList[i].parentLevel == parentLevel) {
                    if (string.Equals(captureEvent.CaptureEventCapturePointsList[i].Text, xNode.Name)) {
                        if ((captureNodesSelectedNames.Count < captureEvent.CaptureEventCapturePointsList.Count - 1) || (!captureNodesSelectedNames.Contains(xNode.Name))) {
                            customTreeNode.customizedAttributeCollection = captureEvent.CaptureEventCapturePointsList[i].customizedAttributeCollection;
                            customTreeNode.isNodeUsed = captureEvent.CaptureEventCapturePointsList[i].isNodeUsed;
                            if ((level == 2) && (!string.Equals(captureNodesSelectedNames[captureNodesSelectedNames.Count - 1], xNode.Name))) {
                                captureNodesSelectedNames.Add(xNode.Name);
                            } else if (level < 2) {
                                captureNodesSelectedNames.Add(xNode.Name);
                            }
                        }
                    }
                }
            }
            return customTreeNode;
        }

        private bool ValidatdByCheckingParentIndexAndUsage(List<CustomTreeNode> captureEventCapturePointsList, CustomTreeNode customTreeNodeCapturePoint, int parentIndex) {

            for (int i = 0; i < captureEventCapturePointsList.Count; i++) {
                if (!string.IsNullOrEmpty(customTreeNodeCapturePoint.parentNodeText)) {
                    if (string.Equals(customTreeNodeCapturePoint.parentNodeText, captureEventCapturePointsList[i].Text)) {
                        if (!captureEventCapturePointsList[i].isNodeUsed) {
                            return false;
                        } else if (captureEventCapturePointsList[i].Index != parentIndex) {
                            return false;
                        }
                    }
                }

            }

            return true;
        }

        private void populateTreeviewSingleEvent(string document) {
            try {
                //Just a good practice -- change the cursor to a 
                //wait cursor while the nodes populate
                XmlDocument xDoc = new XmlDocument();
                xDoc.LoadXml(document);
                this.Cursor = Cursors.WaitCursor;
                //First, we'll load the Xml document                   
                //Now, clear out the treeview, 
                //and add the first (root) node
                tvOutput.Nodes.Clear();
                tvOutput.Nodes.Add(new CustomTreeNode(xDoc.DocumentElement.Name, xDoc.DocumentElement.Attributes));
                TreeNode tNode = new TreeNode();
                tNode = (TreeNode)tvOutput.Nodes[0];
                //We make a call to addTreeNode, 
                //where we'll add all of our nodes
                addTreeNodeForSingleEvent(xDoc.DocumentElement, tNode);
                //Expand the treeview to show all nodes
                tvOutput.ExpandAll();
            } catch (XmlException xExc)
                //Exception is thrown is there is an error in the Xml
             {
                FrontendUtils.ShowError(xExc.Message, xExc);
            } catch (Exception ex) //General exception
             {
                FrontendUtils.ShowError(ex.Message, ex);
            } finally {
                this.Cursor = Cursors.Default; //Change the cursor back
            }
        }

        //This function is called recursively until all nodes are loaded
        private void addTreeNodeForSingleEvent(XmlNode xmlNode, TreeNode treeNode) {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList xNodeList;
            if (xmlNode.HasChildNodes) //The current node has children
                {
                xNodeList = xmlNode.ChildNodes;
                for (int x = 0, j = 0; x <= xNodeList.Count - 1; x++, j++)
                //Loop through the child nodes
                 {
                    xNode = xmlNode.ChildNodes[x];
                    if (xNode.NodeType != XmlNodeType.Text) {
                        CustomTreeNode customTreeNode = new CustomTreeNode(xNode.Name, xNode.Attributes);
                        treeNode.Nodes.Add(customTreeNode);
                        //nodeIncludedText
                        tNode = treeNode.Nodes[j];
                        addTreeNodeForSingleEvent(xNode, tNode);
                    } else {
                        j = x - 1;
                    }
                }
            } else //No children, so add the outer xml (trimming off whitespace)
                // treeNode.Text = xmlNode.Name;
                // treeNode.Text = xmlNode.Attributes["name"].Value;
                treeNode.Text = xmlNode.Attributes["name"] == null ? xmlNode.Name : xmlNode.Attributes["name"].Value;
        }

        private void PopulateDgvWithAttributes() {
            dgvAttributes.Rows.Clear();
            CustomTreeNode node = (CustomTreeNode)tvOutput.SelectedNode;
            if (node.Attributes != null) {
                for (int i = 0; i < node.Attributes.Count; i++) {
                    int rowIndex = dgvAttributes.Rows.Add();
                    bool found = false;

                    for (int j = 0; j < node.customizedAttributeCollection.Count; j++) {
                        if (string.Equals(node.customizedAttributeCollection[j].attrName, node.Attributes[i].Name)) {
                            dgvAttributes.Rows[rowIndex].Cells[0].Value = node.customizedAttributeCollection[j].isUsed;
                            dgvAttributes.Rows[rowIndex].Cells[1].Value = node.customizedAttributeCollection[j].attrName;
                            dgvAttributes.Rows[rowIndex].Cells[2].Value = node.customizedAttributeCollection[j].attrValue;
                            found = true;
                        }
                    }
                    if (!found) {
                        dgvAttributes.Rows[rowIndex].Cells[0].Value = false;
                        dgvAttributes.Rows[rowIndex].Cells[1].Value = node.Attributes[i].Name;
                        dgvAttributes.Rows[rowIndex].Cells[2].Value = node.Attributes[i].Value;
                    }
                }
            }
        }

        private static void TestConnections() {
            SqlCeConnection sqlConnection1 = new SqlCeConnection();
            sqlConnection1.ConnectionString = "Data Source = D:\\Recommendations.sdf";

            //SqlCeCommand cmd = new SqlCeCommand();
            //cmd.CommandType = System.Data.CommandType.Text;
            //cmd.CommandText = "INSERT [Employee Table] (SSN, FirstName) VALUES ('555-23-4322', 'Tim')";
            //cmd.Connection = sqlConnection1;

            try {
                sqlConnection1.Open();
            } catch (Exception ex) {

                throw;
            }
            //cmd.ExecuteNonQuery();
            sqlConnection1.Close();
        }

        private void SaveUpdatedAttributes() {
            CustomTreeNode node = (tvOutput.SelectedNode as CustomTreeNode);
            for (int i = 0; i < node.customizedAttributeCollection.Count; i++) {
                node.customizedAttributeCollection[i].isUsed = false;
            }
            if (dgvAttributes.Rows.Count > 0) {
                foreach (DataGridViewRow row in dgvAttributes.Rows) {
                    if ((bool)row.Cells[0].Value == true) {
                        int attrIndex = GetCustomizedAttrIndex(node.customizedAttributeCollection, row.Cells[1]);
                        if (attrIndex == -1) {
                            int normalAttrIndex = GetNormalAttrIndex(node.customizedAttributeCollection, row.Cells[1]);
                            if (normalAttrIndex != -1) {
                                node.customizedAttributeCollection[normalAttrIndex].isUsed = true;
                                node.customizedAttributeCollection[normalAttrIndex].attrName = row.Cells[1].Value.ToString();
                                node.customizedAttributeCollection[normalAttrIndex].attrValue = row.Cells[2].Value.ToString().Trim();
                                node.Attributes[(string)row.Cells[1].Value].Value = row.Cells[2].Value.ToString().Trim();
                            } else {
                                CustomizedAttribute attr = new CustomizedAttribute(node.Attributes[row.Cells[1].Value.ToString()], true);
                                row.Cells[0].Value = true;
                                attr.attrName = row.Cells[1].Value.ToString().Trim();
                                attr.attrValue = row.Cells[2].Value.ToString().Trim();
                                node.customizedAttributeCollection.Add(attr);
                            }
                        } else {
                            (node.customizedAttributeCollection[attrIndex]).isUsed = true;
                            (node.customizedAttributeCollection[attrIndex]).attrValue = row.Cells[2].Value.ToString().Trim();
                            node.Attributes[(string)row.Cells[1].Value].Value = row.Cells[2].Value.ToString().Trim();
                        }
                    } else {
                        int attrIndex = GetCustomizedAttrIndex(node.customizedAttributeCollection, row.Cells[1]);
                        if (attrIndex != -1) {
                            (node.customizedAttributeCollection[attrIndex]).isUsed = false;
                        }
                    }
                }
            }
        }

        private int GetRegAttrIndex(List<CustomizedAttribute> list, DataGridViewCell dataGridViewCell) {
            int foundIndex = 0;
            for (int i = 0; i < list.Count; i++) {
                if (list[i].attribute != null) {
                    if (string.Equals(list[i].attribute.Name, dataGridViewCell.Value)) {
                        foundIndex = i;
                        return i;
                    }
                }
            }
            return foundIndex;
        }

        private int GetNormalAttrIndex(List<CustomizedAttribute> xmlAttributeCollection, DataGridViewCell dataGridViewCell) {
            int foundIndex = -1;
            for (int i = 0; i < xmlAttributeCollection.Count; i++) {
                if (xmlAttributeCollection[i].attribute != null) {
                    if (string.Equals(xmlAttributeCollection[i].attribute.Name, dataGridViewCell.Value)) {
                        foundIndex = i;
                        return i;
                    }
                }
            }
            return foundIndex;
        }

        private int GetCustomizedAttrIndex(List<CustomizedAttribute> list, DataGridViewCell dataGridViewCell) {
            int foundIndex = -1;
            for (int i = 0; i < list.Count; i++) {
                if (string.Equals(list[i].attrName, dataGridViewCell.Value)) {
                    foundIndex = i;
                    return i;
                }
            }
            return foundIndex;
        }

        void RecurResetTag(TreeNodeCollection nodeCollection) {
            if (nodeCollection != null) {
                for (int i = 0; i < nodeCollection.Count; i++) {
                    nodeCollection[i].Tag = null;
                    RecurResetTag(nodeCollection[i].Nodes);
                }
            }
        }

        void Recur(TreeNodeCollection nodeCollection) {
            if (nodeCollection != null) {
                for (int i = 0; i < nodeCollection.Count; i++) {
                    if (nodeCollection[i].Checked) {
                        (nodeCollection[i] as CustomTreeNode).isNodeUsed = true;
                        captureEventNodes.Add(nodeCollection[i] as CustomTreeNode); //(1)                        
                    } else {
                        (nodeCollection[i] as CustomTreeNode).isNodeUsed = false;
                    }
                    Recur(nodeCollection[i].Nodes);
                }
            }
        }
        #endregion

        #region Events

        private void tvOutput_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                PopulateDgvWithAttributes();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void tvOutput_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            try {
                if (tvOutput.SelectedNode == null) {
                    return;
                }
                SaveUpdatedAttributes();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnAddCaptureEvent_Click(object sender, EventArgs e) {
            try {                
                if (eventParsed) {
                    string ruleName = txtAOName.Text.Trim();
                    string ruleDescription = txtAODescription.Text.Trim();
                    string ruleEventIn = txtAOEventIn.Text.Trim();
                    string replacementText = txtTextValue.Text.Trim();
                    if (IsValidToAddRule(ruleName, ruleDescription, ruleEventIn, replacementText, tvOutput.Nodes[0])) {
                        Recur(tvOutput.Nodes);
                        SaveUpdatedAttributes();
                        AdvancedRecomendation captureEvent = new AdvancedRecomendation(ruleName, ruleDescription, ruleEventIn, captureEventNodes);
                        captureEvent.captureEventCategory = Convert.ToInt32(cboCaptureType.SelectedValue);
                        captureEvent.captureEventUsageCount = 0;
                        ReplacementEvent replacementEvent = new ReplacementEvent("Replacement-" + ruleName, "Repalcement-" + ruleDescription, replacementText, 1, 0, FrontendUtils.LoggedInUserId);
                        Advanced_Recomendations_TextConv.InsertCaptureEventForTextConversion(captureEvent, replacementEvent);
                        FrontendUtils.ShowInformation("Capture event inserted successfully!",false);
                    }
                    LoadAvailableARtoList();
                    SetAllCombos();
                    BindCombos();
                    lbAdvancedCE.Select();
                } else {
                    FrontendUtils.ShowInformation("Please [Parse] the input event before proceeding",true);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private bool IsValidToAddRule(string ruleName, string ruleDescription, string ruleEventIn, string replacement, TreeNode parentNode) {
            if (string.IsNullOrEmpty(ruleName)) {
                FrontendUtils.ShowInformation("Rule name cannot be empty!",true);
                return false;
            } else if (string.IsNullOrEmpty(ruleDescription)) {
                FrontendUtils.ShowInformation("Description cannot be empty!", true);
                return false;
            } else if (string.IsNullOrEmpty(ruleEventIn)) {
                FrontendUtils.ShowInformation("Event in cannot be empty!", true);
                return false;
            }
            if (!IsValidXml(ruleEventIn)) {
                FrontendUtils.ShowInformation("Event must be a valid xml!", true);
                return false;
            }
            if (string.IsNullOrEmpty(replacement)) {
                FrontendUtils.ShowInformation("A replacement must be supplied!", true);
                return false;
            }
            if (!parentNode.Checked) {
                FrontendUtils.ShowInformation("Event main node should be checked!", true);
                return false;
            }
            return true;
        }

        private void SetupAdvancedRecForm_Load(object sender, EventArgs e) {
            try {
                LoadAvailableARtoList();
                SetAllCombos();
                BindCombos();
                lbAdvancedCE.SelectedIndex = 0;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void BindCombos() {
            string displayMember = "categoryName";
            string valueMember = "id";
            DataTable captureDatatable = Advanced_Recommendation_Categories.GetAllCaptureCategoriesAsDataTable();
            FrontendUtils.BindCombo(cboCaptureType, captureDatatable, displayMember, valueMember);
        }

        private void SetAllCombos() {
            foreach (Control control in Controls) {
                CheckControls(control);
            }
        }

        private void CheckControls(Control control) {
            if (control is ComboBox) {
                if (((ComboBox)control).DropDownStyle == ComboBoxStyle.DropDownList) {
                    ((ComboBox)control).SelectedIndex = 0;
                }
            }
            if (control.HasChildren) {
                foreach (Control childControl in control.Controls) {
                    if (childControl is ComboBox) {
                        if (((ComboBox)childControl).DropDownStyle == ComboBoxStyle.DropDownList) {
                            ((ComboBox)childControl).SelectedIndex = 0;
                        }
                    }
                    CheckControls(childControl);
                }
            }
        }

        #endregion

        private void LoadAvailableARtoList() {
            lbAdvancedCE.Items.Clear();
            List<AdvancedRecomendation> allCaptureEvents = Advanced_Recomendations_TextConv.GetAllAdvancedRecsAsListTextConv();
            for (int i = 0; i < allCaptureEvents.Count; i++) {
                lbAdvancedCE.Items.Add(allCaptureEvents[i]);
            }
        }

        private void InterpretCaptureEvent(AdvancedRecomendation captureEvent) {
            ParseEventFromDatabase(captureEvent);
            CustomTreeNode[] customArray = new CustomTreeNode[captureEvent.CaptureEventCapturePointsList.Count];
            captureEvent.CaptureEventCapturePointsList.CopyTo(customArray);
            RestoreSelectedCapturePoints(customArray, tvOutput.Nodes);
        }

        private void RestoreSelectedCapturePoints(CustomTreeNode[] treeNodeNodes, TreeNodeCollection collection) {
            if (collection != null) {
                for (int i = 0; i < collection.Count; i++) {
                    OperateOnTreeNode(collection[i] as CustomTreeNode, treeNodeNodes);
                }

            }
        }

        private void OperateOnTreeNode(CustomTreeNode customTreeNode, CustomTreeNode[] treeNodeNodes) {
            if (!customTreeNode.isNodeUsed) {
                customTreeNode.Checked = false;
            } else {
                customTreeNode.Checked = true;
            }

            for (int j = 0; (j < treeNodeNodes.Length) && (treeNodeNodes[j].isNodeUsed); j++) {
                if (string.Equals(treeNodeNodes[j].Text, customTreeNode.Text) && !treeNodeNodes[j].nodeVisited) {
                    //if (treeNodeNodes[j].isNodeUsed) {
                    //    customTreeNode.Checked = true;
                    //}
                    treeNodeNodes[j].nodeVisited = true;
                    for (int k = 0; k < treeNodeNodes[j].customizedAttributeCollection.Count; k++) {
                        CustomizedAttribute customAttrFromDB = treeNodeNodes[j].customizedAttributeCollection[k];
                        for (int l = 0; l < customTreeNode.customizedAttributeCollection.Count; l++) {
                            CustomizedAttribute customAttrFromTree = customTreeNode.customizedAttributeCollection[l];
                            if (customAttrFromDB.attribute == null && customAttrFromTree.attribute != null) {
                                if (string.Equals(customAttrFromTree.attribute.Name, customAttrFromDB.attrName)) {
                                    customAttrFromTree.attrName = customAttrFromDB.attrName;
                                    customAttrFromTree.attrValue = customAttrFromDB.attrValue;
                                }
                            }
                        }
                    }
                }
            }
            if (customTreeNode.Nodes.Count > 0) {
                RestoreSelectedCapturePoints(treeNodeNodes, customTreeNode.Nodes);
            }

        }

        private void RestoreSelectedSiblingCapturePoints(CustomTreeNode[] Array, TreeNodeCollection collection) {
            if (collection != null) {
                for (int i = 0; i < collection.Count; i++) {
                    collection[i].Checked = false;
                    for (int j = 0; (j < Array.Length) && (Array[j].isNodeUsed); j++) {
                        if (string.Equals(Array[j].Text, collection[i].Text) && !Array[j].nodeVisited) {
                            collection[i].Checked = true;
                            Array[j].nodeVisited = true;
                            for (int k = 0; k < Array[j].customizedAttributeCollection.Count; k++) {
                                CustomizedAttribute customAttrFromDB = Array[j].customizedAttributeCollection[k];
                                for (int l = 0; l < (collection[i] as CustomTreeNode).customizedAttributeCollection.Count; l++) {
                                    CustomizedAttribute customAttrFromTree = (collection[i] as CustomTreeNode).customizedAttributeCollection[l];
                                    if (customAttrFromDB.attribute == null && customAttrFromTree.attribute != null) {

                                        if (string.Equals(customAttrFromTree.attribute.Name, customAttrFromDB.attrName)) {
                                            customAttrFromTree.attrName = customAttrFromDB.attrName;
                                            customAttrFromTree.attrValue = customAttrFromDB.attrValue;

                                        }
                                    }
                                    //customAttrFromTree.isUsed = false;
                                    //if (string.Equals(customAttrFromTree.attribute.Name, customAttrFromDB.attrName)) {
                                    //    customAttrFromTree.isUsed = customAttrFromDB.isUsed;
                                    //    customAttrFromTree.attrValue = customAttrFromDB.attrValue;
                                    //    customAttrFromTree.attrName = customAttrFromDB.attrName;
                                    //}
                                }
                            }
                        }
                    }
                    RestoreSelectedSiblingCapturePoints(Array, collection[i].Nodes);
                }
            }
        }

        AdvancedRecomendation CurrentlySelectedCaptureEvent;

      private void lbAdvancedCE_SelectedIndexChanged_1(object sender, EventArgs e) {
            try {
                eventParsed = true;
                btnDeleteAdvanceRec.Enabled = true;
                captureNodesSelectedNames = new List<string>();
                AdvancedRecomendation captureEvent = new AdvancedRecomendation();
                captureEvent = lbAdvancedCE.SelectedItem as AdvancedRecomendation;

                if (captureEvent != null) {
                    btnAddCaptureEvent.Enabled = false;
                    btnSaveCaptureEvent.Enabled = true;
                    txtAOEventIn.ReadOnly = true;
                    tvOutput.Nodes.Clear();
                    dgvAttributes.Rows.Clear();
                    AdvancedRecomendation workingEvent = new AdvancedRecomendation(captureEvent.CaptureEventId,
                                                                 captureEvent.CaptureEventName,
                                                                 captureEvent.CaptureEventDescription,
                                                                 captureEvent.CaptureEventEventText,
                                                                 captureEvent.captureEventCategory,
                                                                 captureEvent.captureEventUsageCount,
                                                                 captureEvent.CaptureEventCapturePointsList,
                                                                 captureEvent.captureEventuserId);
                    workingEvent.Replacement = captureEvent.Replacement;
                    CurrentlySelectedCaptureEvent = workingEvent;
                    for (int i = 0; i < captureEvent.CaptureEventCapturePointsList.Count; i++) {
                        captureEvent.CaptureEventCapturePointsList[i].nodeVisited = false;
                    }
                    cboCaptureType.SelectedValue = captureEvent.captureEventCategory;
                    txtAOName.Text = workingEvent.CaptureEventName;
                    txtAODescription.Text = workingEvent.CaptureEventDescription;
                    txtAOEventIn.Text = workingEvent.CaptureEventEventText;
                    txtTextValue.Text = workingEvent.Replacement.Value;
                    InterpretCaptureEvent(workingEvent);

                    RecurResetTag(tvOutput.Nodes);
                }

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnResetAO_Click(object sender, EventArgs e) {
            try {
                ResetForm();
                eventParsed = false;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
            //OpenFileDialog dialog = new OpenFileDialog();
            //string FileToParse = string.Empty;
            //if (dialog.ShowDialog() == DialogResult.OK) {
            //    FileToParse = dialog.FileName;
            //}
            //StreamReader reader = new StreamReader(FileToParse);
            //string readText = string.Empty;
            //try {
            //    readText = reader.ReadToEnd();
            //} finally {
            //    reader.Close();
            //}
            //CaptureEvent captureEvent = lbAdvancedCE.SelectedItem as CaptureEvent;
            //XDocument xdoc = XDocument.Parse(readText);


            //captureEvent = GetCapturePointListType(captureEvent);
            //List<string> foundEvents = new List<string>();

            //if (captureEvent.capturePointListType == CapturePointListType.SimpleList) {
            //    ParseUsingSimpleList(captureEvent, xdoc, foundEvents);
            //    txtFoundEvents.Text = string.Empty;
            //    for (int k = 0; k < foundEvents.Count; k++) {
            //        txtFoundEvents.Text = txtFoundEvents.Text + (string.IsNullOrEmpty(txtFoundEvents.Text) ? "" : "\r\n") + FrontendUtils.FormatXml(foundEvents[k]);
            //    }
            //} else {
            //    ParseUsingAdvancedList(captureEvent, xdoc);

            //}
        }

        private void ResetForm() {
            lbAdvancedCE.ClearSelected();
            txtTextValue.Clear();
            btnAddCaptureEvent.Enabled = true;
            btnSaveCaptureEvent.Enabled = false;
            btnDeleteAdvanceRec.Enabled = false;
            txtAOEventIn.ReadOnly = false;
            txtAOName.Focus();
            txtAOName.Clear();
            cboCaptureType.SelectedIndex = 0;
            txtAODescription.Clear();
            txtAOEventIn.Clear();
            tvOutput.Nodes.Clear();
            dgvAttributes.Rows.Clear();
            captureEventNodes.Clear();

        }

        private void ParseUsingAdvancedList(AdvancedRecomendation captureEvent, XDocument xdoc) {
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
                                    } else if (!string.Equals(attributeValueFromXml, customizedAttribute.attrValue) && !string.IsNullOrEmpty(customizedAttribute.attrName)) {
                                        found = false;
                                    }
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
            //for (int k = 0; k < foundlist.Count; k++) {
            //    if (foundlist[k]) {
            //        XNode node = test21.ElementAt(k).elements.ElementAt(0);
            //        txtFoundEvents.Text = txtFoundEvents.Text + (string.IsNullOrEmpty(txtFoundEvents.Text) ? "" : "\r\n") + FrontendUtils.FormatXml(node.ToString());
            //    }
            //}
        }

        private void ParseUsingSimpleList(AdvancedRecomendation captureEvent, XDocument xdoc, List<string> foundEvents) {
            switch (captureEvent.CaptureEventCapturePointsList.Count) {
                case 1:
                    var q1 = from c1 in xdoc.Descendants(captureEvent.CaptureEventCapturePointsList[0].Text)
                             where AllAttributesAvailable(c1, captureEvent.CaptureEventCapturePointsList[0].customizedAttributeCollection)
                             select new {
                                 elements = c1.DescendantNodesAndSelf()
                             };
                    for (int i = 0; i < q1.Count(); i++) {
                        foundEvents.Add(q1.ElementAt(i).elements.ElementAt(0).ToString());
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
                    }
                    break;
            }
        }

        private bool CheckSiblings(XElement c2, List<CustomTreeNode> list) {
            return false;
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

        private bool AllAttributesAvailable(XElement c1, List<CustomizedAttribute> list) {
            bool found = true;
            for (int i = 0; i < list.Count && found; i++) {
                if (string.IsNullOrEmpty(list[i].attrName)) {
                    return true;
                } else if (c1.Attribute(list[i].attrName) == null) {
                    found = false;
                } else if (!string.Equals(c1.Attribute(list[i].attrName).Value, list[i].attrValue)) {
                    found = false;
                }
            }
            return found;
        }

        private bool CheckAttrValue(XAttribute xAttribute, CustomizedAttribute customizedAttribute) {
            return (string.Equals(xAttribute.Name, customizedAttribute.attrName) && string.Equals(xAttribute.Value, customizedAttribute.attrValue));
        }

        private bool FindElementByAttributes(XElement xElement, List<CustomizedAttribute> cutomizedAttrCollection) {
            bool found = true;
            string foundString = string.Empty;
            IEnumerable<XAttribute> attributes = xElement.Attributes();
            for (int i = 0; i < cutomizedAttrCollection.Count; i++) {
                XAttribute attribute = xElement.Attribute(cutomizedAttrCollection[i].attrName);
                if (attribute == null) {
                    found = false;
                    return false;
                } else {
                    if (!string.Equals(attribute.Value, cutomizedAttrCollection[i].attrValue)) {
                        found = false;
                        return false;
                    }
                }
            }
            return found;
        }

        public bool IsValidXml(string xmlText) {
            try {
                XDocument xd1 = new XDocument();
                xd1 = XDocument.Parse(xmlText);
            } catch (XmlException exception) {
                return false;
            }
            return true;
        }

        private List<string> GetReplacementParametersFromValue(string replacementValue) {
            List<string> caughtParameters = new List<string>();
            Regex regex = new Regex("{(.*?)}", RegexOptions.Compiled);
            foreach (Match match in regex.Matches(replacementValue)) {
                caughtParameters.Add(match.Groups[0].Value);
            }
            return caughtParameters;
        }

        private void button1_Click(object sender, EventArgs e) {
            LoadAvailableARtoList();
            SetAllCombos();
            BindCombos();
        }

        private void FillInReplacementVariables(string replacementValue) {
            List<string> foundPatterns = GetReplacementParametersFromValue(replacementValue);
            string output = string.Empty;
            if (foundPatterns.Count > 0) {
                foreach (string pattern in foundPatterns) {
                    output = output + pattern + "\n";
                }
                FrontendUtils.ShowInformation("Found the following variables:\n" + output,false);
            } else {
                FrontendUtils.ShowInformation("No variables found!",false);
            }
        }

        private void btnSaveCaptureEvent_Click(object sender, EventArgs e) {
            try {
                tvOutput.Select();
                Recur(tvOutput.Nodes);
                SaveUpdatedAttributes();
                AdvancedRecomendation captureEvent = new AdvancedRecomendation(txtAOName.Text, txtAODescription.Text, txtAOEventIn.Text, captureEventNodes);
                captureEvent.captureEventCategory = Convert.ToInt32(cboCaptureType.SelectedValue);
                captureEvent.captureEventUsageCount = CurrentlySelectedCaptureEvent.captureEventUsageCount;
                ReplacementEvent selectedReplacementEvent = new ReplacementEvent("Replacement-" + txtAOName.Text, "Replacement-" + txtAODescription.Text, txtTextValue.Text, 1);
                //selectedReplacementEvent.name = txtReplacementName.Text;
                //selectedReplacementEvent.description = txtReplacementDesc.Text;
                //selectedReplacementEvent.Value = txtReplacementRep.Text;
                //selectedReplacementEvent.typeId = Convert.ToInt32(cboReplacementType.SelectedValue);


                selectedReplacementEvent.id = CurrentlySelectedCaptureEvent.Replacement.id;

                Advanced_Recomendations_TextConv.SaveCaptureEventByIdForTextConversion(CurrentlySelectedCaptureEvent.CaptureEventId, captureEvent, selectedReplacementEvent);
                LoadAvailableARtoList();
                SetAllCombos();
                BindCombos();
                ResetForm();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void cboCaptureType_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                //TODO: check what to do here
                //switch ((int)cboCaptureType.SelectedValue) {
                //    case (int)FrontendUtils.AdvancedRecCategory.SpecificConf:
                //        SetupUiForSpecificRecommendation();
                //        break;
                //    case (int)FrontendUtils.AdvancedRecCategory.Verbal:
                //        SetupUiForVerbalRecommendation();
                //        break;
                //    case (int)FrontendUtils.AdvancedRecCategory.Xpath:
                //        SetupUiForXpathRecommendation();
                //        break;
                //}
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void HideAllGroupBoxesUnderParent(Control.ControlCollection controlCollection) {
            foreach (Control control in controlCollection) {
                if (control is GroupBox) {
                    control.Visible = false;
                }
            }
        }

        private void SetupUiForXpathRecommendation() {
            HideAllGroupBoxesUnderParent(gbRuleDefinition.Controls);
        }

        private void SetupUiForVerbalRecommendation() {
            HideAllGroupBoxesUnderParent(gbRuleDefinition.Controls);

        }

        private void SetupUiForSpecificRecommendation() {
            HideAllGroupBoxesUnderParent(gbRuleDefinition.Controls);
        }

        bool eventParsed = false;

        private void btnParse_Click(object sender, EventArgs e) {
            try {
                if (IsValidXml(txtAOEventIn.Text)) {
                    ParseEvent(txtAOEventIn.Text);
                    if (!txtAOEventIn.ReadOnly) {
                        btnAddCaptureEvent.Enabled = true;
                    }                    
                    eventParsed = true;
                } else {
                    FrontendUtils.ShowInformation("Event must be a valid xml!",true);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }


        }

        private void btnDeleteAdvanceRec_Click(object sender, EventArgs e) {
            try {
                DialogResult dial = FrontendUtils.ShowConformation("Are you sure you want to delete [" + CurrentlySelectedCaptureEvent.CaptureEventName + "] ?");
                if (dial == DialogResult.Yes) {
                    Advanced_Recomendations_TextConv.DisableAdvanceRecById(CurrentlySelectedCaptureEvent.CaptureEventId);
                    LoadAvailableARtoList();
                    SetAllCombos();
                    BindCombos();
                    lbAdvancedCE.Select();
                }

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }






    }
}
