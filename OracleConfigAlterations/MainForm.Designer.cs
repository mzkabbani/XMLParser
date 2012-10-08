namespace OracleConfigAlterations {
    partial class MainForm {
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
            this.lstTpks = new System.Windows.Forms.ListBox();
            this.btnCheckout = new System.Windows.Forms.Button();
            this.btnShowOut = new System.Windows.Forms.Button();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.bgwCheckoutWorker = new System.ComponentModel.BackgroundWorker();
            this.btnStart = new System.Windows.Forms.Button();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.txtConnString = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lstTpks
            // 
            this.lstTpks.FormattingEnabled = true;
            this.lstTpks.Location = new System.Drawing.Point(12, 12);
            this.lstTpks.Name = "lstTpks";
            this.lstTpks.Size = new System.Drawing.Size(204, 212);
            this.lstTpks.TabIndex = 0;
            // 
            // btnCheckout
            // 
            this.btnCheckout.Location = new System.Drawing.Point(308, 103);
            this.btnCheckout.Name = "btnCheckout";
            this.btnCheckout.Size = new System.Drawing.Size(75, 23);
            this.btnCheckout.TabIndex = 1;
            this.btnCheckout.Text = "Checkout";
            this.btnCheckout.UseVisualStyleBackColor = true;
            this.btnCheckout.Click += new System.EventHandler(this.btnCheckout_Click);
            // 
            // btnShowOut
            // 
            this.btnShowOut.Location = new System.Drawing.Point(384, 138);
            this.btnShowOut.Name = "btnShowOut";
            this.btnShowOut.Size = new System.Drawing.Size(75, 23);
            this.btnShowOut.TabIndex = 2;
            this.btnShowOut.Text = "Output";
            this.btnShowOut.UseVisualStyleBackColor = true;
            this.btnShowOut.Click += new System.EventHandler(this.btnShowOut_Click);
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(12, 230);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.Size = new System.Drawing.Size(704, 242);
            this.txtLogs.TabIndex = 3;
            // 
            // bgwCheckoutWorker
            // 
            this.bgwCheckoutWorker.WorkerReportsProgress = true;
            this.bgwCheckoutWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwCheckoutWorker_DoWork);
            this.bgwCheckoutWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwCheckoutWorker_ProgressChanged);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(393, 103);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtBranch
            // 
            this.txtBranch.Location = new System.Drawing.Point(323, 55);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(100, 20);
            this.txtBranch.TabIndex = 5;
            // 
            // txtConnString
            // 
            this.txtConnString.Location = new System.Drawing.Point(222, 12);
            this.txtConnString.Name = "txtConnString";
            this.txtConnString.Size = new System.Drawing.Size(399, 20);
            this.txtConnString.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 484);
            this.Controls.Add(this.txtConnString);
            this.Controls.Add(this.txtBranch);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtLogs);
            this.Controls.Add(this.btnShowOut);
            this.Controls.Add(this.btnCheckout);
            this.Controls.Add(this.lstTpks);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lstTpks;
        private System.Windows.Forms.Button btnCheckout;
        private System.Windows.Forms.Button btnShowOut;
        private System.Windows.Forms.TextBox txtLogs;
        private System.ComponentModel.BackgroundWorker bgwCheckoutWorker;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.TextBox txtConnString;
    }
}

