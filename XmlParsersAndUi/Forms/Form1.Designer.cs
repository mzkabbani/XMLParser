namespace XmlParsersAndUi {
    partial class Form1 {
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
        	System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem("item1");
        	this.txtOutput = new System.Windows.Forms.TextBox();
        	this.lvItems = new System.Windows.Forms.ListView();
        	this.txtInputFile = new System.Windows.Forms.TextBox();
        	this.btnParse = new System.Windows.Forms.Button();
        	this.tvOutput = new System.Windows.Forms.TreeView();
        	this.btnPopulateTV = new System.Windows.Forms.Button();
        	this.grpBoxAttr = new System.Windows.Forms.GroupBox();
        	this.button3 = new System.Windows.Forms.Button();
        	this.txtEventIn = new System.Windows.Forms.TextBox();
        	this.btnParseEvent = new System.Windows.Forms.Button();
        	this.gbChildren = new System.Windows.Forms.GroupBox();
        	this.cmbMain = new System.Windows.Forms.ComboBox();
        	this.button1 = new System.Windows.Forms.Button();
        	this.button2 = new System.Windows.Forms.Button();
        	this.btnAdd32Customs = new System.Windows.Forms.Button();
        	this.button4 = new System.Windows.Forms.Button();
        	this.btnUpdateConfig = new System.Windows.Forms.Button();
        	this.button5 = new System.Windows.Forms.Button();
        	this.txtConfi = new System.Windows.Forms.TextBox();
        	this.button6 = new System.Windows.Forms.Button();
        	this.btnUtilsParser = new System.Windows.Forms.Button();
        	this.txtConnx = new System.Windows.Forms.TextBox();
        	this.btnTestConn = new System.Windows.Forms.Button();
        	this.grpBoxAttr.SuspendLayout();
        	this.gbChildren.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// txtOutput
        	// 
        	this.txtOutput.AllowDrop = true;
        	this.txtOutput.Location = new System.Drawing.Point(728, 244);
        	this.txtOutput.Multiline = true;
        	this.txtOutput.Name = "txtOutput";
        	this.txtOutput.Size = new System.Drawing.Size(65, 306);
        	this.txtOutput.TabIndex = 0;
        	this.txtOutput.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtOutput_DragDrop);
        	this.txtOutput.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtOutput_DragEnter);
        	// 
        	// lvItems
        	// 
        	this.lvItems.Activation = System.Windows.Forms.ItemActivation.OneClick;
        	this.lvItems.AllowColumnReorder = true;
        	this.lvItems.AllowDrop = true;
        	this.lvItems.FullRowSelect = true;
        	this.lvItems.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
        	        	        	listViewItem2});
        	this.lvItems.Location = new System.Drawing.Point(605, 262);
        	this.lvItems.Name = "lvItems";
        	this.lvItems.Size = new System.Drawing.Size(107, 288);
        	this.lvItems.TabIndex = 1;
        	this.lvItems.UseCompatibleStateImageBehavior = false;
        	this.lvItems.View = System.Windows.Forms.View.List;
        	this.lvItems.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.lvItems_ItemDrag);
        	this.lvItems.SelectedIndexChanged += new System.EventHandler(this.lvItems_SelectedIndexChanged);
        	this.lvItems.DragOver += new System.Windows.Forms.DragEventHandler(this.lvItems_DragOver);
        	this.lvItems.DragLeave += new System.EventHandler(this.lvItems_DragLeave);
        	this.lvItems.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvItems_MouseDown);
        	// 
        	// txtInputFile
        	// 
        	this.txtInputFile.Location = new System.Drawing.Point(12, 12);
        	this.txtInputFile.Name = "txtInputFile";
        	this.txtInputFile.Size = new System.Drawing.Size(334, 20);
        	this.txtInputFile.TabIndex = 2;
        	this.txtInputFile.Text = "D:\\output.txt";
        	// 
        	// btnParse
        	// 
        	this.btnParse.Location = new System.Drawing.Point(352, 9);
        	this.btnParse.Name = "btnParse";
        	this.btnParse.Size = new System.Drawing.Size(75, 23);
        	this.btnParse.TabIndex = 3;
        	this.btnParse.Text = "Parse File";
        	this.btnParse.UseVisualStyleBackColor = true;
        	this.btnParse.Click += new System.EventHandler(this.button3_Click);
        	// 
        	// tvOutput
        	// 
        	this.tvOutput.CheckBoxes = true;
        	this.tvOutput.Location = new System.Drawing.Point(6, 56);
        	this.tvOutput.Name = "tvOutput";
        	this.tvOutput.Size = new System.Drawing.Size(230, 102);
        	this.tvOutput.TabIndex = 4;
        	this.tvOutput.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvOutput_AfterSelect);
        	// 
        	// btnPopulateTV
        	// 
        	this.btnPopulateTV.Location = new System.Drawing.Point(15, 80);
        	this.btnPopulateTV.Name = "btnPopulateTV";
        	this.btnPopulateTV.Size = new System.Drawing.Size(75, 26);
        	this.btnPopulateTV.TabIndex = 5;
        	this.btnPopulateTV.Text = "Populate";
        	this.btnPopulateTV.UseVisualStyleBackColor = true;
        	this.btnPopulateTV.Click += new System.EventHandler(this.btnPopulateTV_Click);
        	// 
        	// grpBoxAttr
        	// 
        	this.grpBoxAttr.Controls.Add(this.button3);
        	this.grpBoxAttr.Controls.Add(this.tvOutput);
        	this.grpBoxAttr.Location = new System.Drawing.Point(250, 112);
        	this.grpBoxAttr.Name = "grpBoxAttr";
        	this.grpBoxAttr.Size = new System.Drawing.Size(276, 183);
        	this.grpBoxAttr.TabIndex = 6;
        	this.grpBoxAttr.TabStop = false;
        	this.grpBoxAttr.Text = "Attributes";
        	// 
        	// button3
        	// 
        	this.button3.Location = new System.Drawing.Point(6, 19);
        	this.button3.Name = "button3";
        	this.button3.Size = new System.Drawing.Size(130, 23);
        	this.button3.TabIndex = 13;
        	this.button3.Text = "Extract Addops";
        	this.button3.UseVisualStyleBackColor = true;
        	this.button3.Click += new System.EventHandler(this.button3_Click);
        	// 
        	// txtEventIn
        	// 
        	this.txtEventIn.Location = new System.Drawing.Point(561, 109);
        	this.txtEventIn.Multiline = true;
        	this.txtEventIn.Name = "txtEventIn";
        	this.txtEventIn.Size = new System.Drawing.Size(215, 112);
        	this.txtEventIn.TabIndex = 7;
        	// 
        	// btnParseEvent
        	// 
        	this.btnParseEvent.Location = new System.Drawing.Point(591, 227);
        	this.btnParseEvent.Name = "btnParseEvent";
        	this.btnParseEvent.Size = new System.Drawing.Size(75, 23);
        	this.btnParseEvent.TabIndex = 8;
        	this.btnParseEvent.Text = "P Event";
        	this.btnParseEvent.UseVisualStyleBackColor = true;
        	this.btnParseEvent.Click += new System.EventHandler(this.btnParseEvent_Click);
        	// 
        	// gbChildren
        	// 
        	this.gbChildren.Controls.Add(this.btnTestConn);
        	this.gbChildren.Controls.Add(this.txtConnx);
        	this.gbChildren.Location = new System.Drawing.Point(13, 432);
        	this.gbChildren.Name = "gbChildren";
        	this.gbChildren.Size = new System.Drawing.Size(636, 229);
        	this.gbChildren.TabIndex = 9;
        	this.gbChildren.TabStop = false;
        	this.gbChildren.Text = "Children";
        	// 
        	// cmbMain
        	// 
        	this.cmbMain.FormattingEnabled = true;
        	this.cmbMain.Items.AddRange(new object[] {
        	        	        	"AvailableTests"});
        	this.cmbMain.Location = new System.Drawing.Point(340, 83);
        	this.cmbMain.Name = "cmbMain";
        	this.cmbMain.Size = new System.Drawing.Size(121, 21);
        	this.cmbMain.TabIndex = 0;
        	this.cmbMain.SelectedIndexChanged += new System.EventHandler(this.cmbMain_SelectedIndexChanged);
        	// 
        	// button1
        	// 
        	this.button1.Location = new System.Drawing.Point(200, 83);
        	this.button1.Name = "button1";
        	this.button1.Size = new System.Drawing.Size(119, 23);
        	this.button1.TabIndex = 10;
        	this.button1.Text = "Find Children";
        	this.button1.UseVisualStyleBackColor = true;
        	this.button1.Click += new System.EventHandler(this.button1_Click);
        	// 
        	// button2
        	// 
        	this.button2.Location = new System.Drawing.Point(96, 80);
        	this.button2.Name = "button2";
        	this.button2.Size = new System.Drawing.Size(75, 24);
        	this.button2.TabIndex = 11;
        	this.button2.Text = "Parse Dir";
        	this.button2.UseVisualStyleBackColor = true;
        	this.button2.Click += new System.EventHandler(this.button2_Click);
        	// 
        	// btnAdd32Customs
        	// 
        	this.btnAdd32Customs.Location = new System.Drawing.Point(449, 9);
        	this.btnAdd32Customs.Name = "btnAdd32Customs";
        	this.btnAdd32Customs.Size = new System.Drawing.Size(137, 23);
        	this.btnAdd32Customs.TabIndex = 12;
        	this.btnAdd32Customs.Text = "Add 32 Customs";
        	this.btnAdd32Customs.UseVisualStyleBackColor = true;
        	this.btnAdd32Customs.Click += new System.EventHandler(this.btnAdd32Customs_Click);
        	// 
        	// button4
        	// 
        	this.button4.Location = new System.Drawing.Point(14, 131);
        	this.button4.Name = "button4";
        	this.button4.Size = new System.Drawing.Size(75, 23);
        	this.button4.TabIndex = 13;
        	this.button4.Text = "button4";
        	this.button4.UseVisualStyleBackColor = true;
        	this.button4.Click += new System.EventHandler(this.button3_Click);
        	// 
        	// btnUpdateConfig
        	// 
        	this.btnUpdateConfig.Location = new System.Drawing.Point(96, 131);
        	this.btnUpdateConfig.Name = "btnUpdateConfig";
        	this.btnUpdateConfig.Size = new System.Drawing.Size(119, 57);
        	this.btnUpdateConfig.TabIndex = 14;
        	this.btnUpdateConfig.Text = "Update Config";
        	this.btnUpdateConfig.UseVisualStyleBackColor = true;
        	this.btnUpdateConfig.Click += new System.EventHandler(this.btnUpdateConfig_Click);
        	// 
        	// button5
        	// 
        	this.button5.Location = new System.Drawing.Point(96, 110);
        	this.button5.Name = "button5";
        	this.button5.Size = new System.Drawing.Size(119, 23);
        	this.button5.TabIndex = 15;
        	this.button5.Text = "UpdateConfig";
        	this.button5.UseVisualStyleBackColor = true;
        	this.button5.Click += new System.EventHandler(this.button5_Click);
        	// 
        	// txtConfi
        	// 
        	this.txtConfi.Location = new System.Drawing.Point(15, 38);
        	this.txtConfi.Name = "txtConfi";
        	this.txtConfi.Size = new System.Drawing.Size(334, 20);
        	this.txtConfi.TabIndex = 16;
        	this.txtConfi.Text = "C:\\Documents and Settings\\mkabbani\\Desktop\\test.txt";
        	// 
        	// button6
        	// 
        	this.button6.Location = new System.Drawing.Point(30, 227);
        	this.button6.Name = "button6";
        	this.button6.Size = new System.Drawing.Size(113, 43);
        	this.button6.TabIndex = 17;
        	this.button6.Text = "Add Sites";
        	this.button6.UseVisualStyleBackColor = true;
        	this.button6.Click += new System.EventHandler(this.Button6Click);
        	// 
        	// btnUtilsParser
        	// 
        	this.btnUtilsParser.Location = new System.Drawing.Point(30, 290);
        	this.btnUtilsParser.Name = "btnUtilsParser";
        	this.btnUtilsParser.Size = new System.Drawing.Size(141, 54);
        	this.btnUtilsParser.TabIndex = 18;
        	this.btnUtilsParser.Text = "utilsParser";
        	this.btnUtilsParser.UseVisualStyleBackColor = true;
        	this.btnUtilsParser.Click += new System.EventHandler(this.BtnUtilsParserClick);
        	// 
        	// txtConnx
        	// 
        	this.txtConnx.Location = new System.Drawing.Point(6, 19);
        	this.txtConnx.Multiline = true;
        	this.txtConnx.Name = "txtConnx";
        	this.txtConnx.Size = new System.Drawing.Size(449, 112);
        	this.txtConnx.TabIndex = 8;
        	// 
        	// btnTestConn
        	// 
        	this.btnTestConn.Location = new System.Drawing.Point(51, 137);
        	this.btnTestConn.Name = "btnTestConn";
        	this.btnTestConn.Size = new System.Drawing.Size(141, 54);
        	this.btnTestConn.TabIndex = 19;
        	this.btnTestConn.Text = "Test Conn";
        	this.btnTestConn.UseVisualStyleBackColor = true;
        	this.btnTestConn.Click += new System.EventHandler(this.BtnTestConnClick);
        	// 
        	// Form1
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(805, 673);
        	this.Controls.Add(this.btnUtilsParser);
        	this.Controls.Add(this.button6);
        	this.Controls.Add(this.txtConfi);
        	this.Controls.Add(this.button5);
        	this.Controls.Add(this.btnUpdateConfig);
        	this.Controls.Add(this.button4);
        	this.Controls.Add(this.btnAdd32Customs);
        	this.Controls.Add(this.button2);
        	this.Controls.Add(this.cmbMain);
        	this.Controls.Add(this.button1);
        	this.Controls.Add(this.gbChildren);
        	this.Controls.Add(this.btnParseEvent);
        	this.Controls.Add(this.txtEventIn);
        	this.Controls.Add(this.grpBoxAttr);
        	this.Controls.Add(this.btnPopulateTV);
        	this.Controls.Add(this.btnParse);
        	this.Controls.Add(this.txtInputFile);
        	this.Controls.Add(this.lvItems);
        	this.Controls.Add(this.txtOutput);
        	this.Name = "Form1";
        	this.Text = "Main Form";
        	this.Load += new System.EventHandler(this.Form1_Load);
        	this.grpBoxAttr.ResumeLayout(false);
        	this.gbChildren.ResumeLayout(false);
        	this.gbChildren.PerformLayout();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Button btnTestConn;
        private System.Windows.Forms.TextBox txtConnx;
        private System.Windows.Forms.Button btnUtilsParser;
        private System.Windows.Forms.Button button6;

        #endregion

        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.TextBox txtInputFile;
        private System.Windows.Forms.Button btnParse;
        private System.Windows.Forms.TreeView tvOutput;
        private System.Windows.Forms.Button btnPopulateTV;
        private System.Windows.Forms.GroupBox grpBoxAttr;
        private System.Windows.Forms.TextBox txtEventIn;
        private System.Windows.Forms.Button btnParseEvent;
        private System.Windows.Forms.GroupBox gbChildren;
        private System.Windows.Forms.ComboBox cmbMain;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAdd32Customs;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnUpdateConfig;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox txtConfi;
    }
}

