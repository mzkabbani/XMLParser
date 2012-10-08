using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using XmlParsersAndUi.Properties;
using DifferenceEngine;
using System.Collections;
using System.Diagnostics;
using Automation.Common.Utils;
using Automation.Common;
using Automation.Backend;
using Automation.Common.Classes.Monitoring;

namespace XmlParsersAndUi {
    public partial class CleanupForm : Form {

        #region Variables

        string outputDir;
        string inputDir;
        string CLEANUPFORM_EVENTS_SEARCH_PATTERN = "*events.xml";
        string backupDirectory;
        private DiffEngineLevel _level;

        #endregion

        #region Constructor

        public CleanupForm() {
            InitializeComponent();
        }

        public CleanupForm(string inputDirectory) {
            InitializeComponent();
            inputDir = inputDirectory;
        }

        #endregion

        #region Methods

        private void fillTree(List<string> filesToReplace) { // you allready had most of this
            // string[] drives = Environment.GetLogicalDrives();
            // foreach (string dr in drives) {
            TreeNode node = RecursiveDirWalk(txtInputDir.Text, filesToReplace);
            node.ImageIndex = node.SelectedImageIndex = 0; // drive icon
            node.Tag = txtInputDir.Text;
            tvFilesAffected.Nodes.Add(node);
            //}
        }

        private TreeNode RecursiveDirWalk(string path, List<string> filesToReplace) {
            TreeNode node = new TreeNode(path.Substring(path.LastIndexOf('\\')));
            node.ImageIndex = node.SelectedImageIndex = 0; // dir icon
            node.Tag = path;
            string[] dirs = System.IO.Directory.GetDirectories(path);
            for (int t = 0; t < dirs.Length; t++) {
                node.Nodes.Add(RecursiveDirWalk(dirs[t], filesToReplace));
            }
            // Optional if you want files as well:
            string[] files = System.IO.Directory.GetFiles(path, CLEANUPFORM_EVENTS_SEARCH_PATTERN);
            for (int t = 0; t < files.Length; t++) {
                TreeNode tn = new TreeNode(System.IO.Path.GetFileName(files[t]));
                tn.Tag = files[t];
                tn.ImageIndex = tn.SelectedImageIndex = 1; // file icon
                if (filesToReplace.Contains(tn.Tag.ToString())) {
                    tn.ImageIndex = tn.SelectedImageIndex = 2;
                }
                node.Nodes.Add(tn);
            } // end of optional file part
            return node;
        }

        protected void ColorNodes(TreeNode root, Color firstColor, Color secondColor, List<string> fileNamesToReplace) {
            Color nextColor;
            if (fileNamesToReplace.Contains(root.Text)) {
                root.BackColor = Color.Red;
            } else {
                root.BackColor = Color.Green;
            }
            foreach (TreeNode childNode in root.Nodes) {
                nextColor = childNode.ForeColor = childNode.Index % 2 == 0 ? firstColor : secondColor;
                if (fileNamesToReplace.Contains(childNode.Text)) {
                    // childNode.ImageIndex = 1;
                    root.BackColor = Color.Red;
                } else {
                    //childNode.ImageIndex = 2;
                    root.BackColor = Color.Green;
                }
                if (childNode.Nodes.Count > 0) {
                    // alternate colors for the next node
                    if (nextColor == firstColor)
                        ColorNodes(childNode, secondColor, firstColor, fileNamesToReplace);
                    else
                        ColorNodes(childNode, firstColor, secondColor, fileNamesToReplace);
                }
            }
        }

        public static void Copy(string sourceDirectory, string targetDirectory) {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
            CopyAll(diSource, diTarget);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target) {
            // Check if the target directory exists, if not, create it.
            if (Directory.Exists(target.FullName) == false) {
                Directory.CreateDirectory(target.FullName);
            }
            // Copy each file into it's new directory.
            foreach (FileInfo fi in source.GetFiles()) {
                Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
            }
            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories()) {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }        

        private void TextDiff(string sFile, string dFile) {
            _level = DiffEngineLevel.SlowPerfect;
            this.Cursor = Cursors.WaitCursor;
            DiffList_TextFile sLF = null;
            DiffList_TextFile dLF = null;
            try {
                sLF = new DiffList_TextFile(sFile);
                dLF = new DiffList_TextFile(dFile);
            } catch (Exception ex) {
                this.Cursor = Cursors.Default;
                MessageBox.Show(ex.Message, "File Error");
                return;
            }
            try {
                double time = 0;
                DiffEngine de = new DiffEngine();
                time = de.ProcessDiff(sLF, dLF, _level);
                ArrayList rep = de.DiffReport();
                Results dlg = new Results(sLF, dLF, rep, time);
                // dlg.MdiParent = this.MdiParent;
                dlg.Text = Path.GetFileName(sFile);
                dlg.ShowDialog();
                dlg.Dispose();
            } catch (Exception ex) {
                this.Cursor = Cursors.Default;
                string tmp = string.Format("{0}{1}{1}***STACK***{1}{2}",
                    ex.Message,
                    Environment.NewLine,
                    ex.StackTrace);
                MessageBox.Show(tmp, "Compare Error");
                return;
            }
            this.Cursor = Cursors.Default;
        }

        private void LoadSimpleOptions() {
            #region OldCode
            //outputDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\output";
            //outputDir = outputDir.Replace(" ", "");
            //inputDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\input";
            //inputDir = inputDir.Replace(" ", "");
            //if (!Directory.Exists(outputDir)) {
            //    Directory.CreateDirectory(outputDir);
            //}
            //if (!Directory.Exists(inputDir)) {
            //    Directory.CreateDirectory(inputDir);
            //}
            //FrontendUtils.CheckoutPath("http://globalqa/svn/PAR/PFR/0000081/trunk/pfr/QAA-Activities/MaintenanceReduction/SimpleOptions/", inputDir);
            //LoadOptionsIntoList(inputDir); 
            #endregion

            List<SimpleRecommendationObject> allSimpleRecs = Simple_Recommendation.GetAllSimpleRecsAsList();
            InsertSimpleRecIntoListbox(allSimpleRecs);
        }

        private void InsertSimpleRecIntoListbox(List<SimpleRecommendationObject> allSimpleRecs) {
            clbSelectedoptions.Items.Clear();
            for (int i = 0; i < allSimpleRecs.Count; i++) {
                SimpleRecommendationObject simpleRecom = new SimpleRecommendationObject(allSimpleRecs[i].optionName,
                                                                                        allSimpleRecs[i].isRegex,
                                                                                        allSimpleRecs[i].description,
                                                                                        allSimpleRecs[i].pattern,
                                                                                        allSimpleRecs[i].replacement,
                                                                                        allSimpleRecs[i].fileName);
                clbSelectedoptions.Items.Add(simpleRecom);
            }
        }

        private void LoadOptionsIntoList(string inputDir) {
            clbSelectedoptions.Items.Clear();
            string[] simpleOptionFiles = Directory.GetFiles(inputDir, "*.simpleO");
            for (int i = 0; i < simpleOptionFiles.Length; i++) {
                SimpleRecommendationObject simpleRecom = ConvertToObject(FrontendUtils.ReadFile(simpleOptionFiles[i]));
                clbSelectedoptions.Items.Add(simpleRecom);
            }
        }

        private SimpleRecommendationObject ConvertToObject(string fileRead) {
            SimpleRecommendationObject newRecObj = new SimpleRecommendationObject();
            string[] separator = new string[] { "##SPLIT##" };
            string[] splitFile = fileRead.Split(separator, StringSplitOptions.RemoveEmptyEntries);
            newRecObj.optionName = splitFile[0].Replace("\r\n", string.Empty);
            newRecObj.description = splitFile[1].Replace("\r\n", string.Empty);
            newRecObj.isRegex = string.Equals(splitFile[2].Replace("\r\n", string.Empty), "True", StringComparison.InvariantCultureIgnoreCase) ? true : false;
            newRecObj.pattern = splitFile[3].Replace("\r\n", string.Empty);
            newRecObj.replacement = splitFile[4].Replace("\r\n", string.Empty);
            return newRecObj;
        }

        private void BackupInputDirectory(string inputDirectory, string backupDirectory) {
            Copy(inputDirectory, backupDirectory);
        }

        private bool IsValidToParse(string inputDir, CheckedListBox clbSelectedoptions) {
            if (string.IsNullOrEmpty(inputDir)) {
                FrontendUtils.ShowError("Input Directory is not filled", null);
                return false;
            } else if (!Directory.Exists(inputDir)) {
                FrontendUtils.ShowError("Input Directory does not exist", null);
                return false;
            } else if (clbSelectedoptions.SelectedItems == null) {
                FrontendUtils.ShowError("Please select some Recommendations", null);
                return false;
            }
            return true;
        }

        private void ParseEventFiles(string inputDirectory, CheckedListBox.CheckedItemCollection selectedObjectCollection) {
            //get events files   
            string[] applicableFiles = Directory.GetFiles(txtInputDir.Text, CLEANUPFORM_EVENTS_SEARCH_PATTERN, SearchOption.AllDirectories);
            //run query on them
            string readFile = string.Empty;
            List<string> FilesToReplace = new List<string>();
            for (int i = 0; i < applicableFiles.Length; i++) {
                readFile = FrontendUtils.ReadFile(applicableFiles[i]);
                if (RunSelectedOptionsOnTextIsMatch(readFile, selectedObjectCollection)) {
                    FilesToReplace.Add(applicableFiles[i]);
                }
            }
            List<string> fileNamesToReplace = GetFileNames(FilesToReplace);
            fillTree(FilesToReplace);
            SearchAndReplaceOnFiles(FilesToReplace, selectedObjectCollection);

            #region Old Code



            //List<string> fileNamesToReplace = GetFileNames(FilesToReplace);

            //foreach (TreeNode rootNode in tvFilesAffected.Nodes) {
            //    if (fileNamesToReplace.Contains(rootNode.Text)) {
            //        // childNode.ImageIndex = 1;
            //        rootNode.BackColor = Color.Red;
            //    } else {
            //        //childNode.ImageIndex = 2;
            //        rootNode.BackColor = Color.Green;
            //    }
            //    ColorNodes(rootNode, Color.DarkGray, Color.DodgerBlue, fileNamesToReplace);
            //}

            #endregion
        }

        private void SearchAndReplaceOnFiles(List<string> FilesToReplace, CheckedListBox.CheckedItemCollection selectedObjectCollection) {
            string readText = string.Empty;
            string readTextReplaced = string.Empty;
            for (int i = 0; i < FilesToReplace.Count; i++) {
                readText = FrontendUtils.ReadFile(FilesToReplace[i]);
                for (int j = 0; j < selectedObjectCollection.Count; j++) {
                    SimpleRecommendationObject simpleRec = selectedObjectCollection[j] as SimpleRecommendationObject;
                    if (simpleRec.isRegex) {
                        Regex regex = new Regex(simpleRec.pattern, RegexOptions.Compiled);
                        if (regex.IsMatch(readText)) {
                            readText = regex.Replace(readText, simpleRec.replacement);
                        }
                    } else {
                        readText = readText.Replace(simpleRec.pattern, simpleRec.replacement);
                    }
                }
                FrontendUtils.WriteFile(FilesToReplace[i], readText);
            }
        }

        private List<string> GetFileNames(List<string> FilesToReplace) {
            List<string> allfileNames = new List<string>();
            for (int i = 0; i < FilesToReplace.Count; i++) {
                allfileNames.Add(Path.GetFileName(FilesToReplace[i]));
            }
            return allfileNames;
        }

        private bool RunSelectedOptionsOnTextIsMatch(string readFile, CheckedListBox.CheckedItemCollection selectedObjectCollection) {
            bool found = false;
            for (int i = 0; i < selectedObjectCollection.Count && !found; i++) {
                SimpleRecommendationObject simpleRec = selectedObjectCollection[i] as SimpleRecommendationObject;
                if (simpleRec.isRegex) {
                    Regex regex = new Regex(simpleRec.pattern, RegexOptions.Compiled);
                    if (regex.IsMatch(readFile)) {
                        found = true;
                    }
                } else if (!simpleRec.isRegex) {
                    if (readFile.Contains(simpleRec.pattern)) {
                        found = true;
                    }
                }
            }
            return found;
        }

        #endregion

        #region Events

        private void btnStart_Click(object sender, EventArgs e) {
            try {
                if (IsValidToParse(txtInputDir.Text, clbSelectedoptions)) {
                    tvFilesAffected.Nodes.Clear();
                    backupDirectory = outputDir + @"\Backup\";
                    BackupInputDirectory(txtInputDir.Text, backupDirectory + Path.GetFileName(txtInputDir.Text));
                    ParseEventFiles(txtInputDir.Text, clbSelectedoptions.CheckedItems);
                    tvFilesAffected.ExpandAll();
                    FrontendUtils.ShowInformation("The cleanup is done!",false);
                    btnStart.Enabled = false;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void CleanupForm_Load(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(MonitorObject.username)) {
                    MonitorObject.formAndAccessTime.Add(new FormAndAccessTime(this.Name, DateTime.Now));

                }
                // checkout the simple recommendatiosn and load them into the ui
                CLEANUPFORM_EVENTS_SEARCH_PATTERN = Application_Settings.GetAppConfigValueByKey(Application_Settings.ApplicationConfigKeys.CleanUpEventsSearchPattern) as string;
                txtInputDir.Text = inputDir;
                LoadSimpleOptions();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void clbSelectedoptions_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (clbSelectedoptions.SelectedItem == null) {
                    return;
                }
                SimpleRecommendationObject newRecObj = clbSelectedoptions.SelectedItem as SimpleRecommendationObject;
                lblOptionDetails.Text = string.Empty;
                lblOptionDetails.Text = lblOptionDetails.Text + "Name: " + newRecObj.optionName + "\r\n";
                lblOptionDetails.Text = lblOptionDetails.Text + "Description: " + newRecObj.description + "\r\n";
                lblOptionDetails.Text = lblOptionDetails.Text + "Regex: " + (newRecObj.isRegex ? "Yes" : "No") + "\r\n";
                lblOptionDetails.Text = lblOptionDetails.Text + "Pattern: " + newRecObj.pattern + "\r\n";
                lblOptionDetails.Text = lblOptionDetails.Text + "Replacement: " + newRecObj.replacement;
                lblOptionDetails.Visible = true;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnReloadOptions_Click(object sender, EventArgs e) {
            try {
                CLEANUPFORM_EVENTS_SEARCH_PATTERN = Application_Settings.GetAppConfigValueByKey(Application_Settings.ApplicationConfigKeys.CleanUpEventsSearchPattern) as string;
                LoadSimpleOptions();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void tvFilesAffected_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            try {
                string nodepath = tvFilesAffected.SelectedNode.FullPath;
                string fileSystemPathReached = Directory.GetParent(txtInputDir.Text) + tvFilesAffected.SelectedNode.FullPath;
                if (File.Exists(fileSystemPathReached)) {
                    string fileSystemPathSource = backupDirectory + tvFilesAffected.SelectedNode.FullPath;
                    TextDiff(fileSystemPathSource, fileSystemPathReached);
                } else {
                    FrontendUtils.ShowError("Please select a file to display the difference", null);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                if (Directory.Exists(backupDirectory)) {
                    Process.Start(backupDirectory);
                } else {
                    FrontendUtils.ShowError("The backup directory does not exist yet", null);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            try {
                LoadSimpleOptions();
                lblOptionDetails.Visible = false;
                tvFilesAffected.Nodes.Clear();
                txtInputDir.Text = string.Empty;
                btnStart.Enabled = true;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtInputDir.Text = dialog.SelectedPath;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }
 
        #endregion
           
   }
}