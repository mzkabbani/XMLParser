namespace XmlParsersAndUi {
    partial class FindXpathForm {
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
            this.txtXmlInput = new System.Windows.Forms.TextBox();
            this.txtXpathOut = new System.Windows.Forms.TextBox();
            this.btnFindXpath = new System.Windows.Forms.Button();
            this.txtFinder = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtXmlInput
            // 
            this.txtXmlInput.Location = new System.Drawing.Point(12, 12);
            this.txtXmlInput.MaxLength = 9999999;
            this.txtXmlInput.Multiline = true;
            this.txtXmlInput.Name = "txtXmlInput";
            this.txtXmlInput.Size = new System.Drawing.Size(540, 271);
            this.txtXmlInput.TabIndex = 0;
            // 
            // txtXpathOut
            // 
            this.txtXpathOut.Location = new System.Drawing.Point(12, 349);
            this.txtXpathOut.Multiline = true;
            this.txtXpathOut.Name = "txtXpathOut";
            this.txtXpathOut.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtXpathOut.Size = new System.Drawing.Size(540, 189);
            this.txtXpathOut.TabIndex = 1;
            // 
            // btnFindXpath
            // 
            this.btnFindXpath.Location = new System.Drawing.Point(194, 320);
            this.btnFindXpath.Name = "btnFindXpath";
            this.btnFindXpath.Size = new System.Drawing.Size(75, 23);
            this.btnFindXpath.TabIndex = 2;
            this.btnFindXpath.Text = "Find";
            this.btnFindXpath.UseVisualStyleBackColor = true;
            this.btnFindXpath.Click += new System.EventHandler(this.btnFindXpath_Click);
            // 
            // txtFinder
            // 
            this.txtFinder.Location = new System.Drawing.Point(12, 289);
            this.txtFinder.Multiline = true;
            this.txtFinder.Name = "txtFinder";
            this.txtFinder.Size = new System.Drawing.Size(540, 25);
            this.txtFinder.TabIndex = 3;
            // 
            // FindXpathForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 550);
            this.Controls.Add(this.txtFinder);
            this.Controls.Add(this.btnFindXpath);
            this.Controls.Add(this.txtXpathOut);
            this.Controls.Add(this.txtXmlInput);
            this.Name = "FindXpathForm";
            this.Text = "FindXpathForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtXmlInput;
        private System.Windows.Forms.TextBox txtXpathOut;
        private System.Windows.Forms.Button btnFindXpath;
        private System.Windows.Forms.TextBox txtFinder;
    }
}