namespace XmlParsersAndUi.Forms {
    partial class MacroConverterConfForm {
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacroConverterConfForm));
        	this.tabControl1 = new System.Windows.Forms.TabControl();
        	this.tabPage1 = new System.Windows.Forms.TabPage();
        	this.groupBox2 = new System.Windows.Forms.GroupBox();
        	this.lbAdvancedCE = new System.Windows.Forms.ListBox();
        	this.btnReloadCapturePoints = new System.Windows.Forms.Button();
        	this.gbRuleDefinition = new System.Windows.Forms.GroupBox();
        	this.btnDeleteAdvanceRec = new System.Windows.Forms.Button();
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
        	this.txtTextValue = new System.Windows.Forms.TextBox();
        	this.label1 = new System.Windows.Forms.Label();
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
        	this.tabControl1.SuspendLayout();
        	this.tabPage1.SuspendLayout();
        	this.groupBox2.SuspendLayout();
        	this.gbRuleDefinition.SuspendLayout();
        	this.gbSpecificConfNodes.SuspendLayout();
        	this.grpBoxAttr.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.dgvAttributes)).BeginInit();
        	this.gbSpecificConfDef.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// tabControl1
        	// 
        	this.tabControl1.Controls.Add(this.tabPage1);
        	this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tabControl1.Location = new System.Drawing.Point(0, 0);
        	this.tabControl1.Name = "tabControl1";
        	this.tabControl1.SelectedIndex = 0;
        	this.tabControl1.Size = new System.Drawing.Size(955, 756);
        	this.tabControl1.TabIndex = 3;
        	// 
        	// tabPage1
        	// 
        	this.tabPage1.Controls.Add(this.groupBox2);
        	this.tabPage1.Controls.Add(this.gbRuleDefinition);
        	this.tabPage1.Location = new System.Drawing.Point(4, 22);
        	this.tabPage1.Name = "tabPage1";
        	this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
        	this.tabPage1.Size = new System.Drawing.Size(947, 730);
        	this.tabPage1.TabIndex = 0;
        	this.tabPage1.Text = "Events";
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
        	this.groupBox2.Size = new System.Drawing.Size(227, 716);
        	this.groupBox2.TabIndex = 16;
        	this.groupBox2.TabStop = false;
        	this.groupBox2.Text = "Available Events";
        	// 
        	// lbAdvancedCE
        	// 
        	this.lbAdvancedCE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left)));
        	this.lbAdvancedCE.FormattingEnabled = true;
        	this.lbAdvancedCE.Location = new System.Drawing.Point(7, 15);
        	this.lbAdvancedCE.Name = "lbAdvancedCE";
        	this.lbAdvancedCE.Size = new System.Drawing.Size(214, 654);
        	this.lbAdvancedCE.Sorted = true;
        	this.lbAdvancedCE.TabIndex = 22;
        	this.lbAdvancedCE.SelectedIndexChanged += new System.EventHandler(this.lbAdvancedCE_SelectedIndexChanged_1);
        	// 
        	// btnReloadCapturePoints
        	// 
        	this.btnReloadCapturePoints.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnReloadCapturePoints.Location = new System.Drawing.Point(35, 681);
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
        	this.gbRuleDefinition.Controls.Add(this.btnDeleteAdvanceRec);
        	this.gbRuleDefinition.Controls.Add(this.label14);
        	this.gbRuleDefinition.Controls.Add(this.gbSpecificConfNodes);
        	this.gbRuleDefinition.Controls.Add(this.cboCaptureType);
        	this.gbRuleDefinition.Controls.Add(this.gbSpecificConfDef);
        	this.gbRuleDefinition.Controls.Add(this.btnAddCaptureEvent);
        	this.gbRuleDefinition.Controls.Add(this.btnSaveCaptureEvent);
        	this.gbRuleDefinition.Controls.Add(this.btnResetCaptureEvents);
        	this.gbRuleDefinition.Controls.Add(this.txtAOName);
        	this.gbRuleDefinition.Controls.Add(this.label8);
        	this.gbRuleDefinition.Location = new System.Drawing.Point(239, 6);
        	this.gbRuleDefinition.Name = "gbRuleDefinition";
        	this.gbRuleDefinition.Size = new System.Drawing.Size(700, 716);
        	this.gbRuleDefinition.TabIndex = 2;
        	this.gbRuleDefinition.TabStop = false;
        	this.gbRuleDefinition.Text = "Rule Definition";
        	// 
        	// btnDeleteAdvanceRec
        	// 
        	this.btnDeleteAdvanceRec.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnDeleteAdvanceRec.Enabled = false;
        	this.btnDeleteAdvanceRec.Location = new System.Drawing.Point(499, 687);
        	this.btnDeleteAdvanceRec.Name = "btnDeleteAdvanceRec";
        	this.btnDeleteAdvanceRec.Size = new System.Drawing.Size(140, 23);
        	this.btnDeleteAdvanceRec.TabIndex = 19;
        	this.btnDeleteAdvanceRec.Text = "Delete";
        	this.btnDeleteAdvanceRec.UseVisualStyleBackColor = true;
        	this.btnDeleteAdvanceRec.Click += new System.EventHandler(this.btnDeleteAdvanceRec_Click);
        	// 
        	// label14
        	// 
        	this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.label14.AutoSize = true;
        	this.label14.Location = new System.Drawing.Point(494, 25);
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
        	this.gbSpecificConfNodes.Location = new System.Drawing.Point(7, 376);
        	this.gbSpecificConfNodes.Name = "gbSpecificConfNodes";
        	this.gbSpecificConfNodes.Size = new System.Drawing.Size(687, 305);
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
        	this.grpBoxAttr.Size = new System.Drawing.Size(429, 279);
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
        	this.dgvAttributes.Size = new System.Drawing.Size(423, 260);
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
        	this.tvOutput.Location = new System.Drawing.Point(6, 36);
        	this.tvOutput.Name = "tvOutput";
        	this.tvOutput.Size = new System.Drawing.Size(223, 263);
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
        	this.cboCaptureType.FormattingEnabled = true;
        	this.cboCaptureType.Items.AddRange(new object[] {
        	        	        	"one",
        	        	        	"two",
        	        	        	"three"});
        	this.cboCaptureType.Location = new System.Drawing.Point(534, 22);
        	this.cboCaptureType.Name = "cboCaptureType";
        	this.cboCaptureType.Size = new System.Drawing.Size(154, 21);
        	this.cboCaptureType.TabIndex = 17;
        	// 
        	// gbSpecificConfDef
        	// 
        	this.gbSpecificConfDef.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.gbSpecificConfDef.Controls.Add(this.txtTextValue);
        	this.gbSpecificConfDef.Controls.Add(this.label1);
        	this.gbSpecificConfDef.Controls.Add(this.btnParse);
        	this.gbSpecificConfDef.Controls.Add(this.txtAODescription);
        	this.gbSpecificConfDef.Controls.Add(this.txtAOEventIn);
        	this.gbSpecificConfDef.Controls.Add(this.label6);
        	this.gbSpecificConfDef.Controls.Add(this.label7);
        	this.gbSpecificConfDef.Location = new System.Drawing.Point(6, 58);
        	this.gbSpecificConfDef.Name = "gbSpecificConfDef";
        	this.gbSpecificConfDef.Size = new System.Drawing.Size(688, 312);
        	this.gbSpecificConfDef.TabIndex = 2;
        	this.gbSpecificConfDef.TabStop = false;
        	this.gbSpecificConfDef.Text = "Definition";
        	// 
        	// txtTextValue
        	// 
        	this.txtTextValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.txtTextValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.txtTextValue.Location = new System.Drawing.Point(5, 137);
        	this.txtTextValue.Multiline = true;
        	this.txtTextValue.Name = "txtTextValue";
        	this.txtTextValue.Size = new System.Drawing.Size(676, 52);
        	this.txtTextValue.TabIndex = 17;
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(4, 121);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(61, 13);
        	this.label1.TabIndex = 18;
        	this.label1.Text = "Text Value:";
        	// 
        	// btnParse
        	// 
        	this.btnParse.Anchor = System.Windows.Forms.AnchorStyles.Top;
        	this.btnParse.Location = new System.Drawing.Point(276, 283);
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
        	this.txtAODescription.Location = new System.Drawing.Point(7, 208);
        	this.txtAODescription.Multiline = true;
        	this.txtAODescription.Name = "txtAODescription";
        	this.txtAODescription.Size = new System.Drawing.Size(676, 52);
        	this.txtAODescription.TabIndex = 1;
        	// 
        	// txtAOEventIn
        	// 
        	this.txtAOEventIn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.txtAOEventIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        	this.txtAOEventIn.Location = new System.Drawing.Point(6, 32);
        	this.txtAOEventIn.Multiline = true;
        	this.txtAOEventIn.Name = "txtAOEventIn";
        	this.txtAOEventIn.Size = new System.Drawing.Size(676, 83);
        	this.txtAOEventIn.TabIndex = 3;
        	// 
        	// label6
        	// 
        	this.label6.AutoSize = true;
        	this.label6.Location = new System.Drawing.Point(6, 16);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(65, 13);
        	this.label6.TabIndex = 7;
        	this.label6.Text = "Input Event:";
        	// 
        	// label7
        	// 
        	this.label7.AutoSize = true;
        	this.label7.Location = new System.Drawing.Point(7, 192);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(63, 13);
        	this.label7.TabIndex = 3;
        	this.label7.Text = "Description:";
        	// 
        	// btnAddCaptureEvent
        	// 
        	this.btnAddCaptureEvent.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        	this.btnAddCaptureEvent.Enabled = false;
        	this.btnAddCaptureEvent.Location = new System.Drawing.Point(61, 687);
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
        	this.btnSaveCaptureEvent.Location = new System.Drawing.Point(207, 687);
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
        	this.btnResetCaptureEvents.Location = new System.Drawing.Point(353, 687);
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
        	this.txtAOName.Size = new System.Drawing.Size(347, 20);
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
        	// MacroConverterConfForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(955, 756);
        	this.Controls.Add(this.tabControl1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.Name = "MacroConverterConfForm";
        	this.Text = "SDD Generator Configuration";
        	this.Load += new System.EventHandler(this.MacroConverter_Load);
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
        	this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbAdvancedCE;
        private System.Windows.Forms.Button btnReloadCapturePoints;
        private System.Windows.Forms.GroupBox gbRuleDefinition;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.GroupBox gbSpecificConfNodes;
        private System.Windows.Forms.GroupBox grpBoxAttr;
        private System.Windows.Forms.DataGridView dgvAttributes;
        private System.Windows.Forms.DataGridViewCheckBoxColumn useAttribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Attribute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Value;
        private System.Windows.Forms.TreeView tvOutput;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboCaptureType;
        private System.Windows.Forms.GroupBox gbSpecificConfDef;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TextBox txtAODescription;
        private System.Windows.Forms.TextBox txtAOEventIn;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnAddCaptureEvent;
        private System.Windows.Forms.Button btnSaveCaptureEvent;
        private System.Windows.Forms.Button btnResetCaptureEvents;
        private System.Windows.Forms.TextBox txtAOName;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTextValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDeleteAdvanceRec;
    }
}