using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using FtpLib;
using Tamir.SharpSsh;
using System.Text.RegularExpressions;
using Automation.Common.Utils;

namespace XmlParsersAndUi.Forms {



    public partial class PushAutomationJobForm : Form {
        public PushAutomationJobForm() {
            InitializeComponent();
        }

        string jobParamtersText = "Site Name=/MXJ_SITE_NAME;Platform Name=/MXJ_PLATFORM_NAME:;Process Nickname=/MXJ_PROCESS_NICK_NAME:;" +
                                 "Installation Code=/MXJ_INSTALLATION_CODE:;TPK Reference=/TPK_REFERENCE:;TPK Nickname=/TPK_NICKNAME:;" +
                                 "MX Build ID=/BUILD_ID:;Changelist=/CHANGE_LIST:;Build ID Type=/BUILD_ID_TYPE:;Version=/VERSION:;" +
                                 "Operating System=/OPERATING_SYSTEM:;Database Server=/DB_SERVER:;FS Host=/FS_HOST:;FS Port=/FS_PORT:;" +
                                 "Install Directory=/INSTALL_DIR:;Job ID=/JOB_ID:;Test Target=/TEST_TARGET:;Job Type=/JOB_TYPE:;" +
                                 "Reference Job ID=/REF_JOB_ID:;Status After Done=/STATUS_AFTER_DONE:;Test Parameters=/TEST_PARAMETERS:;" +
                                 "Deploy Parameters=/DEPLOY_PARAMETERS:;Local Agent=/LOCALAGENT:;User=/USER:;Comment=/COMMENT:;" +
                                 "Customize=/CUSTOMIZE:;Customize Path=/CUSTOMIZE_PATH:;Pac Path=/PAC_PATH:;Client Path=/CLIENT_PATH:;" +
                                 "Client ID=/CLIENT_ID:;Session Filename=/MX_SESSION_FILENAME:;Session Nickname=/MX_SESSION_NICKNAME:;" +
                                 "Session Customize=/MX_SESSION_CUSTOMIZE:;Quality Version=/MX_QUALITY_VERSION:;Quality Build ID=/MX_QUALITY_BUILD_ID:;" +
                                 "Quality Build ID Type=/MX_QUALITY_BUILD_ID_TYPE:;Quality Branch=/MX_QUALITY_BRANCH:;" +
                                 "Quality Revision=/MX_QUALITY_REVISION:;Days to Keep=/NUMBER_OFDAYS_KEPT:";

        private void PushAutomationJobForm_Load(object sender, EventArgs e) {
            try {
                //string readFile = FrontendUtils.ReadFile("D:/jobParameters.pa");
                List<string> readFileSplit = ReadFileAndSplit("D:/jobParameters.pa");

                LoadJobParametersIntoTree(readFileSplit);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private List<string> ReadFileAndSplit(string filePath) {
            List<string> fileLines = new List<string>();
            StreamReader reader = new StreamReader(filePath);

            try {
                string line = string.Empty;
                while (!string.IsNullOrEmpty((line = reader.ReadLine()))) {
                    fileLines.Add(line);
                }
            } finally {
                reader.Close();
            }

            return fileLines;
        }

        private void LoadJobParametersIntoTree(List<string> paramsAsText) {

            TreeNode rootNode = tvJobParameters.Nodes.Add("Job");
            for (int i = 0; i < paramsAsText.Count; i++) {
                string[] keyValues = paramsAsText[i].Split('=');
                JobParameter jobParameter = new JobParameter(keyValues[0], keyValues[1].Split(':')[0] + ":", keyValues[1].Split(':').Length > 0 ? keyValues[1].Split(':')[1] : string.Empty);
                rootNode.Nodes.Add(jobParameter);
            }
        }

        private void tvJobParameters_AfterSelect(object sender, TreeViewEventArgs e) {
            try {
                if (e.Node is JobParameter) {
                    FillUiFromSelectedNode(e.Node as JobParameter);
                    gbValues.Visible = true;
                } else {
                    gbValues.Visible = false;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void FillUiFromSelectedNode(JobParameter jobParameter) {
            lblName.Text = jobParameter.localReadableName;
            txtValue.Text = jobParameter.localValue;
        }

        private void tvJobParameters_BeforeSelect(object sender, TreeViewCancelEventArgs e) {
            try {
                if (tvJobParameters.SelectedNode != null) {
                    if (tvJobParameters.SelectedNode is JobParameter) {
                        SaveSubmitedValue(lblName.Text, txtValue.Text, tvJobParameters.SelectedNode);
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void SaveSubmitedValue(string labelName, string valueToSave, TreeNode treeNode) {
            (treeNode as JobParameter).localValue = txtValue.Text;
        }



        private void btnStart_Click(object sender, EventArgs e) {
            try {
                string generatedScript = GetGeneratedScript(tvJobParameters.Nodes[0].Nodes);
                string filename = "D:/launchJob.sh";
                StreamWriter writer = new StreamWriter(filename);
                writer.Write(generatedScript);
                writer.Flush();
                writer.Close();
                SendFileToServer(filename);
                InitializeSSh();
                string result = string.Empty;
                result = result + ExecuteFileAndReturnResult("rm -f /dell014srv1/automation/automation-Jobs/launchJob1.sh");

                result = result + ExecuteFileAndReturnResult("cp /dell014srv1/automation/automation-Jobs/launchJob.sh /dell014srv1/automation/automation-Jobs/launchJob1.sh");

                result = result + ExecuteFileAndReturnResult("chmod 777 /dell014srv1/automation/automation-Jobs/launchJob1.sh");
                result = result + ExecuteFileAndReturnResult("/dell014srv1/automation/automation-Jobs/launchJob1.sh");
                result = result + ssh.ReadResponse();

                Regex reg = new Regex("PAR\\.DJOB\\.\\d+");
                FrontendUtils.ShowInformation(reg.Match(result).Value + " Pushed!",false);

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        SshStream ssh;

        private void InitializeSSh() {
            ssh = new SshStream("dell014srv", "autoengine", "");
            //Set the end of response matcher character
            ssh.Prompt = "\\$";
            //Remove terminal emulation characters
            ssh.RemoveTerminalEmulationCharacters = true;
            //Writing to the SSH channel
            //tmReturn.Start();;
        }



        private string ExecuteCommandReturnResult(string commandText) {
            string response = string.Empty;
            //Remove terminal emulation characters
            ssh.RemoveTerminalEmulationCharacters = true;
            //Writing to the SSH channel

            ssh.Write(commandText);
            //Reading from the SSH channel


            //Reading from the SSH channel
            return response = ssh.ReadResponse();
        }
        private string ExecuteFileAndReturnResult(string filepath) {

            return ExecuteCommandReturnResult(filepath);
        }

        private void SendFileToServer(string filename) {
            List<string> remoteFiles = new List<string>();
            string localDownloadDirectory = string.Empty;
            FtpConnection connection = new FtpConnection("dell014srv", "mxftp", "mxftp");
            try {
                try {
                    connection.Open();
                } catch (Exception ex) {
                    FrontendUtils.ShowError(ex.Message, ex);
                }

                connection.Login();
                connection.SetCurrentDirectory("/dell014srv1/automation/automation-Jobs/");
                connection.PutFile(filename, "launchJob.sh");

            } finally {
                connection.SetLocalDirectory(Path.GetTempPath());
                connection.Close();
                connection.Dispose();

            }
        }

        private string GetGeneratedScript(TreeNodeCollection treeNodeCollection) {
            string generatedScript = "#!/bin/bash\n. /etc/profile\ncd /dell014srv1/automation/automation-Jobs/\n./deploy.sh";

            for (int i = 0; i < treeNodeCollection.Count; i++) {
                if (treeNodeCollection[i] is JobParameter) {
                    JobParameter jobParameter = treeNodeCollection[i] as JobParameter;
                    if (!string.IsNullOrEmpty(jobParameter.localValue)) {
                        generatedScript = generatedScript + " " + jobParameter.localName + jobParameter.localValue;
                    }
                }
            }
            return generatedScript;
        }

    }


    public class JobParameter : TreeNode {
        public string localReadableName;
        public string localName;
        public string localValue;

        public override string ToString() {
            return localReadableName;
        }

        public JobParameter(string readableName, string name, string value) {
            localReadableName = readableName;
            localName = name;
            localValue = value;
            this.Name = readableName;
            this.Text = readableName;
        }
    }
}
