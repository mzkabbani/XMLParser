using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Automation.Common.Utils;

namespace XmlParsersAndUi.Forms {
    public partial class FindForm : Form {
        public FindForm() {
            InitializeComponent();
        }

        DataGridView localGrid;
        public FindForm(DataGridView grid) {
            InitializeComponent();
            localGrid = grid;
        }
        int foundIndex = -1;
        bool found = false;
        private void btnSearch_Click(object sender, EventArgs e) {
            try {
                foundIndex = foundIndex + 1;
                if(!string.IsNullOrEmpty(cboFindText.Text)){
                    SearchInDataGrid(cboFindText.Text, chkCaseSensitive.Checked, localGrid);
                }
                cboFindText.Focus();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void SearchInDataGrid(string searchText,bool caseSensitive, DataGridView grid) {
            Regex regex = new Regex(searchText, caseSensitive ? RegexOptions.None : RegexOptions.IgnoreCase);        
            for (int i = foundIndex; i < grid.Rows.Count && !found; i++) {
                if (regex.Matches(grid.Rows[i].Cells[3].Value.ToString()).Count > 0) {
                    grid.ClearSelection();
                    DataGridViewCellStyle style = new DataGridViewCellStyle();
                    style.BackColor = Color.LightGreen;
                    grid.Rows[i].Selected = true;
                    grid.FirstDisplayedScrollingRowIndex = i;
                    found = true;
                    foundIndex = i;
                }
            }
            if (!found && foundIndex > -1) {
                foundIndex = -1;
            }

            found = false;
            cboFindText.Items.Add(cboFindText.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void cboFindText_TextUpdate(object sender, EventArgs e) {
            foundIndex = -1;
            found = false;
        }

        private void FindForm_Load(object sender, EventArgs e) {
            cboFindText.Focus();
        }

        private void cboFindText_KeyPress(object sender, KeyPressEventArgs e) {
            try {
                //Enter pressed
                if ((int)e.KeyChar == 13) {
                    foundIndex = foundIndex + 1;
                    if (!string.IsNullOrEmpty(cboFindText.Text)) {
                        SearchInDataGrid(cboFindText.Text, chkCaseSensitive.Checked, localGrid);
                    }
                    cboFindText.Focus(); 
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }
    }
}
