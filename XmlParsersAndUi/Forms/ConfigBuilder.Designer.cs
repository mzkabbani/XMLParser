namespace XmlParsersAndUi {
    partial class ConfigBuilder {
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
            this.tcNicknameGenerator = new System.Windows.Forms.TabControl();
            this.tpNickname = new System.Windows.Forms.TabPage();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.tpImport = new System.Windows.Forms.TabPage();
            this.lbImport = new System.Windows.Forms.ListBox();
            this.tpCustomize = new System.Windows.Forms.TabPage();
            this.gbParameters = new System.Windows.Forms.GroupBox();
            this.lbCustomize = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.txtConfigFile = new System.Windows.Forms.TextBox();
            this.tcNicknameGenerator.SuspendLayout();
            this.tpNickname.SuspendLayout();
            this.tpImport.SuspendLayout();
            this.tpCustomize.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tcNicknameGenerator
            // 
            this.tcNicknameGenerator.Controls.Add(this.tpNickname);
            this.tcNicknameGenerator.Controls.Add(this.tpImport);
            this.tcNicknameGenerator.Controls.Add(this.tpCustomize);
            this.tcNicknameGenerator.Location = new System.Drawing.Point(12, 12);
            this.tcNicknameGenerator.Multiline = true;
            this.tcNicknameGenerator.Name = "tcNicknameGenerator";
            this.tcNicknameGenerator.SelectedIndex = 0;
            this.tcNicknameGenerator.Size = new System.Drawing.Size(756, 295);
            this.tcNicknameGenerator.TabIndex = 1;
            // 
            // tpNickname
            // 
            this.tpNickname.Controls.Add(this.listBox1);
            this.tpNickname.Location = new System.Drawing.Point(4, 22);
            this.tpNickname.Name = "tpNickname";
            this.tpNickname.Padding = new System.Windows.Forms.Padding(3);
            this.tpNickname.Size = new System.Drawing.Size(748, 269);
            this.tpNickname.TabIndex = 0;
            this.tpNickname.Text = "Nickname";
            this.tpNickname.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(6, 6);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(120, 95);
            this.listBox1.TabIndex = 0;
            // 
            // tpImport
            // 
            this.tpImport.Controls.Add(this.lbImport);
            this.tpImport.Location = new System.Drawing.Point(4, 22);
            this.tpImport.Name = "tpImport";
            this.tpImport.Padding = new System.Windows.Forms.Padding(3);
            this.tpImport.Size = new System.Drawing.Size(748, 269);
            this.tpImport.TabIndex = 1;
            this.tpImport.Text = "Import";
            this.tpImport.UseVisualStyleBackColor = true;
            // 
            // lbImport
            // 
            this.lbImport.FormattingEnabled = true;
            this.lbImport.Location = new System.Drawing.Point(3, 3);
            this.lbImport.Name = "lbImport";
            this.lbImport.Size = new System.Drawing.Size(120, 251);
            this.lbImport.TabIndex = 1;
            // 
            // tpCustomize
            // 
            this.tpCustomize.Controls.Add(this.gbParameters);
            this.tpCustomize.Controls.Add(this.lbCustomize);
            this.tpCustomize.Location = new System.Drawing.Point(4, 22);
            this.tpCustomize.Name = "tpCustomize";
            this.tpCustomize.Size = new System.Drawing.Size(748, 269);
            this.tpCustomize.TabIndex = 2;
            this.tpCustomize.Text = "Customize";
            this.tpCustomize.UseVisualStyleBackColor = true;
            // 
            // gbParameters
            // 
            this.gbParameters.Location = new System.Drawing.Point(129, 4);
            this.gbParameters.Name = "gbParameters";
            this.gbParameters.Size = new System.Drawing.Size(616, 250);
            this.gbParameters.TabIndex = 4;
            this.gbParameters.TabStop = false;
            this.gbParameters.Text = "Parameters";
            this.gbParameters.Visible = false;
            // 
            // lbCustomize
            // 
            this.lbCustomize.FormattingEnabled = true;
            this.lbCustomize.Location = new System.Drawing.Point(3, 2);
            this.lbCustomize.Name = "lbCustomize";
            this.lbCustomize.Size = new System.Drawing.Size(120, 264);
            this.lbCustomize.TabIndex = 2;
            this.lbCustomize.DoubleClick += new System.EventHandler(this.lbCustomize_DoubleClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 314);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(756, 320);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLogs);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(748, 294);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Logs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtConfigFile);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(748, 294);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "ConfigFile";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtLogs
            // 
            this.txtLogs.Location = new System.Drawing.Point(6, 6);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogs.Size = new System.Drawing.Size(736, 282);
            this.txtLogs.TabIndex = 1;
            // 
            // txtConfigFile
            // 
            this.txtConfigFile.Location = new System.Drawing.Point(6, 6);
            this.txtConfigFile.Multiline = true;
            this.txtConfigFile.Name = "txtConfigFile";
            this.txtConfigFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtConfigFile.Size = new System.Drawing.Size(736, 282);
            this.txtConfigFile.TabIndex = 2;
            // 
            // ConfigBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 646);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.tcNicknameGenerator);
            this.Name = "ConfigBuilder";
            this.Text = "ConfigBuilder";
            this.Load += new System.EventHandler(this.ConfigBuilder_Load);
            this.tcNicknameGenerator.ResumeLayout(false);
            this.tpNickname.ResumeLayout(false);
            this.tpImport.ResumeLayout(false);
            this.tpCustomize.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcNicknameGenerator;
        private System.Windows.Forms.TabPage tpNickname;
        private System.Windows.Forms.TabPage tpImport;
        private System.Windows.Forms.TabPage tpCustomize;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox lbImport;
        private System.Windows.Forms.ListBox lbCustomize;
        private System.Windows.Forms.GroupBox gbParameters;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txtConfigFile;
    }
}