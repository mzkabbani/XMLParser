namespace XmlParsersAndUi.Forms {
    partial class BulkMacroBuildXmlForm {
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
            this.txtBuildFileText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtBuildFileText
            // 
            this.txtBuildFileText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuildFileText.Location = new System.Drawing.Point(14, 12);
            this.txtBuildFileText.Multiline = true;
            this.txtBuildFileText.Name = "txtBuildFileText";
            this.txtBuildFileText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtBuildFileText.Size = new System.Drawing.Size(868, 526);
            this.txtBuildFileText.TabIndex = 0;
            // 
            // BulkMacroBuildXmlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 550);
            this.Controls.Add(this.txtBuildFileText);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "BulkMacroBuildXmlForm";
            this.Opacity = 0.9;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Macro Build File";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BulkMacroBuildXmlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuildFileText;
    }
}