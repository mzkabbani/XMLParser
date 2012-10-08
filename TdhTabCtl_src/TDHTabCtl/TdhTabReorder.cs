#region using ...
using System;																								// 1.0.003
using System.Drawing;																						// 1.0.003
using System.Collections;																					// 1.0.003
using System.ComponentModel;																				// 1.0.003
using System.Text.RegularExpressions;																		// 1.0.003
using System.Windows.Forms;																					// 1.0.003
#endregion 

namespace TDHControls.TDHTabCtl																				// 1.0.003
{																											// 1.0.003
	/// <summary>																							// 1.0.003
	/// Summary description for TdhTabReorder.																// 1.0.003
	/// </summary>																							// 1.0.003
	[System.ComponentModel.ToolboxItem(false)]																// 1.0.003
	internal class TdhTabReorder : System.Windows.Forms.Form												// 1.0.003
	{																										// 1.0.003
		#region Windows Component Designer generated instantiation of components
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.TrackBar trackBarMoveTo;
		private System.Windows.Forms.TextBox txtMoveTo;
		private System.Windows.Forms.Button btnReorder_LeftFull;
		private System.Windows.Forms.Button btnReorder_Left;
		private System.Windows.Forms.Button btnReorder_Right;
		private System.Windows.Forms.Button btnReorder_RightFull;
		private System.Windows.Forms.Panel pnlReorderControls;
		private System.Windows.Forms.Panel pnlTabImages;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ToolTip toolTip1;

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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(TdhTabReorder));
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlReorderControls = new System.Windows.Forms.Panel();
			this.trackBarMoveTo = new System.Windows.Forms.TrackBar();
			this.btnReorder_RightFull = new System.Windows.Forms.Button();
			this.btnReorder_Right = new System.Windows.Forms.Button();
			this.btnReorder_Left = new System.Windows.Forms.Button();
			this.btnReorder_LeftFull = new System.Windows.Forms.Button();
			this.txtMoveTo = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.pnlTabImages = new System.Windows.Forms.Panel();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.pnlReorderControls.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBarMoveTo)).BeginInit();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancel.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnCancel.Image")));
			this.btnCancel.Location = new System.Drawing.Point(324, 0);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(24, 24);
			this.btnCancel.TabIndex = 1;
			this.toolTip1.SetToolTip(this.btnCancel, "Reject all TabPage reordering");
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// pnlReorderControls
			// 
			this.pnlReorderControls.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.pnlReorderControls.Controls.AddRange(new System.Windows.Forms.Control[] {
																							 this.trackBarMoveTo,
																							 this.btnReorder_RightFull,
																							 this.btnReorder_Right,
																							 this.btnReorder_Left,
																							 this.btnReorder_LeftFull,
																							 this.txtMoveTo,
																							 this.btnOK,
																							 this.btnCancel});
			this.pnlReorderControls.Location = new System.Drawing.Point(0, 28);
			this.pnlReorderControls.Name = "pnlReorderControls";
			this.pnlReorderControls.Size = new System.Drawing.Size(350, 32);
			this.pnlReorderControls.TabIndex = 0;
			this.pnlReorderControls.TabStop = true;
			// 
			// trackBarMoveTo
			// 
			this.trackBarMoveTo.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.trackBarMoveTo.Location = new System.Drawing.Point(82, -2);
			this.trackBarMoveTo.Name = "trackBarMoveTo";
			this.trackBarMoveTo.Size = new System.Drawing.Size(93, 45);
			this.trackBarMoveTo.TabIndex = 10;
			this.toolTip1.SetToolTip(this.trackBarMoveTo, "Move selected TabPage to the given position");
			this.trackBarMoveTo.Scroll += new System.EventHandler(this.trackBarMoveTo_Scroll);
			// 
			// btnReorder_RightFull
			// 
			this.btnReorder_RightFull.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnReorder_RightFull.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnReorder_RightFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReorder_RightFull.Location = new System.Drawing.Point(258, 0);
			this.btnReorder_RightFull.Name = "btnReorder_RightFull";
			this.btnReorder_RightFull.Size = new System.Drawing.Size(40, 24);
			this.btnReorder_RightFull.TabIndex = 4;
			this.btnReorder_RightFull.Text = ">>|";
			this.toolTip1.SetToolTip(this.btnReorder_RightFull, "Move selected TabPage to End");
			this.btnReorder_RightFull.Click += new System.EventHandler(this.btnReorder_X_Click);
			// 
			// btnReorder_Right
			// 
			this.btnReorder_Right.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnReorder_Right.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnReorder_Right.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReorder_Right.Location = new System.Drawing.Point(217, 0);
			this.btnReorder_Right.Name = "btnReorder_Right";
			this.btnReorder_Right.Size = new System.Drawing.Size(40, 24);
			this.btnReorder_Right.TabIndex = 3;
			this.btnReorder_Right.Text = ">";
			this.toolTip1.SetToolTip(this.btnReorder_Right, "Move selected TabPage one position to the right");
			this.btnReorder_Right.Click += new System.EventHandler(this.btnReorder_X_Click);
			// 
			// btnReorder_Left
			// 
			this.btnReorder_Left.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnReorder_Left.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReorder_Left.Location = new System.Drawing.Point(41, 0);
			this.btnReorder_Left.Name = "btnReorder_Left";
			this.btnReorder_Left.Size = new System.Drawing.Size(40, 24);
			this.btnReorder_Left.TabIndex = 2;
			this.btnReorder_Left.Text = "<";
			this.toolTip1.SetToolTip(this.btnReorder_Left, "Move selected TabPage one position to the left");
			this.btnReorder_Left.Click += new System.EventHandler(this.btnReorder_X_Click);
			// 
			// btnReorder_LeftFull
			// 
			this.btnReorder_LeftFull.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnReorder_LeftFull.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnReorder_LeftFull.Name = "btnReorder_LeftFull";
			this.btnReorder_LeftFull.Size = new System.Drawing.Size(40, 24);
			this.btnReorder_LeftFull.TabIndex = 1;
			this.btnReorder_LeftFull.Text = "|<<";
			this.toolTip1.SetToolTip(this.btnReorder_LeftFull, "Move selected TabPage to Start");
			this.btnReorder_LeftFull.Click += new System.EventHandler(this.btnReorder_X_Click);
			// 
			// txtMoveTo
			// 
			this.txtMoveTo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.txtMoveTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.txtMoveTo.Location = new System.Drawing.Point(176, 0);
			this.txtMoveTo.MaxLength = 5;
			this.txtMoveTo.Name = "txtMoveTo";
			this.txtMoveTo.Size = new System.Drawing.Size(40, 20);
			this.txtMoveTo.TabIndex = 11;
			this.txtMoveTo.Text = "";
			this.txtMoveTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.toolTip1.SetToolTip(this.txtMoveTo, "Move selected TabPage to the given position");
			this.txtMoveTo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txtMoveTo_MouseDown);
			this.txtMoveTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMoveTo_KeyPress);
			this.txtMoveTo.Leave += new System.EventHandler(this.txtMoveTo_Leave);
			this.txtMoveTo.Enter += new System.EventHandler(this.txtMoveTo_Enter);
			// 
			// btnOK
			// 
			this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnOK.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnOK.Image")));
			this.btnOK.Location = new System.Drawing.Point(299, 0);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(24, 24);
			this.btnOK.TabIndex = 0;
			this.toolTip1.SetToolTip(this.btnOK, "Accept TabPage current reordering");
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// pnlTabImages
			// 
			this.pnlTabImages.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.pnlTabImages.AutoScroll = true;
			this.pnlTabImages.Name = "pnlTabImages";
			this.pnlTabImages.Size = new System.Drawing.Size(350, 28);
			this.pnlTabImages.TabIndex = 10;
			// 
			// TdhTabReorder
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(348, 58);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pnlReorderControls,
																		  this.pnlTabImages});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TdhTabReorder";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.pnlReorderControls.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBarMoveTo)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion


		#region Class variables 
		private TDHTabCtl.TdhTabCtl _theTabCtl = null;														// 1.0.003
		System.Collections.ArrayList _alTabImages = new System.Collections.ArrayList();						// 1.0.003
		System.Collections.ArrayList _alTabPointers = new System.Collections.ArrayList();					// 1.0.003
		private int _idxPbxActive = -1;																		// 1.0.003

		private string _txtMoveTo_TextAtEnter = "";															// 1.0.003
		private string _txtMoveTo_regexFilter = @"^\d+$";													// 1.0.003
		private System.Text.RegularExpressions.Regex _regexFilter = null;									// 1.0.003
		#endregion 

		#region (Form) TdhTabReorder class constructor (and Dispose), etc
		// public TdhTabReorder(
		//     TDHTabCtl.TdhTabCtl theTabCtl, int activeTabPage_Idx, 
		//     System.Drawing.Point ptShow, int height, int width 
		// )
		// 
		// protected override void Dispose( bool disposing )
		// 
		// protected override void OnActivated(System.EventArgs e)
		// 
		public TdhTabReorder(																				// 1.0.003
			TDHTabCtl.TdhTabCtl theTabCtl, int activeTabPage_Idx,											// 1.0.003
			System.Drawing.Point ptShow, int height, int width												// 1.0.003
		)																									// 1.0.003
		{																									// 1.0.003
			//																								// 1.0.003
			// Required for Windows Form Designer support													// 1.0.003
			//																								// 1.0.003
			InitializeComponent();																			// 1.0.003
			//																								// 1.0.003
			// TODO: Add any constructor code after InitializeComponent call								// 1.0.003
			//																								// 1.0.003
			this.DialogResult = System.Windows.Forms.DialogResult.None;										// 1.0.003

			//this.Location = this.PointToScreen(ptShow);													// 1.0.003
			this.Location = ptShow;																			// 1.0.003

			this.ClientSize = new System.Drawing.Size(348, 58);												// 1.0.004
			if (height >= 60)																				// 1.0.003
			{																								// 1.0.003
				this.Height = height;																		// 1.0.003
			}																								// 1.0.003
			if (width >= 350)																				// 1.0.004
			{																								// 1.0.003
				this.Width = width;																			// 1.0.003
			}																								// 1.0.003

			this._idxPbxActive = activeTabPage_Idx;															// 1.0.003
			this._theTabCtl = theTabCtl;																	// 1.0.003
			trackBarMoveTo_SetProperties(this._theTabCtl.TabCount);											// 1.0.003

			pbxWork_X_Build(activeTabPage_Idx);																// 1.0.003
			trackBarMoveTo_SetValue(this._idxPbxActive + 1);												// 1.0.003
			this.trackBarMoveTo.Focus();																	// 1.0.003
		}																									// 1.0.003


		/// <summary>																						// 1.0.003
		/// Clean up any resources being used.																// 1.0.003
		/// </summary>																						// 1.0.003
		protected override void Dispose( bool disposing )													// 1.0.003
		{																									// 1.0.003
			if( disposing )																					// 1.0.003
			{																								// 1.0.003
				if(components != null)																		// 1.0.003
				{																							// 1.0.003
					components.Dispose();																	// 1.0.003
				}																							// 1.0.003
			}																								// 1.0.003
			base.Dispose( disposing );																		// 1.0.003
		}																									// 1.0.003


		protected override void OnActivated(System.EventArgs e)												// 1.0.001
		{																									// 1.0.001
			base.OnActivated(e);																			// 1.0.001

			this.DialogResult = System.Windows.Forms.DialogResult.None;										// 1.0.003

			//this.pnlTabImages.Controls[this._idxPbxActive].Select();										// 1.0.003
			this.pnlTabImages.ScrollControlIntoView(this.pnlTabImages.Controls[this._idxPbxActive]);		// 1.0.003

			trackBarMoveTo_SetValue(this._idxPbxActive + 1);												// 1.0.003
			this.trackBarMoveTo.Focus();																	// 1.0.003
		}																									// 1.0.003
		#endregion 

		#region Navigation EventHandlers (and related Methods) -- for [trackBarMoveTo] and [txtMoveTo]
		// private void trackBarMoveTo_Scroll(object sender, System.EventArgs e)
		// private int trackBarMoveTo_SetValue(int setValue)
		// private void trackBarMoveTo_SetProperties(int nbrTabPages)
		// 
		// private void txtMoveTo_Enter(object sender, System.EventArgs e)
		// private void txtMoveTo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		// private void txtMoveTo_Leave(object sender, System.EventArgs e)
		// private void txtMoveTo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		// 
		private void trackBarMoveTo_Scroll(object sender, System.EventArgs e)								// 1.0.003
		{																									// 1.0.003
			Reorder_Work(trackBarMoveTo.Value.ToString());													// 1.0.004
		}																									// 1.0.003

		private int trackBarMoveTo_SetValue(int setValue)													// 1.0.004
		{																									// 1.0.003
			if (setValue <= 0)																				// 1.0.003
			{																								// 1.0.003
				trackBarMoveTo.Value = 1;																	// 1.0.003
			}																								// 1.0.003
			else																							// 1.0.003
			if (setValue >= trackBarMoveTo.Maximum)															// 1.0.003
			{																								// 1.0.003
				trackBarMoveTo.Value = trackBarMoveTo.Maximum;												// 1.0.003
			}																								// 1.0.003
			else																							// 1.0.003
			{																								// 1.0.003
				trackBarMoveTo.Value = setValue;															// 1.0.003
			}																								// 1.0.003
			txtMoveTo.Text = trackBarMoveTo.Value.ToString();												// 1.0.003

			return trackBarMoveTo.Value;																	// 1.0.004
		}																									// 1.0.003

		private void trackBarMoveTo_SetProperties(int nbrTabPages)											// 1.0.003
		{																									// 1.0.003
			this.trackBarMoveTo.Minimum = 1;																// 1.0.003
			this.trackBarMoveTo.Maximum = System.Math.Max(1, nbrTabPages);									// 1.0.003

			if (this.trackBarMoveTo.Maximum <= 40)															// 1.0.003
			{																								// 1.0.003
				this.trackBarMoveTo.LargeChange = System.Math.Max(1, (int)(this.trackBarMoveTo.Maximum / 10));	// 1.0.003
				if (this.trackBarMoveTo.Maximum <= 25)														// 1.0.003
				{																							// 1.0.003
					this.trackBarMoveTo.TickFrequency = 1;													// 1.0.003
				}																							// 1.0.003
				else																						// 1.0.003
				{																							// 1.0.003
					this.trackBarMoveTo.TickFrequency = 2;													// 1.0.003
				}																							// 1.0.003
			}																								// 1.0.003
			else																							// 1.0.003
			{																								// 1.0.003
				this.trackBarMoveTo.LargeChange = System.Math.Max(1, (int)(this.trackBarMoveTo.Maximum / 15));	// 1.0.003
				this.trackBarMoveTo.TickFrequency = 5;														// 1.0.003
			}																								// 1.0.003
			this.trackBarMoveTo.SmallChange = 1;															// 1.0.003
		}																									// 1.0.003


		private void txtMoveTo_Enter(object sender, System.EventArgs e)										// 1.0.003
		{																									// 1.0.003
			if (this._txtMoveTo_TextAtEnter.Length <= 0)													// 1.0.004
			{																								// 1.0.004
				this._txtMoveTo_TextAtEnter = this.txtMoveTo.Text;											// 1.0.003
				if (this.txtMoveTo.SelectionLength <= 0)													// 1.0.003
				{																							// 1.0.003
					this.txtMoveTo.SelectAll();																// 1.0.003
				}																							// 1.0.003
			}																								// 1.0.004
		}																									// 1.0.003

		private void txtMoveTo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)			// 1.0.003
		{																									// 1.0.003
			#region Done: If [Keys.Escape] Or [Keys.Return]
			// If [Keys.Escape] restore [this.txtMoveTo.Text]												// 1.0.003
			if (e.KeyChar == (char)27)		// Keys.Escape													// 1.0.003
			{																								// 1.0.003
				this.txtMoveTo.Text = this._txtMoveTo_TextAtEnter;											// 1.0.003
				this.txtMoveTo.SelectAll();																	// 1.0.003
				e.Handled = true;																			// 1.0.003
				return;																						// 1.0.003
			}																								// 1.0.003

			// If [Keys.Return] use value of [this.txtMoveTo.Text] at NewLocation for TabPage				// 1.0.003
			if (e.KeyChar == (char)13)		// Keys.Return													// 1.0.003
			{																								// 1.0.003
				e.Handled = true;																			// 1.0.003
				Reorder_Work(this.txtMoveTo.Text);															// 1.0.004
				return;																						// 1.0.003
			}																								// 1.0.003
			#endregion 

			string _KeyChar = e.KeyChar.ToString();															// 1.0.003

			// If the typed character is a backspace, then do not bother matching.							// 1.0.003
			if (_KeyChar == "\b")																			// 1.0.003
			{																								// 1.0.003
				return;																						// 1.0.003
			}																								// 1.0.003

			// Create a string to represent what the text will be if the input is successful,				// 1.0.003
			// so that we can test it to see if it is valid.												// 1.0.003
			string inputText = this.txtMoveTo.Text;															// 1.0.003
			// If some text is selected, then remove the selected text. We are replacing it.				// 1.0.003
			if (this.txtMoveTo.SelectionLength > 0)															// 1.0.003
			{																								// 1.0.003
				inputText = inputText.Remove(this.txtMoveTo.SelectionStart, this.txtMoveTo.SelectionLength);// 1.0.003
			}																								// 1.0.003
			// Add the typed character after the cursor.													// 1.0.003
			inputText = inputText.Insert(this.txtMoveTo.SelectionStart, _KeyChar);							// 1.0.003

			if (this._regexFilter == null)																	// 1.0.003
			{																								// 1.0.003
				// Set up a regular expression class with [_txtMoveTo_TextAtEnter] as the regular expression.// 1.0.003
				this._regexFilter = new System.Text.RegularExpressions.Regex(this._txtMoveTo_regexFilter);	// 1.0.003
			}																								// 1.0.003
			// If the current text, plus the typed character, does not fit into the regular expression,		// 1.0.003
			// then set handled to true (thus, the typed character is rejected).							// 1.0.003
			if (!this._regexFilter.IsMatch(inputText))														// 1.0.003
			//if (!this._regexFilter.IsMatch(_KeyChar))	// Validate only the individual typed character		// 1.0.003
			{																								// 1.0.003
				e.Handled = true;																			// 1.0.003
			}																								// 1.0.003
		}																									// 1.0.003

		private void txtMoveTo_Leave(object sender, System.EventArgs e)										// 1.0.003
		{																									// 1.0.003
			//this._txtMoveTo_TextAtEnter = "";																// 1.0.004
			Reorder_Work(this.txtMoveTo.Text);																// 1.0.004
		}																									// 1.0.003

		private void txtMoveTo_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)				// 1.0.003
		{																									// 1.0.003
			txtMoveTo_Enter(sender, System.EventArgs.Empty);
		}																									// 1.0.003
		#endregion 

		#region EventHandlers 
		// private void btnCancel_Click(object sender, System.EventArgs e)
		// private void btnOK_Click(object sender, System.EventArgs e)
		// 
		// private void pbxWork_X_Click(object sender, System.EventArgs e)
		// 
		// private void btnReorder_X_Click(object sender, System.EventArgs e)
		// 
		private void btnCancel_Click(object sender, System.EventArgs e)										// 1.0.003
		{																									// 1.0.003
			// Done: Reject Edit Action																		// 1.0.003
			this.DialogResult = System.Windows.Forms.DialogResult.Cancel;									// 1.0.003
			this.Hide();																					// 1.0.003
		}																									// 1.0.003

		private void btnOK_Click(object sender, System.EventArgs e)											// 1.0.003
		{																									// 1.0.003
			// Done: Accept Edit Action																		// 1.0.003
			this.DialogResult = System.Windows.Forms.DialogResult.OK;										// 1.0.003
			this.Hide();																					// 1.0.003
		}																									// 1.0.003

		
		private void pbxWork_X_Click(object sender, System.EventArgs e)										// 1.0.003
		{																									// 1.0.003
			int idxPbxDeactive = this._idxPbxActive;						// idx to old active PictureBox	// 1.0.003
			System.Windows.Forms.PictureBox pbxDeactive = (System.Windows.Forms.PictureBox)this.pnlTabImages.Controls[idxPbxDeactive];	// 1.0.003
			int idxTabDeactive = (int)this._alTabPointers[idxPbxDeactive];	// Pointer to actual TabPage	// 1.0.003
			System.Drawing.Bitmap imgDeactive = Create_TabPageImage(idxTabDeactive, false);	// Get TabImage	// 1.0.003
			_alTabImages[idxPbxDeactive] = imgDeactive;						// Replace TabImage in ArrayList// 1.0.003
			pbxDeactive.Image = imgDeactive;								// Assign TabImage to PictureBox// 1.0.003

			System.Windows.Forms.PictureBox pbxActive = (System.Windows.Forms.PictureBox)sender;			// 1.0.003
			int idxPbxActive = pbxActive.TabIndex;							// idx to new active PictureBox	// 1.0.003
			int idxTabActive = (int)this._alTabPointers[idxPbxActive];		// Pointer to actual TabPage	// 1.0.003
			System.Drawing.Bitmap imgActive = Create_TabPageImage(idxTabActive, true);		// Get TabImage	// 1.0.003
			_alTabImages[idxPbxActive] = imgActive;							// Replace TabImage in ArrayList// 1.0.003
			pbxActive.Image = imgActive;									// Assign TabImage to PictureBox// 1.0.003

			this._idxPbxActive = idxPbxActive;				// Keep idx to this new active PictureBox		// 1.0.003
			//pbxWork_X_Assignments();						// Not necessary here (it's effectively done)	// 1.0.003
			trackBarMoveTo_SetValue(this._idxPbxActive + 1);												// 1.0.003
			this.trackBarMoveTo.Focus();																	// 1.0.003
		}																									// 1.0.003


		private void btnReorder_X_Click(object sender, System.EventArgs e)									// 1.0.003
		{																									// 1.0.003
			#region Validate Pointer to current active selection
			// This particular situation should never occur													// 1.0.003
			if (!ActivePointerIsValid())																	// 1.0.003
			{																								// 1.0.003
				trackBarMoveTo_SetValue(this._idxPbxActive + 1);											// 1.0.004
				this.txtMoveTo.Focus();																		// 1.0.004
				//this.trackBarMoveTo.Focus();																// 1.0.004
				return;																						// 1.0.003
			}																								// 1.0.003
			#endregion 

			#region Build old/current and new position pointers
			int idxOldPosition = this._idxPbxActive;	// Pointer to current active selection, or index to	// 1.0.003
			int idxNewPosition = -1;					//   [this._alTabPointers] and [this._alTabImages]	// 1.0.003
			System.Windows.Forms.Button btnSender = (System.Windows.Forms.Button)sender;					// 1.0.003
			if (btnSender == btnReorder_LeftFull)															// 1.0.003
			{																								// 1.0.003
				idxNewPosition = 0;																			// 1.0.003
			}																								// 1.0.003
			else																							// 1.0.003
			if (btnSender == btnReorder_Left)																// 1.0.003
			{																								// 1.0.003
				idxNewPosition = idxOldPosition - 1;														// 1.0.003
			}																								// 1.0.003
			else																							// 1.0.003
			if (btnSender == btnReorder_Right)																// 1.0.003
			{																								// 1.0.003
				idxNewPosition = idxOldPosition + 1;														// 1.0.003
			}																								// 1.0.003
			else																							// 1.0.003
			if (btnSender == btnReorder_RightFull)															// 1.0.003
			{																								// 1.0.003
				idxNewPosition = this._alTabPointers.Count;													// 1.0.003
			}																								// 1.0.003
			#endregion 
			Reorder_Work(idxOldPosition, idxNewPosition);													// 1.0.004
		}																									// 1.0.003
		#endregion

		#region Private Functions/Methods
		// private bool ActivePointerIsValid()
		// 
		// private System.Drawing.Bitmap Create_TabPageImage(int idxTabPage, bool asActive)
		// 
		// private void pbxWork_X_Assignments()
		// private void pbxWork_X_Build(int activeTabPage_Idx)
		// 
		// private void Reorder_Work(string parmMoveTo)
		// private void Reorder_Work(int idxOldPosition, int idxNewPosition)
		// 
		private bool ActivePointerIsValid()																	// 1.0.003
		{																									// 1.0.003
			// Validate Pointer to current active selection													// 1.0.003
			// This particular situation should never occur													// 1.0.003
			if ((this._idxPbxActive < 0) || (this._idxPbxActive >= this._alTabPointers.Count))				// 1.0.003
			{																								// 1.0.003
				this._idxPbxActive = 0;						// It's bad; Reset it							// 1.0.003
				pbxWork_X_Build(0);							// Rebuild everything							// 1.0.003

				//this.pnlTabImages.Controls[this._idxPbxActive].Select();									// 1.0.003
				this.pnlTabImages.ScrollControlIntoView(this.pnlTabImages.Controls[this._idxPbxActive]);	// 1.0.003

				trackBarMoveTo_SetValue(this._idxPbxActive + 1);											// 1.0.003
				this.trackBarMoveTo.Focus();																// 1.0.003

				return false;																				// 1.0.003
			}																								// 1.0.003
			return true;																					// 1.0.003
		}																									// 1.0.003


		private System.Drawing.Bitmap Create_TabPageImage(int idxTabPage, bool asActive)					// 1.0.003
		{																									// 1.0.003
			// Create TabPage images																		// 1.0.003
			#region Create/Set working variables 
			System.Drawing.Point ptMouse = new System.Drawing.Point(0, 0);	// mouse pseudo-location		// 1.0.003

			System.Drawing.RectangleF tabRectDraw = this._theTabCtl.TabRect_ByIdx(idxTabPage);				// 1.0.003
			System.Drawing.Bitmap bmImage = new System.Drawing.Bitmap(										// 1.0.003
				(int)tabRectDraw.Width, (int)tabRectDraw.Height,											// 1.0.003
				System.Drawing.Imaging.PixelFormat.Format32bppRgb);											// 1.0.003
			System.Drawing.RectangleF rectImage = new System.Drawing.RectangleF(0f, 0f, tabRectDraw.Width, tabRectDraw.Height);	// 1.0.003

			System.Drawing.Graphics gfxImage = System.Drawing.Graphics.FromImage(bmImage);					// 1.0.003
			gfxImage.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;						// 1.0.003
			#endregion  
			TDHTabCtl.TdhTabCtl.TabRect_DrawTabRect(														// 1.0.003
				this._theTabCtl, ptMouse,																	// 1.0.003
				this._theTabCtl.TdhTabPages[true, idxTabPage],												// 1.0.010
				idxTabPage, asActive,																		// 1.0.003
				gfxImage, rectImage																			// 1.0.003
			);																								// 1.0.003
			gfxImage.Dispose();																				// 1.0.003

			return bmImage;																					// 1.0.003
		}																									// 1.0.003


		private void pbxWork_X_Assignments()																// 1.0.003
		{																									// 1.0.003
			// Set [pbxWork.Image] and [pbxWork.Size] and [pbxWork.Location]								// 1.0.003
			this.pnlTabImages.SuspendLayout();																// 1.0.003
			// Setting [pnlTabImages.AutoScrollPosition] allows setting proper relative [pbxWork.Location]	// 1.0.003
			this.pnlTabImages.AutoScrollPosition = new System.Drawing.Point(0, 0);							// 1.0.003
			int locOffset = 1;																				// 1.0.003
			for (int idx = 0; idx < this._alTabImages.Count; idx++)											// 1.0.003
			{																								// 1.0.003
				System.Drawing.Bitmap bmpWork = (System.Drawing.Bitmap)_alTabImages[idx];					// 1.0.003

				System.Windows.Forms.PictureBox pbxWork = (System.Windows.Forms.PictureBox)this.pnlTabImages.Controls[idx];	// 1.0.003
				pbxWork.Image = bmpWork;																	// 1.0.003
				pbxWork.Size = new System.Drawing.Size(bmpWork.Width, bmpWork.Height);						// 1.0.003
				pbxWork.Location = new System.Drawing.Point(locOffset, 0);									// 1.0.003

				locOffset += pbxWork.Width + 1;																// 1.0.003
			}																								// 1.0.003
			this.pnlTabImages.ResumeLayout(false);															// 1.0.003
			//this.pnlTabImages.Invalidate();																// 1.0.003
		}																									// 1.0.003

		private void pbxWork_X_Build(int activeTabPage_Idx)													// 1.0.003
		{																									// 1.0.003
			this._idxPbxActive = activeTabPage_Idx;															// 1.0.003

			#region Create TabPage Images; Store in ArrayList [_alTabImages.Add(image)]; 
			// Create TabPage images; Create PictureBox controls to display TabPage images					// 1.0.003
			this._alTabImages = new System.Collections.ArrayList(this._theTabCtl.TabCount);					// 1.0.003
			this._alTabPointers = new System.Collections.ArrayList(this._theTabCtl.TabCount);				// 1.0.003

			this.pnlTabImages.Controls.Clear();																// 1.0.003
			this.pnlTabImages.SuspendLayout();																// 1.0.003
			for (int idx = 0; idx < this._theTabCtl.TabCount; idx++)										// 1.0.003
			{																								// 1.0.003
				#region Create TabPage image; Store in ArrayList [_alTabImages.Add(image);]
				bool asActive = false;																		// 1.0.003
				if (idx == this._idxPbxActive)				// Show this as the active TabPage?				// 1.0.003
				{																							// 1.0.003
					asActive = true;																		// 1.0.003
				}																							// 1.0.003
				// Create the TabPage image; Store in ArrayList [_alTabImages.Add(image);]					// 1.0.003
				this._alTabImages.Add(this.Create_TabPageImage(idx, asActive));								// 1.0.010
				this._alTabPointers.Add(idx);	// Index of current TabPage order (reordering will change this)	// 1.0.003
				#endregion 

				#region Create PictureBox controls to display TabPage images [this.pnlTabImages.Controls.Add(pbxWork);]
				System.Windows.Forms.PictureBox pbxWork = new System.Windows.Forms.PictureBox();			// 1.0.003
				pbxWork.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;							// 1.0.003
				pbxWork.Name = "pbxWork_"+ idx.ToString();													// 1.0.003
				pbxWork.TabIndex = idx;		// Index to original TabPage order (this will not change)		// 1.0.003
				pbxWork.Tag = idx;																			// 1.0.003
				pbxWork.TabStop = false;																	// 1.0.003
				pbxWork.Click += new System.EventHandler(this.pbxWork_X_Click);								// 1.0.003

				this.pnlTabImages.Controls.Add(pbxWork);													// 1.0.003
				#endregion 
			}																								// 1.0.003
			this.pnlTabImages.ResumeLayout(false);															// 1.0.003
			#endregion 
			#region Assign TabPage Images to PictureBoxes in [this.pnlTabImages]
			// Set [pbxWork.Image] and [pbxWork.Size] and [pbxWork.Location]								// 1.0.003
			pbxWork_X_Assignments();																		// 1.0.003
			#endregion 

			#region Ensure [this.Height] is sufficient to display the PictureBoxes in [this.pnlTabImages]
			// Ensure [this.Height] is sufficient to display the PictureBoxes in [this.pnlTabImages]
			System.Windows.Forms.PictureBox pbxLast = (System.Windows.Forms.PictureBox)this.pnlTabImages.Controls[this.pnlTabImages.Controls.Count - 1];	// 1.0.003
			if( ((pbxLast.Location.X + pbxLast.Width) > this.pnlTabImages.Width)							// 1.0.003
			&& (this.pnlTabImages.Height < (pbxLast.Height + SystemInformation.HorizontalScrollBarHeight))	// 1.0.011
			)																								// 1.0.003
			{																								// 1.0.003
				this.Height += SystemInformation.HorizontalScrollBarHeight;	// Add .Height for ScrollBar	// 1.0.011
			}																								// 1.0.003
			pbxLast = null;																					// 1.0.003
			#endregion 
		}																									// 1.0.003


		private void Reorder_Work(string parmMoveTo)														// 1.0.004
		{																									// 1.0.003
			this._txtMoveTo_TextAtEnter = "";																// 1.0.004
			#region Validate Pointer to current active selection
			// This particular situation should never occur													// 1.0.004
			if (!ActivePointerIsValid())																	// 1.0.004
			{																								// 1.0.004
				trackBarMoveTo_SetValue(this._idxPbxActive + 1);											// 1.0.004
				this.txtMoveTo.Focus();																		// 1.0.004
				//this.trackBarMoveTo.Focus();																// 1.0.004
				return;																						// 1.0.004
			}																								// 1.0.004
			#endregion 

			int moveTo = 0;																					// 1.0.003
			double dummyDouble = 0.0;																		// 1.0.003
			// Actually, the RegularExpression will guarantee that [parmMoveTo] is numeric					// 1.0.004
			if (StringIs.Numeric(parmMoveTo, out moveTo, out dummyDouble) )									// 1.0.004
			{																								// 1.0.003
				moveTo = trackBarMoveTo_SetValue(moveTo);													// 1.0.004
				//this.trackBarMoveTo.Focus();																// 1.0.003

				// Build old/current and new position pointers												// 1.0.004
				int idxOldPosition = this._idxPbxActive;// Pointer to current active selection, or index to	// 1.0.004
				int idxNewPosition = moveTo - 1;		//   [this._alTabPointers] and [this._alTabImages]	// 1.0.004
				Reorder_Work(idxOldPosition, idxNewPosition);												// 1.0.004
			}																								// 1.0.003
		}																									// 1.0.003

		private void Reorder_Work(int idxOldPosition, int idxNewPosition)									// 1.0.004
		{																									// 1.0.004
			if(( (idxNewPosition > -1)								// Can't move leftmost to the left		// 1.0.003
				|| (idxOldPosition > 0) )																	// 1.0.004
			&&( (idxOldPosition != this._alTabPointers.Count - 1)	// Can't move rightmost to the right	// 1.0.003
				|| (idxNewPosition < this._alTabPointers.Count) )											// 1.0.003
			)																								// 1.0.003
			{																								// 1.0.003
				#region If we let a value [ (idxNewPosition < 0) ] into this code-block, fix the value
				if (idxNewPosition < 0)																		// 1.0.004
				{																							// 1.0.004
					idxNewPosition = 0;																		// 1.0.004
				}																							// 1.0.004
				#endregion 

				#region "Move" the TabPage (i.e. move its Pointer and TabRect Image within the respective ArrayLists)
				object pointer = this._alTabPointers[idxOldPosition];	// Pointer to the actual TabPage	// 1.0.003
				object image = this._alTabImages[idxOldPosition];		// Image of the TabPage TabRect		// 1.0.003

				this._alTabPointers.RemoveAt(idxOldPosition);												// 1.0.003
				this._alTabImages.RemoveAt(idxOldPosition);													// 1.0.003
				if (idxNewPosition >= this._alTabPointers.Count)											// 1.0.003
				{																							// 1.0.003
					this._alTabPointers.Add(pointer);														// 1.0.003
					this._alTabImages.Add(image);															// 1.0.003
					this._idxPbxActive = this._alTabPointers.Count - 1;										// 1.0.003
				}																							// 1.0.003
				else																						// 1.0.003
				{																							// 1.0.003
					this._alTabPointers.Insert(idxNewPosition, pointer);									// 1.0.003
					this._alTabImages.Insert(idxNewPosition, image);										// 1.0.003
					this._idxPbxActive = idxNewPosition;													// 1.0.003
				}																							// 1.0.003
				#endregion 

				pbxWork_X_Assignments();																	// 1.0.003

				//this.pnlTabImages.Controls[this._idxPbxActive].Select();									// 1.0.003
				this.pnlTabImages.ScrollControlIntoView(this.pnlTabImages.Controls[this._idxPbxActive]);	// 1.0.003

				trackBarMoveTo_SetValue(this._idxPbxActive + 1);											// 1.0.003
				this.trackBarMoveTo.Focus();																// 1.0.003
			}																								// 1.0.003
		}																									// 1.0.004
		#endregion 

		#region Public Properties
		// public int[] TabOrder_int {get}
		// 
		public int[] TabOrder_int																			// 1.0.003
		{																									// 1.0.003
			get																								// 1.0.003
			{																								// 1.0.003
				if (this._alTabPointers.Count > 0)															// 1.0.003
				{																							// 1.0.003
					return (int[])this._alTabPointers.ToArray(typeof(int));									// 1.0.003

					// The above does essentially the following:											// 1.0.003
					//int[] intTabOrder = new int[this._alTabPointers.Count];								// 1.0.003
					//for (int idx = 0; idx < this._alTabPointers.Count; idx++)								// 1.0.003
					//{																						// 1.0.003
					//	intTabOrder[idx] = (int)this._alTabPointers[idx];									// 1.0.003
					//}																						// 1.0.003
					//return intTabOrder;																	// 1.0.003
				}																							// 1.0.003
				return new int[]{};																			// 1.0.003
			}																								// 1.0.003
		}																									// 1.0.003
		#endregion 
	}																										// 1.0.003

	#region Class:  StringIs
	// internal class StringIs 
	//   public static bool Numeric(string parmString, out int outInt, out double outDouble)
	//   
	internal class StringIs
	{
		public static bool Numeric(string parmString, out int outInt, out double outDouble)
		{
			bool interimNumeric = false;
			bool foundDecimal = false;
			bool foundMinus = false;
			bool foundPlus = false;

			int tempInt = 0;
			double tempDouble = 0.0;
			double tempDoubleDivisor = 1.0;
			int digit;

			string tempString = parmString.Trim();
			if (tempString.Length > 0)
			{
				interimNumeric = true;
				for (int ix = 0; (interimNumeric) && (ix < tempString.Length); ix++)
				{
					char oneChar = tempString[ix];
					//if( (tempString[ix] == '-') || (tempString[ix] == '+') )
					if( (oneChar == '-') || (oneChar == '+') )
					{
						if( foundMinus || foundPlus || ((ix > 0) && (ix < tempString.Length -1)) )
						{
							interimNumeric = false;
							continue;
						}
						else
						{
							if (oneChar == '-')
							{
								foundMinus = true;
							}
							else if (oneChar == '+')
							{
								foundPlus = true;
							}
							continue;
						}
					}
					//if (tempString[ix] == ',')
					if (oneChar == ',')
					{
						continue;
					}
					//if (tempString[ix] == '.')
					if (oneChar == '.')
					{
						if (foundDecimal)
						{
							interimNumeric = false;
							continue;
						}
						else
						{
							foundDecimal = true;
							continue;
						}
					}
					//if( (tempString[ix] < '0') || (tempString[ix] > '9') )
					if( (oneChar < '0') || (oneChar > '9') )
					//if( !Char.IsNumber(tempString[ix]) )
					//if( !Char.IsNumber(oneChar) )
					{
						interimNumeric = false;
						continue;
					}
					//digit = Int32.Parse((string)tempString[ix]);
					digit = Int32.Parse(tempString.Substring(ix,1));
					if (foundDecimal)
					{
						tempDouble = (tempDouble * 10.0) + (double)digit;
						tempDoubleDivisor = (tempDoubleDivisor * 10.0);
					}
					else
					{
						tempInt = (tempInt * 10) + digit;
					}
				}

				tempDouble = (tempDouble/tempDoubleDivisor) + (double)tempInt;
			}

			if (foundMinus)
			{
				outInt = -1 * tempInt;
				outDouble = -1.0 * tempDouble;
			}
			else
			{
				outInt = tempInt;
				outDouble = tempDouble;
			}
			return interimNumeric;
		}

	}
	#endregion 
}																											// 1.0.003
