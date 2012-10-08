using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlServerCe;
using XmlParsersAndUi.Classes;
using Automation.Common;
using Automation.Backend;

namespace XmlParsersAndUi.Forms {
    public partial class ConvertToEnumForm : Form {
        public ConvertToEnumForm() {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            string generatedEnum = "public enum ApplicationConfigKeys {";
            List<ApplicationConfigObject> allAppConfig = Application_Settings.GetAllApplicationConfigAsList();
            
            foreach (ApplicationConfigObject config in allAppConfig) {
                generatedEnum = generatedEnum + "\r\n" + config.key + " = "+config.id+",";
            }
            generatedEnum.TrimEnd(',');
            generatedEnum = generatedEnum + "\r\n }";
            txtGeneratedEnum.Text = generatedEnum;
        }
    }
}
