using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml;


namespace XmlParsersAndUi {
    public partial class MainForm : Form {
        private int childFormNumber = 0;

        public List<string> priveligedUsers {
            get;
            set;
        }

        public MainForm() {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e) {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK) {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK) {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e) {
        }
           

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e) {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e) {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e) {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e) {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (Form childForm in MdiChildren) {
                childForm.Close();
            }
        }

        private void simpleOperationToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
              //  SimpleOperationParser simpleOperationParser = new SimpleOperationParser();
             //   simpleOperationParser.MdiParent = this;
             //   simpleOperationParser.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message);
            }
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Form1 form1 = new Form1();
                form1.MdiParent = this;
                form1.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message);
            }
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Form2 form2 = new Form2();
                form2.MdiParent = this;
                form2.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message);
            }
        }

        private void setupRecommendationsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                SetupRecForm setupRecForm = new SetupRecForm();
                setupRecForm.MdiParent = this;
                setupRecForm.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message);
            }
        }

        private void configBuilderToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                ConfigBuilder configBuilder = new ConfigBuilder();
                configBuilder.MdiParent = this;
                configBuilder.Show();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void cleanupToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                CleanupForm cleanupForm = new CleanupForm();
                cleanupForm.MdiParent = this;
                cleanupForm.Show();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            string configFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\app.conf";
            XmlDocument xmldoc = new XmlDocument();
            try {
                xmldoc.Load(configFile);
                priveligedUsers = new List<string>();
                XmlNodeList nodeList = xmldoc.DocumentElement.ChildNodes[0].ChildNodes;
                for (int i = 0; i < nodeList.Count; i++) {
                    priveligedUsers.Add(nodeList[i].Attributes["key"].Value);
                }
                System.Security.Principal.WindowsIdentity user =
                  System.Security.Principal.WindowsIdentity.GetCurrent();
                if (!priveligedUsers.Contains(user.Name.Split('\\').ElementAt(1))) {
                    setupRecommendationsToolStripMenuItem.Visible = false;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message);
            }
        }

        private void macroSplitToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                BulkMacroSplitterForm form = new BulkMacroSplitterForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message);
            }
        }

        private void firstLevelCleanupToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                CleanupForm form = new CleanupForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message);
            }
        }

        private void advancedOperationToolStripMenuItem_Click(object sender, EventArgs e) {

        }       
    }
}