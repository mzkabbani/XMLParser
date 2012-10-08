namespace MacroJoiner {
    partial class Form1 {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnShowOutput = new System.Windows.Forms.Button();
            this.btnBrowseOutDir = new System.Windows.Forms.Button();
            this.btnBrowseInDir = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInputDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.chkAllOneFile = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkAllOneFile);
            this.groupBox1.Controls.Add(this.btnShowOutput);
            this.groupBox1.Controls.Add(this.btnBrowseOutDir);
            this.groupBox1.Controls.Add(this.btnBrowseInDir);
            this.groupBox1.Controls.Add(this.txtOutputDir);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtInputDir);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(538, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // btnShowOutput
            // 
            this.btnShowOutput.Location = new System.Drawing.Point(313, 69);
            this.btnShowOutput.Name = "btnShowOutput";
            this.btnShowOutput.Size = new System.Drawing.Size(75, 23);
            this.btnShowOutput.TabIndex = 8;
            this.btnShowOutput.Text = "View Output";
            this.btnShowOutput.UseVisualStyleBackColor = true;
            this.btnShowOutput.Click += new System.EventHandler(this.btnShowOutput_Click);
            // 
            // btnBrowseOutDir
            // 
            this.btnBrowseOutDir.Location = new System.Drawing.Point(501, 43);
            this.btnBrowseOutDir.Name = "btnBrowseOutDir";
            this.btnBrowseOutDir.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseOutDir.TabIndex = 7;
            this.btnBrowseOutDir.Text = "...";
            this.btnBrowseOutDir.UseVisualStyleBackColor = true;
            this.btnBrowseOutDir.Click += new System.EventHandler(this.btnBrowseOutDir_Click);
            // 
            // btnBrowseInDir
            // 
            this.btnBrowseInDir.Location = new System.Drawing.Point(501, 14);
            this.btnBrowseInDir.Name = "btnBrowseInDir";
            this.btnBrowseInDir.Size = new System.Drawing.Size(30, 23);
            this.btnBrowseInDir.TabIndex = 6;
            this.btnBrowseInDir.Text = "...";
            this.btnBrowseInDir.UseVisualStyleBackColor = true;
            this.btnBrowseInDir.Click += new System.EventHandler(this.btnBrowseInDir_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Location = new System.Drawing.Point(74, 43);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(421, 20);
            this.txtOutputDir.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output Dir:";
            // 
            // txtInputDir
            // 
            this.txtInputDir.Location = new System.Drawing.Point(74, 17);
            this.txtInputDir.Name = "txtInputDir";
            this.txtInputDir.Size = new System.Drawing.Size(421, 20);
            this.txtInputDir.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input Dir:";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(232, 69);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(151, 69);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chkAllOneFile
            // 
            this.chkAllOneFile.AutoSize = true;
            this.chkAllOneFile.Location = new System.Drawing.Point(404, 73);
            this.chkAllOneFile.Name = "chkAllOneFile";
            this.chkAllOneFile.Size = new System.Drawing.Size(112, 17);
            this.chkAllOneFile.TabIndex = 9;
            this.chkAllOneFile.Text = "Generate One File";
            this.chkAllOneFile.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 131);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Join Macros";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInputDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseOutDir;
        private System.Windows.Forms.Button btnBrowseInDir;
        private System.Windows.Forms.Button btnShowOutput;
        private System.Windows.Forms.CheckBox chkAllOneFile;
    }
}

