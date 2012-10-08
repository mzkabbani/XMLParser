#region using ...
using System;																								// 1.0.005
using System.Collections;																					// 1.0.005
using System.Windows.Forms;																					// 1.0.005
#endregion 

namespace XmlParsersAndUi																				// 1.0.005
{																											// 1.0.005
	#region Define EventHandler Delegates Class/Control

	// Enable the [TDHControls.TdhTabCtl] instance to notify the client-code of:					// 1.0.000
	// . TdhTabPage-AddEvent																				// 1.0.001
	// . TdhTabPage-RemoveEvent																				// 1.0.000
	// . TdhTabPage-RenameEvent																				// 1.0.001
    public delegate void TabEventsDelegate(object sender, XmlParsersAndUi.TabEventArgs e);			// 1.0.001

	// . TdhTabPage-ReorderEvent																			// 1.0.003
    public delegate void TabsReorderedEventDelegate(object sender, XmlParsersAndUi.TabsReorderedEventArgs e);	// 1.0.003

	#endregion 

	#region Class:  TabEventArgs : System.EventArgs
	public class TabEventArgs : System.EventArgs															// 1.0.001
	{
		public enum TabEvents																				// 1.0.001
		{																									// 1.0.001
			TabAdded,																						// 1.0.001
			TabAddRejected,																					// 1.0.001
			TabRemoved,																						// 1.0.001
			TabRenamed,																						// 1.0.001
			TabsReordered,																					// 1.0.003
			undefined																						// 1.0.001
		}																									// 1.0.001


		protected int _TabIndex = -1;
		protected int _oldTabIndex = -1;																	// 1.0.003
		protected System.Windows.Forms.TabPage _TabPage = null;												// 1.0.010
		protected TabEventArgs.TabEvents _TabEvent = TabEventArgs.TabEvents.undefined;	// 1.0.001

		#region Class Constructore
		public TabEventArgs()																				// 1.0.003
		{																									// 1.0.003
		}																									// 1.0.003

		public TabEventArgs(
			int theTabIndex, 
			TabEventArgs.TabEvents theTabEvent)													// 1.0.001
		{
			this._TabIndex = theTabIndex;
			this._TabEvent = theTabEvent;																	// 1.0.001
		}

		public TabEventArgs(																				// 1.0.010
			System.Windows.Forms.TabPage theTabPage, 														// 1.0.010
			TabEventArgs.TabEvents theTabEvent)													// 1.0.010
		{																									// 1.0.010
			this._TabPage = theTabPage;																		// 1.0.010
			this._TabEvent = theTabEvent;																	// 1.0.010
		}																									// 1.0.010

		public TabEventArgs(																				// 1.0.001
			TdhTabPage theTabPage, 																// 1.0.001
			TabEventArgs.TabEvents theTabEvent)													// 1.0.001
		{																									// 1.0.001
			this._TabPage = theTabPage;																		// 1.0.001
			this._TabEvent = theTabEvent;																	// 1.0.001
		}																									// 1.0.001

		public TabEventArgs(																				// 1.0.010
			int theTabIndex,																				// 1.0.010
			System.Windows.Forms.TabPage theTabPage,														// 1.0.010
			TabEventArgs.TabEvents theTabEvent)													// 1.0.010
		{																									// 1.0.010
			this._TabIndex = theTabIndex;																	// 1.0.010
			this._TabPage = theTabPage;																		// 1.0.010
			this._TabEvent = theTabEvent;																	// 1.0.010
		}																									// 1.0.010

		public TabEventArgs(																				// 1.0.001
			int theTabIndex,																				// 1.0.001
			TdhTabPage theTabPage,																// 1.0.001
			TabEventArgs.TabEvents theTabEvent)													// 1.0.001
		{																									// 1.0.001
			this._TabIndex = theTabIndex;																	// 1.0.001
			this._TabPage = theTabPage;																		// 1.0.001
			this._TabEvent = theTabEvent;																	// 1.0.001
		}																									// 1.0.001

		public TabEventArgs(																				// 1.0.010
			int theNewTabIndex, int theOldTabIndex, 														// 1.0.010
			System.Windows.Forms.TabPage theTabPage,														// 1.0.010
			TabEventArgs.TabEvents theTabEvent)													// 1.0.010
		{																									// 1.0.010
			this._TabIndex = theNewTabIndex;																// 1.0.010
			this._oldTabIndex = theOldTabIndex;																// 1.0.010
			this._TabPage = theTabPage;																		// 1.0.010
			this._TabEvent = theTabEvent;																	// 1.0.010
		}																									// 1.0.010

		public TabEventArgs(																				// 1.0.003
			int theNewTabIndex, int theOldTabIndex, 														// 1.0.003
			TdhTabPage theTabPage,																// 1.0.003
			TabEventArgs.TabEvents theTabEvent)													// 1.0.003
		{																									// 1.0.003
			this._TabIndex = theNewTabIndex;																// 1.0.003
			this._oldTabIndex = theOldTabIndex;																// 1.0.003
			this._TabPage = theTabPage;																		// 1.0.003
			this._TabEvent = theTabEvent;																	// 1.0.003
		}																									// 1.0.003
		#endregion 

		/// <summary>
		/// Get/Set the tab index value where the close button is clicked
		/// </summary>
		public int TabIndex 
		{
			get {return this._TabIndex;}
		}

		public int TabIndexNew																				// 1.0.003
		{																									// 1.0.003
			get {return this._TabIndex;}																	// 1.0.003
		}																									// 1.0.003

		public int TabIndexOld																				// 1.0.003
		{																									// 1.0.003
			get {return this._oldTabIndex;}																	// 1.0.003
		}																									// 1.0.003


		public bool TabPage_IsTdhTabPage																	// 1.0.010
		{																									// 1.0.010
			get																								// 1.0.010
			{																								// 1.0.010
				if( (this._TabPage != null)																	// 1.0.010
				&&( (this._TabPage.GetType() == typeof(TdhTabPage))								// 1.0.010
					|| this._TabPage.GetType().IsSubclassOf(typeof(TdhTabPage))					// 1.0.010
					)																						// 1.0.010
				)																							// 1.0.010
				{																							// 1.0.010
					return true;																			// 1.0.010
				}																							// 1.0.010
				return false;																				// 1.0.010
			}																								// 1.0.010
		}																									// 1.0.010

		public System.Windows.Forms.TabPage TabPage															// 1.0.010
		{																									// 1.0.001
			get {return this._TabPage;}																		// 1.0.001
		}																									// 1.0.001

		public TdhTabPage TdhTabPage																// 1.0.010
		{																									// 1.0.010
			get																								// 1.0.010
			{																								// 1.0.010
				if( (this._TabPage != null)																	// 1.0.010
				&&( (this._TabPage.GetType() == typeof(TdhTabPage))								// 1.0.010
					|| this._TabPage.GetType().IsSubclassOf(typeof(TdhTabPage))					// 1.0.010
					)																						// 1.0.010
				)																							// 1.0.010
				{																							// 1.0.010
					return (TdhTabPage)this._TabPage;												// 1.0.010
				}																							// 1.0.010
				return null;																				// 1.0.010
			}																								// 1.0.010
		}																									// 1.0.010


		public TabEventArgs.TabEvents TabEvent													// 1.0.001
		{																									// 1.0.001
			get {return this._TabEvent;}																	// 1.0.001
		}																									// 1.0.001
	}
	#endregion 

	#region Class:  TabsReorderedEventArgs : TabEventArgs
	public class TabsReorderedEventArgs : TabEventArgs											// 1.0.003
	{
		protected System.Collections.ArrayList _alTabOrder = new System.Collections.ArrayList();			// 1.0.003

		public TabsReorderedEventArgs()																		// 1.0.003
			: base(-1, -1, null, TabEventArgs.TabEvents.TabsReordered)							// 1.0.003
		{																									// 1.0.003
		}																									// 1.0.003

		public TabsReorderedEventArgs(System.Collections.ArrayList alTabOrder)								// 1.0.003
			: base(-1, -1, null, TabEventArgs.TabEvents.TabsReordered)							// 1.0.003
		{																									// 1.0.003
			if (alTabOrder != null) 																		// 1.0.003
			{																								// 1.0.003
				this._alTabOrder = alTabOrder;																// 1.0.003
			}																								// 1.0.003
		}																									// 1.0.003

		public TabsReorderedEventArgs(int[] intTabOrder)													// 1.0.003
			: base(-1, -1, null, TabEventArgs.TabEvents.TabsReordered)							// 1.0.003
		{																									// 1.0.003
			if( (intTabOrder != null)																		// 1.0.003
			&& (intTabOrder.Length > 0) )																	// 1.0.003
			{																								// 1.0.003
				this._alTabOrder = new System.Collections.ArrayList(intTabOrder.Length);					// 1.0.003
				this._alTabOrder.AddRange(intTabOrder);														// 1.0.003
			}																								// 1.0.003
		}																									// 1.0.003



		public System.Collections.ArrayList TabOrder														// 1.0.003
		{																									// 1.0.003
			get {return this._alTabOrder;}																	// 1.0.003
		}																									// 1.0.003

		public int[] TabOrder_int																			// 1.0.003
		{																									// 1.0.003
			get																								// 1.0.003
			{																								// 1.0.003
				if (this._alTabOrder.Count > 0)																// 1.0.003
				{																							// 1.0.003
					return (int[])this._alTabOrder.ToArray(typeof(int));									// 1.0.003
				}																							// 1.0.003
				return new int[]{};																			// 1.0.003
			}																								// 1.0.003
		}																									// 1.0.003
	}
	#endregion 
}																											// 1.0.005