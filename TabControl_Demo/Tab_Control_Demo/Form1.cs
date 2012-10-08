using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using MyControlLibrary;
namespace WindowsApplication1
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private MyControlLibrary.TabCtlEx userControl11;
		TabPageEx tabPage1;
		TabPageEx tabPage2;
		TabPageEx tabPage3;
		private TabPageEx tabPage4;
		private ContextMenu contextMenuStrip1;
		private MenuItem closeToolStripMenuItem;
		private MenuItem closeAllButThisToolStripMenuItem;
		private MenuItem closeTabToolStripMenuItem;
		private System.ComponentModel.IContainer components;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
         
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.userControl11 = new MyControlLibrary.TabCtlEx();
			this.tabPage2 = new MyControlLibrary.TabPageEx(this.components);
			this.tabPage3 = new MyControlLibrary.TabPageEx(this.components);
			this.tabPage4 = new MyControlLibrary.TabPageEx(this.components);
			this.tabPage1 = new MyControlLibrary.TabPageEx(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenu();
			this.closeToolStripMenuItem = new System.Windows.Forms.MenuItem();
			this.closeAllButThisToolStripMenuItem = new System.Windows.Forms.MenuItem();
			this.closeTabToolStripMenuItem = new System.Windows.Forms.MenuItem();
			this.userControl11.SuspendLayout();
            
			this.SuspendLayout();
			// 
			// userControl11
			// 
			this.userControl11.ConfirmOnClose = true;
			this.userControl11.Controls.Add(this.tabPage2);
			this.userControl11.Controls.Add(this.tabPage3);
			this.userControl11.Controls.Add(this.tabPage4);
			this.userControl11.Controls.Add(this.tabPage1);
			this.userControl11.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.userControl11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.userControl11.ItemSize = new System.Drawing.Size(330, 24);
			this.userControl11.Location = new System.Drawing.Point(8, 40);
			this.userControl11.Name = "userControl11";
			this.userControl11.SelectedIndex = 0;
			this.userControl11.Size = new System.Drawing.Size(824, 320);
			this.userControl11.TabIndex = 0;
			this.userControl11.TabStop = false;
			this.userControl11.OnClose += new MyControlLibrary.TabCtlEx.OnHeaderCloseDelegate(this.userControl11_OnClose);
			// 
			// tabPage2
			// 
			this.tabPage2.Location = new System.Drawing.Point(4, 28);
			this.tabPage2.Menu = null;
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(816, 288);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "tabPage2";
			this.tabPage2.Menu = contextMenuStrip1;
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 28);
			this.tabPage3.Menu = null;
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(816, 288);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "tabPage3";
			//this.tabPage3.Menu = contextMenuStrip1;
			// 
			// tabPage4
			// 
			this.tabPage4.Location = new System.Drawing.Point(4, 28);
			this.tabPage4.Menu = null;
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(816, 288);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "tabPage4";
			this.tabPage4.Menu = contextMenuStrip1;
			// 
			// tabPage1
			// 
			this.tabPage1.Location = new System.Drawing.Point(4, 28);
			
			this.tabPage1.Menu = null;
			this.tabPage1.Name = "tabPage1";
			
			this.tabPage1.Size = new System.Drawing.Size(816, 288);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "tabPage1";
			
			this.tabPage1.Menu = contextMenuStrip1;
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																							  this.closeToolStripMenuItem,
																							  this.closeAllButThisToolStripMenuItem,
																							  this.closeTabToolStripMenuItem});
            
			
            
			// 
			// closeToolStripMenuItem
			// 
			
            
			this.closeToolStripMenuItem.Text = "New Tab";
			this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
			// 
			// closeAllButThisToolStripMenuItem
			// 
			
            
			this.closeAllButThisToolStripMenuItem.Text = "Close all other tabs";
			// 
			// closeTabToolStripMenuItem
			// 
			
            
			this.closeTabToolStripMenuItem.Text = "Close tab";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(856, 382);
			this.Controls.Add(this.userControl11);
			this.Name = "Form1";
			this.Text = "Tab Control Demo";
			this.userControl11.ResumeLayout(false);
            
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void userControl11_OnClose(object sender, CloseEventArgs e)
		{
         
			this.userControl11.Controls.Remove(this.userControl11.TabPages[e.TabIndex ]); 
		}

		private void closeToolStripMenuItem_Click(object sender, EventArgs e)
		{

		}
	}
}
