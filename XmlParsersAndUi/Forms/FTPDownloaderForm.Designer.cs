namespace XmlParsersAndUi.Forms {
    partial class FTPDownloaderForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FTPDownloaderForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.btnBrowseFileList = new System.Windows.Forms.Button();
            this.txtInputFileList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRemoteLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseOutputFolder = new System.Windows.Forms.Button();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.btnStartDownload = new System.Windows.Forms.Button();
            this.btnResetForm = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.btnBrowseFileList);
            this.groupBox1.Controls.Add(this.txtInputFileList);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtRemoteLocation);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(461, 113);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(365, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Host:";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(403, 32);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(52, 20);
            this.txtHost.TabIndex = 5;
            // 
            // btnBrowseFileList
            // 
            this.btnBrowseFileList.Location = new System.Drawing.Point(416, 69);
            this.btnBrowseFileList.Name = "btnBrowseFileList";
            this.btnBrowseFileList.Size = new System.Drawing.Size(36, 23);
            this.btnBrowseFileList.TabIndex = 4;
            this.btnBrowseFileList.Text = "...";
            this.btnBrowseFileList.UseVisualStyleBackColor = true;
            this.btnBrowseFileList.Click += new System.EventHandler(this.btnBrowseFileList_Click);
            // 
            // txtInputFileList
            // 
            this.txtInputFileList.Location = new System.Drawing.Point(9, 71);
            this.txtInputFileList.Name = "txtInputFileList";
            this.txtInputFileList.Size = new System.Drawing.Size(404, 20);
            this.txtInputFileList.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Input File List (Line delimited):";
            // 
            // txtRemoteLocation
            // 
            this.txtRemoteLocation.Location = new System.Drawing.Point(9, 32);
            this.txtRemoteLocation.Name = "txtRemoteLocation";
            this.txtRemoteLocation.Size = new System.Drawing.Size(282, 20);
            this.txtRemoteLocation.TabIndex = 1;
            this.txtRemoteLocation.TextChanged += new System.EventHandler(this.txtRemoteLocation_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remote Location:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnBrowseOutputFolder);
            this.groupBox2.Controls.Add(this.txtOutputFolder);
            this.groupBox2.Location = new System.Drawing.Point(13, 132);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(461, 73);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Output Folder:";
            // 
            // btnBrowseOutputFolder
            // 
            this.btnBrowseOutputFolder.Location = new System.Drawing.Point(413, 30);
            this.btnBrowseOutputFolder.Name = "btnBrowseOutputFolder";
            this.btnBrowseOutputFolder.Size = new System.Drawing.Size(36, 23);
            this.btnBrowseOutputFolder.TabIndex = 6;
            this.btnBrowseOutputFolder.Text = "...";
            this.btnBrowseOutputFolder.UseVisualStyleBackColor = true;
            this.btnBrowseOutputFolder.Click += new System.EventHandler(this.btnBrowseOutputFolder_Click);
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(6, 32);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(404, 20);
            this.txtOutputFolder.TabIndex = 5;
            // 
            // btnStartDownload
            // 
            this.btnStartDownload.Location = new System.Drawing.Point(136, 211);
            this.btnStartDownload.Name = "btnStartDownload";
            this.btnStartDownload.Size = new System.Drawing.Size(105, 23);
            this.btnStartDownload.TabIndex = 2;
            this.btnStartDownload.Text = "Start Download";
            this.btnStartDownload.UseVisualStyleBackColor = true;
            this.btnStartDownload.Click += new System.EventHandler(this.btnStartDownload_Click);
            // 
            // btnResetForm
            // 
            this.btnResetForm.Location = new System.Drawing.Point(247, 211);
            this.btnResetForm.Name = "btnResetForm";
            this.btnResetForm.Size = new System.Drawing.Size(105, 23);
            this.btnResetForm.TabIndex = 3;
            this.btnResetForm.Text = "Reset";
            this.btnResetForm.UseVisualStyleBackColor = true;
            this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
            // 
            // FTPDownloaderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 244);
            this.Controls.Add(this.btnResetForm);
            this.Controls.Add(this.btnStartDownload);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FTPDownloaderForm";
            this.Text = "Downloader";
            this.Load += new System.EventHandler(this.FTPDownloaderForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtRemoteLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputFileList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseFileList;
        private System.Windows.Forms.Button btnStartDownload;
        private System.Windows.Forms.Button btnResetForm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBrowseOutputFolder;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHost;
    }
}