using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using TDHControls.TDHTabCtl;

namespace Demo_TDHTabCtl
{
	/// <summary>
	/// Summary description for frmDemo_TDHTabCtl.
	/// </summary>
	public class frmDemo_TDHTabCtl : System.Windows.Forms.Form
	{
		#region Windows Component Designer generated instantiation of components

		private TDHControls.TDHTabCtl.TdhTabCtl tdhTabCtl1;
		private TDHControls.TDHTabCtl.TdhTabPage tdhTabPage1;
		private TDHControls.TDHTabCtl.TdhTabPage tdhTabPage2;
		private TDHControls.TDHTabCtl.TdhTabPage tdhTabPage3;
		private TDHControls.TDHTabCtl.TdhTabPage tdhTabPage4;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPageX;
		private System.ComponentModel.IContainer components;

		#endregion 

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.tdhTabCtl1 = new TDHControls.TDHTabCtl.TdhTabCtl();
			this.tdhTabPage1 = new TDHControls.TDHTabCtl.TdhTabPage(this.components);
			this.label1 = new System.Windows.Forms.Label();
			this.tdhTabPage2 = new TDHControls.TDHTabCtl.TdhTabPage(this.components);
			this.label2 = new System.Windows.Forms.Label();
			this.tdhTabPage3 = new TDHControls.TDHTabCtl.TdhTabPage(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.tdhTabPage4 = new TDHControls.TDHTabCtl.TdhTabPage(this.components);
			this.label4 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPageX = new System.Windows.Forms.TabPage();
			this.tdhTabCtl1.SuspendLayout();
			this.tdhTabPage1.SuspendLayout();
			this.tdhTabPage2.SuspendLayout();
			this.tdhTabPage3.SuspendLayout();
			this.tdhTabPage4.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// tdhTabCtl1
			// 
			this.tdhTabCtl1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tdhTabCtl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.tdhTabPage1,
																					 this.tdhTabPage2,
																					 this.tdhTabPage3,
																					 this.tdhTabPage4,
																					 this.tabPageX});
//this.tdhTabCtl1.Controls.AddRange(new System.Windows.Forms.Control[] {
//																			this.tdhTabPage1,
//																			this.tdhTabPage2,
//																			this.tdhTabPage3,
//																			this.tdhTabPage4
//																	 });
//this.tdhTabCtl1.TabPages.AddRange(new System.Windows.Forms.TabPage[] {
//																			this.tdhTabPage1,
//																			this.tdhTabPage2,
//																			this.tdhTabPage3,
//																			this.tdhTabPage4,
//																			this.tabPageX});
//this.tdhTabCtl1.TdhTabPages.AddRange(new System.Windows.Forms.TabPage[] {
//																			this.tdhTabPage1,
//																			this.tdhTabPage2,
//																			this.tdhTabPage3,
//																			this.tdhTabPage4,
//																			this.tabPageX});
//this.tdhTabCtl1.TdhTabPages.AddRange(new TDHControls.TDHTabCtl.TdhTabPage[] {
//																			this.tdhTabPage1,
//																			this.tdhTabPage2,
//																			this.tdhTabPage3,
//																			this.tdhTabPage4
//																		});

			this.tdhTabCtl1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.tdhTabCtl1.ItemSize = new System.Drawing.Size(230, 24);
			this.tdhTabCtl1.Name = "tdhTabCtl1";
			this.tdhTabCtl1.SelectedIndex = 0;
			this.tdhTabCtl1.Size = new System.Drawing.Size(800, 216);
			this.tdhTabCtl1.TabIndex = 2;
			this.tdhTabCtl1.TabStop = false;

//this.tdhTabCtl1.TabsAllowContextMenu = false;
//this.tdhTabCtl1.TabsAllowClose = false;
//this.tdhTabCtl1.TabsConfirmOnClose = false;
this.tdhTabCtl1.TabsBase_AllowClose = true;
this.tdhTabCtl1.TabsBase_ConfirmOnClose = false;
this.tdhTabCtl1.TabsBase_ContextMenuAllowOpen = true;

//this.tdhTabCtl1.TabsAllowContextMenu = false;
//this.tdhTabCtl1.TabsContextMenuAllowOpen = false;
//this.tdhTabCtl1.TabsBase_ContextMenuAllowOpen = false;
//this.tdhTabCtl1.TabsContextMenuAllowRename = false;
//this.tdhTabCtl1.TabsContextMenuAllowReorder = false;
//this.tdhTabCtl1.TabsContextMenuAllowClose = false;
//this.tdhTabCtl1.TabsBase_AllowClose = false;

			this.tdhTabCtl1.OnTabsReordered += new TDHControls.TDHTabCtl.TabsReorderedEventDelegate(this.tdhTabCtl1_OnTabsReordered);
			this.tdhTabCtl1.OnTabEvents += new TDHControls.TDHTabCtl.TabEventsDelegate(this.tdhTabCtl1_OnTabEvents);
			// 
			// tdhTabPage1
			// 
			this.tdhTabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.label1});
			this.tdhTabPage1.Location = new System.Drawing.Point(4, 28);
			this.tdhTabPage1.Name = "tdhTabPage1";
			this.tdhTabPage1.Size = new System.Drawing.Size(792, 184);
			this.tdhTabPage1.TabIndex = 0;
			this.tdhTabPage1.TabShowCloseButton = false;
			this.tdhTabPage1.TabShowMenuButton = false;
			this.tdhTabPage1.Text = " Page1";
			// 
			// label1
			// 
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(160, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "FireFox-like TabPage 1";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tdhTabPage2
			// 
			this.tdhTabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.label2});
			this.tdhTabPage2.Location = new System.Drawing.Point(4, 28);
			this.tdhTabPage2.Name = "tdhTabPage2";
			this.tdhTabPage2.Size = new System.Drawing.Size(792, 184);
			this.tdhTabPage2.TabAllowClose = false;
			this.tdhTabPage2.TabIndex = 1;
			this.tdhTabPage2.TabShowMenuButton = false;
			this.tdhTabPage2.Text = " Page2      ";
			// 
			// label2
			// 
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(160, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "FireFox-like TabPage 2";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tdhTabPage3
			// 
			this.tdhTabPage3.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.label3});
			this.tdhTabPage3.Location = new System.Drawing.Point(4, 28);
			this.tdhTabPage3.Name = "tdhTabPage3";
			this.tdhTabPage3.Size = new System.Drawing.Size(792, 184);
			this.tdhTabPage3.TabAllowContextMenu = false;
			this.tdhTabPage3.TabIndex = 2;
			this.tdhTabPage3.Text = " Page3             ";
			// 
			// label3
			// 
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(160, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "FireFox-like TabPage 3";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tdhTabPage4
			// 
			this.tdhTabPage4.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.label4});
			this.tdhTabPage4.Location = new System.Drawing.Point(4, 28);
			this.tdhTabPage4.Name = "tdhTabPage4";
			this.tdhTabPage4.Size = new System.Drawing.Size(792, 184);
			this.tdhTabPage4.TabIndex = 3;
			this.tdhTabPage4.TabShowCloseButton = false;
			this.tdhTabPage4.Text = " Page4      ";
			// 
			// tabPageX
			// 
			this.tabPageX.Location = new System.Drawing.Point(4, 28);
			this.tabPageX.Name = "tabPageX";
			this.tabPageX.Size = new System.Drawing.Size(792, 184);
			this.tabPageX.TabIndex = 4;
			this.tabPageX.Text = "tabPageX";
			// 
			// label4
			// 
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(160, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "FireFox-like TabPage 4";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Info;
			this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline), System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.button1.Location = new System.Drawing.Point(72, 224);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(32, 32);
			this.button1.TabIndex = 1;
			this.button1.Text = "^";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(792, 190);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tabPage1});
			this.tabControl1.ItemSize = new System.Drawing.Size(58, 18);
			this.tabControl1.Location = new System.Drawing.Point(0, 272);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(800, 216);
			this.tabControl1.TabIndex = 1;
			// 
			// frmDemo_TDHTabCtl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
			this.ClientSize = new System.Drawing.Size(800, 486);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tdhTabCtl1,
																		  this.tabControl1,
																		  this.button1});
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Name = "frmDemo_TDHTabCtl";
			this.Text = "frmDemo_TDHTabCtl";
			this.tdhTabCtl1.ResumeLayout(false);
			this.tdhTabPage1.ResumeLayout(false);
			this.tdhTabPage2.ResumeLayout(false);
			this.tdhTabPage3.ResumeLayout(false);
			this.tdhTabPage4.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmDemo_TDHTabCtl());
		}


		#region Form Constructor and Dispose()
		public frmDemo_TDHTabCtl()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			System.Windows.Forms.ContextMenu cmnuTemp = new System.Windows.Forms.ContextMenu();				// TEST	
			System.Windows.Forms.MenuItem itemTemp = new System.Windows.Forms.MenuItem("MenuItem: TabPage3");// TEST	
			itemTemp.Click += new System.EventHandler(this.itemTemp_Click);									// TEST
			cmnuTemp.MenuItems.Add(itemTemp);																// TEST
			this.tdhTabPage3.ContextMenu = cmnuTemp;														// TEST
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}
		#endregion 


		private void button1_Click(object sender, System.EventArgs e)
		{
//{
////	//System.Windows.Forms.TabPage tabPage = this.tdhTabCtl1.TabPages[0];
////	//System.Windows.Forms.TabPage tabPage = this.tdhTabCtl1.TdhTabPages[true, 0];
////	//this.tdhTabCtl1.TabPages.Remove(tabPage);
////
////	TDHControls.TDHTabCtl.TdhTabPage tabPage = this.tdhTabCtl1.TdhTabPages[0];
////	this.tdhTabCtl1.TdhTabPages.Remove(tabPage);
////
////	this.tabControl1.TabPages.Add(tabPage);
//
//}
//return;

			if( (tabControl1.TabCount > 1) 
				&& (tabControl1.SelectedIndex > -1) 
				&& (tabControl1.SelectedIndex < tabControl1.TabCount) 
				)
			{
				System.Windows.Forms.TabPage tabPage = tabControl1.TabPages[tabControl1.SelectedIndex];
				if( (tabPage.GetType() == typeof(TDHControls.TDHTabCtl.TdhTabPage))
				|| tabPage.GetType().IsSubclassOf(typeof(TDHControls.TDHTabCtl.TdhTabPage))
				)
				{
					this.tabControl1.TabPages.Remove(tabPage);
					////this.tdhTabCtl1.TabPages[0] = (TDHControls.TDHTabCtl.TdhTabPage)tabPage;	// TEST (replace [0])
					//this.tdhTabCtl1.TdhTabPages[0] = (TDHControls.TDHTabCtl.TdhTabPage)tabPage;	// TEST (replace [0])
					////this.tdhTabCtl1.TabPages.Add((TDHControls.TDHTabCtl.TdhTabPage)tabPage);	// TEST (append)
					//this.tdhTabCtl1.TdhTabPages.Add((TDHControls.TDHTabCtl.TdhTabPage)tabPage);	// TEST (append)

					//this.tdhTabCtl1.TabPages.Insert(
					this.tdhTabCtl1.TdhTabPages.Insert(
						((TDHControls.TDHTabCtl.TdhTabPage)tabPage).TabIndex,	// assume .TabIndex has correct value
						(TDHControls.TDHTabCtl.TdhTabPage)tabPage);

				//	// [tabPage] will either replace [.TdhTabPages[idx]] or will be appended to the Collection
				//	this.tdhTabCtl1.TdhTabPages[true, ((TDHControls.TDHTabCtl.TdhTabPage)tabPage).TabIndex] = tabPage;

				}
				else
				{
					this.tabControl1.TabPages.Remove(tabPage);

					//this.tdhTabCtl1.TabPages.Insert(
					this.tdhTabCtl1.TdhTabPages.Insert(
						tabPage.TabIndex,										// assume .TabIndex has correct value
						tabPage);
				}
			}
		}

		private void tdhTabCtl1_OnTabEvents(object sender, TDHControls.TDHTabCtl.TabEventArgs e)
		{
			switch (e.TabEvent)
			{
				case TDHControls.TDHTabCtl.TabEventArgs.TabEvents.TabAdded:
					Console.WriteLine("Added="+ e.TabPage.Text);										// TEST
					break;
				case TDHControls.TDHTabCtl.TabEventArgs.TabEvents.TabAddRejected:
					Console.WriteLine("Add Rejected="+ e.TabPage.Text);									// TEST
					//this.tabControl1.Controls.Add(e.TabPage);
					this.tabControl1.TabPages.Add(e.TabPage);
					break;
				case TDHControls.TDHTabCtl.TabEventArgs.TabEvents.TabRemoved:
					Console.WriteLine("Closed="+ e.TabPage.Text);										// TEST
					this.tabControl1.Controls.Add(e.TabPage);
//this.tdhTabCtl1.Controls.Add(e.TabPage);
//this.tdhTabCtl1.TabPages.Add(e.TabPage);
					break;
				case TDHControls.TDHTabCtl.TabEventArgs.TabEvents.TabRenamed:
					Console.WriteLine("Renamed="+ e.TabPage.Text.Trim()									// TEST
						//+"   contains? "+ this.tdhTabCtl1.TabPages.Contains(e.TabPage).ToString() );	// TEST
						+"   contains? "+ this.tdhTabCtl1.Controls.Contains(e.TabPage).ToString() );	// TEST

					break;
				case TDHControls.TDHTabCtl.TabEventArgs.TabEvents.TabsReordered:
					// This "subevent" is not raised  
					// if the [tdhTabCtl1.OnTabsReordered] eventhandler is assigned
					// It is raised for each TdhTabPage affected by the reorder
					Console.WriteLine("TdhTabPage reordered."											// TEST
						+"    OldInd="+ e.TabIndexOld.ToString()										// TEST
						+"    NewInd="+ e.TabIndexNew.ToString());										// TEST
					break;
				case TDHControls.TDHTabCtl.TabEventArgs.TabEvents.undefined:
				default:
					break;
			}
		}

		private void tdhTabCtl1_OnTabsReordered(object sender, TDHControls.TDHTabCtl.TabsReorderedEventArgs e)
		{ 
			for (int idx = 0; idx < e.TabOrder_int.Length; idx++)
			{
				Console.WriteLine("TdhTabPage reordered."											// TEST
					+"    OldInd="+ e.TabOrder_int[idx].ToString()									// TEST
					+"    NewInd="+ idx.ToString() );												// TEST
			}
		}

		private void itemTemp_Click(object sender, System.EventArgs e)								// TEST
		{																							// TEST
			MessageBox.Show("clicked - MenuItem: TabPage3");										// TEST
//MessageBox.Show(this.tdhTabCtl1.TdhTabPages["Page2", true].Text );
//MessageBox.Show(this.tdhTabCtl1.TdhTabPages[4].Text );
		}																							// TEST


	}
}