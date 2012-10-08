namespace XmlParsersAndUi.Forms {
    partial class TestingTabs {
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
            this.tdhTabPage1 = new XmlParsersAndUi.TdhTabPage(this.components);
            this.tdhTabPage2 = new XmlParsersAndUi.TdhTabPage(this.components);
            this.tdhTabCtl1 = new XmlParsersAndUi.TdhTabCtl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.cboAvailablePages = new System.Windows.Forms.ComboBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txtPropertyDesc = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.btnResetProperty = new System.Windows.Forms.Button();
            this.btnSaveProperty = new System.Windows.Forms.Button();
            this.btnAddProperty = new System.Windows.Forms.Button();
            this.lbAvailableProperties = new System.Windows.Forms.ListBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboPropertyType = new System.Windows.Forms.ComboBox();
            this.txtPropertyValue = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPropertyName = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnRemovePage = new System.Windows.Forms.Button();
            this.btnAddPage = new System.Windows.Forms.Button();
            this.txtPageId = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPageName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tdhTabCtl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tdhTabPage1
            // 
            this.tdhTabPage1.Location = new System.Drawing.Point(4, 28);
            this.tdhTabPage1.Name = "tdhTabPage1";
            this.tdhTabPage1.Size = new System.Drawing.Size(753, 408);
            this.tdhTabPage1.TabIndex = 3;
            this.tdhTabPage1.Text = "Page4              ";
            this.tdhTabPage1.Visible = false;
            // 
            // tdhTabPage2
            // 
            this.tdhTabPage2.Location = new System.Drawing.Point(4, 28);
            this.tdhTabPage2.Name = "tdhTabPage2";
            this.tdhTabPage2.Size = new System.Drawing.Size(767, 475);
            this.tdhTabPage2.TabIndex = 3;
            this.tdhTabPage2.Text = "Page4              ";
            this.tdhTabPage2.Visible = false;
            // 
            // tdhTabCtl1
            // 
            this.tdhTabCtl1.Controls.Add(this.tabPage3);
            this.tdhTabCtl1.Controls.Add(this.tabPage4);
            this.tdhTabCtl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tdhTabCtl1.ItemSize = new System.Drawing.Size(230, 24);
            this.tdhTabCtl1.Location = new System.Drawing.Point(12, 12);
            this.tdhTabCtl1.Name = "tdhTabCtl1";
            this.tdhTabCtl1.SelectedIndex = 1;
            this.tdhTabCtl1.Size = new System.Drawing.Size(677, 399);
            this.tdhTabCtl1.TabIndex = 9;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 28);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(669, 367);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Functions";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.label15);
            this.tabPage4.Controls.Add(this.cboAvailablePages);
            this.tabPage4.Controls.Add(this.groupBox6);
            this.tabPage4.Controls.Add(this.groupBox4);
            this.tabPage4.Location = new System.Drawing.Point(4, 28);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(669, 367);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Main Page";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(243, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(98, 13);
            this.label15.TabIndex = 8;
            this.label15.Text = "Available Pages";
            // 
            // cboAvailablePages
            // 
            this.cboAvailablePages.BackColor = System.Drawing.Color.SkyBlue;
            this.cboAvailablePages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAvailablePages.FormattingEnabled = true;
            this.cboAvailablePages.Items.AddRange(new object[] {
            "Boolean",
            "String"});
            this.cboAvailablePages.Location = new System.Drawing.Point(161, 30);
            this.cboAvailablePages.Name = "cboAvailablePages";
            this.cboAvailablePages.Size = new System.Drawing.Size(263, 21);
            this.cboAvailablePages.TabIndex = 7;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.txtPropertyDesc);
            this.groupBox6.Controls.Add(this.label14);
            this.groupBox6.Controls.Add(this.btnResetProperty);
            this.groupBox6.Controls.Add(this.btnSaveProperty);
            this.groupBox6.Controls.Add(this.btnAddProperty);
            this.groupBox6.Controls.Add(this.lbAvailableProperties);
            this.groupBox6.Controls.Add(this.label13);
            this.groupBox6.Controls.Add(this.cboPropertyType);
            this.groupBox6.Controls.Add(this.txtPropertyValue);
            this.groupBox6.Controls.Add(this.label11);
            this.groupBox6.Controls.Add(this.txtPropertyName);
            this.groupBox6.Controls.Add(this.label12);
            this.groupBox6.Location = new System.Drawing.Point(5, 156);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(574, 262);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Page Properties";
            // 
            // txtPropertyDesc
            // 
            this.txtPropertyDesc.Location = new System.Drawing.Point(192, 45);
            this.txtPropertyDesc.Multiline = true;
            this.txtPropertyDesc.Name = "txtPropertyDesc";
            this.txtPropertyDesc.Size = new System.Drawing.Size(376, 43);
            this.txtPropertyDesc.TabIndex = 11;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(145, 48);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 13);
            this.label14.TabIndex = 10;
            this.label14.Text = "Desc:";
            // 
            // btnResetProperty
            // 
            this.btnResetProperty.Location = new System.Drawing.Point(330, 233);
            this.btnResetProperty.Name = "btnResetProperty";
            this.btnResetProperty.Size = new System.Drawing.Size(75, 23);
            this.btnResetProperty.TabIndex = 9;
            this.btnResetProperty.Text = "Reset";
            this.btnResetProperty.UseVisualStyleBackColor = true;
            // 
            // btnSaveProperty
            // 
            this.btnSaveProperty.Location = new System.Drawing.Point(249, 233);
            this.btnSaveProperty.Name = "btnSaveProperty";
            this.btnSaveProperty.Size = new System.Drawing.Size(75, 23);
            this.btnSaveProperty.TabIndex = 8;
            this.btnSaveProperty.Text = "Save";
            this.btnSaveProperty.UseVisualStyleBackColor = true;
            // 
            // btnAddProperty
            // 
            this.btnAddProperty.Location = new System.Drawing.Point(168, 233);
            this.btnAddProperty.Name = "btnAddProperty";
            this.btnAddProperty.Size = new System.Drawing.Size(75, 23);
            this.btnAddProperty.TabIndex = 7;
            this.btnAddProperty.Text = "Add";
            this.btnAddProperty.UseVisualStyleBackColor = true;
            // 
            // lbAvailableProperties
            // 
            this.lbAvailableProperties.FormattingEnabled = true;
            this.lbAvailableProperties.Location = new System.Drawing.Point(6, 19);
            this.lbAvailableProperties.Name = "lbAvailableProperties";
            this.lbAvailableProperties.Size = new System.Drawing.Size(130, 238);
            this.lbAvailableProperties.TabIndex = 6;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(146, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "Type: ";
            // 
            // cboPropertyType
            // 
            this.cboPropertyType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPropertyType.FormattingEnabled = true;
            this.cboPropertyType.Items.AddRange(new object[] {
            "Boolean",
            "String"});
            this.cboPropertyType.Location = new System.Drawing.Point(192, 94);
            this.cboPropertyType.Name = "cboPropertyType";
            this.cboPropertyType.Size = new System.Drawing.Size(153, 21);
            this.cboPropertyType.TabIndex = 4;
            // 
            // txtPropertyValue
            // 
            this.txtPropertyValue.Location = new System.Drawing.Point(192, 128);
            this.txtPropertyValue.Name = "txtPropertyValue";
            this.txtPropertyValue.Size = new System.Drawing.Size(153, 20);
            this.txtPropertyValue.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(146, 131);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Value: ";
            // 
            // txtPropertyName
            // 
            this.txtPropertyName.Location = new System.Drawing.Point(192, 19);
            this.txtPropertyName.Name = "txtPropertyName";
            this.txtPropertyName.Size = new System.Drawing.Size(213, 20);
            this.txtPropertyName.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(145, 22);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 0;
            this.label12.Text = "Name: ";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnRemovePage);
            this.groupBox4.Controls.Add(this.btnAddPage);
            this.groupBox4.Controls.Add(this.txtPageId);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.txtPageName);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Location = new System.Drawing.Point(5, 57);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(574, 94);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Page Config";
            // 
            // btnRemovePage
            // 
            this.btnRemovePage.Location = new System.Drawing.Point(290, 65);
            this.btnRemovePage.Name = "btnRemovePage";
            this.btnRemovePage.Size = new System.Drawing.Size(92, 23);
            this.btnRemovePage.TabIndex = 10;
            this.btnRemovePage.Text = "Remove Page";
            this.btnRemovePage.UseVisualStyleBackColor = true;
            // 
            // btnAddPage
            // 
            this.btnAddPage.Location = new System.Drawing.Point(192, 65);
            this.btnAddPage.Name = "btnAddPage";
            this.btnAddPage.Size = new System.Drawing.Size(92, 23);
            this.btnAddPage.TabIndex = 9;
            this.btnAddPage.Text = "Add Page";
            this.btnAddPage.UseVisualStyleBackColor = true;
            // 
            // txtPageId
            // 
            this.txtPageId.Location = new System.Drawing.Point(53, 39);
            this.txtPageId.Name = "txtPageId";
            this.txtPageId.Size = new System.Drawing.Size(124, 20);
            this.txtPageId.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(24, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "ID: ";
            // 
            // txtPageName
            // 
            this.txtPageName.Location = new System.Drawing.Point(53, 13);
            this.txtPageName.Name = "txtPageName";
            this.txtPageName.Size = new System.Drawing.Size(319, 20);
            this.txtPageName.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 13);
            this.label9.TabIndex = 0;
            this.label9.Text = "Name: ";
            // 
            // TestingTabs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 605);
            this.Controls.Add(this.tdhTabCtl1);
            this.Name = "TestingTabs";
            this.Text = "TestingTabs";
            this.Load += new System.EventHandler(this.TestingTabs_Load);
            this.tdhTabCtl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TdhTabPage tdhTabPage1;
        private TdhTabPage tdhTabPage2;
        private TdhTabCtl tdhTabCtl1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboAvailablePages;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txtPropertyDesc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnResetProperty;
        private System.Windows.Forms.Button btnSaveProperty;
        private System.Windows.Forms.Button btnAddProperty;
        private System.Windows.Forms.ListBox lbAvailableProperties;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cboPropertyType;
        private System.Windows.Forms.TextBox txtPropertyValue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtPropertyName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnRemovePage;
        private System.Windows.Forms.Button btnAddPage;
        private System.Windows.Forms.TextBox txtPageId;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPageName;
        private System.Windows.Forms.Label label9;

    }
}