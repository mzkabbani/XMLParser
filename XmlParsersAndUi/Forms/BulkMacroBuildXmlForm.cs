using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XmlParsersAndUi.Forms {
    public partial class BulkMacroBuildXmlForm : Form {

        string passedBuildText = string.Empty;

        public BulkMacroBuildXmlForm(string buildText) {
            InitializeComponent();
            passedBuildText = buildText;
        }

        private void BulkMacroBuildXmlForm_Load(object sender, EventArgs e) {
            try {
                txtBuildFileText.Text = passedBuildText;
            } catch (Exception ex) {
                
                throw;
            }
        }
    }
}
