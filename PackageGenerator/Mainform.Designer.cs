using PackageGenerator.Controls;
namespace PackageGenerator {
    partial class Mainform {
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
        /// 
        DGVColumnHeader dgvColumnHeader = new DGVColumnHeader();
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mainform));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnReloadCi = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.btnMoveRowUp = new System.Windows.Forms.Button();
            this.btnMoveRowDown = new System.Windows.Forms.Button();
            this.dgvOutputOperations = new System.Windows.Forms.DataGridView();
            this.CommentUsage = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Steps = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operations = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Key = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClear = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtFunctionComment = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.gbParameters = new System.Windows.Forms.GroupBox();
            this.pnlParameters = new System.Windows.Forms.Panel();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFunctionName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAvailableFunctions = new System.Windows.Forms.ListBox();
            this.btnGeneratePackage = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnExportFiles = new System.Windows.Forms.Button();
            this.dgvFilesToImport = new System.Windows.Forms.DataGridView();
            this.relativePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileLink = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnImportFileList = new System.Windows.Forms.Button();
            this.btnResetFileToImport = new System.Windows.Forms.Button();
            this.btnRemoveFileToImport = new System.Windows.Forms.Button();
            this.btnAddFileToImport = new System.Windows.Forms.Button();
            this.txtRelativePathToImport = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.btnSaveFileToImport = new System.Windows.Forms.Button();
            this.txtImportFileLink = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lbAvailableProps = new System.Windows.Forms.ListBox();
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
            this.cmsCommentSelection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.selectGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsAddPropertyMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addPropertyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relAppdirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msMainMenu = new System.Windows.Forms.MenuStrip();
            this.packagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generatePackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.publishPackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compareCustomizationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.iToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportPackageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCustomizationLogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bwPackageGenerator = new System.ComponentModel.BackgroundWorker();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bwExcelExporter = new System.ComponentModel.BackgroundWorker();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputOperations)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbParameters.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilesToImport)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.gbProperty.SuspendLayout();
            this.cmsCommentSelection.SuspendLayout();
            this.cmsAddPropertyMenu.SuspendLayout();
            this.msMainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.ItemSize = new System.Drawing.Size(100, 18);
            this.tabControl1.Location = new System.Drawing.Point(12, 27);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1001, 788);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnReloadCi);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.btnClear);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.btnGeneratePackage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(993, 762);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Functions";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnReloadCi
            // 
            this.btnReloadCi.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnReloadCi.Enabled = false;
            this.btnReloadCi.Location = new System.Drawing.Point(427, 732);
            this.btnReloadCi.Name = "btnReloadCi";
            this.btnReloadCi.Size = new System.Drawing.Size(139, 23);
            this.btnReloadCi.TabIndex = 3;
            this.btnReloadCi.Text = "Reload Ci";
            this.btnReloadCi.UseVisualStyleBackColor = true;
            this.btnReloadCi.Click += new System.EventHandler(this.btnReloadCi_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.BackColor = System.Drawing.Color.Transparent;
            this.groupBox6.Controls.Add(this.btnMoveRowUp);
            this.groupBox6.Controls.Add(this.btnMoveRowDown);
            this.groupBox6.Controls.Add(this.dgvOutputOperations);
            this.groupBox6.Location = new System.Drawing.Point(6, 435);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(977, 290);
            this.groupBox6.TabIndex = 8;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Output";
            // 
            // btnMoveRowUp
            // 
            this.btnMoveRowUp.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMoveRowUp.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveRowUp.Image")));
            this.btnMoveRowUp.Location = new System.Drawing.Point(938, 73);
            this.btnMoveRowUp.Name = "btnMoveRowUp";
            this.btnMoveRowUp.Size = new System.Drawing.Size(32, 68);
            this.btnMoveRowUp.TabIndex = 1;
            this.btnMoveRowUp.TabStop = false;
            this.btnMoveRowUp.UseVisualStyleBackColor = true;
            this.btnMoveRowUp.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnMoveRowDown
            // 
            this.btnMoveRowDown.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnMoveRowDown.Image = ((System.Drawing.Image)(resources.GetObject("btnMoveRowDown.Image")));
            this.btnMoveRowDown.Location = new System.Drawing.Point(938, 147);
            this.btnMoveRowDown.Name = "btnMoveRowDown";
            this.btnMoveRowDown.Size = new System.Drawing.Size(32, 68);
            this.btnMoveRowDown.TabIndex = 2;
            this.btnMoveRowDown.TabStop = false;
            this.btnMoveRowDown.UseVisualStyleBackColor = true;
            this.btnMoveRowDown.Click += new System.EventHandler(this.btnMoveRowDown_Click);
            // 
            // dgvOutputOperations
            // 
            this.dgvOutputOperations.AllowDrop = true;
            this.dgvOutputOperations.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            this.dgvOutputOperations.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOutputOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOutputOperations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
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
            this.CommentUsage,
            this.Steps,
            this.Operations,
            this.Key,
            this.Comment});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOutputOperations.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvOutputOperations.Location = new System.Drawing.Point(6, 19);
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
            this.dgvOutputOperations.Size = new System.Drawing.Size(927, 268);
            this.dgvOutputOperations.TabIndex = 0;
            this.dgvOutputOperations.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvOutputOperations_ColumnHeaderMouseClick);
            this.dgvOutputOperations.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutputOperations_CellContentClick);
            this.dgvOutputOperations.SelectionChanged += new System.EventHandler(this.dgvOutputOperations_SelectionChanged);
            this.dgvOutputOperations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOutputOperations_CellContentClick);
            // 
            // CommentUsage
            // 
            this.CommentUsage.FillWeight = 10F;
            this.CommentUsage.HeaderText = "Comment";
            this.CommentUsage.Name = "CommentUsage";
            this.CommentUsage.Width = 80;
            // 
            // Steps
            // 
            this.Steps.FillWeight = 10F;
            this.Steps.HeaderText = "Steps";
            this.Steps.Name = "Steps";
            this.Steps.ReadOnly = true;
            this.Steps.Width = 70;
            // 
            // Operations
            // 
            this.Operations.HeaderText = "Operations";
            this.Operations.Name = "Operations";
            this.Operations.ReadOnly = true;
            this.Operations.Width = 1020;
            // 
            // Key
            // 
            this.Key.HeaderText = "Key";
            this.Key.Name = "Key";
            this.Key.Visible = false;
            // 
            // Comment
            // 
            this.Comment.HeaderText = "Comment";
            this.Comment.Name = "Comment";
            this.Comment.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClear.Location = new System.Drawing.Point(572, 732);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(139, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear All";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txtFunctionComment);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnAdd);
            this.groupBox2.Controls.Add(this.gbParameters);
            this.groupBox2.Controls.Add(this.txtDescription);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtFunctionName);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(235, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(750, 422);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Function Configurations";
            // 
            // txtFunctionComment
            // 
            this.txtFunctionComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFunctionComment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFunctionComment.Location = new System.Drawing.Point(79, 116);
            this.txtFunctionComment.Multiline = true;
            this.txtFunctionComment.Name = "txtFunctionComment";
            this.txtFunctionComment.Size = new System.Drawing.Size(665, 67);
            this.txtFunctionComment.TabIndex = 2;
            this.txtFunctionComment.Text = "Add comment here...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Comment:";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(378, 390);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(139, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(233, 390);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(139, 23);
            this.btnAdd.TabIndex = 3;
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
            this.gbParameters.Location = new System.Drawing.Point(7, 197);
            this.gbParameters.Name = "gbParameters";
            this.gbParameters.Size = new System.Drawing.Size(737, 187);
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
            this.pnlParameters.Size = new System.Drawing.Size(731, 168);
            this.pnlParameters.TabIndex = 0;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescription.Location = new System.Drawing.Point(79, 43);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(665, 67);
            this.txtDescription.TabIndex = 1;
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
            this.txtFunctionName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFunctionName.Location = new System.Drawing.Point(79, 17);
            this.txtFunctionName.Name = "txtFunctionName";
            this.txtFunctionName.ReadOnly = true;
            this.txtFunctionName.Size = new System.Drawing.Size(478, 20);
            this.txtFunctionName.TabIndex = 0;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAvailableFunctions);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(223, 422);
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
            this.lbAvailableFunctions.Size = new System.Drawing.Size(210, 394);
            this.lbAvailableFunctions.Sorted = true;
            this.lbAvailableFunctions.TabIndex = 0;
            this.lbAvailableFunctions.SelectedIndexChanged += new System.EventHandler(this.lbAvailableFunctions_SelectedIndexChanged);
            // 
            // btnGeneratePackage
            // 
            this.btnGeneratePackage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGeneratePackage.Location = new System.Drawing.Point(282, 732);
            this.btnGeneratePackage.Name = "btnGeneratePackage";
            this.btnGeneratePackage.Size = new System.Drawing.Size(139, 23);
            this.btnGeneratePackage.TabIndex = 0;
            this.btnGeneratePackage.Text = "Generate Package";
            this.btnGeneratePackage.UseVisualStyleBackColor = true;
            this.btnGeneratePackage.Click += new System.EventHandler(this.btnGeneratePackage_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox7);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(993, 762);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Configuration";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox7.Controls.Add(this.btnExportFiles);
            this.groupBox7.Controls.Add(this.dgvFilesToImport);
            this.groupBox7.Controls.Add(this.btnImportFileList);
            this.groupBox7.Controls.Add(this.btnResetFileToImport);
            this.groupBox7.Controls.Add(this.btnRemoveFileToImport);
            this.groupBox7.Controls.Add(this.btnAddFileToImport);
            this.groupBox7.Controls.Add(this.txtRelativePathToImport);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.btnSaveFileToImport);
            this.groupBox7.Controls.Add(this.txtImportFileLink);
            this.groupBox7.Controls.Add(this.label11);
            this.groupBox7.Location = new System.Drawing.Point(9, 262);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(976, 492);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "File Import";
            // 
            // btnExportFiles
            // 
            this.btnExportFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportFiles.Location = new System.Drawing.Point(868, 162);
            this.btnExportFiles.Name = "btnExportFiles";
            this.btnExportFiles.Size = new System.Drawing.Size(102, 23);
            this.btnExportFiles.TabIndex = 8;
            this.btnExportFiles.Text = "Export File List";
            this.btnExportFiles.UseVisualStyleBackColor = true;
            this.btnExportFiles.Click += new System.EventHandler(this.btnExportFiles_Click);
            // 
            // dgvFilesToImport
            // 
            this.dgvFilesToImport.AllowUserToAddRows = false;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.LemonChiffon;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFilesToImport.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvFilesToImport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFilesToImport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvFilesToImport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilesToImport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.relativePath,
            this.fileLink});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFilesToImport.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgvFilesToImport.Location = new System.Drawing.Point(11, 77);
            this.dgvFilesToImport.MultiSelect = false;
            this.dgvFilesToImport.Name = "dgvFilesToImport";
            this.dgvFilesToImport.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFilesToImport.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgvFilesToImport.RowHeadersVisible = false;
            this.dgvFilesToImport.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvFilesToImport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFilesToImport.Size = new System.Drawing.Size(851, 409);
            this.dgvFilesToImport.TabIndex = 2;
            this.dgvFilesToImport.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilesToImport_CellContentClick);
            this.dgvFilesToImport.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvFilesToImport_CellContentClick);
            // 
            // relativePath
            // 
            this.relativePath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.relativePath.HeaderText = "Relative Path";
            this.relativePath.Name = "relativePath";
            this.relativePath.ReadOnly = true;
            // 
            // fileLink
            // 
            this.fileLink.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fileLink.HeaderText = "File Link";
            this.fileLink.Name = "fileLink";
            this.fileLink.ReadOnly = true;
            // 
            // btnImportFileList
            // 
            this.btnImportFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImportFileList.Location = new System.Drawing.Point(868, 133);
            this.btnImportFileList.Name = "btnImportFileList";
            this.btnImportFileList.Size = new System.Drawing.Size(102, 23);
            this.btnImportFileList.TabIndex = 7;
            this.btnImportFileList.Text = "Import File List";
            this.btnImportFileList.UseVisualStyleBackColor = true;
            this.btnImportFileList.Click += new System.EventHandler(this.btnImportFileList_Click);
            // 
            // btnResetFileToImport
            // 
            this.btnResetFileToImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetFileToImport.Location = new System.Drawing.Point(868, 104);
            this.btnResetFileToImport.Name = "btnResetFileToImport";
            this.btnResetFileToImport.Size = new System.Drawing.Size(102, 23);
            this.btnResetFileToImport.TabIndex = 6;
            this.btnResetFileToImport.Text = "Reset";
            this.btnResetFileToImport.UseVisualStyleBackColor = true;
            this.btnResetFileToImport.Click += new System.EventHandler(this.btnResetFileToImport_Click);
            // 
            // btnRemoveFileToImport
            // 
            this.btnRemoveFileToImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFileToImport.Location = new System.Drawing.Point(868, 75);
            this.btnRemoveFileToImport.Name = "btnRemoveFileToImport";
            this.btnRemoveFileToImport.Size = new System.Drawing.Size(102, 23);
            this.btnRemoveFileToImport.TabIndex = 5;
            this.btnRemoveFileToImport.Text = "Remove";
            this.btnRemoveFileToImport.UseVisualStyleBackColor = true;
            this.btnRemoveFileToImport.Click += new System.EventHandler(this.btnDelteFileToImport_Click);
            // 
            // btnAddFileToImport
            // 
            this.btnAddFileToImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFileToImport.Location = new System.Drawing.Point(868, 17);
            this.btnAddFileToImport.Name = "btnAddFileToImport";
            this.btnAddFileToImport.Size = new System.Drawing.Size(102, 23);
            this.btnAddFileToImport.TabIndex = 3;
            this.btnAddFileToImport.Text = "Add";
            this.btnAddFileToImport.UseVisualStyleBackColor = true;
            this.btnAddFileToImport.Click += new System.EventHandler(this.btnAddFileToImport_Click);
            // 
            // txtRelativePathToImport
            // 
            this.txtRelativePathToImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRelativePathToImport.Location = new System.Drawing.Point(90, 45);
            this.txtRelativePathToImport.Name = "txtRelativePathToImport";
            this.txtRelativePathToImport.Size = new System.Drawing.Size(772, 20);
            this.txtRelativePathToImport.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(74, 13);
            this.label13.TabIndex = 15;
            this.label13.Text = "Relative Path:";
            // 
            // btnSaveFileToImport
            // 
            this.btnSaveFileToImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveFileToImport.Enabled = false;
            this.btnSaveFileToImport.Location = new System.Drawing.Point(868, 46);
            this.btnSaveFileToImport.Name = "btnSaveFileToImport";
            this.btnSaveFileToImport.Size = new System.Drawing.Size(102, 23);
            this.btnSaveFileToImport.TabIndex = 4;
            this.btnSaveFileToImport.Text = "Save";
            this.btnSaveFileToImport.UseVisualStyleBackColor = true;
            this.btnSaveFileToImport.Click += new System.EventHandler(this.btnSaveFileToImport_Click);
            // 
            // txtImportFileLink
            // 
            this.txtImportFileLink.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportFileLink.Location = new System.Drawing.Point(90, 19);
            this.txtImportFileLink.Name = "txtImportFileLink";
            this.txtImportFileLink.Size = new System.Drawing.Size(772, 20);
            this.txtImportFileLink.TabIndex = 0;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(49, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "File Link:";
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.gbProperty);
            this.groupBox3.Location = new System.Drawing.Point(8, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(977, 250);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Properties";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lbAvailableProps);
            this.groupBox4.Location = new System.Drawing.Point(6, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(194, 213);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Available Properties";
            // 
            // lbAvailableProps
            // 
            this.lbAvailableProps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbAvailableProps.FormattingEnabled = true;
            this.lbAvailableProps.Location = new System.Drawing.Point(6, 19);
            this.lbAvailableProps.Name = "lbAvailableProps";
            this.lbAvailableProps.Size = new System.Drawing.Size(182, 186);
            this.lbAvailableProps.TabIndex = 0;
            this.lbAvailableProps.Click += new System.EventHandler(this.lbAvailableProps_SelectedIndexChanged);
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
            this.gbProperty.Location = new System.Drawing.Point(206, 22);
            this.gbProperty.Name = "gbProperty";
            this.gbProperty.Size = new System.Drawing.Size(765, 210);
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
            this.cboPropertyValue.Size = new System.Drawing.Size(263, 21);
            this.cboPropertyValue.TabIndex = 3;
            this.cboPropertyValue.Visible = false;
            // 
            // btnReset
            // 
            this.btnReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReset.Location = new System.Drawing.Point(657, 114);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(102, 23);
            this.btnReset.TabIndex = 8;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnRemoveProperty
            // 
            this.btnRemoveProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveProperty.Location = new System.Drawing.Point(657, 85);
            this.btnRemoveProperty.Name = "btnRemoveProperty";
            this.btnRemoveProperty.Size = new System.Drawing.Size(102, 23);
            this.btnRemoveProperty.TabIndex = 7;
            this.btnRemoveProperty.Text = "Remove";
            this.btnRemoveProperty.UseVisualStyleBackColor = true;
            this.btnRemoveProperty.Click += new System.EventHandler(this.btnRemoveProperty_Click);
            // 
            // btnSaveProperty
            // 
            this.btnSaveProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveProperty.Location = new System.Drawing.Point(657, 56);
            this.btnSaveProperty.Name = "btnSaveProperty";
            this.btnSaveProperty.Size = new System.Drawing.Size(102, 23);
            this.btnSaveProperty.TabIndex = 6;
            this.btnSaveProperty.Text = "Save";
            this.btnSaveProperty.UseVisualStyleBackColor = true;
            this.btnSaveProperty.Click += new System.EventHandler(this.btnSaveProperty_Click);
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddProperty.Location = new System.Drawing.Point(657, 27);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(102, 23);
            this.btnAddProperty.TabIndex = 5;
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
            this.cboPropertyType.Location = new System.Drawing.Point(53, 151);
            this.cboPropertyType.Name = "cboPropertyType";
            this.cboPropertyType.Size = new System.Drawing.Size(263, 21);
            this.cboPropertyType.TabIndex = 2;
            this.cboPropertyType.SelectedIndexChanged += new System.EventHandler(this.cboPropertyType_SelectedIndexChanged);
            // 
            // txtPropertyValue
            // 
            this.txtPropertyValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPropertyValue.Location = new System.Drawing.Point(53, 178);
            this.txtPropertyValue.Name = "txtPropertyValue";
            this.txtPropertyValue.Size = new System.Drawing.Size(365, 20);
            this.txtPropertyValue.TabIndex = 4;
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
            this.txtPropertyDesc.Size = new System.Drawing.Size(598, 87);
            this.txtPropertyDesc.TabIndex = 1;
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
            this.txtPropertyName.Size = new System.Drawing.Size(598, 20);
            this.txtPropertyName.TabIndex = 0;
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
            // cmsCommentSelection
            // 
            this.cmsCommentSelection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectGroupToolStripMenuItem});
            this.cmsCommentSelection.Name = "cmsCommentSelection";
            this.cmsCommentSelection.Size = new System.Drawing.Size(147, 26);
            // 
            // selectGroupToolStripMenuItem
            // 
            this.selectGroupToolStripMenuItem.Name = "selectGroupToolStripMenuItem";
            this.selectGroupToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.selectGroupToolStripMenuItem.Text = "Check Group";
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
            // msMainMenu
            // 
            this.msMainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.packagesToolStripMenuItem,
            this.importExportToolStripMenuItem});
            this.msMainMenu.Location = new System.Drawing.Point(0, 0);
            this.msMainMenu.Name = "msMainMenu";
            this.msMainMenu.Size = new System.Drawing.Size(1025, 24);
            this.msMainMenu.TabIndex = 14;
            this.msMainMenu.Text = "menuStrip1";
            // 
            // packagesToolStripMenuItem
            // 
            this.packagesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.generatePackageToolStripMenuItem,
            this.publishPackageToolStripMenuItem,
            this.compareCustomizationsToolStripMenuItem});
            this.packagesToolStripMenuItem.Name = "packagesToolStripMenuItem";
            this.packagesToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.packagesToolStripMenuItem.Text = "Packages";
            // 
            // generatePackageToolStripMenuItem
            // 
            this.generatePackageToolStripMenuItem.Name = "generatePackageToolStripMenuItem";
            this.generatePackageToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.generatePackageToolStripMenuItem.Text = "Generate Package";
            this.generatePackageToolStripMenuItem.Click += new System.EventHandler(this.btnGeneratePackage_Click);
            // 
            // publishPackageToolStripMenuItem
            // 
            this.publishPackageToolStripMenuItem.Name = "publishPackageToolStripMenuItem";
            this.publishPackageToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.publishPackageToolStripMenuItem.Text = "Publish Customizations";
            this.publishPackageToolStripMenuItem.Click += new System.EventHandler(this.publishPackageToolStripMenuItem_Click);
            // 
            // compareCustomizationsToolStripMenuItem
            // 
            this.compareCustomizationsToolStripMenuItem.Name = "compareCustomizationsToolStripMenuItem";
            this.compareCustomizationsToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.compareCustomizationsToolStripMenuItem.Text = "Compare Customizations";
            this.compareCustomizationsToolStripMenuItem.Click += new System.EventHandler(this.compareCustomizationsToolStripMenuItem_Click);
            // 
            // importExportToolStripMenuItem
            // 
            this.importExportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iToolStripMenuItem,
            this.exportPackageToolStripMenuItem,
            this.exportCustomizationLogToolStripMenuItem});
            this.importExportToolStripMenuItem.Name = "importExportToolStripMenuItem";
            this.importExportToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.importExportToolStripMenuItem.Text = "Import\\Export";
            // 
            // iToolStripMenuItem
            // 
            this.iToolStripMenuItem.Name = "iToolStripMenuItem";
            this.iToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.iToolStripMenuItem.Text = "Import Package";
            this.iToolStripMenuItem.Click += new System.EventHandler(this.btnImportCi_Click);
            // 
            // exportPackageToolStripMenuItem
            // 
            this.exportPackageToolStripMenuItem.Name = "exportPackageToolStripMenuItem";
            this.exportPackageToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.exportPackageToolStripMenuItem.Text = "Export Package";
            this.exportPackageToolStripMenuItem.Click += new System.EventHandler(this.btnExportCi_Click);
            // 
            // exportCustomizationLogToolStripMenuItem
            // 
            this.exportCustomizationLogToolStripMenuItem.Name = "exportCustomizationLogToolStripMenuItem";
            this.exportCustomizationLogToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.exportCustomizationLogToolStripMenuItem.Text = "Export Customizations Log";
            this.exportCustomizationLogToolStripMenuItem.Click += new System.EventHandler(this.exportCustomizationLogToolStripMenuItem_Click);
            // 
            // bwPackageGenerator
            // 
            this.bwPackageGenerator.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwPackageGenerator_DoWork);
            this.bwPackageGenerator.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwPackageGenerator_RunWorkerCompleted);
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.ContextMenuStrip = this.cmsCommentSelection;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle9.NullValue = false;
            this.dataGridViewCheckBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridViewCheckBoxColumn1.FillWeight = 10F;
            this.dataGridViewCheckBoxColumn1.HeaderText = "Comment";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle10;
            this.dataGridViewTextBoxColumn1.FillWeight = 10F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Steps";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 70;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Operations";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 1020;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Key";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "Comment";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.Visible = false;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.HeaderText = "Relative Path";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn6.HeaderText = "File Link";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // bwExcelExporter
            // 
            this.bwExcelExporter.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwExcelExporter_DoWork);
            this.bwExcelExporter.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwExcelExporter_RunWorkerCompleted);
            // 
            // Mainform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1025, 827);
            this.Controls.Add(this.msMainMenu);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Mainform";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Package Generator";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Mainform_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputOperations)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbParameters.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilesToImport)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.gbProperty.ResumeLayout(false);
            this.gbProperty.PerformLayout();
            this.cmsCommentSelection.ResumeLayout(false);
            this.cmsAddPropertyMenu.ResumeLayout(false);
            this.msMainMenu.ResumeLayout(false);
            this.msMainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnReloadCi;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button btnMoveRowUp;
        private System.Windows.Forms.Button btnMoveRowDown;
        private System.Windows.Forms.DataGridView dgvOutputOperations;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox gbParameters;
        private System.Windows.Forms.Panel pnlParameters;
        private System.Windows.Forms.TextBox txtFunctionName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbAvailableFunctions;
        private System.Windows.Forms.Button btnGeneratePackage;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lbAvailableProps;
        private System.Windows.Forms.GroupBox gbProperty;
        private System.Windows.Forms.ComboBox cboPropertyValue;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnRemoveProperty;
        private System.Windows.Forms.Button btnSaveProperty;
        private System.Windows.Forms.Button btnAddProperty;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboPropertyType;
        private System.Windows.Forms.TextBox txtPropertyValue;
        private System.Windows.Forms.Label lblPropValue;
        private System.Windows.Forms.TextBox txtPropertyDesc;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPropertyName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ContextMenuStrip cmsAddPropertyMenu;
        private System.Windows.Forms.ToolStripMenuItem addPropertyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relAppdirToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.DataGridView dgvFilesToImport;
        private System.Windows.Forms.DataGridViewTextBoxColumn relativePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileLink;
        private System.Windows.Forms.Button btnImportFileList;
        private System.Windows.Forms.Button btnResetFileToImport;
        private System.Windows.Forms.Button btnRemoveFileToImport;
        private System.Windows.Forms.Button btnAddFileToImport;
        private System.Windows.Forms.TextBox txtRelativePathToImport;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnSaveFileToImport;
        private System.Windows.Forms.TextBox txtImportFileLink;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnExportFiles;
        private System.Windows.Forms.TextBox txtFunctionComment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MenuStrip msMainMenu;
        private System.Windows.Forms.ToolStripMenuItem packagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generatePackageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem iToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportPackageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportCustomizationLogToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip cmsCommentSelection;
        private System.Windows.Forms.ToolStripMenuItem selectGroupToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.ToolStripMenuItem publishPackageToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CommentUsage;
        private System.Windows.Forms.DataGridViewTextBoxColumn Steps;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operations;
        private System.Windows.Forms.DataGridViewTextBoxColumn Key;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.ToolStripMenuItem compareCustomizationsToolStripMenuItem;
        private System.ComponentModel.BackgroundWorker bwPackageGenerator;
        private System.ComponentModel.BackgroundWorker bwExcelExporter;

        
    }
}