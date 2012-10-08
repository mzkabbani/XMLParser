using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XmlParsersAndUi.Classes;
using Automation.Common.Utils;

namespace XmlParsersAndUi.Forms {
    public partial class AddPropertyForm : Form {

        List<InstallerProp> installerProps = new List<InstallerProp>();

        public AddPropertyForm(ListBox.ObjectCollection availablePropsList) {
            InitializeComponent();
            foreach (InstallerProp installerProp in availablePropsList) {
                installerProps.Add(installerProp);
            }
        }

        private void AddPropertyForm_Load(object sender, EventArgs e) {
            try {
                for (int i = 0; i < installerProps.Count; i++) {
                    lbAvailableProperties.Items.Add(installerProps[i]);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }
        public InstallerProp selectedInstallerProp;
        private void lbAvailableProperties_MouseDoubleClick(object sender, MouseEventArgs e) {
            try {
                InstallerProp installerProp = lbAvailableProperties.SelectedItem as InstallerProp;
                selectedInstallerProp = installerProp;
                this.DialogResult = DialogResult.OK;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }
    }
}
