using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace OracleConfigAlterations {
    public partial class FeederDumpReplacements : Form {
        public FeederDumpReplacements() {
            InitializeComponent();
        }

        private void btnParse_Click(object sender, EventArgs e) {
            try {
                StreamReader reader = new StreamReader(txtInputFile.Text);
                try {
                    string lineRead = string.Empty;
                    while (!string.IsNullOrEmpty((lineRead = reader.ReadLine()))) {
                        
                        string[] splitLine = lineRead.Split(',');
                        ConfigurationObject confObject = new ConfigurationObject();
                        confObject.nickname =splitLine[3] ;
                        confObject.tpkNumber=splitLine[2].Split('.')[2];
                        confObject.branch =txtBranch.Text;
                        confObject.oldDumpId =splitLine[5];
                        confObject.newDumpId = splitLine[4];
                        //confObject.envNumber = GetEnvNumber(confObject.nickname,confObject.);
                        
                        
                        lbTpkList.Items.Add(confObject);
                    }
                } finally {
                    reader.Close();
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        string outputDir = string.Empty;

        private string[] GenerateLocalPath(ConfigurationObject confObject) {
            string[] localPaths = new string[4];
            // @0 tpk pub
            localPaths[0] = outputDir + @"\TPKpublic" + confObject.tpkNumber;
            // @1 tpk mur
            localPaths[1] = outputDir + @"\TPKmurex" + confObject.tpkNumber;
            if (confObject.hasEnv) {
                // @2 env pub
                localPaths[2] = outputDir + @"\ENVpublic" + confObject.envNumber;
                // @3 env mur
                localPaths[3] = outputDir + @"\ENVmurex" + confObject.envNumber;
            }
            return localPaths;

        }

        private string[] GenerateRemotePath(ConfigurationObject confObject) {
            string[] remotePaths = new string[4];
            // @0 tpk pub
            remotePaths[0] = "http://globalqa/svn/PAR/TPK/" + confObject.tpkNumber + "/" + confObject.branch + "/tpk/apps/fs/quality/public/conf/";
            // @1 tpk mur
            remotePaths[1] = "http://globalqa/svn/PAR/TPK/" + confObject.tpkNumber + "/" + confObject.branch + "/tpk/apps/fs/quality/murex/conf/";

            if (confObject.hasEnv) {
                // @2 env pub
                remotePaths[2] = "http://globalqa/svn/PAR/ENV/" + confObject.envNumber + "/" + confObject.branch + "/env/apps/fs/quality/public/conf/";
                // @3 env mur
                remotePaths[3] = "http://globalqa/svn/PAR/ENV/" + confObject.envNumber + "/" + confObject.branch + "/env/apps/fs/quality/murex/conf/";
            }

            return remotePaths;

        }

        private void CheckoutPath(string repositoryLocation, string localLocation) {
            try {
                Process p = new Process();
                p.StartInfo.FileName = "svn";
                //http://globalqa/svn/PAR/TPK/0001570/branches/v3.1.build.dev.14851.pac/tpk/apps/fs/quality/murex/conf/
                p.StartInfo.Arguments = "checkout " + repositoryLocation + " " + localLocation;
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.StartInfo.CreateNoWindow = false;
                p.Start();
                string output = p.StartInfo.Arguments + "\r\n";
                output = output + p.StandardOutput.ReadToEnd();
                bgwCheckoutWorker.ReportProgress(0, output);
                p.WaitForExit();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "SVN checkout issue");
            }
        }



        private void bgwCheckoutWorker_DoWork(object sender, DoWorkEventArgs e) {
            System.Windows.Forms.ListBox.ObjectCollection configObjects = lbTpkList.Items;
            for (int i = 0; i < configObjects.Count; i++) {
                //co tpk public and murex resp

                ConfigurationObject confObject = configObjects[i] as ConfigurationObject;
                confObject.branch = e.Argument.ToString();
                string[] remotePaths = GenerateRemotePath(confObject);
                string[] localPaths = GenerateLocalPath(confObject);

                (configObjects[i] as ConfigurationObject).tpkPublicConfigCheckedOutPath = localPaths[0] + @"\config.xml";
                (configObjects[i] as ConfigurationObject).tpkMurexConfigCheckedOutPath = localPaths[1] + @"\config.xml";
                CheckoutPath(remotePaths[0], localPaths[0]);
                CheckoutPath(remotePaths[1], localPaths[1]);

                if (confObject.hasEnv) {
                    //co env public and murex resp
                    CheckoutPath(remotePaths[2], localPaths[2]);
                    CheckoutPath(remotePaths[3], localPaths[3]);
                    (configObjects[i] as ConfigurationObject).envPublicConfigCheckedOutPath = localPaths[2] + @"\config.xml";
                    (configObjects[i] as ConfigurationObject).envMurexConfigCheckedOutPath = localPaths[3] + @"\config.xml";
                }
            }
        }

        private void bgwCheckoutWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            txtLogs.Text = txtLogs.Text + e.UserState;
        }

        private void btnCheckout_Click(object sender, EventArgs e) {
            try {
                bgwCheckoutWorker.RunWorkerAsync(txtBranch.Text);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStart_Click(object sender, EventArgs e) {
            try {
                for (int i = 0; i < lbTpkList.Items.Count; i++) {
                    

                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
