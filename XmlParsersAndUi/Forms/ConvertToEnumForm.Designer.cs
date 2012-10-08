namespace XmlParsersAndUi.Forms {
    partial class ConvertToEnumForm {
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
            this.btnStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTable = new System.Windows.Forms.TextBox();
            this.txtEnumStringColName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEnumIntColName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtGeneratedEnum = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(54, 105);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Table: ";
            // 
            // txtTable
            // 
            this.txtTable.Location = new System.Drawing.Point(54, 27);
            this.txtTable.Name = "txtTable";
            this.txtTable.Size = new System.Drawing.Size(194, 20);
            this.txtTable.TabIndex = 2;
            this.txtTable.Text = "Application_Settings";
            // 
            // txtEnumStringColName
            // 
            this.txtEnumStringColName.Location = new System.Drawing.Point(54, 53);
            this.txtEnumStringColName.Name = "txtEnumStringColName";
            this.txtEnumStringColName.Size = new System.Drawing.Size(111, 20);
            this.txtEnumStringColName.TabIndex = 4;
            this.txtEnumStringColName.Text = "settingName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "String: ";
            // 
            // txtEnumIntColName
            // 
            this.txtEnumIntColName.Location = new System.Drawing.Point(54, 79);
            this.txtEnumIntColName.Name = "txtEnumIntColName";
            this.txtEnumIntColName.Size = new System.Drawing.Size(111, 20);
            this.txtEnumIntColName.TabIndex = 6;
            this.txtEnumIntColName.Text = "id";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Int: ";
            // 
            // txtGeneratedEnum
            // 
            this.txtGeneratedEnum.Location = new System.Drawing.Point(12, 134);
            this.txtGeneratedEnum.Multiline = true;
            this.txtGeneratedEnum.Name = "txtGeneratedEnum";
            this.txtGeneratedEnum.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtGeneratedEnum.Size = new System.Drawing.Size(654, 422);
            this.txtGeneratedEnum.TabIndex = 7;
            // 
            // ConvertToEnumForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 568);
            this.Controls.Add(this.txtGeneratedEnum);
            this.Controls.Add(this.txtEnumIntColName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtEnumStringColName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTable);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStart);
            this.Name = "ConvertToEnumForm";
            this.Text = "ConvertToEnumForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTable;
        private System.Windows.Forms.TextBox txtEnumStringColName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEnumIntColName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtGeneratedEnum;
    }
}