// Class: [TdhTabCtl_Designer : System.Windows.Forms.Design.ControlDesigner]								// 1.0.020
//   The primary purpose of this class is to define a custom design-time ContextMenu						// 1.0.020
//   for the [TDHControls.TDHTabCtl.TdhTabCtl] class,														// 1.0.020
//	 as the [System.Windows.Forms.Design.TabControlDesigner] cannot be inherited.							// 1.0.020
//																											// 1.0.020
// The best (most effective) part of the code for the [TdhTabCtl_Designer] class							// 1.0.020
// is based on code posted in a comment here:																// 1.0.020
//																											// 1.0.020
//   "Adding custom TabPages at design time" http://bytes.com/forum/thread576709.html						// 1.0.020
//																											// 1.0.020
// I was fairly certain I needed to use a [.ControlDesigner] class to define the design-time ContextMenu, 	// 1.0.020
// and I was sure it would involve the [Verbs] property, but I didn't know enough to do it correctly.		// 1.0.020
// What a relief to find this code.																			// 1.0.020

#region using ...
using System;																								// 1.0.020
using System.Collections;																					// 1.0.020
using System.ComponentModel;																				// 1.0.020
using System.ComponentModel.Design;																			// 1.0.020
using System.Design;																						// 1.0.020
using System.Drawing;																						// 1.0.020
using System.Windows.Forms;																					// 1.0.020
using System.Windows.Forms.Design;																			// 1.0.020

using System.Runtime.InteropServices;																		// 1.0.020
#endregion 

namespace TDHControls.TDHTabCtl																				// 1.0.020
{																											// 1.0.020
	//internal class TdhTabCtl_Designer : System.Windows.Forms.Design.ControlDesigner						// 1.0.020
	internal class TdhTabCtl_Designer : System.Windows.Forms.Design.ParentControlDesigner					// 1.0.020
	{																										// 1.0.020
		#region Class Private Fields
		//private System.ComponentModel.Design.DesignerVerbCollection _Verbs;								// 1.0.020
		private System.ComponentModel.Design.DesignerVerbCollection _Verbs = new System.ComponentModel.Design.DesignerVerbCollection();	// 1.0.020
		private System.ComponentModel.Design.DesignerVerb _Verb_Add_TdhTabPage;								// 1.0.021
		private System.ComponentModel.Design.DesignerVerb _Verb_Add_TabPage;								// 1.0.021
		private System.ComponentModel.Design.DesignerVerb _Verb_Remove_TabPage;								// 1.0.021

		private System.ComponentModel.Design.IDesignerHost _DesignerHost;									// 1.0.020
		private System.ComponentModel.Design.ISelectionService _SelectionService;							// 1.0.020
		#endregion 

		#region Class construcor and destructor
		TdhTabCtl_Designer() : base()																		// 1.0.020
		{																									// 1.0.020
			Verbs_Build();								// Build a new list of context menu items			// 1.0.020
		}																									// 1.0.020

		~TdhTabCtl_Designer()																				// 1.0.020
		{																									// 1.0.020
			_Verb_Add_TdhTabPage = null;																	// 1.0.021
			_Verb_Add_TabPage = null;																		// 1.0.021
			_Verb_Remove_TabPage = null;																	// 1.0.021
			_Verbs.Clear();																					// 1.0.020
			_Verbs = null;																					// 1.0.020

			_DesignerHost = null;																			// 1.0.020
			_SelectionService = null;																		// 1.0.020
		}																									// 1.0.020
		#endregion 

		#region EventHandlers -- Add/Remove TabPages
		// private void OnAdd_TdhTabPage(object sender, System.EventArgs e) 
		// private void OnAdd_TabPage(object sender, System.EventArgs e)
		// private void OnRemove_TabPage(object sender, System.EventArgs e)
		// 
		private void OnAdd_TdhTabPage(object sender, System.EventArgs e)									// 1.0.020
		{																									// 1.0.020
			TDHControls.TDHTabCtl.TdhTabCtl ParentControl = (TDHControls.TDHTabCtl.TdhTabCtl)this.Control;	// 1.0.020
			System.Windows.Forms.Control.ControlCollection oldTabs = ParentControl.Controls;				// 1.0.020

			RaiseComponentChanging(TypeDescriptor.GetProperties(ParentControl)["TabPages"]);				// 1.0.020

			string newTab_Name = "Page"+ (ParentControl.TabCount + 1).ToString();							// 1.0.020
			TDHControls.TDHTabCtl.TdhTabPage newTab =														// 1.0.020
				(TDHControls.TDHTabCtl.TdhTabPage)DesignerHost.CreateComponent(								// 1.0.020
					typeof(TDHControls.TDHTabCtl.TdhTabPage)												// 1.0.020
				);																							// 1.0.020
			#region Commented out -- alternate creation of the new TabPage
			// This signature supplies the actual name of the control being created ... however, if there	// 1.0.020
			// is already a control by that name (this can easily happen if a TabPage is added and then		// 1.0.020
			// removed from the collection), an exception is thrown.  So, it's better to instead allow		// 1.0.020
			// the default name to be generated/used.														// 1.0.020
			//TDHControls.TDHTabCtl.TdhTabPage newTab =														// 1.0.020
			//	(TDHControls.TDHTabCtl.TdhTabPage)DesignerHost.CreateComponent(								// 1.0.020
			//		typeof(TDHControls.TDHTabCtl.TdhTabPage), 												// 1.0.020
			//		newTab_Name																				// 1.0.020
			//	);																							// 1.0.020
			#endregion 
			//newTab.Text = newTab.Name;					// Set .Text to the auto-generated name			// 1.0.020
			newTab.Text = newTab_Name;																		// 1.0.020
			ParentControl.TabPages.Add(newTab);																// 1.0.020

			RaiseComponentChanged(																			// 1.0.020
				System.ComponentModel.TypeDescriptor.GetProperties(ParentControl)["TabPages"],				// 1.0.020
				oldTabs,																					// 1.0.020
				ParentControl.TabPages																		// 1.0.020
			);																								// 1.0.020
			ParentControl.SelectedTab = newTab;																// 1.0.020

			Verbs_Set();																					// 1.0.020
		}																									// 1.0.020

		private void OnAdd_TabPage(object sender, System.EventArgs e)										// 1.0.020
		{																									// 1.0.020
			TDHControls.TDHTabCtl.TdhTabCtl ParentControl = (TDHControls.TDHTabCtl.TdhTabCtl)this.Control;	// 1.0.020
			System.Windows.Forms.Control.ControlCollection oldTabs = ParentControl.Controls;				// 1.0.020

			RaiseComponentChanging(TypeDescriptor.GetProperties(ParentControl)["TabPages"]);				// 1.0.020

			string newTab_Name = "Page"+ (ParentControl.TabCount + 1).ToString();							// 1.0.020
			System.Windows.Forms.TabPage newTab =															// 1.0.020
				(System.Windows.Forms.TabPage)DesignerHost.CreateComponent(									// 1.0.020
					typeof(System.Windows.Forms.TabPage)													// 1.0.020
				);																							// 1.0.020
			#region Commented out -- alternate creation of the new TabPage
			// This signature supplies the actual name of the control being created ... however, if there	// 1.0.020
			// is already a control by that name (this can easily happen if a TabPage is added and then		// 1.0.020
			// removed from the collection), an exception is thrown.  So, it's better to instead allow		// 1.0.020
			// the default name to be generated/used.														// 1.0.020
			//System.Windows.Forms.TabPage newTab =															// 1.0.020
			//	(System.Windows.Forms.TabPage)DesignerHost.CreateComponent(									// 1.0.020
			//		typeof(System.Windows.Forms.TabPage), 													// 1.0.020
			//		newTab_Name																				// 1.0.020
			//	);																							// 1.0.020
			#endregion 
			//newTab.Text = newTab.Name;					// Set .Text to the auto-generated name			// 1.0.020
			newTab.Text = newTab_Name;																		// 1.0.020
			ParentControl.TabPages.Add(newTab);																// 1.0.020

			RaiseComponentChanged(																			// 1.0.020
				System.ComponentModel.TypeDescriptor.GetProperties(ParentControl)["TabPages"],				// 1.0.020
				oldTabs,																					// 1.0.020
				ParentControl.TabPages																		// 1.0.020
			);																								// 1.0.020
			ParentControl.SelectedTab = newTab;																// 1.0.020

			Verbs_Set();																					// 1.0.020
		}																									// 1.0.020

		private void OnRemove_TabPage(object sender, System.EventArgs e)									// 1.0.020
		{																									// 1.0.020
			TDHControls.TDHTabCtl.TdhTabCtl ParentControl = (TDHControls.TDHTabCtl.TdhTabCtl)this.Control;	// 1.0.020
			if (ParentControl.SelectedIndex < 0)															// 1.0.020
			{																								// 1.0.020
				Verbs_Set();																				// 1.0.020
				MessageBox.Show("No TabPage selected.");													// 1.0.020
				return;																						// 1.0.020
			}																								// 1.0.020
			System.Windows.Forms.Control.ControlCollection oldTabs = ParentControl.Controls;				// 1.0.020

			RaiseComponentChanging(TypeDescriptor.GetProperties(ParentControl)["TabPages"]);				// 1.0.020
			DesignerHost.DestroyComponent(ParentControl.TabPages[ParentControl.SelectedIndex]);				// 1.0.020
			RaiseComponentChanged(																			// 1.0.020
				TypeDescriptor.GetProperties(ParentControl)["TabPages"],									// 1.0.020
				oldTabs,																					// 1.0.020
				ParentControl.TabPages																		// 1.0.020
			);																								// 1.0.020

			SelectionService.SetSelectedComponents(															// 1.0.020
				new IComponent[] {ParentControl},															// 1.0.020
				//System.ComponentModel.Design.SelectionTypes.Auto		// .Auto is undefined				// 1.0.020
				System.ComponentModel.Design.SelectionTypes.Normal											// 1.0.020
				);																							// 1.0.020

			Verbs_Set();																					// 1.0.020
		}																									// 1.0.020
		#endregion 

		#region Over-ridden Methods
		// protected override void OnPaintAdornments(System.Windows.Forms.PaintEventArgs pe)
		// public override System.Windows.Forms.Design.SelectionRules SelectionRules {get}
		// 
		protected override void OnPaintAdornments(System.Windows.Forms.PaintEventArgs pe)					// 1.0.020
		{																									// 1.0.020
			// Don't want DrawGrid dots on the TabControl itself.											// 1.0.020
		}																									// 1.0.020

		public override System.Windows.Forms.Design.SelectionRules SelectionRules							// 1.0.020
		{																									// 1.0.020
			get																								// 1.0.020
			{																								// 1.0.020
				//Fix the AllSizable selectionrule on DockStyle.Fill										// 1.0.020
				if (this.Control.Dock == System.Windows.Forms.DockStyle.Fill)								// 1.0.020
				{																							// 1.0.020
					return System.Windows.Forms.Design.SelectionRules.Visible;								// 1.0.020
				}																							// 1.0.020
				return base.SelectionRules;																	// 1.0.020
			}																								// 1.0.020
		}																									// 1.0.020
		#endregion 

		#region Properties
		// public override System.ComponentModel.Design.DesignerVerbCollection Verbs
		// public System.ComponentModel.Design.IDesignerHost DesignerHost
		// public System.ComponentModel.Design.ISelectionService SelectionService
		// 
		public override System.ComponentModel.Design.DesignerVerbCollection Verbs							// 1.0.020
		{																									// 1.0.020
			get																								// 1.0.020
			{																								// 1.0.020
				if( (_Verbs == null)					// The Constructor should have built the .Verbs		// 1.0.020
				|| (_Verbs.Count <= 0) )																	// 1.0.020
				{																							// 1.0.020
					Verbs_Build();						// Build a new list of context menu items			// 1.0.020
				}																							// 1.0.020

				#region Enable/Disable the "Remove Tab" MenuItem
				//if (_Verbs.Count == 3)																	// 1.0.020
				//{																							// 1.0.020
				//	//Verbs_Set();						// This causes a stack overflow when used here		// 1.0.020
				//
				//	TDHControls.TDHTabCtl.TdhTabCtl ParentControl = (TDHControls.TDHTabCtl.TdhTabCtl)this.Control;	// 1.0.020
				//	if (ParentControl.TabCount > 0)															// 1.0.020
				//	{																						// 1.0.020
				//		_Verbs[2].Enabled = true;															// 1.0.020
				//	}																						// 1.0.020
				//	else																					// 1.0.020
				//	{																						// 1.0.020
				//		_Verbs[2].Enabled = false;															// 1.0.020
				//	}																						// 1.0.020
				//}																							// 1.0.020

				if (_Verb_Remove_TabPage != null)															// 1.0.021
				{																							// 1.0.021
					Verbs_Set();																			// 1.0.021

//					TDHControls.TDHTabCtl.TdhTabCtl ParentControl = (TDHControls.TDHTabCtl.TdhTabCtl)this.Control;	// 1.0.021
//					if (ParentControl.TabCount > 0)															// 1.0.021
//					{																						// 1.0.021
//						//_Verbs[2].Enabled = true;															// 1.0.021
//						_Verb_Remove_TabPage.Enabled = true;												// 1.0.021
//					}																						// 1.0.021
//					else																					// 1.0.021
//					{																						// 1.0.021
//						//_Verbs[2].Enabled = false;														// 1.0.021
//						_Verb_Remove_TabPage.Enabled = false;												// 1.0.021
//					}																						// 1.0.021
				}																							// 1.0.021
				#endregion 

				return _Verbs;																				// 1.0.020
			}																								// 1.0.020
		}																									// 1.0.020


		public System.ComponentModel.Design.IDesignerHost DesignerHost										// 1.0.020
		{																									// 1.0.020
			get																								// 1.0.020
			{																								// 1.0.020
				if (_DesignerHost == null)																	// 1.0.020
				{																							// 1.0.020
					_DesignerHost = (System.ComponentModel.Design.IDesignerHost)(GetService(typeof(System.ComponentModel.Design.IDesignerHost)));	// 1.0.020
				}																							// 1.0.020
				return _DesignerHost;																		// 1.0.020
			}																								// 1.0.020
		}																									// 1.0.020


		public System.ComponentModel.Design.ISelectionService SelectionService
		{
			get
			{
				if (_SelectionService == null)
				{
					_SelectionService = (System.ComponentModel.Design.ISelectionService)(this.GetService(typeof(System.ComponentModel.Design.ISelectionService)));
				}
				return _SelectionService;
			}
		}
		#endregion 

		#region Private Methods
		// private void Verbs_Build()
		// private void Verbs_Set()
		// 
		private void Verbs_Build()																			// 1.0.020
		{																									// 1.0.020
			// Build a new list of context menu items														// 1.0.020
			if (_Verbs == null)																				// 1.0.020
			{																								// 1.0.020
				_Verbs = new System.ComponentModel.Design.DesignerVerbCollection();							// 1.0.020
			}																								// 1.0.020
			else																							// 1.0.021
			{																								// 1.0.021
				_Verbs.Clear();																				// 1.0.021
			}																								// 1.0.021
			//if (_Verbs.Count <= 0)																		// 1.0.020
			{																								// 1.0.020
				#region Create the .Verbs [ _Verbs.AddRange(...) ]
				//_Verbs.AddRange(																			// 1.0.020
				//	new System.ComponentModel.Design.DesignerVerb[]											// 1.0.020
				//		{																					// 1.0.020
				//			new System.ComponentModel.Design.DesignerVerb(									// 1.0.020
				//				"Add TdhTabPage",															// 1.0.020
				//				new System.EventHandler(OnAdd_TdhTabPage)									// 1.0.020
				//			),																				// 1.0.020
				//			new System.ComponentModel.Design.DesignerVerb(									// 1.0.020
				//				"Add TabPage",																// 1.0.020
				//				new System.EventHandler(OnAdd_TabPage)										// 1.0.020
				//			),																				// 1.0.020
				//			new System.ComponentModel.Design.DesignerVerb(									// 1.0.020
				//				"Remove Tab",																// 1.0.020
				//				new System.EventHandler(OnRemove_TabPage)									// 1.0.020
				//			)																				// 1.0.020
				//		}																					// 1.0.020
				//	);																						// 1.0.020

				_Verb_Add_TdhTabPage = new System.ComponentModel.Design.DesignerVerb(						// 1.0.021
					"Add TdhTabPage",																		// 1.0.021
					new System.EventHandler(OnAdd_TdhTabPage)												// 1.0.021
					);																						// 1.0.021
				_Verb_Add_TabPage = new System.ComponentModel.Design.DesignerVerb(							// 1.0.021
					"Add TabPage",																			// 1.0.021
					new System.EventHandler(OnAdd_TabPage)													// 1.0.021
					);																						// 1.0.021
				_Verb_Remove_TabPage = new System.ComponentModel.Design.DesignerVerb(						// 1.0.021
					"Remove Tab",																			// 1.0.021
					new System.EventHandler(OnRemove_TabPage)												// 1.0.021
					);																						// 1.0.021

				_Verbs.AddRange(																			// 1.0.021
					new System.ComponentModel.Design.DesignerVerb[]											// 1.0.021
						{																					// 1.0.021
							_Verb_Add_TdhTabPage, 															// 1.0.021
							_Verb_Add_TabPage,																// 1.0.021
							_Verb_Remove_TabPage															// 1.0.021
						}																					// 1.0.021
					);																						// 1.0.021
				#endregion 
			}																								// 1.0.020
		}																									// 1.0.020

		private void Verbs_Set()																			// 1.0.020
		{																									// 1.0.020
			// Enable/Disable the "Remove Tab" MenuItem														// 1.0.020
			if (_Verb_Remove_TabPage != null)																// 1.0.021
			{																								// 1.0.021
				TDHControls.TDHTabCtl.TdhTabCtl ParentControl = (TDHControls.TDHTabCtl.TdhTabCtl)this.Control;	// 1.0.020
				//switch (ParentControl.TabPages.Count)														// 1.0.020
				switch (ParentControl.TabCount)																// 1.0.020
				{																							// 1.0.020
					case 0:																					// 1.0.020
						//Verbs[2].Enabled = false;															// 1.0.020
						_Verb_Remove_TabPage.Enabled = false;												// 1.0.021
						break;																				// 1.0.020
					default:																				// 1.0.020
						//Verbs[2].Enabled = true;															// 1.0.020
						_Verb_Remove_TabPage.Enabled = true;												// 1.0.021
						break;																				// 1.0.020
				}																							// 1.0.020
			}																								// 1.0.021
		}																									// 1.0.020
		#endregion 


		#region [WndProc(...)] and [GetHitTest(...)] -- Design-time mouse interactivity

		// The code in this section allows design-time selection of the TabControl and individual TabPages	// 1.0.020
		// via mouse-clicks.  When this section of code isn't included in the [TdhTabCtl_Designer] class,	// 1.0.020
		// the class still works, but it doesn't properly interact with the mouse at design-time.			// 1.0.020

		private enum TabControlHitTest																		// 1.0.020
		{																									// 1.0.020
			TCHT_NOWHERE = 1,																				// 1.0.020
			TCHT_ONITEMICON = 2,																			// 1.0.020
			TCHT_ONITEMLABEL = 4,																			// 1.0.020
			TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL												// 1.0.020
		}

		private struct TCHITTESTINFO																		// 1.0.020
		{																									// 1.0.020
			public System.Drawing.Point pt;																	// 1.0.020
			public TabControlHitTest flags;																	// 1.0.020
		}																									// 1.0.020


		#region Constants
		private const int HTTRANSPARENT = -1;																// 1.0.020
		private const int HTCLIENT = 1;																		// 1.0.020
		private const int TCM_HITTEST = 0x130D;																// 1.0.020
		private const int WM_NCHITTEST = 0x84;																// 1.0.020

//		//internal const int WM_MOUSEMOVE = 0x200;															// 1.0.020
//		internal const int WM_LBUTTONDOWN = 0x0201;															// 1.0.020
//		internal const int WM_LBUTTONUP = 0x0202;															// 1.0.020
//		internal const int WM_LBUTTONDBLCLK = 0x0203;														// 1.0.020
		internal const int WM_RBUTTONDOWN = 0x0204;															// 1.0.020
//		internal const int WM_RBUTTONUP = 0x0205;															// 1.0.020
//		//internal const int WM_RBUTTONDBLCLK = 0x206;														// 1.0.020
//		//internal const int WM_MBUTTONDOWN = 0x207;														// 1.0.020
//		//internal const int WM_MBUTTONUP = 0x208;															// 1.0.020
//		//internal const int WM_MBUTTONDBLCLK = 0x209;														// 1.0.020
//		//internal const int WM_MOUSEWHEEL = 0x20A;		// = 522;	// ???									// 1.0.020
		#endregion 

		protected override void WndProc(ref System.Windows.Forms.Message m)									// 1.0.020
		{																									// 1.0.020
			base.WndProc(ref m);																			// 1.0.020

			if (m.Msg == WM_NCHITTEST)																		// 1.0.020
			{																								// 1.0.020
				// Select TabControl when TabControl clicked outside of TabItem.							// 1.0.020
				if (m.Result.ToInt32() == HTTRANSPARENT)													// 1.0.020
				{																							// 1.0.020
					m.Result = (IntPtr)HTCLIENT;															// 1.0.020
				}																							// 1.0.020
			}																								// 1.0.020
			else																							// 1.0.020
			if (m.Msg == WM_RBUTTONDOWN)																	// 1.0.020
			{																								// 1.0.020
				// The method [Verbs_Set()] isn't executed by the custom [TabControlDesigner] class.		// 1.0.020
				// This is a kludge to achieve almost that by intercepting the mouse right-click			// 1.0.020
				Verbs_Set();																				// 1.0.020
			}																								// 1.0.020
		}																									// 1.0.020


		protected override bool GetHitTest(System.Drawing.Point point)										// 1.0.020
		{																									// 1.0.020
			if (this.SelectionService.PrimarySelection == this.Control)										// 1.0.020
			{																								// 1.0.020
				TCHITTESTINFO hti = new TCHITTESTINFO();													// 1.0.020

				hti.pt = this.Control.PointToClient(point);													// 1.0.020
				hti.flags = 0;																				// 1.0.020

				System.Windows.Forms.Message m = new System.Windows.Forms.Message();						// 1.0.020
				m.HWnd = this.Control.Handle;																// 1.0.020
				m.Msg = TCM_HITTEST;																		// 1.0.020

				IntPtr lparam = System.Runtime.InteropServices.Marshal.AllocHGlobal(System.Runtime.InteropServices.Marshal.SizeOf(hti));	// 1.0.020
				System.Runtime.InteropServices.Marshal.StructureToPtr(hti, lparam, false);					// 1.0.020
				m.LParam = lparam;																			// 1.0.020

				base.WndProc(ref m);																		// 1.0.020
				System.Runtime.InteropServices.Marshal.FreeHGlobal(lparam);									// 1.0.020

				if (m.Result.ToInt32() != -1)																// 1.0.020
				{																							// 1.0.020
					return hti.flags != TabControlHitTest.TCHT_NOWHERE;										// 1.0.020
				}																							// 1.0.020
			}																								// 1.0.020
			return false;																					// 1.0.020
		}																									// 1.0.020
		#endregion 
	}																										// 1.0.020
}																											// 1.0.020