namespace XmlParsersAndUi {
    partial class SlashAdderToEventsFiles {
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOutputDir = new System.Windows.Forms.Button();
            this.txtInputDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkLstAllStepEvents = new System.Windows.Forms.CheckedListBox();
            this.btnParse = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnGroup = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnParse);
            this.groupBox2.Controls.Add(this.btnOutputDir);
            this.groupBox2.Controls.Add(this.txtInputDir);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 91);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // btnOutputDir
            // 
            this.btnOutputDir.Location = new System.Drawing.Point(431, 17);
            this.btnOutputDir.Name = "btnOutputDir";
            this.btnOutputDir.Size = new System.Drawing.Size(24, 23);
            this.btnOutputDir.TabIndex = 3;
            this.btnOutputDir.Text = "...";
            this.btnOutputDir.UseVisualStyleBackColor = true;
            this.btnOutputDir.Click += new System.EventHandler(this.btnOutputDir_Click);
            // 
            // txtInputDir
            // 
            this.txtInputDir.Location = new System.Drawing.Point(117, 19);
            this.txtInputDir.Name = "txtInputDir";
            this.txtInputDir.Size = new System.Drawing.Size(308, 20);
            this.txtInputDir.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Input Folder:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.chkLstAllStepEvents);
            this.groupBox1.Location = new System.Drawing.Point(12, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 282);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Slashes";
            // 
            // chkLstAllStepEvents
            // 
            this.chkLstAllStepEvents.CheckOnClick = true;
            this.chkLstAllStepEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkLstAllStepEvents.FormattingEnabled = true;
            this.chkLstAllStepEvents.Location = new System.Drawing.Point(3, 16);
            this.chkLstAllStepEvents.Name = "chkLstAllStepEvents";
            this.chkLstAllStepEvents.Size = new System.Drawing.Size(458, 259);
            this.chkLstAllStepEvents.TabIndex = 0;
            // 
            // btnParse
            // 
            this.btnParse.Location = new System.Drawing.Point(172, 45);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(118, 39);
            this.btnParse.TabIndex = 28;
            this.btnParse.Text = "Parse";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSelectAll.Location = new System.Drawing.Point(129, 397);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(94, 23);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click_1);
            // 
            // btnGroup
            // 
            this.btnGroup.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGroup.Location = new System.Drawing.Point(229, 397);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(94, 23);
            this.btnGroup.TabIndex = 6;
            this.btnGroup.Text = "Slash Selected";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click_1);
            // 
            // SlashAdderToEventsFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 432);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnGroup);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "SlashAdderToEventsFiles";
            this.Text = "SlashAdderToEventsFiles";
            this.Load += new System.EventHandler(this.SlashAdderToEventsFiles_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnOutputDir;
        private System.Windows.Forms.TextBox txtInputDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckedListBox chkLstAllStepEvents;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnGroup;
    }
}