#region using ...
using System;																								// 1.0.002
using System.ComponentModel;																				// 1.0.002
using System.Collections;																					// 1.0.002
using System.Diagnostics;																					// 1.0.002
using System.Windows.Forms;																					// 1.0.002
#endregion 

namespace TDHControls.TDHTabCtl																				// 1.0.002
{																											// 1.0.002
	/// <summary>																							// 1.0.002
	/// Summary description for TdhTabPageControls.															// 1.0.002
	/// </summary>																							// 1.0.002
	[System.ComponentModel.ToolboxItem(false)]																// 1.0.002
	public class TdhTabPageControls : System.Windows.Forms.Control.ControlCollection						// 1.0.002
	{																										// 1.0.002
		#region pseudo-[Component Designer generated instantiation of components]

		/// <summary>																						// 1.0.002
		/// Required designer variable.																		// 1.0.002
		/// </summary>																						// 1.0.002
		private System.ComponentModel.Container components = null;											// 1.0.002

		#endregion 

		#region pseudo-[Component Designer generated code]
		/// <summary>																						// 1.0.002
		/// Required method for Designer support - do not modify											// 1.0.002
		/// the contents of this method with the code editor.												// 1.0.002
		/// </summary>																						// 1.0.002
		private void InitializeComponent()																	// 1.0.002
		{																									// 1.0.002
			components = new System.ComponentModel.Container();												// 1.0.002
		}																									// 1.0.002
		#endregion
	

		#region Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]
		private bool gblRunModeIs_DebugMode = false;														// 1.0.000
		private bool gblRunModeIs_DesignMode = true;														// 1.0.000

		private void Initialize_gblRunModeIs()																// 1.0.000
		{																									// 1.0.000
			#region Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]
			gblRunModeIs_DebugMode = System.Diagnostics.Debugger.IsAttached;								// 1.0.000

			//gblRunModeIs_DesignMode = false;																// 1.0.000
			//try						// the try-catch method can detect 'DesignMode' in the Constructor	// 1.0.000
			//{																								// 1.0.000
			//	//string dummy = System.Reflection.Assembly.GetEntryAssembly().Location.ToString();			// 1.0.000
			//	string dummy = System.Reflection.Assembly.GetEntryAssembly().FullName;						// 1.0.000
			//}																								// 1.0.000
			//catch (System.NullReferenceException ex)														// 1.0.000
			//{																								// 1.0.000
			//	gblRunModeIs_DesignMode = true;																// 1.0.000
			//}																								// 1.0.000

			// In the Constructor, [this.DesignMode] always returns false.									// 1.0.000
			// Also, [this.DesignMode] is applicable only to the class that actually invokes it.			// 1.0.000
			// Thus, in the code of the base class, it will return false.									// 1.0.000
			//gblRunModeIs_DesignMode = this.DesignMode;													// 1.0.000

			// Determine whether the class is in DesignMode by examining the .ProcessName of the current Process	// 1.0.000
			if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower() == "devenv")			// 1.0.000
			{																								// 1.0.000
				gblRunModeIs_DesignMode = true;																// 1.0.000
			}																								// 1.0.000
			else																							// 1.0.000
			{																								// 1.0.000
				gblRunModeIs_DesignMode = false;															// 1.0.000
			}																								// 1.0.000
			#endregion
		}																									// 1.0.000
		#endregion 

		#region Private Fields and Properties 
		private TDHTabCtl.TdhTabCtl _owner = null;															// 1.0.002
		#endregion 

		#region Class Constructor (and Dispose)
		// public TdhTabPageControls(TDHControls.TDHTabCtl.TdhTabCtl owner)
		//     : base((System.Windows.Forms.Control)owner)
		// 
		// protected void Dispose( bool disposing )
		// 
		public TdhTabPageControls(TDHControls.TDHTabCtl.TdhTabCtl owner)									// 1.0.002
			: base((System.Windows.Forms.Control)owner)														// 1.0.002
		{																									// 1.0.002
			Initialize_gblRunModeIs();		// Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]	// 1.0.000

			_owner = owner;																					// 1.0.002
		}																									// 1.0.002


		/// <summary>																						// 1.0.002
		/// Clean up any resources being used.																// 1.0.002
		/// </summary>																						// 1.0.002
		//protected override void Dispose( bool disposing )													// 1.0.002
		protected void Dispose( bool disposing )															// 1.0.002
		{																									// 1.0.002
			if( disposing )																					// 1.0.002
			{																								// 1.0.002
				if(components != null)																		// 1.0.002
				{																							// 1.0.002
					components.Dispose();																	// 1.0.002
				}																							// 1.0.002
			}																								// 1.0.002
			//base.Dispose( disposing );																	// 1.0.002
		}																									// 1.0.002
		#endregion 

		#region New/Override Properties
		// public new System.Windows.Forms.Control this[int index]
		// public new int Count {get}
		// public new bool IsReadOnly {get}
		//
		// the .Item (.TabPage) indexer
		public new System.Windows.Forms.Control this[int index]												// 1.0.002
		{																									// 1.0.002
			get																								// 1.0.002
			{																								// 1.0.002
				int idx = 0;																				// 1.0.002
				if (index > 0)																				// 1.0.002
				{																							// 1.0.002
					idx = index;																			// 1.0.002
				}																							// 1.0.002
				if (idx >= this.Count)																		// 1.0.002
				{																							// 1.0.002
					idx = this.Count - 1;																	// 1.0.002
				}																							// 1.0.002

				if (idx < 0)																				// 1.0.002
				{																							// 1.0.002
					return null;																			// 1.0.002
				}																							// 1.0.002
				return (base[idx] as System.Windows.Forms.Control);											// 1.0.002
			}																								// 1.0.002
		}																									// 1.0.002

		//public new int Count																				// 1.0.002
		//{																									// 1.0.002
		//	get { return base.Count; }																		// 1.0.002
		//}																									// 1.0.002
		//
		//public new bool IsReadOnly																			// 1.0.002
		//{																									// 1.0.002
		//	get { return base.IsReadOnly; }																	// 1.0.002
		//}																									// 1.0.002
		#endregion 

		#region New/Override and Novel Methods/Functions 
		// public override void Add(System.Windows.Forms.Control control)
		// public override void AddRange(System.Windows.Forms.Control[] controls)
		//     public new void AddRange(params System.Windows.Forms.Control[] controls)
		// 
		public override void Add(System.Windows.Forms.Control control)										// 1.0.002
		{																									// 1.0.002
//			if( (control.GetType() == typeof(TDHTabCtl.TdhTabPage))											// 1.0.002
//			|| control.GetType().IsSubclassOf(typeof(TDHTabCtl.TdhTabPage))									// 1.0.002
//			)																								// 1.0.002
//			{																								// 1.0.002
//				_owner.TabPages.Add((TDHTabCtl.TdhTabPage)control);											// 1.0.002
//			}																								// 1.0.002
//			else																							// 1.0.002
//			{																								// 1.0.002
//				base.Add(control);																			// 1.0.002
//			}																								// 1.0.002

			if( (control.GetType() == typeof(System.Windows.Forms.TabPage))									// 1.0.020
			|| control.GetType().IsSubclassOf(typeof(System.Windows.Forms.TabPage)) 						// 1.0.020
			)																								// 1.0.020
			{																								// 1.0.020
				_owner.TabPages.Add((System.Windows.Forms.TabPage)control);									// 1.0.020
			}																								// 1.0.020

		}																									// 1.0.002

		//public new void AddRange(params System.Windows.Forms.Control[] controls)							// 1.0.002
		public override void AddRange(System.Windows.Forms.Control[] controls)								// 1.0.020
		{																									// 1.0.002
			foreach (System.Windows.Forms.Control _control in controls)										// 1.0.002
			{																								// 1.0.002
				//if( (_control.GetType() == typeof(TDHTabCtl.TdhTabPage))									// 1.0.002
				//|| control.GetType().IsSubclassOf(typeof(TDHTabCtl.TdhTabPage))							// 1.0.002
				//)																							// 1.0.002
				//{																							// 1.0.002
				//	_owner.TabPages.Add((TDHTabCtl.TdhTabPage)_control);									// 1.0.002
				//}																							// 1.0.002
				//else																						// 1.0.002
				//{																							// 1.0.002
				//	base.Add(control);																		// 1.0.002
				//}																							// 1.0.002
				this.Add(_control);																			// 1.0.002
			}																								// 1.0.002
		}																									// 1.0.002
		#endregion 
	}																										// 1.0.002
}																											// 1.0.002