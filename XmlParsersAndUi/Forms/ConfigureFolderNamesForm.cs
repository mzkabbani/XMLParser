using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Automation.Common.Utils;
using Automation.Backend;

namespace XmlParsersAndUi.Forms {
    public partial class ConfigureFolderNamesForm : Form {
        public ConfigureFolderNamesForm() {
            InitializeComponent();
        }
        private TreeNode CreateNode(string text, bool expanded) {
            TreeNode node = new TreeNode(text);
            node.Expand();
            return node;
        }

        private void RecursivelyPopulate(DataRow dbRow, TreeNode node) {
            foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation")) {
                TreeNode childNode = CreateNode(childRow["folderName"].ToString(), true);
                node.Nodes.Add(childNode);
                RecursivelyPopulate(childRow, childNode);
            }
        }

        private void ConfigureFolderNamesForm_Load(object sender, EventArgs e) {
            try {
                DataSet dataSet = Folder_Names.GetAllFolderNamesAsDataset();
                dataSet.Relations.Add("NodeRelation", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["parentId"]);

                foreach (DataRow dataRow in dataSet.Tables[0].Rows) {
                    if (dataRow.IsNull("parentId")) {
                        TreeNode node = CreateNode(dataRow["folderName"].ToString(), true);

                        tvFolderNames.Nodes.Add(node);
                        RecursivelyPopulate(dataRow, node);
                    }
                }
                tvFolderNames.ExpandAll();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnSaveFolderNames_Click(object sender, EventArgs e) {
            try {
                SaveUpdatedTreeView();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        List<TreeNode> allTreeNodes = new List<TreeNode>();

        private void SaveUpdatedTreeView() {
            LoopOverAllTreeNodes();
            Folder_Names.UpdateTreeNodesTransaction(allTreeNodes);
        }

        private void LoopOverAllTreeNodes() {
            foreach (TreeNode treeNode in tvFolderNames.Nodes) {
                allTreeNodes.Add(treeNode);
                ParseAllChildren(treeNode);
            }
        }

        private void ParseAllChildren(TreeNode treeNode) {
            foreach (TreeNode childNode in treeNode.Nodes) {
                allTreeNodes.Add(childNode);
                if (childNode.Nodes.Count > 0) {
                    ParseAllChildren(childNode);
                }
            }
        }

        private void tvFolderNames_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                txtSelectedFolderName.Text = tvFolderNames.SelectedNode.Text;
                btnAddChild.Enabled = true;
                btnSaveName.Enabled = true;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void button1_Click(object sender, EventArgs e) {
            try {
                tvFolderNames.SelectedNode.Text = txtSelectedFolderName.Text;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            try {
                txtSelectedFolderName.Text = string.Empty;
                btnAddChild.Enabled = false;
                btnSaveName.Enabled = false;
                tvFolderNames.SelectedNode = new TreeNode();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnAddChild_Click(object sender, EventArgs e) {
            try {
                tvFolderNames.SelectedNode.Nodes.Add(txtSelectedFolderName.Text);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void addChildToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                EditFolderNameForm form = new EditFolderNameForm();
                DialogResult dialog = form.ShowDialog();

                if (dialog == DialogResult.OK) {
                    tvFolderNames.SelectedNode.Nodes.Add(form.Controls["txtNewName"].Text);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void saveNameToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                EditFolderNameForm form = new EditFolderNameForm(tvFolderNames.SelectedNode.Text);
                DialogResult dialog = form.ShowDialog();

                if (dialog == DialogResult.OK) {
                    tvFolderNames.SelectedNode.Text = form.Controls["txtNewName"].Text;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

    }
}
