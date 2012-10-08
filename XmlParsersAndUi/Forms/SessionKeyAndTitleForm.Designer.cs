namespace XmlParsersAndUi {
    partial class SessionKeyAndTitleForm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtSessionKey = new System.Windows.Forms.TextBox();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnProceed = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.nudStartIndex = new System.Windows.Forms.NumericUpDown();
            this.btnSelectFolderName = new System.Windows.Forms.Button();
            this.txtOperation = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTestTitle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudStartIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Session Key:";
            // 
            // txtSessionKey
            // 
            this.txtSessionKey.Location = new System.Drawing.Point(81, 12);
            this.txtSessionKey.Name = "txtSessionKey";
            this.txtSessionKey.Size = new System.Drawing.Size(199, 20);
            this.txtSessionKey.TabIndex = 0;
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point(81, 64);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(199, 20);
            this.txtFolderName.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Folder Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(149, 159);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnProceed
            // 
            this.btnProceed.Location = new System.Drawing.Point(68, 159);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(75, 23);
            this.btnProceed.TabIndex = 5;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Start Index: ";
            // 
            // nudStartIndex
            // 
            this.nudStartIndex.Location = new System.Drawing.Point(81, 116);
            this.nudStartIndex.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudStartIndex.Name = "nudStartIndex";
            this.nudStartIndex.Size = new System.Drawing.Size(62, 20);
            this.nudStartIndex.TabIndex = 4;
            this.nudStartIndex.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnSelectFolderName
            // 
            this.btnSelectFolderName.Location = new System.Drawing.Point(230, 88);
            this.btnSelectFolderName.Name = "btnSelectFolderName";
            this.btnSelectFolderName.Size = new System.Drawing.Size(47, 23);
            this.btnSelectFolderName.TabIndex = 3;
            this.btnSelectFolderName.Text = "Select";
            this.btnSelectFolderName.UseVisualStyleBackColor = true;
            this.btnSelectFolderName.Click += new System.EventHandler(this.btnSelectFolderName_Click);
            // 
            // txtOperation
            // 
            this.txtOperation.Location = new System.Drawing.Point(81, 90);
            this.txtOperation.Name = "txtOperation";
            this.txtOperation.ReadOnly = true;
            this.txtOperation.Size = new System.Drawing.Size(143, 20);
            this.txtOperation.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Operation:";
            // 
            // txtTestTitle
            // 
            this.txtTestTitle.Location = new System.Drawing.Point(81, 38);
            this.txtTestTitle.Name = "txtTestTitle";
            this.txtTestTitle.Size = new System.Drawing.Size(199, 20);
            this.txtTestTitle.TabIndex = 1;
            this.txtTestTitle.TextChanged += new System.EventHandler(this.txtTestTitle_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Test Title:";
            // 
            // SessionKeyAndTitleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 194);
            this.ControlBox = false;
            this.Controls.Add(this.txtTestTitle);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOperation);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnSelectFolderName);
            this.Controls.Add(this.nudStartIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtFolderName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSessionKey);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SessionKeyAndTitleForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Input Session Key and Folder";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SessionKeyAndTitleForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudStartIndex)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSessionKey;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudStartIndex;
        private System.Windows.Forms.Button btnSelectFolderName;
        private System.Windows.Forms.TextBox txtOperation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTestTitle;
        private System.Windows.Forms.Label label5;
    }
}