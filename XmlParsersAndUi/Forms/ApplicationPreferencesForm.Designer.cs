namespace XmlParsersAndUi.Forms {
    partial class ApplicationPreferencesForm {
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Application Settings");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Backend", new System.Windows.Forms.TreeNode[] {
            treeNode1});
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Folder Naming");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Frontend", new System.Windows.Forms.TreeNode[] {
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Preferences", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode4});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplicationPreferencesForm));
            this.gbParentPrefs = new System.Windows.Forms.GroupBox();
            this.gbConnectedDatabase = new System.Windows.Forms.GroupBox();
            this.txtConnectedDatabase = new System.Windows.Forms.TextBox();
            this.gbDatabasePrefs = new System.Windows.Forms.GroupBox();
            this.dgvDatabasePrefs = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbFolderNaming = new System.Windows.Forms.GroupBox();
            this.btnSaveFolderNames = new System.Windows.Forms.Button();
            this.tvFolderNames = new System.Windows.Forms.TreeView();
            this.cmsItemOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addChildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveNameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tvPreferenceSections = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.addBulkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gbParentPrefs.SuspendLayout();
            this.gbConnectedDatabase.SuspendLayout();
            this.gbDatabasePrefs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabasePrefs)).BeginInit();
            this.gbFolderNaming.SuspendLayout();
            this.cmsItemOptions.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbParentPrefs
            // 
            this.gbParentPrefs.Controls.Add(this.gbConnectedDatabase);
            this.gbParentPrefs.Controls.Add(this.gbDatabasePrefs);
            this.gbParentPrefs.Controls.Add(this.gbFolderNaming);
            this.gbParentPrefs.Location = new System.Drawing.Point(228, 12);
            this.gbParentPrefs.Name = "gbParentPrefs";
            this.gbParentPrefs.Size = new System.Drawing.Size(495, 498);
            this.gbParentPrefs.TabIndex = 0;
            this.gbParentPrefs.TabStop = false;
            this.gbParentPrefs.Text = "Preferences";
            // 
            // gbConnectedDatabase
            // 
            this.gbConnectedDatabase.Controls.Add(this.txtConnectedDatabase);
            this.gbConnectedDatabase.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbConnectedDatabase.Location = new System.Drawing.Point(3, 16);
            this.gbConnectedDatabase.Name = "gbConnectedDatabase";
            this.gbConnectedDatabase.Size = new System.Drawing.Size(489, 66);
            this.gbConnectedDatabase.TabIndex = 5;
            this.gbConnectedDatabase.TabStop = false;
            this.gbConnectedDatabase.Text = "Connected Database";
            // 
            // txtConnectedDatabase
            // 
            this.txtConnectedDatabase.Location = new System.Drawing.Point(6, 23);
            this.txtConnectedDatabase.Name = "txtConnectedDatabase";
            this.txtConnectedDatabase.ReadOnly = true;
            this.txtConnectedDatabase.Size = new System.Drawing.Size(471, 20);
            this.txtConnectedDatabase.TabIndex = 4;
            // 
            // gbDatabasePrefs
            // 
            this.gbDatabasePrefs.Controls.Add(this.dgvDatabasePrefs);
            this.gbDatabasePrefs.Controls.Add(this.btnSave);
            this.gbDatabasePrefs.Location = new System.Drawing.Point(6, 91);
            this.gbDatabasePrefs.Name = "gbDatabasePrefs";
            this.gbDatabasePrefs.Size = new System.Drawing.Size(483, 245);
            this.gbDatabasePrefs.TabIndex = 1;
            this.gbDatabasePrefs.TabStop = false;
            this.gbDatabasePrefs.Text = "Database Prefs";
            this.gbDatabasePrefs.Visible = false;
            // 
            // dgvDatabasePrefs
            // 
            this.dgvDatabasePrefs.AllowUserToAddRows = false;
            this.dgvDatabasePrefs.AllowUserToDeleteRows = false;
            this.dgvDatabasePrefs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatabasePrefs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatabasePrefs.Location = new System.Drawing.Point(6, 16);
            this.dgvDatabasePrefs.Name = "dgvDatabasePrefs";
            this.dgvDatabasePrefs.RowHeadersVisible = false;
            this.dgvDatabasePrefs.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            this.dgvDatabasePrefs.Size = new System.Drawing.Size(471, 197);
            this.dgvDatabasePrefs.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(198, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // gbFolderNaming
            // 
            this.gbFolderNaming.Controls.Add(this.btnSaveFolderNames);
            this.gbFolderNaming.Controls.Add(this.tvFolderNames);
            this.gbFolderNaming.Location = new System.Drawing.Point(6, 343);
            this.gbFolderNaming.Name = "gbFolderNaming";
            this.gbFolderNaming.Size = new System.Drawing.Size(483, 470);
            this.gbFolderNaming.TabIndex = 3;
            this.gbFolderNaming.TabStop = false;
            this.gbFolderNaming.Text = "Folder Naming";
            this.gbFolderNaming.Visible = false;
            // 
            // btnSaveFolderNames
            // 
            this.btnSaveFolderNames.Location = new System.Drawing.Point(204, 442);
            this.btnSaveFolderNames.Name = "btnSaveFolderNames";
            this.btnSaveFolderNames.Size = new System.Drawing.Size(75, 23);
            this.btnSaveFolderNames.TabIndex = 4;
            this.btnSaveFolderNames.Text = "Save";
            this.btnSaveFolderNames.UseVisualStyleBackColor = true;
            this.btnSaveFolderNames.Click += new System.EventHandler(this.btnSaveFolderNames_Click);
            // 
            // tvFolderNames
            // 
            this.tvFolderNames.ContextMenuStrip = this.cmsItemOptions;
            this.tvFolderNames.Location = new System.Drawing.Point(6, 19);
            this.tvFolderNames.Name = "tvFolderNames";
            this.tvFolderNames.Size = new System.Drawing.Size(471, 417);
            this.tvFolderNames.TabIndex = 3;
            // 
            // cmsItemOptions
            // 
            this.cmsItemOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addChildToolStripMenuItem,
            this.saveNameToolStripMenuItem,
            this.addBulkToolStripMenuItem});
            this.cmsItemOptions.Name = "cmsItemOptions";
            this.cmsItemOptions.Size = new System.Drawing.Size(153, 92);
            // 
            // addChildToolStripMenuItem
            // 
            this.addChildToolStripMenuItem.Name = "addChildToolStripMenuItem";
            this.addChildToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addChildToolStripMenuItem.Text = "Add Child";
            this.addChildToolStripMenuItem.Click += new System.EventHandler(this.addChildToolStripMenuItem_Click);
            // 
            // saveNameToolStripMenuItem
            // 
            this.saveNameToolStripMenuItem.Name = "saveNameToolStripMenuItem";
            this.saveNameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveNameToolStripMenuItem.Text = "Rename";
            this.saveNameToolStripMenuItem.Click += new System.EventHandler(this.saveNameToolStripMenuItem_Click);
            // 
            // tvPreferenceSections
            // 
            this.tvPreferenceSections.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvPreferenceSections.Location = new System.Drawing.Point(3, 16);
            this.tvPreferenceSections.Name = "tvPreferenceSections";
            treeNode1.Name = "Node3";
            treeNode1.Text = "Application Settings";
            treeNode2.Name = "Node1";
            treeNode2.Text = "Backend";
            treeNode3.Name = "Node4";
            treeNode3.Text = "Folder Naming";
            treeNode4.Name = "Node2";
            treeNode4.Text = "Frontend";
            treeNode5.Name = "Node0";
            treeNode5.Text = "Preferences";
            this.tvPreferenceSections.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode5});
            this.tvPreferenceSections.Size = new System.Drawing.Size(203, 478);
            this.tvPreferenceSections.TabIndex = 1;
            this.tvPreferenceSections.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPreferenceSections_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tvPreferenceSections);
            this.groupBox2.Location = new System.Drawing.Point(13, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(209, 497);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sections";
            // 
            // addBulkToolStripMenuItem
            // 
            this.addBulkToolStripMenuItem.Name = "addBulkToolStripMenuItem";
            this.addBulkToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.addBulkToolStripMenuItem.Text = "Add Bulk";
            this.addBulkToolStripMenuItem.Click += new System.EventHandler(this.addBulkToolStripMenuItem_Click);
            // 
            // ApplicationPreferencesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 523);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbParentPrefs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ApplicationPreferencesForm";
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.ApplicationPreferencesForm_Load);
            this.gbParentPrefs.ResumeLayout(false);
            this.gbConnectedDatabase.ResumeLayout(false);
            this.gbConnectedDatabase.PerformLayout();
            this.gbDatabasePrefs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatabasePrefs)).EndInit();
            this.gbFolderNaming.ResumeLayout(false);
            this.cmsItemOptions.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbParentPrefs;
        private System.Windows.Forms.DataGridView dgvDatabasePrefs;
        private System.Windows.Forms.GroupBox gbDatabasePrefs;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtConnectedDatabase;
        private System.Windows.Forms.GroupBox gbFolderNaming;
        private System.Windows.Forms.Button btnSaveFolderNames;
        private System.Windows.Forms.TreeView tvFolderNames;
        private System.Windows.Forms.ContextMenuStrip cmsItemOptions;
        private System.Windows.Forms.ToolStripMenuItem addChildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveNameToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbConnectedDatabase;
        private System.Windows.Forms.TreeView tvPreferenceSections;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem addBulkToolStripMenuItem;
    }
}