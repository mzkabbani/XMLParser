using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using Automation.Common.Utils;
using Automation.Common;
using Automation.Backend;
using Automation.Common.Classes.Monitoring;

namespace XmlParsersAndUi {
    public partial class SetupSimpleRecForm : Form {
        
        #region Constructor
        
        public SetupSimpleRecForm() {
            InitializeComponent();
        } 

        #endregion

        #region Variables

        string outputDir;
        string inputDir;

        #endregion

        #region Methods

        private void LoadOptionsIntoList(string inputDir) {
            lbOptions.Items.Clear();
            string[] simpleOptionFiles = Directory.GetFiles(inputDir, "*.simpleO");

            for (int i = 0; i < simpleOptionFiles.Length; i++) {
                SimpleRecommendationObject simpleRecom = ConvertToObject(FrontendUtils.ReadFile(simpleOptionFiles[i]));
                simpleRecom.fileName = Path.GetFileName(simpleOptionFiles[i]);
                Simple_Recommendation.InsertNewSimpleRecommendation(simpleRecom);
                lbOptions.Items.Add(simpleRecom);
            }
        }

        private SimpleRecommendationObject ConvertToObject(string fileRead) {
            SimpleRecommendationObject newRecObj = new SimpleRecommendationObject();
            string[] separator = new string[] { "##SPLIT##" };
            string[] splitFile = fileRead.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            newRecObj.optionName = splitFile[0].Replace("\r\n", string.Empty);
            newRecObj.description = splitFile[1].Replace("\r\n", string.Empty);
            newRecObj.isRegex = string.Equals(splitFile[2].Replace("\r\n", string.Empty), "True", StringComparison.InvariantCultureIgnoreCase) ? true : false;
            newRecObj.pattern = splitFile[3].Replace("\r\n", string.Empty);
            newRecObj.replacement = splitFile[4].Replace("\r\n", string.Empty);

            return newRecObj;
        }

        private void LoadSimpleOptions() {
            #region OldCode
            //outputDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\output";
            //outputDir = outputDir.Replace(" ", "");
            //inputDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\input";
            //inputDir = inputDir.Replace(" ", "");
            //if (!Directory.Exists(outputDir)) {
            //    Directory.CreateDirectory(outputDir);
            //}
            //if (!Directory.Exists(inputDir)) {
            //    Directory.CreateDirectory(inputDir);
            //}
            //FrontendUtils.CheckoutPath("http://globalqa/svn/PAR/PFR/0000081/trunk/pfr/QAA-Activities/MaintenanceReduction/SimpleOptions/", inputDir);
            //LoadOptionsIntoList(inputDir); 
            #endregion

            List<SimpleRecommendationObject> allSimpleRecs = Simple_Recommendation.GetAllSimpleRecsAsList();
            InsertSimpleRecIntoListbox(allSimpleRecs);
        }


        private void InsertSimpleRecIntoListbox(List<SimpleRecommendationObject> allSimpleRecs) {
            lbOptions.Items.Clear();
            for (int i = 0; i < allSimpleRecs.Count; i++) {
                SimpleRecommendationObject simpleRecom = new SimpleRecommendationObject(allSimpleRecs[i].optionName,
                                                                                        allSimpleRecs[i].isRegex,
                                                                                        allSimpleRecs[i].description,
                                                                                        allSimpleRecs[i].pattern,
                                                                                        allSimpleRecs[i].replacement,
                                                                                        allSimpleRecs[i].fileName);
                lbOptions.Items.Add(simpleRecom);
            }
        }

        private bool IsValidToSaveObject(string optionName, string optionDescription, string optionPattern, string optionReplacement) {
            if (string.IsNullOrEmpty(optionName)) {
                FrontendUtils.ShowError("Name cannot be empty", null);
                return false;
            } else if (string.IsNullOrEmpty(optionDescription)) {
                FrontendUtils.ShowError("Description cannot be empty", null);
                return false;
            } else if (string.IsNullOrEmpty(optionPattern)) {
                FrontendUtils.ShowError("Pattern cannot be empty", null);
                return false;
            } else if (string.IsNullOrEmpty(optionReplacement)) {
                FrontendUtils.ShowError("Replacement cannot be empty", null);
                return false;
            }
            return true;
        }

        private SimpleRecommendationObject FillSimpleOpiton(string optionName, string optionDescription, string optionPattern, string optionReplacement, bool isRegegex) {
            SimpleRecommendationObject simpleRec = new SimpleRecommendationObject();
            simpleRec.optionName = optionName;
            simpleRec.description = optionDescription;
            simpleRec.pattern = optionPattern;
            simpleRec.replacement = optionReplacement;
            simpleRec.isRegex = isRegegex;
            return simpleRec;
        }

        #endregion

        #region Events

        private void SetupRecForm_Load(object sender, EventArgs e) {
            try {
                LoadSimpleOptions();
                btnAdd.Enabled = true;
                btnSave.Enabled = false;

                try {
                    if (!string.IsNullOrEmpty(MonitorObject.username)) {
                        MonitorObject.formAndAccessTime.Add(new FormAndAccessTime(this.Name, DateTime.Now));
                    }
                } catch (Exception) {

                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnReloadOptions_Click(object sender, EventArgs e) {
            try {
                LoadSimpleOptions();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            try {
                txtOptionName.Text = string.Empty;
                txtOptionDesc.Text = string.Empty;
                txtOptionPattern.Text = string.Empty;
                txtOptionReplacement.Text = string.Empty;
                chkIsRegex.Checked = false;
                btnAdd.Enabled = true;
                btnSave.Enabled = false;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            try {
                if (IsValidToSaveObject(txtOptionName.Text.Trim(), txtOptionDesc.Text.Trim(), txtOptionPattern.Text.Trim(), txtOptionReplacement.Text.Trim())) {
                    SimpleRecommendationObject newRecObj = FillSimpleOpiton((lbOptions.SelectedItem as SimpleRecommendationObject).optionName, txtOptionDesc.Text.Trim(), txtOptionPattern.Text.Trim(), txtOptionReplacement.Text.Trim(), chkIsRegex.Checked);
                    newRecObj.fileName = "sample";
                    Simple_Recommendation.UpdateSimpleRecByName(newRecObj, txtOptionName.Text);
                    LoadSimpleOptions();
                    FrontendUtils.ShowInformation("The Simple Recommendation is now updated!",false);
                    lbOptions.SelectedIndex = 0;
                    #region old code
                    //newRecObj.fileName = (lbOptions.SelectedItem as SimpleRecommendationObject).fileName;
                    //string filePath = inputDir + @"\" + newRecObj.fileName;
                    //FrontendUtils.WriteFile(filePath, newRecObj.optionName + "##SPLIT##" + newRecObj.description + "##SPLIT##" + newRecObj.isRegex + "##SPLIT##" + newRecObj.pattern + "##SPLIT##" + newRecObj.replacement + "##SPLIT##" + newRecObj.fileName);
                    //FrontendUtils.AddSimpleRectoSvn(inputDir);
                    //LoadOptionsIntoList(inputDir); 
                    #endregion
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void lbOptions_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (lbOptions.SelectedItem == null) {
                    return;
                }
                FillUiFromobject(lbOptions.SelectedItem as SimpleRecommendationObject);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void FillUiFromobject(SimpleRecommendationObject simpleRecommendationObject) {
            txtOptionName.Text = simpleRecommendationObject.optionName;
            txtOptionDesc.Text = simpleRecommendationObject.description;
            txtOptionPattern.Text = simpleRecommendationObject.pattern;
            txtOptionReplacement.Text = simpleRecommendationObject.replacement;
            chkIsRegex.Checked = simpleRecommendationObject.isRegex;
            btnSave.Enabled = true;
            btnAdd.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e) {
            try {
                if (IsValidToSaveObject(txtOptionName.Text.Trim(), txtOptionDesc.Text.Trim(), txtOptionPattern.Text.Trim(), txtOptionReplacement.Text.Trim())) {
                    SimpleRecommendationObject newRecObj = FillSimpleOpiton(txtOptionName.Text.Trim(), txtOptionDesc.Text.Trim(), txtOptionPattern.Text.Trim(), txtOptionReplacement.Text.Trim(), chkIsRegex.Checked);
                    string fileName = DateTime.Now.Ticks + ".simpleO";
                    newRecObj.fileName = fileName;
                    //string filePath = inputDir + @"\" + fileName;
                    Simple_Recommendation.InsertNewSimpleRecommendation(newRecObj);
                    //List<SimpleRecommendationObject> allSimpleRecs = BackEndUtils.GetAllSimpleRecsAsList();
                    //RefreshUiFromList(allSimpleRecs);
                    LoadSimpleOptions();
                    //FrontendUtils.WriteFile(filePath, newRecObj.optionName + "##SPLIT##" + newRecObj.description + "##SPLIT##" + newRecObj.isRegex + "##SPLIT##" + newRecObj.pattern + "##SPLIT##" + newRecObj.replacement + "##SPLIT##" + fileName);
                    //FrontendUtils.AddSimpleRectoSvn(inputDir);
                    //LoadOptionsIntoList(inputDir);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }
    
        #endregion

    }
}