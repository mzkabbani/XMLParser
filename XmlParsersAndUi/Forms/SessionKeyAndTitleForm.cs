using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using XmlParsersAndUi.Forms;
using Automation.Common.Utils;
using XmlParsersAndUi.Classes;

namespace XmlParsersAndUi {
    public partial class SessionKeyAndTitleForm : Form {
        
        #region Variables

        public string sessionKey;
        string currentOutputDir;

        #endregion

        #region Constructor
        
        public SessionKeyAndTitleForm(string outputDirectory) {
            InitializeComponent();
            currentOutputDir = outputDirectory;
        }

        #endregion    
        
        #region Events

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnProceed_Click(object sender, EventArgs e) {
            sessionKey = txtSessionKey.Text;
            if (IsValidToProceed()) {
                this.DialogResult = DialogResult.OK;            
            }
        }

        private bool IsValidToProceed() {
            if (string.IsNullOrEmpty(txtFolderName.Text)) {
                FrontendUtils.ShowInformation("Please input a folder name!", true);
                //    this.DialogResult = DialogResult.No;
                return false;
            }

            if (string.IsNullOrEmpty(txtOperation.Text)) {
                FrontendUtils.ShowInformation("Please select an operation!", true);
                //  this.DialogResult = DialogResult.No;
                return false;
            }
            if (Directory.Exists(currentOutputDir + @"\" + txtFolderName.Text + "-" + eventsGroupNameAndID.OperationGeneratedID)) {
                DialogResult dialogResult = MessageBox.Show("Selected directory already exists, do you want to overrite?", "Directory Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.No) {
                    //this.DialogResult = DialogResult.Abort;
                    return false;
                }
            }
            return true;
        }

        private void SessionKeyAndTitleForm_Load(object sender, EventArgs e) {
            Random random = new Random(DateTime.Now.Millisecond);
            txtSessionKey.Text = random.Next(8999).ToString();
        }

       public EventsGroupNameAndID eventsGroupNameAndID;

        private void btnSelectFolderName_Click(object sender, EventArgs e) {
            try {
                SelectFolderNameForm form = new SelectFolderNameForm();
                form.Parent = this.Parent;
                form.StartPosition = FormStartPosition.CenterParent;
                DialogResult result =  form.ShowDialog();
                
                if(result == DialogResult.OK){
                   eventsGroupNameAndID = form.selectedOperation;
                   txtOperation.Text =  form.selectedOperation.OperationName;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        #endregion   

        private void txtTestTitle_TextChanged(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(txtTestTitle.Text)) {
                    txtFolderName.Text = txtTestTitle.Text.Replace(" ","_");                
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

       
    }
}
