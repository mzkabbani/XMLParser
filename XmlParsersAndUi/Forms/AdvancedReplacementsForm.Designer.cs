namespace XmlParsersAndUi.Forms {
    partial class AdvancedReplacementsForm {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdvancedReplacementsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvAdvancedRules = new System.Windows.Forms.ListView();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(269, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(573, 587);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Replacement Selection";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lvAdvancedRules);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(251, 587);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Used Advanced Rules";
            // 
            // lvAdvancedRules
            // 
            this.lvAdvancedRules.GridLines = true;
            this.lvAdvancedRules.Location = new System.Drawing.Point(6, 19);
            this.lvAdvancedRules.Name = "lvAdvancedRules";
            this.lvAdvancedRules.Size = new System.Drawing.Size(239, 562);
            this.lvAdvancedRules.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvAdvancedRules.TabIndex = 2;
            this.lvAdvancedRules.TileSize = new System.Drawing.Size(168, 20);
            this.lvAdvancedRules.UseCompatibleStateImageBehavior = false;
            this.lvAdvancedRules.View = System.Windows.Forms.View.Tile;
            // 
            // AdvancedReplacementsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 611);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdvancedReplacementsForm";
            this.Text = "Replacements Selection";
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView lvAdvancedRules;
    }
}