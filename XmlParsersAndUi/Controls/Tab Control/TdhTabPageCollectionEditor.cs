#region using ...
using System;																								// 1.0.020
using System.ComponentModel;																				// 1.0.020
using System.ComponentModel.Design;																			// 1.0.020
using System.Windows.Forms;																					// 1.0.020
#endregion 

namespace XmlParsersAndUi																				// 1.0.020
{																											// 1.0.020
	// internal class TdhTabPageCollectionEditor : System.ComponentModel.Design.CollectionEditor
	// internal class TabPageCollectionEditor : System.ComponentModel.Design.CollectionEditor
	// 
	#region [ internal class TdhTabPageCollectionEditor : System.ComponentModel.Design.CollectionEditor ]
	// The code for the [TdhTabPageCollectionEditor] class is based on code posted in a comment here:		// 1.0.020
	//   "Adding custom TabPages at design time" http://bytes.com/forum/thread576709.html					// 1.0.020

	internal class TdhTabPageCollectionEditor : System.ComponentModel.Design.CollectionEditor				// 1.0.020
	{																										// 1.0.020
		public TdhTabPageCollectionEditor(System.Type type) : base(type)									// 1.0.020
		{																									// 1.0.020
		}																									// 1.0.020

		protected override System.ComponentModel.Design.CollectionEditor.CollectionForm CreateCollectionForm()	// 1.0.020
		{																									// 1.0.020
			CollectionForm baseForm = base.CreateCollectionForm();											// 1.0.020
			baseForm.Text = "TdhTabPage Collection Editor";													// 1.0.020
			return baseForm;																				// 1.0.020
		}																									// 1.0.020

		protected override System.Type CreateCollectionItemType()											// 1.0.020
		{																									// 1.0.020
			return typeof(XmlParsersAndUi.TdhTabPage);												// 1.0.020
		}																									// 1.0.020

		protected override System.Type[] CreateNewItemTypes()												// 1.0.020
		{																									// 1.0.020
			return new System.Type[] {																		// 1.0.020
										typeof(XmlParsersAndUi.TdhTabPage), 							// 1.0.020
										typeof(System.Windows.Forms.TabPage)								// 1.0.020
									 };																		// 1.0.020
		}																									// 1.0.020
	}																										// 1.0.020
	#endregion 
		
	#region [ internal class TabPageCollectionEditor : System.ComponentModel.Design.CollectionEditor ]
	// The code for the [TabPageCollectionEditor] class is based on code posted in a comment here:			// 1.0.020
	//   "Adding custom TabPages at design time" http://bytes.com/forum/thread576709.html					// 1.0.020

	internal class TabPageCollectionEditor : System.ComponentModel.Design.CollectionEditor					// 1.0.020
	{																										// 1.0.020
		public TabPageCollectionEditor(System.Type type) : base(type)										// 1.0.020
		{																									// 1.0.020
		}																									// 1.0.020

		protected override System.ComponentModel.Design.CollectionEditor.CollectionForm CreateCollectionForm()	// 1.0.020
		{																									// 1.0.020
			CollectionForm baseForm = base.CreateCollectionForm();											// 1.0.020
			baseForm.Text = "TabPage Collection Editor";													// 1.0.020
			return baseForm;																				// 1.0.020
		}																									// 1.0.020

		protected override System.Type CreateCollectionItemType()											// 1.0.020
		{																									// 1.0.020
			return typeof(System.Windows.Forms.TabPage); 													// 1.0.020
		}																									// 1.0.020

		protected override System.Type[] CreateNewItemTypes()												// 1.0.020
		{																									// 1.0.020
			return new System.Type[] {																		// 1.0.020
										typeof(System.Windows.Forms.TabPage), 								// 1.0.020
										typeof(XmlParsersAndUi.TdhTabPage)							// 1.0.020
									 };																		// 1.0.020
		}																									// 1.0.020
	}																										// 1.0.020
	#endregion 
}																											// 1.0.020