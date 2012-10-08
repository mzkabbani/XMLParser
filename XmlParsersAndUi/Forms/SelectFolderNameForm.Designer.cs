namespace XmlParsersAndUi.Forms {
    partial class SelectFolderNameForm {
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
        	this.tvOperationNames = new System.Windows.Forms.TreeView();
        	this.SuspendLayout();
        	// 
        	// tvOperationNames
        	// 
        	this.tvOperationNames.Dock = System.Windows.Forms.DockStyle.Fill;
        	this.tvOperationNames.Location = new System.Drawing.Point(0, 0);
        	this.tvOperationNames.Name = "tvOperationNames";
        	this.tvOperationNames.Size = new System.Drawing.Size(195, 267);
        	this.tvOperationNames.TabIndex = 0;
        	this.tvOperationNames.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFolderNames_NodeMouseDoubleClick);
        	this.tvOperationNames.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TvOperationNamesKeyPress);
        	// 
        	// SelectFolderNameForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(195, 267);
        	this.Controls.Add(this.tvOperationNames);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        	this.Name = "SelectFolderNameForm";
        	this.ShowIcon = false;
        	this.ShowInTaskbar = false;
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "Select Operation";
        	this.TopMost = true;
        	this.Load += new System.EventHandler(this.SelectFolderNameForm_Load);
        	this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SelectFolderNameFormKeyPress);
        	this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TreeView tvOperationNames;
    }
}