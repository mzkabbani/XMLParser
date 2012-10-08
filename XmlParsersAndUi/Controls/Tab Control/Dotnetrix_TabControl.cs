// This code was posted in a comment here:
//   "Adding custom TabPages at design time" http://bytes.com/forum/thread576709.html

// I've set this codefile's BuildAction = "None"  
// It's still included in the project because it's bare-bones.  That is, since the classes in this 
// codefile don't include much extra, it's relatively easy to study the code and concepts related to 
// building good custom TabControl and TabPage controls and getting them to behave themselves in 
// the Visual Studio IDE.

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;

namespace Dotnetrix.Examples
{
	[Designer(typeof(MyTabControlDesigner))]
	public class MyTabControl : System.Windows.Forms.TabControl
	{
		[Editor(typeof(MyTabPageCollectionEditor), typeof(UITypeEditor))]
		public new TabPageCollection TabPages
		{
			get
			{
				return base.TabPages;
			}
		}

		internal class MyTabPageCollectionEditor : CollectionEditor
		{
			protected override CollectionEditor.CollectionForm CreateCollectionForm()
			{
				CollectionForm baseForm = base.CreateCollectionForm();
				baseForm.Text = "MyTabPage Collection Editor";
				return baseForm;
			}

			public MyTabPageCollectionEditor(System.Type type) : base(type)
			{
			}

			protected override Type CreateCollectionItemType()
			{
				return typeof(RandomColorTabPage);
			}

			protected override Type[] CreateNewItemTypes()
			{
				return new Type[] { typeof(TabPage),
									  typeof(RandomColorTabPage) };
			}
		}
	}


	[Designer(typeof(System.Windows.Forms.Design.ScrollableControlDesigner))]
	public class TabPage : System.Windows.Forms.TabPage
	{
		public TabPage() : base()
		{
		}
	}


	public class RandomColorTabPage : TabPage
	{
		public RandomColorTabPage() : base()
		{
			this.BackColor = RandomColor();
		}

		private static Random ColorRandomizer = new Random();

		private System.Drawing.Color RandomColor()
		{
			return System.Drawing.Color.FromArgb(ColorRandomizer.Next (256),
				ColorRandomizer.Next(256),
				ColorRandomizer.Next(256));
		}
	}


	internal class MyTabControlDesigner : System.Windows.Forms.Design.ParentControlDesigner
	{

		#region Private Instance Variables

		private DesignerVerbCollection m_verbs = new DesignerVerbCollection();
		private IDesignerHost m_DesignerHost;
		private ISelectionService m_SelectionService;

		#endregion

		public MyTabControlDesigner() : base()
		{
			DesignerVerb verb1 = new DesignerVerb("Add Tab", new EventHandler(OnAddPage));
			DesignerVerb verb2 = new DesignerVerb("Remove Tab", new EventHandler(OnRemovePage));
			m_verbs.AddRange(new DesignerVerb[] { verb1, verb2 });
		}

		#region Properties

		public override DesignerVerbCollection Verbs
		{
			get
			{
				if (m_verbs.Count == 2)
				{
					MyTabControl MyControl = (MyTabControl)Control;
					if (MyControl.TabCount > 0)
					{
						m_verbs[1].Enabled = true;
					}
					else
					{
						m_verbs[1].Enabled = false;
					}
				}
				return m_verbs;
			}
		}

		public IDesignerHost DesignerHost
		{
			get
			{
				if (m_DesignerHost == null)
					m_DesignerHost =
						(IDesignerHost)(GetService(typeof(IDesignerHost))) ;

				return m_DesignerHost;
			}
		}

		public ISelectionService SelectionService
		{
			get
			{
				if (m_SelectionService == null)
				{
					m_SelectionService = (ISelectionService)(this.GetService(typeof(ISelectionService)));
				}
				return m_SelectionService;
			}
		}


		#endregion

		void OnAddPage(Object sender, EventArgs e)
		{
			MyTabControl ParentControl = (MyTabControl)Control;
			System.Windows.Forms.Control.ControlCollection oldTabs =
				ParentControl.Controls;

			RaiseComponentChanging(TypeDescriptor.GetProperties(ParentControl)["TabPages"]);

			System.Windows.Forms.TabPage P =
				(System.Windows.Forms.TabPage)(DesignerHost.CreateComponent(typeof(TabPage)));
			P.Text = P.Name;
			ParentControl.TabPages.Add(P);

			RaiseComponentChanged(TypeDescriptor.GetProperties (ParentControl)["TabPages"],
				oldTabs, ParentControl.TabPages);
			ParentControl.SelectedTab = P;

			SetVerbs();

		}

		void OnRemovePage(Object sender, EventArgs e)
		{
			MyTabControl ParentControl = (MyTabControl)Control;
			System.Windows.Forms.Control.ControlCollection oldTabs =
				ParentControl.Controls;

			if (ParentControl.SelectedIndex < 0) return;

			RaiseComponentChanging(TypeDescriptor.GetProperties(ParentControl)["TabPages"]);

			DesignerHost.DestroyComponent(ParentControl.TabPages[ParentControl.SelectedIndex]);

			RaiseComponentChanged(TypeDescriptor.GetProperties (ParentControl)["TabPages"],
				oldTabs, ParentControl.TabPages);

			SelectionService.SetSelectedComponents(
				new IComponent[] {ParentControl}, 
//SelectionTypes.Auto
				SelectionTypes.Normal 
				);

			SetVerbs();

		}


		private void SetVerbs()
		{
			MyTabControl ParentControl = (MyTabControl)Control;

			switch (ParentControl.TabPages.Count)
			{
				case 0:
					Verbs[1].Enabled = false;
					break;
				default:
					Verbs[1].Enabled = true;
					break;
			}
		}


		
		private const int WM_NCHITTEST = 0x84;

		private const int HTTRANSPARENT = -1;
		private const int HTCLIENT = 1;

		protected override void WndProc(ref System.Windows.Forms.Message m)
		{
			base.WndProc(ref m);
			if (m.Msg == WM_NCHITTEST)
			{
				//select tabcontrol when Tabcontrol clicked outside of TabItem.
				if (m.Result.ToInt32() == HTTRANSPARENT)
				{
					m.Result = (IntPtr)HTCLIENT;
				}
			}

		}

		private enum TabControlHitTest
		{
			TCHT_NOWHERE = 1,
			TCHT_ONITEMICON = 2,
			TCHT_ONITEMLABEL = 4,
			TCHT_ONITEM = TCHT_ONITEMICON | TCHT_ONITEMLABEL
		}

		private const int TCM_HITTEST = 0x130D;

		private struct TCHITTESTINFO
		{
			public System.Drawing.Point pt;
			public TabControlHitTest flags;
		}

		protected override bool GetHitTest(System.Drawing.Point point)
		{
			if (this.SelectionService.PrimarySelection == this.Control)
			{
				TCHITTESTINFO hti = new TCHITTESTINFO();

				hti.pt = this.Control.PointToClient(point);
				hti.flags = 0;

				System.Windows.Forms.Message m = new
					System.Windows.Forms.Message();
				m.HWnd = this.Control.Handle;
				m.Msg = TCM_HITTEST;

				IntPtr lparam =
					System.Runtime.InteropServices.Marshal.AllocHGlobal(System.Runtime.InteropServices.Marshal.SizeOf(hti));
				System.Runtime.InteropServices.Marshal.StructureToPtr(hti,
				lparam, false);
				m.LParam = lparam;

				base.WndProc(ref m);
				System.Runtime.InteropServices.Marshal.FreeHGlobal (lparam);

				if (m.Result.ToInt32() != -1)
					return hti.flags != TabControlHitTest.TCHT_NOWHERE;

			}

			return false;
		}


		protected override void OnPaintAdornments(System.Windows.Forms.PaintEventArgs pe)
		{
			//Don't want DrawGrid dots.
		}


		//Fix the AllSizable selectionrule on DockStyle.Fill
		public override System.Windows.Forms.Design.SelectionRules SelectionRules
		{
			get
			{
				if (Control.Dock == System.Windows.Forms.DockStyle.Fill)
				{
					return System.Windows.Forms.Design.SelectionRules.Visible;
				}
				return base.SelectionRules;
			}
		}

	}

}
