namespace Automation.Common.Forms {
    partial class ExceptionForm {
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnExceptionOk = new System.Windows.Forms.Button();
            this.btnSendToAdmin = new System.Windows.Forms.Button();
            this.btnMore = new System.Windows.Forms.Button();
            this.txtExceptionStack = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.txtMessage);
            this.splitContainer1.Panel1.Controls.Add(this.btnMore);
            this.splitContainer1.Panel1.Controls.Add(this.btnSendToAdmin);
            this.splitContainer1.Panel1.Controls.Add(this.btnExceptionOk);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtExceptionStack);
            this.splitContainer1.Size = new System.Drawing.Size(519, 464);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnExceptionOk
            // 
            this.btnExceptionOk.Location = new System.Drawing.Point(441, 126);
            this.btnExceptionOk.Name = "btnExceptionOk";
            this.btnExceptionOk.Size = new System.Drawing.Size(75, 23);
            this.btnExceptionOk.TabIndex = 1;
            this.btnExceptionOk.Text = "Ok";
            this.btnExceptionOk.UseVisualStyleBackColor = true;
            this.btnExceptionOk.Click += new System.EventHandler(this.btnExceptionOk_Click);
            // 
            // btnSendToAdmin
            // 
            this.btnSendToAdmin.Location = new System.Drawing.Point(360, 126);
            this.btnSendToAdmin.Name = "btnSendToAdmin";
            this.btnSendToAdmin.Size = new System.Drawing.Size(75, 23);
            this.btnSendToAdmin.TabIndex = 2;
            this.btnSendToAdmin.Text = "Send ";
            this.btnSendToAdmin.UseVisualStyleBackColor = true;
            this.btnSendToAdmin.Click += new System.EventHandler(this.btnSendToAdmin_Click);
            // 
            // btnMore
            // 
            this.btnMore.Enabled = false;
            this.btnMore.Location = new System.Drawing.Point(3, 126);
            this.btnMore.Name = "btnMore";
            this.btnMore.Size = new System.Drawing.Size(75, 23);
            this.btnMore.TabIndex = 3;
            this.btnMore.Text = "More";
            this.btnMore.UseVisualStyleBackColor = true;
            this.btnMore.Click += new System.EventHandler(this.btnMore_Click);
            // 
            // txtExceptionStack
            // 
            this.txtExceptionStack.Location = new System.Drawing.Point(3, 3);
            this.txtExceptionStack.Multiline = true;
            this.txtExceptionStack.Name = "txtExceptionStack";
            this.txtExceptionStack.ReadOnly = true;
            this.txtExceptionStack.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtExceptionStack.Size = new System.Drawing.Size(513, 302);
            this.txtExceptionStack.TabIndex = 0;
            // 
            // txtMessage
            // 
            this.txtMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.Location = new System.Drawing.Point(3, 3);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ReadOnly = true;
            this.txtMessage.Size = new System.Drawing.Size(513, 124);
            this.txtMessage.TabIndex = 4;
            this.txtMessage.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 171);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ExceptionForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " Exception";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ExceptionForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnExceptionOk;
        private System.Windows.Forms.Button btnSendToAdmin;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.TextBox txtExceptionStack;
        private System.Windows.Forms.TextBox txtMessage;
    }
}