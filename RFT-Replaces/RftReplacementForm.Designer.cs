namespace XmlParsersAndUi {
    partial class RftReplacementForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RftReplacementForm));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRemoteDest = new System.Windows.Forms.TextBox();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.btnBrowseDes = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtLogText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.btnFtp = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Remote Path (Directory):";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtRemoteDest);
            this.groupBox1.Controls.Add(this.txtServer);
            this.groupBox1.Controls.Add(this.txtDest);
            this.groupBox1.Controls.Add(this.btnBrowseDes);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(582, 105);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 51);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Remote Server:";
            // 
            // txtRemoteDest
            // 
            this.txtRemoteDest.Location = new System.Drawing.Point(138, 22);
            this.txtRemoteDest.Name = "txtRemoteDest";
            this.txtRemoteDest.Size = new System.Drawing.Size(438, 20);
            this.txtRemoteDest.TabIndex = 9;
            this.txtRemoteDest.TextChanged += new System.EventHandler(this.txtRemoteDest_TextChanged);
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(138, 48);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(76, 20);
            this.txtServer.TabIndex = 8;
            // 
            // txtDest
            // 
            this.txtDest.Location = new System.Drawing.Point(138, 74);
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(357, 20);
            this.txtDest.TabIndex = 5;
            // 
            // btnBrowseDes
            // 
            this.btnBrowseDes.Location = new System.Drawing.Point(501, 72);
            this.btnBrowseDes.Name = "btnBrowseDes";
            this.btnBrowseDes.Size = new System.Drawing.Size(75, 23);
            this.btnBrowseDes.TabIndex = 4;
            this.btnBrowseDes.Text = "Browse";
            this.btnBrowseDes.UseVisualStyleBackColor = true;
            this.btnBrowseDes.Click += new System.EventHandler(this.btnBrowseDes_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Destination (Resource):";
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(56, 123);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(245, 31);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtLogText
            // 
            this.txtLogText.Location = new System.Drawing.Point(12, 173);
            this.txtLogText.Multiline = true;
            this.txtLogText.Name = "txtLogText";
            this.txtLogText.ReadOnly = true;
            this.txtLogText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogText.Size = new System.Drawing.Size(584, 84);
            this.txtLogText.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log:";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(226, 263);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 6;
            this.btnClearLog.Text = "Clear Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // btnFtp
            // 
            this.btnFtp.Location = new System.Drawing.Point(307, 123);
            this.btnFtp.Name = "btnFtp";
            this.btnFtp.Size = new System.Drawing.Size(245, 31);
            this.btnFtp.TabIndex = 8;
            this.btnFtp.Text = "FTP";
            this.btnFtp.UseVisualStyleBackColor = true;
            this.btnFtp.Click += new System.EventHandler(this.btnFtp_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(307, 263);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Downloads";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(388, 263);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "t1";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RftReplacementForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 290);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnFtp);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtLogText);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RftReplacementForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RFT - Screen Updater";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.Button btnBrowseDes;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txtLogText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.Button btnFtp;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.TextBox txtRemoteDest;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

