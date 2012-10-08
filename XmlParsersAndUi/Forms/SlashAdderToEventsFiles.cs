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
using Automation.Common.Utils;

namespace XmlParsersAndUi {
    public partial class SlashAdderToEventsFiles : Form {
        public SlashAdderToEventsFiles() {
            InitializeComponent();
        }

        string slashValue = "<ConnectionParams><Session><Param>/MXJ_PING_POP_GUI_DOCUMENT:1</Param><Param>/MXJ_POP_CONNECTION_TIME_OUT:60000</Param></Session></ConnectionParams> ";

        private void btnGroup_Click(object sender, EventArgs e) {



        }

        private void AddSlashToEventsFiles(List<string> selectedItems, string slashValue) {
            for (int i = 0; i < selectedItems.Count; i++) {
                StreamReader reader = new StreamReader(selectedItems[i]);
                string readValue = string.Empty;
                try {
                    readValue = reader.ReadToEnd();
                } finally {
                    reader.Close();
                    reader.Dispose();
                }

                if (!readValue.Contains("MXJ_PING_POP_GUI_DOCUMENT")) {
                    Regex regex = new Regex("<Steps.*?>");

                    readValue = regex.Replace(readValue, regex.Match(readValue).Value + slashValue);
                    StreamWriter writer = new StreamWriter(selectedItems[i]);
                    try {
                        writer.Write(readValue);
                    } finally {
                        writer.Flush();
                        writer.Close();
                        writer.Dispose();
                    }
                }
            }
        }

        private void btnParse_Click(object sender, EventArgs e) {
            try {
                string[] foundEventsFiles = Directory.GetFiles(txtInputDir.Text, "eventsfiles.xml", SearchOption.AllDirectories);

                for (int i = 0; i < foundEventsFiles.Length; i++) {
                    chkLstAllStepEvents.Items.Add(foundEventsFiles[i]);
                }

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        bool check = true;
        private void btnSelectAll_Click(object sender, EventArgs e) {
            try {

                for (int i = 0; i < chkLstAllStepEvents.Items.Count; i++) {
                    chkLstAllStepEvents.SetItemChecked(i, check);
                }
                check = !check;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void SlashAdderToEventsFiles_Load(object sender, EventArgs e) {

        }

        private void btnGroup_Click_1(object sender, EventArgs e) {
            System.Windows.Forms.CheckedListBox.CheckedItemCollection checkedCollection = chkLstAllStepEvents.CheckedItems;
            List<string> selectedItems = new List<string>();
            for (int i = 0; i < checkedCollection.Count; i++) {
                selectedItems.Add(checkedCollection[i].ToString());
            }


            AddSlashToEventsFiles(selectedItems, slashValue);

            for (int i = 0; i < selectedItems.Count; i++) {
                chkLstAllStepEvents.Items.Remove(selectedItems[i]);

            }

        }

        private void btnOutputDir_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                if (dialog.ShowDialog() == DialogResult.OK) {
                    txtInputDir.Text = dialog.SelectedPath;
                }

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnSelectAll_Click_1(object sender, EventArgs e) {
            try {

                for (int i = 0; i < chkLstAllStepEvents.Items.Count; i++) {
                    chkLstAllStepEvents.SetItemChecked(i, check);
                }
                check = !check;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }
    }
}
