using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Common.Utils;
using System.IO;

namespace PackageGenerator.Forms {
    public partial class SelectPackageNameAndStorageForm : Form {
        public SelectPackageNameAndStorageForm() {
            InitializeComponent();
        }

        private void btnBrowseFolder_Click(object sender, EventArgs e) {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            folderBrowserDialog.ShowDialog();
            folderBrowserDialog.ShowNewFolderButton = true;
            txtOutputPath.Text = folderBrowserDialog.SelectedPath;

        }

        private void btnProceed_Click(object sender, EventArgs e) {
            try {
                if (string.IsNullOrEmpty(txtOutputPath.Text.Trim()) || string.IsNullOrEmpty(txtPackageName.Text.Trim())) {
                    FrontendUtils.ShowInformation("[Output Path] and [Package Name] are mandatory fields!", true);
                    this.DialogResult = DialogResult.Cancel;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void SelectPackageNameAndStorageForm_Load(object sender, EventArgs e) {
            try {
                 string pathToThisExec = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                 txtOutputPath.Text = pathToThisExec+"\\Released";
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }


    }
}
