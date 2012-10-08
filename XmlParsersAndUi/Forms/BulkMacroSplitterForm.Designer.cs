namespace XmlParsersAndUi {
    partial class BulkMacroSplitterForm {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BulkMacroSplitterForm));
            this.label4 = new System.Windows.Forms.Label();
            this.txtSessionKey = new System.Windows.Forms.TextBox();
            this.btnShowOutput = new System.Windows.Forms.Button();
            this.btnSplitFile = new System.Windows.Forms.Button();
            this.chkLstAllStepEvents = new System.Windows.Forms.CheckedListBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameStepToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGroup = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkFsEvents = new System.Windows.Forms.CheckBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnOutputDir = new System.Windows.Forms.Button();
            this.txtOutputDir = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtDirectory = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtShowBuildFile = new System.Windows.Forms.Button();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Global Session Key:";
            // 
            // txtSessionKey
            // 
            this.txtSessionKey.Location = new System.Drawing.Point(120, 71);
            this.txtSessionKey.Name = "txtSessionKey";
            this.txtSessionKey.Size = new System.Drawing.Size(308, 20);
            this.txtSessionKey.TabIndex = 4;
            // 
            // btnShowOutput
            // 
            this.btnShowOutput.Location = new System.Drawing.Point(82, 464);
            this.btnShowOutput.Name = "btnShowOutput";
            this.btnShowOutput.Size = new System.Drawing.Size(157, 23);
            this.btnShowOutput.TabIndex = 3;
            this.btnShowOutput.Text = "Show Output";
            this.btnShowOutput.UseVisualStyleBackColor = true;
            this.btnShowOutput.Click += new System.EventHandler(this.btnShowOutput_Click);
            // 
            // btnSplitFile
            // 
            this.btnSplitFile.Location = new System.Drawing.Point(235, 97);
            this.btnSplitFile.Name = "btnSplitFile";
            this.btnSplitFile.Size = new System.Drawing.Size(157, 23);
            this.btnSplitFile.TabIndex = 6;
            this.btnSplitFile.Text = "Split File";
            this.btnSplitFile.UseVisualStyleBackColor = true;
            this.btnSplitFile.Click += new System.EventHandler(this.btnSplitFile_Click);
            // 
            // chkLstAllStepEvents
            // 
            this.chkLstAllStepEvents.CheckOnClick = true;
            this.chkLstAllStepEvents.ContextMenuStrip = this.contextMenuStrip1;
            this.chkLstAllStepEvents.FormattingEnabled = true;
            this.chkLstAllStepEvents.Location = new System.Drawing.Point(6, 19);
            this.chkLstAllStepEvents.Name = "chkLstAllStepEvents";
            this.chkLstAllStepEvents.Size = new System.Drawing.Size(446, 259);
            this.chkLstAllStepEvents.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameStepToolStripMenuItem});
            this.contextMenuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 26);
            // 
            // renameStepToolStripMenuItem
            // 
            this.renameStepToolStripMenuItem.Name = "renameStepToolStripMenuItem";
            this.renameStepToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.renameStepToolStripMenuItem.Text = "Rename Step";
            this.renameStepToolStripMenuItem.Click += new System.EventHandler(this.renameStepToolStripMenuItem_Click);
            // 
            // btnGroup
            // 
            this.btnGroup.Location = new System.Drawing.Point(235, 284);
            this.btnGroup.Name = "btnGroup";
            this.btnGroup.Size = new System.Drawing.Size(94, 23);
            this.btnGroup.TabIndex = 2;
            this.btnGroup.Text = "Group Selected";
            this.btnGroup.UseVisualStyleBackColor = true;
            this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkFsEvents);
            this.groupBox1.Controls.Add(this.btnSelectAll);
            this.groupBox1.Controls.Add(this.chkLstAllStepEvents);
            this.groupBox1.Controls.Add(this.btnGroup);
            this.groupBox1.Location = new System.Drawing.Point(12, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(464, 318);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Grouping";
            // 
            // chkFsEvents
            // 
            this.chkFsEvents.AutoSize = true;
            this.chkFsEvents.Location = new System.Drawing.Point(372, 288);
            this.chkFsEvents.Name = "chkFsEvents";
            this.chkFsEvents.Size = new System.Drawing.Size(73, 17);
            this.chkFsEvents.TabIndex = 3;
            this.chkFsEvents.Text = "Fs Events";
            this.chkFsEvents.UseVisualStyleBackColor = true;
            this.chkFsEvents.Visible = false;
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Location = new System.Drawing.Point(135, 284);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(94, 23);
            this.btnSelectAll.TabIndex = 1;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnOutputDir);
            this.groupBox2.Controls.Add(this.txtOutputDir);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.btnBrowse);
            this.groupBox2.Controls.Add(this.btnReset);
            this.groupBox2.Controls.Add(this.txtDirectory);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.btnSplitFile);
            this.groupBox2.Controls.Add(this.txtSessionKey);
            this.groupBox2.Location = new System.Drawing.Point(12, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(464, 134);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input";
            // 
            // btnOutputDir
            // 
            this.btnOutputDir.Location = new System.Drawing.Point(434, 43);
            this.btnOutputDir.Name = "btnOutputDir";
            this.btnOutputDir.Size = new System.Drawing.Size(24, 23);
            this.btnOutputDir.TabIndex = 3;
            this.btnOutputDir.Text = "...";
            this.btnOutputDir.UseVisualStyleBackColor = true;
            this.btnOutputDir.Click += new System.EventHandler(this.btnOutputDir_Click);
            // 
            // txtOutputDir
            // 
            this.txtOutputDir.Location = new System.Drawing.Point(120, 45);
            this.txtOutputDir.Name = "txtOutputDir";
            this.txtOutputDir.Size = new System.Drawing.Size(308, 20);
            this.txtOutputDir.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Output Folder:";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(434, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(24, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(72, 97);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(157, 23);
            this.btnReset.TabIndex = 5;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // txtDirectory
            // 
            this.txtDirectory.Location = new System.Drawing.Point(120, 19);
            this.txtDirectory.Name = "txtDirectory";
            this.txtDirectory.Size = new System.Drawing.Size(308, 20);
            this.txtDirectory.TabIndex = 0;
            this.txtDirectory.TextChanged += new System.EventHandler(this.txtDirectory_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "Input File:";
            // 
            // txtShowBuildFile
            // 
            this.txtShowBuildFile.Location = new System.Drawing.Point(245, 464);
            this.txtShowBuildFile.Name = "txtShowBuildFile";
            this.txtShowBuildFile.Size = new System.Drawing.Size(157, 23);
            this.txtShowBuildFile.TabIndex = 4;
            this.txtShowBuildFile.Text = "Show Build";
            this.txtShowBuildFile.UseVisualStyleBackColor = true;
            // 
            // BulkMacroSplitterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 491);
            this.Controls.Add(this.txtShowBuildFile);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnShowOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "BulkMacroSplitterForm";
            this.Text = "Macro Splitter";
            this.Load += new System.EventHandler(this.BulkMacroSplitterForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSessionKey;
        private System.Windows.Forms.Button btnShowOutput;
        private System.Windows.Forms.Button btnSplitFile;
        private System.Windows.Forms.CheckedListBox chkLstAllStepEvents;
        private System.Windows.Forms.Button btnGroup;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnOutputDir;
        private System.Windows.Forms.TextBox txtOutputDir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDirectory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkFsEvents;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem renameStepToolStripMenuItem;
        private System.Windows.Forms.Button txtShowBuildFile;
    }
}