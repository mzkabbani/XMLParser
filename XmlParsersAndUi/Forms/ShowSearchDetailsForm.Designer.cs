namespace XmlParsersAndUi.Forms {
    partial class ShowSearchDetailsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowSearchDetailsForm));
            this.pnlReplacements = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlReplacements
            // 
            this.pnlReplacements.AutoScroll = true;
            this.pnlReplacements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlReplacements.Location = new System.Drawing.Point(0, 0);
            this.pnlReplacements.Name = "pnlReplacements";
            this.pnlReplacements.Size = new System.Drawing.Size(814, 220);
            this.pnlReplacements.TabIndex = 0;
            // 
            // ShowSearchDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 220);
            this.Controls.Add(this.pnlReplacements);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(822, 800);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(822, 34);
            this.Name = "ShowSearchDetailsForm";
            this.Text = "Available Replacements";
            this.Load += new System.EventHandler(this.ShowSearchDetailsForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ShowSearchDetailsForm_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlReplacements;
    }
}