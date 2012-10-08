namespace XmlParsersAndUi.Forms {
    partial class BulkFolderNamesInsertion {
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
            this.txtBulkFolderNames = new System.Windows.Forms.TextBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtBulkFolderNames
            // 
            this.txtBulkFolderNames.Location = new System.Drawing.Point(13, 13);
            this.txtBulkFolderNames.Multiline = true;
            this.txtBulkFolderNames.Name = "txtBulkFolderNames";
            this.txtBulkFolderNames.Size = new System.Drawing.Size(364, 264);
            this.txtBulkFolderNames.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(138, 283);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            // 
            // BulkFolderNamesInsertion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 311);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.txtBulkFolderNames);
            this.Name = "BulkFolderNamesInsertion";
            this.Text = "BulkFolderNamesInsertion";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBulkFolderNames;
        private System.Windows.Forms.Button btnOk;
    }
}