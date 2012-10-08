namespace XmlParsersAndUi.Forms {
    partial class OracleUpdaterForm {
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
            this.btnStart = new System.Windows.Forms.Button();
            this.txtInputDir = new System.Windows.Forms.TextBox();
            this.txtNickname = new System.Windows.Forms.TextBox();
            this.txtOra11Nickname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbHasEnv = new System.Windows.Forms.CheckBox();
            this.cboModes = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbEnvConf = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtTPKNickname = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTPKNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lbTpks = new System.Windows.Forms.ListBox();
            this.txtEnvNickname = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtEnvNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBranch = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbEnvConf.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(180, 95);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // txtInputDir
            // 
            this.txtInputDir.Location = new System.Drawing.Point(125, 69);
            this.txtInputDir.Name = "txtInputDir";
            this.txtInputDir.Size = new System.Drawing.Size(280, 20);
            this.txtInputDir.TabIndex = 1;
            // 
            // txtNickname
            // 
            this.txtNickname.Location = new System.Drawing.Point(125, 17);
            this.txtNickname.Name = "txtNickname";
            this.txtNickname.Size = new System.Drawing.Size(109, 20);
            this.txtNickname.TabIndex = 2;
            this.txtNickname.Text = "DEFAULT";
            this.txtNickname.TextChanged += new System.EventHandler(this.txtNickname_TextChanged);
            // 
            // txtOra11Nickname
            // 
            this.txtOra11Nickname.Location = new System.Drawing.Point(125, 43);
            this.txtOra11Nickname.Name = "txtOra11Nickname";
            this.txtOra11Nickname.Size = new System.Drawing.Size(109, 20);
            this.txtOra11Nickname.TabIndex = 3;
            this.txtOra11Nickname.Text = "DEFAULT_ORA_11";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Original Nickname:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Oracle 11 Nickname:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "TPK Location:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lbTpks);
            this.groupBox1.Location = new System.Drawing.Point(13, 129);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 472);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtBranch);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.cbHasEnv);
            this.groupBox2.Controls.Add(this.cboModes);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.gbEnvConf);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.txtTPKNickname);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtTPKNumber);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(167, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 445);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Information";
            // 
            // cbHasEnv
            // 
            this.cbHasEnv.AutoSize = true;
            this.cbHasEnv.Location = new System.Drawing.Point(67, 152);
            this.cbHasEnv.Name = "cbHasEnv";
            this.cbHasEnv.Size = new System.Drawing.Size(67, 17);
            this.cbHasEnv.TabIndex = 19;
            this.cbHasEnv.Text = "Has Env";
            this.cbHasEnv.UseVisualStyleBackColor = true;
            this.cbHasEnv.CheckedChanged += new System.EventHandler(this.cbHasEnv_CheckedChanged);
            // 
            // cboModes
            // 
            this.cboModes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboModes.FormattingEnabled = true;
            this.cboModes.Items.AddRange(new object[] {
            "TPK-Public",
            "TPK-Murex"});
            this.cboModes.Location = new System.Drawing.Point(67, 175);
            this.cboModes.Name = "cboModes";
            this.cboModes.Size = new System.Drawing.Size(121, 21);
            this.cboModes.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 178);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = "Mode";
            // 
            // gbEnvConf
            // 
            this.gbEnvConf.Controls.Add(this.txtEnvNickname);
            this.gbEnvConf.Controls.Add(this.txtEnvNumber);
            this.gbEnvConf.Controls.Add(this.label9);
            this.gbEnvConf.Controls.Add(this.label8);
            this.gbEnvConf.Location = new System.Drawing.Point(6, 198);
            this.gbEnvConf.Name = "gbEnvConf";
            this.gbEnvConf.Size = new System.Drawing.Size(262, 241);
            this.gbEnvConf.TabIndex = 16;
            this.gbEnvConf.TabStop = false;
            this.gbEnvConf.Text = "Env Configuration";
            this.gbEnvConf.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 129);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ora 11:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(67, 126);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(109, 20);
            this.textBox1.TabIndex = 13;
            this.textBox1.Text = "DEFAULT_ORA_11";
            // 
            // txtTPKNickname
            // 
            this.txtTPKNickname.Location = new System.Drawing.Point(67, 100);
            this.txtTPKNickname.Name = "txtTPKNickname";
            this.txtTPKNickname.Size = new System.Drawing.Size(201, 20);
            this.txtTPKNickname.TabIndex = 10;
            this.txtTPKNickname.Text = "DEFAULT";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Nickname:";
            // 
            // txtTPKNumber
            // 
            this.txtTPKNumber.Location = new System.Drawing.Point(67, 74);
            this.txtTPKNumber.Name = "txtTPKNumber";
            this.txtTPKNumber.Size = new System.Drawing.Size(201, 20);
            this.txtTPKNumber.TabIndex = 8;
            this.txtTPKNumber.Text = "PAR.TPK.0000000";
            this.txtTPKNumber.TextChanged += new System.EventHandler(this.txtTPKNumber_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "TPK:";
            // 
            // lbTpks
            // 
            this.lbTpks.FormattingEnabled = true;
            this.lbTpks.Location = new System.Drawing.Point(6, 19);
            this.lbTpks.Name = "lbTpks";
            this.lbTpks.Size = new System.Drawing.Size(144, 446);
            this.lbTpks.TabIndex = 0;
            // 
            // txtEnvNickname
            // 
            this.txtEnvNickname.Location = new System.Drawing.Point(67, 59);
            this.txtEnvNickname.Name = "txtEnvNickname";
            this.txtEnvNickname.Size = new System.Drawing.Size(189, 20);
            this.txtEnvNickname.TabIndex = 14;
            this.txtEnvNickname.Text = "DEFAULT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Nickname:";
            // 
            // txtEnvNumber
            // 
            this.txtEnvNumber.Location = new System.Drawing.Point(67, 30);
            this.txtEnvNumber.Name = "txtEnvNumber";
            this.txtEnvNumber.Size = new System.Drawing.Size(189, 20);
            this.txtEnvNumber.TabIndex = 12;
            this.txtEnvNumber.Text = "PAR.ENV.0000000";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "ENV:";
            // 
            // txtBranch
            // 
            this.txtBranch.Location = new System.Drawing.Point(67, 48);
            this.txtBranch.Name = "txtBranch";
            this.txtBranch.Size = new System.Drawing.Size(201, 20);
            this.txtBranch.TabIndex = 21;
            this.txtBranch.Text = "trunk";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(44, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Branch:";
            // 
            // OracleUpdaterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(472, 613);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtOra11Nickname);
            this.Controls.Add(this.txtNickname);
            this.Controls.Add(this.txtInputDir);
            this.Controls.Add(this.btnStart);
            this.Name = "OracleUpdaterForm";
            this.Text = "OracleUpdaterForm";
            this.Load += new System.EventHandler(this.OracleUpdaterForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbEnvConf.ResumeLayout(false);
            this.gbEnvConf.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TextBox txtInputDir;
        private System.Windows.Forms.TextBox txtNickname;
        private System.Windows.Forms.TextBox txtOra11Nickname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbTpks;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTPKNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTPKNickname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox gbEnvConf;
        private System.Windows.Forms.CheckBox cbHasEnv;
        private System.Windows.Forms.ComboBox cboModes;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtEnvNickname;
        private System.Windows.Forms.TextBox txtEnvNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtBranch;
        private System.Windows.Forms.Label label10;
    }
}