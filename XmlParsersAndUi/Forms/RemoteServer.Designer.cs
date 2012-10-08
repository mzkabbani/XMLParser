namespace XmlParsersAndUi.Forms {
    partial class RemoteServer {
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
            this.components = new System.ComponentModel.Container();
            this.btnTest = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGotoApp = new System.Windows.Forms.Button();
            this.lblConnected = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.txtAppdir = new System.Windows.Forms.TextBox();
            this.btnInit = new System.Windows.Forms.Button();
            this.btnLauncAll = new System.Windows.Forms.Button();
            this.txtResponse = new System.Windows.Forms.TextBox();
            this.tmReturn = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.txtShelText = new System.Windows.Forms.TextBox();
            this.btnCommit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(162, 231);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGotoApp);
            this.groupBox1.Controls.Add(this.lblConnected);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtHost);
            this.groupBox1.Controls.Add(this.txtAppdir);
            this.groupBox1.Controls.Add(this.btnInit);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(434, 103);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Configuration";
            // 
            // btnGotoApp
            // 
            this.btnGotoApp.Location = new System.Drawing.Point(133, 72);
            this.btnGotoApp.Name = "btnGotoApp";
            this.btnGotoApp.Size = new System.Drawing.Size(75, 23);
            this.btnGotoApp.TabIndex = 6;
            this.btnGotoApp.Text = "go to app";
            this.btnGotoApp.UseVisualStyleBackColor = true;
            this.btnGotoApp.Click += new System.EventHandler(this.btnGotoApp_Click);
            // 
            // lblConnected
            // 
            this.lblConnected.AutoSize = true;
            this.lblConnected.BackColor = System.Drawing.Color.Red;
            this.lblConnected.Location = new System.Drawing.Point(367, 16);
            this.lblConnected.Name = "lblConnected";
            this.lblConnected.Size = new System.Drawing.Size(59, 13);
            this.lblConnected.TabIndex = 5;
            this.lblConnected.Text = "Connected";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Appdir:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Host:";
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(52, 19);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(103, 20);
            this.txtHost.TabIndex = 2;
            // 
            // txtAppdir
            // 
            this.txtAppdir.Location = new System.Drawing.Point(52, 46);
            this.txtAppdir.Name = "txtAppdir";
            this.txtAppdir.Size = new System.Drawing.Size(368, 20);
            this.txtAppdir.TabIndex = 1;
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(52, 72);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(75, 23);
            this.btnInit.TabIndex = 0;
            this.btnInit.Text = "Init";
            this.btnInit.UseVisualStyleBackColor = true;
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnLauncAll
            // 
            this.btnLauncAll.Location = new System.Drawing.Point(13, 122);
            this.btnLauncAll.Name = "btnLauncAll";
            this.btnLauncAll.Size = new System.Drawing.Size(75, 23);
            this.btnLauncAll.TabIndex = 6;
            this.btnLauncAll.Text = "launcAll";
            this.btnLauncAll.UseVisualStyleBackColor = true;
            this.btnLauncAll.Click += new System.EventHandler(this.btnLauncAll_Click);
            // 
            // txtResponse
            // 
            this.txtResponse.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtResponse.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResponse.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txtResponse.Location = new System.Drawing.Point(12, 260);
            this.txtResponse.Multiline = true;
            this.txtResponse.Name = "txtResponse";
            this.txtResponse.ReadOnly = true;
            this.txtResponse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResponse.Size = new System.Drawing.Size(655, 284);
            this.txtResponse.TabIndex = 6;
            // 
            // tmReturn
            // 
            this.tmReturn.Interval = 10;
            this.tmReturn.Tick += new System.EventHandler(this.tmReturn_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 151);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "timer";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtShelText
            // 
            this.txtShelText.BackColor = System.Drawing.SystemColors.Window;
            this.txtShelText.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtShelText.Location = new System.Drawing.Point(12, 550);
            this.txtShelText.Name = "txtShelText";
            this.txtShelText.Size = new System.Drawing.Size(655, 20);
            this.txtShelText.TabIndex = 7;
            this.txtShelText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtShelText_KeyPress);
            // 
            // btnCommit
            // 
            this.btnCommit.Location = new System.Drawing.Point(146, 151);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(75, 23);
            this.btnCommit.TabIndex = 8;
            this.btnCommit.Text = "Commit";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // RemoteServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 574);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.txtShelText);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtResponse);
            this.Controls.Add(this.btnLauncAll);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnTest);
            this.Name = "RemoteServer";
            this.Text = "RemoteServer";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnInit;
        private System.Windows.Forms.TextBox txtAppdir;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblConnected;
        private System.Windows.Forms.Button btnLauncAll;
        private System.Windows.Forms.TextBox txtResponse;
        private System.Windows.Forms.Button btnGotoApp;
        private System.Windows.Forms.Timer tmReturn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtShelText;
        private System.Windows.Forms.Button btnCommit;
    }
}