namespace XmlParsersAndUi.Forms {
    partial class AddPropertyForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPropertyForm));
            this.lbAvailableProperties = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbAvailableProperties
            // 
            this.lbAvailableProperties.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAvailableProperties.FormattingEnabled = true;
            this.lbAvailableProperties.Location = new System.Drawing.Point(0, 0);
            this.lbAvailableProperties.Name = "lbAvailableProperties";
            this.lbAvailableProperties.Size = new System.Drawing.Size(206, 264);
            this.lbAvailableProperties.TabIndex = 0;
            this.lbAvailableProperties.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbAvailableProperties_MouseDoubleClick);
            // 
            // AddPropertyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 266);
            this.Controls.Add(this.lbAvailableProperties);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPropertyForm";
            this.Text = "Available Properties";
            this.Load += new System.EventHandler(this.AddPropertyForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbAvailableProperties;
    }
}