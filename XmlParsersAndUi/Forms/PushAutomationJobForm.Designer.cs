namespace XmlParsersAndUi.Forms {
    partial class PushAutomationJobForm {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbValues = new System.Windows.Forms.GroupBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tvJobParameters = new System.Windows.Forms.TreeView();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.gbValues.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gbValues);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(596, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // gbValues
            // 
            this.gbValues.Controls.Add(this.txtValue);
            this.gbValues.Controls.Add(this.lblName);
            this.gbValues.Location = new System.Drawing.Point(248, 20);
            this.gbValues.Name = "gbValues";
            this.gbValues.Size = new System.Drawing.Size(342, 280);
            this.gbValues.TabIndex = 1;
            this.gbValues.TabStop = false;
            this.gbValues.Text = "Values";
            this.gbValues.Visible = false;
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(6, 32);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(330, 20);
            this.txtValue.TabIndex = 1;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 16);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "label1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tvJobParameters);
            this.groupBox2.Location = new System.Drawing.Point(7, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(234, 281);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameters";
            // 
            // tvJobParameters
            // 
            this.tvJobParameters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvJobParameters.Location = new System.Drawing.Point(3, 16);
            this.tvJobParameters.Name = "tvJobParameters";
            this.tvJobParameters.Size = new System.Drawing.Size(228, 262);
            this.tvJobParameters.TabIndex = 0;
            this.tvJobParameters.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvJobParameters_AfterSelect);
            this.tvJobParameters.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvJobParameters_BeforeSelect);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(313, 325);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(232, 325);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            // 
            // PushAutomationJobForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 360);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.groupBox1);
            this.Name = "PushAutomationJobForm";
            this.Text = "PushAutomationJobForm";
            this.Load += new System.EventHandler(this.PushAutomationJobForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.gbValues.ResumeLayout(false);
            this.gbValues.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView tvJobParameters;
        private System.Windows.Forms.GroupBox gbValues;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label lblName;
    }
}