namespace XmlParsersAndUi {
    partial class BulkCustomsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkCustomsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkConvertFast = new System.Windows.Forms.CheckBox();
            this.txtCustom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFocusCode = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtInputDir = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkConvertFast);
            this.groupBox1.Controls.Add(this.txtCustom);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtFocusCode);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.txtInputDir);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(424, 159);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // chkConvertFast
            // 
            this.chkConvertFast.AutoSize = true;
            this.chkConvertFast.Location = new System.Drawing.Point(76, 102);
            this.chkConvertFast.Name = "chkConvertFast";
            this.chkConvertFast.Size = new System.Drawing.Size(132, 17);
            this.chkConvertFast.TabIndex = 9;
            this.chkConvertFast.Text = "Convert To Fast Mode";
            this.chkConvertFast.UseVisualStyleBackColor = true;
            this.chkConvertFast.CheckedChanged += new System.EventHandler(this.chkConvertFast_CheckedChanged);
            // 
            // txtCustom
            // 
            this.txtCustom.Location = new System.Drawing.Point(76, 76);
            this.txtCustom.Name = "txtCustom";
            this.txtCustom.Size = new System.Drawing.Size(339, 20);
            this.txtCustom.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Custom:";
            // 
            // txtFocusCode
            // 
            this.txtFocusCode.Location = new System.Drawing.Point(76, 50);
            this.txtFocusCode.Name = "txtFocusCode";
            this.txtFocusCode.Size = new System.Drawing.Size(339, 20);
            this.txtFocusCode.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Focus Code: ";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(224, 125);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(143, 125);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 3;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtInputDir
            // 
            this.txtInputDir.Location = new System.Drawing.Point(76, 23);
            this.txtInputDir.Name = "txtInputDir";
            this.txtInputDir.Size = new System.Drawing.Size(298, 20);
            this.txtInputDir.TabIndex = 2;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(380, 21);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(35, 23);
            this.btnBrowse.TabIndex = 0;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Input Dir: ";
            // 
            // BulkCustomsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 183);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BulkCustomsForm";
            this.Text = "Bulk Customs";
            this.Load += new System.EventHandler(this.BulkCustomsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtInputDir;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFocusCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkConvertFast;
    }
}