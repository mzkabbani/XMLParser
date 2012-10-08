using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using Tamir.SharpSsh;
using System.Text.RegularExpressions;
using Automation.Common.Utils;

namespace XmlParsersAndUi.Forms {
    public partial class RemoteServer : Form {

        public RemoteServer() {
            InitializeComponent();
        }

        SshStream ssh;

        private void btnTest_Click(object sender, EventArgs e) {
            try {
                ssh = new SshStream("dell036srv", "autoengine", "");
                //Set the end of response matcher character
                ssh.Prompt = "\\$";
                //Remove terminal emulation characters
                ssh.RemoveTerminalEmulationCharacters = true;
                //Writing to the SSH channel
                ssh.Write("cd /dell036srv3/apps/qa27144_TPK0001018_6297137");
                //Reading from the SSH channel
                string response = ssh.ReadResponse();
                ssh.Write("ll -ltr *all*");
                //Reading from the SSH channel
                response = ssh.ReadResponse();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
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

        private void btnInit_Click(object sender, EventArgs e) {
            try {
                ssh = new SshStream(txtHost.Text, "autoengine", "");
                //Set the end of response matcher character
                ssh.Prompt = "\\$";
                //Remove terminal emulation characters
                ssh.RemoveTerminalEmulationCharacters = true;
                //Writing to the SSH channel
                //tmReturn.Start();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnLauncAll_Click(object sender, EventArgs e) {
            try {
                txtResponse.Text = txtResponse.Text + ExecuteCommandReturnResult("launchAllServices.sh");
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnGotoApp_Click(object sender, EventArgs e) {
            try {
                ssh.Write("cd " + txtAppdir.Text);
                //Reading from the SSH channel
                string response = ssh.ReadResponse();
                ssh.Write("cd " + txtAppdir.Text);
                response = ssh.ReadResponse();
                //    ssh.Write("ll -ltr *all*");
                //    //Reading from the SSH channel
                //    response = ssh.ReadResponse();
                //
                //dell036srv autoengine /dell036srv3/apps/qa27144_TPK0001018_6297137/
                txtResponse.Text = txtResponse.Text + response;
                if (response.Contains(txtHost.Text + " autoengine " + txtAppdir.Text)) {
                    lblConnected.BackColor = Color.LightGreen;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void tmReturn_Tick(object sender, EventArgs e) {
            txtResponse.Text = txtResponse.Text + ExecuteCommandReturnResult("top -n 1");
        }

        private void button1_Click(object sender, EventArgs e) {
            ssh.Write("a");
            txtResponse.Text = txtResponse.Text + ssh.ReadResponse();
        }

        private void txtShelText_KeyPress(object sender, KeyPressEventArgs e) {
            if ((int)e.KeyChar == 13) {
                txtResponse.Text = txtResponse.Text + ExecuteCommandReturnResult(txtShelText.Text);
                txtShelText.Clear();
            }
        }

        private void btnCommit_Click(object sender, EventArgs e) {
            try {
                string response = string.Empty;
                //Remove terminal emulation characters
                ssh.RemoveTerminalEmulationCharacters = true;
                ssh.Prompt = "\\$";
                //Writing to the SSH channel

                ssh.Write("svn add *");
                //Reading from the SSH channel


                //Reading from the SSH channel
                txtResponse.Text = txtResponse.Text + "\n\n\n\n" + ssh.ReadResponse();


                //ssh.RemoveTerminalEmulationCharacters = true;
                //ssh.Prompt = "\\$";
                ////Writing to the SSH channel

                //ssh.Write("svn add *");
                ////Reading from the SSH channel


                ////Reading from the SSH channel
                //txtResponse.Text = txtResponse.Text + "\n\n\n\n" + ssh.ReadResponse();

                //ssh.Write("svn commit -m \"test\"");
                ////Reading from the SSH channel


                ////Reading from the SSH channel
                //txtResponse.Text = txtResponse.Text + "\n\n\n\n" + ssh.ReadResponse();



                //ssh.Write("ab");
                ////Reading from the SSH channel


                ////Reading from the SSH channel
                //txtResponse.Text = txtResponse.Text + "\n\n\n\n" + ssh.ReadResponse();



                //ssh.Write("mkabbani");
                ////Reading from the SSH channel


                ////Reading from the SSH channel
                //txtResponse.Text = txtResponse.Text + "\n\n\n\n" + ssh.ReadResponse();


                //ssh.Write("abc@123");
                ////Reading from the SSH channel


                ////Reading from the SSH channel
                //txtResponse.Text = txtResponse.Text + "\n\n\n\n" + ssh.ReadResponse();


                //ssh.RemoveTerminalEmulationCharacters = true;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }



        }
    }
}
