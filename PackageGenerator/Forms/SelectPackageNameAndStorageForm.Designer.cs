namespace PackageGenerator.Forms {
    partial class SelectPackageNameAndStorageForm {
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
            this.gbOutputSettings = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnProceed = new System.Windows.Forms.Button();
            this.btnBrowseFolder = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPackageName = new System.Windows.Forms.TextBox();
            this.txtOutputPath = new System.Windows.Forms.TextBox();
            this.gbOutputSettings.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbOutputSettings
            // 
            this.gbOutputSettings.Controls.Add(this.btnCancel);
            this.gbOutputSettings.Controls.Add(this.btnProceed);
            this.gbOutputSettings.Controls.Add(this.btnBrowseFolder);
            this.gbOutputSettings.Controls.Add(this.label2);
            this.gbOutputSettings.Controls.Add(this.label1);
            this.gbOutputSettings.Controls.Add(this.txtPackageName);
            this.gbOutputSettings.Controls.Add(this.txtOutputPath);
            this.gbOutputSettings.Location = new System.Drawing.Point(13, 12);
            this.gbOutputSettings.Name = "gbOutputSettings";
            this.gbOutputSettings.Size = new System.Drawing.Size(508, 104);
            this.gbOutputSettings.TabIndex = 0;
            this.gbOutputSettings.TabStop = false;
            this.gbOutputSettings.Text = "Output Settings";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(257, 72);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnProceed
            // 
            this.btnProceed.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnProceed.Location = new System.Drawing.Point(176, 72);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(75, 23);
            this.btnProceed.TabIndex = 4;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // btnBrowseFolder
            // 
            this.btnBrowseFolder.Location = new System.Drawing.Point(477, 20);
            this.btnBrowseFolder.Name = "btnBrowseFolder";
            this.btnBrowseFolder.Size = new System.Drawing.Size(25, 23);
            this.btnBrowseFolder.TabIndex = 3;
            this.btnBrowseFolder.Text = "...";
            this.btnBrowseFolder.UseVisualStyleBackColor = true;
            this.btnBrowseFolder.Click += new System.EventHandler(this.btnBrowseFolder_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Package Name:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Output Path:";
            // 
            // txtPackageName
            // 
            this.txtPackageName.Location = new System.Drawing.Point(96, 46);
            this.txtPackageName.Name = "txtPackageName";
            this.txtPackageName.Size = new System.Drawing.Size(375, 20);
            this.txtPackageName.TabIndex = 1;
            this.txtPackageName.Text = "Migration-Package";
            // 
            // txtOutputPath
            // 
            this.txtOutputPath.Location = new System.Drawing.Point(96, 20);
            this.txtOutputPath.Name = "txtOutputPath";
            this.txtOutputPath.Size = new System.Drawing.Size(375, 20);
            this.txtOutputPath.TabIndex = 0;
            // 
            // SelectPackageNameAndStorageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 130);
            this.Controls.Add(this.gbOutputSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectPackageNameAndStorageForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Publishing Setup";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SelectPackageNameAndStorageForm_Load);
            this.gbOutputSettings.ResumeLayout(false);
            this.gbOutputSettings.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOutputSettings;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPackageName;
        private System.Windows.Forms.TextBox txtOutputPath;
        private System.Windows.Forms.Button btnBrowseFolder;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnProceed;
    }
}