namespace XmlParsersAndUi.Forms {
    partial class SecondLevelCleanupForm {
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
        	System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
        	System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("aaaaaaaaaa");
        	System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("aaaaaaaaaa");
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SecondLevelCleanupForm));
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
        	System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
        	this.lvAdvancedRules = new System.Windows.Forms.ListView();
        	this.ilIcons = new System.Windows.Forms.ImageList(this.components);
        	this.gbAdvancedRules = new System.Windows.Forms.GroupBox();
        	this.btnSelectAllLVAdvancedRulesItems = new System.Windows.Forms.Button();
        	this.btnClearLvAdvancedRulesSelections = new System.Windows.Forms.Button();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.gbOperation = new System.Windows.Forms.GroupBox();
        	this.btnBrowse = new System.Windows.Forms.Button();
        	this.txtInputDir = new System.Windows.Forms.TextBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.btnStart = new System.Windows.Forms.Button();
        	this.pbPercentComplete = new System.Windows.Forms.ProgressBar();
        	this.pcProgress = new Utezduyar.Windows.Forms.ProgressCircle();
        	this.gbSelectedCapture = new System.Windows.Forms.GroupBox();
        	this.srcPopularityAdded = new RatingControls.StarRatingControl();
        	this.txtRuleDescription = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.txtRuleName = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
        	this.lblFoundNodesCound = new System.Windows.Forms.Label();
        	this.gbAvailableReplacements = new System.Windows.Forms.GroupBox();
        	this.pnlAvailableReplacements = new System.Windows.Forms.Panel();
        	this.gbAffectedFiles = new System.Windows.Forms.GroupBox();
        	this.tvAffectedFiles = new System.Windows.Forms.TreeView();
        	this.ilImageList = new System.Windows.Forms.ImageList(this.components);
        	this.btnResetForm = new System.Windows.Forms.Button();
        	this.dgvSearchResult = new System.Windows.Forms.DataGridView();
        	this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Files = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.NumberMatches = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.details = new System.Windows.Forms.DataGridViewButtonColumn();
        	this.Ready = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        	this.btnProceedToReplacement = new System.Windows.Forms.Button();
        	this.bgwSearchForMatches = new System.ComponentModel.BackgroundWorker();
        	this.gbSearchResults = new System.Windows.Forms.GroupBox();
        	this.dgvResults = new System.Windows.Forms.DataGridView();
        	this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.objectCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.numHits = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.btnBackToSearch = new System.Windows.Forms.Button();
        	this.btnStartReplacementOp = new System.Windows.Forms.Button();
        	this.gbAdvancedRules.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	this.gbOperation.SuspendLayout();
        	this.gbSelectedCapture.SuspendLayout();
        	this.gbAvailableReplacements.SuspendLayout();
        	this.gbAffectedFiles.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).BeginInit();
        	this.gbSearchResults.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// lvAdvancedRules
        	// 
        	this.lvAdvancedRules.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lvAdvancedRules.GridLines = true;
        	listViewGroup1.Header = "ListViewGroup";
        	listViewGroup1.Name = "listViewGroup1";
        	this.lvAdvancedRules.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
        	        	        	listViewGroup1});
        	this.lvAdvancedRules.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
        	        	        	listViewItem1,
        	        	        	listViewItem2});
        	this.lvAdvancedRules.LabelWrap = false;
        	this.lvAdvancedRules.Location = new System.Drawing.Point(6, 19);
        	this.lvAdvancedRules.Name = "lvAdvancedRules";
        	this.lvAdvancedRules.Size = new System.Drawing.Size(238, 532);
        	this.lvAdvancedRules.SmallImageList = this.ilIcons;
        	this.lvAdvancedRules.Sorting = System.Windows.Forms.SortOrder.Ascending;
        	this.lvAdvancedRules.TabIndex = 2;
        	this.lvAdvancedRules.TileSize = new System.Drawing.Size(168, 50);
        	this.lvAdvancedRules.UseCompatibleStateImageBehavior = false;
        	this.lvAdvancedRules.View = System.Windows.Forms.View.SmallIcon;
        	this.lvAdvancedRules.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvAdvancedRules_ItemSelectionChanged);
        	this.lvAdvancedRules.SelectedIndexChanged += new System.EventHandler(this.lvAdvancedRules_SelectedIndexChanged);
        	this.lvAdvancedRules.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvAdvancedRules_KeyPress);
        	this.lvAdvancedRules.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvAdvancedRules_MouseDoubleClick);
        	// 
        	// ilIcons
        	// 
        	this.ilIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons.ImageStream")));
        	this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
        	this.ilIcons.Images.SetKeyName(0, "green_check.gif");
        	this.ilIcons.Images.SetKeyName(1, "redx.skinny.vysm.gif");
        	// 
        	// gbAdvancedRules
        	// 
        	this.gbAdvancedRules.Controls.Add(this.btnSelectAllLVAdvancedRulesItems);
        	this.gbAdvancedRules.Controls.Add(this.btnClearLvAdvancedRulesSelections);
        	this.gbAdvancedRules.Controls.Add(this.lvAdvancedRules);
        	this.gbAdvancedRules.Location = new System.Drawing.Point(13, 13);
        	this.gbAdvancedRules.Name = "gbAdvancedRules";
        	this.gbAdvancedRules.Size = new System.Drawing.Size(251, 586);
        	this.gbAdvancedRules.TabIndex = 4;
        	this.gbAdvancedRules.TabStop = false;
        	this.gbAdvancedRules.Text = "Advanced Search Rules";
        	// 
        	// btnSelectAllLVAdvancedRulesItems
        	// 
        	this.btnSelectAllLVAdvancedRulesItems.Location = new System.Drawing.Point(128, 557);
        	this.btnSelectAllLVAdvancedRulesItems.Name = "btnSelectAllLVAdvancedRulesItems";
        	this.btnSelectAllLVAdvancedRulesItems.Size = new System.Drawing.Size(75, 23);
        	this.btnSelectAllLVAdvancedRulesItems.TabIndex = 4;
        	this.btnSelectAllLVAdvancedRulesItems.Text = "Select All";
        	this.btnSelectAllLVAdvancedRulesItems.UseVisualStyleBackColor = true;
        	this.btnSelectAllLVAdvancedRulesItems.Click += new System.EventHandler(this.btnSelectAllLVAdvancedRulesItems_Click);
        	// 
        	// btnClearLvAdvancedRulesSelections
        	// 
        	this.btnClearLvAdvancedRulesSelections.Location = new System.Drawing.Point(47, 557);
        	this.btnClearLvAdvancedRulesSelections.Name = "btnClearLvAdvancedRulesSelections";
        	this.btnClearLvAdvancedRulesSelections.Size = new System.Drawing.Size(75, 23);
        	this.btnClearLvAdvancedRulesSelections.TabIndex = 3;
        	this.btnClearLvAdvancedRulesSelections.Text = "Clear";
        	this.btnClearLvAdvancedRulesSelections.UseVisualStyleBackColor = true;
        	this.btnClearLvAdvancedRulesSelections.Click += new System.EventHandler(this.btnClearLvAdvancedRulesSelections_Click);
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Controls.Add(this.gbOperation);
        	this.groupBox2.Controls.Add(this.gbSelectedCapture);
        	this.groupBox2.Controls.Add(this.lblFoundNodesCound);
        	this.groupBox2.Controls.Add(this.gbAvailableReplacements);
        	this.groupBox2.Controls.Add(this.gbAffectedFiles);
        	this.groupBox2.Location = new System.Drawing.Point(270, 13);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Size = new System.Drawing.Size(609, 586);
        	this.groupBox2.TabIndex = 5;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "Cleanup";
        	// 
        	// gbOperation
        	// 
        	this.gbOperation.Controls.Add(this.btnBrowse);
        	this.gbOperation.Controls.Add(this.txtInputDir);
        	this.gbOperation.Controls.Add(this.label3);
        	this.gbOperation.Controls.Add(this.btnStart);
        	this.gbOperation.Controls.Add(this.pbPercentComplete);
        	this.gbOperation.Controls.Add(this.pcProgress);
        	this.gbOperation.Location = new System.Drawing.Point(6, 184);
        	this.gbOperation.Name = "gbOperation";
        	this.gbOperation.Size = new System.Drawing.Size(598, 396);
        	this.gbOperation.TabIndex = 7;
        	this.gbOperation.TabStop = false;
        	this.gbOperation.Text = "Operation";
        	// 
        	// btnBrowse
        	// 
        	this.btnBrowse.Location = new System.Drawing.Point(567, 17);
        	this.btnBrowse.Name = "btnBrowse";
        	this.btnBrowse.Size = new System.Drawing.Size(24, 23);
        	this.btnBrowse.TabIndex = 13;
        	this.btnBrowse.Text = "...";
        	this.btnBrowse.UseVisualStyleBackColor = true;
        	this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
        	// 
        	// txtInputDir
        	// 
        	this.txtInputDir.Location = new System.Drawing.Point(62, 18);
        	this.txtInputDir.Name = "txtInputDir";
        	this.txtInputDir.Size = new System.Drawing.Size(499, 20);
        	this.txtInputDir.TabIndex = 7;
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(6, 21);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(50, 13);
        	this.label3.TabIndex = 6;
        	this.label3.Text = "Input Dir:";
        	// 
        	// btnStart
        	// 
        	this.btnStart.Location = new System.Drawing.Point(201, 45);
        	this.btnStart.Name = "btnStart";
        	this.btnStart.Size = new System.Drawing.Size(196, 23);
        	this.btnStart.TabIndex = 9;
        	this.btnStart.Text = "1. Search For Matches";
        	this.btnStart.UseVisualStyleBackColor = true;
        	this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
        	// 
        	// pbPercentComplete
        	// 
        	this.pbPercentComplete.Location = new System.Drawing.Point(5, 367);
        	this.pbPercentComplete.Name = "pbPercentComplete";
        	this.pbPercentComplete.Size = new System.Drawing.Size(586, 23);
        	this.pbPercentComplete.TabIndex = 7;
        	// 
        	// pcProgress
        	// 
        	this.pcProgress.ForeColor = System.Drawing.Color.DodgerBlue;
        	this.pcProgress.Interval = 240;
        	this.pcProgress.Location = new System.Drawing.Point(224, 123);
        	this.pcProgress.Name = "pcProgress";
        	this.pcProgress.RingColor = System.Drawing.Color.White;
        	this.pcProgress.RingThickness = 40;
        	this.pcProgress.Size = new System.Drawing.Size(150, 150);
        	this.pcProgress.TabIndex = 1;
        	// 
        	// gbSelectedCapture
        	// 
        	this.gbSelectedCapture.Controls.Add(this.srcPopularityAdded);
        	this.gbSelectedCapture.Controls.Add(this.txtRuleDescription);
        	this.gbSelectedCapture.Controls.Add(this.label2);
        	this.gbSelectedCapture.Controls.Add(this.txtRuleName);
        	this.gbSelectedCapture.Controls.Add(this.label1);
        	this.gbSelectedCapture.Location = new System.Drawing.Point(6, 19);
        	this.gbSelectedCapture.Name = "gbSelectedCapture";
        	this.gbSelectedCapture.Size = new System.Drawing.Size(598, 159);
        	this.gbSelectedCapture.TabIndex = 6;
        	this.gbSelectedCapture.TabStop = false;
        	this.gbSelectedCapture.Text = "Selected Rule";
        	// 
        	// srcPopularityAdded
        	// 
        	this.srcPopularityAdded.BottomMargin = 2;
        	this.srcPopularityAdded.Enabled = false;
        	this.srcPopularityAdded.HoverColor = System.Drawing.Color.Gold;
        	this.srcPopularityAdded.LeftMargin = 2;
        	this.srcPopularityAdded.Location = new System.Drawing.Point(445, 15);
        	this.srcPopularityAdded.Name = "srcPopularityAdded";
        	this.srcPopularityAdded.OutlineColor = System.Drawing.Color.DarkGray;
        	this.srcPopularityAdded.OutlineThickness = 1;
        	this.srcPopularityAdded.RightMargin = 2;
        	this.srcPopularityAdded.SelectedColor = System.Drawing.Color.RoyalBlue;
        	this.srcPopularityAdded.Size = new System.Drawing.Size(146, 24);
        	this.srcPopularityAdded.StarCount = 5;
        	this.srcPopularityAdded.StarSpacing = 8;
        	this.srcPopularityAdded.TabIndex = 4;
        	this.srcPopularityAdded.Text = "starRatingControl1";
        	this.srcPopularityAdded.TopMargin = 2;
        	// 
        	// txtRuleDescription
        	// 
        	this.txtRuleDescription.Location = new System.Drawing.Point(76, 45);
        	this.txtRuleDescription.Multiline = true;
        	this.txtRuleDescription.Name = "txtRuleDescription";
        	this.txtRuleDescription.Size = new System.Drawing.Size(516, 107);
        	this.txtRuleDescription.TabIndex = 3;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(7, 48);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(63, 13);
        	this.label2.TabIndex = 2;
        	this.label2.Text = "Description:";
        	// 
        	// txtRuleName
        	// 
        	this.txtRuleName.Location = new System.Drawing.Point(76, 19);
        	this.txtRuleName.Name = "txtRuleName";
        	this.txtRuleName.Size = new System.Drawing.Size(174, 20);
        	this.txtRuleName.TabIndex = 1;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(7, 22);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(41, 13);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Name: ";
        	// 
        	// lblFoundNodesCound
        	// 
        	this.lblFoundNodesCound.AutoSize = true;
        	this.lblFoundNodesCound.Location = new System.Drawing.Point(13, 189);
        	this.lblFoundNodesCound.Name = "lblFoundNodesCound";
        	this.lblFoundNodesCound.Size = new System.Drawing.Size(13, 13);
        	this.lblFoundNodesCound.TabIndex = 6;
        	this.lblFoundNodesCound.Text = "0";
        	// 
        	// gbAvailableReplacements
        	// 
        	this.gbAvailableReplacements.Controls.Add(this.pnlAvailableReplacements);
        	this.gbAvailableReplacements.Location = new System.Drawing.Point(8, 18);
        	this.gbAvailableReplacements.Name = "gbAvailableReplacements";
        	this.gbAvailableReplacements.Size = new System.Drawing.Size(596, 562);
        	this.gbAvailableReplacements.TabIndex = 12;
        	this.gbAvailableReplacements.TabStop = false;
        	this.gbAvailableReplacements.Text = "Available Replacements";
        	this.gbAvailableReplacements.Visible = false;
        	// 
        	// pnlAvailableReplacements
        	// 
        	this.pnlAvailableReplacements.AutoScroll = true;
        	this.pnlAvailableReplacements.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.pnlAvailableReplacements.Location = new System.Drawing.Point(3, 16);
        	this.pnlAvailableReplacements.Name = "pnlAvailableReplacements";
        	this.pnlAvailableReplacements.Size = new System.Drawing.Size(590, 543);
        	this.pnlAvailableReplacements.TabIndex = 0;
        	// 
        	// gbAffectedFiles
        	// 
        	this.gbAffectedFiles.Controls.Add(this.tvAffectedFiles);
        	this.gbAffectedFiles.Location = new System.Drawing.Point(6, 285);
        	this.gbAffectedFiles.Name = "gbAffectedFiles";
        	this.gbAffectedFiles.Size = new System.Drawing.Size(601, 295);
        	this.gbAffectedFiles.TabIndex = 13;
        	this.gbAffectedFiles.TabStop = false;
        	this.gbAffectedFiles.Text = "Affected Files";
        	this.gbAffectedFiles.Visible = false;
        	// 
        	// tvAffectedFiles
        	// 
        	this.tvAffectedFiles.CheckBoxes = true;
        	this.tvAffectedFiles.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tvAffectedFiles.ImageIndex = 0;
        	this.tvAffectedFiles.ImageList = this.ilImageList;
        	this.tvAffectedFiles.Location = new System.Drawing.Point(3, 16);
        	this.tvAffectedFiles.Name = "tvAffectedFiles";
        	this.tvAffectedFiles.SelectedImageIndex = 0;
        	this.tvAffectedFiles.Size = new System.Drawing.Size(595, 276);
        	this.tvAffectedFiles.TabIndex = 0;
        	this.tvAffectedFiles.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvAffectedFiles_AfterCheck);
        	this.tvAffectedFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvAffectedFiles_NodeMouseDoubleClick);
        	// 
        	// ilImageList
        	// 
        	this.ilImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilImageList.ImageStream")));
        	this.ilImageList.TransparentColor = System.Drawing.Color.Transparent;
        	this.ilImageList.Images.SetKeyName(0, "folder_32.png");
        	this.ilImageList.Images.SetKeyName(1, "file_icon.png");
        	this.ilImageList.Images.SetKeyName(2, "circle_red_M1.jpg");
        	// 
        	// btnResetForm
        	// 
        	this.btnResetForm.Location = new System.Drawing.Point(423, 605);
        	this.btnResetForm.Name = "btnResetForm";
        	this.btnResetForm.Size = new System.Drawing.Size(131, 23);
        	this.btnResetForm.TabIndex = 10;
        	this.btnResetForm.Text = "Reset";
        	this.btnResetForm.UseVisualStyleBackColor = true;
        	this.btnResetForm.Visible = false;
        	this.btnResetForm.Click += new System.EventHandler(this.btnResetForm_Click);
        	// 
        	// dgvSearchResult
        	// 
        	this.dgvSearchResult.AllowUserToAddRows = false;
        	dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
        	dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
        	dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        	dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvSearchResult.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
        	this.dgvSearchResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvSearchResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.name,
        	        	        	this.Files,
        	        	        	this.NumberMatches,
        	        	        	this.details,
        	        	        	this.Ready});
        	dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
        	dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
        	dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        	dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
        	this.dgvSearchResult.DefaultCellStyle = dataGridViewCellStyle2;
        	this.dgvSearchResult.Location = new System.Drawing.Point(201, 631);
        	this.dgvSearchResult.Name = "dgvSearchResult";
        	dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
        	dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
        	dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
        	dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
        	dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
        	dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
        	this.dgvSearchResult.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
        	this.dgvSearchResult.RowHeadersVisible = false;
        	this.dgvSearchResult.Size = new System.Drawing.Size(519, 297);
        	this.dgvSearchResult.TabIndex = 9;
        	this.dgvSearchResult.Visible = false;
        	this.dgvSearchResult.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSearchResult_CellContentClick);
        	// 
        	// name
        	// 
        	this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.name.HeaderText = "Name";
        	this.name.Name = "name";
        	this.name.ReadOnly = true;
        	// 
        	// Files
        	// 
        	this.Files.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.Files.HeaderText = "# Files Hit";
        	this.Files.Name = "Files";
        	this.Files.ReadOnly = true;
        	// 
        	// NumberMatches
        	// 
        	this.NumberMatches.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.NumberMatches.HeaderText = "# of Matches";
        	this.NumberMatches.Name = "NumberMatches";
        	this.NumberMatches.ReadOnly = true;
        	// 
        	// details
        	// 
        	this.details.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.details.HeaderText = "Used Replacement";
        	this.details.Name = "details";
        	this.details.ReadOnly = true;
        	this.details.Resizable = System.Windows.Forms.DataGridViewTriState.True;
        	this.details.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
        	// 
        	// Ready
        	// 
        	this.Ready.HeaderText = "Ready";
        	this.Ready.Name = "Ready";
        	this.Ready.ReadOnly = true;
        	// 
        	// btnProceedToReplacement
        	// 
        	this.btnProceedToReplacement.Location = new System.Drawing.Point(560, 605);
        	this.btnProceedToReplacement.Name = "btnProceedToReplacement";
        	this.btnProceedToReplacement.Size = new System.Drawing.Size(131, 23);
        	this.btnProceedToReplacement.TabIndex = 8;
        	this.btnProceedToReplacement.Text = "2 . Start Replacement";
        	this.btnProceedToReplacement.UseVisualStyleBackColor = true;
        	this.btnProceedToReplacement.Visible = false;
        	this.btnProceedToReplacement.Click += new System.EventHandler(this.btnProceedToReplacement_Click);
        	// 
        	// bgwSearchForMatches
        	// 
        	this.bgwSearchForMatches.WorkerReportsProgress = true;
        	// 
        	// gbSearchResults
        	// 
        	this.gbSearchResults.Controls.Add(this.dgvResults);
        	this.gbSearchResults.Location = new System.Drawing.Point(12, 13);
        	this.gbSearchResults.Name = "gbSearchResults";
        	this.gbSearchResults.Size = new System.Drawing.Size(251, 586);
        	this.gbSearchResults.TabIndex = 10;
        	this.gbSearchResults.TabStop = false;
        	this.gbSearchResults.Text = "Advanced Search Results";
        	this.gbSearchResults.Visible = false;
        	// 
        	// dgvResults
        	// 
        	this.dgvResults.AllowUserToAddRows = false;
        	this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.dataGridViewTextBoxColumn1,
        	        	        	this.objectCol,
        	        	        	this.numHits});
        	this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvResults.Location = new System.Drawing.Point(3, 16);
        	this.dgvResults.Name = "dgvResults";
        	this.dgvResults.RowHeadersVisible = false;
        	this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
        	this.dgvResults.Size = new System.Drawing.Size(245, 567);
        	this.dgvResults.TabIndex = 2;
        	this.dgvResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvResults_CellClick);
        	// 
        	// dataGridViewTextBoxColumn1
        	// 
        	this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.dataGridViewTextBoxColumn1.HeaderText = "Name";
        	this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
        	this.dataGridViewTextBoxColumn1.ReadOnly = true;
        	// 
        	// objectCol
        	// 
        	this.objectCol.HeaderText = "Column1";
        	this.objectCol.Name = "objectCol";
        	this.objectCol.ReadOnly = true;
        	this.objectCol.Visible = false;
        	// 
        	// numHits
        	// 
        	this.numHits.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.numHits.HeaderText = "Hits";
        	this.numHits.Name = "numHits";
        	this.numHits.ReadOnly = true;
        	// 
        	// btnBackToSearch
        	// 
        	this.btnBackToSearch.Location = new System.Drawing.Point(152, 605);
        	this.btnBackToSearch.Name = "btnBackToSearch";
        	this.btnBackToSearch.Size = new System.Drawing.Size(131, 23);
        	this.btnBackToSearch.TabIndex = 12;
        	this.btnBackToSearch.Text = "<< Back To Search";
        	this.btnBackToSearch.UseVisualStyleBackColor = true;
        	this.btnBackToSearch.Visible = false;
        	this.btnBackToSearch.Click += new System.EventHandler(this.btnBackToSearch_Click);
        	// 
        	// btnStartReplacementOp
        	// 
        	this.btnStartReplacementOp.Location = new System.Drawing.Point(289, 605);
        	this.btnStartReplacementOp.Name = "btnStartReplacementOp";
        	this.btnStartReplacementOp.Size = new System.Drawing.Size(131, 23);
        	this.btnStartReplacementOp.TabIndex = 11;
        	this.btnStartReplacementOp.Text = "Start Replacement";
        	this.btnStartReplacementOp.UseVisualStyleBackColor = true;
        	this.btnStartReplacementOp.Visible = false;
        	this.btnStartReplacementOp.Click += new System.EventHandler(this.btnStartReplacementOp_Click);
        	// 
        	// SecondLevelCleanupForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(889, 631);
        	this.Controls.Add(this.btnBackToSearch);
        	this.Controls.Add(this.btnStartReplacementOp);
        	this.Controls.Add(this.btnResetForm);
        	this.Controls.Add(this.groupBox2);
        	this.Controls.Add(this.btnProceedToReplacement);
        	this.Controls.Add(this.dgvSearchResult);
        	this.Controls.Add(this.gbAdvancedRules);
        	this.Controls.Add(this.gbSearchResults);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.Name = "SecondLevelCleanupForm";
        	this.Text = "Second Level Cleanup";
        	this.Load += new System.EventHandler(this.SecondLevelCleanupForm_Load);
        	this.gbAdvancedRules.ResumeLayout(false);
        	this.groupBox2.ResumeLayout(false);
        	this.groupBox2.PerformLayout();
        	this.gbOperation.ResumeLayout(false);
        	this.gbOperation.PerformLayout();
        	this.gbSelectedCapture.ResumeLayout(false);
        	this.gbSelectedCapture.PerformLayout();
        	this.gbAvailableReplacements.ResumeLayout(false);
        	this.gbAffectedFiles.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgvSearchResult)).EndInit();
        	this.gbSearchResults.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
        	this.ResumeLayout(false);
        }
        private RatingControls.StarRatingControl srcPopularityAdded;

        #endregion

        private System.Windows.Forms.ListView lvAdvancedRules;
        private System.Windows.Forms.GroupBox gbAdvancedRules;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox gbSelectedCapture;
        private System.Windows.Forms.TextBox txtRuleName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRuleDescription;
        private System.Windows.Forms.Label label2;
       // private RatingControls.StarRatingControl srcPopularityAdded;
        private System.Windows.Forms.GroupBox gbOperation;
        private System.Windows.Forms.ImageList ilIcons;
        private System.ComponentModel.BackgroundWorker bgwSearchForMatches;
        private Utezduyar.Windows.Forms.ProgressCircle pcProgress;
        private System.Windows.Forms.Label lblFoundNodesCound;
        private System.Windows.Forms.ProgressBar pbPercentComplete;
        private System.Windows.Forms.Button btnProceedToReplacement;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dgvSearchResult;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Files;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumberMatches;
        private System.Windows.Forms.DataGridViewButtonColumn details;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Ready;
        private System.Windows.Forms.Button btnResetForm;
        private System.Windows.Forms.GroupBox gbAvailableReplacements;
        private System.Windows.Forms.Panel pnlAvailableReplacements;
        private System.Windows.Forms.GroupBox gbSearchResults;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn numHits;
        private System.Windows.Forms.Button btnBackToSearch;
        private System.Windows.Forms.Button btnStartReplacementOp;
        private System.Windows.Forms.TextBox txtInputDir;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbAffectedFiles;
        private System.Windows.Forms.TreeView tvAffectedFiles;
        private System.Windows.Forms.ImageList ilImageList;
        private System.Windows.Forms.Button btnSelectAllLVAdvancedRulesItems;
        private System.Windows.Forms.Button btnClearLvAdvancedRulesSelections;
        private System.Windows.Forms.Button btnBrowse;
    }
}