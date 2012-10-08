namespace PackageGenerator.Forms {
    partial class ExcelComparisonForm {
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
            this.gbCustlogs = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnProceed = new System.Windows.Forms.Button();
            this.btnBrowseFileTwo = new System.Windows.Forms.Button();
            this.txtFileTwoInput = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBrowseFileOne = new System.Windows.Forms.Button();
            this.txtFileOneInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbCustlogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbCustlogs
            // 
            this.gbCustlogs.Controls.Add(this.btnCancel);
            this.gbCustlogs.Controls.Add(this.btnProceed);
            this.gbCustlogs.Controls.Add(this.btnBrowseFileTwo);
            this.gbCustlogs.Controls.Add(this.txtFileTwoInput);
            this.gbCustlogs.Controls.Add(this.label2);
            this.gbCustlogs.Controls.Add(this.btnBrowseFileOne);
            this.gbCustlogs.Controls.Add(this.txtFileOneInput);
            this.gbCustlogs.Controls.Add(this.label1);
            this.gbCustlogs.Location = new System.Drawing.Point(13, 13);
            this.gbCustlogs.Name = "gbCustlogs";
            this.gbCustlogs.Size = new System.Drawing.Size(437, 121);
            this.gbCustlogs.TabIndex = 2;
            this.gbCustlogs.TabStop = false;
            this.gbCustlogs.Text = "Customizations Logs";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnCancel.Location = new System.Drawing.Point(221, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnProceed
            // 
            this.btnProceed.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnProceed.Location = new System.Drawing.Point(140, 92);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(75, 23);
            this.btnProceed.TabIndex = 3;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // btnBrowseFileTwo
            // 
            this.btnBrowseFileTwo.Location = new System.Drawing.Point(407, 53);
            this.btnBrowseFileTwo.Name = "btnBrowseFileTwo";
            this.btnBrowseFileTwo.Size = new System.Drawing.Size(22, 23);
            this.btnBrowseFileTwo.TabIndex = 7;
            this.btnBrowseFileTwo.Text = "...";
            this.btnBrowseFileTwo.UseVisualStyleBackColor = true;
            this.btnBrowseFileTwo.Click += new System.EventHandler(this.btnBrowseFileTwo_Click);
            // 
            // txtFileTwoInput
            // 
            this.txtFileTwoInput.Location = new System.Drawing.Point(75, 55);
            this.txtFileTwoInput.Name = "txtFileTwoInput";
            this.txtFileTwoInput.Size = new System.Drawing.Size(326, 20);
            this.txtFileTwoInput.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Current:";
            // 
            // btnBrowseFileOne
            // 
            this.btnBrowseFileOne.Location = new System.Drawing.Point(407, 25);
            this.btnBrowseFileOne.Name = "btnBrowseFileOne";
            this.btnBrowseFileOne.Size = new System.Drawing.Size(22, 23);
            this.btnBrowseFileOne.TabIndex = 4;
            this.btnBrowseFileOne.Text = "...";
            this.btnBrowseFileOne.UseVisualStyleBackColor = true;
            this.btnBrowseFileOne.Click += new System.EventHandler(this.btnBrowseFileOne_Click);
            // 
            // txtFileOneInput
            // 
            this.txtFileOneInput.Location = new System.Drawing.Point(75, 27);
            this.txtFileOneInput.Name = "txtFileOneInput";
            this.txtFileOneInput.Size = new System.Drawing.Size(326, 20);
            this.txtFileOneInput.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Reference:";
            // 
            // ExcelComparisonForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 154);
            this.Controls.Add(this.gbCustlogs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ExcelComparisonForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Customizations Comparison";
            this.TopMost = true;
            this.gbCustlogs.ResumeLayout(false);
            this.gbCustlogs.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbCustlogs;
        private System.Windows.Forms.Button btnBrowseFileOne;
        private System.Windows.Forms.TextBox txtFileOneInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnProceed;
        private System.Windows.Forms.Button btnBrowseFileTwo;
        private System.Windows.Forms.TextBox txtFileTwoInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
    }
}