namespace OracleConfigAlterations {
    partial class FeederDumpReplacements {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbTpkList = new System.Windows.Forms.ListBox();
            this.bgwCheckoutWorker = new System.ComponentModel.BackgroundWorker();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtBranch);
            this.groupBox1.Controls.Add(this.btnCheckout);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtInputFile);
            this.groupBox1.Controls.Add(this.btnParse);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(630, 207);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(81, 43);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(75, 23);
            this.btnParse.TabIndex = 0;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // txtInputFile
            // 
            this.txtInputFile.Location = new System.Drawing.Point(63, 17);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(480, 20);
            this.txtInputFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Input File";
            // 
            // lbTpkList
            // 
            this.lbTpkList.FormattingEnabled = true;
            this.lbTpkList.Location = new System.Drawing.Point(13, 255);
            this.lbTpkList.Name = "lbTpkList";
            this.lbTpkList.Size = new System.Drawing.Size(120, 95);
            this.lbTpkList.TabIndex = 1;
            // 
            // bgwCheckoutWorker
            // 
            this.bgwCheckoutWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCheckoutWorker_DoWork);
            this.bgwCheckoutWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCheckoutWorker_ProgressChanged);
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(301, 278);
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.Size = new System.Drawing.Size(100, 20);
            this.txtLogs.TabIndex = 2;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(162, 43);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(75, 23);
            this.btnCheckout.TabIndex = 3;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // txtBranch
            // 
            this.txtBranch.Location = new System.Drawing.Point(63, 84);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(197, 20);
            this.txtBranch.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Branch";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(243, 43);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // FeederDumpReplacements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 405);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.lbTpkList);
            this.Controls.Add(this.groupBox1);
            this.Name = "FeederDumpReplacements";
            this.Text = "FeederDumpReplacements";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.ListBox lbTpkList;
        private System.ComponentModel.BackgroundWorker bgwCheckoutWorker;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnStart;
    }
}