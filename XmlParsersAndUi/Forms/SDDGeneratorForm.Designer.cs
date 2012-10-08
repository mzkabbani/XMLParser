namespace XmlParsersAndUi.Forms {
    partial class SDDGeneratorForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SDDGeneratorForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnStartOperation = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtInputFile = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gbOutput = new System.Windows.Forms.GroupBox();
            this.tcOutputForms = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tvOutputSteps = new System.Windows.Forms.TreeView();
            this.ilTreeNodes = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnExport = new System.Windows.Forms.Button();
            this.dgvOutputResults = new System.Windows.Forms.DataGridView();
            this.StepIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Operation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bwSearchReplace = new System.ComponentModel.BackgroundWorker();
            this.bwExportExcel = new System.ComponentModel.BackgroundWorker();
            this.gbInput.SuspendLayout();
            this.gbOutput.SuspendLayout();
            this.tcOutputForms.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputResults)).BeginInit();
            this.SuspendLayout();
            // 
            // gbInput
            // 
            this.gbInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbInput.Controls.Add(this.btnReset);
            this.gbInput.Controls.Add(this.btnStartOperation);
            this.gbInput.Controls.Add(this.btnBrowse);
            this.gbInput.Controls.Add(this.txtInputFile);
            this.gbInput.Controls.Add(this.label1);
            this.gbInput.Location = new System.Drawing.Point(13, 13);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(724, 100);
            this.gbInput.TabIndex = 0;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "Input Macros";
            // 
            // btnReset
            // 
            this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReset.Location = new System.Drawing.Point(365, 71);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 4;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnStartOperation
            // 
            this.btnStartOperation.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStartOperation.Location = new System.Drawing.Point(284, 71);
            this.btnStartOperation.Name = "btnStartOperation";
            this.btnStartOperation.Size = new System.Drawing.Size(75, 23);
            this.btnStartOperation.TabIndex = 3;
            this.btnStartOperation.Text = "Start";
            this.btnStartOperation.UseVisualStyleBackColor = true;
            this.btnStartOperation.Click += new System.EventHandler(this.btnStartOperation_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnBrowse.Location = new System.Drawing.Point(692, 35);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(26, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtInputFile
            // 
            this.txtInputFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInputFile.Location = new System.Drawing.Point(10, 37);
            this.txtInputFile.Name = "txtInputFile";
            this.txtInputFile.Size = new System.Drawing.Size(676, 20);
            this.txtInputFile.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Input File:";
            // 
            // gbOutput
            // 
            this.gbOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbOutput.Controls.Add(this.tcOutputForms);
            this.gbOutput.Location = new System.Drawing.Point(12, 119);
            this.gbOutput.Name = "gbOutput";
            this.gbOutput.Size = new System.Drawing.Size(725, 355);
            this.gbOutput.TabIndex = 1;
            this.gbOutput.TabStop = false;
            this.gbOutput.Text = "Output";
            // 
            // tcOutputForms
            // 
            this.tcOutputForms.Controls.Add(this.tabPage1);
            this.tcOutputForms.Controls.Add(this.tabPage2);
            this.tcOutputForms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcOutputForms.Location = new System.Drawing.Point(3, 16);
            this.tcOutputForms.Name = "tcOutputForms";
            this.tcOutputForms.SelectedIndex = 0;
            this.tcOutputForms.Size = new System.Drawing.Size(719, 336);
            this.tcOutputForms.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tvOutputSteps);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(711, 310);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Tree";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tvOutputSteps
            // 
            this.tvOutputSteps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvOutputSteps.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvOutputSteps.ImageIndex = 2;
            this.tvOutputSteps.ImageList = this.ilTreeNodes;
            this.tvOutputSteps.Location = new System.Drawing.Point(3, 3);
            this.tvOutputSteps.Name = "tvOutputSteps";
            this.tvOutputSteps.SelectedImageIndex = 2;
            this.tvOutputSteps.Size = new System.Drawing.Size(705, 304);
            this.tvOutputSteps.TabIndex = 0;
            // 
            // ilTreeNodes
            // 
            this.ilTreeNodes.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilTreeNodes.ImageStream")));
            this.ilTreeNodes.TransparentColor = System.Drawing.Color.Transparent;
            this.ilTreeNodes.Images.SetKeyName(0, "redx.skinny.vysm.gif");
            this.ilTreeNodes.Images.SetKeyName(1, "green_check.gif");
            this.ilTreeNodes.Images.SetKeyName(2, "YellowCircle.gif");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnExport);
            this.tabPage2.Controls.Add(this.dgvOutputResults);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(711, 310);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Grid";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnExport.Location = new System.Drawing.Point(318, 281);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // dgvOutputResults
            // 
            this.dgvOutputResults.AllowUserToAddRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.NavajoWhite;
            this.dgvOutputResults.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOutputResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvOutputResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutputResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StepIndex,
            this.Operation});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOutputResults.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvOutputResults.Location = new System.Drawing.Point(7, 7);
            this.dgvOutputResults.Name = "dgvOutputResults";
            this.dgvOutputResults.RowHeadersVisible = false;
            this.dgvOutputResults.Size = new System.Drawing.Size(698, 266);
            this.dgvOutputResults.TabIndex = 0;
            // 
            // StepIndex
            // 
            this.StepIndex.HeaderText = "Step";
            this.StepIndex.Name = "StepIndex";
            this.StepIndex.ReadOnly = true;
            this.StepIndex.Width = 40;
            // 
            // Operation
            // 
            this.Operation.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Operation.HeaderText = "Operation";
            this.Operation.Name = "Operation";
            this.Operation.ReadOnly = true;
            // 
            // bwSearchReplace
            // 
            this.bwSearchReplace.WorkerReportsProgress = true;
            this.bwSearchReplace.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwSearchReplace_DoWork);
            this.bwSearchReplace.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwSearchReplace_RunWorkerCompleted);
            // 
            // bwExportExcel
            // 
            this.bwExportExcel.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwExportExcel_DoWork);
            this.bwExportExcel.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwExportExcel_RunWorkerCompleted);
            // 
            // SDDGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 486);
            this.Controls.Add(this.gbOutput);
            this.Controls.Add(this.gbInput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SDDGeneratorForm";
            this.Text = "SDD Generator";
            this.Load += new System.EventHandler(this.SDDGeneratorForm_Load);
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbOutput.ResumeLayout(false);
            this.tcOutputForms.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutputResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.GroupBox gbOutput;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tcOutputForms;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView tvOutputSteps;
        private System.Windows.Forms.Button btnStartOperation;
        private System.ComponentModel.BackgroundWorker bwSearchReplace;
        private System.Windows.Forms.DataGridView dgvOutputResults;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn StepIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Operation;
        private System.ComponentModel.BackgroundWorker bwExportExcel;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.ImageList ilTreeNodes;
    }
}