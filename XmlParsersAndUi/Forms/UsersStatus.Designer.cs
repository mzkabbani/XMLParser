namespace XmlParsersAndUi.Forms {
    partial class UsersStatus {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersStatus));
            this.btnUpdateUSer = new System.Windows.Forms.Button();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtUserNameInsert = new System.Windows.Forms.TextBox();
            this.btnInsertUser = new System.Windows.Forms.Button();
            this.dgvUserStatus = new System.Windows.Forms.DataGridView();
            this.ilOnlineStatus = new System.Windows.Forms.ImageList(this.components);
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // btnUpdateUSer
            // 
            this.btnUpdateUSer.Location = new System.Drawing.Point(12, 30);
            this.btnUpdateUSer.Name = "btnUpdateUSer";
            this.btnUpdateUSer.Size = new System.Drawing.Size(107, 23);
            this.btnUpdateUSer.TabIndex = 0;
            this.btnUpdateUSer.Text = "Update User";
            this.btnUpdateUSer.UseVisualStyleBackColor = true;
            this.btnUpdateUSer.Click += new System.EventHandler(this.btnUpdateUSer_Click);
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(12, 4);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(167, 20);
            this.txtUserName.TabIndex = 1;
            // 
            // txtUserNameInsert
            // 
            this.txtUserNameInsert.Location = new System.Drawing.Point(12, 59);
            this.txtUserNameInsert.Name = "txtUserNameInsert";
            this.txtUserNameInsert.Size = new System.Drawing.Size(167, 20);
            this.txtUserNameInsert.TabIndex = 3;
            // 
            // btnInsertUser
            // 
            this.btnInsertUser.Location = new System.Drawing.Point(12, 85);
            this.btnInsertUser.Name = "btnInsertUser";
            this.btnInsertUser.Size = new System.Drawing.Size(107, 23);
            this.btnInsertUser.TabIndex = 2;
            this.btnInsertUser.Text = "Insert User";
            this.btnInsertUser.UseVisualStyleBackColor = true;
            this.btnInsertUser.Click += new System.EventHandler(this.btnInsertUser_Click);
            // 
            // dgvUserStatus
            // 
            this.dgvUserStatus.AllowUserToAddRows = false;
            this.dgvUserStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUserStatus.Location = new System.Drawing.Point(12, 114);
            this.dgvUserStatus.Name = "dgvUserStatus";
            this.dgvUserStatus.RowHeadersVisible = false;
            this.dgvUserStatus.Size = new System.Drawing.Size(167, 376);
            this.dgvUserStatus.TabIndex = 4;
            // 
            // ilOnlineStatus
            // 
            this.ilOnlineStatus.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilOnlineStatus.ImageStream")));
            this.ilOnlineStatus.TransparentColor = System.Drawing.Color.Transparent;
            this.ilOnlineStatus.Images.SetKeyName(0, "Button-Blank-Green-icon.png");
            this.ilOnlineStatus.Images.SetKeyName(1, "Aqua Ball Red Icon.jpg");
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(42, 497);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(107, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // UsersStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 532);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.dgvUserStatus);
            this.Controls.Add(this.txtUserNameInsert);
            this.Controls.Add(this.btnInsertUser);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.btnUpdateUSer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "UsersStatus";
            this.Text = "Users Status";
            this.Load += new System.EventHandler(this.UsersStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUserStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdateUSer;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtUserNameInsert;
        private System.Windows.Forms.Button btnInsertUser;
        private System.Windows.Forms.DataGridView dgvUserStatus;
        private System.Windows.Forms.ImageList ilOnlineStatus;
        private System.Windows.Forms.Button btnRefresh;
    }
}