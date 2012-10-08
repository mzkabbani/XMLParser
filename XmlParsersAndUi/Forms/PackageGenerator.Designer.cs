namespace XmlParsersAndUi.Forms {
    partial class PackageGenerator {
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageGenerator));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAvailableFunctions = new System.Windows.Forms.ListBox();
            this.btnGeneratePackage = new System.Windows.Forms.Button();
            this.lbAvailableVars = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnAddVar = new System.Windows.Forms.Button();
            this.btnSaveVar = new System.Windows.Forms.Button();
            this.btnResetVar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVarName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVarDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDefaultValue = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboVarType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbParameters = new System.Windows.Forms.GroupBox();
            this.pnlParameters = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFunctionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExportCi = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.gbProperty = new System.Windows.Forms.GroupBox();
            this.cboPropertyValue = new System.Windows.Forms.ComboBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnRemoveProperty = new System.Windows.Forms.Button();
            this.btnSaveProperty = new System.Windows.Forms.Button();
            this.btnAddProperty = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.cboPropertyType = new System.Windows.Forms.ComboBox();
            this.txtPropertyValue = new System.Windows.Forms.TextBox();
            this.lblPropValue = new System.Windows.Forms.Label();
            this.txtPropertyDesc = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPropertyName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbAvailableProps = new System.Windows.Forms.ListBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.dgvOutputOperations = new System.Windows.Forms.DataGridView();
            this.Steps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmsAddPropertyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relAppdirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnImportCi = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbParameters.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.gbProperty.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputOperations)).BeginInit();
            this.cmsAddPropertyMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAvailableFunctions);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 375);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Available Funtctions";
            // 
            // lbAvailableFunctions
            // 
            this.lbAvailableFunctions.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAvailableFunctions.FormattingEnabled = true;
            this.lbAvailableFunctions.Location = new System.Drawing.Point(7, 20);
            this.lbAvailableFunctions.Name = "lbAvailableFunctions";
            this.lbAvailableFunctions.Size = new System.Drawing.Size(210, 342);
            this.lbAvailableFunctions.TabIndex = 0;
            this.lbAvailableFunctions.SelectedIndexChanged += new System.EventHandler(this.lbAvailableFunctions_SelectedIndexChanged);
            // 
            // btnGeneratePackage
            // 
            this.btnGeneratePackage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGeneratePackage.Location = new System.Drawing.Point(159, 673);
            this.btnGeneratePackage.Name = "btnGeneratePackage";
            this.btnGeneratePackage.Size = new System.Drawing.Size(174, 23);
            this.btnGeneratePackage.TabIndex = 7;
            this.btnGeneratePackage.Text = "Generate Package";
            this.btnGeneratePackage.UseVisualStyleBackColor = true;
            this.btnGeneratePackage.Click += new System.EventHandler(this.btnGeneratePackage_Click);
            // 
            // lbAvailableVars
            // 
            this.lbAvailableVars.FormattingEnabled = true;
            this.lbAvailableVars.Location = new System.Drawing.Point(6, 19);
            this.lbAvailableVars.Name = "lbAvailableVars";
            this.lbAvailableVars.Size = new System.Drawing.Size(135, 199);
            this.lbAvailableVars.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(148, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(424, 203);
            this.groupBox5.TabIndex = 5;
            this.groupBox5.TabStop = false;
            // 
            // btnAddVar
            // 
            this.btnAddVar.Location = new System.Drawing.Point(94, 174);
            this.btnAddVar.Name = "btnAddVar";
            this.btnAddVar.Size = new System.Drawing.Size(75, 23);
            this.btnAddVar.TabIndex = 5;
            this.btnAddVar.Text = "Add";
            this.btnAddVar.UseVisualStyleBackColor = true;
            // 
            // btnSaveVar
            // 
            this.btnSaveVar.Location = new System.Drawing.Point(175, 174);
            this.btnSaveVar.Name = "btnSaveVar";
            this.btnSaveVar.Size = new System.Drawing.Size(75, 23);
            this.btnSaveVar.TabIndex = 6;
            this.btnSaveVar.Text = "Save";
            this.btnSaveVar.UseVisualStyleBackColor = true;
            // 
            // btnResetVar
            // 
            this.btnResetVar.Location = new System.Drawing.Point(256, 174);
            this.btnResetVar.Name = "btnResetVar";
            this.btnResetVar.Size = new System.Drawing.Size(75, 23);
            this.btnResetVar.TabIndex = 7;
            this.btnResetVar.Text = "Reset";
            this.btnResetVar.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 8;
            // 
            // txtVarName
            // 
            this.txtVarName.Location = new System.Drawing.Point(50, 19);
            this.txtVarName.Name = "txtVarName";
            this.txtVarName.Size = new System.Drawing.Size(218, 20);
            this.txtVarName.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 10;
            // 
            // txtVarDescription
            // 
            this.txtVarDescription.Location = new System.Drawing.Point(6, 64);
            this.txtVarDescription.Multiline = true;
            this.txtVarDescription.Name = "txtVarDescription";
            this.txtVarDescription.Size = new System.Drawing.Size(412, 67);
            this.txtVarDescription.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(218, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 12;
            // 
            // txtDefaultValue
            // 
            this.txtDefaultValue.Location = new System.Drawing.Point(301, 141);
            this.txtDefaultValue.Name = "txtDefaultValue";
            this.txtDefaultValue.Size = new System.Drawing.Size(117, 20);
            this.txtDefaultValue.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 14;
            // 
            // cboVarType
            // 
            this.cboVarType.FormattingEnabled = true;
            this.cboVarType.Location = new System.Drawing.Point(49, 140);
            this.cboVarType.Name = "cboVarType";
            this.cboVarType.Size = new System.Drawing.Size(120, 21);
            this.cboVarType.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 16;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(79, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(486, 20);
            this.textBox1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(7, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 18;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(79, 45);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(486, 20);
            this.textBox2.TabIndex = 19;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnClear);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.gbParameters);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFunctionName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(235, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(601, 375);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Function Configurations";
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClear.Location = new System.Drawing.Point(303, 343);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(222, 343);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gbParameters
            // 
            this.gbParameters.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbParameters.Controls.Add(this.pnlParameters);
            this.gbParameters.Location = new System.Drawing.Point(7, 116);
            this.gbParameters.Name = "gbParameters";
            this.gbParameters.Size = new System.Drawing.Size(558, 221);
            this.gbParameters.TabIndex = 4;
            this.gbParameters.TabStop = false;
            this.gbParameters.Text = "Parameters";
            // 
            // pnlParameters
            // 
            this.pnlParameters.AutoScroll = true;
            this.pnlParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlParameters.Location = new System.Drawing.Point(3, 16);
            this.pnlParameters.Name = "pnlParameters";
            this.pnlParameters.Size = new System.Drawing.Size(552, 202);
            this.pnlParameters.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(79, 43);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(486, 67);
            this.txtDescription.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description: ";
            // 
            // txtFunctionName
            // 
            this.txtFunctionName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFunctionName.Location = new System.Drawing.Point(79, 17);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.ReadOnly = true;
            this.txtFunctionName.Size = new System.Drawing.Size(329, 20);
            this.txtFunctionName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name: ";
            // 
            // btnExportCi
            // 
            this.btnExportCi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExportCi.Location = new System.Drawing.Point(339, 673);
            this.btnExportCi.Name = "btnExportCi";
            this.btnExportCi.Size = new System.Drawing.Size(174, 23);
            this.btnExportCi.TabIndex = 10;
            this.btnExportCi.Text = "Export .Ci";
            this.btnExportCi.UseVisualStyleBackColor = true;
            this.btnExportCi.Click += new System.EventHandler(this.btnExportCi_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(852, 700);
            this.tabControl1.TabIndex = 11;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(844, 674);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Functions";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.gbProperty);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(844, 674);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Properties";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // gbProperty
            // 
            this.gbProperty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbProperty.Controls.Add(this.cboPropertyValue);
            this.gbProperty.Controls.Add(this.btnReset);
            this.gbProperty.Controls.Add(this.btnRemoveProperty);
            this.gbProperty.Controls.Add(this.btnSaveProperty);
            this.gbProperty.Controls.Add(this.btnAddProperty);
            this.gbProperty.Controls.Add(this.label12);
            this.gbProperty.Controls.Add(this.cboPropertyType);
            this.gbProperty.Controls.Add(this.txtPropertyValue);
            this.gbProperty.Controls.Add(this.lblPropValue);
            this.gbProperty.Controls.Add(this.txtPropertyDesc);
            this.gbProperty.Controls.Add(this.label10);
            this.gbProperty.Controls.Add(this.txtPropertyName);
            this.gbProperty.Controls.Add(this.label9);
            this.gbProperty.Location = new System.Drawing.Point(203, 9);
            this.gbProperty.Name = "gbProperty";
            this.gbProperty.Size = new System.Drawing.Size(633, 371);
            this.gbProperty.TabIndex = 2;
            this.gbProperty.TabStop = false;
            this.gbProperty.Text = "Property";
            // 
            // cboPropertyValue
            // 
            this.cboPropertyValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPropertyValue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPropertyValue.FormattingEnabled = true;
            this.cboPropertyValue.Items.AddRange(new object[] {
            "True",
            "False"});
            this.cboPropertyValue.Location = new System.Drawing.Point(53, 177);
            this.cboPropertyValue.Name = "cboPropertyValue";
            this.cboPropertyValue.Size = new System.Drawing.Size(131, 21);
            this.cboPropertyValue.TabIndex = 12;
            this.cboPropertyValue.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReset.Location = new System.Drawing.Point(400, 342);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRemoveProperty
            // 
            this.btnRemoveProperty.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemoveProperty.Location = new System.Drawing.Point(319, 342);
            this.btnRemoveProperty.Name = "btnRemoveProperty";
            this.btnRemoveProperty.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveProperty.TabIndex = 10;
            this.btnRemoveProperty.Text = "Remove";
            this.btnRemoveProperty.UseVisualStyleBackColor = true;
            this.btnRemoveProperty.Click += new System.EventHandler(this.btnRemoveProperty_Click);
            // 
            // btnSaveProperty
            // 
            this.btnSaveProperty.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSaveProperty.Location = new System.Drawing.Point(238, 342);
            this.btnSaveProperty.Name = "btnSaveProperty";
            this.btnSaveProperty.Size = new System.Drawing.Size(75, 23);
            this.btnSaveProperty.TabIndex = 9;
            this.btnSaveProperty.Text = "Save";
            this.btnSaveProperty.UseVisualStyleBackColor = true;
            this.btnSaveProperty.Click += new System.EventHandler(this.btnSaveProperty_Click);
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddProperty.Location = new System.Drawing.Point(157, 342);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(75, 23);
            this.btnAddProperty.TabIndex = 8;
            this.btnAddProperty.Text = "Add";
            this.btnAddProperty.UseVisualStyleBackColor = true;
            this.btnAddProperty.Click += new System.EventHandler(this.btnAddProperty_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(5, 154);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Type: ";
            // 
            // cboPropertyType
            // 
            this.cboPropertyType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cboPropertyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPropertyType.FormattingEnabled = true;
            this.cboPropertyType.Items.AddRange(new object[] {
            "String",
            "Boolean"});
            this.cboPropertyType.Location = new System.Drawing.Point(52, 151);
            this.cboPropertyType.Name = "cboPropertyType";
            this.cboPropertyType.Size = new System.Drawing.Size(131, 21);
            this.cboPropertyType.TabIndex = 6;
            this.cboPropertyType.SelectedIndexChanged += new System.EventHandler(this.cboPropertyType_SelectedIndexChanged);
            // 
            // txtPropertyValue
            // 
            this.txtPropertyValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPropertyValue.Location = new System.Drawing.Point(52, 178);
            this.txtPropertyValue.Name = "txtPropertyValue";
            this.txtPropertyValue.Size = new System.Drawing.Size(233, 20);
            this.txtPropertyValue.TabIndex = 5;
            this.txtPropertyValue.Visible = false;
            // 
            // lblPropValue
            // 
            this.lblPropValue.AutoSize = true;
            this.lblPropValue.Location = new System.Drawing.Point(6, 181);
            this.lblPropValue.Name = "lblPropValue";
            this.lblPropValue.Size = new System.Drawing.Size(40, 13);
            this.lblPropValue.TabIndex = 4;
            this.lblPropValue.Text = "Value: ";
            // 
            // txtPropertyDesc
            // 
            this.txtPropertyDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPropertyDesc.Location = new System.Drawing.Point(53, 58);
            this.txtPropertyDesc.Multiline = true;
            this.txtPropertyDesc.Name = "txtPropertyDesc";
            this.txtPropertyDesc.Size = new System.Drawing.Size(552, 87);
            this.txtPropertyDesc.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 58);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Desc:";
            // 
            // txtPropertyName
            // 
            this.txtPropertyName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPropertyName.Location = new System.Drawing.Point(53, 29);
            this.txtPropertyName.Name = "txtPropertyName";
            this.txtPropertyName.Size = new System.Drawing.Size(304, 20);
            this.txtPropertyName.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Name: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbAvailableProps);
            this.groupBox4.Location = new System.Drawing.Point(3, 6);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(194, 374);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Available Properties";
            // 
            // lbAvailableProps
            // 
            this.lbAvailableProps.FormattingEnabled = true;
            this.lbAvailableProps.Location = new System.Drawing.Point(6, 19);
            this.lbAvailableProps.Name = "lbAvailableProps";
            this.lbAvailableProps.Size = new System.Drawing.Size(182, 342);
            this.lbAvailableProps.TabIndex = 0;
            this.lbAvailableProps.SelectedIndexChanged += new System.EventHandler(this.lbAvailableProps_SelectedIndexChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.dgvOutputOperations);
            this.groupBox6.Location = new System.Drawing.Point(12, 410);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(831, 253);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Output";
            // 
            // dgvOutputOperations
            // 
            this.dgvOutputOperations.AllowDrop = true;
            this.dgvOutputOperations.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            this.dgvOutputOperations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOutputOperations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOutputOperations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutputOperations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Steps,
            this.Operations});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOutputOperations.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOutputOperations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOutputOperations.Location = new System.Drawing.Point(3, 16);
            this.dgvOutputOperations.Name = "dgvOutputOperations";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvOutputOperations.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvOutputOperations.RowHeadersVisible = false;
            this.dgvOutputOperations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvOutputOperations.Size = new System.Drawing.Size(825, 234);
            this.dgvOutputOperations.TabIndex = 0;
            this.dgvOutputOperations.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dgvOutputOperations_MouseDown);
            this.dgvOutputOperations.MouseMove += new System.Windows.Forms.MouseEventHandler(this.dgvOutputOperations_MouseMove);
            this.dgvOutputOperations.DragOver += new System.Windows.Forms.DragEventHandler(this.dgvOutputOperations_DragOver);
            this.dgvOutputOperations.DragDrop += new System.Windows.Forms.DragEventHandler(this.dgvOutputOperations_DragDrop);
            // 
            // Steps
            // 
            this.Steps.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Steps.FillWeight = 10F;
            this.Steps.HeaderText = "Steps";
            this.Steps.Name = "Steps";
            // 
            // Operations
            // 
            this.Operations.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Operations.HeaderText = "Operations";
            this.Operations.Name = "Operations";
            // 
            // cmsAddPropertyMenu
            // 
            this.cmsAddPropertyMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addPropertyToolStripMenuItem,
            this.relAppdirToolStripMenuItem});
            this.cmsAddPropertyMenu.Name = "cmsAddPropertyMenu";
            this.cmsAddPropertyMenu.Size = new System.Drawing.Size(150, 48);
            // 
            // addPropertyToolStripMenuItem
            // 
            this.addPropertyToolStripMenuItem.Name = "addPropertyToolStripMenuItem";
            this.addPropertyToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.addPropertyToolStripMenuItem.Text = "Add Property";
            this.addPropertyToolStripMenuItem.Click += new System.EventHandler(this.addPropertyToolStripMenuItem_Click);
            // 
            // relAppdirToolStripMenuItem
            // 
            this.relAppdirToolStripMenuItem.Name = "relAppdirToolStripMenuItem";
            this.relAppdirToolStripMenuItem.Size = new System.Drawing.Size(149, 22);
            this.relAppdirToolStripMenuItem.Text = "Rel. Appdir";
            this.relAppdirToolStripMenuItem.Click += new System.EventHandler(this.relAppdirToolStripMenuItem_Click);
            // 
            // btnImportCi
            // 
            this.btnImportCi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnImportCi.Location = new System.Drawing.Point(519, 673);
            this.btnImportCi.Name = "btnImportCi";
            this.btnImportCi.Size = new System.Drawing.Size(174, 23);
            this.btnImportCi.TabIndex = 12;
            this.btnImportCi.Text = "Import .Ci";
            this.btnImportCi.UseVisualStyleBackColor = true;
            this.btnImportCi.Click += new System.EventHandler(this.btnImportCi_Click);
            // 
            // PackageGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 700);
            this.Controls.Add(this.btnImportCi);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnExportCi);
            this.Controls.Add(this.btnGeneratePackage);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PackageGenerator";
            this.Text = "Package Generator";
            this.Load += new System.EventHandler(this.PackageGenerator_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbParameters.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.gbProperty.ResumeLayout(false);
            this.gbProperty.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputOperations)).EndInit();
            this.cmsAddPropertyMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbAvailableFunctions;
        private System.Windows.Forms.Button btnGeneratePackage;
        private System.Windows.Forms.ListBox lbAvailableVars;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnAddVar;
        private System.Windows.Forms.Button btnSaveVar;
        private System.Windows.Forms.Button btnResetVar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVarName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVarDescription;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtDefaultValue;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboVarType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gbParameters;
        private System.Windows.Forms.Panel pnlParameters;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExportCi;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ListBox lbAvailableProps;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox gbProperty;
        private System.Windows.Forms.TextBox txtPropertyName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtPropertyDesc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPropertyValue;
        private System.Windows.Forms.Label lblPropValue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboPropertyType;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRemoveProperty;
        private System.Windows.Forms.Button btnSaveProperty;
        private System.Windows.Forms.Button btnAddProperty;
        private System.Windows.Forms.ComboBox cboPropertyValue;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.DataGridView dgvOutputOperations;
        private System.Windows.Forms.DataGridViewTextBoxColumn Steps;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operations;
        private System.Windows.Forms.ContextMenuStrip cmsAddPropertyMenu;
        private System.Windows.Forms.ToolStripMenuItem addPropertyToolStripMenuItem;
        private System.Windows.Forms.Button btnImportCi;
        private System.Windows.Forms.ToolStripMenuItem relAppdirToolStripMenuItem;
    }
}