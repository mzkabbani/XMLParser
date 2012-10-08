using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XmlParsersAndUi.Forms {
    public partial class EditFolderNameForm : Form {
        public EditFolderNameForm() {
            InitializeComponent();
        }
        string passedFolderName;
        public EditFolderNameForm(string oldFolderName) {
            InitializeComponent();
            passedFolderName = oldFolderName;
        }

        private void EditFolderNameForm_Load(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(passedFolderName)) {
                txtNewName.Text = passedFolderName;
            }
            txtNewName.Select();
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnProceed_Click(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(txtNewName.Text)) {
                this.DialogResult = DialogResult.Cancel;
            }
            this.Close();
        }
    }
}
