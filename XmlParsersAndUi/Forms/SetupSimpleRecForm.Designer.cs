namespace XmlParsersAndUi {
    partial class SetupSimpleRecForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupSimpleRecForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
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
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(737, 464);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Option Definition";
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
            this.lbOptions.SelectedIndexChanged += new System.EventHandler(this.lbOptions_SelectedIndexChanged);
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
            this.btnReloadOptions.Click += new System.EventHandler(this.btnReloadOptions_Click);
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
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
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
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
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
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // SetupSimpleRecForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 484);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SetupSimpleRecForm";
            this.Text = "Option Definition";
            this.Load += new System.EventHandler(this.SetupRecForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnReloadOptions;
        private System.Windows.Forms.TextBox txtOptionPattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsRegex;
        private System.Windows.Forms.TextBox txtOptionName;
        private System.Windows.Forms.TextBox txtOptionDesc;
        private System.Windows.Forms.TextBox txtOptionReplacement;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListBox lbOptions;
        private System.Windows.Forms.Button btnAdd;
    }
}