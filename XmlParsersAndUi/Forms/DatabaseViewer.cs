using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Common.Utils;
using Automation.Backend;

namespace XmlParsersAndUi {
    public partial class DatabaseViewer : Form {
        public DatabaseViewer() {
            InitializeComponent();
        }

        private void DatabaseViewer_Load(object sender, EventArgs e) {
            try {
              
                DataSet set =BackEndUtils.GetAllTableNamesAsDataSet();


                cboTableNames.DataSource = set.Tables[0].DefaultView;
                cboTableNames.DisplayMember = "TABLE_NAME";
                dgvRecomendations.DataSource = Advanced_Recommendations.GetAllAdvancedRecs();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnExecute_Click(object sender, EventArgs e) {
            try {
               FrontendUtils.ShowError( BackEndUtils.ExecuteRandomQuery(txtQuery.Text).ToString(),null);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            try {
                dgvRecomendations.DataSource = null;
                dgvRecomendations.DataSource = BackEndUtils.GetAllTableRowsAsDataTable(cboTableNames.SelectedItem.ToString());
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnRefresh_Click_1(object sender, EventArgs e) {
            try {
                dgvRecomendations.DataSource = null;
                dgvRecomendations.DataSource = BackEndUtils.GetAllTableRowsAsDataTable((string)(cboTableNames.SelectedValue as DataRowView)[0]);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnExecute_Click_1(object sender, EventArgs e) {
            try {
                FrontendUtils.ShowError(BackEndUtils.ExecuteRandomQuery(txtQuery.Text).ToString(),null);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }
    }
}
