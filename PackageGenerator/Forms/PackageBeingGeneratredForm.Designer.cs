namespace PackageGenerator.Forms {
    partial class PackageBeingGeneratredForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PackageBeingGeneratredForm));
            this.pcPackageGeneration = new Utezduyar.Windows.Forms.ProgressCircle();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pcPackageGeneration
            // 
            this.pcPackageGeneration.ForeColor = System.Drawing.Color.RoyalBlue;
            this.pcPackageGeneration.Location = new System.Drawing.Point(140, 43);
            this.pcPackageGeneration.Name = "pcPackageGeneration";
            this.pcPackageGeneration.NumberOfArcs = 12;
            this.pcPackageGeneration.NumberOfTail = 11;
            this.pcPackageGeneration.RingColor = System.Drawing.Color.White;
            this.pcPackageGeneration.RingThickness = 40;
            this.pcPackageGeneration.Size = new System.Drawing.Size(150, 150);
            this.pcPackageGeneration.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Package Generation is underway, please wait ...";
            // 
            // PackageBeingGeneratredForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 205);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pcPackageGeneration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PackageBeingGeneratredForm";
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Package Generation";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PackageBeingGeneratredForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Utezduyar.Windows.Forms.ProgressCircle pcPackageGeneration;
        private System.Windows.Forms.Label label1;
    }
}