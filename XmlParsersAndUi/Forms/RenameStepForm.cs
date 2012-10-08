using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XmlParsersAndUi.Forms {
    public partial class RenameStepForm : Form {
        string defaultStepTitle;

        public RenameStepForm(string oldStepTitle) {
        	InitializeComponent();
        	defaultStepTitle = oldStepTitle;
        }

        private void RenameStepForm_Load(object sender, EventArgs e) {
            txtNewStepTitle.Text = defaultStepTitle;
        }

        private void btnSave_Click(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(txtNewStepTitle.Text)) {
                this.DialogResult = DialogResult.OK;
            } else {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
