namespace XmlParsersAndUi.Forms {
    partial class testReplacements {
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
            this.gbSearchResults = new System.Windows.Forms.GroupBox();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.objectCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numHits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pnlAvailableReplacements = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gbSearchResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSearchResults
            // 
            this.gbSearchResults.Controls.Add(this.dgvResults);
            this.gbSearchResults.Location = new System.Drawing.Point(12, 13);
            this.gbSearchResults.Name = "gbSearchResults";
            this.gbSearchResults.Size = new System.Drawing.Size(220, 574);
            this.gbSearchResults.TabIndex = 1;
            this.gbSearchResults.TabStop = false;
            this.gbSearchResults.Text = "Search Results";
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Name,
            this.objectCol,
            this.numHits});
            this.dgvResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResults.Location = new System.Drawing.Point(3, 16);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersVisible = false;
            this.dgvResults.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvResults.Size = new System.Drawing.Size(214, 555);
            this.dgvResults.TabIndex = 2;
            this.dgvResults.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dgvResults.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Name
            // 
            this.Name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Name.HeaderText = "Name";
            this.Name.Name = "Name";
            this.Name.ReadOnly = true;
            // 
            // objectCol
            // 
            this.objectCol.HeaderText = "Column1";
            this.objectCol.Name = "objectCol";
            this.objectCol.ReadOnly = true;
            this.objectCol.Visible = false;
            // 
            // numHits
            // 
            this.numHits.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.numHits.HeaderText = "Hits";
            this.numHits.Name = "numHits";
            this.numHits.ReadOnly = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pnlAvailableReplacements);
            this.groupBox2.Location = new System.Drawing.Point(239, 13);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(598, 204);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available Replacements";
            // 
            // pnlAvailableReplacements
            // 
            this.pnlAvailableReplacements.AutoScroll = true;
            this.pnlAvailableReplacements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAvailableReplacements.Location = new System.Drawing.Point(3, 16);
            this.pnlAvailableReplacements.Name = "pnlAvailableReplacements";
            this.pnlAvailableReplacements.Size = new System.Drawing.Size(592, 185);
            this.pnlAvailableReplacements.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(239, 223);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(595, 364);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Affected Files";
            // 
            // testReplacements
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 599);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbSearchResults);            
            this.Text = "testReplacements";
            this.Load += new System.EventHandler(this.testReplacements_Load);
            this.gbSearchResults.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbSearchResults;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel pnlAvailableReplacements;
        private System.Windows.Forms.DataGridViewTextBoxColumn Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn objectCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn numHits;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}