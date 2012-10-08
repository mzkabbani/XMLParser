using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Xml;
using XmlParsersAndUi.Forms;
using Automation.Common.Utils;
using System.Collections;
using Automation.Common;
using Automation.Common.Classes.Monitoring;

namespace XmlParsersAndUi {
	public partial class BulkMacroSplitterTreeForm : Form {

		#region Constructor

		public BulkMacroSplitterTreeForm() {
			InitializeComponent();
		}

		#endregion

		#region Variables

		string oldEventsFile = string.Empty;
		bool check = true;
		string fsEventsFile = string.Empty;
		string buildFileText = string.Empty;
		string buildFileTextGrouped = string.Empty;
		string buildMacroStep = "<automation.macroplayback eventsfile=\"${datastore}.macros.${OutputFolderName}.eventsfiles.xml\"" +
			" kernelsteptitle=\"{TestTitle}\" createstep=\"false\" />";


		#endregion

		#region Methods

		private void StartSplittingFile() {
			if (!Directory.Exists(txtOutputDir.Text)) {
				Directory.CreateDirectory(txtOutputDir.Text);
			}

			string sessionKey = string.Empty;
			sessionKey = txtSessionKey.Text.Trim();
			string fileRead = string.Empty;
			StreamReader reader = new StreamReader(txtDirectory.Text);
			string eventsFile = "<Steps label=\"Automatically Generated\">";
			try {
				fileRead = reader.ReadToEnd();
				MatchCollection collection = Regex.Matches(fileRead, "<Comment.*>(.*)</Comment>");
				List<string> matches = new List<string>();
				for (int i = 0; i < collection.Count; i++) {
					matches.Add(collection[i].Groups[1].ToString());
					//     txtOutput.Text = txtOutput.Text + "\r\n" + collection[i].Groups[1].ToString();
				}


				string newFileRead = Regex.Replace(fileRead, "<Comment.*</Comment>", "</Events></MXClientScript><!-- --><MXClientScript><Events>");
				string[] test = new string[] { "<!-- -->" };
				string[] splitArray = newFileRead.Split(test, StringSplitOptions.RemoveEmptyEntries);

				for (int j = 0; j < splitArray.Length; j++) {
					if (j < collection.Count) {
						StreamWriter writer = new StreamWriter(txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml");
						StreamWriter guiWriter = new StreamWriter(txtOutputDir.Text + @"\step" + (j + 1) + "_gui.xml");
						StreamWriter customsWriter = new StreamWriter(txtOutputDir.Text + @"\step" + (j + 1) + "_customs.xml");
						try {
							guiWriter.Write(" ");
							customsWriter.Write(@"<Customs></Customs>");
							writer.Write(splitArray[j]);
							if (string.IsNullOrEmpty(sessionKey)) {

								eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" label=\"" + collection[j].Groups[1].ToString() + "\" events=\"step" + (j + 1) + "_events.xml\" gui=\"step" + (j + 1) + "_gui.xml\" customs=\"step" + (j + 1) + "_customs.xml\"></Step>";

							} else {
								eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"" + collection[j].Groups[1].ToString() + "\" events=\"step" + (j + 1) + "_events.xml\" gui=\"step" + (j + 1) + "_gui.xml\" customs=\"step" + (j + 1) + "_customs.xml\"></Step>";

							}

							BulkMacroTreeNode node = new BulkMacroTreeNode();
							node.filepath = txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml";
							node.stepName = "step" + (j + 1) + "_events.xml";
							node.stepTitle = collection[j].Groups[1].ToString();
							node.stepEvents = splitArray[j];
							node.Text = node.stepName + " | " + node.stepTitle;

							tvResults.Nodes.Add(node);


							//checkboxItems item = new checkboxItems();
							//item.filepath = txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml";
							//item.stepName = "step" + (j + 1) + "_events.xml";
							//item.stepTitle = collection[j].Groups[1].ToString();
							//item.stepEvents = splitArray[j];
							//chkLstAllStepEvents.Items.Add(item);
						} finally {
							if (writer != null) {
								writer.Close();
							}
							if (guiWriter != null) {
								guiWriter.Close();
							}
							if (customsWriter != null) {
								customsWriter.Close();
							}
						}
					} else {
						StreamWriter writer = new StreamWriter(txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml");
						try {

							writer.Write(splitArray[j]);

							if (string.IsNullOrEmpty(sessionKey)) {

								eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" label=\"Exit\" events=\"step" + (j + 1) + "_events.xml\"></Step>";

							} else {
								eventsFile = eventsFile + "\r\n <Step id=\"" + (j + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"Exit\" events=\"step" + (j + 1) + "_events.xml\"></Step>";


							}

							//remove customs and gui for exit step
							File.Delete(txtOutputDir.Text + @"\step" + (j + 1) + "_gui.xml");
							File.Delete(txtOutputDir.Text + @"\step" + (j + 1) + "_gui.xml");

							BulkMacroTreeNode node = new BulkMacroTreeNode();
							node.filepath = txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml";
							node.stepName = "step" + (j + 1) + "_events.xml";
							node.stepTitle = "Exit";
							node.stepEvents = splitArray[j];
							node.Text = node.stepName + " | " + "Exit";

							tvResults.Nodes.Add(node);

							//checkboxItems item = new checkboxItems();
							//item.filepath = txtOutputDir.Text + @"\step" + (j + 1) + "_events.xml";
							//item.stepName = "step" + (j + 1) + "_events.xml";
							//item.stepTitle = "Exit";
							//item.stepEvents = splitArray[j];
							//chkLstAllStepEvents.Items.Add(item);
						} finally {
							if (writer != null) {
								writer.Close();
							}
						}

					}

				}
			} finally {
				if (reader != null) {
					reader.Close();
				}
			}


			eventsFile = WriteEventsFile(eventsFile);
			buildFileText = buildMacroStep.Replace("${OutputFolderName}", Path.GetFileName(txtOutputDir.Text));


		}

		private string WriteEventsFile(string eventsFile) {
			StreamWriter eventsfilesWriter = new StreamWriter(txtOutputDir.Text + @"\eventsfiles.xml");
			try {
				eventsFile = eventsFile + "</Steps>";
				eventsfilesWriter.Write(eventsFile);
				oldEventsFile = eventsFile;
			} finally {
				if (eventsfilesWriter != null) {
					eventsfilesWriter.Close();
				}
			}
			return eventsFile;
		}

		private string PrepareFsEventsFile(List<checkboxItems> selectedItems, string oldEventsFile) {
			string preparedEventsFile = string.Empty;
			XmlDocument xDoc = new XmlDocument();
			xDoc.LoadXml(oldEventsFile);

			for (int i = 0; i < selectedItems.Count; i++) {
				XmlNode requestedNode = GetRespectiveChildNode(selectedItems[i], xDoc);
			}

			return preparedEventsFile;
		}

		private XmlNode GetRespectiveChildNode(checkboxItems selectedItem, XmlDocument xDoc) {
			XmlNode node = null;

			for (int i = 0; i < xDoc.DocumentElement.ChildNodes.Count; i++) {
				//    if (xDoc.DocumentElement.ChildNodes[i]) {

				//    }
			}

			return node;
		}

		private static void SetDefaultFormValues(SessionKeyAndTitleForm form) {
			Random random = new Random(DateTime.Now.Millisecond);
			form.Controls["txtSessionKey"].Text = random.Next(8999).ToString();
		}

		private void CleanOutputDir(BulkMacroTreeNode bulkMacroTreeNode) {


			File.Delete(bulkMacroTreeNode.filepath);
			string parentDirectory = Directory.GetParent(bulkMacroTreeNode.filepath).ToString();
			if (File.Exists(parentDirectory + @"\" + Path.GetFileName(bulkMacroTreeNode.filepath).Replace("events", "customs"))) {
				File.Delete(parentDirectory + @"\" + Path.GetFileName(bulkMacroTreeNode.filepath).Replace("events", "customs"));
			}
			if (File.Exists(parentDirectory + @"\" + Path.GetFileName(bulkMacroTreeNode.filepath).Replace("events", "gui"))) {
				File.Delete(parentDirectory + @"\" + Path.GetFileName(bulkMacroTreeNode.filepath).Replace("events", "gui"));
			}
		}

		private void CreateBuildXmlFile(string parentTitle, string outputFolderName) {
			//writer.Write("<project default=\"allSequence\"><target name=\"allSequence\"><automation.macroplayback eventsfile=\"${datastore}." + pathOfEventsFile + " kernelsteptitle=\"" + parentTitle + "\" createstep=\"false\" />  </target></project>");

			buildFileTextGrouped = buildFileTextGrouped + "\r\n\r\n" + buildMacroStep.Replace("${OutputFolderName}", outputFolderName).Replace("{TestTitle}", parentTitle);

		}

		private void GenerateSplitFile(List<BulkMacroTreeNode> movedNodes, string sessionKey, string folderName, int startIndex) {
			string eventsFileDirectory = Directory.GetParent(movedNodes[0].filepath).ToString();
			Directory.CreateDirectory(eventsFileDirectory);

			string eventsFileText = "<Steps label=\"Automatically Generated\">";


			for (int i = startIndex - 1, j = 0; i < (movedNodes.Count + startIndex - 1); i++, j++) {
				if (!string.Equals(movedNodes[j].stepTitle, "Exit")) {
					WriteCustomsFile(eventsFileDirectory, i + 1);
					WriteGuiFile(eventsFileDirectory, i + 1);
				}
				WriteStepEventFile(eventsFileDirectory, i + 1, movedNodes[j]);
				if (string.Equals(movedNodes[j].stepTitle, "Exit")) {
					if (string.IsNullOrEmpty(sessionKey)) {
						eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" label=\"Exit\" events=\"step" + (i + 1) + "_events.xml\" ></Step>";
					} else {
						eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"Exit\" events=\"step" + (i + 1) + "_events.xml\" ></Step>";
					}
				} else {
					if (!string.IsNullOrEmpty(sessionKey)) {
						eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" sessionKey=\"" + sessionKey + "\" label=\"" + movedNodes[j].stepTitle + "\" events=\"step" + (i + 1) + "_events.xml\" gui=\"step" + (i + 1) + "_gui.xml\" customs=\"step" + (i + 1) + "_customs.xml\"></Step>";
					} else {
						eventsFileText = eventsFileText + "\r\n <Step id=\"" + (i + 1) + "\" label=\"" + movedNodes[j].stepTitle + "\" events=\"step" + (i + 1) + "_events.xml\" gui=\"step" + (i + 1) + "_gui.xml\" customs=\"step" + (i + 1) + "_customs.xml\"></Step>";

					}
				}
			}
			WriteEventsFile(sessionKey, eventsFileDirectory, eventsFileText);

		}

		private void WriteStepEventFile(string eventsFileDirectory, int stepNumber, BulkMacroTreeNode bulkMacroTreeNode) {
			StreamWriter writer = new StreamWriter(eventsFileDirectory + @"\step" + stepNumber + "_events.xml");
			try {
				writer.Write(bulkMacroTreeNode.stepEvents);
			} finally {
				if (writer != null) {
					writer.Flush();
					writer.Close();
					writer.Dispose();
				}
			}
		}

		private void WriteGuiFile(string eventsFileDirectory, int guiNumber) {
			StreamWriter guiWriter = new StreamWriter(eventsFileDirectory + @"\step" + guiNumber + "_gui.xml");
			try {
				guiWriter.Write("<GuiRoot MXRequest=\"GetFullTree\"></GuiRoot>");
			} finally {
				if (guiWriter != null) {
					guiWriter.Flush();
					guiWriter.Close();
					guiWriter.Dispose();
				}
			}
		}

		private void WriteCustomsFile(string eventsFileDirectory, int customsNumber) {
			StreamWriter customsWriter = new StreamWriter(eventsFileDirectory + @"\step" + customsNumber + "_customs.xml");
			try {
				customsWriter.Write(@"<Customs></Customs>");
			} finally {
				if (customsWriter != null) {
					customsWriter.Flush();
					customsWriter.Close();
					customsWriter.Dispose();
				}
			}

		}

		private void WriteEventsFile(string sessionKey, string eventsFileDirectory, string eventsFileText) {
			StreamWriter eventsfilesWriter = new StreamWriter(eventsFileDirectory + @"\eventsfiles.xml");
			try {
				eventsFileText = eventsFileText + "</Steps>";
				eventsfilesWriter.Write(eventsFileText);
			} finally {
				if (eventsfilesWriter != null) {
					eventsfilesWriter.Flush();
					eventsfilesWriter.Close();
					eventsfilesWriter.Dispose();
				}
			}

		}

		#endregion

		#region Events

		private void btnShowOutput_Click(object sender, EventArgs e) {
			if (Directory.Exists(txtOutputDir.Text)) {
				Process.Start(txtOutputDir.Text);
			} else {

				FrontendUtils.ShowError("The output directory does not exist yet", null);
			}
		}

		private void btnGroup_Click(object sender, EventArgs e) {
			//try {
			//    chkFsEvents.Enabled = false;
			//    if (chkLstAllStepEvents.Items.Count == 0) {
			//        FrontendUtils.ShowError("There is no steps to group!", null);
			//        return;
			//    }
			//    List<checkboxItems> selectedItems = new List<checkboxItems>();
			//    System.Windows.Forms.CheckedListBox.CheckedItemCollection checkedCollection = chkLstAllStepEvents.CheckedItems;
			//    for (int i = 0; i < checkedCollection.Count; i++) {
			//        selectedItems.Add(checkedCollection[i] as checkboxItems);
			//    }
			//    SessionKeyAndTitleForm form = new SessionKeyAndTitleForm(txtOutputDir.Text);
			//    DialogResult result = form.ShowDialog();
			//    SetDefaultFormValues(form);
			//    if (result == DialogResult.OK) {
			//        File.Delete(Directory.GetParent(selectedItems[0].filepath) + @"\eventsfiles.xml");
			//        for (int i = 0; i < selectedItems.Count; i++) {
			//            CleanOutputDir(selectedItems[i]);
			//            chkLstAllStepEvents.Items.Remove(selectedItems[i]);
			//        }
			//        int startIndex = Convert.ToInt32(((NumericUpDown)form.Controls["nudStartIndex"]).Value);
			//        string outputFolderName = form.Controls["txtTitle"].Text + "-" + form.eventsGroupNameAndID.OperationGeneratedID;
			//        GenerateSplitFile(selectedItems, form.sessionKey, outputFolderName, startIndex);


			//        CreateBuildXmlFile(form.Controls["txtTitle"].Text, outputFolderName);

			//    }
			//} catch (Exception ex) {
			//    FrontendUtils.ShowError(ex.Message, ex);
			//}
		}

		private void btnSelectAll_Click(object sender, EventArgs e) {
			//try {
			//    for (int i = 0; i < chkLstAllStepEvents.Items.Count; i++) {
			//        chkLstAllStepEvents.SetItemChecked(i, check);
			//    }
			//    check = !check;
			//} catch (Exception ex) {
			//    FrontendUtils.ShowError(ex.Message, ex);
			//}
		}

		private void btnReset_Click(object sender, EventArgs e) {
			btnSplitFile.Enabled = true;
			tvResults.Nodes.Clear();
			buildFileText = string.Empty;
			buildFileTextGrouped = string.Empty;
			//     chkLstAllStepEvents.Items.Clear();
		}

		private void btnBrowse_Click(object sender, EventArgs e) {
			try {
				OpenFileDialog dialog = new OpenFileDialog();
				if (dialog.ShowDialog() == DialogResult.OK) {
					txtDirectory.Text = dialog.FileName;
				}
			} catch (Exception ex) {
				FrontendUtils.ShowError(ex.Message, ex);
			}
		}

		private void btnOutputDir_Click(object sender, EventArgs e) {
			try {
				FolderBrowserDialog dialog = new FolderBrowserDialog();
				if (dialog.ShowDialog() == DialogResult.OK) {
					txtOutputDir.Text = dialog.SelectedPath;
				}
			} catch (Exception ex) {
				FrontendUtils.ShowError(ex.Message, ex);
			}
		}

		private void txtDirectory_TextChanged(object sender, EventArgs e) {
			try {
				if (!string.IsNullOrEmpty(txtDirectory.Text)) {
					string outputDir = Directory.GetParent(txtDirectory.Text) + @"\output";
					if (!Directory.Exists(outputDir)) {
						Directory.Exists(outputDir);
					}
					txtOutputDir.Text = outputDir;
				}
			} catch (Exception ex) {
				FrontendUtils.ShowError(ex.Message, ex);
			}
		}

		private void BulkMacroSplitterForm_Load(object sender, EventArgs e) {
			if (!string.IsNullOrEmpty(MonitorObject.username)) {
				MonitorObject.formAndAccessTime.Add(new FormAndAccessTime(this.Name, DateTime.Now));

			}
		}



		private void btnSplitFile_Click(object sender, EventArgs e) {
			try {
				tvResults.Nodes.Clear();
				StartSplittingFile();
				//FrontendUtils.ShowInformation("Splitting done!");
				btnSplitFile.Enabled = false;
			} catch (Exception ex) {
				FrontendUtils.ShowError(ex.Message, ex);
			}
		}

		#endregion

		private void renameStepToolStripMenuItem_Click(object sender, EventArgs e) {
			//try {
			//    checkboxItems item = (chkLstAllStepEvents.SelectedItem as checkboxItems);
			//    if (item != null) {
			//        RenameStepForm form = new RenameStepForm(item.stepTitle);
			//        DialogResult dialog = form.ShowDialog();
			//        if (dialog == DialogResult.OK) {
			//            item.stepTitle = form.Controls["txtNewStepTitle"].Text;
			//            chkLstAllStepEvents.SelectedItem = item;
			//            chkLstAllStepEvents.Refresh();
			//        }
			//    }
			//} catch (Exception ex) {
			//    FrontendUtils.ShowError(ex.Message, ex);
			//}
		}


		/// <summary> /// Gets controls for context menu ///
		/// </summary> /// <param name="Sender">Sender object from menu event handler</param> ///
		/// <returns></returns>
		private object GetSourceControl(Object Sender) {
			// ContextMenuStrip sended?
			if (Sender as ContextMenuStrip != null) {
				ContextMenuStrip cms = Sender as ContextMenuStrip;
				return cms.SourceControl;
			}
			var item = Sender as ToolStripItem;
			// move to root item
			while (item.OwnerItem != null) {
				item = item.OwnerItem;
			}
			// we have root item now, so lets take ContextMenuStrip object
			var menuObject = item.Owner as ContextMenuStrip;
			if (menuObject != null) {
				return menuObject.SourceControl;
			}
			return null;
		}

		private void groupToolStripMenuItem_Click(object sender, EventArgs e) {
			Control control = GetSourceControl((sender as ToolStripMenuItem).GetCurrentParent()) as Control;
			MWTreeView treeView = control as MWTreeView;

			if (treeView != null) {

				if (treeView.SelNodes.Count > 0) {

					SessionKeyAndTitleForm form = new SessionKeyAndTitleForm(txtOutputDir.Text);
					DialogResult result = form.ShowDialog();
					SetDefaultFormValues(form);
					if (result == DialogResult.OK) {
						int startIndex = Convert.ToInt32(((NumericUpDown)form.Controls["nudStartIndex"]).Value);
						string outputFolderName = form.Controls["txtFolderName"].Text + "-" + form.eventsGroupNameAndID.OperationGeneratedID;
						string testTitle = form.Controls["txtTestTitle"].Text;

						object[] selectedKeys = new object[treeView.SelNodes.Count];
						treeView.SelNodes.Keys.CopyTo(selectedKeys, 0);


						List<BulkMacroTreeNode> selectedNodes = new List<BulkMacroTreeNode>();

						bool emptyParentInSelection = false;

						for (int i = 0; i < selectedKeys.Length; i++) {
							BulkMacroTreeNode node = (treeView.SelNodes[selectedKeys[i]] as Automation.Common.MWTreeNodeWrapper).Node as BulkMacroTreeNode;
							if (!node.Text.Contains("|")) {
								emptyParentInSelection = true;
							}
							selectedNodes.Add(node);
						}

						if (!emptyParentInSelection) {
							tvResults.ClearSelNodes();
							selectedNodes.Sort(BulkMacroTreeNode.stepIndexComparison);


							List<BulkMacroTreeNode> movedNodes = new List<BulkMacroTreeNode>();
							for (int i = 0; i < selectedNodes.Count; i++) {

								BulkMacroTreeNode bulkMacroTreeNode = selectedNodes[i].Clone() as BulkMacroTreeNode;
								bulkMacroTreeNode.endStepId = selectedNodes[i].endStepId;
								bulkMacroTreeNode.filepath = selectedNodes[i].filepath;
								bulkMacroTreeNode.startStepId = selectedNodes[i].startStepId;
								bulkMacroTreeNode.stepEvents = selectedNodes[i].stepEvents;

								CleanOutputDir(bulkMacroTreeNode);

								//outputFolderName
								bulkMacroTreeNode.stepName = Regex.Replace(selectedNodes[i].stepName, "\\d+", ((i) + startIndex).ToString());
								bulkMacroTreeNode.stepTitle = selectedNodes[i].stepTitle;
								bulkMacroTreeNode.Text = bulkMacroTreeNode.stepName + " | " + bulkMacroTreeNode.stepTitle;
								bulkMacroTreeNode.filepath = Directory.GetParent(bulkMacroTreeNode.filepath) + @"\" + outputFolderName + @"\" + bulkMacroTreeNode.stepName;
								tvResults.DeselectNode(bulkMacroTreeNode, true);
								selectedNodes[0].Nodes.Add(bulkMacroTreeNode);
								//outputFolderName
								selectedNodes[0].isParentNode = true;
								selectedNodes[0].Tag = outputFolderName;
								movedNodes.Add(bulkMacroTreeNode);
								if (i > 0) {
									selectedNodes[i].Remove();
								}
							}
							File.Delete(Directory.GetParent(txtOutputDir.Text) + @"\eventsfiles.xml");
							selectedNodes[0].Text = testTitle;
							selectedNodes[0] = new BulkMacroTreeNode();
							GenerateSplitFile(movedNodes, form.sessionKey, outputFolderName, startIndex);
							CreateBuildXmlFile(testTitle, outputFolderName);
						}
					}
				}
				tvResults.ExpandAll();
			}

			//if(File.Exists(txtOutputDir.Text+@"\eventsfiles.xml")){
			//    File.Delete(txtOutputDir.Text + @"\eventsfiles.xml");
			//}

		}

		private void txtShowBuildFile_Click(object sender, EventArgs e) {
			// show buildFileTextGrouped;
			try {
				BulkMacroBuildXmlForm form = new BulkMacroBuildXmlForm(buildFileTextGrouped);
				form.ShowDialog();

			} catch (Exception ex) {
				FrontendUtils.ShowError(ex.Message, ex);
			}
		}

		private void renameSToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				Control control = GetSourceControl((sender as ToolStripMenuItem).GetCurrentParent()) as Control;
				MWTreeView resutltsTree = control as MWTreeView;
				if (resutltsTree != null) {
					BulkMacroTreeNode bulkMacroTreeNode = resutltsTree.SelNode as BulkMacroTreeNode;
					if (bulkMacroTreeNode != null) {
						if (!bulkMacroTreeNode.isParentNode) {
							RenameStepForm form = new RenameStepForm(bulkMacroTreeNode.stepTitle);
							DialogResult dialog = form.ShowDialog();
							if (dialog == DialogResult.OK) {

								bulkMacroTreeNode.stepTitle = form.Controls["txtNewStepTitle"].Text;
								bulkMacroTreeNode.Text = bulkMacroTreeNode.Text.Split(new char[] { '|' })[0]
									+ "| " + form.Controls["txtNewStepTitle"].Text;
								UpdateEventsFileWithNewName(bulkMacroTreeNode);
							}
						}
					}
				}
			} catch (Exception ex) {
				FrontendUtils.ShowError(ex.Message, ex);
			}
		}

		
		
		
		private void UpdateEventsFileWithNewName(BulkMacroTreeNode bulkMacroTreeNode) {
			string eventsFilePath = Directory.GetParent(bulkMacroTreeNode.filepath) + @"\eventsfiles.xml";
			string renameStepRegex = "(<Step.*?label=\")(.*?)(\" events=\"" + bulkMacroTreeNode.stepName + "\".*?></Step>)";
			string eventsFile = FrontendUtils.ReadFile(eventsFilePath);
			eventsFile = Regex.Replace(eventsFile, renameStepRegex, "$1" + bulkMacroTreeNode.stepTitle + "$3");
			FrontendUtils.WriteFile(eventsFilePath, eventsFile);
		}

		private void cmsResultsTreeView_Opening(object sender, CancelEventArgs e) {
			try {
				Control control = GetSourceControl(sender) as Control;
				MWTreeView resutltsTree = control as MWTreeView;
				if (resutltsTree != null) {
					//int leve=  resutltsTree.SelNode.Level;

					if (resutltsTree.SelNodes.Count > 1) {
						renameSToolStripMenuItem.Enabled = false;
						compareExceptionToolStripMenuItem.Enabled = false;
						compareDialogToolStripMenuItem.Enabled = false;
						object[] selectedKeys = new object[resutltsTree.SelNodes.Count];
						resutltsTree.SelNodes.Keys.CopyTo(selectedKeys, 0);


						List<BulkMacroTreeNode> selectedNodes = new List<BulkMacroTreeNode>();

						bool foundParentOrLevelTwo = false;
						for (int i = 0; i < selectedKeys.Length && !foundParentOrLevelTwo; i++) {
							BulkMacroTreeNode node = (resutltsTree.SelNodes[selectedKeys[i]] as Automation.Common.MWTreeNodeWrapper).Node as BulkMacroTreeNode;
							if (node.isParentNode || node.Level > 0) {
								foundParentOrLevelTwo = true;
							}
						}
						if (foundParentOrLevelTwo) {
							groupToolStripMenuItem.Enabled = false;
						} else {
							groupToolStripMenuItem.Enabled = true;
						}
					} else if (resutltsTree.SelNode != null) {
						if (resutltsTree.SelNode.Level > 0 || (resutltsTree.SelNode as BulkMacroTreeNode).isParentNode) {
							compareExceptionToolStripMenuItem.Enabled = true;
							renameSToolStripMenuItem.Enabled = true;
							compareDialogToolStripMenuItem.Enabled = true;
							if ((resutltsTree.SelNode as BulkMacroTreeNode).isParentNode) {
								groupToolStripMenuItem.Enabled = false;
								renameSToolStripMenuItem.Enabled = false;
								compareDialogToolStripMenuItem.Enabled = false;
								compareExceptionToolStripMenuItem.Enabled = false;
							}
						} else {
							renameSToolStripMenuItem.Enabled = true;
							compareExceptionToolStripMenuItem.Enabled = true;
							compareDialogToolStripMenuItem.Enabled = true;
							groupToolStripMenuItem.Enabled = true;
						}
					} else {
						groupToolStripMenuItem.Enabled = false;
						compareExceptionToolStripMenuItem.Enabled = false;
						compareDialogToolStripMenuItem.Enabled = false;
						renameSToolStripMenuItem.Enabled = false;
					}
				}
			} catch (Exception ex) {
				FrontendUtils.ShowError(ex.Message, ex);
			}
		}

		private void BulkMacroSplitterTreeForm_FormClosing(object sender, FormClosingEventArgs e) {
			try {
				if (FrontendUtils.ShowConformation("Do you want to proceed to level one cleanup?") == DialogResult.Yes) {
					CleanupForm form = new CleanupForm(txtOutputDir.Text);
					form.MdiParent = this.MdiParent;
					form.Show();
				}
			} catch (Exception ex) {
				FrontendUtils.ShowError(ex.Message, ex);
			}
		}

		private void compareExceptionToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				Control control = GetSourceControl((sender as ToolStripMenuItem).GetCurrentParent()) as Control;
				MWTreeView resutltsTree = control as MWTreeView;
				if (resutltsTree != null) {
					BulkMacroTreeNode bulkMacroTreeNode = resutltsTree.SelNode as BulkMacroTreeNode;
					if (bulkMacroTreeNode != null) {
						if (!bulkMacroTreeNode.isParentNode) {
							UpdateEventsFileWithCompareException(bulkMacroTreeNode);
							if (!bulkMacroTreeNode.Text.Contains("[CE]")) {
								bulkMacroTreeNode.Text = bulkMacroTreeNode.Text + " [CE]";
							}
							
						}
					}
				}
			} catch (Exception ex) {
				FrontendUtils.ShowError(ex.Message, ex);
			}
		}

		private void UpdateEventsFileWithCompareException(BulkMacroTreeNode bulkMacroTreeNode) {
			string eventsFilePath = Directory.GetParent(bulkMacroTreeNode.filepath) + @"\eventsfiles.xml";
			string renameStepRegex = "(<Step.*?(id=\"\\d+\"))(.*?label=\".*?\" events=\"" + bulkMacroTreeNode.stepName + "\".*?></Step>)";
			string eventsFile = FrontendUtils.ReadFile(eventsFilePath);
			eventsFile = Regex.Replace(eventsFile, renameStepRegex, "$1" +
			                           " compareExceptions=\"true\" exception=\"" +
			                           bulkMacroTreeNode.stepName.Replace("events", "exception") +
			                           "\" exceptionCustoms=\"" +
			                           bulkMacroTreeNode.stepName.Replace("events.xml", "exception") +
			                           "_customs.xml\" " +
			                           "$3");

			//write step1_exception.xml
			FrontendUtils.WriteFile(Directory.GetParent(bulkMacroTreeNode.filepath) +
			                        @"\" + bulkMacroTreeNode.stepName.Replace("events", "exception"), "");
			//write step1_exception_customs.xml
			FrontendUtils.WriteFile(Directory.GetParent(bulkMacroTreeNode.filepath) +
			                        @"\" + bulkMacroTreeNode.stepName.Replace("events.xml", "exception") + "_customs.xml", "");




			FrontendUtils.WriteFile(eventsFilePath, eventsFile);
		}

		private void compareDialogToolStripMenuItem_Click(object sender, EventArgs e) {
			try {
				Control control = GetSourceControl((sender as ToolStripMenuItem).GetCurrentParent()) as Control;
				MWTreeView resutltsTree = control as MWTreeView;
				if (resutltsTree != null) {
					BulkMacroTreeNode bulkMacroTreeNode = resutltsTree.SelNode as BulkMacroTreeNode;
					if (bulkMacroTreeNode != null) {
						if (!bulkMacroTreeNode.isParentNode) {
							UpdateEventsFileWithCompareDialogs(bulkMacroTreeNode);
							if (!bulkMacroTreeNode.Text.Contains("[CD]")) {
								bulkMacroTreeNode.Text = bulkMacroTreeNode.Text + " [CD]";
							}
						}
					}
				}
			} catch (Exception ex) {
				FrontendUtils.ShowError(ex.Message, ex);
			}
		}

		private void UpdateEventsFileWithCompareDialogs(BulkMacroTreeNode bulkMacroTreeNode) {
			string eventsFilePath = Directory.GetParent(bulkMacroTreeNode.filepath) + @"\eventsfiles.xml";
			string renameStepRegex = "(<Step.*?(id=\"\\d+\"))(.*?label=\".*?\" events=\"" + bulkMacroTreeNode.stepName + "\".*?></Step>)";
			string eventsFile = FrontendUtils.ReadFile(eventsFilePath);
			eventsFile = Regex.Replace(eventsFile, renameStepRegex, "$1" +
			                           " compareDialogs=\"true\" dialog=\"" +
			                           bulkMacroTreeNode.stepName.Replace("events", "dialog") +
			                           "\" " +
			                           "$3");

			//write step1_dialog.xml
			FrontendUtils.WriteFile(Directory.GetParent(bulkMacroTreeNode.filepath) +
			                        @"\" + bulkMacroTreeNode.stepName.Replace("events", "dialog"), "");
			FrontendUtils.WriteFile(eventsFilePath, eventsFile);
		}
	}
}
