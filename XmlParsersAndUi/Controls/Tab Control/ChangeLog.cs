// The [TDHControls.TdhTabCtl] and [TDHControls.TDHTabCtl.TdhTabPage] controls are:
// - Based primarily on code originally written by "vijayaprasen"
//   (see "FireFox-like Tab Control" on TheCodeProject: http://www.codeproject.com/KB/tabs/firefoxtabcontrol.aspx )
// 
// Some features of [TDHControls.TdhTabCtl] and [TDHControls.TDHTabCtl.TdhTabPage]
//	1) TabPageControl - Allow or disallow any TabPage to be closed
//	1a) TabPageControl - Require or not confirmation before closing any TabPage
//	2) TabPageControl - Allow or disallow new TabPages to be opened
//	3) TabPageControl - Allow or disallow any TabPage to be "renamed" (change text on Tab)
//	4) TabPageControl - Allow or disallow TabPages to be reordered
//	5) TabPageControl - Allow or disallow right-click ContextMenus on any TabPage tabs/headers
//
//	6) TabPages - Allow or disallow individual TabPage to be closed.
//	7) TabPages - Allow or disallow right-click ContextMenus on individual TabPage.
//	8) TabPages - Require or not confirmation before closing individual TabPage
//	9) TabPages - Show on not the Close Button on individual TabPage
//	10) TabPages - Show on not the Menu Button on individual TabPage
//	11) TabPages - Default Menu does not have to be assigned to individual TabPage; 
//	11a) TabPages - ContextMenu assigned to individual TabPage is merged into default Menu (when the Menu is displayed for that TabPage)
//
//	12) Default Menu -- MenuItems may be enabled or disabled
//	12a) MenuItem - Open New TabPage
//	12b) MenuItem - "Rename" selected TabPage (change text on Tab)
//	12c) MenuItem - Reorder TabPages
//	12d) MenuItem - Close individual TabPage (selected page)
//	12e) MenuItem - Close individual TabPage (from menu list)
//	12f) MenuItem - Close all pages except selected
//	12f) MenuItem - Close all pages (except those which are not allowed to be closed)
//
//	13) Raise event telling client code just what was changed (Add, Remove, Rename, Reorder)

//#region Change Log
//
// ver 1.0.021 (2008/08/09)
// = Minor modification to [TDHControls.TdhTabCtl_Designer]
//   - Created class named-variables for the ContextMenu items (i.e. the [TdhTabCtl_Designer.Verbs] items)
//     to make the code to enable/disable the "Remove Tab" MenuItem cleaner.
//   * This has the added benefit that executing the [ Verbs_Set() ] method
//     from the [Verbs] property {get} accessor no longer causes a stack overflow.
// 
// ver 1.0.020 (2008/08/09)
// = The [TDHControls.TdhTabCtl] design-time (default) ContextMenu 
//   contains MenuItems to "Add Tab" and "Remove Tab" (yay!).
//   However, this default "Add Tab" MenuItem creates/adds a standard [System.Windows.Forms.TabPage]
//   rather than a [TDHControls.TDHTabCtl.TdhTabPage] (boo!).
//   The solution to this diffculty was to create a custom [ControlDesigner] class (yip!yip!yip!),
//   as the [System.Windows.Forms.Design.TabControlDesigner] cannot be inherited (grrrr!).
//   
//   Created/Modified:
//   - Created codefile [TdhTabCtl_Designer.cs], containing:
//     . Class: [ internal class TdhTabCtl_Designer : System.Windows.Forms.Design.ParentControlDesigner ]
//       Defined the class' ContextMenu.MenuItem items as:
//       - "Add TdhTabPage"
//       - "Add TabPage"
//       - "Remove Tab"
//   - Created codefile [TdhTabPageCollectionEditor.cs], containing:
//     . Class: [ internal class TdhTabPageCollectionEditor : System.ComponentModel.Design.CollectionEditor ]
//     . Class: [ internal class TabPageCollectionEditor : System.ComponentModel.Design.CollectionEditor ]
//   - Modified Class: [TDHControls.TdhTabCtl]
//     . Assigned [TdhTabCtl_Designer] as the design-time [ControlDesigner] class for [TdhTabCtl] 
//     . Created Property: [ public new System.Windows.Forms.TabControl.TabPageCollection TabPages ]
//     . Assigned [TabPageCollectionEditor] as the design-time [CollectionEditor] class for [TabPages]
//     . Assigned [TdhTabPageCollectionEditor] as the design-time [CollectionEditor] class for [TdhTabPages]
// 
// ver 1.0.012 (2008/08/08)
// = Modifications to:
//   - Class: [TDHControls.TdhTabCtl]
//     Added Methods:
//     . [ public bool TabPages_Remove(bool overridePermission, TDHTabCtl.TdhTabPage theTabPage) ]
//     . [ public bool TabPages_Remove(bool overridePermission, System.Windows.Forms.TabPage theTabPage) ]
//     . [ public bool TabPages_RemoveAt(bool overridePermission, int index) ]
//     . [ public bool TabPages_RemoveRange(bool overridePermission, int indexStart, int indexEnd) ]
//   - Class: [TDHControls.TDHTabCtl.TdhTabPageCollection]
//     Added Method:
//     . [ public bool RemoveRange(int indexStart, int indexEnd) ]
// 
// ver 1.0.011 (2008/08/04)
// = Allow standard [System.Windows.Forms.TabPage] controls to be created and closed.
//   Modifications to:
//   - Class: [TDHControls.TdhTabCtl]
//     Add Properties (and code changes to impliment corresponding functionality):
//     . Novel Property: [ public bool TabsBase_AllowClose  ]
//     . Novel Property: [ public bool TabsBase_ConfirmOnClose  ]
//     . Novel Property: [ public bool TabsBase_ContextMenuAllowOpen  ]
// 
// ver 1.0.010 (2008/08/03)
// = Enable the [TDHControls.TdhTabCtl] control 
//   to handle [System.Windows.Forms.TabPage] controls 
//   in its [.TdhTabPageControls]/[.TabPages] Collection
//   Modifications to:
//   - Class: [TDHControls.TdhTabCtl]
//     . As appropriate, change [ TDHTabCtl.TdhTabPage theTabPage = this.TabPages[idx] ] references
//       to [ TDHTabCtl.TdhTabPage theTabPage = (TDHTabCtl.TdhTabPage)this.TabPages[idx] ]
//       or [ System.Windows.Forms.TabPage = this.TabPages[idx] ]
//     = Later: changed references to [ this.TdhTabPages[idx] ]
//   - Class: [TDHControls.TDHTabCtl.TdhTabPageCollection]

//     . Modified Property [ public new TDHTabCtl.TdhTabPage this[int index] {get} {set} ]
//       to [ public new System.Windows.Forms.TabPage this[int index] {get} {set} ]
//     * (Later, changed it back)
//     . Added Property [ public System.Windows.Forms.TabPage this[bool alwaysAsBase, int index] {get} ]
//     . Added Property [ public System.Windows.Forms.TabPage this[string text] {get} ]
//     . Added Property [ public System.Windows.Forms.TabPage this[bool alwaysAsBase, string text] {get} ]
//     . Added Method [ public new void Add(System.Windows.Forms.TabPage theTabPage) ]
//     . Added Method [ public new void AddRange(params System.Windows.Forms.TabPage[] theTabPages) ]
//     . Added Method [ public new bool Contains(System.Windows.Forms.TabPage theTabPage) ]
//     . Added Method [ public void Insert(int index, System.Windows.Forms.TabPage theTabPage) ]
//     . Added Method [ public void InsertRange(int index, params System.Windows.Forms.TabPage[] theTabPages) ]
//     . Added Method [ public bool IsTdhTabPage(int index) ]
//     . Modified Method [ private void InsertRange(bool replace, int index, params TDHTabCtl.TdhTabPage[] theTabPages) ]
//       [ private void InsertRange(bool replace, int index, params System.Windows.Forms.TabPage[] theTabPages) ]
//   - Class: [TDHControls.TabEventArgs]
//     . Added Constructors which can accept [System.Windows.Forms.TabPage] arguments
//     . Added Property [ public bool TabPage_IsTdhTabPage {get} ]
//     . Modified [ public TDHTabCtl.TdhTabPage TabPage {get} ] 
//       to [ public System.Windows.Forms.TabPage TabPage {get} ]
//     . Added Property [public TDHTabCtl.TdhTabPage TdhTabPage {get} ]
// 
// * With the above, everything seemed to work fine running the demo program
//   (with and without standard [TabPages] added via code to the [TdhTabPageCollection])
//   -- until I tried to use the TdhTabCtl in the VisualStudio IDE.
//   - I had defined the [TdhTabPageCollection] Indexer as: 
//     [ public System.Windows.Forms.TabPage this[int index] ] 
//     And so, naturally, the IDE could add only [TabPages] and not [TdhTabPages] to the collection.
// 
//   - Class: [TDHControls.TdhTabCtl]
//     . Renamed/redefined Property/Collection [public new TDHTabCtl.TdhTabPageCollection TabPages]
//       to [public TDHTabCtl.TdhTabPageCollection TdhTabPages]
//       This seems a big part of straightening out the various problems.
//     
//   * When [TabPages] (the [TdhTabPageCollection] Collection) is defined as:
//       [public new TDHTabCtl.TdhTabPageCollection TabPages]
//     (which is how I'd originally defined it), 
//     it hides the [base.TabPages] Collection; This is how I expected it to behave.
//   * It doesn't hide the [base.TabPages] Collection when defined as:
//       [protected new TDHTabCtl.TdhTabPageCollection TabPages]
//     = But, of course, when defined this way it isn't visible to "external" classes,
//       meaning that the novel methods and properties aren't available.
//   * When the [base.TabPages] Collection isn't hidden 
//     (and is thus visible in the Properties list in the Visual Studio IDE)
//     it can be used to add standard [TabPages] to the [TdhTabPageCollection]
// 
// 
// ver 1.0.005 (2008/08/01)
// = Created codefile [TDHTabCtl::TdhTabEventArgs.cs]
//   - Moved 
//     . Class: [TDHControls.TabEventArgs]
//     . Class: [TDHControls.TDHTabCtl.TabsReorderedEventArgs]
//     from [TDHTabCtl::TdhTabCtl.cs] to [TDHTabCtl::TdhTabEventArgs.cs]
// = Modified [TDHControls.TdhTabCtl]
//   - Corrected potential error with [this._lastTabRectIdx] and [this._lastTabRect]
//     failure to re-initialize these fields when the TabPage is closed
//     (this appears to have been the cause of an odd (timing) error someone reported)
//   - In method [ internal static void TabRect_DrawButtons() ]
//     fixed a flaw in the code which decides: [Draw the "Close pseudo-Button" Rectangle as "disabled?"]
// 
// ver 1.0.004 (2008/07/26)
// = Modified [TDHControls.TDHTabCtl.TdhTabPageCollection]
//   - Added Methods:
//     . [ public void Insert(int index, TDHTabCtl.TdhTabPage theTabPage) ]
//     . [ public void InsertRange(int index, params TDHTabCtl.TdhTabPage[] theTabPages) ]
//     . [ public void InsertRange(bool replace, int index, params TDHTabCtl.TdhTabPage[] theTabPages) ]
// = Modified [TDHControls.TDHTabCtl.TdhTabReorder]
//   - Added Method:
//     . [ private void Reorder_Work(int idxOldPosition, int idxNewPosition) ]
//       from code originally in [ private void btnReorder_X_Click(object sender, System.EventArgs e) ]
//   - other minor modifications
// 
// ver 1.0.003 (2008/07/05)
// = Modified [TDHControls.TDHTabCtl.TdhTabPageCollection]
//   - Added Set accessor to the .Item (.TabPage) indexer property
//   - Added Properties:
//     . Count {get}
//     . IsReadOnly {get}
//   = 2008/07/22: This is odd: at the time, the above properties didn't seem to exist until I added them.
//   = Yet, other properties exist (and are visible via IntelliSense), so I've commented these out.
// = Modified [TDHControls.TdhTabCtl]
//   . Added logic to allow TabPage reordering
// = Created Class [TDHControls.TDHTabCtl.TdhTabReorder] to assist in TabPage reordering
// 
// ver 1.0.002 (2008/06/29)
// * The [TDHControls.TDHTabCtl.TdhTabPageControls] class doesn't work properly with the IDE 
//   (it seems to work OK when executed) 
//   When the TabPages collection is modified:
//   -- the IDE removes the .Controls.Add(...) statements
//   -- the IDE removes the Novel Property assignments
//   At the same time, the standard [System.Windows.Forms.Control.ControlCollection] seems to work OK
// = So: 
//   . Changed [TdhPageControls.cs] [Build Action] to "None"
//     (I don't want to throw it away just yet)
//   . Commented out use of [TDHControls.TDHTabCtl.TdhTabPageControls] in [TDHControls.TdhTabCtl]
// 
// ver 1.0.001 (2008/06/28)
// - Created Classes:  
//   . [TDHControls.TDHTabCtl.TdhTabPageCollection]		-- replace [System.Windows.Forms.TabControl.TabPageCollection]
//   . [TDHControls.TDHTabCtl.TdhTabPageControls]		-- replace [System.Windows.Forms.Control.ControlCollection]
//   . [TDHControls.TDHTabCtl.TDHEditBox.TdhEditBox]	-- Allow TdhTabPage-Rename
// - Modified Classes:  [TDHControls.TdhTabCtl] 
//   and [TDHControls.TDHTabCtl.TdhTabPage] 
//   to make use of the new classes
// - Created Properties and Methods to support
//   . User creation of new TabPages (or course, they will be empty)
//   . Renaming TabPage ... reset [.Text] and [.Name] properties
//     => Hmmm, for now, don't reset the [.Name] property
//   . customizing the "pseudo-buttons" and/or ContextMenu for each TabPage
// - Replaced Class [TDHControls.TdhTabCtl.CloseEventArgs] 
//   by [TDHControls.TabEventArgs]
// - Replaced Delagate [TDHControls.TDHTabCtl.TabCloseDelegate]
//   by [TDHControls.TDHTabCtl.TabEventsDelegate]
// - Cleaned up the logic of the original class
//   (For instance, method [OnDrawItem()] cycled through and redrew all TabPages)
// 
// ver 1.0.000 (2008/06/24)
// - Created the [TDHControls.TdhTabCtl] control 
//   Classes:  [TDHControls.TdhTabCtl]	-- formerly [MyControlLibrary.TabCtlEx]
//             [TDHControls.TDHTabCtl.TdhTabPage]	-- formerly [MyControlLibrary.TabPageEx]
//   = Based primarily on code originally written by "vijayaprasen"
//     (see "FireFox-like Tab Control" on TheCodeProject: http://www.codeproject.com/KB/tabs/firefoxtabcontrol.aspx )
// 
//#endregion 