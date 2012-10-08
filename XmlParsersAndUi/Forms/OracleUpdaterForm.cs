using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Xml.Linq;
using Automation.Common.Utils;

namespace XmlParsersAndUi.Forms {
    public partial class OracleUpdaterForm : Form {
        public OracleUpdaterForm() {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            try {
                string[] nicknameSpecificDirectories = Directory.GetDirectories(txtInputDir.Text, "__" + txtNickname.Text + "__", SearchOption.AllDirectories);

                for (int i = 0; i < nicknameSpecificDirectories.Count(); i++) {
                    string Ora11DirectoryName = nicknameSpecificDirectories[i].Replace(txtNickname.Text, txtOra11Nickname.Text);
                    if (!Directory.Exists(Ora11DirectoryName)) {
                        Directory.CreateDirectory(Ora11DirectoryName);
                        string[] caughtFiles = Directory.GetFiles(nicknameSpecificDirectories[i], "*.*", SearchOption.TopDirectoryOnly);
                        for (int j = 0; j < caughtFiles.Length; j++) {
                            File.Copy(caughtFiles[j], Ora11DirectoryName + @"\" + Path.GetFileName(caughtFiles[j]));
                        }
                    } else {
                        string[] caughtFiles = Directory.GetFiles(nicknameSpecificDirectories[i], "*.*", SearchOption.TopDirectoryOnly);
                        for (int j = 0; j < caughtFiles.Length; j++) {
                            File.Copy(caughtFiles[j], Ora11DirectoryName + @"\" + Path.GetFileName(caughtFiles[j]), true);
                        }
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void txtNickname_TextChanged(object sender, EventArgs e) {
            txtOra11Nickname.Text = txtNickname.Text + "_ORA11";
        }

        private void OracleUpdaterForm_Load(object sender, EventArgs e) {
            try {
                cboModes.SelectedIndex = 0;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }


        enum cboMode {
            tpk_public = 1,
            tpk_murex = 2,
            env_public = 3,
            env_murex = 4
        }

        private void cbHasEnv_CheckedChanged(object sender, EventArgs e) {
            try {
                if (cbHasEnv.Checked) {
                    gbEnvConf.Visible = true;
                    cboModes.Items.Add("ENV-Public");
                    cboModes.Items.Add("ENV-Murex");
                    cboModes.SelectedIndex = 0;
                } else {
                    gbEnvConf.Visible = false;
                    cboModes.Items.Remove("ENV-Public");
                    cboModes.Items.Remove("ENV-Murex");
                    cboModes.SelectedIndex = 0;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        public string GetConfigFile(string[] nameSplit, string branch, bool isPublic, bool isEnv) {

            string filePath = string.Empty;

            if (isEnv) {
                if (isPublic) {
                    filePath = "http://globalqa/svn/" + nameSplit[0] + "/" + nameSplit[1] + "/" +
                            nameSplit[2] + "/" + branch + "/env/apps/fs/quality/public/conf/config.xml";
                } else {
                    filePath = "http://globalqa/svn/" + nameSplit[0] + "/" + nameSplit[1] + "/" +
                           nameSplit[2] + "/" + branch + "/env/apps/fs/quality/murex/conf/config.xml";
                }
            } else {
                if (isPublic) {
                    filePath = "http://globalqa/svn/" + nameSplit[0] + "/" + nameSplit[1] + "/" +
                                nameSplit[2] + "/" + branch + "/tpk/apps/fs/quality/public/conf/config.xml";
                } else {
                    filePath = "http://globalqa/svn/" + nameSplit[0] + "/" + nameSplit[1] + "/" +
                            nameSplit[2] + "/" + branch + "/tpk/apps/fs/quality/murex/conf/config.xml";
                }
            }

            WebClient wc = new WebClient();
            //Download the File
            string tempFileName = Path.GetTempFileName();
            wc.DownloadFile(filePath, tempFileName);

            return tempFileName;
        }

        private void txtTPKNumber_TextChanged(object sender, EventArgs e) {
            try {
                //http://globalqa/svn/PAR/TPK/0000901/trunk/tpk/apps/fs/quality/public/conf/
                if (txtTPKNumber.Text.Length == 15) {
                    //PAR.TPK.0000236
                    string[] tpkNameSplit = txtTPKNumber.Text.Split('.');
                    //[PAR,TPK,0000236]
                    string publicConfigFile = GetConfigFile(tpkNameSplit, txtBranch.Text, true, false);
                    string murexConfigFile = GetConfigFile(tpkNameSplit, txtBranch.Text, false, false);

                    StreamReader reader = new StreamReader(murexConfigFile);
                    string readText = string.Empty;
                    try {
                        readText = reader.ReadToEnd();
                    } finally {
                        reader.Close();
                    }

                    
                    XDocument xdoc = XDocument.Parse(readText);
                    var q1 = from c1 in xdoc.Descendants("AvailableTest")
                             where CheckIfNicknamePresent(xdoc.Descendants("AvailableTest").Elements("NickName").Nodes(), "DEFAULT_CONFIG")                  
                                select new {
                                     elements = c1.Descendants()
                                 };



          
                }

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private bool CheckIfNicknamePresent(IEnumerable<XNode> iEnumerable, string nickname) {
            bool found = false;

            for (int i = 0; i < iEnumerable.Count() && !found; i++) {
                if (string.Equals(nickname, iEnumerable.ElementAt(i).ToString())) {
                    found = true;
                }
            }

            return found;
        }

    }
}
