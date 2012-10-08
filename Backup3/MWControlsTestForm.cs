using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using MWControls;
using MWCommon;

/// <summary>
///	Mikael Wiberg 2003
///		mikwib@hotmail.com (usual HoTMaiL spam filters)
///		mick@ar.com.au (heavy spam filters on, harldy anything gets through, START the subject with C# and it will probably go through)
///		md5mw@mdstud.chalmers.se (heavy spam filters on, harldy anything gets through, START the subject with C# and it will probably go through)
///	
///	Feel free to use this code as you wish, as long as you do not take credit for it yourself.
///	If it is used in commercial projects or applications please mention my name.
///	Feel free to donate any amount of money if this code makes you happy ;)
///	Use this code at your own risk. If your machine blows up while using it - don't blame me.
/// </summary>
namespace MWControlsTest
{
	/// <summary>
	/// Summary description for MWControlsTestForm.
	/// </summary>
	public class MWControlsTestForm : System.Windows.Forms.Form
	{
		#region Variables

		private System.Windows.Forms.TabPage tpMWLabel;
		private System.Windows.Forms.TabPage tpMWScrollLabel;
		private MWControls.MWLabel mwlblTL;
		private System.Windows.Forms.Button btMWLabelEnable;
		private MWControls.MWLabel mwlblTC;
		private MWControls.MWLabel mwlblTR;
		private MWControls.MWLabel mwlblML;
		private MWControls.MWLabel mwlblMC;
		private MWControls.MWLabel mwlblMR;
		private MWControls.MWLabel mwlblBL;
		private MWControls.MWLabel mwlblBC;
		private MWControls.MWLabel mwlblBR;
		private System.Windows.Forms.Button btMWLabelText;
		private System.Windows.Forms.TextBox tbMWLabelText;
		private System.Windows.Forms.Button btMWScrollLabelEnable;
		private System.Windows.Forms.Button btMWScrollLabelText;
		private System.Windows.Forms.TextBox tbMWScrollLabelText;
		private MWControls.MWScrollLabel mwslblTL;
		private MWControls.MWScrollLabel mwslblTC;
		private MWControls.MWScrollLabel mwslblTR;
		private MWControls.MWScrollLabel mwslblML;
		private MWControls.MWScrollLabel mwslblMC;
		private MWControls.MWScrollLabel mwslblMR;
		private MWControls.MWScrollLabel mwslblBL;
		private MWControls.MWScrollLabel mwslblBC;
		private MWControls.MWScrollLabel mwslblBR;
		private System.Windows.Forms.TabPage tpMWLabelDir;
		private System.Windows.Forms.Button btMWLabelN;
		private System.Windows.Forms.Button btMWLabelU;
		private System.Windows.Forms.Button btMWLabelL;
		private System.Windows.Forms.Button btMWLabelR;
		private MWControls.MWLabel mwlblDir;
		private MWControls.MWScrollLabel mwslblDir;
		private System.Windows.Forms.Button btMWLabelDirR;
		private System.Windows.Forms.Button btMWLabelDirL;
		private System.Windows.Forms.Button btMWLabelDirU;
		private System.Windows.Forms.Button btMWLabelDirN;
		private System.Windows.Forms.Button btMWLabelDirTL;
		private System.Windows.Forms.Button btMWLabelDirTC;
		private System.Windows.Forms.Button btMWLabelDirTR;
		private System.Windows.Forms.Button btMWLabelDirML;
		private System.Windows.Forms.Button btMWLabelDirMC;
		private System.Windows.Forms.Button btMWLabelDirMR;
		private System.Windows.Forms.Button btMWLabelDirBL;
		private System.Windows.Forms.Button btMWLabelDirBC;
		private System.Windows.Forms.Button btMWLabelDirBR;
		private System.Windows.Forms.Button btMWLabelDirUp;
		private System.Windows.Forms.Button btMWLabelDirLeft;
		private System.Windows.Forms.Button btMWLabelDirRight;
		private System.Windows.Forms.Button btMWLabelDirDown;
		private System.Windows.Forms.Button btMWLabelDirSwitch;
		private System.Windows.Forms.Button btMWLabelDirEnable;
		private System.Windows.Forms.Button btMWLabelDirText;
		private System.Windows.Forms.TextBox tbMWLabelDirText;
		private System.Windows.Forms.ToolTip ttMWLabelDir;
		private System.Windows.Forms.Button btMWLabelDirSFE;
		private System.Windows.Forms.Button btMWScrollLabelR;
		private System.Windows.Forms.Button btMWScrollLabelL;
		private System.Windows.Forms.Button btMWScrollLabelU;
		private System.Windows.Forms.Button btMWScrollLabelN;
		private System.Windows.Forms.TabControl tcMWControls;
		private System.Windows.Forms.Label lblMWLabelDir;
		private System.Windows.Forms.TabPage tpMWTreeView;
		private System.Windows.Forms.TreeView tvMWTreeView;
		private System.Windows.Forms.CheckBox cbMWTreeViewFullRowSelect;
		private System.Windows.Forms.CheckBox cbMWTreeViewCheckBoxes;
		private MWControls.MWTreeView mwtvMWTreeView;
		private System.Windows.Forms.CheckBox cbMWTreeViewLabelEdit;
		private System.Windows.Forms.CheckBox cbMWTreeViewHideSelection;
		private System.Windows.Forms.CheckBox cbMWTreeViewScrollable;
		private System.Windows.Forms.CheckBox cbMWTreeViewScrollToSelNode;
		private System.Windows.Forms.CheckBox cbMWTreeViewAllowBlankNodeText;
		private System.Windows.Forms.CheckBox cbMWTreeViewAllowNoSelNode;
		private System.Windows.Forms.ImageList ilMWTreeView;
		private System.Windows.Forms.CheckBox cbMWTreeViewUseImageList;
		private System.Windows.Forms.CheckBox cbMWTreeViewShowRootLines;
		private System.Windows.Forms.CheckBox cbMWTreeViewHotTracking;
		private System.Windows.Forms.CheckBox cbMWTreeViewAllowMultiCheck;
		private System.Windows.Forms.ComboBox cobMWTreeViewMultiSelect;
		private System.Windows.Forms.Label lblMWTreeViewTreeView;
		private System.Windows.Forms.Label lblMWTreeViewMWTreeView;
		private System.Windows.Forms.GroupBox gbMWTreeViewCombined;
		private System.Windows.Forms.GroupBox gbMWTreeViewMWTreeView;
		private System.Windows.Forms.Label lblMWTreeViewMultiSelect;
		private System.Windows.Forms.TabPage tpMWCheckBox;
		private System.Windows.Forms.ComboBox cobMWCheckBoxAppearance;
		private System.Windows.Forms.Label lblMWCheckBoxAppearance;
		private MWControls.MWCheckBox mwcbMWCheckBox;
		private System.Windows.Forms.CheckBox cbMWCheckBox;
		private System.Windows.Forms.ComboBox cobMWCheckBoxCheckAlign;
		private System.Windows.Forms.Label lblMWCheckBoxCheckAlign;
		private System.Windows.Forms.ComboBox cobMWCheckBoxFlatStyle;
		private System.Windows.Forms.Label lblMWCheckBoxFlatStyle;
		private System.Windows.Forms.CheckBox cbMWCheckBoxUseImage;
		private System.Windows.Forms.ComboBox cobMWCheckBoxImageAlign;
		private System.Windows.Forms.Label lblMWCheckBoxImageAlign;
		private System.Windows.Forms.ComboBox cobMWCheckBoxTextAlign;
		private System.Windows.Forms.Label lblMWCheckBoxTextAlign;
		private System.Windows.Forms.CheckBox cbMWCheckBoxThreeState;
		private System.Windows.Forms.GroupBox gbMWCheckBoxCombined;
		private System.Windows.Forms.GroupBox gbMWCheckBoxMWCheckBox;
		private System.Windows.Forms.CheckBox cbMWCheckBoxRightToLeft;
		private System.Windows.Forms.ComboBox cobMWCheckBoxStringFormat;
		private System.Windows.Forms.Label lblMWCheckBoxStringFormat;
		private System.Windows.Forms.ComboBox cobMWCheckBoxTextDir;
		private System.Windows.Forms.Label lblMWCheckBoxTextDir;
		private System.Windows.Forms.Label lblMWCheckBoxCheckBox;
		private System.Windows.Forms.Label lblMWCheckBoxMWCheckBox;
		private System.Windows.Forms.CheckBox cbMWTreeViewAllowRubberbandSelect;
		private System.Windows.Forms.TextBox tbMWTreeViewLabelEditRegEx;
		private MWControls.MWScrollLabel lblMWTreeViewLabelEditRegEx;
		private System.Windows.Forms.CheckBox cobMWTreeViewUseLabelEditRegEx;
		private MWControls.MWScrollLabel lblMWTreeViewDisallowLabelEditRegEx;
		private System.Windows.Forms.TextBox tbMWTreeViewDisallowLabelEditRegEx;
		private System.Windows.Forms.CheckBox cobMWTreeViewUseDisallowLabelEditRegEx;
		private MWControls.MWScrollLabel lblMWTreeViewSelectNodeRegEx;
		private System.Windows.Forms.TextBox tbMWTreeViewSelectNodeRegEx;
		private System.Windows.Forms.CheckBox cobMWTreeViewUseSelectNodeRegEx;
		private MWControls.MWScrollLabel lblMWTreeViewCheckNodeRegEx;
		private System.Windows.Forms.TextBox tbMWTreeViewCheckNodeRegEx;
		private System.Windows.Forms.CheckBox cobMWTreeViewUseCheckNodeRegEx;
		private System.Windows.Forms.Button btMWTreeViewToggleSelNodes;
		private System.Windows.Forms.Button btMWTreeViewClearSelNodes;
		private System.Windows.Forms.Button btMWTreeViewSaveSelNodes;
		private System.Windows.Forms.Button btMWTreeViewLoadSelNodes;
		private System.Windows.Forms.Button btMWTreeViewClearNodes;
		private System.Windows.Forms.Button btMWTreeViewSaveNodes;
		private System.Windows.Forms.Button btMWTreeViewLoadNodes;
		private System.Windows.Forms.Button btMWTreeViewToggleNodes;
		private System.Windows.Forms.Button btMWTreeViewRecreateNodes;
		private System.Windows.Forms.Button btMWTreeViewAddNodes;
		private System.Windows.Forms.GroupBox gbMWTreeViewCommands;
		private System.Windows.Forms.Button btMWTreeViewRemoveNode0;
		private System.Windows.Forms.CheckBox cbMWCheckBoxEnabled;
		private System.Windows.Forms.ComboBox cobMWCheckBoxCheckBoxPaintOrder;
		private System.Windows.Forms.Label lblMWCheckBoxCheckBoxPaintOrder;
		private System.Windows.Forms.Label lblMWCheckBoxMessage;

		private System.ComponentModel.IContainer components;

		#endregion Variables



		#region Constructor, Dispose and Main

		public MWControlsTestForm()
		{
			this.SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);
			this.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
			this.SetStyle(System.Windows.Forms.ControlStyles.ResizeRedraw, true);
			this.SetStyle(System.Windows.Forms.ControlStyles.Selectable, true);
			this.SetStyle(System.Windows.Forms.ControlStyles.SupportsTransparentBackColor, true);
			this.SetStyle(System.Windows.Forms.ControlStyles.UserPaint, true);

			InitializeComponent();

			tpMWCheckBox.Enabled = false;
			tcMWControls.TabPages.Remove(tpMWCheckBox);
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

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.Run(new MWControlsTestForm());
		}

		#endregion Constructor, Dispose and Main



		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MWControlsTestForm));
			this.tcMWControls = new System.Windows.Forms.TabControl();
			this.tpMWLabel = new System.Windows.Forms.TabPage();
			this.btMWLabelR = new System.Windows.Forms.Button();
			this.btMWLabelL = new System.Windows.Forms.Button();
			this.btMWLabelU = new System.Windows.Forms.Button();
			this.btMWLabelN = new System.Windows.Forms.Button();
			this.mwlblBR = new MWControls.MWLabel();
			this.mwlblBC = new MWControls.MWLabel();
			this.mwlblMR = new MWControls.MWLabel();
			this.mwlblMC = new MWControls.MWLabel();
			this.mwlblML = new MWControls.MWLabel();
			this.mwlblTR = new MWControls.MWLabel();
			this.btMWLabelEnable = new System.Windows.Forms.Button();
			this.btMWLabelText = new System.Windows.Forms.Button();
			this.tbMWLabelText = new System.Windows.Forms.TextBox();
			this.mwlblTL = new MWControls.MWLabel();
			this.mwlblTC = new MWControls.MWLabel();
			this.mwlblBL = new MWControls.MWLabel();
			this.tpMWLabelDir = new System.Windows.Forms.TabPage();
			this.lblMWLabelDir = new System.Windows.Forms.Label();
			this.btMWLabelDirSFE = new System.Windows.Forms.Button();
			this.tbMWLabelDirText = new System.Windows.Forms.TextBox();
			this.btMWLabelDirText = new System.Windows.Forms.Button();
			this.btMWLabelDirEnable = new System.Windows.Forms.Button();
			this.btMWLabelDirSwitch = new System.Windows.Forms.Button();
			this.btMWLabelDirDown = new System.Windows.Forms.Button();
			this.btMWLabelDirRight = new System.Windows.Forms.Button();
			this.btMWLabelDirLeft = new System.Windows.Forms.Button();
			this.btMWLabelDirUp = new System.Windows.Forms.Button();
			this.btMWLabelDirBR = new System.Windows.Forms.Button();
			this.btMWLabelDirBC = new System.Windows.Forms.Button();
			this.btMWLabelDirBL = new System.Windows.Forms.Button();
			this.btMWLabelDirMR = new System.Windows.Forms.Button();
			this.btMWLabelDirMC = new System.Windows.Forms.Button();
			this.btMWLabelDirML = new System.Windows.Forms.Button();
			this.btMWLabelDirTR = new System.Windows.Forms.Button();
			this.btMWLabelDirTC = new System.Windows.Forms.Button();
			this.btMWLabelDirTL = new System.Windows.Forms.Button();
			this.btMWLabelDirR = new System.Windows.Forms.Button();
			this.btMWLabelDirL = new System.Windows.Forms.Button();
			this.btMWLabelDirU = new System.Windows.Forms.Button();
			this.btMWLabelDirN = new System.Windows.Forms.Button();
			this.mwlblDir = new MWControls.MWLabel();
			this.mwslblDir = new MWControls.MWScrollLabel();
			this.tpMWScrollLabel = new System.Windows.Forms.TabPage();
			this.btMWScrollLabelR = new System.Windows.Forms.Button();
			this.btMWScrollLabelL = new System.Windows.Forms.Button();
			this.btMWScrollLabelU = new System.Windows.Forms.Button();
			this.btMWScrollLabelN = new System.Windows.Forms.Button();
			this.mwslblBR = new MWControls.MWScrollLabel();
			this.mwslblBC = new MWControls.MWScrollLabel();
			this.mwslblBL = new MWControls.MWScrollLabel();
			this.mwslblMR = new MWControls.MWScrollLabel();
			this.mwslblMC = new MWControls.MWScrollLabel();
			this.mwslblML = new MWControls.MWScrollLabel();
			this.mwslblTR = new MWControls.MWScrollLabel();
			this.mwslblTC = new MWControls.MWScrollLabel();
			this.mwslblTL = new MWControls.MWScrollLabel();
			this.btMWScrollLabelEnable = new System.Windows.Forms.Button();
			this.btMWScrollLabelText = new System.Windows.Forms.Button();
			this.tbMWScrollLabelText = new System.Windows.Forms.TextBox();
			this.tpMWTreeView = new System.Windows.Forms.TabPage();
			this.gbMWTreeViewCommands = new System.Windows.Forms.GroupBox();
			this.btMWTreeViewRemoveNode0 = new System.Windows.Forms.Button();
			this.btMWTreeViewClearSelNodes = new System.Windows.Forms.Button();
			this.btMWTreeViewAddNodes = new System.Windows.Forms.Button();
			this.btMWTreeViewClearNodes = new System.Windows.Forms.Button();
			this.btMWTreeViewToggleNodes = new System.Windows.Forms.Button();
			this.btMWTreeViewLoadSelNodes = new System.Windows.Forms.Button();
			this.btMWTreeViewRecreateNodes = new System.Windows.Forms.Button();
			this.btMWTreeViewSaveSelNodes = new System.Windows.Forms.Button();
			this.btMWTreeViewSaveNodes = new System.Windows.Forms.Button();
			this.btMWTreeViewToggleSelNodes = new System.Windows.Forms.Button();
			this.btMWTreeViewLoadNodes = new System.Windows.Forms.Button();
			this.gbMWTreeViewMWTreeView = new System.Windows.Forms.GroupBox();
			this.lblMWTreeViewCheckNodeRegEx = new MWControls.MWScrollLabel();
			this.tbMWTreeViewCheckNodeRegEx = new System.Windows.Forms.TextBox();
			this.cobMWTreeViewUseCheckNodeRegEx = new System.Windows.Forms.CheckBox();
			this.lblMWTreeViewSelectNodeRegEx = new MWControls.MWScrollLabel();
			this.tbMWTreeViewSelectNodeRegEx = new System.Windows.Forms.TextBox();
			this.cobMWTreeViewUseSelectNodeRegEx = new System.Windows.Forms.CheckBox();
			this.lblMWTreeViewDisallowLabelEditRegEx = new MWControls.MWScrollLabel();
			this.tbMWTreeViewDisallowLabelEditRegEx = new System.Windows.Forms.TextBox();
			this.cobMWTreeViewUseDisallowLabelEditRegEx = new System.Windows.Forms.CheckBox();
			this.lblMWTreeViewLabelEditRegEx = new MWControls.MWScrollLabel();
			this.tbMWTreeViewLabelEditRegEx = new System.Windows.Forms.TextBox();
			this.cbMWTreeViewAllowRubberbandSelect = new System.Windows.Forms.CheckBox();
			this.cbMWTreeViewAllowNoSelNode = new System.Windows.Forms.CheckBox();
			this.cbMWTreeViewScrollToSelNode = new System.Windows.Forms.CheckBox();
			this.cbMWTreeViewAllowMultiCheck = new System.Windows.Forms.CheckBox();
			this.cobMWTreeViewMultiSelect = new System.Windows.Forms.ComboBox();
			this.cbMWTreeViewAllowBlankNodeText = new System.Windows.Forms.CheckBox();
			this.lblMWTreeViewMultiSelect = new System.Windows.Forms.Label();
			this.cobMWTreeViewUseLabelEditRegEx = new System.Windows.Forms.CheckBox();
			this.gbMWTreeViewCombined = new System.Windows.Forms.GroupBox();
			this.cbMWTreeViewHideSelection = new System.Windows.Forms.CheckBox();
			this.cbMWTreeViewCheckBoxes = new System.Windows.Forms.CheckBox();
			this.cbMWTreeViewLabelEdit = new System.Windows.Forms.CheckBox();
			this.cbMWTreeViewFullRowSelect = new System.Windows.Forms.CheckBox();
			this.cbMWTreeViewShowRootLines = new System.Windows.Forms.CheckBox();
			this.cbMWTreeViewHotTracking = new System.Windows.Forms.CheckBox();
			this.cbMWTreeViewUseImageList = new System.Windows.Forms.CheckBox();
			this.cbMWTreeViewScrollable = new System.Windows.Forms.CheckBox();
			this.lblMWTreeViewTreeView = new System.Windows.Forms.Label();
			this.mwtvMWTreeView = new MWControls.MWTreeView();
			this.ilMWTreeView = new System.Windows.Forms.ImageList(this.components);
			this.tvMWTreeView = new System.Windows.Forms.TreeView();
			this.lblMWTreeViewMWTreeView = new System.Windows.Forms.Label();
			this.tpMWCheckBox = new System.Windows.Forms.TabPage();
			this.lblMWCheckBoxMWCheckBox = new System.Windows.Forms.Label();
			this.lblMWCheckBoxCheckBox = new System.Windows.Forms.Label();
			this.gbMWCheckBoxMWCheckBox = new System.Windows.Forms.GroupBox();
			this.cobMWCheckBoxCheckBoxPaintOrder = new System.Windows.Forms.ComboBox();
			this.lblMWCheckBoxCheckBoxPaintOrder = new System.Windows.Forms.Label();
			this.cobMWCheckBoxTextDir = new System.Windows.Forms.ComboBox();
			this.lblMWCheckBoxTextDir = new System.Windows.Forms.Label();
			this.cobMWCheckBoxStringFormat = new System.Windows.Forms.ComboBox();
			this.lblMWCheckBoxStringFormat = new System.Windows.Forms.Label();
			this.mwcbMWCheckBox = new MWControls.MWCheckBox();
			this.cbMWCheckBox = new System.Windows.Forms.CheckBox();
			this.gbMWCheckBoxCombined = new System.Windows.Forms.GroupBox();
			this.cbMWCheckBoxEnabled = new System.Windows.Forms.CheckBox();
			this.cbMWCheckBoxRightToLeft = new System.Windows.Forms.CheckBox();
			this.cbMWCheckBoxThreeState = new System.Windows.Forms.CheckBox();
			this.cobMWCheckBoxTextAlign = new System.Windows.Forms.ComboBox();
			this.lblMWCheckBoxTextAlign = new System.Windows.Forms.Label();
			this.cobMWCheckBoxImageAlign = new System.Windows.Forms.ComboBox();
			this.lblMWCheckBoxImageAlign = new System.Windows.Forms.Label();
			this.cbMWCheckBoxUseImage = new System.Windows.Forms.CheckBox();
			this.cobMWCheckBoxFlatStyle = new System.Windows.Forms.ComboBox();
			this.lblMWCheckBoxFlatStyle = new System.Windows.Forms.Label();
			this.cobMWCheckBoxCheckAlign = new System.Windows.Forms.ComboBox();
			this.lblMWCheckBoxCheckAlign = new System.Windows.Forms.Label();
			this.cobMWCheckBoxAppearance = new System.Windows.Forms.ComboBox();
			this.lblMWCheckBoxAppearance = new System.Windows.Forms.Label();
			this.ttMWLabelDir = new System.Windows.Forms.ToolTip(this.components);
			this.lblMWCheckBoxMessage = new System.Windows.Forms.Label();
			this.tcMWControls.SuspendLayout();
			this.tpMWLabel.SuspendLayout();
			this.tpMWLabelDir.SuspendLayout();
			this.tpMWScrollLabel.SuspendLayout();
			this.tpMWTreeView.SuspendLayout();
			this.gbMWTreeViewCommands.SuspendLayout();
			this.gbMWTreeViewMWTreeView.SuspendLayout();
			this.gbMWTreeViewCombined.SuspendLayout();
			this.tpMWCheckBox.SuspendLayout();
			this.gbMWCheckBoxMWCheckBox.SuspendLayout();
			this.gbMWCheckBoxCombined.SuspendLayout();
			this.SuspendLayout();
			// 
			// tcMWControls
			// 
			this.tcMWControls.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tcMWControls.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.tpMWLabel,
																					   this.tpMWLabelDir,
																					   this.tpMWScrollLabel,
																					   this.tpMWTreeView,
																					   this.tpMWCheckBox});
			this.tcMWControls.Location = new System.Drawing.Point(8, 8);
			this.tcMWControls.Name = "tcMWControls";
			this.tcMWControls.SelectedIndex = 0;
			this.tcMWControls.Size = new System.Drawing.Size(696, 664);
			this.tcMWControls.TabIndex = 0;
			// 
			// tpMWLabel
			// 
			this.tpMWLabel.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.btMWLabelR,
																					this.btMWLabelL,
																					this.btMWLabelU,
																					this.btMWLabelN,
																					this.mwlblBR,
																					this.mwlblBC,
																					this.mwlblMR,
																					this.mwlblMC,
																					this.mwlblML,
																					this.mwlblTR,
																					this.btMWLabelEnable,
																					this.btMWLabelText,
																					this.tbMWLabelText,
																					this.mwlblTL,
																					this.mwlblTC,
																					this.mwlblBL});
			this.tpMWLabel.Location = new System.Drawing.Point(4, 22);
			this.tpMWLabel.Name = "tpMWLabel";
			this.tpMWLabel.Size = new System.Drawing.Size(688, 638);
			this.tpMWLabel.TabIndex = 0;
			this.tpMWLabel.Text = "MWLabel";
			// 
			// btMWLabelR
			// 
			this.btMWLabelR.Location = new System.Drawing.Point(224, 112);
			this.btMWLabelR.Name = "btMWLabelR";
			this.btMWLabelR.Size = new System.Drawing.Size(24, 23);
			this.btMWLabelR.TabIndex = 13;
			this.btMWLabelR.Text = "R";
			this.btMWLabelR.Click += new System.EventHandler(this.btMWLabelR_Click);
			// 
			// btMWLabelL
			// 
			this.btMWLabelL.Location = new System.Drawing.Point(224, 88);
			this.btMWLabelL.Name = "btMWLabelL";
			this.btMWLabelL.Size = new System.Drawing.Size(24, 23);
			this.btMWLabelL.TabIndex = 12;
			this.btMWLabelL.Text = "L";
			this.btMWLabelL.Click += new System.EventHandler(this.btMWLabelL_Click);
			// 
			// btMWLabelU
			// 
			this.btMWLabelU.Location = new System.Drawing.Point(224, 64);
			this.btMWLabelU.Name = "btMWLabelU";
			this.btMWLabelU.Size = new System.Drawing.Size(24, 23);
			this.btMWLabelU.TabIndex = 11;
			this.btMWLabelU.Text = "U";
			this.btMWLabelU.Click += new System.EventHandler(this.btMWLabelU_Click);
			// 
			// btMWLabelN
			// 
			this.btMWLabelN.Location = new System.Drawing.Point(224, 40);
			this.btMWLabelN.Name = "btMWLabelN";
			this.btMWLabelN.Size = new System.Drawing.Size(24, 23);
			this.btMWLabelN.TabIndex = 10;
			this.btMWLabelN.Text = "N";
			this.btMWLabelN.Click += new System.EventHandler(this.btMWLabelN_Click);
			// 
			// mwlblBR
			// 
			this.mwlblBR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwlblBR.Location = new System.Drawing.Point(152, 184);
			this.mwlblBR.Name = "mwlblBR";
			this.mwlblBR.Size = new System.Drawing.Size(64, 64);
			this.mwlblBR.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwlblBR.TabIndex = 9;
			this.mwlblBR.Text = "abcd";
			this.mwlblBR.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			// 
			// mwlblBC
			// 
			this.mwlblBC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwlblBC.Location = new System.Drawing.Point(80, 184);
			this.mwlblBC.Name = "mwlblBC";
			this.mwlblBC.Size = new System.Drawing.Size(64, 64);
			this.mwlblBC.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwlblBC.TabIndex = 8;
			this.mwlblBC.Text = "abcd";
			this.mwlblBC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// mwlblMR
			// 
			this.mwlblMR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwlblMR.Location = new System.Drawing.Point(152, 112);
			this.mwlblMR.Name = "mwlblMR";
			this.mwlblMR.Size = new System.Drawing.Size(64, 64);
			this.mwlblMR.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwlblMR.TabIndex = 7;
			this.mwlblMR.Text = "abcd";
			this.mwlblMR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// mwlblMC
			// 
			this.mwlblMC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwlblMC.Location = new System.Drawing.Point(80, 112);
			this.mwlblMC.Name = "mwlblMC";
			this.mwlblMC.Size = new System.Drawing.Size(64, 64);
			this.mwlblMC.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwlblMC.TabIndex = 6;
			this.mwlblMC.Text = "abcd";
			this.mwlblMC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// mwlblML
			// 
			this.mwlblML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwlblML.Location = new System.Drawing.Point(8, 112);
			this.mwlblML.Name = "mwlblML";
			this.mwlblML.Size = new System.Drawing.Size(64, 64);
			this.mwlblML.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwlblML.TabIndex = 5;
			this.mwlblML.Text = "abcd";
			this.mwlblML.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// mwlblTR
			// 
			this.mwlblTR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwlblTR.Location = new System.Drawing.Point(152, 40);
			this.mwlblTR.Name = "mwlblTR";
			this.mwlblTR.Size = new System.Drawing.Size(64, 64);
			this.mwlblTR.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwlblTR.TabIndex = 4;
			this.mwlblTR.Text = "abcd";
			this.mwlblTR.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btMWLabelEnable
			// 
			this.btMWLabelEnable.Location = new System.Drawing.Point(168, 8);
			this.btMWLabelEnable.Name = "btMWLabelEnable";
			this.btMWLabelEnable.Size = new System.Drawing.Size(48, 23);
			this.btMWLabelEnable.TabIndex = 3;
			this.btMWLabelEnable.Text = "Enable";
			this.btMWLabelEnable.Click += new System.EventHandler(this.btMWLabelEnable_Click);
			// 
			// btMWLabelText
			// 
			this.btMWLabelText.Location = new System.Drawing.Point(120, 8);
			this.btMWLabelText.Name = "btMWLabelText";
			this.btMWLabelText.Size = new System.Drawing.Size(40, 23);
			this.btMWLabelText.TabIndex = 2;
			this.btMWLabelText.Text = "Text";
			this.btMWLabelText.Click += new System.EventHandler(this.btMWLabelText_Click);
			// 
			// tbMWLabelText
			// 
			this.tbMWLabelText.Location = new System.Drawing.Point(8, 8);
			this.tbMWLabelText.Name = "tbMWLabelText";
			this.tbMWLabelText.Size = new System.Drawing.Size(104, 20);
			this.tbMWLabelText.TabIndex = 1;
			this.tbMWLabelText.Text = "abcdefghijklmnopqrstuvwxyz";
			// 
			// mwlblTL
			// 
			this.mwlblTL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwlblTL.Location = new System.Drawing.Point(8, 40);
			this.mwlblTL.Name = "mwlblTL";
			this.mwlblTL.Size = new System.Drawing.Size(64, 64);
			this.mwlblTL.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwlblTL.TabIndex = 0;
			this.mwlblTL.Text = "abcd";
			// 
			// mwlblTC
			// 
			this.mwlblTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwlblTC.Location = new System.Drawing.Point(80, 40);
			this.mwlblTC.Name = "mwlblTC";
			this.mwlblTC.Size = new System.Drawing.Size(64, 64);
			this.mwlblTC.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwlblTC.TabIndex = 0;
			this.mwlblTC.Text = "abcd";
			this.mwlblTC.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// mwlblBL
			// 
			this.mwlblBL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwlblBL.Location = new System.Drawing.Point(8, 184);
			this.mwlblBL.Name = "mwlblBL";
			this.mwlblBL.Size = new System.Drawing.Size(64, 64);
			this.mwlblBL.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwlblBL.TabIndex = 1;
			this.mwlblBL.Text = "abcd";
			this.mwlblBL.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// tpMWLabelDir
			// 
			this.tpMWLabelDir.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.lblMWLabelDir,
																					   this.btMWLabelDirSFE,
																					   this.tbMWLabelDirText,
																					   this.btMWLabelDirText,
																					   this.btMWLabelDirEnable,
																					   this.btMWLabelDirSwitch,
																					   this.btMWLabelDirDown,
																					   this.btMWLabelDirRight,
																					   this.btMWLabelDirLeft,
																					   this.btMWLabelDirUp,
																					   this.btMWLabelDirBR,
																					   this.btMWLabelDirBC,
																					   this.btMWLabelDirBL,
																					   this.btMWLabelDirMR,
																					   this.btMWLabelDirMC,
																					   this.btMWLabelDirML,
																					   this.btMWLabelDirTR,
																					   this.btMWLabelDirTC,
																					   this.btMWLabelDirTL,
																					   this.btMWLabelDirR,
																					   this.btMWLabelDirL,
																					   this.btMWLabelDirU,
																					   this.btMWLabelDirN,
																					   this.mwlblDir,
																					   this.mwslblDir});
			this.tpMWLabelDir.Location = new System.Drawing.Point(4, 22);
			this.tpMWLabelDir.Name = "tpMWLabelDir";
			this.tpMWLabelDir.Size = new System.Drawing.Size(688, 638);
			this.tpMWLabelDir.TabIndex = 2;
			this.tpMWLabelDir.Text = "MWLabelDir";
			// 
			// lblMWLabelDir
			// 
			this.lblMWLabelDir.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblMWLabelDir.Location = new System.Drawing.Point(224, 8);
			this.lblMWLabelDir.Name = "lblMWLabelDir";
			this.lblMWLabelDir.Size = new System.Drawing.Size(456, 23);
			this.lblMWLabelDir.TabIndex = 36;
			this.lblMWLabelDir.Text = "MWLabel";
			this.lblMWLabelDir.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// btMWLabelDirSFE
			// 
			this.btMWLabelDirSFE.Location = new System.Drawing.Point(224, 32);
			this.btMWLabelDirSFE.Name = "btMWLabelDirSFE";
			this.btMWLabelDirSFE.Size = new System.Drawing.Size(48, 23);
			this.btMWLabelDirSFE.TabIndex = 35;
			this.btMWLabelDirSFE.Text = "SFE";
			this.btMWLabelDirSFE.Click += new System.EventHandler(this.btMWLabelDirSFE_Click);
			// 
			// tbMWLabelDirText
			// 
			this.tbMWLabelDirText.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tbMWLabelDirText.Location = new System.Drawing.Point(64, 64);
			this.tbMWLabelDirText.Name = "tbMWLabelDirText";
			this.tbMWLabelDirText.Size = new System.Drawing.Size(616, 20);
			this.tbMWLabelDirText.TabIndex = 34;
			this.tbMWLabelDirText.Text = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
			// 
			// btMWLabelDirText
			// 
			this.btMWLabelDirText.Location = new System.Drawing.Point(8, 64);
			this.btMWLabelDirText.Name = "btMWLabelDirText";
			this.btMWLabelDirText.Size = new System.Drawing.Size(48, 23);
			this.btMWLabelDirText.TabIndex = 33;
			this.btMWLabelDirText.Text = "Text";
			this.btMWLabelDirText.Click += new System.EventHandler(this.btMWLabelDirText_Click);
			// 
			// btMWLabelDirEnable
			// 
			this.btMWLabelDirEnable.Location = new System.Drawing.Point(112, 32);
			this.btMWLabelDirEnable.Name = "btMWLabelDirEnable";
			this.btMWLabelDirEnable.Size = new System.Drawing.Size(48, 23);
			this.btMWLabelDirEnable.TabIndex = 32;
			this.btMWLabelDirEnable.Text = "Enable";
			this.btMWLabelDirEnable.Click += new System.EventHandler(this.btMWLabelDirEnable_Click);
			// 
			// btMWLabelDirSwitch
			// 
			this.btMWLabelDirSwitch.Location = new System.Drawing.Point(64, 32);
			this.btMWLabelDirSwitch.Name = "btMWLabelDirSwitch";
			this.btMWLabelDirSwitch.Size = new System.Drawing.Size(48, 23);
			this.btMWLabelDirSwitch.TabIndex = 31;
			this.btMWLabelDirSwitch.Text = "Switch";
			this.ttMWLabelDir.SetToolTip(this.btMWLabelDirSwitch, "Switch between displaying an MWLabel and an MWScrollLabel.");
			this.btMWLabelDirSwitch.Click += new System.EventHandler(this.btMWLabelDirSwitch_Click);
			// 
			// btMWLabelDirDown
			// 
			this.btMWLabelDirDown.Location = new System.Drawing.Point(24, 40);
			this.btMWLabelDirDown.Name = "btMWLabelDirDown";
			this.btMWLabelDirDown.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirDown.TabIndex = 30;
			this.btMWLabelDirDown.Text = "v";
			this.btMWLabelDirDown.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btMWLabelDirDown.Click += new System.EventHandler(this.btMWLabelDirDown_Click);
			// 
			// btMWLabelDirRight
			// 
			this.btMWLabelDirRight.Location = new System.Drawing.Point(40, 24);
			this.btMWLabelDirRight.Name = "btMWLabelDirRight";
			this.btMWLabelDirRight.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirRight.TabIndex = 29;
			this.btMWLabelDirRight.Text = ">";
			this.btMWLabelDirRight.Click += new System.EventHandler(this.btMWLabelDirRight_Click);
			// 
			// btMWLabelDirLeft
			// 
			this.btMWLabelDirLeft.Location = new System.Drawing.Point(8, 24);
			this.btMWLabelDirLeft.Name = "btMWLabelDirLeft";
			this.btMWLabelDirLeft.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirLeft.TabIndex = 28;
			this.btMWLabelDirLeft.Text = "<";
			this.btMWLabelDirLeft.Click += new System.EventHandler(this.btMWLabelDirLeft_Click);
			// 
			// btMWLabelDirUp
			// 
			this.btMWLabelDirUp.Location = new System.Drawing.Point(24, 8);
			this.btMWLabelDirUp.Name = "btMWLabelDirUp";
			this.btMWLabelDirUp.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirUp.TabIndex = 27;
			this.btMWLabelDirUp.Text = "^";
			this.btMWLabelDirUp.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.btMWLabelDirUp.Click += new System.EventHandler(this.btMWLabelDirUp_Click);
			// 
			// btMWLabelDirBR
			// 
			this.btMWLabelDirBR.Location = new System.Drawing.Point(200, 40);
			this.btMWLabelDirBR.Name = "btMWLabelDirBR";
			this.btMWLabelDirBR.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirBR.TabIndex = 26;
			this.btMWLabelDirBR.Click += new System.EventHandler(this.btMWLabelDirBR_Click);
			// 
			// btMWLabelDirBC
			// 
			this.btMWLabelDirBC.Location = new System.Drawing.Point(184, 40);
			this.btMWLabelDirBC.Name = "btMWLabelDirBC";
			this.btMWLabelDirBC.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirBC.TabIndex = 25;
			this.btMWLabelDirBC.Click += new System.EventHandler(this.btMWLabelDirBC_Click);
			// 
			// btMWLabelDirBL
			// 
			this.btMWLabelDirBL.Location = new System.Drawing.Point(168, 40);
			this.btMWLabelDirBL.Name = "btMWLabelDirBL";
			this.btMWLabelDirBL.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirBL.TabIndex = 24;
			this.btMWLabelDirBL.Click += new System.EventHandler(this.btMWLabelDirBL_Click);
			// 
			// btMWLabelDirMR
			// 
			this.btMWLabelDirMR.Location = new System.Drawing.Point(200, 24);
			this.btMWLabelDirMR.Name = "btMWLabelDirMR";
			this.btMWLabelDirMR.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirMR.TabIndex = 23;
			this.btMWLabelDirMR.Click += new System.EventHandler(this.btMWLabelDirMR_Click);
			// 
			// btMWLabelDirMC
			// 
			this.btMWLabelDirMC.Location = new System.Drawing.Point(184, 24);
			this.btMWLabelDirMC.Name = "btMWLabelDirMC";
			this.btMWLabelDirMC.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirMC.TabIndex = 22;
			this.btMWLabelDirMC.Click += new System.EventHandler(this.btMWLabelDirMC_Click);
			// 
			// btMWLabelDirML
			// 
			this.btMWLabelDirML.Location = new System.Drawing.Point(168, 24);
			this.btMWLabelDirML.Name = "btMWLabelDirML";
			this.btMWLabelDirML.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirML.TabIndex = 21;
			this.btMWLabelDirML.Click += new System.EventHandler(this.btMWLabelDirML_Click);
			// 
			// btMWLabelDirTR
			// 
			this.btMWLabelDirTR.Location = new System.Drawing.Point(200, 8);
			this.btMWLabelDirTR.Name = "btMWLabelDirTR";
			this.btMWLabelDirTR.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirTR.TabIndex = 20;
			this.btMWLabelDirTR.Click += new System.EventHandler(this.btMWLabelDirTR_Click);
			// 
			// btMWLabelDirTC
			// 
			this.btMWLabelDirTC.Location = new System.Drawing.Point(184, 8);
			this.btMWLabelDirTC.Name = "btMWLabelDirTC";
			this.btMWLabelDirTC.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirTC.TabIndex = 19;
			this.btMWLabelDirTC.Click += new System.EventHandler(this.btMWLabelDirTC_Click);
			// 
			// btMWLabelDirTL
			// 
			this.btMWLabelDirTL.Location = new System.Drawing.Point(168, 8);
			this.btMWLabelDirTL.Name = "btMWLabelDirTL";
			this.btMWLabelDirTL.Size = new System.Drawing.Size(16, 16);
			this.btMWLabelDirTL.TabIndex = 18;
			this.btMWLabelDirTL.Text = "x";
			this.btMWLabelDirTL.Click += new System.EventHandler(this.btMWLabelDirTL_Click);
			// 
			// btMWLabelDirR
			// 
			this.btMWLabelDirR.Location = new System.Drawing.Point(136, 8);
			this.btMWLabelDirR.Name = "btMWLabelDirR";
			this.btMWLabelDirR.Size = new System.Drawing.Size(24, 23);
			this.btMWLabelDirR.TabIndex = 17;
			this.btMWLabelDirR.Text = "R";
			this.btMWLabelDirR.Click += new System.EventHandler(this.btMWLabelDirR_Click);
			// 
			// btMWLabelDirL
			// 
			this.btMWLabelDirL.Location = new System.Drawing.Point(112, 8);
			this.btMWLabelDirL.Name = "btMWLabelDirL";
			this.btMWLabelDirL.Size = new System.Drawing.Size(24, 23);
			this.btMWLabelDirL.TabIndex = 16;
			this.btMWLabelDirL.Text = "L";
			this.btMWLabelDirL.Click += new System.EventHandler(this.btMWLabelDirL_Click);
			// 
			// btMWLabelDirU
			// 
			this.btMWLabelDirU.Location = new System.Drawing.Point(88, 8);
			this.btMWLabelDirU.Name = "btMWLabelDirU";
			this.btMWLabelDirU.Size = new System.Drawing.Size(24, 23);
			this.btMWLabelDirU.TabIndex = 15;
			this.btMWLabelDirU.Text = "U";
			this.btMWLabelDirU.Click += new System.EventHandler(this.btMWLabelDirU_Click);
			// 
			// btMWLabelDirN
			// 
			this.btMWLabelDirN.Location = new System.Drawing.Point(64, 8);
			this.btMWLabelDirN.Name = "btMWLabelDirN";
			this.btMWLabelDirN.Size = new System.Drawing.Size(24, 23);
			this.btMWLabelDirN.TabIndex = 14;
			this.btMWLabelDirN.Text = "N";
			this.btMWLabelDirN.Click += new System.EventHandler(this.btMWLabelDirN_Click);
			// 
			// mwlblDir
			// 
			this.mwlblDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwlblDir.ForeColor = System.Drawing.SystemColors.ControlText;
			this.mwlblDir.Location = new System.Drawing.Point(8, 96);
			this.mwlblDir.Name = "mwlblDir";
			this.mwlblDir.Size = new System.Drawing.Size(216, 216);
			this.mwlblDir.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwlblDir.TabIndex = 0;
			this.mwlblDir.Text = "abcdefghijklmnopqrstuvwxyz";
			// 
			// mwslblDir
			// 
			this.mwslblDir.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwslblDir.Location = new System.Drawing.Point(8, 96);
			this.mwslblDir.Name = "mwslblDir";
			this.mwslblDir.Size = new System.Drawing.Size(216, 216);
			this.mwslblDir.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwslblDir.TabIndex = 0;
			this.mwslblDir.Text = "abcdefghijklmnopqrstuvwxyz";
			this.mwslblDir.Visible = false;
			this.mwslblDir.MouseLeave += new System.EventHandler(this.mwslblDir_MouseLeave);
			this.mwslblDir.MouseEnter += new System.EventHandler(this.mwslblDir_MouseEnter);
			// 
			// tpMWScrollLabel
			// 
			this.tpMWScrollLabel.Controls.AddRange(new System.Windows.Forms.Control[] {
																						  this.btMWScrollLabelR,
																						  this.btMWScrollLabelL,
																						  this.btMWScrollLabelU,
																						  this.btMWScrollLabelN,
																						  this.mwslblBR,
																						  this.mwslblBC,
																						  this.mwslblBL,
																						  this.mwslblMR,
																						  this.mwslblMC,
																						  this.mwslblML,
																						  this.mwslblTR,
																						  this.mwslblTC,
																						  this.mwslblTL,
																						  this.btMWScrollLabelEnable,
																						  this.btMWScrollLabelText,
																						  this.tbMWScrollLabelText});
			this.tpMWScrollLabel.Location = new System.Drawing.Point(4, 22);
			this.tpMWScrollLabel.Name = "tpMWScrollLabel";
			this.tpMWScrollLabel.Size = new System.Drawing.Size(688, 638);
			this.tpMWScrollLabel.TabIndex = 1;
			this.tpMWScrollLabel.Text = "MWScrollLabel";
			// 
			// btMWScrollLabelR
			// 
			this.btMWScrollLabelR.Location = new System.Drawing.Point(224, 112);
			this.btMWScrollLabelR.Name = "btMWScrollLabelR";
			this.btMWScrollLabelR.Size = new System.Drawing.Size(24, 23);
			this.btMWScrollLabelR.TabIndex = 19;
			this.btMWScrollLabelR.Text = "R";
			this.btMWScrollLabelR.Click += new System.EventHandler(this.btMWScrollLabelR_Click);
			// 
			// btMWScrollLabelL
			// 
			this.btMWScrollLabelL.Location = new System.Drawing.Point(224, 88);
			this.btMWScrollLabelL.Name = "btMWScrollLabelL";
			this.btMWScrollLabelL.Size = new System.Drawing.Size(24, 23);
			this.btMWScrollLabelL.TabIndex = 18;
			this.btMWScrollLabelL.Text = "L";
			this.btMWScrollLabelL.Click += new System.EventHandler(this.btMWScrollLabelL_Click);
			// 
			// btMWScrollLabelU
			// 
			this.btMWScrollLabelU.Location = new System.Drawing.Point(224, 64);
			this.btMWScrollLabelU.Name = "btMWScrollLabelU";
			this.btMWScrollLabelU.Size = new System.Drawing.Size(24, 23);
			this.btMWScrollLabelU.TabIndex = 17;
			this.btMWScrollLabelU.Text = "U";
			this.btMWScrollLabelU.Click += new System.EventHandler(this.btMWScrollLabelU_Click);
			// 
			// btMWScrollLabelN
			// 
			this.btMWScrollLabelN.Location = new System.Drawing.Point(224, 40);
			this.btMWScrollLabelN.Name = "btMWScrollLabelN";
			this.btMWScrollLabelN.Size = new System.Drawing.Size(24, 23);
			this.btMWScrollLabelN.TabIndex = 16;
			this.btMWScrollLabelN.Text = "N";
			this.btMWScrollLabelN.Click += new System.EventHandler(this.btMWScrollLabelN_Click);
			// 
			// mwslblBR
			// 
			this.mwslblBR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwslblBR.Location = new System.Drawing.Point(152, 184);
			this.mwslblBR.Name = "mwslblBR";
			this.mwslblBR.Size = new System.Drawing.Size(64, 64);
			this.mwslblBR.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwslblBR.TabIndex = 15;
			this.mwslblBR.Text = "abcd";
			this.mwslblBR.TextAlign = System.Drawing.ContentAlignment.BottomRight;
			this.mwslblBR.MouseLeave += new System.EventHandler(this.MWScrollLabel_MouseLeave);
			this.mwslblBR.MouseEnter += new System.EventHandler(this.MWScrollLabel_MouseEnter);
			// 
			// mwslblBC
			// 
			this.mwslblBC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwslblBC.Location = new System.Drawing.Point(80, 184);
			this.mwslblBC.Name = "mwslblBC";
			this.mwslblBC.Size = new System.Drawing.Size(64, 64);
			this.mwslblBC.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwslblBC.TabIndex = 14;
			this.mwslblBC.Text = "abcd";
			this.mwslblBC.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			this.mwslblBC.MouseLeave += new System.EventHandler(this.MWScrollLabel_MouseLeave);
			this.mwslblBC.MouseEnter += new System.EventHandler(this.MWScrollLabel_MouseEnter);
			// 
			// mwslblBL
			// 
			this.mwslblBL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwslblBL.Location = new System.Drawing.Point(8, 184);
			this.mwslblBL.Name = "mwslblBL";
			this.mwslblBL.Size = new System.Drawing.Size(64, 64);
			this.mwslblBL.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwslblBL.TabIndex = 13;
			this.mwslblBL.Text = "abcd";
			this.mwslblBL.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			this.mwslblBL.MouseLeave += new System.EventHandler(this.MWScrollLabel_MouseLeave);
			this.mwslblBL.MouseEnter += new System.EventHandler(this.MWScrollLabel_MouseEnter);
			// 
			// mwslblMR
			// 
			this.mwslblMR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwslblMR.Location = new System.Drawing.Point(152, 112);
			this.mwslblMR.Name = "mwslblMR";
			this.mwslblMR.Size = new System.Drawing.Size(64, 64);
			this.mwslblMR.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwslblMR.TabIndex = 12;
			this.mwslblMR.Text = "abcd";
			this.mwslblMR.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.mwslblMR.MouseLeave += new System.EventHandler(this.MWScrollLabel_MouseLeave);
			this.mwslblMR.MouseEnter += new System.EventHandler(this.MWScrollLabel_MouseEnter);
			// 
			// mwslblMC
			// 
			this.mwslblMC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwslblMC.Location = new System.Drawing.Point(80, 112);
			this.mwslblMC.Name = "mwslblMC";
			this.mwslblMC.Size = new System.Drawing.Size(64, 64);
			this.mwslblMC.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwslblMC.TabIndex = 11;
			this.mwslblMC.Text = "abcd";
			this.mwslblMC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.mwslblMC.MouseLeave += new System.EventHandler(this.MWScrollLabel_MouseLeave);
			this.mwslblMC.MouseEnter += new System.EventHandler(this.MWScrollLabel_MouseEnter);
			// 
			// mwslblML
			// 
			this.mwslblML.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwslblML.Location = new System.Drawing.Point(8, 112);
			this.mwslblML.Name = "mwslblML";
			this.mwslblML.Size = new System.Drawing.Size(64, 64);
			this.mwslblML.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwslblML.TabIndex = 10;
			this.mwslblML.Text = "abcd";
			this.mwslblML.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.mwslblML.MouseLeave += new System.EventHandler(this.MWScrollLabel_MouseLeave);
			this.mwslblML.MouseEnter += new System.EventHandler(this.MWScrollLabel_MouseEnter);
			// 
			// mwslblTR
			// 
			this.mwslblTR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwslblTR.Location = new System.Drawing.Point(152, 40);
			this.mwslblTR.Name = "mwslblTR";
			this.mwslblTR.Size = new System.Drawing.Size(64, 64);
			this.mwslblTR.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwslblTR.TabIndex = 9;
			this.mwslblTR.Text = "abcd";
			this.mwslblTR.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.mwslblTR.MouseLeave += new System.EventHandler(this.MWScrollLabel_MouseLeave);
			this.mwslblTR.MouseEnter += new System.EventHandler(this.MWScrollLabel_MouseEnter);
			// 
			// mwslblTC
			// 
			this.mwslblTC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwslblTC.Location = new System.Drawing.Point(80, 40);
			this.mwslblTC.Name = "mwslblTC";
			this.mwslblTC.Size = new System.Drawing.Size(64, 64);
			this.mwslblTC.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwslblTC.TabIndex = 8;
			this.mwslblTC.Text = "abcd";
			this.mwslblTC.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.mwslblTC.MouseLeave += new System.EventHandler(this.MWScrollLabel_MouseLeave);
			this.mwslblTC.MouseEnter += new System.EventHandler(this.MWScrollLabel_MouseEnter);
			// 
			// mwslblTL
			// 
			this.mwslblTL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.mwslblTL.Location = new System.Drawing.Point(8, 40);
			this.mwslblTL.Name = "mwslblTL";
			this.mwslblTL.Size = new System.Drawing.Size(64, 64);
			this.mwslblTL.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwslblTL.TabIndex = 7;
			this.mwslblTL.Text = "abcd";
			this.mwslblTL.MouseLeave += new System.EventHandler(this.MWScrollLabel_MouseLeave);
			this.mwslblTL.MouseEnter += new System.EventHandler(this.MWScrollLabel_MouseEnter);
			// 
			// btMWScrollLabelEnable
			// 
			this.btMWScrollLabelEnable.Location = new System.Drawing.Point(168, 8);
			this.btMWScrollLabelEnable.Name = "btMWScrollLabelEnable";
			this.btMWScrollLabelEnable.Size = new System.Drawing.Size(48, 23);
			this.btMWScrollLabelEnable.TabIndex = 6;
			this.btMWScrollLabelEnable.Text = "Enable";
			this.btMWScrollLabelEnable.Click += new System.EventHandler(this.btMWScrollLabelEnable_Click);
			// 
			// btMWScrollLabelText
			// 
			this.btMWScrollLabelText.Location = new System.Drawing.Point(120, 8);
			this.btMWScrollLabelText.Name = "btMWScrollLabelText";
			this.btMWScrollLabelText.Size = new System.Drawing.Size(40, 23);
			this.btMWScrollLabelText.TabIndex = 5;
			this.btMWScrollLabelText.Text = "Text";
			this.btMWScrollLabelText.Click += new System.EventHandler(this.btMWScrollLabelText_Click);
			// 
			// tbMWScrollLabelText
			// 
			this.tbMWScrollLabelText.Location = new System.Drawing.Point(8, 8);
			this.tbMWScrollLabelText.Name = "tbMWScrollLabelText";
			this.tbMWScrollLabelText.Size = new System.Drawing.Size(104, 20);
			this.tbMWScrollLabelText.TabIndex = 4;
			this.tbMWScrollLabelText.Text = "abcdefghijklmnopqrstuvwxyz";
			// 
			// tpMWTreeView
			// 
			this.tpMWTreeView.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.gbMWTreeViewCommands,
																					   this.gbMWTreeViewMWTreeView,
																					   this.gbMWTreeViewCombined,
																					   this.lblMWTreeViewTreeView,
																					   this.mwtvMWTreeView,
																					   this.tvMWTreeView,
																					   this.lblMWTreeViewMWTreeView});
			this.tpMWTreeView.Location = new System.Drawing.Point(4, 22);
			this.tpMWTreeView.Name = "tpMWTreeView";
			this.tpMWTreeView.Size = new System.Drawing.Size(688, 638);
			this.tpMWTreeView.TabIndex = 3;
			this.tpMWTreeView.Text = "MWTreeView";
			// 
			// gbMWTreeViewCommands
			// 
			this.gbMWTreeViewCommands.Controls.AddRange(new System.Windows.Forms.Control[] {
																							   this.btMWTreeViewRemoveNode0,
																							   this.btMWTreeViewClearSelNodes,
																							   this.btMWTreeViewAddNodes,
																							   this.btMWTreeViewClearNodes,
																							   this.btMWTreeViewToggleNodes,
																							   this.btMWTreeViewLoadSelNodes,
																							   this.btMWTreeViewRecreateNodes,
																							   this.btMWTreeViewSaveSelNodes,
																							   this.btMWTreeViewSaveNodes,
																							   this.btMWTreeViewToggleSelNodes,
																							   this.btMWTreeViewLoadNodes});
			this.gbMWTreeViewCommands.Location = new System.Drawing.Point(320, 8);
			this.gbMWTreeViewCommands.Name = "gbMWTreeViewCommands";
			this.gbMWTreeViewCommands.Size = new System.Drawing.Size(360, 120);
			this.gbMWTreeViewCommands.TabIndex = 23;
			this.gbMWTreeViewCommands.TabStop = false;
			this.gbMWTreeViewCommands.Text = "MWTreeView Commands";
			// 
			// btMWTreeViewRemoveNode0
			// 
			this.btMWTreeViewRemoveNode0.Location = new System.Drawing.Point(240, 72);
			this.btMWTreeViewRemoveNode0.Name = "btMWTreeViewRemoveNode0";
			this.btMWTreeViewRemoveNode0.Size = new System.Drawing.Size(112, 23);
			this.btMWTreeViewRemoveNode0.TabIndex = 23;
			this.btMWTreeViewRemoveNode0.Text = "Remove Node 0";
			this.btMWTreeViewRemoveNode0.Click += new System.EventHandler(this.btMWTreeViewRemoveNode0_Click);
			// 
			// btMWTreeViewClearSelNodes
			// 
			this.btMWTreeViewClearSelNodes.Location = new System.Drawing.Point(8, 40);
			this.btMWTreeViewClearSelNodes.Name = "btMWTreeViewClearSelNodes";
			this.btMWTreeViewClearSelNodes.Size = new System.Drawing.Size(112, 23);
			this.btMWTreeViewClearSelNodes.TabIndex = 16;
			this.btMWTreeViewClearSelNodes.Text = "Clear SelNodes";
			this.btMWTreeViewClearSelNodes.Click += new System.EventHandler(this.btMWTreeViewClearSelNodes_Click);
			// 
			// btMWTreeViewAddNodes
			// 
			this.btMWTreeViewAddNodes.Location = new System.Drawing.Point(240, 40);
			this.btMWTreeViewAddNodes.Name = "btMWTreeViewAddNodes";
			this.btMWTreeViewAddNodes.Size = new System.Drawing.Size(112, 23);
			this.btMWTreeViewAddNodes.TabIndex = 22;
			this.btMWTreeViewAddNodes.Text = "Add Nodes";
			this.btMWTreeViewAddNodes.Click += new System.EventHandler(this.btMWTreeViewAddNodes_Click);
			// 
			// btMWTreeViewClearNodes
			// 
			this.btMWTreeViewClearNodes.Location = new System.Drawing.Point(120, 40);
			this.btMWTreeViewClearNodes.Name = "btMWTreeViewClearNodes";
			this.btMWTreeViewClearNodes.Size = new System.Drawing.Size(112, 23);
			this.btMWTreeViewClearNodes.TabIndex = 17;
			this.btMWTreeViewClearNodes.Text = "Clear Nodes";
			this.btMWTreeViewClearNodes.Click += new System.EventHandler(this.btMWTreeViewClearNodes_Click);
			// 
			// btMWTreeViewToggleNodes
			// 
			this.btMWTreeViewToggleNodes.Location = new System.Drawing.Point(120, 16);
			this.btMWTreeViewToggleNodes.Name = "btMWTreeViewToggleNodes";
			this.btMWTreeViewToggleNodes.Size = new System.Drawing.Size(112, 23);
			this.btMWTreeViewToggleNodes.TabIndex = 20;
			this.btMWTreeViewToggleNodes.Text = "Toggle Nodes";
			this.btMWTreeViewToggleNodes.Click += new System.EventHandler(this.btMWTreeViewToggleNodes_Click);
			// 
			// btMWTreeViewLoadSelNodes
			// 
			this.btMWTreeViewLoadSelNodes.Location = new System.Drawing.Point(8, 88);
			this.btMWTreeViewLoadSelNodes.Name = "btMWTreeViewLoadSelNodes";
			this.btMWTreeViewLoadSelNodes.Size = new System.Drawing.Size(112, 23);
			this.btMWTreeViewLoadSelNodes.TabIndex = 16;
			this.btMWTreeViewLoadSelNodes.Text = "Load SelNodes";
			this.btMWTreeViewLoadSelNodes.Click += new System.EventHandler(this.btMWTreeViewLoadSelNodes_Click);
			// 
			// btMWTreeViewRecreateNodes
			// 
			this.btMWTreeViewRecreateNodes.Location = new System.Drawing.Point(240, 16);
			this.btMWTreeViewRecreateNodes.Name = "btMWTreeViewRecreateNodes";
			this.btMWTreeViewRecreateNodes.Size = new System.Drawing.Size(112, 23);
			this.btMWTreeViewRecreateNodes.TabIndex = 21;
			this.btMWTreeViewRecreateNodes.Text = "Recreate Nodes";
			this.btMWTreeViewRecreateNodes.Click += new System.EventHandler(this.btMWTreeViewRecreateNodes_Click);
			// 
			// btMWTreeViewSaveSelNodes
			// 
			this.btMWTreeViewSaveSelNodes.Location = new System.Drawing.Point(8, 64);
			this.btMWTreeViewSaveSelNodes.Name = "btMWTreeViewSaveSelNodes";
			this.btMWTreeViewSaveSelNodes.Size = new System.Drawing.Size(112, 23);
			this.btMWTreeViewSaveSelNodes.TabIndex = 16;
			this.btMWTreeViewSaveSelNodes.Text = "Save SelNodes";
			this.btMWTreeViewSaveSelNodes.Click += new System.EventHandler(this.btMWTreeViewSaveSelNodes_Click);
			// 
			// btMWTreeViewSaveNodes
			// 
			this.btMWTreeViewSaveNodes.Location = new System.Drawing.Point(120, 64);
			this.btMWTreeViewSaveNodes.Name = "btMWTreeViewSaveNodes";
			this.btMWTreeViewSaveNodes.Size = new System.Drawing.Size(112, 23);
			this.btMWTreeViewSaveNodes.TabIndex = 18;
			this.btMWTreeViewSaveNodes.Text = "Save Nodes";
			this.btMWTreeViewSaveNodes.Click += new System.EventHandler(this.btMWTreeViewSaveNodes_Click);
			// 
			// btMWTreeViewToggleSelNodes
			// 
			this.btMWTreeViewToggleSelNodes.Location = new System.Drawing.Point(8, 16);
			this.btMWTreeViewToggleSelNodes.Name = "btMWTreeViewToggleSelNodes";
			this.btMWTreeViewToggleSelNodes.Size = new System.Drawing.Size(112, 23);
			this.btMWTreeViewToggleSelNodes.TabIndex = 16;
			this.btMWTreeViewToggleSelNodes.Text = "Toggle SelNodes";
			this.btMWTreeViewToggleSelNodes.Click += new System.EventHandler(this.btMWTreeViewToggleSelNodes_Click);
			// 
			// btMWTreeViewLoadNodes
			// 
			this.btMWTreeViewLoadNodes.Location = new System.Drawing.Point(120, 88);
			this.btMWTreeViewLoadNodes.Name = "btMWTreeViewLoadNodes";
			this.btMWTreeViewLoadNodes.Size = new System.Drawing.Size(112, 23);
			this.btMWTreeViewLoadNodes.TabIndex = 19;
			this.btMWTreeViewLoadNodes.Text = "Load Nodes";
			this.btMWTreeViewLoadNodes.Click += new System.EventHandler(this.btMWTreeViewLoadNodes_Click);
			// 
			// gbMWTreeViewMWTreeView
			// 
			this.gbMWTreeViewMWTreeView.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.gbMWTreeViewMWTreeView.Controls.AddRange(new System.Windows.Forms.Control[] {
																								 this.lblMWTreeViewCheckNodeRegEx,
																								 this.tbMWTreeViewCheckNodeRegEx,
																								 this.cobMWTreeViewUseCheckNodeRegEx,
																								 this.lblMWTreeViewSelectNodeRegEx,
																								 this.tbMWTreeViewSelectNodeRegEx,
																								 this.cobMWTreeViewUseSelectNodeRegEx,
																								 this.lblMWTreeViewDisallowLabelEditRegEx,
																								 this.tbMWTreeViewDisallowLabelEditRegEx,
																								 this.cobMWTreeViewUseDisallowLabelEditRegEx,
																								 this.lblMWTreeViewLabelEditRegEx,
																								 this.tbMWTreeViewLabelEditRegEx,
																								 this.cbMWTreeViewAllowRubberbandSelect,
																								 this.cbMWTreeViewAllowNoSelNode,
																								 this.cbMWTreeViewScrollToSelNode,
																								 this.cbMWTreeViewAllowMultiCheck,
																								 this.cobMWTreeViewMultiSelect,
																								 this.cbMWTreeViewAllowBlankNodeText,
																								 this.lblMWTreeViewMultiSelect,
																								 this.cobMWTreeViewUseLabelEditRegEx});
			this.gbMWTreeViewMWTreeView.Location = new System.Drawing.Point(440, 160);
			this.gbMWTreeViewMWTreeView.Name = "gbMWTreeViewMWTreeView";
			this.gbMWTreeViewMWTreeView.Size = new System.Drawing.Size(240, 440);
			this.gbMWTreeViewMWTreeView.TabIndex = 15;
			this.gbMWTreeViewMWTreeView.TabStop = false;
			this.gbMWTreeViewMWTreeView.Text = "MWTreeView Properties";
			// 
			// lblMWTreeViewCheckNodeRegEx
			// 
			this.lblMWTreeViewCheckNodeRegEx.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblMWTreeViewCheckNodeRegEx.Location = new System.Drawing.Point(8, 368);
			this.lblMWTreeViewCheckNodeRegEx.Name = "lblMWTreeViewCheckNodeRegEx";
			this.lblMWTreeViewCheckNodeRegEx.Size = new System.Drawing.Size(224, 16);
			this.lblMWTreeViewCheckNodeRegEx.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.lblMWTreeViewCheckNodeRegEx.TabIndex = 28;
			this.lblMWTreeViewCheckNodeRegEx.Text = "Select Node RegEx (supplied RegEx is a date with optional time (24 or 12 hr))";
			this.lblMWTreeViewCheckNodeRegEx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbMWTreeViewCheckNodeRegEx
			// 
			this.tbMWTreeViewCheckNodeRegEx.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tbMWTreeViewCheckNodeRegEx.Location = new System.Drawing.Point(24, 384);
			this.tbMWTreeViewCheckNodeRegEx.Name = "tbMWTreeViewCheckNodeRegEx";
			this.tbMWTreeViewCheckNodeRegEx.Size = new System.Drawing.Size(208, 20);
			this.tbMWTreeViewCheckNodeRegEx.TabIndex = 27;
			this.tbMWTreeViewCheckNodeRegEx.Text = "(?i-s:^\\d{1,2}\\/\\d{1,2}\\/\\d{4}(|\\x20\\d{1,2}\\:\\d{2}|\\x20\\d{1,2}\\:\\d{2}(\\x20|)(AM|P" +
				"M))$)";
			// 
			// cobMWTreeViewUseCheckNodeRegEx
			// 
			this.cobMWTreeViewUseCheckNodeRegEx.Location = new System.Drawing.Point(24, 408);
			this.cobMWTreeViewUseCheckNodeRegEx.Name = "cobMWTreeViewUseCheckNodeRegEx";
			this.cobMWTreeViewUseCheckNodeRegEx.Size = new System.Drawing.Size(152, 24);
			this.cobMWTreeViewUseCheckNodeRegEx.TabIndex = 26;
			this.cobMWTreeViewUseCheckNodeRegEx.Text = "Use Select Node RegEx";
			this.cobMWTreeViewUseCheckNodeRegEx.CheckedChanged += new System.EventHandler(this.cobMWTreeViewUseCheckNodeRegEx_CheckedChanged);
			// 
			// lblMWTreeViewSelectNodeRegEx
			// 
			this.lblMWTreeViewSelectNodeRegEx.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblMWTreeViewSelectNodeRegEx.Location = new System.Drawing.Point(8, 304);
			this.lblMWTreeViewSelectNodeRegEx.Name = "lblMWTreeViewSelectNodeRegEx";
			this.lblMWTreeViewSelectNodeRegEx.Size = new System.Drawing.Size(224, 16);
			this.lblMWTreeViewSelectNodeRegEx.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.lblMWTreeViewSelectNodeRegEx.TabIndex = 25;
			this.lblMWTreeViewSelectNodeRegEx.Text = "Select Node RegEx (supplied RegEx is a date with optional time (24 or 12 hr))";
			this.lblMWTreeViewSelectNodeRegEx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbMWTreeViewSelectNodeRegEx
			// 
			this.tbMWTreeViewSelectNodeRegEx.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tbMWTreeViewSelectNodeRegEx.Location = new System.Drawing.Point(24, 320);
			this.tbMWTreeViewSelectNodeRegEx.Name = "tbMWTreeViewSelectNodeRegEx";
			this.tbMWTreeViewSelectNodeRegEx.Size = new System.Drawing.Size(208, 20);
			this.tbMWTreeViewSelectNodeRegEx.TabIndex = 24;
			this.tbMWTreeViewSelectNodeRegEx.Text = "(?i-s:^\\d{1,2}\\/\\d{1,2}\\/\\d{4}(|\\x20\\d{1,2}\\:\\d{2}|\\x20\\d{1,2}\\:\\d{2}(\\x20|)(AM|P" +
				"M))$)";
			// 
			// cobMWTreeViewUseSelectNodeRegEx
			// 
			this.cobMWTreeViewUseSelectNodeRegEx.Location = new System.Drawing.Point(24, 344);
			this.cobMWTreeViewUseSelectNodeRegEx.Name = "cobMWTreeViewUseSelectNodeRegEx";
			this.cobMWTreeViewUseSelectNodeRegEx.Size = new System.Drawing.Size(152, 24);
			this.cobMWTreeViewUseSelectNodeRegEx.TabIndex = 23;
			this.cobMWTreeViewUseSelectNodeRegEx.Text = "Use Select Node RegEx";
			this.cobMWTreeViewUseSelectNodeRegEx.CheckedChanged += new System.EventHandler(this.cobMWTreeViewUseSelectNodeRegEx_CheckedChanged);
			// 
			// lblMWTreeViewDisallowLabelEditRegEx
			// 
			this.lblMWTreeViewDisallowLabelEditRegEx.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblMWTreeViewDisallowLabelEditRegEx.Location = new System.Drawing.Point(8, 240);
			this.lblMWTreeViewDisallowLabelEditRegEx.Name = "lblMWTreeViewDisallowLabelEditRegEx";
			this.lblMWTreeViewDisallowLabelEditRegEx.Size = new System.Drawing.Size(224, 16);
			this.lblMWTreeViewDisallowLabelEditRegEx.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.lblMWTreeViewDisallowLabelEditRegEx.TabIndex = 22;
			this.lblMWTreeViewDisallowLabelEditRegEx.Text = "Disallow Label Edit RegEx (supplied RegEx is a date with optional time (24 or 12 " +
				"hr))";
			this.lblMWTreeViewDisallowLabelEditRegEx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbMWTreeViewDisallowLabelEditRegEx
			// 
			this.tbMWTreeViewDisallowLabelEditRegEx.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tbMWTreeViewDisallowLabelEditRegEx.Location = new System.Drawing.Point(24, 256);
			this.tbMWTreeViewDisallowLabelEditRegEx.Name = "tbMWTreeViewDisallowLabelEditRegEx";
			this.tbMWTreeViewDisallowLabelEditRegEx.Size = new System.Drawing.Size(208, 20);
			this.tbMWTreeViewDisallowLabelEditRegEx.TabIndex = 21;
			this.tbMWTreeViewDisallowLabelEditRegEx.Text = "(?i-s:^\\d{1,2}\\/\\d{1,2}\\/\\d{4}(|\\x20\\d{1,2}\\:\\d{2}|\\x20\\d{1,2}\\:\\d{2}(\\x20|)(AM|P" +
				"M))$)";
			// 
			// cobMWTreeViewUseDisallowLabelEditRegEx
			// 
			this.cobMWTreeViewUseDisallowLabelEditRegEx.Location = new System.Drawing.Point(24, 280);
			this.cobMWTreeViewUseDisallowLabelEditRegEx.Name = "cobMWTreeViewUseDisallowLabelEditRegEx";
			this.cobMWTreeViewUseDisallowLabelEditRegEx.Size = new System.Drawing.Size(184, 24);
			this.cobMWTreeViewUseDisallowLabelEditRegEx.TabIndex = 20;
			this.cobMWTreeViewUseDisallowLabelEditRegEx.Text = "Use Disallow Label Edit RegEx";
			this.cobMWTreeViewUseDisallowLabelEditRegEx.CheckedChanged += new System.EventHandler(this.cobMWTreeViewUseDisallowLabelEditRegEx_CheckedChanged);
			// 
			// lblMWTreeViewLabelEditRegEx
			// 
			this.lblMWTreeViewLabelEditRegEx.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblMWTreeViewLabelEditRegEx.Location = new System.Drawing.Point(8, 176);
			this.lblMWTreeViewLabelEditRegEx.Name = "lblMWTreeViewLabelEditRegEx";
			this.lblMWTreeViewLabelEditRegEx.Size = new System.Drawing.Size(224, 16);
			this.lblMWTreeViewLabelEditRegEx.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.lblMWTreeViewLabelEditRegEx.TabIndex = 19;
			this.lblMWTreeViewLabelEditRegEx.Text = "Label Edit RegEx (supplied RegEx is a date with optional time (24 or 12 hr))";
			this.lblMWTreeViewLabelEditRegEx.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// tbMWTreeViewLabelEditRegEx
			// 
			this.tbMWTreeViewLabelEditRegEx.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tbMWTreeViewLabelEditRegEx.Location = new System.Drawing.Point(24, 192);
			this.tbMWTreeViewLabelEditRegEx.Name = "tbMWTreeViewLabelEditRegEx";
			this.tbMWTreeViewLabelEditRegEx.Size = new System.Drawing.Size(208, 20);
			this.tbMWTreeViewLabelEditRegEx.TabIndex = 18;
			this.tbMWTreeViewLabelEditRegEx.Text = "(?i-s:^\\d{1,2}\\/\\d{1,2}\\/\\d{4}(|\\x20\\d{1,2}\\:\\d{2}|\\x20\\d{1,2}\\:\\d{2}(\\x20|)(AM|P" +
				"M))$)";
			// 
			// cbMWTreeViewAllowRubberbandSelect
			// 
			this.cbMWTreeViewAllowRubberbandSelect.Checked = true;
			this.cbMWTreeViewAllowRubberbandSelect.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMWTreeViewAllowRubberbandSelect.Location = new System.Drawing.Point(8, 152);
			this.cbMWTreeViewAllowRubberbandSelect.Name = "cbMWTreeViewAllowRubberbandSelect";
			this.cbMWTreeViewAllowRubberbandSelect.Size = new System.Drawing.Size(152, 24);
			this.cbMWTreeViewAllowRubberbandSelect.TabIndex = 17;
			this.cbMWTreeViewAllowRubberbandSelect.Text = "Allow Rubberband Select";
			this.cbMWTreeViewAllowRubberbandSelect.CheckedChanged += new System.EventHandler(this.cbMWTreeViewAllowRubberbandSelect_CheckedChanged);
			// 
			// cbMWTreeViewAllowNoSelNode
			// 
			this.cbMWTreeViewAllowNoSelNode.Checked = true;
			this.cbMWTreeViewAllowNoSelNode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMWTreeViewAllowNoSelNode.Location = new System.Drawing.Point(8, 64);
			this.cbMWTreeViewAllowNoSelNode.Name = "cbMWTreeViewAllowNoSelNode";
			this.cbMWTreeViewAllowNoSelNode.Size = new System.Drawing.Size(144, 24);
			this.cbMWTreeViewAllowNoSelNode.TabIndex = 7;
			this.cbMWTreeViewAllowNoSelNode.Text = "Allow No SelNode";
			this.cbMWTreeViewAllowNoSelNode.CheckedChanged += new System.EventHandler(this.cbMWTreeViewAllowNoSelNode_CheckedChanged);
			// 
			// cbMWTreeViewScrollToSelNode
			// 
			this.cbMWTreeViewScrollToSelNode.Checked = true;
			this.cbMWTreeViewScrollToSelNode.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMWTreeViewScrollToSelNode.Location = new System.Drawing.Point(8, 16);
			this.cbMWTreeViewScrollToSelNode.Name = "cbMWTreeViewScrollToSelNode";
			this.cbMWTreeViewScrollToSelNode.Size = new System.Drawing.Size(144, 24);
			this.cbMWTreeViewScrollToSelNode.TabIndex = 7;
			this.cbMWTreeViewScrollToSelNode.Text = "Scroll To SelNode";
			this.cbMWTreeViewScrollToSelNode.CheckedChanged += new System.EventHandler(this.cbMWTreeViewScrollToSelNode_CheckedChanged);
			// 
			// cbMWTreeViewAllowMultiCheck
			// 
			this.cbMWTreeViewAllowMultiCheck.Checked = true;
			this.cbMWTreeViewAllowMultiCheck.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMWTreeViewAllowMultiCheck.Location = new System.Drawing.Point(8, 88);
			this.cbMWTreeViewAllowMultiCheck.Name = "cbMWTreeViewAllowMultiCheck";
			this.cbMWTreeViewAllowMultiCheck.Size = new System.Drawing.Size(144, 24);
			this.cbMWTreeViewAllowMultiCheck.TabIndex = 11;
			this.cbMWTreeViewAllowMultiCheck.Text = "Allow Multi Check";
			this.cbMWTreeViewAllowMultiCheck.CheckedChanged += new System.EventHandler(this.cbMWTreeViewAllowMultiCheck_CheckedChanged);
			// 
			// cobMWTreeViewMultiSelect
			// 
			this.cobMWTreeViewMultiSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobMWTreeViewMultiSelect.Location = new System.Drawing.Point(24, 128);
			this.cobMWTreeViewMultiSelect.Name = "cobMWTreeViewMultiSelect";
			this.cobMWTreeViewMultiSelect.Size = new System.Drawing.Size(144, 21);
			this.cobMWTreeViewMultiSelect.TabIndex = 12;
			this.cobMWTreeViewMultiSelect.SelectedIndexChanged += new System.EventHandler(this.cobMWTreeViewMultiSelect_SelectedIndexChanged);
			// 
			// cbMWTreeViewAllowBlankNodeText
			// 
			this.cbMWTreeViewAllowBlankNodeText.Location = new System.Drawing.Point(8, 40);
			this.cbMWTreeViewAllowBlankNodeText.Name = "cbMWTreeViewAllowBlankNodeText";
			this.cbMWTreeViewAllowBlankNodeText.Size = new System.Drawing.Size(144, 24);
			this.cbMWTreeViewAllowBlankNodeText.TabIndex = 7;
			this.cbMWTreeViewAllowBlankNodeText.Text = "Allow Blank Node Text";
			this.cbMWTreeViewAllowBlankNodeText.CheckedChanged += new System.EventHandler(this.cbMWTreeViewAllowBlankNodeText_CheckedChanged);
			// 
			// lblMWTreeViewMultiSelect
			// 
			this.lblMWTreeViewMultiSelect.Location = new System.Drawing.Point(8, 112);
			this.lblMWTreeViewMultiSelect.Name = "lblMWTreeViewMultiSelect";
			this.lblMWTreeViewMultiSelect.Size = new System.Drawing.Size(144, 16);
			this.lblMWTreeViewMultiSelect.TabIndex = 16;
			this.lblMWTreeViewMultiSelect.Text = "MultiSelect";
			this.lblMWTreeViewMultiSelect.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
			// 
			// cobMWTreeViewUseLabelEditRegEx
			// 
			this.cobMWTreeViewUseLabelEditRegEx.Location = new System.Drawing.Point(24, 216);
			this.cobMWTreeViewUseLabelEditRegEx.Name = "cobMWTreeViewUseLabelEditRegEx";
			this.cobMWTreeViewUseLabelEditRegEx.Size = new System.Drawing.Size(144, 24);
			this.cobMWTreeViewUseLabelEditRegEx.TabIndex = 11;
			this.cobMWTreeViewUseLabelEditRegEx.Text = "Use Label Edit RegEx";
			this.cobMWTreeViewUseLabelEditRegEx.CheckedChanged += new System.EventHandler(this.cobMWTreeViewUseLabelEditRegEx_CheckedChanged);
			// 
			// gbMWTreeViewCombined
			// 
			this.gbMWTreeViewCombined.Controls.AddRange(new System.Windows.Forms.Control[] {
																							   this.cbMWTreeViewHideSelection,
																							   this.cbMWTreeViewCheckBoxes,
																							   this.cbMWTreeViewLabelEdit,
																							   this.cbMWTreeViewFullRowSelect,
																							   this.cbMWTreeViewShowRootLines,
																							   this.cbMWTreeViewHotTracking,
																							   this.cbMWTreeViewUseImageList,
																							   this.cbMWTreeViewScrollable});
			this.gbMWTreeViewCombined.Location = new System.Drawing.Point(8, 8);
			this.gbMWTreeViewCombined.Name = "gbMWTreeViewCombined";
			this.gbMWTreeViewCombined.Size = new System.Drawing.Size(304, 120);
			this.gbMWTreeViewCombined.TabIndex = 14;
			this.gbMWTreeViewCombined.TabStop = false;
			this.gbMWTreeViewCombined.Text = "TreeView and MWTreeView Properties";
			// 
			// cbMWTreeViewHideSelection
			// 
			this.cbMWTreeViewHideSelection.Checked = true;
			this.cbMWTreeViewHideSelection.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMWTreeViewHideSelection.Location = new System.Drawing.Point(8, 88);
			this.cbMWTreeViewHideSelection.Name = "cbMWTreeViewHideSelection";
			this.cbMWTreeViewHideSelection.Size = new System.Drawing.Size(144, 24);
			this.cbMWTreeViewHideSelection.TabIndex = 5;
			this.cbMWTreeViewHideSelection.Text = "Hide Selection";
			this.cbMWTreeViewHideSelection.CheckedChanged += new System.EventHandler(this.cbMWTreeViewHideSelection_CheckedChanged);
			// 
			// cbMWTreeViewCheckBoxes
			// 
			this.cbMWTreeViewCheckBoxes.Location = new System.Drawing.Point(8, 40);
			this.cbMWTreeViewCheckBoxes.Name = "cbMWTreeViewCheckBoxes";
			this.cbMWTreeViewCheckBoxes.Size = new System.Drawing.Size(144, 24);
			this.cbMWTreeViewCheckBoxes.TabIndex = 2;
			this.cbMWTreeViewCheckBoxes.Text = "Check Boxes";
			this.cbMWTreeViewCheckBoxes.CheckedChanged += new System.EventHandler(this.cbMWTreeViewCheckBoxes_CheckedChanged);
			// 
			// cbMWTreeViewLabelEdit
			// 
			this.cbMWTreeViewLabelEdit.Location = new System.Drawing.Point(8, 64);
			this.cbMWTreeViewLabelEdit.Name = "cbMWTreeViewLabelEdit";
			this.cbMWTreeViewLabelEdit.Size = new System.Drawing.Size(144, 24);
			this.cbMWTreeViewLabelEdit.TabIndex = 4;
			this.cbMWTreeViewLabelEdit.Text = "Label Edit";
			this.cbMWTreeViewLabelEdit.CheckedChanged += new System.EventHandler(this.cbMWTreeViewLabelEdit_CheckedChanged);
			// 
			// cbMWTreeViewFullRowSelect
			// 
			this.cbMWTreeViewFullRowSelect.Location = new System.Drawing.Point(8, 16);
			this.cbMWTreeViewFullRowSelect.Name = "cbMWTreeViewFullRowSelect";
			this.cbMWTreeViewFullRowSelect.Size = new System.Drawing.Size(144, 24);
			this.cbMWTreeViewFullRowSelect.TabIndex = 1;
			this.cbMWTreeViewFullRowSelect.Text = "Full Row Select";
			this.cbMWTreeViewFullRowSelect.CheckedChanged += new System.EventHandler(this.cbMWTreeViewFullRowSelect_CheckedChanged);
			// 
			// cbMWTreeViewShowRootLines
			// 
			this.cbMWTreeViewShowRootLines.Checked = true;
			this.cbMWTreeViewShowRootLines.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMWTreeViewShowRootLines.Location = new System.Drawing.Point(152, 64);
			this.cbMWTreeViewShowRootLines.Name = "cbMWTreeViewShowRootLines";
			this.cbMWTreeViewShowRootLines.Size = new System.Drawing.Size(144, 24);
			this.cbMWTreeViewShowRootLines.TabIndex = 9;
			this.cbMWTreeViewShowRootLines.Text = "Show RootLines";
			this.cbMWTreeViewShowRootLines.CheckedChanged += new System.EventHandler(this.cbMWTreeViewShowRootLines_CheckedChanged);
			// 
			// cbMWTreeViewHotTracking
			// 
			this.cbMWTreeViewHotTracking.Location = new System.Drawing.Point(152, 88);
			this.cbMWTreeViewHotTracking.Name = "cbMWTreeViewHotTracking";
			this.cbMWTreeViewHotTracking.Size = new System.Drawing.Size(144, 24);
			this.cbMWTreeViewHotTracking.TabIndex = 10;
			this.cbMWTreeViewHotTracking.Text = "HotTracking";
			this.cbMWTreeViewHotTracking.CheckedChanged += new System.EventHandler(this.cbMWTreeViewHotTracking_CheckedChanged);
			// 
			// cbMWTreeViewUseImageList
			// 
			this.cbMWTreeViewUseImageList.Checked = true;
			this.cbMWTreeViewUseImageList.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMWTreeViewUseImageList.Location = new System.Drawing.Point(152, 40);
			this.cbMWTreeViewUseImageList.Name = "cbMWTreeViewUseImageList";
			this.cbMWTreeViewUseImageList.Size = new System.Drawing.Size(144, 24);
			this.cbMWTreeViewUseImageList.TabIndex = 8;
			this.cbMWTreeViewUseImageList.Text = "Use ImageList";
			this.cbMWTreeViewUseImageList.CheckedChanged += new System.EventHandler(this.cbMWTreeViewUseImageList_CheckedChanged);
			// 
			// cbMWTreeViewScrollable
			// 
			this.cbMWTreeViewScrollable.Checked = true;
			this.cbMWTreeViewScrollable.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMWTreeViewScrollable.Location = new System.Drawing.Point(152, 16);
			this.cbMWTreeViewScrollable.Name = "cbMWTreeViewScrollable";
			this.cbMWTreeViewScrollable.Size = new System.Drawing.Size(144, 24);
			this.cbMWTreeViewScrollable.TabIndex = 6;
			this.cbMWTreeViewScrollable.Text = "Scrollable";
			this.cbMWTreeViewScrollable.CheckedChanged += new System.EventHandler(this.cbMWTreeViewScrollable_CheckedChanged);
			// 
			// lblMWTreeViewTreeView
			// 
			this.lblMWTreeViewTreeView.Location = new System.Drawing.Point(8, 136);
			this.lblMWTreeViewTreeView.Name = "lblMWTreeViewTreeView";
			this.lblMWTreeViewTreeView.Size = new System.Drawing.Size(208, 16);
			this.lblMWTreeViewTreeView.TabIndex = 13;
			this.lblMWTreeViewTreeView.Text = "TreeView";
			this.lblMWTreeViewTreeView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// mwtvMWTreeView
			// 
			this.mwtvMWTreeView.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left);
			this.mwtvMWTreeView.CheckedNodes = ((System.Collections.Hashtable)(resources.GetObject("mwtvMWTreeView.CheckedNodes")));
			this.mwtvMWTreeView.ImageList = this.ilMWTreeView;
			this.mwtvMWTreeView.Location = new System.Drawing.Point(224, 152);
			this.mwtvMWTreeView.Name = "mwtvMWTreeView";
			this.mwtvMWTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																					   new System.Windows.Forms.TreeNode("Level0Node0", new System.Windows.Forms.TreeNode[] {
																																												new System.Windows.Forms.TreeNode("L0N0Child0", new System.Windows.Forms.TreeNode[] {
																																																																		new System.Windows.Forms.TreeNode("L0N0N0Child0"),
																																																																		new System.Windows.Forms.TreeNode("L0N0N0Child1"),
																																																																		new System.Windows.Forms.TreeNode("L0N0N0Child2"),
																																																																		new System.Windows.Forms.TreeNode("L0N0N0Child3")}),
																																												new System.Windows.Forms.TreeNode("L0N0Child1"),
																																												new System.Windows.Forms.TreeNode("L0N0Child2", new System.Windows.Forms.TreeNode[] {
																																																																		new System.Windows.Forms.TreeNode("L0N0N2Child0"),
																																																																		new System.Windows.Forms.TreeNode("L0N0N2Child1"),
																																																																		new System.Windows.Forms.TreeNode("L0N0N2Child2"),
																																																																		new System.Windows.Forms.TreeNode("L0N0N2Child3")}),
																																												new System.Windows.Forms.TreeNode("L0N0Child3")}),
																					   new System.Windows.Forms.TreeNode("Level0Node1", new System.Windows.Forms.TreeNode[] {
																																												new System.Windows.Forms.TreeNode("L0N1Child0"),
																																												new System.Windows.Forms.TreeNode("L0N1Child1", new System.Windows.Forms.TreeNode[] {
																																																																		new System.Windows.Forms.TreeNode("L0N1N0Child0", new System.Windows.Forms.TreeNode[] {
																																																																																								  new System.Windows.Forms.TreeNode("L0N1N0N0Child0", new System.Windows.Forms.TreeNode[] {
																																																																																																															  new System.Windows.Forms.TreeNode("L0N1N0N0N0Child0", new System.Windows.Forms.TreeNode[] {
																																																																																																																																							new System.Windows.Forms.TreeNode("L0N1N0N0N0N0Child0")})})})}),
																																												new System.Windows.Forms.TreeNode("L0N1Child2"),
																																												new System.Windows.Forms.TreeNode("L0N1Child3")}),
																					   new System.Windows.Forms.TreeNode("Level0Node2", new System.Windows.Forms.TreeNode[] {
																																												new System.Windows.Forms.TreeNode("L0N2Child0"),
																																												new System.Windows.Forms.TreeNode("L0N2Child1"),
																																												new System.Windows.Forms.TreeNode("L0N2Child2"),
																																												new System.Windows.Forms.TreeNode("L0N2Child3")}),
																					   new System.Windows.Forms.TreeNode("Level0Node3", new System.Windows.Forms.TreeNode[] {
																																												new System.Windows.Forms.TreeNode("L0N3Child0"),
																																												new System.Windows.Forms.TreeNode("L0N3Child1"),
																																												new System.Windows.Forms.TreeNode("L0N3Child2"),
																																												new System.Windows.Forms.TreeNode("L0N3Child3")}),
																					   new System.Windows.Forms.TreeNode("Level0Node4", new System.Windows.Forms.TreeNode[] {
																																												new System.Windows.Forms.TreeNode("L0N4Child0"),
																																												new System.Windows.Forms.TreeNode("L0N4Child1"),
																																												new System.Windows.Forms.TreeNode("L0N4Child2"),
																																												new System.Windows.Forms.TreeNode("L0N4Child3"),
																																												new System.Windows.Forms.TreeNode("L0N4Child4"),
																																												new System.Windows.Forms.TreeNode("L0N4Child5"),
																																												new System.Windows.Forms.TreeNode("L0N4Child6"),
																																												new System.Windows.Forms.TreeNode("L0N4Child7"),
																																												new System.Windows.Forms.TreeNode("L0N4Child8"),
																																												new System.Windows.Forms.TreeNode("L0N4Child9"),
																																												new System.Windows.Forms.TreeNode("L0N4Child10"),
																																												new System.Windows.Forms.TreeNode("L0N4Child11"),
																																												new System.Windows.Forms.TreeNode("L0N4Child12"),
																																												new System.Windows.Forms.TreeNode("L0N4Child13"),
																																												new System.Windows.Forms.TreeNode("L0N4Child14"),
																																												new System.Windows.Forms.TreeNode("L0N4Child15"),
																																												new System.Windows.Forms.TreeNode("L0N4Child16"),
																																												new System.Windows.Forms.TreeNode("L0N4Child17"),
																																												new System.Windows.Forms.TreeNode("L0N4Child18"),
																																												new System.Windows.Forms.TreeNode("L0N4Child19"),
																																												new System.Windows.Forms.TreeNode("L0N4Child20"),
																																												new System.Windows.Forms.TreeNode("L0N4Child21"),
																																												new System.Windows.Forms.TreeNode("L0N4Child22"),
																																												new System.Windows.Forms.TreeNode("L0N4Child23"),
																																												new System.Windows.Forms.TreeNode("L0N4Child24"),
																																												new System.Windows.Forms.TreeNode("L0N4Child25"),
																																												new System.Windows.Forms.TreeNode("L0N4Child26"),
																																												new System.Windows.Forms.TreeNode("L0N4Child27"),
																																												new System.Windows.Forms.TreeNode("L0N4Child28"),
																																												new System.Windows.Forms.TreeNode("L0N4Child29"),
																																												new System.Windows.Forms.TreeNode("L0N4Child30"),
																																												new System.Windows.Forms.TreeNode("L0N4Child31"),
																																												new System.Windows.Forms.TreeNode("L0N4Child32"),
																																												new System.Windows.Forms.TreeNode("L0N4Child33"),
																																												new System.Windows.Forms.TreeNode("L0N4Child34"),
																																												new System.Windows.Forms.TreeNode("L0N4Child35"),
																																												new System.Windows.Forms.TreeNode("L0N4Child36"),
																																												new System.Windows.Forms.TreeNode("L0N4Child37"),
																																												new System.Windows.Forms.TreeNode("L0N4Child38"),
																																												new System.Windows.Forms.TreeNode("L0N4Child39"),
																																												new System.Windows.Forms.TreeNode("L0N4Child40"),
																																												new System.Windows.Forms.TreeNode("L0N4Child41"),
																																												new System.Windows.Forms.TreeNode("L0N4Child42"),
																																												new System.Windows.Forms.TreeNode("L0N4Child43"),
																																												new System.Windows.Forms.TreeNode("L0N4Child44"),
																																												new System.Windows.Forms.TreeNode("L0N4Child45"),
																																												new System.Windows.Forms.TreeNode("L0N4Child46"),
																																												new System.Windows.Forms.TreeNode("L0N4Child47"),
																																												new System.Windows.Forms.TreeNode("L0N4Child48"),
																																												new System.Windows.Forms.TreeNode("L0N4Child49"),
																																												new System.Windows.Forms.TreeNode("L0N4Child50"),
																																												new System.Windows.Forms.TreeNode("L0N4Child51"),
																																												new System.Windows.Forms.TreeNode("L0N4Child52"),
																																												new System.Windows.Forms.TreeNode("L0N4Child53"),
																																												new System.Windows.Forms.TreeNode("L0N4Child54"),
																																												new System.Windows.Forms.TreeNode("L0N4Child55"),
																																												new System.Windows.Forms.TreeNode("L0N4Child56"),
																																												new System.Windows.Forms.TreeNode("L0N4Child57"),
																																												new System.Windows.Forms.TreeNode("L0N4Child58"),
																																												new System.Windows.Forms.TreeNode("L0N4Child59"),
																																												new System.Windows.Forms.TreeNode("L0N4Child60"),
																																												new System.Windows.Forms.TreeNode("L0N4Child61"),
																																												new System.Windows.Forms.TreeNode("L0N4Child62"),
																																												new System.Windows.Forms.TreeNode("L0N4Child63")})});
			this.mwtvMWTreeView.SelectedImageIndex = 1;
			this.mwtvMWTreeView.SelNodes = ((System.Collections.Hashtable)(resources.GetObject("mwtvMWTreeView.SelNodes")));
			this.mwtvMWTreeView.Size = new System.Drawing.Size(208, 480);
			this.mwtvMWTreeView.TabIndex = 3;
			// 
			// ilMWTreeView
			// 
			this.ilMWTreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.ilMWTreeView.ImageSize = new System.Drawing.Size(16, 16);
			this.ilMWTreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilMWTreeView.ImageStream")));
			this.ilMWTreeView.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tvMWTreeView
			// 
			this.tvMWTreeView.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left);
			this.tvMWTreeView.ImageList = this.ilMWTreeView;
			this.tvMWTreeView.Location = new System.Drawing.Point(8, 152);
			this.tvMWTreeView.Name = "tvMWTreeView";
			this.tvMWTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																					 new System.Windows.Forms.TreeNode("Level0Node0", new System.Windows.Forms.TreeNode[] {
																																											  new System.Windows.Forms.TreeNode("L0N0Child0", new System.Windows.Forms.TreeNode[] {
																																																																	  new System.Windows.Forms.TreeNode("L0N0N0Child0"),
																																																																	  new System.Windows.Forms.TreeNode("L0N0N0Child1"),
																																																																	  new System.Windows.Forms.TreeNode("L0N0N0Child2"),
																																																																	  new System.Windows.Forms.TreeNode("L0N0N0Child3")}),
																																											  new System.Windows.Forms.TreeNode("L0N0Child1"),
																																											  new System.Windows.Forms.TreeNode("L0N0Child2", new System.Windows.Forms.TreeNode[] {
																																																																	  new System.Windows.Forms.TreeNode("L0N0N2Child0"),
																																																																	  new System.Windows.Forms.TreeNode("L0N0N2Child1"),
																																																																	  new System.Windows.Forms.TreeNode("L0N0N2Child2"),
																																																																	  new System.Windows.Forms.TreeNode("L0N0N2Child3")}),
																																											  new System.Windows.Forms.TreeNode("L0N0Child3")}),
																					 new System.Windows.Forms.TreeNode("Level0Node1", new System.Windows.Forms.TreeNode[] {
																																											  new System.Windows.Forms.TreeNode("L0N1Child0"),
																																											  new System.Windows.Forms.TreeNode("L0N1Child1", new System.Windows.Forms.TreeNode[] {
																																																																	  new System.Windows.Forms.TreeNode("L0N1N0Child0", new System.Windows.Forms.TreeNode[] {
																																																																																								new System.Windows.Forms.TreeNode("L0N1N0N0Child0", new System.Windows.Forms.TreeNode[] {
																																																																																																															new System.Windows.Forms.TreeNode("L0N1N0N0N0Child0", new System.Windows.Forms.TreeNode[] {
																																																																																																																																						  new System.Windows.Forms.TreeNode("L0N1N0N0N0N0Child0")})})})}),
																																											  new System.Windows.Forms.TreeNode("L0N1Child2"),
																																											  new System.Windows.Forms.TreeNode("L0N1Child3")}),
																					 new System.Windows.Forms.TreeNode("Level0Node2", new System.Windows.Forms.TreeNode[] {
																																											  new System.Windows.Forms.TreeNode("L0N2Child0"),
																																											  new System.Windows.Forms.TreeNode("L0N2Child1"),
																																											  new System.Windows.Forms.TreeNode("L0N2Child2"),
																																											  new System.Windows.Forms.TreeNode("L0N2Child3")}),
																					 new System.Windows.Forms.TreeNode("Level0Node3", new System.Windows.Forms.TreeNode[] {
																																											  new System.Windows.Forms.TreeNode("L0N3Child0"),
																																											  new System.Windows.Forms.TreeNode("L0N3Child1"),
																																											  new System.Windows.Forms.TreeNode("L0N3Child2"),
																																											  new System.Windows.Forms.TreeNode("L0N3Child3")}),
																					 new System.Windows.Forms.TreeNode("Level0Node4", new System.Windows.Forms.TreeNode[] {
																																											  new System.Windows.Forms.TreeNode("L0N4Child0"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child1"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child2"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child3"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child4"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child5"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child6"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child7"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child8"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child9"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child10"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child11"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child12"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child13"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child14"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child15"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child16"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child17"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child18"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child19"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child20"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child21"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child22"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child23"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child24"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child25"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child26"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child27"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child28"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child29"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child30"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child31"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child32"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child33"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child34"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child35"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child36"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child37"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child38"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child39"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child40"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child41"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child42"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child43"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child44"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child45"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child46"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child47"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child48"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child49"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child50"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child51"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child52"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child53"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child54"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child55"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child56"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child57"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child58"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child59"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child60"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child61"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child62"),
																																											  new System.Windows.Forms.TreeNode("L0N4Child63")})});
			this.tvMWTreeView.SelectedImageIndex = 1;
			this.tvMWTreeView.Size = new System.Drawing.Size(208, 480);
			this.tvMWTreeView.TabIndex = 0;
			// 
			// lblMWTreeViewMWTreeView
			// 
			this.lblMWTreeViewMWTreeView.Location = new System.Drawing.Point(224, 136);
			this.lblMWTreeViewMWTreeView.Name = "lblMWTreeViewMWTreeView";
			this.lblMWTreeViewMWTreeView.Size = new System.Drawing.Size(208, 16);
			this.lblMWTreeViewMWTreeView.TabIndex = 13;
			this.lblMWTreeViewMWTreeView.Text = "MWTreeView";
			this.lblMWTreeViewMWTreeView.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// tpMWCheckBox
			// 
			this.tpMWCheckBox.Controls.AddRange(new System.Windows.Forms.Control[] {
																					   this.lblMWCheckBoxMessage,
																					   this.lblMWCheckBoxMWCheckBox,
																					   this.lblMWCheckBoxCheckBox,
																					   this.gbMWCheckBoxMWCheckBox,
																					   this.mwcbMWCheckBox,
																					   this.cbMWCheckBox,
																					   this.gbMWCheckBoxCombined});
			this.tpMWCheckBox.Location = new System.Drawing.Point(4, 22);
			this.tpMWCheckBox.Name = "tpMWCheckBox";
			this.tpMWCheckBox.Size = new System.Drawing.Size(688, 638);
			this.tpMWCheckBox.TabIndex = 4;
			this.tpMWCheckBox.Text = "MWCheckBox";
			// 
			// lblMWCheckBoxMWCheckBox
			// 
			this.lblMWCheckBoxMWCheckBox.Location = new System.Drawing.Point(136, 8);
			this.lblMWCheckBoxMWCheckBox.Name = "lblMWCheckBoxMWCheckBox";
			this.lblMWCheckBoxMWCheckBox.Size = new System.Drawing.Size(112, 16);
			this.lblMWCheckBoxMWCheckBox.TabIndex = 29;
			this.lblMWCheckBoxMWCheckBox.Text = "MWCheckBox";
			this.lblMWCheckBoxMWCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// lblMWCheckBoxCheckBox
			// 
			this.lblMWCheckBoxCheckBox.Location = new System.Drawing.Point(8, 8);
			this.lblMWCheckBoxCheckBox.Name = "lblMWCheckBoxCheckBox";
			this.lblMWCheckBoxCheckBox.Size = new System.Drawing.Size(112, 16);
			this.lblMWCheckBoxCheckBox.TabIndex = 28;
			this.lblMWCheckBoxCheckBox.Text = "CheckBox";
			this.lblMWCheckBoxCheckBox.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// gbMWCheckBoxMWCheckBox
			// 
			this.gbMWCheckBoxMWCheckBox.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.gbMWCheckBoxMWCheckBox.Controls.AddRange(new System.Windows.Forms.Control[] {
																								 this.cobMWCheckBoxCheckBoxPaintOrder,
																								 this.lblMWCheckBoxCheckBoxPaintOrder,
																								 this.cobMWCheckBoxTextDir,
																								 this.lblMWCheckBoxTextDir,
																								 this.cobMWCheckBoxStringFormat,
																								 this.lblMWCheckBoxStringFormat});
			this.gbMWCheckBoxMWCheckBox.Location = new System.Drawing.Point(456, 336);
			this.gbMWCheckBoxMWCheckBox.Name = "gbMWCheckBoxMWCheckBox";
			this.gbMWCheckBoxMWCheckBox.Size = new System.Drawing.Size(224, 144);
			this.gbMWCheckBoxMWCheckBox.TabIndex = 27;
			this.gbMWCheckBoxMWCheckBox.TabStop = false;
			this.gbMWCheckBoxMWCheckBox.Text = "MWCheckBox Properties";
			// 
			// cobMWCheckBoxCheckBoxPaintOrder
			// 
			this.cobMWCheckBoxCheckBoxPaintOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobMWCheckBoxCheckBoxPaintOrder.Location = new System.Drawing.Point(8, 32);
			this.cobMWCheckBoxCheckBoxPaintOrder.Name = "cobMWCheckBoxCheckBoxPaintOrder";
			this.cobMWCheckBoxCheckBoxPaintOrder.Size = new System.Drawing.Size(160, 21);
			this.cobMWCheckBoxCheckBoxPaintOrder.TabIndex = 41;
			this.cobMWCheckBoxCheckBoxPaintOrder.SelectedIndexChanged += new System.EventHandler(this.cobMWCheckBoxCheckBoxPaintOrder_SelectedIndexChanged);
			// 
			// lblMWCheckBoxCheckBoxPaintOrder
			// 
			this.lblMWCheckBoxCheckBoxPaintOrder.Location = new System.Drawing.Point(8, 16);
			this.lblMWCheckBoxCheckBoxPaintOrder.Name = "lblMWCheckBoxCheckBoxPaintOrder";
			this.lblMWCheckBoxCheckBoxPaintOrder.Size = new System.Drawing.Size(144, 16);
			this.lblMWCheckBoxCheckBoxPaintOrder.TabIndex = 42;
			this.lblMWCheckBoxCheckBoxPaintOrder.Text = "CheckBox Paint Order";
			this.lblMWCheckBoxCheckBoxPaintOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// cobMWCheckBoxTextDir
			// 
			this.cobMWCheckBoxTextDir.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobMWCheckBoxTextDir.Location = new System.Drawing.Point(8, 112);
			this.cobMWCheckBoxTextDir.Name = "cobMWCheckBoxTextDir";
			this.cobMWCheckBoxTextDir.Size = new System.Drawing.Size(160, 21);
			this.cobMWCheckBoxTextDir.TabIndex = 39;
			this.cobMWCheckBoxTextDir.SelectedIndexChanged += new System.EventHandler(this.cobMWCheckBoxTextDir_SelectedIndexChanged);
			// 
			// lblMWCheckBoxTextDir
			// 
			this.lblMWCheckBoxTextDir.Location = new System.Drawing.Point(8, 96);
			this.lblMWCheckBoxTextDir.Name = "lblMWCheckBoxTextDir";
			this.lblMWCheckBoxTextDir.Size = new System.Drawing.Size(144, 16);
			this.lblMWCheckBoxTextDir.TabIndex = 40;
			this.lblMWCheckBoxTextDir.Text = "TextDir";
			this.lblMWCheckBoxTextDir.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// cobMWCheckBoxStringFormat
			// 
			this.cobMWCheckBoxStringFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobMWCheckBoxStringFormat.Location = new System.Drawing.Point(8, 72);
			this.cobMWCheckBoxStringFormat.Name = "cobMWCheckBoxStringFormat";
			this.cobMWCheckBoxStringFormat.Size = new System.Drawing.Size(160, 21);
			this.cobMWCheckBoxStringFormat.TabIndex = 37;
			this.cobMWCheckBoxStringFormat.SelectedIndexChanged += new System.EventHandler(this.cobMWCheckBoxStringFormat_SelectedIndexChanged);
			// 
			// lblMWCheckBoxStringFormat
			// 
			this.lblMWCheckBoxStringFormat.Location = new System.Drawing.Point(8, 56);
			this.lblMWCheckBoxStringFormat.Name = "lblMWCheckBoxStringFormat";
			this.lblMWCheckBoxStringFormat.Size = new System.Drawing.Size(144, 16);
			this.lblMWCheckBoxStringFormat.TabIndex = 38;
			this.lblMWCheckBoxStringFormat.Text = "StringFormat";
			this.lblMWCheckBoxStringFormat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// mwcbMWCheckBox
			// 
			this.mwcbMWCheckBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.mwcbMWCheckBox.Image = ((System.Drawing.Bitmap)(resources.GetObject("mwcbMWCheckBox.Image")));
			this.mwcbMWCheckBox.ImageIndex = 0;
			this.mwcbMWCheckBox.ImageList = this.ilMWTreeView;
			this.mwcbMWCheckBox.Location = new System.Drawing.Point(136, 24);
			this.mwcbMWCheckBox.Name = "mwcbMWCheckBox";
			this.mwcbMWCheckBox.Size = new System.Drawing.Size(112, 224);
			this.mwcbMWCheckBox.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			this.mwcbMWCheckBox.TabIndex = 22;
			this.mwcbMWCheckBox.Text = "X--x--X--x--X";
			this.mwcbMWCheckBox.ThreeState = true;
			// 
			// cbMWCheckBox
			// 
			this.cbMWCheckBox.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(128)));
			this.cbMWCheckBox.Image = ((System.Drawing.Bitmap)(resources.GetObject("cbMWCheckBox.Image")));
			this.cbMWCheckBox.ImageIndex = 0;
			this.cbMWCheckBox.ImageList = this.ilMWTreeView;
			this.cbMWCheckBox.Location = new System.Drawing.Point(8, 24);
			this.cbMWCheckBox.Name = "cbMWCheckBox";
			this.cbMWCheckBox.Size = new System.Drawing.Size(112, 224);
			this.cbMWCheckBox.TabIndex = 20;
			this.cbMWCheckBox.Text = "checkBoxX";
			this.cbMWCheckBox.ThreeState = true;
			// 
			// gbMWCheckBoxCombined
			// 
			this.gbMWCheckBoxCombined.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.gbMWCheckBoxCombined.Controls.AddRange(new System.Windows.Forms.Control[] {
																							   this.cbMWCheckBoxEnabled,
																							   this.cbMWCheckBoxRightToLeft,
																							   this.cbMWCheckBoxThreeState,
																							   this.cobMWCheckBoxTextAlign,
																							   this.lblMWCheckBoxTextAlign,
																							   this.cobMWCheckBoxImageAlign,
																							   this.lblMWCheckBoxImageAlign,
																							   this.cbMWCheckBoxUseImage,
																							   this.cobMWCheckBoxFlatStyle,
																							   this.lblMWCheckBoxFlatStyle,
																							   this.cobMWCheckBoxCheckAlign,
																							   this.lblMWCheckBoxCheckAlign,
																							   this.cobMWCheckBoxAppearance,
																							   this.lblMWCheckBoxAppearance});
			this.gbMWCheckBoxCombined.Location = new System.Drawing.Point(456, 8);
			this.gbMWCheckBoxCombined.Name = "gbMWCheckBoxCombined";
			this.gbMWCheckBoxCombined.Size = new System.Drawing.Size(224, 320);
			this.gbMWCheckBoxCombined.TabIndex = 26;
			this.gbMWCheckBoxCombined.TabStop = false;
			this.gbMWCheckBoxCombined.Text = "CheckBox and MWCheckBox Properties";
			// 
			// cbMWCheckBoxEnabled
			// 
			this.cbMWCheckBoxEnabled.Checked = true;
			this.cbMWCheckBoxEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMWCheckBoxEnabled.Location = new System.Drawing.Point(8, 288);
			this.cbMWCheckBoxEnabled.Name = "cbMWCheckBoxEnabled";
			this.cbMWCheckBoxEnabled.Size = new System.Drawing.Size(144, 24);
			this.cbMWCheckBoxEnabled.TabIndex = 37;
			this.cbMWCheckBoxEnabled.Text = "Enabled";
			this.cbMWCheckBoxEnabled.CheckedChanged += new System.EventHandler(this.cbMWCheckBoxEnabled_CheckedChanged);
			// 
			// cbMWCheckBoxRightToLeft
			// 
			this.cbMWCheckBoxRightToLeft.Location = new System.Drawing.Point(8, 200);
			this.cbMWCheckBoxRightToLeft.Name = "cbMWCheckBoxRightToLeft";
			this.cbMWCheckBoxRightToLeft.Size = new System.Drawing.Size(144, 24);
			this.cbMWCheckBoxRightToLeft.TabIndex = 36;
			this.cbMWCheckBoxRightToLeft.Text = "RightToLeft";
			this.cbMWCheckBoxRightToLeft.CheckedChanged += new System.EventHandler(this.cbMWCheckBoxRightToLeft_CheckedChanged);
			// 
			// cbMWCheckBoxThreeState
			// 
			this.cbMWCheckBoxThreeState.Checked = true;
			this.cbMWCheckBoxThreeState.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMWCheckBoxThreeState.Location = new System.Drawing.Point(8, 264);
			this.cbMWCheckBoxThreeState.Name = "cbMWCheckBoxThreeState";
			this.cbMWCheckBoxThreeState.Size = new System.Drawing.Size(144, 24);
			this.cbMWCheckBoxThreeState.TabIndex = 35;
			this.cbMWCheckBoxThreeState.Text = "ThreeState";
			this.cbMWCheckBoxThreeState.CheckedChanged += new System.EventHandler(this.cbMWCheckBoxThreeState_CheckedChanged);
			// 
			// cobMWCheckBoxTextAlign
			// 
			this.cobMWCheckBoxTextAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobMWCheckBoxTextAlign.Location = new System.Drawing.Point(8, 240);
			this.cobMWCheckBoxTextAlign.Name = "cobMWCheckBoxTextAlign";
			this.cobMWCheckBoxTextAlign.Size = new System.Drawing.Size(160, 21);
			this.cobMWCheckBoxTextAlign.TabIndex = 33;
			this.cobMWCheckBoxTextAlign.SelectedIndexChanged += new System.EventHandler(this.cobMWCheckBoxTextAlign_SelectedIndexChanged);
			// 
			// lblMWCheckBoxTextAlign
			// 
			this.lblMWCheckBoxTextAlign.Location = new System.Drawing.Point(8, 224);
			this.lblMWCheckBoxTextAlign.Name = "lblMWCheckBoxTextAlign";
			this.lblMWCheckBoxTextAlign.Size = new System.Drawing.Size(144, 16);
			this.lblMWCheckBoxTextAlign.TabIndex = 34;
			this.lblMWCheckBoxTextAlign.Text = "TextAlign";
			this.lblMWCheckBoxTextAlign.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// cobMWCheckBoxImageAlign
			// 
			this.cobMWCheckBoxImageAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobMWCheckBoxImageAlign.Location = new System.Drawing.Point(8, 176);
			this.cobMWCheckBoxImageAlign.Name = "cobMWCheckBoxImageAlign";
			this.cobMWCheckBoxImageAlign.Size = new System.Drawing.Size(160, 21);
			this.cobMWCheckBoxImageAlign.TabIndex = 31;
			this.cobMWCheckBoxImageAlign.SelectedIndexChanged += new System.EventHandler(this.cobMWCheckBoxImageAlign_SelectedIndexChanged);
			// 
			// lblMWCheckBoxImageAlign
			// 
			this.lblMWCheckBoxImageAlign.Location = new System.Drawing.Point(8, 160);
			this.lblMWCheckBoxImageAlign.Name = "lblMWCheckBoxImageAlign";
			this.lblMWCheckBoxImageAlign.Size = new System.Drawing.Size(144, 16);
			this.lblMWCheckBoxImageAlign.TabIndex = 32;
			this.lblMWCheckBoxImageAlign.Text = "ImageAlign";
			this.lblMWCheckBoxImageAlign.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// cbMWCheckBoxUseImage
			// 
			this.cbMWCheckBoxUseImage.Checked = true;
			this.cbMWCheckBoxUseImage.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbMWCheckBoxUseImage.Location = new System.Drawing.Point(8, 136);
			this.cbMWCheckBoxUseImage.Name = "cbMWCheckBoxUseImage";
			this.cbMWCheckBoxUseImage.Size = new System.Drawing.Size(144, 24);
			this.cbMWCheckBoxUseImage.TabIndex = 30;
			this.cbMWCheckBoxUseImage.Text = "Use Image";
			this.cbMWCheckBoxUseImage.CheckedChanged += new System.EventHandler(this.cbMWCheckBoxUseImage_CheckedChanged);
			// 
			// cobMWCheckBoxFlatStyle
			// 
			this.cobMWCheckBoxFlatStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobMWCheckBoxFlatStyle.Location = new System.Drawing.Point(8, 112);
			this.cobMWCheckBoxFlatStyle.Name = "cobMWCheckBoxFlatStyle";
			this.cobMWCheckBoxFlatStyle.Size = new System.Drawing.Size(160, 21);
			this.cobMWCheckBoxFlatStyle.TabIndex = 28;
			this.cobMWCheckBoxFlatStyle.SelectedIndexChanged += new System.EventHandler(this.cobMWCheckBoxFlatStyle_SelectedIndexChanged);
			// 
			// lblMWCheckBoxFlatStyle
			// 
			this.lblMWCheckBoxFlatStyle.Location = new System.Drawing.Point(8, 96);
			this.lblMWCheckBoxFlatStyle.Name = "lblMWCheckBoxFlatStyle";
			this.lblMWCheckBoxFlatStyle.Size = new System.Drawing.Size(144, 16);
			this.lblMWCheckBoxFlatStyle.TabIndex = 29;
			this.lblMWCheckBoxFlatStyle.Text = "FlatStyle";
			this.lblMWCheckBoxFlatStyle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// cobMWCheckBoxCheckAlign
			// 
			this.cobMWCheckBoxCheckAlign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobMWCheckBoxCheckAlign.Location = new System.Drawing.Point(8, 72);
			this.cobMWCheckBoxCheckAlign.Name = "cobMWCheckBoxCheckAlign";
			this.cobMWCheckBoxCheckAlign.Size = new System.Drawing.Size(160, 21);
			this.cobMWCheckBoxCheckAlign.TabIndex = 26;
			this.cobMWCheckBoxCheckAlign.SelectedIndexChanged += new System.EventHandler(this.cobMWCheckBoxCheckAlign_SelectedIndexChanged);
			// 
			// lblMWCheckBoxCheckAlign
			// 
			this.lblMWCheckBoxCheckAlign.Location = new System.Drawing.Point(8, 56);
			this.lblMWCheckBoxCheckAlign.Name = "lblMWCheckBoxCheckAlign";
			this.lblMWCheckBoxCheckAlign.Size = new System.Drawing.Size(144, 16);
			this.lblMWCheckBoxCheckAlign.TabIndex = 27;
			this.lblMWCheckBoxCheckAlign.Text = "CheckAlign";
			this.lblMWCheckBoxCheckAlign.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// cobMWCheckBoxAppearance
			// 
			this.cobMWCheckBoxAppearance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cobMWCheckBoxAppearance.Location = new System.Drawing.Point(8, 32);
			this.cobMWCheckBoxAppearance.Name = "cobMWCheckBoxAppearance";
			this.cobMWCheckBoxAppearance.Size = new System.Drawing.Size(160, 21);
			this.cobMWCheckBoxAppearance.TabIndex = 24;
			this.cobMWCheckBoxAppearance.SelectedIndexChanged += new System.EventHandler(this.cobMWCheckBoxAppearance_SelectedIndexChanged);
			// 
			// lblMWCheckBoxAppearance
			// 
			this.lblMWCheckBoxAppearance.Location = new System.Drawing.Point(8, 16);
			this.lblMWCheckBoxAppearance.Name = "lblMWCheckBoxAppearance";
			this.lblMWCheckBoxAppearance.Size = new System.Drawing.Size(144, 16);
			this.lblMWCheckBoxAppearance.TabIndex = 25;
			this.lblMWCheckBoxAppearance.Text = "Appearance";
			this.lblMWCheckBoxAppearance.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
			// 
			// lblMWCheckBoxMessage
			// 
			this.lblMWCheckBoxMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblMWCheckBoxMessage.ForeColor = System.Drawing.Color.Blue;
			this.lblMWCheckBoxMessage.Location = new System.Drawing.Point(8, 256);
			this.lblMWCheckBoxMessage.Name = "lblMWCheckBoxMessage";
			this.lblMWCheckBoxMessage.Size = new System.Drawing.Size(440, 176);
			this.lblMWCheckBoxMessage.TabIndex = 30;
			this.lblMWCheckBoxMessage.Text = "NOT DONE!";
			this.lblMWCheckBoxMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// MWControlsTestForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(712, 677);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tcMWControls});
			this.Name = "MWControlsTestForm";
			this.Text = "MWControlsTest";
			this.Load += new System.EventHandler(this.MWControlsTestForm_Load);
			this.tcMWControls.ResumeLayout(false);
			this.tpMWLabel.ResumeLayout(false);
			this.tpMWLabelDir.ResumeLayout(false);
			this.tpMWScrollLabel.ResumeLayout(false);
			this.tpMWTreeView.ResumeLayout(false);
			this.gbMWTreeViewCommands.ResumeLayout(false);
			this.gbMWTreeViewMWTreeView.ResumeLayout(false);
			this.gbMWTreeViewCombined.ResumeLayout(false);
			this.tpMWCheckBox.ResumeLayout(false);
			this.gbMWCheckBoxMWCheckBox.ResumeLayout(false);
			this.gbMWCheckBoxCombined.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion Windows Form Designer generated code



		#region EventHandlers

		private void MWControlsTestForm_Load(object sender, System.EventArgs e)
		{
			FillComboBoxTreeViewMultiSelect();

			FillComboBoxCheckBoxAppearance();
			FillComboBoxCheckBoxCheckAlign();
			FillComboBoxCheckBoxFlatStyle();
			FillComboBoxCheckBoxImageAlign();
			FillComboBoxCheckBoxTextAlign();
			FillComboBoxCheckBoxCheckBoxPaintOrder();
			FillComboBoxCheckBoxStringFormat();
			FillComboBoxCheckBoxTextDir();
		}

		#endregion EventHandlers



		#region Methods

		private void FillComboBoxTreeViewMultiSelect()
		{
			FieldInfo[] afi = typeof(TreeViewMultiSelect).GetFields(BindingFlags.Public | BindingFlags.Static);

			foreach(FieldInfo fi in afi)
			{
				//This shows the name prepended by the enum name!
				//cobMWTreeViewMultiSelect.Items.Add(fi);
			}

			cobMWTreeViewMultiSelect.Items.Add(TreeViewMultiSelect.Classic);
			cobMWTreeViewMultiSelect.Items.Add(TreeViewMultiSelect.NoMulti);
			cobMWTreeViewMultiSelect.Items.Add(TreeViewMultiSelect.Multi);
			cobMWTreeViewMultiSelect.Items.Add(TreeViewMultiSelect.MultiSameBranchAndLevel);
			cobMWTreeViewMultiSelect.Items.Add(TreeViewMultiSelect.MultiSameBranch);
			cobMWTreeViewMultiSelect.Items.Add(TreeViewMultiSelect.MultiSameLevel);
			cobMWTreeViewMultiSelect.Items.Add(TreeViewMultiSelect.MultiPathToParent);
			cobMWTreeViewMultiSelect.Items.Add(TreeViewMultiSelect.MultiPathToParents);
			cobMWTreeViewMultiSelect.Items.Add(TreeViewMultiSelect.SinglePathToParent);
			cobMWTreeViewMultiSelect.Items.Add(TreeViewMultiSelect.SinglePathToParents);

			cobMWTreeViewMultiSelect.SelectedIndex = 2;
		}

		private void FillComboBoxCheckBoxAppearance()
		{
			cobMWCheckBoxAppearance.Items.Add(Appearance.Button);
			cobMWCheckBoxAppearance.Items.Add(Appearance.Normal);

			cobMWCheckBoxAppearance.SelectedIndex = 1;
		}

		private void FillComboBoxCheckBoxCheckAlign()
		{
			cobMWCheckBoxCheckAlign.Items.Add(ContentAlignment.BottomCenter);
			cobMWCheckBoxCheckAlign.Items.Add(ContentAlignment.BottomLeft);
			cobMWCheckBoxCheckAlign.Items.Add(ContentAlignment.BottomRight);
			cobMWCheckBoxCheckAlign.Items.Add(ContentAlignment.MiddleCenter);
			cobMWCheckBoxCheckAlign.Items.Add(ContentAlignment.MiddleLeft);
			cobMWCheckBoxCheckAlign.Items.Add(ContentAlignment.MiddleRight);
			cobMWCheckBoxCheckAlign.Items.Add(ContentAlignment.TopCenter);
			cobMWCheckBoxCheckAlign.Items.Add(ContentAlignment.TopLeft);
			cobMWCheckBoxCheckAlign.Items.Add(ContentAlignment.TopRight);

			cobMWCheckBoxCheckAlign.SelectedIndex = 4;
		}

		private void FillComboBoxCheckBoxFlatStyle()
		{
			cobMWCheckBoxFlatStyle.Items.Add(FlatStyle.Flat);
			cobMWCheckBoxFlatStyle.Items.Add(FlatStyle.Popup);
			cobMWCheckBoxFlatStyle.Items.Add(FlatStyle.Standard);
			cobMWCheckBoxFlatStyle.Items.Add(FlatStyle.System);

			cobMWCheckBoxFlatStyle.SelectedIndex = 2;
		}

		private void FillComboBoxCheckBoxImageAlign()
		{
			cobMWCheckBoxImageAlign.Items.Add(ContentAlignment.BottomCenter);
			cobMWCheckBoxImageAlign.Items.Add(ContentAlignment.BottomLeft);
			cobMWCheckBoxImageAlign.Items.Add(ContentAlignment.BottomRight);
			cobMWCheckBoxImageAlign.Items.Add(ContentAlignment.MiddleCenter);
			cobMWCheckBoxImageAlign.Items.Add(ContentAlignment.MiddleLeft);
			cobMWCheckBoxImageAlign.Items.Add(ContentAlignment.MiddleRight);
			cobMWCheckBoxImageAlign.Items.Add(ContentAlignment.TopCenter);
			cobMWCheckBoxImageAlign.Items.Add(ContentAlignment.TopLeft);
			cobMWCheckBoxImageAlign.Items.Add(ContentAlignment.TopRight);

			cobMWCheckBoxImageAlign.SelectedIndex = 3;
		}

		private void FillComboBoxCheckBoxTextAlign()
		{
			cobMWCheckBoxTextAlign.Items.Add(ContentAlignment.BottomCenter);
			cobMWCheckBoxTextAlign.Items.Add(ContentAlignment.BottomLeft);
			cobMWCheckBoxTextAlign.Items.Add(ContentAlignment.BottomRight);
			cobMWCheckBoxTextAlign.Items.Add(ContentAlignment.MiddleCenter);
			cobMWCheckBoxTextAlign.Items.Add(ContentAlignment.MiddleLeft);
			cobMWCheckBoxTextAlign.Items.Add(ContentAlignment.MiddleRight);
			cobMWCheckBoxTextAlign.Items.Add(ContentAlignment.TopCenter);
			cobMWCheckBoxTextAlign.Items.Add(ContentAlignment.TopLeft);
			cobMWCheckBoxTextAlign.Items.Add(ContentAlignment.TopRight);

			cobMWCheckBoxTextAlign.SelectedIndex = 4;
		}

		private void FillComboBoxCheckBoxCheckBoxPaintOrder()
		{
			cobMWCheckBoxCheckBoxPaintOrder.Items.Add(CheckBoxPaintOrder.CheckImageText);
			cobMWCheckBoxCheckBoxPaintOrder.Items.Add(CheckBoxPaintOrder.CheckTextImage);
			cobMWCheckBoxCheckBoxPaintOrder.Items.Add(CheckBoxPaintOrder.ImageCheckText);
			cobMWCheckBoxCheckBoxPaintOrder.Items.Add(CheckBoxPaintOrder.ImageTextCheck);
			cobMWCheckBoxCheckBoxPaintOrder.Items.Add(CheckBoxPaintOrder.TextCheckImage);
			cobMWCheckBoxCheckBoxPaintOrder.Items.Add(CheckBoxPaintOrder.TextImageCheck);

			cobMWCheckBoxCheckBoxPaintOrder.SelectedIndex = 2;
		}

		private void FillComboBoxCheckBoxStringFormat()
		{
			cobMWCheckBoxStringFormat.Items.Add(StringFormatEnum.GenericDefault);
			cobMWCheckBoxStringFormat.Items.Add(StringFormatEnum.GenericTypographic);

			cobMWCheckBoxStringFormat.SelectedIndex = 1;
		}

		private void FillComboBoxCheckBoxTextDir()
		{
			cobMWCheckBoxTextDir.Items.Add(TextDir.Left);
			cobMWCheckBoxTextDir.Items.Add(TextDir.Normal);
			cobMWCheckBoxTextDir.Items.Add(TextDir.Right);
			cobMWCheckBoxTextDir.Items.Add(TextDir.UpsideDown);

			cobMWCheckBoxTextDir.SelectedIndex = 1;
		}

		#endregion Methods



		#region MWLabel TabPage

		private void btMWLabelText_Click(object sender, System.EventArgs e)
		{
			mwlblTL.Text = tbMWLabelText.Text;
			mwlblTC.Text = tbMWLabelText.Text;
			mwlblTR.Text = tbMWLabelText.Text;
			mwlblML.Text = tbMWLabelText.Text;
			mwlblMC.Text = tbMWLabelText.Text;
			mwlblMR.Text = tbMWLabelText.Text;
			mwlblBL.Text = tbMWLabelText.Text;
			mwlblBC.Text = tbMWLabelText.Text;
			mwlblBR.Text = tbMWLabelText.Text;
		}

		private void btMWLabelEnable_Click(object sender, System.EventArgs e)
		{
			mwlblTL.Enabled = !mwlblTL.Enabled;
			mwlblTC.Enabled = !mwlblTC.Enabled;
			mwlblTR.Enabled = !mwlblTR.Enabled;
			mwlblML.Enabled = !mwlblML.Enabled;
			mwlblMC.Enabled = !mwlblMC.Enabled;
			mwlblMR.Enabled = !mwlblMR.Enabled;
			mwlblBL.Enabled = !mwlblBL.Enabled;
			mwlblBC.Enabled = !mwlblBC.Enabled;
			mwlblBR.Enabled = !mwlblBR.Enabled;
		}

		private void btMWLabelN_Click(object sender, System.EventArgs e)
		{
			mwlblTL.TextDir = MWCommon.TextDir.Normal;
			mwlblTC.TextDir = MWCommon.TextDir.Normal;
			mwlblTR.TextDir = MWCommon.TextDir.Normal;
			mwlblML.TextDir = MWCommon.TextDir.Normal;
			mwlblMC.TextDir = MWCommon.TextDir.Normal;
			mwlblMR.TextDir = MWCommon.TextDir.Normal;
			mwlblBL.TextDir = MWCommon.TextDir.Normal;
			mwlblBC.TextDir = MWCommon.TextDir.Normal;
			mwlblBR.TextDir = MWCommon.TextDir.Normal;
		}

		private void btMWLabelU_Click(object sender, System.EventArgs e)
		{
			mwlblTL.TextDir = MWCommon.TextDir.UpsideDown;
			mwlblTC.TextDir = MWCommon.TextDir.UpsideDown;
			mwlblTR.TextDir = MWCommon.TextDir.UpsideDown;
			mwlblML.TextDir = MWCommon.TextDir.UpsideDown;
			mwlblMC.TextDir = MWCommon.TextDir.UpsideDown;
			mwlblMR.TextDir = MWCommon.TextDir.UpsideDown;
			mwlblBL.TextDir = MWCommon.TextDir.UpsideDown;
			mwlblBC.TextDir = MWCommon.TextDir.UpsideDown;
			mwlblBR.TextDir = MWCommon.TextDir.UpsideDown;
		}

		private void btMWLabelL_Click(object sender, System.EventArgs e)
		{
			mwlblTL.TextDir = MWCommon.TextDir.Left;
			mwlblTC.TextDir = MWCommon.TextDir.Left;
			mwlblTR.TextDir = MWCommon.TextDir.Left;
			mwlblML.TextDir = MWCommon.TextDir.Left;
			mwlblMC.TextDir = MWCommon.TextDir.Left;
			mwlblMR.TextDir = MWCommon.TextDir.Left;
			mwlblBL.TextDir = MWCommon.TextDir.Left;
			mwlblBC.TextDir = MWCommon.TextDir.Left;
			mwlblBR.TextDir = MWCommon.TextDir.Left;
		}

		private void btMWLabelR_Click(object sender, System.EventArgs e)
		{
			mwlblTL.TextDir = MWCommon.TextDir.Right;
			mwlblTC.TextDir = MWCommon.TextDir.Right;
			mwlblTR.TextDir = MWCommon.TextDir.Right;
			mwlblML.TextDir = MWCommon.TextDir.Right;
			mwlblMC.TextDir = MWCommon.TextDir.Right;
			mwlblMR.TextDir = MWCommon.TextDir.Right;
			mwlblBL.TextDir = MWCommon.TextDir.Right;
			mwlblBC.TextDir = MWCommon.TextDir.Right;
			mwlblBR.TextDir = MWCommon.TextDir.Right;
		}

		#endregion MWLabel TabPage



		#region MWScrollLabel TabPage

		private void btMWScrollLabelText_Click(object sender, System.EventArgs e)
		{
			mwslblTL.Text = tbMWScrollLabelText.Text;
			mwslblTC.Text = tbMWScrollLabelText.Text;
			mwslblTR.Text = tbMWScrollLabelText.Text;
			mwslblML.Text = tbMWScrollLabelText.Text;
			mwslblMC.Text = tbMWScrollLabelText.Text;
			mwslblMR.Text = tbMWScrollLabelText.Text;
			mwslblBL.Text = tbMWScrollLabelText.Text;
			mwslblBC.Text = tbMWScrollLabelText.Text;
			mwslblBR.Text = tbMWScrollLabelText.Text;
		}

		private void btMWScrollLabelEnable_Click(object sender, System.EventArgs e)
		{
			mwslblTL.Enabled = !mwslblTL.Enabled;
			mwslblTC.Enabled = !mwslblTC.Enabled;
			mwslblTR.Enabled = !mwslblTR.Enabled;
			mwslblML.Enabled = !mwslblML.Enabled;
			mwslblMC.Enabled = !mwslblMC.Enabled;
			mwslblMR.Enabled = !mwslblMR.Enabled;
			mwslblBL.Enabled = !mwslblBL.Enabled;
			mwslblBC.Enabled = !mwslblBC.Enabled;
			mwslblBR.Enabled = !mwslblBR.Enabled;
		}

		private void btMWScrollLabelN_Click(object sender, System.EventArgs e)
		{
			mwslblTL.TextDir = MWCommon.TextDir.Normal;
			mwslblTC.TextDir = MWCommon.TextDir.Normal;
			mwslblTR.TextDir = MWCommon.TextDir.Normal;
			mwslblML.TextDir = MWCommon.TextDir.Normal;
			mwslblMC.TextDir = MWCommon.TextDir.Normal;
			mwslblMR.TextDir = MWCommon.TextDir.Normal;
			mwslblBL.TextDir = MWCommon.TextDir.Normal;
			mwslblBC.TextDir = MWCommon.TextDir.Normal;
			mwslblBR.TextDir = MWCommon.TextDir.Normal;
		}

		private void btMWScrollLabelU_Click(object sender, System.EventArgs e)
		{
			mwslblTL.TextDir = MWCommon.TextDir.UpsideDown;
			mwslblTC.TextDir = MWCommon.TextDir.UpsideDown;
			mwslblTR.TextDir = MWCommon.TextDir.UpsideDown;
			mwslblML.TextDir = MWCommon.TextDir.UpsideDown;
			mwslblMC.TextDir = MWCommon.TextDir.UpsideDown;
			mwslblMR.TextDir = MWCommon.TextDir.UpsideDown;
			mwslblBL.TextDir = MWCommon.TextDir.UpsideDown;
			mwslblBC.TextDir = MWCommon.TextDir.UpsideDown;
			mwslblBR.TextDir = MWCommon.TextDir.UpsideDown;
		}

		private void btMWScrollLabelL_Click(object sender, System.EventArgs e)
		{
			mwslblTL.TextDir = MWCommon.TextDir.Left;
			mwslblTC.TextDir = MWCommon.TextDir.Left;
			mwslblTR.TextDir = MWCommon.TextDir.Left;
			mwslblML.TextDir = MWCommon.TextDir.Left;
			mwslblMC.TextDir = MWCommon.TextDir.Left;
			mwslblMR.TextDir = MWCommon.TextDir.Left;
			mwslblBL.TextDir = MWCommon.TextDir.Left;
			mwslblBC.TextDir = MWCommon.TextDir.Left;
			mwslblBR.TextDir = MWCommon.TextDir.Left;
		}

		private void btMWScrollLabelR_Click(object sender, System.EventArgs e)
		{
			mwslblTL.TextDir = MWCommon.TextDir.Right;
			mwslblTC.TextDir = MWCommon.TextDir.Right;
			mwslblTR.TextDir = MWCommon.TextDir.Right;
			mwslblML.TextDir = MWCommon.TextDir.Right;
			mwslblMC.TextDir = MWCommon.TextDir.Right;
			mwslblMR.TextDir = MWCommon.TextDir.Right;
			mwslblBL.TextDir = MWCommon.TextDir.Right;
			mwslblBC.TextDir = MWCommon.TextDir.Right;
			mwslblBR.TextDir = MWCommon.TextDir.Right;
		}

		private void MWScrollLabel_MouseEnter(object sender, System.EventArgs e)
		{
			if(sender is MWScrollLabel)
			{
				(sender as MWScrollLabel).ScrollStart();
			}
		}

		private void MWScrollLabel_MouseLeave(object sender, System.EventArgs e)
		{
			if(sender is MWScrollLabel)
			{
				(sender as MWScrollLabel).ScrollStop();
			}
		}

		#endregion MWScrollLabel TabPage



		#region MWLabelDir TabPage

		private int iPix = 8;

		private void btMWLabelDirUp_Click(object sender, System.EventArgs e)
		{
			if(mwlblDir.Height > iPix + 1)
			{
				mwlblDir.Height -= iPix;
			}
			if(mwslblDir.Height > iPix + 1)
			{
				mwslblDir.Height -= iPix;
			}
		}

		private void btMWLabelDirLeft_Click(object sender, System.EventArgs e)
		{
			if(mwlblDir.Width > iPix + 1)
			{
				mwlblDir.Width -= iPix;
			}
			if(mwslblDir.Width > iPix + 1)
			{
				mwslblDir.Width -= iPix;
			}
		}

		private void btMWLabelDirRight_Click(object sender, System.EventArgs e)
		{
			mwlblDir.Width += iPix;
			mwslblDir.Width += iPix;
		}

		private void btMWLabelDirDown_Click(object sender, System.EventArgs e)
		{
			mwlblDir.Height += iPix;
			mwslblDir.Height += iPix;
		}


		private void btMWLabelDirN_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextDir = MWCommon.TextDir.Normal;
			mwslblDir.TextDir = MWCommon.TextDir.Normal;
		}

		private void btMWLabelDirU_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextDir = MWCommon.TextDir.UpsideDown;
			mwslblDir.TextDir = MWCommon.TextDir.UpsideDown;
		}

		private void btMWLabelDirL_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextDir = MWCommon.TextDir.Left;
			mwslblDir.TextDir = MWCommon.TextDir.Left;
		}

		private void btMWLabelDirR_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextDir = MWCommon.TextDir.Right;
			mwslblDir.TextDir = MWCommon.TextDir.Right;
		}


		private void btMWLabelDirSwitch_Click(object sender, System.EventArgs e)
		{
			mwlblDir.Visible = !mwlblDir.Visible;
			mwslblDir.Visible = !mwslblDir.Visible;

			if(mwlblDir.Visible)
			{
				lblMWLabelDir.Text = "MWLabel";
			}
			else
			{
				lblMWLabelDir.Text = "MWScrollLabel";
			}
		}


		private void btMWLabelDirEnable_Click(object sender, System.EventArgs e)
		{
			mwlblDir.Enabled = !mwlblDir.Enabled;
			mwslblDir.Enabled = !mwslblDir.Enabled;
		}


		private void btMWLabelDirTL_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextAlign = ContentAlignment.TopLeft;
			mwslblDir.TextAlign = ContentAlignment.TopLeft;
			IndicateTextAlign(sender);
		}

		private void btMWLabelDirTC_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextAlign = ContentAlignment.TopCenter;
			mwslblDir.TextAlign = ContentAlignment.TopCenter;
			IndicateTextAlign(sender);
		}

		private void btMWLabelDirTR_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextAlign = ContentAlignment.TopRight;
			mwslblDir.TextAlign = ContentAlignment.TopRight;
			IndicateTextAlign(sender);
		}

		private void btMWLabelDirML_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextAlign = ContentAlignment.MiddleLeft;
			mwslblDir.TextAlign = ContentAlignment.MiddleLeft;
			IndicateTextAlign(sender);
		}

		private void btMWLabelDirMC_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextAlign = ContentAlignment.MiddleCenter;
			mwslblDir.TextAlign = ContentAlignment.MiddleCenter;
			IndicateTextAlign(sender);
		}

		private void btMWLabelDirMR_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextAlign = ContentAlignment.MiddleRight;
			mwslblDir.TextAlign = ContentAlignment.MiddleRight;
			IndicateTextAlign(sender);
		}

		private void btMWLabelDirBL_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextAlign = ContentAlignment.BottomLeft;
			mwslblDir.TextAlign = ContentAlignment.BottomLeft;
			IndicateTextAlign(sender);
		}

		private void btMWLabelDirBC_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextAlign = ContentAlignment.BottomCenter;
			mwslblDir.TextAlign = ContentAlignment.BottomCenter;
			IndicateTextAlign(sender);
		}

		private void btMWLabelDirBR_Click(object sender, System.EventArgs e)
		{
			mwlblDir.TextAlign = ContentAlignment.BottomRight;
			mwslblDir.TextAlign = ContentAlignment.BottomRight;
			IndicateTextAlign(sender);
		}

		private void IndicateTextAlign(object ctl)
		{
			btMWLabelDirTL.Text = string.Empty;
			btMWLabelDirTC.Text = string.Empty;
			btMWLabelDirTR.Text = string.Empty;
			btMWLabelDirML.Text = string.Empty;
			btMWLabelDirMC.Text = string.Empty;
			btMWLabelDirMR.Text = string.Empty;
			btMWLabelDirBL.Text = string.Empty;
			btMWLabelDirBC.Text = string.Empty;
			btMWLabelDirBR.Text = string.Empty;

			(ctl as Control).Text = "x";
		}


		private void mwslblDir_MouseEnter(object sender, System.EventArgs e)
		{
			mwslblDir.ScrollStart();
		}

		private void mwslblDir_MouseLeave(object sender, System.EventArgs e)
		{
			mwslblDir.ScrollStop();
		}


		private void btMWLabelDirText_Click(object sender, System.EventArgs e)
		{
			mwlblDir.Text = tbMWLabelDirText.Text;
			mwslblDir.Text = tbMWLabelDirText.Text;
		}

		private void btMWLabelDirSFE_Click(object sender, System.EventArgs e)
		{
			if(mwlblDir.StringFrmt == MWCommon.StringFormatEnum.GenericDefault)
			{
				mwlblDir.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
				mwslblDir.StringFrmt = MWCommon.StringFormatEnum.GenericTypographic;
			}
			else
			{
				mwlblDir.StringFrmt = MWCommon.StringFormatEnum.GenericDefault;
				mwslblDir.StringFrmt = MWCommon.StringFormatEnum.GenericDefault;
			}
		}

		#endregion MWLabelDir TabPage



		#region MWTreeView TabPage

		private void cbMWTreeViewFullRowSelect_CheckedChanged(object sender, System.EventArgs e)
		{
			tvMWTreeView.FullRowSelect = cbMWTreeViewFullRowSelect.Checked;
			mwtvMWTreeView.FullRowSelect = cbMWTreeViewFullRowSelect.Checked;
		}

		private void cbMWTreeViewCheckBoxes_CheckedChanged(object sender, System.EventArgs e)
		{
			tvMWTreeView.CheckBoxes = cbMWTreeViewCheckBoxes.Checked;
			mwtvMWTreeView.CheckBoxes = cbMWTreeViewCheckBoxes.Checked;
		}

		private void cbMWTreeViewLabelEdit_CheckedChanged(object sender, System.EventArgs e)
		{
			tvMWTreeView.LabelEdit = cbMWTreeViewLabelEdit.Checked;
			mwtvMWTreeView.LabelEdit = cbMWTreeViewLabelEdit.Checked;
		}

		private void cbMWTreeViewHideSelection_CheckedChanged(object sender, System.EventArgs e)
		{
			tvMWTreeView.HideSelection = cbMWTreeViewHideSelection.Checked;
			mwtvMWTreeView.HideSelection = cbMWTreeViewHideSelection.Checked;
		}

		private void cbMWTreeViewScrollable_CheckedChanged(object sender, System.EventArgs e)
		{
			tvMWTreeView.Scrollable = cbMWTreeViewScrollable.Checked;
			mwtvMWTreeView.Scrollable = cbMWTreeViewScrollable.Checked;
		}

		private void cbMWTreeViewScrollToSelNode_CheckedChanged(object sender, System.EventArgs e)
		{
			mwtvMWTreeView.ScrollToSelNode = cbMWTreeViewScrollToSelNode.Checked;
		}

		private void cbMWTreeViewAllowBlankNodeText_CheckedChanged(object sender, System.EventArgs e)
		{
			mwtvMWTreeView.AllowBlankNodeText = cbMWTreeViewAllowBlankNodeText.Checked;
		}

		private void cbMWTreeViewAllowNoSelNode_CheckedChanged(object sender, System.EventArgs e)
		{
			mwtvMWTreeView.AllowNoSelNode = cbMWTreeViewAllowNoSelNode.Checked;
		}

		private void cbMWTreeViewUseImageList_CheckedChanged(object sender, System.EventArgs e)
		{
			if(cbMWTreeViewUseImageList.Checked)
			{
				tvMWTreeView.ImageList = ilMWTreeView;
				mwtvMWTreeView.ImageList = ilMWTreeView;
			}
			else
			{
				tvMWTreeView.ImageList = null;
				mwtvMWTreeView.ImageList = null;
			}
		}

		private void cbMWTreeViewShowRootLines_CheckedChanged(object sender, System.EventArgs e)
		{
			tvMWTreeView.ShowRootLines = cbMWTreeViewShowRootLines.Checked;
			mwtvMWTreeView.ShowRootLines = cbMWTreeViewShowRootLines.Checked;
		}

		private void cbMWTreeViewHotTracking_CheckedChanged(object sender, System.EventArgs e)
		{
			tvMWTreeView.HotTracking = cbMWTreeViewHotTracking.Checked;
			mwtvMWTreeView.HotTracking = cbMWTreeViewHotTracking.Checked;
		}

		private void cbMWTreeViewAllowMultiCheck_CheckedChanged(object sender, System.EventArgs e)
		{
			mwtvMWTreeView.AllowMultiCheck = cbMWTreeViewAllowMultiCheck.Checked;
		}

		private void cobMWTreeViewMultiSelect_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			mwtvMWTreeView.MultiSelect = (TreeViewMultiSelect)cobMWTreeViewMultiSelect.SelectedItem;
		}

		private void cbMWTreeViewAllowRubberbandSelect_CheckedChanged(object sender, System.EventArgs e)
		{
			mwtvMWTreeView.AllowRubberbandSelect = cbMWTreeViewAllowRubberbandSelect.Checked;
		}

		private void cobMWTreeViewUseLabelEditRegEx_CheckedChanged(object sender, System.EventArgs e)
		{
			if(cobMWTreeViewUseLabelEditRegEx.Checked)
			{
				mwtvMWTreeView.LabelEditRegEx = tbMWTreeViewLabelEditRegEx.Text.Trim();
			}
			else
			{
				mwtvMWTreeView.LabelEditRegEx = string.Empty;
			}
		}

		private void cobMWTreeViewUseDisallowLabelEditRegEx_CheckedChanged(object sender, System.EventArgs e)
		{
			if(cobMWTreeViewUseDisallowLabelEditRegEx.Checked)
			{
				mwtvMWTreeView.DisallowLabelEditRegEx = tbMWTreeViewDisallowLabelEditRegEx.Text.Trim();
			}
			else
			{
				mwtvMWTreeView.DisallowLabelEditRegEx = string.Empty;
			}
		}

		private void cobMWTreeViewUseSelectNodeRegEx_CheckedChanged(object sender, System.EventArgs e)
		{
			if(cobMWTreeViewUseSelectNodeRegEx.Checked)
			{
				mwtvMWTreeView.SelectNodeRegEx = tbMWTreeViewSelectNodeRegEx.Text.Trim();
			}
			else
			{
				mwtvMWTreeView.SelectNodeRegEx = string.Empty;
			}
		}

		private void cobMWTreeViewUseCheckNodeRegEx_CheckedChanged(object sender, System.EventArgs e)
		{
			if(cobMWTreeViewUseCheckNodeRegEx.Checked)
			{
				mwtvMWTreeView.CheckNodeRegEx = tbMWTreeViewCheckNodeRegEx.Text.Trim();
			}
			else
			{
				mwtvMWTreeView.CheckNodeRegEx = string.Empty;
			}
		}

		Hashtable htSelNodes = null;
		Hashtable htCheckedNodes = null;
		TreeView tv = null;

		private void btMWTreeViewToggleSelNodes_Click(object sender, System.EventArgs e)
		{
			if(htSelNodes == null)
			{
				if(mwtvMWTreeView.SelNodes != null)
				{
					htSelNodes = mwtvMWTreeView.SelNodes.Clone() as Hashtable;
				}

				if(mwtvMWTreeView.CheckedNodes != null)
				{
					htCheckedNodes = mwtvMWTreeView.CheckedNodes.Clone() as Hashtable;
				}

				mwtvMWTreeView.SelNodes = null;

				mwtvMWTreeView.CheckedNodes = null;
			}
			else
			{
				if(htSelNodes != null)
				{
					mwtvMWTreeView.SelNodes = htSelNodes.Clone() as Hashtable;
				}

				if(htCheckedNodes != null)
				{
					mwtvMWTreeView.CheckedNodes = htCheckedNodes.Clone() as Hashtable;
				}

				htSelNodes = null;
				htCheckedNodes = null;
			}
		}

		private void btMWTreeViewClearSelNodes_Click(object sender, System.EventArgs e)
		{
			mwtvMWTreeView.SelNodes = null;
			mwtvMWTreeView.CheckedNodes = null;
		}

		private void btMWTreeViewSaveSelNodes_Click(object sender, System.EventArgs e)
		{
			if(mwtvMWTreeView.SelNodes != null)
			{
				htSelNodes = mwtvMWTreeView.SelNodes.Clone() as Hashtable;
			}

			if(mwtvMWTreeView.CheckedNodes != null)
			{
				htCheckedNodes = mwtvMWTreeView.CheckedNodes.Clone() as Hashtable;
			}
		}

		private void btMWTreeViewLoadSelNodes_Click(object sender, System.EventArgs e)
		{
			if(htSelNodes != null)
			{
				mwtvMWTreeView.SelNodes = htSelNodes.Clone() as Hashtable;
			}

			if(htCheckedNodes != null)
			{
				mwtvMWTreeView.CheckedNodes = htCheckedNodes.Clone() as Hashtable;
			}
		}

		private void btMWTreeViewToggleNodes_Click(object sender, System.EventArgs e)
		{
			if(tv == null)
			{
				mwtvMWTreeView.SelNodes = null;
				mwtvMWTreeView.CheckedNodes = null;

				htSelNodes = null;
				htCheckedNodes = null;

				tv = new TreeView();

				foreach(TreeNode tn in mwtvMWTreeView.Nodes)
				{
					tv.Nodes.Add(tn.Clone() as TreeNode);
				}

				mwtvMWTreeView.Nodes.Clear();
			}
			else
			{
				htSelNodes = null;
				htCheckedNodes = null;

				if(tv != null)
				{
					foreach(TreeNode tn in tv.Nodes)
					{
						mwtvMWTreeView.Nodes.Add(tn.Clone() as TreeNode);
					}
				}

				tv = null;
			}
		}

		private void btMWTreeViewClearNodes_Click(object sender, System.EventArgs e)
		{
			mwtvMWTreeView.SelNodes = null;
			mwtvMWTreeView.CheckedNodes = null;

			mwtvMWTreeView.Nodes.Clear();
		}

		private void btMWTreeViewSaveNodes_Click(object sender, System.EventArgs e)
		{
			mwtvMWTreeView.SelNodes = null;
			mwtvMWTreeView.CheckedNodes = null;

			htSelNodes = null;
			htCheckedNodes = null;

			tv = new TreeView();

			foreach(TreeNode tn in mwtvMWTreeView.Nodes)
			{
				tv.Nodes.Add(tn.Clone() as TreeNode);
			}
		}

		private void btMWTreeViewLoadNodes_Click(object sender, System.EventArgs e)
		{
			htSelNodes = null;
			htCheckedNodes = null;

			if(tv != null)
			{
				foreach(TreeNode tn in tv.Nodes)
				{
					mwtvMWTreeView.Nodes.Add(tn.Clone() as TreeNode);
				}
			}
		}

		private void btMWTreeViewRecreateNodes_Click(object sender, System.EventArgs e)
		{
			this.mwtvMWTreeView.Nodes.Clear();

			AddNodes();
		}

		private void btMWTreeViewAddNodes_Click(object sender, System.EventArgs e)
		{
			AddNodes();
		}

		private void AddNodes()
		{
			this.mwtvMWTreeView.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																					   new System.Windows.Forms.TreeNode("Level0Node0", new System.Windows.Forms.TreeNode[] {
																																												new System.Windows.Forms.TreeNode("L0N0Child0", new System.Windows.Forms.TreeNode[] {
																																																																		new System.Windows.Forms.TreeNode("L0N0N0Child0"),
																																																																		new System.Windows.Forms.TreeNode("L0N0N0Child1"),
																																																																		new System.Windows.Forms.TreeNode("L0N0N0Child2"),
																																																																		new System.Windows.Forms.TreeNode("L0N0N0Child3")}),
																																												new System.Windows.Forms.TreeNode("L0N0Child1"),
																																												new System.Windows.Forms.TreeNode("L0N0Child2", new System.Windows.Forms.TreeNode[] {
																																																																		new System.Windows.Forms.TreeNode("L0N0N2Child0"),
																																																																		new System.Windows.Forms.TreeNode("L0N0N2Child1"),
																																																																		new System.Windows.Forms.TreeNode("L0N0N2Child2"),
																																																																		new System.Windows.Forms.TreeNode("L0N0N2Child3")}),
																																												new System.Windows.Forms.TreeNode("L0N0Child3")}),
																					   new System.Windows.Forms.TreeNode("Level0Node1", new System.Windows.Forms.TreeNode[] {
																																												new System.Windows.Forms.TreeNode("L0N1Child0"),
																																												new System.Windows.Forms.TreeNode("L0N1Child1", new System.Windows.Forms.TreeNode[] {
																																																																		new System.Windows.Forms.TreeNode("L0N1N0Child0", new System.Windows.Forms.TreeNode[] {
																																																																																								  new System.Windows.Forms.TreeNode("L0N1N0N0Child0", new System.Windows.Forms.TreeNode[] {
																																																																																																															  new System.Windows.Forms.TreeNode("L0N1N0N0N0Child0", new System.Windows.Forms.TreeNode[] {
																																																																																																																																							new System.Windows.Forms.TreeNode("L0N1N0N0N0N0Child0")})})})}),
																																												new System.Windows.Forms.TreeNode("L0N1Child2"),
																																												new System.Windows.Forms.TreeNode("L0N1Child3")}),
																					   new System.Windows.Forms.TreeNode("Level0Node2", new System.Windows.Forms.TreeNode[] {
																																												new System.Windows.Forms.TreeNode("L0N2Child0"),
																																												new System.Windows.Forms.TreeNode("L0N2Child1"),
																																												new System.Windows.Forms.TreeNode("L0N2Child2"),
																																												new System.Windows.Forms.TreeNode("L0N2Child3")}),
																					   new System.Windows.Forms.TreeNode("Level0Node3", new System.Windows.Forms.TreeNode[] {
																																												new System.Windows.Forms.TreeNode("L0N3Child0"),
																																												new System.Windows.Forms.TreeNode("L0N3Child1"),
																																												new System.Windows.Forms.TreeNode("L0N3Child2"),
																																												new System.Windows.Forms.TreeNode("L0N3Child3")}),
																					   new System.Windows.Forms.TreeNode("Level0Node4", new System.Windows.Forms.TreeNode[] {
																																												new System.Windows.Forms.TreeNode("L0N4Child0"),
																																												new System.Windows.Forms.TreeNode("L0N4Child1"),
																																												new System.Windows.Forms.TreeNode("L0N4Child2"),
																																												new System.Windows.Forms.TreeNode("L0N4Child3"),
																																												new System.Windows.Forms.TreeNode("L0N4Child4"),
																																												new System.Windows.Forms.TreeNode("L0N4Child5"),
																																												new System.Windows.Forms.TreeNode("L0N4Child6"),
																																												new System.Windows.Forms.TreeNode("L0N4Child7"),
																																												new System.Windows.Forms.TreeNode("L0N4Child8"),
																																												new System.Windows.Forms.TreeNode("L0N4Child9"),
																																												new System.Windows.Forms.TreeNode("L0N4Child10"),
																																												new System.Windows.Forms.TreeNode("L0N4Child11"),
																																												new System.Windows.Forms.TreeNode("L0N4Child12"),
																																												new System.Windows.Forms.TreeNode("L0N4Child13"),
																																												new System.Windows.Forms.TreeNode("L0N4Child14"),
																																												new System.Windows.Forms.TreeNode("L0N4Child15"),
																																												new System.Windows.Forms.TreeNode("L0N4Child16"),
																																												new System.Windows.Forms.TreeNode("L0N4Child17"),
																																												new System.Windows.Forms.TreeNode("L0N4Child18"),
																																												new System.Windows.Forms.TreeNode("L0N4Child19"),
																																												new System.Windows.Forms.TreeNode("L0N4Child20"),
																																												new System.Windows.Forms.TreeNode("L0N4Child21"),
																																												new System.Windows.Forms.TreeNode("L0N4Child22"),
																																												new System.Windows.Forms.TreeNode("L0N4Child23"),
																																												new System.Windows.Forms.TreeNode("L0N4Child24"),
																																												new System.Windows.Forms.TreeNode("L0N4Child25"),
																																												new System.Windows.Forms.TreeNode("L0N4Child26"),
																																												new System.Windows.Forms.TreeNode("L0N4Child27"),
																																												new System.Windows.Forms.TreeNode("L0N4Child28"),
																																												new System.Windows.Forms.TreeNode("L0N4Child29"),
																																												new System.Windows.Forms.TreeNode("L0N4Child30"),
																																												new System.Windows.Forms.TreeNode("L0N4Child31"),
																																												new System.Windows.Forms.TreeNode("L0N4Child32"),
																																												new System.Windows.Forms.TreeNode("L0N4Child33"),
																																												new System.Windows.Forms.TreeNode("L0N4Child34"),
																																												new System.Windows.Forms.TreeNode("L0N4Child35"),
																																												new System.Windows.Forms.TreeNode("L0N4Child36"),
																																												new System.Windows.Forms.TreeNode("L0N4Child37"),
																																												new System.Windows.Forms.TreeNode("L0N4Child38"),
																																												new System.Windows.Forms.TreeNode("L0N4Child39"),
																																												new System.Windows.Forms.TreeNode("L0N4Child40"),
																																												new System.Windows.Forms.TreeNode("L0N4Child41"),
																																												new System.Windows.Forms.TreeNode("L0N4Child42"),
																																												new System.Windows.Forms.TreeNode("L0N4Child43"),
																																												new System.Windows.Forms.TreeNode("L0N4Child44"),
																																												new System.Windows.Forms.TreeNode("L0N4Child45"),
																																												new System.Windows.Forms.TreeNode("L0N4Child46"),
																																												new System.Windows.Forms.TreeNode("L0N4Child47"),
																																												new System.Windows.Forms.TreeNode("L0N4Child48"),
																																												new System.Windows.Forms.TreeNode("L0N4Child49"),
																																												new System.Windows.Forms.TreeNode("L0N4Child50"),
																																												new System.Windows.Forms.TreeNode("L0N4Child51"),
																																												new System.Windows.Forms.TreeNode("L0N4Child52"),
																																												new System.Windows.Forms.TreeNode("L0N4Child53"),
																																												new System.Windows.Forms.TreeNode("L0N4Child54"),
																																												new System.Windows.Forms.TreeNode("L0N4Child55"),
																																												new System.Windows.Forms.TreeNode("L0N4Child56"),
																																												new System.Windows.Forms.TreeNode("L0N4Child57"),
																																												new System.Windows.Forms.TreeNode("L0N4Child58"),
																																												new System.Windows.Forms.TreeNode("L0N4Child59"),
																																												new System.Windows.Forms.TreeNode("L0N4Child60"),
																																												new System.Windows.Forms.TreeNode("L0N4Child61"),
																																												new System.Windows.Forms.TreeNode("L0N4Child62"),
																																												new System.Windows.Forms.TreeNode("L0N4Child63")})});
		}

		private void btMWTreeViewRemoveNode0_Click(object sender, System.EventArgs e)
		{
			mwtvMWTreeView.RemoveNode(mwtvMWTreeView.Nodes[0]);
		}

		#endregion MWTreeView TabPage



		#region MWCheckBox TabPage

		private void cobMWCheckBoxAppearance_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cbMWCheckBox.Appearance = (Appearance)cobMWCheckBoxAppearance.SelectedItem;
			mwcbMWCheckBox.Appearance = (Appearance)cobMWCheckBoxAppearance.SelectedItem;
		}

		private void cobMWCheckBoxCheckAlign_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cbMWCheckBox.CheckAlign = (ContentAlignment)cobMWCheckBoxCheckAlign.SelectedItem;
			mwcbMWCheckBox.CheckAlign = (ContentAlignment)cobMWCheckBoxCheckAlign.SelectedItem;
		}

		private void cobMWCheckBoxFlatStyle_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cbMWCheckBox.FlatStyle = (FlatStyle)cobMWCheckBoxFlatStyle.SelectedItem;
			mwcbMWCheckBox.FlatStyle = (FlatStyle)cobMWCheckBoxFlatStyle.SelectedItem;
		}

		private void cbMWCheckBoxUseImage_CheckedChanged(object sender, System.EventArgs e)
		{
			if(cbMWCheckBoxUseImage.Checked)
			{
				cbMWCheckBox.ImageList = ilMWTreeView;
				mwcbMWCheckBox.ImageList = ilMWTreeView;
			}
			else
			{
				cbMWCheckBox.ImageList = null;
				mwcbMWCheckBox.ImageList = null;
			}
		}

		private void cobMWCheckBoxImageAlign_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cbMWCheckBox.ImageAlign = (ContentAlignment)cobMWCheckBoxImageAlign.SelectedItem;
			mwcbMWCheckBox.ImageAlign = (ContentAlignment)cobMWCheckBoxImageAlign.SelectedItem;
		}

		private void cbMWCheckBoxRightToLeft_CheckedChanged(object sender, System.EventArgs e)
		{
			if(cbMWCheckBoxRightToLeft.Checked)
			{
				cbMWCheckBox.RightToLeft = RightToLeft.Yes;
				mwcbMWCheckBox.RightToLeft = RightToLeft.Yes;
			}
			else
			{
				cbMWCheckBox.RightToLeft = RightToLeft.No;
				mwcbMWCheckBox.RightToLeft = RightToLeft.No;
			}
		}

		private void cobMWCheckBoxTextAlign_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			cbMWCheckBox.TextAlign = (ContentAlignment)cobMWCheckBoxTextAlign.SelectedItem;
			mwcbMWCheckBox.TextAlign = (ContentAlignment)cobMWCheckBoxTextAlign.SelectedItem;
		}

		private void cbMWCheckBoxThreeState_CheckedChanged(object sender, System.EventArgs e)
		{
			cbMWCheckBox.ThreeState = cbMWCheckBoxThreeState.Checked;
			mwcbMWCheckBox.ThreeState = cbMWCheckBoxThreeState.Checked;
		}

		private void cbMWCheckBoxEnabled_CheckedChanged(object sender, System.EventArgs e)
		{
			cbMWCheckBox.Enabled = cbMWCheckBoxEnabled.Checked;
			mwcbMWCheckBox.Enabled = cbMWCheckBoxEnabled.Checked;
		}

		private void cobMWCheckBoxCheckBoxPaintOrder_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			mwcbMWCheckBox.CheckBoxPaintOrder = (CheckBoxPaintOrder)cobMWCheckBoxCheckBoxPaintOrder.SelectedItem;
		}

		private void cobMWCheckBoxStringFormat_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			mwcbMWCheckBox.StringFrmt = (StringFormatEnum)cobMWCheckBoxStringFormat.SelectedItem;
		}

		private void cobMWCheckBoxTextDir_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			mwcbMWCheckBox.TextDir = (TextDir)cobMWCheckBoxTextDir.SelectedItem;
		}

		#endregion MWCheckBox TabPage

	}
}
