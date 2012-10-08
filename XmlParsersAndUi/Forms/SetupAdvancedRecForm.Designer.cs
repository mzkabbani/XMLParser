namespace XmlParsersAndUi {
    partial class SetupAdvancedRecForm {
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupAdvancedRecForm));
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.lbAdvancedCE = new System.Windows.Forms.ListBox();
        	this.btnReloadCapturePoints = new System.Windows.Forms.Button();
        	this.gbRuleDefinition = new System.Windows.Forms.GroupBox();
        	this.label14 = new System.Windows.Forms.Label();
        	this.gbSpecificConfNodes = new System.Windows.Forms.GroupBox();
        	this.grpBoxAttr = new System.Windows.Forms.GroupBox();
        	this.dgvAttributes = new System.Windows.Forms.DataGridView();
        	this.useAttribute = new System.Windows.Forms.DataGridViewCheckBoxColumn();
        	this.Attribute = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.tvOutput = new System.Windows.Forms.TreeView();
        	this.label5 = new System.Windows.Forms.Label();
        	this.cboCaptureType = new System.Windows.Forms.ComboBox();
        	this.gbSpecificConfDef = new System.Windows.Forms.GroupBox();
        	this.btnParse = new System.Windows.Forms.Button();
        	this.txtAODescription = new System.Windows.Forms.TextBox();
        	this.txtAOEventIn = new System.Windows.Forms.TextBox();
        	this.label6 = new System.Windows.Forms.Label();
        	this.label7 = new System.Windows.Forms.Label();
        	this.btnAddCaptureEvent = new System.Windows.Forms.Button();
        	this.btnSaveCaptureEvent = new System.Windows.Forms.Button();
        	this.btnResetCaptureEvents = new System.Windows.Forms.Button();
        	this.txtAOName = new System.Windows.Forms.TextBox();
        	this.label8 = new System.Windows.Forms.Label();
        	this.tabPage2 = new System.Windows.Forms.TabPage();
        	this.groupBox6 = new System.Windows.Forms.GroupBox();
        	this.groupBox8 = new System.Windows.Forms.GroupBox();
        	this.btnResetReplacement = new System.Windows.Forms.Button();
        	this.btnValidate = new System.Windows.Forms.Button();
        	this.label13 = new System.Windows.Forms.Label();
        	this.cboReplacementType = new System.Windows.Forms.ComboBox();
        	this.btnAddReplacementEvent = new System.Windows.Forms.Button();
        	this.txtReplacementDesc = new System.Windows.Forms.TextBox();
        	this.label9 = new System.Windows.Forms.Label();
        	this.btnSaveReplacement = new System.Windows.Forms.Button();
        	this.txtReplacementName = new System.Windows.Forms.TextBox();
        	this.txtReplacementRep = new System.Windows.Forms.TextBox();
        	this.label10 = new System.Windows.Forms.Label();
        	this.label11 = new System.Windows.Forms.Label();
        	this.groupBox7 = new System.Windows.Forms.GroupBox();
        	this.btnRefreshReplacements = new System.Windows.Forms.Button();
        	this.lbAvailableReplacements = new System.Windows.Forms.ListBox();
        	this.cboCapturePoint = new System.Windows.Forms.ComboBox();
        	this.label12 = new System.Windows.Forms.Label();
        	this.groupBox4 = new System.Windows.Forms.GroupBox();
        	this.lbOptions = new System.Windows.Forms.ListBox();
        	this.btnReloadOptions = new System.Windows.Forms.Button();
        	this.groupBox3 = new System.Windows.Forms.GroupBox();
        	this.btnAdd = new System.Windows.Forms.Button();
        	this.btnReset = new System.Windows.Forms.Button();
        	this.btnSave = new System.Windows.Forms.Button();
        	this.txtOptionReplacement = new System.Windows.Forms.TextBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.txtOptionDesc = new System.Windows.Forms.TextBox();
        	this.txtOptionPattern = new System.Windows.Forms.TextBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.chkIsRegex = new System.Windows.Forms.CheckBox();
        	this.txtOptionName = new System.Windows.Forms.TextBox();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label1 = new System.Windows.Forms.Label();
        	this.listBox1 = new System.Windows.Forms.ListBox();
        	this.button2 = new System.Windows.Forms.Button();
        	this.tabControl1.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	this.gbRuleDefinition.SuspendLayout();
        	this.gbSpecificConfNodes.SuspendLayout();
        	this.grpBoxAttr.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).BeginInit();
        	this.gbSpecificConfDef.SuspendLayout();
        	this.tabPage2.SuspendLayout();
        	this.groupBox6.SuspendLayout();
        	this.groupBox8.SuspendLayout();
        	this.groupBox7.SuspendLayout();
        	this.groupBox4.SuspendLayout();
        	this.groupBox3.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Controls.Add(this.tabPage1);
        	this.tabControl1.Controls.Add(this.tabPage2);
        	this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControl1.Location = new System.Drawing.Point(0, 0);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(1054, 714);
        	this.tabControl1.TabIndex = 2;
        	this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.groupBox2);
        	this.tabPage1.Controls.Add(this.gbRuleDefinition);
        	this.tabPage1.Location = new System.Drawing.Point(4, 22);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage1.Size = new System.Drawing.Size(1046, 688);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "Capture Events";
        	this.tabPage1.UseVisualStyleBackColor = true;
        	// 
        	// groupBox2
        	// 
        	this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left)));
        	this.groupBox2.BackColor = System.Drawing.Color.Transparent;
        	this.groupBox2.Controls.Add(this.lbAdvancedCE);
        	this.groupBox2.Controls.Add(this.btnReloadCapturePoints);
        	this.groupBox2.Location = new System.Drawing.Point(6, 6);
        	this.groupBox2.Name = "groupBox2";
        	this.groupBox2.Size = new System.Drawing.Size(267, 674);
        	this.groupBox2.TabIndex = 16;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "Available Capture Events";
        	// 
        	// lbAdvancedCE
        	// 
        	this.lbAdvancedCE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left)));
        	this.lbAdvancedCE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lbAdvancedCE.FormattingEnabled = true;
        	this.lbAdvancedCE.Location = new System.Drawing.Point(7, 15);
        	this.lbAdvancedCE.Name = "lbAdvancedCE";
        	this.lbAdvancedCE.Size = new System.Drawing.Size(254, 615);
        	this.lbAdvancedCE.TabIndex = 22;
        	this.lbAdvancedCE.SelectedIndexChanged += new System.EventHandler(this.lbAdvancedCE_SelectedIndexChanged_1);
        	// 
        	// btnReloadCapturePoints
        	// 
        	this.btnReloadCapturePoints.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnReloadCapturePoints.Location = new System.Drawing.Point(55, 639);
        	this.btnReloadCapturePoints.Name = "btnReloadCapturePoints";
        	this.btnReloadCapturePoints.Size = new System.Drawing.Size(156, 23);
        	this.btnReloadCapturePoints.TabIndex = 0;
        	this.btnReloadCapturePoints.Text = "Reload Options";
        	this.btnReloadCapturePoints.UseVisualStyleBackColor = true;
        	this.btnReloadCapturePoints.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// gbRuleDefinition
        	// 
        	this.gbRuleDefinition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.gbRuleDefinition.Controls.Add(this.label14);
        	this.gbRuleDefinition.Controls.Add(this.gbSpecificConfNodes);
        	this.gbRuleDefinition.Controls.Add(this.cboCaptureType);
        	this.gbRuleDefinition.Controls.Add(this.gbSpecificConfDef);
        	this.gbRuleDefinition.Controls.Add(this.btnAddCaptureEvent);
        	this.gbRuleDefinition.Controls.Add(this.btnSaveCaptureEvent);
        	this.gbRuleDefinition.Controls.Add(this.btnResetCaptureEvents);
        	this.gbRuleDefinition.Controls.Add(this.txtAOName);
        	this.gbRuleDefinition.Controls.Add(this.label8);
        	this.gbRuleDefinition.Location = new System.Drawing.Point(279, 6);
        	this.gbRuleDefinition.Name = "gbRuleDefinition";
        	this.gbRuleDefinition.Size = new System.Drawing.Size(759, 674);
        	this.gbRuleDefinition.TabIndex = 2;
        	this.gbRuleDefinition.TabStop = false;
        	this.gbRuleDefinition.Text = "Rule Definition";
        	// 
        	// label14
        	// 
        	this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.label14.AutoSize = true;
        	this.label14.Location = new System.Drawing.Point(553, 25);
        	this.label14.Name = "label14";
        	this.label14.Size = new System.Drawing.Size(34, 13);
        	this.label14.TabIndex = 18;
        	this.label14.Text = "Type:";
        	// 
        	// gbSpecificConfNodes
        	// 
        	this.gbSpecificConfNodes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.gbSpecificConfNodes.Controls.Add(this.grpBoxAttr);
        	this.gbSpecificConfNodes.Controls.Add(this.tvOutput);
        	this.gbSpecificConfNodes.Controls.Add(this.label5);
        	this.gbSpecificConfNodes.Location = new System.Drawing.Point(7, 286);
        	this.gbSpecificConfNodes.Name = "gbSpecificConfNodes";
        	this.gbSpecificConfNodes.Size = new System.Drawing.Size(746, 353);
        	this.gbSpecificConfNodes.TabIndex = 8;
        	this.gbSpecificConfNodes.TabStop = false;
        	this.gbSpecificConfNodes.Text = "Nodes & Attributes";
        	// 
        	// grpBoxAttr
        	// 
        	this.grpBoxAttr.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.grpBoxAttr.Controls.Add(this.dgvAttributes);
        	this.grpBoxAttr.Location = new System.Drawing.Point(245, 20);
        	this.grpBoxAttr.Name = "grpBoxAttr";
        	this.grpBoxAttr.Size = new System.Drawing.Size(488, 327);
        	this.grpBoxAttr.TabIndex = 21;
        	this.grpBoxAttr.TabStop = false;
        	this.grpBoxAttr.Text = "Attributes";
        	// 
        	// dgvAttributes
        	// 
        	this.dgvAttributes.AllowUserToAddRows = false;
        	this.dgvAttributes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
        	this.dgvAttributes.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
        	this.dgvAttributes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
        	this.dgvAttributes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.useAttribute,
        	        	        	this.Attribute,
        	        	        	this.Value});
        	this.dgvAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.dgvAttributes.Location = new System.Drawing.Point(3, 16);
        	this.dgvAttributes.Name = "dgvAttributes";
        	this.dgvAttributes.RowHeadersVisible = false;
        	this.dgvAttributes.Size = new System.Drawing.Size(482, 308);
        	this.dgvAttributes.TabIndex = 0;
        	// 
        	// useAttribute
        	// 
        	this.useAttribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.useAttribute.HeaderText = "Enabled";
        	this.useAttribute.Name = "useAttribute";
        	// 
        	// Attribute
        	// 
        	this.Attribute.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.Attribute.HeaderText = "Attribute";
        	this.Attribute.Name = "Attribute";
        	this.Attribute.ReadOnly = true;
        	// 
        	// Value
        	// 
        	this.Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
        	this.Value.HeaderText = "Value";
        	this.Value.Name = "Value";
        	// 
        	// tvOutput
        	// 
        	this.tvOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left)));
        	this.tvOutput.CheckBoxes = true;
        	this.tvOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.tvOutput.Location = new System.Drawing.Point(6, 36);
        	this.tvOutput.Name = "tvOutput";
        	this.tvOutput.Size = new System.Drawing.Size(223, 311);
        	this.tvOutput.TabIndex = 20;
        	this.tvOutput.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvOutput_BeforeSelect);
        	this.tvOutput.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOutput_AfterSelect);
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(6, 20);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(79, 13);
        	this.label5.TabIndex = 19;
        	this.label5.Text = "Capture Points:";
        	// 
        	// cboCaptureType
        	// 
        	this.cboCaptureType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.cboCaptureType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cboCaptureType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.cboCaptureType.FormattingEnabled = true;
        	this.cboCaptureType.Items.AddRange(new object[] {
        	        	        	"one",
        	        	        	"two",
        	        	        	"three"});
        	this.cboCaptureType.Location = new System.Drawing.Point(593, 22);
        	this.cboCaptureType.Name = "cboCaptureType";
        	this.cboCaptureType.Size = new System.Drawing.Size(154, 21);
        	this.cboCaptureType.TabIndex = 17;
        	this.cboCaptureType.SelectedIndexChanged += new System.EventHandler(this.cboCaptureType_SelectedIndexChanged);
        	// 
        	// gbSpecificConfDef
        	// 
        	this.gbSpecificConfDef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.gbSpecificConfDef.Controls.Add(this.btnParse);
        	this.gbSpecificConfDef.Controls.Add(this.txtAODescription);
        	this.gbSpecificConfDef.Controls.Add(this.txtAOEventIn);
        	this.gbSpecificConfDef.Controls.Add(this.label6);
        	this.gbSpecificConfDef.Controls.Add(this.label7);
        	this.gbSpecificConfDef.Location = new System.Drawing.Point(6, 58);
        	this.gbSpecificConfDef.Name = "gbSpecificConfDef";
        	this.gbSpecificConfDef.Size = new System.Drawing.Size(747, 222);
        	this.gbSpecificConfDef.TabIndex = 2;
        	this.gbSpecificConfDef.TabStop = false;
        	this.gbSpecificConfDef.Text = "Definition";
        	// 
        	// btnParse
        	// 
        	this.btnParse.Anchor = System.Windows.Forms.AnchorStyles.Top;
        	this.btnParse.Location = new System.Drawing.Point(303, 193);
        	this.btnParse.Name = "btnParse";
        	this.btnParse.Size = new System.Drawing.Size(140, 23);
        	this.btnParse.TabIndex = 16;
        	this.btnParse.Text = "Parse";
        	this.btnParse.UseVisualStyleBackColor = true;
        	this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
        	// 
        	// txtAODescription
        	// 
        	this.txtAODescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.txtAODescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.txtAODescription.Location = new System.Drawing.Point(7, 32);
        	this.txtAODescription.Multiline = true;
        	this.txtAODescription.Name = "txtAODescription";
        	this.txtAODescription.Size = new System.Drawing.Size(735, 52);
        	this.txtAODescription.TabIndex = 1;
        	// 
        	// txtAOEventIn
        	// 
        	this.txtAOEventIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.txtAOEventIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.txtAOEventIn.Location = new System.Drawing.Point(7, 104);
        	this.txtAOEventIn.Multiline = true;
        	this.txtAOEventIn.Name = "txtAOEventIn";
        	this.txtAOEventIn.Size = new System.Drawing.Size(735, 83);
        	this.txtAOEventIn.TabIndex = 3;
        	// 
        	// label6
        	// 
        	this.label6.AutoSize = true;
        	this.label6.Location = new System.Drawing.Point(7, 88);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(65, 13);
        	this.label6.TabIndex = 7;
        	this.label6.Text = "Input Event:";
        	// 
        	// label7
        	// 
        	this.label7.AutoSize = true;
        	this.label7.Location = new System.Drawing.Point(6, 16);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(63, 13);
        	this.label7.TabIndex = 3;
        	this.label7.Text = "Description:";
        	// 
        	// btnAddCaptureEvent
        	// 
        	this.btnAddCaptureEvent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnAddCaptureEvent.Enabled = false;
        	this.btnAddCaptureEvent.Location = new System.Drawing.Point(156, 645);
        	this.btnAddCaptureEvent.Name = "btnAddCaptureEvent";
        	this.btnAddCaptureEvent.Size = new System.Drawing.Size(140, 23);
        	this.btnAddCaptureEvent.TabIndex = 5;
        	this.btnAddCaptureEvent.Text = "Add";
        	this.btnAddCaptureEvent.UseVisualStyleBackColor = true;
        	this.btnAddCaptureEvent.Click += new System.EventHandler(this.btnAddCaptureEvent_Click);
        	// 
        	// btnSaveCaptureEvent
        	// 
        	this.btnSaveCaptureEvent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnSaveCaptureEvent.Enabled = false;
        	this.btnSaveCaptureEvent.Location = new System.Drawing.Point(302, 645);
        	this.btnSaveCaptureEvent.Name = "btnSaveCaptureEvent";
        	this.btnSaveCaptureEvent.Size = new System.Drawing.Size(140, 23);
        	this.btnSaveCaptureEvent.TabIndex = 6;
        	this.btnSaveCaptureEvent.Text = "Save";
        	this.btnSaveCaptureEvent.UseVisualStyleBackColor = true;
        	this.btnSaveCaptureEvent.Click += new System.EventHandler(this.btnSaveCaptureEvent_Click);
        	// 
        	// btnResetCaptureEvents
        	// 
        	this.btnResetCaptureEvents.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnResetCaptureEvents.Location = new System.Drawing.Point(448, 645);
        	this.btnResetCaptureEvents.Name = "btnResetCaptureEvents";
        	this.btnResetCaptureEvents.Size = new System.Drawing.Size(140, 23);
        	this.btnResetCaptureEvents.TabIndex = 7;
        	this.btnResetCaptureEvents.Text = "Reset";
        	this.btnResetCaptureEvents.UseVisualStyleBackColor = true;
        	this.btnResetCaptureEvents.Click += new System.EventHandler(this.btnResetAO_Click);
        	// 
        	// txtAOName
        	// 
        	this.txtAOName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.txtAOName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.txtAOName.Location = new System.Drawing.Point(49, 22);
        	this.txtAOName.Name = "txtAOName";
        	this.txtAOName.Size = new System.Drawing.Size(406, 20);
        	this.txtAOName.TabIndex = 0;
        	// 
        	// label8
        	// 
        	this.label8.AutoSize = true;
        	this.label8.Location = new System.Drawing.Point(5, 25);
        	this.label8.Name = "label8";
        	this.label8.Size = new System.Drawing.Size(38, 13);
        	this.label8.TabIndex = 1;
        	this.label8.Text = "Name:";
        	// 
        	// tabPage2
        	// 
        	this.tabPage2.Controls.Add(this.groupBox6);
        	this.tabPage2.Location = new System.Drawing.Point(4, 22);
        	this.tabPage2.Name = "tabPage2";
        	this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage2.Size = new System.Drawing.Size(1046, 688);
        	this.tabPage2.TabIndex = 1;
        	this.tabPage2.Text = "Replacement";
        	this.tabPage2.UseVisualStyleBackColor = true;
        	// 
        	// groupBox6
        	// 
        	this.groupBox6.Controls.Add(this.groupBox8);
        	this.groupBox6.Controls.Add(this.groupBox7);
        	this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.groupBox6.Location = new System.Drawing.Point(3, 3);
        	this.groupBox6.Name = "groupBox6";
        	this.groupBox6.Size = new System.Drawing.Size(1040, 682);
        	this.groupBox6.TabIndex = 2;
        	this.groupBox6.TabStop = false;
        	this.groupBox6.Text = "Replacement Events Definition";
        	// 
        	// groupBox8
        	// 
        	this.groupBox8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.groupBox8.Controls.Add(this.btnResetReplacement);
        	this.groupBox8.Controls.Add(this.btnValidate);
        	this.groupBox8.Controls.Add(this.label13);
        	this.groupBox8.Controls.Add(this.cboReplacementType);
        	this.groupBox8.Controls.Add(this.btnAddReplacementEvent);
        	this.groupBox8.Controls.Add(this.txtReplacementDesc);
        	this.groupBox8.Controls.Add(this.label9);
        	this.groupBox8.Controls.Add(this.btnSaveReplacement);
        	this.groupBox8.Controls.Add(this.txtReplacementName);
        	this.groupBox8.Controls.Add(this.txtReplacementRep);
        	this.groupBox8.Controls.Add(this.label10);
        	this.groupBox8.Controls.Add(this.label11);
        	this.groupBox8.Location = new System.Drawing.Point(299, 16);
        	this.groupBox8.Name = "groupBox8";
        	this.groupBox8.Size = new System.Drawing.Size(735, 663);
        	this.groupBox8.TabIndex = 10;
        	this.groupBox8.TabStop = false;
        	this.groupBox8.Text = "Definition";
        	// 
        	// btnResetReplacement
        	// 
        	this.btnResetReplacement.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnResetReplacement.Location = new System.Drawing.Point(451, 634);
        	this.btnResetReplacement.Name = "btnResetReplacement";
        	this.btnResetReplacement.Size = new System.Drawing.Size(75, 23);
        	this.btnResetReplacement.TabIndex = 15;
        	this.btnResetReplacement.Text = "Reset";
        	this.btnResetReplacement.UseVisualStyleBackColor = true;
        	this.btnResetReplacement.Click += new System.EventHandler(this.btnResetReplacement_Click);
        	// 
        	// btnValidate
        	// 
        	this.btnValidate.Location = new System.Drawing.Point(321, 305);
        	this.btnValidate.Name = "btnValidate";
        	this.btnValidate.Size = new System.Drawing.Size(75, 23);
        	this.btnValidate.TabIndex = 13;
        	this.btnValidate.Text = "Validate";
        	this.btnValidate.UseVisualStyleBackColor = true;
        	this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
        	// 
        	// label13
        	// 
        	this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.label13.AutoSize = true;
        	this.label13.Location = new System.Drawing.Point(535, 23);
        	this.label13.Name = "label13";
        	this.label13.Size = new System.Drawing.Size(34, 13);
        	this.label13.TabIndex = 11;
        	this.label13.Text = "Type:";
        	// 
        	// cboReplacementType
        	// 
        	this.cboReplacementType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.cboReplacementType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cboReplacementType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.cboReplacementType.FormattingEnabled = true;
        	this.cboReplacementType.Items.AddRange(new object[] {
        	        	        	"one",
        	        	        	"two",
        	        	        	"three"});
        	this.cboReplacementType.Location = new System.Drawing.Point(575, 20);
        	this.cboReplacementType.Name = "cboReplacementType";
        	this.cboReplacementType.Size = new System.Drawing.Size(154, 21);
        	this.cboReplacementType.TabIndex = 10;
        	// 
        	// btnAddReplacementEvent
        	// 
        	this.btnAddReplacementEvent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnAddReplacementEvent.Location = new System.Drawing.Point(370, 634);
        	this.btnAddReplacementEvent.Name = "btnAddReplacementEvent";
        	this.btnAddReplacementEvent.Size = new System.Drawing.Size(75, 23);
        	this.btnAddReplacementEvent.TabIndex = 9;
        	this.btnAddReplacementEvent.Text = "Add";
        	this.btnAddReplacementEvent.UseVisualStyleBackColor = true;
        	this.btnAddReplacementEvent.Click += new System.EventHandler(this.btnAddReplacementEvent_Click);
        	// 
        	// txtReplacementDesc
        	// 
        	this.txtReplacementDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.txtReplacementDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.txtReplacementDesc.Location = new System.Drawing.Point(91, 46);
        	this.txtReplacementDesc.Multiline = true;
        	this.txtReplacementDesc.Name = "txtReplacementDesc";
        	this.txtReplacementDesc.Size = new System.Drawing.Size(638, 123);
        	this.txtReplacementDesc.TabIndex = 3;
        	// 
        	// label9
        	// 
        	this.label9.AutoSize = true;
        	this.label9.Location = new System.Drawing.Point(9, 20);
        	this.label9.Name = "label9";
        	this.label9.Size = new System.Drawing.Size(38, 13);
        	this.label9.TabIndex = 0;
        	this.label9.Text = "Name:";
        	// 
        	// btnSaveReplacement
        	// 
        	this.btnSaveReplacement.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnSaveReplacement.Enabled = false;
        	this.btnSaveReplacement.Location = new System.Drawing.Point(289, 634);
        	this.btnSaveReplacement.Name = "btnSaveReplacement";
        	this.btnSaveReplacement.Size = new System.Drawing.Size(75, 23);
        	this.btnSaveReplacement.TabIndex = 8;
        	this.btnSaveReplacement.Text = "Save";
        	this.btnSaveReplacement.UseVisualStyleBackColor = true;
        	this.btnSaveReplacement.Click += new System.EventHandler(this.btnSaveReplacement_Click);
        	// 
        	// txtReplacementName
        	// 
        	this.txtReplacementName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.txtReplacementName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.txtReplacementName.Location = new System.Drawing.Point(91, 17);
        	this.txtReplacementName.Name = "txtReplacementName";
        	this.txtReplacementName.Size = new System.Drawing.Size(282, 20);
        	this.txtReplacementName.TabIndex = 1;
        	// 
        	// txtReplacementRep
        	// 
        	this.txtReplacementRep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.txtReplacementRep.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.txtReplacementRep.Location = new System.Drawing.Point(91, 175);
        	this.txtReplacementRep.Multiline = true;
        	this.txtReplacementRep.Name = "txtReplacementRep";
        	this.txtReplacementRep.Size = new System.Drawing.Size(638, 123);
        	this.txtReplacementRep.TabIndex = 5;
        	// 
        	// label10
        	// 
        	this.label10.AutoSize = true;
        	this.label10.Location = new System.Drawing.Point(9, 49);
        	this.label10.Name = "label10";
        	this.label10.Size = new System.Drawing.Size(66, 13);
        	this.label10.TabIndex = 2;
        	this.label10.Text = "Description: ";
        	// 
        	// label11
        	// 
        	this.label11.AutoSize = true;
        	this.label11.Location = new System.Drawing.Point(9, 178);
        	this.label11.Name = "label11";
        	this.label11.Size = new System.Drawing.Size(76, 13);
        	this.label11.TabIndex = 4;
        	this.label11.Text = "Replacement: ";
        	// 
        	// groupBox7
        	// 
        	this.groupBox7.Controls.Add(this.btnRefreshReplacements);
        	this.groupBox7.Controls.Add(this.lbAvailableReplacements);
        	this.groupBox7.Controls.Add(this.cboCapturePoint);
        	this.groupBox7.Controls.Add(this.label12);
        	this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
        	this.groupBox7.Location = new System.Drawing.Point(3, 16);
        	this.groupBox7.Name = "groupBox7";
        	this.groupBox7.Size = new System.Drawing.Size(290, 663);
        	this.groupBox7.TabIndex = 9;
        	this.groupBox7.TabStop = false;
        	this.groupBox7.Text = "Replacements";
        	// 
        	// btnRefreshReplacements
        	// 
        	this.btnRefreshReplacements.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnRefreshReplacements.Location = new System.Drawing.Point(108, 634);
        	this.btnRefreshReplacements.Name = "btnRefreshReplacements";
        	this.btnRefreshReplacements.Size = new System.Drawing.Size(75, 23);
        	this.btnRefreshReplacements.TabIndex = 10;
        	this.btnRefreshReplacements.Text = "Refresh";
        	this.btnRefreshReplacements.UseVisualStyleBackColor = true;
        	this.btnRefreshReplacements.Click += new System.EventHandler(this.btnRefreshReplacements_Click);
        	// 
        	// lbAvailableReplacements
        	// 
        	this.lbAvailableReplacements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left)));
        	this.lbAvailableReplacements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.lbAvailableReplacements.FormattingEnabled = true;
        	this.lbAvailableReplacements.Location = new System.Drawing.Point(6, 53);
        	this.lbAvailableReplacements.Name = "lbAvailableReplacements";
        	this.lbAvailableReplacements.Size = new System.Drawing.Size(278, 576);
        	this.lbAvailableReplacements.TabIndex = 8;
        	this.lbAvailableReplacements.SelectedIndexChanged += new System.EventHandler(this.lbAvailableReplacements_SelectedIndexChanged);
        	// 
        	// cboCapturePoint
        	// 
        	this.cboCapturePoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.cboCapturePoint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.cboCapturePoint.FormattingEnabled = true;
        	this.cboCapturePoint.Location = new System.Drawing.Point(72, 20);
        	this.cboCapturePoint.Name = "cboCapturePoint";
        	this.cboCapturePoint.Size = new System.Drawing.Size(212, 21);
        	this.cboCapturePoint.TabIndex = 7;
        	this.cboCapturePoint.SelectedIndexChanged += new System.EventHandler(this.cboCapturePoint_SelectedIndexChanged);
        	// 
        	// label12
        	// 
        	this.label12.AutoSize = true;
        	this.label12.Location = new System.Drawing.Point(6, 23);
        	this.label12.Name = "label12";
        	this.label12.Size = new System.Drawing.Size(66, 13);
        	this.label12.TabIndex = 6;
        	this.label12.Text = "Capture Evt.";
        	// 
        	// groupBox4
        	// 
        	this.groupBox4.Controls.Add(this.lbOptions);
        	this.groupBox4.Controls.Add(this.btnReloadOptions);
        	this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
        	this.groupBox4.Location = new System.Drawing.Point(3, 16);
        	this.groupBox4.Name = "groupBox4";
        	this.groupBox4.Size = new System.Drawing.Size(197, 445);
        	this.groupBox4.TabIndex = 14;
        	this.groupBox4.TabStop = false;
        	this.groupBox4.Text = "Available Options";
        	// 
        	// lbOptions
        	// 
        	this.lbOptions.FormattingEnabled = true;
        	this.lbOptions.Location = new System.Drawing.Point(7, 15);
        	this.lbOptions.Name = "lbOptions";
        	this.lbOptions.Size = new System.Drawing.Size(184, 394);
        	this.lbOptions.TabIndex = 22;
        	// 
        	// btnReloadOptions
        	// 
        	this.btnReloadOptions.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnReloadOptions.Location = new System.Drawing.Point(20, 415);
        	this.btnReloadOptions.Name = "btnReloadOptions";
        	this.btnReloadOptions.Size = new System.Drawing.Size(156, 23);
        	this.btnReloadOptions.TabIndex = 0;
        	this.btnReloadOptions.Text = "Reload Options";
        	this.btnReloadOptions.UseVisualStyleBackColor = true;
        	// 
        	// groupBox3
        	// 
        	this.groupBox3.Controls.Add(this.btnAdd);
        	this.groupBox3.Controls.Add(this.btnReset);
        	this.groupBox3.Controls.Add(this.btnSave);
        	this.groupBox3.Controls.Add(this.txtOptionReplacement);
        	this.groupBox3.Controls.Add(this.label3);
        	this.groupBox3.Controls.Add(this.txtOptionDesc);
        	this.groupBox3.Controls.Add(this.txtOptionPattern);
        	this.groupBox3.Controls.Add(this.label4);
        	this.groupBox3.Controls.Add(this.chkIsRegex);
        	this.groupBox3.Controls.Add(this.txtOptionName);
        	this.groupBox3.Controls.Add(this.label2);
        	this.groupBox3.Controls.Add(this.label1);
        	this.groupBox3.Location = new System.Drawing.Point(206, 19);
        	this.groupBox3.Name = "groupBox3";
        	this.groupBox3.Size = new System.Drawing.Size(521, 441);
        	this.groupBox3.TabIndex = 2;
        	this.groupBox3.TabStop = false;
        	this.groupBox3.Text = "Definition";
        	// 
        	// btnAdd
        	// 
        	this.btnAdd.Enabled = false;
        	this.btnAdd.Location = new System.Drawing.Point(21, 412);
        	this.btnAdd.Name = "btnAdd";
        	this.btnAdd.Size = new System.Drawing.Size(156, 23);
        	this.btnAdd.TabIndex = 5;
        	this.btnAdd.Text = "Add";
        	this.btnAdd.UseVisualStyleBackColor = true;
        	// 
        	// btnReset
        	// 
        	this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnReset.Location = new System.Drawing.Point(343, 412);
        	this.btnReset.Name = "btnReset";
        	this.btnReset.Size = new System.Drawing.Size(156, 23);
        	this.btnReset.TabIndex = 7;
        	this.btnReset.Text = "Reset";
        	this.btnReset.UseVisualStyleBackColor = true;
        	// 
        	// btnSave
        	// 
        	this.btnSave.Enabled = false;
        	this.btnSave.Location = new System.Drawing.Point(183, 412);
        	this.btnSave.Name = "btnSave";
        	this.btnSave.Size = new System.Drawing.Size(156, 23);
        	this.btnSave.TabIndex = 6;
        	this.btnSave.Text = "Save";
        	this.btnSave.UseVisualStyleBackColor = true;
        	// 
        	// txtOptionReplacement
        	// 
        	this.txtOptionReplacement.Location = new System.Drawing.Point(13, 311);
        	this.txtOptionReplacement.Multiline = true;
        	this.txtOptionReplacement.Name = "txtOptionReplacement";
        	this.txtOptionReplacement.Size = new System.Drawing.Size(498, 83);
        	this.txtOptionReplacement.TabIndex = 4;
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(10, 295);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(73, 13);
        	this.label3.TabIndex = 13;
        	this.label3.Text = "Replacement:";
        	// 
        	// txtOptionDesc
        	// 
        	this.txtOptionDesc.Location = new System.Drawing.Point(13, 75);
        	this.txtOptionDesc.Multiline = true;
        	this.txtOptionDesc.Name = "txtOptionDesc";
        	this.txtOptionDesc.Size = new System.Drawing.Size(498, 83);
        	this.txtOptionDesc.TabIndex = 1;
        	// 
        	// txtOptionPattern
        	// 
        	this.txtOptionPattern.Location = new System.Drawing.Point(13, 193);
        	this.txtOptionPattern.Multiline = true;
        	this.txtOptionPattern.Name = "txtOptionPattern";
        	this.txtOptionPattern.Size = new System.Drawing.Size(498, 83);
        	this.txtOptionPattern.TabIndex = 3;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(10, 177);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(44, 13);
        	this.label4.TabIndex = 7;
        	this.label4.Text = "Pattern:";
        	// 
        	// chkIsRegex
        	// 
        	this.chkIsRegex.AutoSize = true;
        	this.chkIsRegex.Location = new System.Drawing.Point(454, 173);
        	this.chkIsRegex.Name = "chkIsRegex";
        	this.chkIsRegex.Size = new System.Drawing.Size(57, 17);
        	this.chkIsRegex.TabIndex = 2;
        	this.chkIsRegex.Text = "Regex";
        	this.chkIsRegex.UseVisualStyleBackColor = true;
        	// 
        	// txtOptionName
        	// 
        	this.txtOptionName.Location = new System.Drawing.Point(51, 19);
        	this.txtOptionName.Name = "txtOptionName";
        	this.txtOptionName.Size = new System.Drawing.Size(254, 20);
        	this.txtOptionName.TabIndex = 0;
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(10, 59);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(63, 13);
        	this.label2.TabIndex = 3;
        	this.label2.Text = "Description:";
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(10, 22);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(38, 13);
        	this.label1.TabIndex = 1;
        	this.label1.Text = "Name:";
        	// 
        	// listBox1
        	// 
        	this.listBox1.FormattingEnabled = true;
        	this.listBox1.Location = new System.Drawing.Point(7, 15);
        	this.listBox1.Name = "listBox1";
        	this.listBox1.Size = new System.Drawing.Size(184, 446);
        	this.listBox1.TabIndex = 22;
        	// 
        	// button2
        	// 
        	this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.button2.Location = new System.Drawing.Point(20, 469);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(156, 23);
        	this.button2.TabIndex = 0;
        	this.button2.Text = "Reload Options";
        	this.button2.UseVisualStyleBackColor = true;
        	// 
        	// SetupAdvancedRecForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(1054, 714);
        	this.Controls.Add(this.tabControl1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "SetupAdvancedRecForm";
        	this.Text = "Setup Advanced Rec.";
        	this.Load += new System.EventHandler(this.SetupAdvancedRecForm_Load);
        	this.tabControl1.ResumeLayout(false);
        	this.tabPage1.ResumeLayout(false);
        	this.groupBox2.ResumeLayout(false);
        	this.gbRuleDefinition.ResumeLayout(false);
        	this.gbRuleDefinition.PerformLayout();
        	this.gbSpecificConfNodes.ResumeLayout(false);
        	this.gbSpecificConfNodes.PerformLayout();
        	this.grpBoxAttr.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).EndInit();
        	this.gbSpecificConfDef.ResumeLayout(false);
        	this.gbSpecificConfDef.PerformLayout();
        	this.tabPage2.ResumeLayout(false);
        	this.groupBox6.ResumeLayout(false);
        	this.groupBox8.ResumeLayout(false);
        	this.groupBox8.PerformLayout();
        	this.groupBox7.ResumeLayout(false);
        	this.groupBox7.PerformLayout();
        	this.groupBox4.ResumeLayout(false);
        	this.groupBox3.ResumeLayout(false);
        	this.groupBox3.PerformLayout();
        	this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox gbRuleDefinition;
        private System.Windows.Forms.GroupBox gbSpecificConfDef;
        private System.Windows.Forms.Button btnAddCaptureEvent;
        private System.Windows.Forms.Button btnResetCaptureEvents;
        private System.Windows.Forms.Button btnSaveCaptureEvent;
        private System.Windows.Forms.TextBox txtAODescription;
        private System.Windows.Forms.TextBox txtAOEventIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAOName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lbOptions;
        private System.Windows.Forms.Button btnReloadOptions;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtOptionReplacement;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOptionDesc;
        private System.Windows.Forms.TextBox txtOptionPattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsRegex;
        private System.Windows.Forms.TextBox txtOptionName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbAdvancedCE;
        private System.Windows.Forms.Button btnReloadCapturePoints;
        private System.Windows.Forms.GroupBox gbSpecificConfNodes;
        private System.Windows.Forms.GroupBox grpBoxAttr;
        private System.Windows.Forms.DataGridView dgvAttributes;
        private System.Windows.Forms.TreeView tvOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn useAttribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboReplacementType;
        private System.Windows.Forms.Button btnAddReplacementEvent;
        private System.Windows.Forms.TextBox txtReplacementDesc;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnSaveReplacement;
        private System.Windows.Forms.TextBox txtReplacementName;
        private System.Windows.Forms.TextBox txtReplacementRep;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button btnRefreshReplacements;
        private System.Windows.Forms.ListBox lbAvailableReplacements;
        private System.Windows.Forms.ComboBox cboCapturePoint;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnResetReplacement;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboCaptureType;        
    }
}