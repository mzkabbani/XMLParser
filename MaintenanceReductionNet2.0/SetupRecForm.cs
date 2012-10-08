using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace XmlParsersAndUi {
    public partial class SetupRecForm : Form {
        public SetupRecForm() {
            InitializeComponent();
        }

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
            outputDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\output";
            outputDir = outputDir.Replace(" ", "");
            inputDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\input";
            inputDir = inputDir.Replace(" ", "");

            if (!Directory.Exists(outputDir)) {
                Directory.CreateDirectory(outputDir);
            }
            if (!Directory.Exists(inputDir)) {
                Directory.CreateDirectory(inputDir);
            }
            FrontendUtils.CheckoutPath("http://globalqa/svn/PAR/PFR/0000081/trunk/pfr/QAA-Activities/MaintenanceReduction/SimpleOptions/", inputDir);

            LoadOptionsIntoList(inputDir);
        }

        private bool IsValidToSaveObject(string optionName, string optionDescription, string optionPattern, string optionReplacement) {
            if (string.IsNullOrEmpty(optionName)) {
                FrontendUtils.ShowError("Name cannot be empty");
                return false;
            } else if (string.IsNullOrEmpty(optionDescription)) {
                FrontendUtils.ShowError("Description cannot be empty");
                return false;
            } else if (string.IsNullOrEmpty(optionPattern)) {
                FrontendUtils.ShowError("Pattern cannot be empty");
                return false;
            } else if (string.IsNullOrEmpty(optionReplacement)) {
                FrontendUtils.ShowError("Replacement cannot be empty");
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
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message);
            }
        }

        private void btnReloadOptions_Click(object sender, EventArgs e) {
            try {
                LoadSimpleOptions();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message);
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
                FrontendUtils.ShowError(ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e) {
            try {
                if (IsValidToSaveObject(txtOptionName.Text.Trim(), txtOptionDesc.Text.Trim(), txtOptionPattern.Text.Trim(), txtOptionReplacement.Text.Trim())) {
                    SimpleRecommendationObject newRecObj = FillSimpleOpiton(txtOptionName.Text.Trim(), txtOptionDesc.Text.Trim(), txtOptionPattern.Text.Trim(), txtOptionReplacement.Text.Trim(), chkIsRegex.Checked);
                    newRecObj.fileName = (lbOptions.SelectedItem as SimpleRecommendationObject).fileName;
                    string filePath = inputDir + @"\" + newRecObj.fileName;
                    FrontendUtils.WriteFile(filePath, newRecObj.optionName + "##SPLIT##" + newRecObj.description + "##SPLIT##" + newRecObj.isRegex + "##SPLIT##" + newRecObj.pattern + "##SPLIT##" + newRecObj.replacement + "##SPLIT##" + newRecObj.fileName);


                    FrontendUtils.AddSimpleRectoSvn(inputDir);
                    LoadOptionsIntoList(inputDir);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message);
            }
        }

    
        #endregion

        private void lbOptions_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (lbOptions.SelectedItem == null) {
                    return;
                }
                FillUiFromobject(lbOptions.SelectedItem as SimpleRecommendationObject);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message);
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
                    string filePath = inputDir + @"\" + fileName;
                    FrontendUtils.WriteFile(filePath, newRecObj.optionName + "##SPLIT##" + newRecObj.description + "##SPLIT##" + newRecObj.isRegex + "##SPLIT##" + newRecObj.pattern + "##SPLIT##" + newRecObj.replacement + "##SPLIT##" + fileName);


                    FrontendUtils.AddSimpleRectoSvn(inputDir);
                    LoadOptionsIntoList(inputDir);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message);
            }
        }      
    }
}
