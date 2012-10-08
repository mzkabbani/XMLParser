using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Backend;

namespace XmlParsersAndUi.Forms {
    public partial class UsersStatus : Form {

        #region Constructor

        public UsersStatus() {
            InitializeComponent();
        }

        #endregion

        #region Variables

        bool islogin = false;

        #endregion

        #region Methods
        
        private void LoadForm() {
            dgvUserStatus.DataSource = null;
            DataSet dataSet = UserStatus.GetAllUsersTableAsDataSet();
            dgvUserStatus.DataSource = dataSet.Tables[0];
            dgvUserStatus.Columns["onlineStatus"].Visible = false;
            dgvUserStatus.Columns["loginCount"].Visible = false;
            dgvUserStatus.Columns["firstLogin"].Visible = false;
            dgvUserStatus.Columns["lastLogin"].Visible = false;
            dgvUserStatus.Columns["id"].Visible = false;
            dgvUserStatus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUserStatus.Columns["username"].Name = "Username";
            if (dgvUserStatus.Columns["Status"] != null) {
                dgvUserStatus.Columns.Remove("Status");
            }
            DataGridViewImageColumn imageCol = new DataGridViewImageColumn();
            imageCol.Name = "Status";
            dgvUserStatus.Columns.Add(imageCol);
        }

        #endregion

        #region Events

        private void btnUpdateUSer_Click(object sender, EventArgs e) {
            int userId = UserStatus.GetUserIdByUsername(txtUserName.Text);
            UserStatus.UpdateUserStatusById(userId, !islogin);
            islogin = !islogin;
            LoadForm();
        }

        private void btnInsertUser_Click(object sender, EventArgs e) {
            UserStatus.InsertNewUser(txtUserNameInsert.Text);
            LoadForm();
        }

        private void UsersStatus_Load(object sender, EventArgs e) {
            LoadForm();
            this.dgvUserStatus.CellFormatting +=
               new DataGridViewCellFormattingEventHandler(dataGridView1_CellFormatting);
        }

        void dataGridView1_CellFormatting(object sender,
            DataGridViewCellFormattingEventArgs e) {
            if (e.RowIndex > -1 && e.ColumnIndex == this.dgvUserStatus.Columns["Status"].Index) {
                if (this.dgvUserStatus["onlineStatus", e.RowIndex].Value != null) {
                    string s = this.dgvUserStatus["onlineStatus", e.RowIndex].Value.ToString();
                    switch (s) {
                        case "Online":
                            e.Value = ilOnlineStatus.Images[0];
                            break;
                        case "Offline":
                            e.Value = ilOnlineStatus.Images[1];
                            break;
                    }
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e) {
            dgvUserStatus.DataSource = new DataTable();
            LoadForm();
        }

        #endregion
    
    }
}