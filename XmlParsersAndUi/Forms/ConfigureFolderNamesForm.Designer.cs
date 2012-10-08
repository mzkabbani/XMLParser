namespace XmlParsersAndUi.Forms {
    partial class ConfigureFolderNamesForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigureFolderNamesForm));
            this.tvFolderNames = new System.Windows.Forms.TreeView();
            this.btnSaveFolderNames = new System.Windows.Forms.Button();
            this.btnSaveName = new System.Windows.Forms.Button();
            this.txtSelectedFolderName = new System.Windows.Forms.TextBox();
            this.btnAddChild = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.cmsItemOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsItemOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvFolderNames
            // 
            this.tvFolderNames.ContextMenuStrip = this.cmsItemOptions;
            this.tvFolderNames.Location = new System.Drawing.Point(12, 12);
            this.tvFolderNames.Name = "tvFolderNames";
            this.tvFolderNames.Size = new System.Drawing.Size(230, 390);
            this.tvFolderNames.TabIndex = 1;
            this.tvFolderNames.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFolderNames_AfterSelect);
            // 
            // btnSaveFolderNames
            // 
            this.btnSaveFolderNames.Location = new System.Drawing.Point(91, 409);
            this.btnSaveFolderNames.Name = "btnSaveFolderNames";
            this.btnSaveFolderNames.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFolderNames.TabIndex = 2;
            this.btnSaveFolderNames.Text = "Save";
            this.btnSaveFolderNames.UseVisualStyleBackColor = true;
            this.btnSaveFolderNames.Click += new System.EventHandler(this.btnSaveFolderNames_Click);
            // 
            // btnSaveName
            // 
            this.btnSaveName.Enabled = false;
            this.btnSaveName.Location = new System.Drawing.Point(48, 38);
            this.btnSaveName.Name = "btnSaveName";
            this.btnSaveName.Size = new System.Drawing.Size(75, 23);
            this.btnSaveName.TabIndex = 3;
            this.btnSaveName.Text = "Save Name";
            this.btnSaveName.UseVisualStyleBackColor = true;
            this.btnSaveName.Visible = false;
            this.btnSaveName.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSelectedFolderName
            // 
            this.txtSelectedFolderName.Location = new System.Drawing.Point(12, 12);
            this.txtSelectedFolderName.Name = "txtSelectedFolderName";
            this.txtSelectedFolderName.Size = new System.Drawing.Size(232, 20);
            this.txtSelectedFolderName.TabIndex = 4;
            this.txtSelectedFolderName.Visible = false;
            // 
            // btnAddChild
            // 
            this.btnAddChild.Location = new System.Drawing.Point(133, 38);
            this.btnAddChild.Name = "btnAddChild";
            this.btnAddChild.Size = new System.Drawing.Size(75, 23);
            this.btnAddChild.TabIndex = 5;
            this.btnAddChild.Text = "Add Child";
            this.btnAddChild.UseVisualStyleBackColor = true;
            this.btnAddChild.Visible = false;
            this.btnAddChild.Click += new System.EventHandler(this.btnAddChild_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(91, 67);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Visible = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmsItemOptions
            // 
            this.cmsItemOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChildToolStripMenuItem,
            this.saveNameToolStripMenuItem});
            this.cmsItemOptions.Name = "cmsItemOptions";
            this.cmsItemOptions.Size = new System.Drawing.Size(131, 48);
            // 
            // addChildToolStripMenuItem
            // 
            this.addChildToolStripMenuItem.Name = "addChildToolStripMenuItem";
            this.addChildToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.addChildToolStripMenuItem.Text = "Add Child";
            this.addChildToolStripMenuItem.Click += new System.EventHandler(this.addChildToolStripMenuItem_Click);
            // 
            // saveNameToolStripMenuItem
            // 
            this.saveNameToolStripMenuItem.Name = "saveNameToolStripMenuItem";
            this.saveNameToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.saveNameToolStripMenuItem.Text = "Rename";
            this.saveNameToolStripMenuItem.Click += new System.EventHandler(this.saveNameToolStripMenuItem_Click);
            // 
            // ConfigureFolderNamesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(256, 438);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnAddChild);
            this.Controls.Add(this.txtSelectedFolderName);
            this.Controls.Add(this.btnSaveName);
            this.Controls.Add(this.btnSaveFolderNames);
            this.Controls.Add(this.tvFolderNames);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfigureFolderNamesForm";
            this.Text = "Configure Folder Names";
            this.Load += new System.EventHandler(this.ConfigureFolderNamesForm_Load);
            this.cmsItemOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvFolderNames;
        private System.Windows.Forms.Button btnSaveFolderNames;
        private System.Windows.Forms.Button btnSaveName;
        private System.Windows.Forms.TextBox txtSelectedFolderName;
        private System.Windows.Forms.Button btnAddChild;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ContextMenuStrip cmsItemOptions;
        private System.Windows.Forms.ToolStripMenuItem addChildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveNameToolStripMenuItem;
    }
}