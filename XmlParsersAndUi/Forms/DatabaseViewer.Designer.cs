namespace XmlParsersAndUi {
    partial class DatabaseViewer {
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
            this.dgvRecomendations = new System.Windows.Forms.DataGridView();
            this.cboTableNames = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnExecute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecomendations)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvRecomendations
            // 
            this.dgvRecomendations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecomendations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecomendations.Location = new System.Drawing.Point(12, 171);
            this.dgvRecomendations.Name = "dgvRecomendations";
            this.dgvRecomendations.Size = new System.Drawing.Size(626, 339);
            this.dgvRecomendations.TabIndex = 0;
            // 
            // cboTableNames
            // 
            this.cboTableNames.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTableNames.FormattingEnabled = true;
            this.cboTableNames.Items.AddRange(new object[] {
            "Rec_CapturePoints",
            "Advanced_Recommendations",
            "UserStatus"});
            this.cboTableNames.Location = new System.Drawing.Point(12, 13);
            this.cboTableNames.Name = "cboTableNames";
            this.cboTableNames.Size = new System.Drawing.Size(190, 21);
            this.cboTableNames.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(223, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 25);
            this.btnRefresh.TabIndex = 7;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click_1);
            // 
            // txtQuery
            // 
            this.txtQuery.Location = new System.Drawing.Point(12, 40);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.Size = new System.Drawing.Size(365, 125);
            this.txtQuery.TabIndex = 6;
            // 
            // btnExecute
            // 
            this.btnExecute.Location = new System.Drawing.Point(383, 40);
            this.btnExecute.Name = "btnExecute";
            this.btnExecute.Size = new System.Drawing.Size(75, 23);
            this.btnExecute.TabIndex = 5;
            this.btnExecute.Text = "Execute";
            this.btnExecute.UseVisualStyleBackColor = true;
            this.btnExecute.Click += new System.EventHandler(this.btnExecute_Click_1);
            // 
            // DatabaseViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 522);
            this.Controls.Add(this.cboTableNames);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnExecute);
            this.Controls.Add(this.dgvRecomendations);
            this.Name = "DatabaseViewer";
            this.Text = "DatabaseViewer";
            this.Load += new System.EventHandler(this.DatabaseViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecomendations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRecomendations;
        private System.Windows.Forms.ComboBox cboTableNames;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.TextBox txtQuery;
        private System.Windows.Forms.Button btnExecute;
    }
}