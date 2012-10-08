using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Xml.Linq;
using System.Data.SqlClient;

namespace OracleConfigAlterations {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
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


        private void MainForm_Load(object sender, EventArgs e) {
            try {

                outputDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\output";
                outputDir = outputDir.Replace(" ", "");
                if (!Directory.Exists(outputDir)) {
                    Directory.CreateDirectory(outputDir);
                }
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load("App.config");
                XmlNodeList TpksFromConfig = xmlDoc.DocumentElement.ChildNodes;
                for (int i = 0; i < TpksFromConfig.Count; i++) {
                    ConfigurationObject confObject = new ConfigurationObject();
                    confObject.tpkNumber = TpksFromConfig[i].Attributes["number"].Value;
                    confObject.nickname = TpksFromConfig[i].Attributes["nickname"].Value;
                    if (TpksFromConfig[i].HasChildNodes) {
                        confObject.hasEnv = true;
                        confObject.envNumber = TpksFromConfig[i].ChildNodes[0].Attributes["number"].Value;
                    }
                    lstTpks.Items.Add(confObject);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCheckout_Click(object sender, EventArgs e) {
            try {
                bgwCheckoutWorker.RunWorkerAsync(txtBranch.Text);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnShowOut_Click(object sender, EventArgs e) {
            try {
                if (Directory.Exists(outputDir)) {
                    Process.Start(outputDir);
                } else {
                    MessageBox.Show("The output directory does not exist yet");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void bgwCheckoutWorker_DoWork(object sender, DoWorkEventArgs e) {

            System.Windows.Forms.ListBox.ObjectCollection configObjects = lstTpks.Items;
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

        private void btnStart_Click(object sender, EventArgs e) {
            try {
                ConfigFile configFile = new ConfigFile();

                List<ConfigFile> configFiles = new List<ConfigFile>();
                for (int i = 0; i < lstTpks.Items.Count; i++) {
                    configFiles = ParseConfigFiles(lstTpks.Items[i] as ConfigurationObject);
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private List<ConfigFile> ParseConfigFiles(ConfigurationObject configurationObject) {
            List<ConfigFile> configFiles = new List<ConfigFile>(); ;
            if (configurationObject.hasEnv) {
                configFiles = ParseTPKWithEnvConfigFiles(configurationObject);
            } else if (!configurationObject.hasEnv) {
                configFiles = ParseTPKConfigFiles(configurationObject);
            }

            return configFiles;
        }

        private List<ConfigFile> ParseTPKWithEnvConfigFiles(ConfigurationObject configurationObject) {
            List<ConfigFile> configFiles = new List<ConfigFile>();
            bool found = false;
            ConfigFile configFileOriginal = SearchForNicknames(configurationObject, false, out found);
            //here we have the basic config file
            ConfigFile configFileOriginalBase;
            if (found) {
                if (!configFileOriginal.availableNickname.isBaseNickname) {
                    configurationObject.nickname = configFileOriginal.availableNickname.referenceNickname;
                    configFileOriginalBase = SearchForNicknames(configurationObject, true, out found);
                }

                configurationObject.nickname = configurationObject.nickname + "_ORA11_MIG";
                bool foundOra11Mig;
                ConfigFile configFileOra11Mig = SearchForNicknames(configurationObject, false, out foundOra11Mig);
                ConfigFile configFileOra11MigBase;
                if (foundOra11Mig) {// check for dump check tpk murex then go to env
                    if (!configFileOra11Mig.availableNickname.isBaseNickname) {
                        configurationObject.nickname = configFileOra11Mig.availableNickname.referenceNickname;
                        configFileOra11MigBase = SearchForNicknames(configurationObject, true, out foundOra11Mig);
                    }
                } else {
                    //create new 

                }

                configurationObject.nickname = configurationObject.nickname + "_ORA11";
                bool foundOra11;
                ConfigFile configFileOra11 = SearchForNicknames(configurationObject, false, out foundOra11);
                ConfigFile configFileOra11Base;
                if (foundOra11) {//test parameters (tpk and env ) and bcps
                    if (!configFileOra11Mig.availableNickname.isBaseNickname) {
                        configurationObject.nickname = configFileOra11.availableNickname.referenceNickname;
                        configFileOra11Base = SearchForNicknames(configurationObject, true, out foundOra11);
                    }
                } else {
                    //create new 

                }


            } else {
                // do nothing coz nickname not found
            }
            return configFiles;
        }


        private List<ConfigFile> ParseTPKConfigFiles(ConfigurationObject configurationObject) {
            List<ConfigFile> configFiles = new List<ConfigFile>();
            bool found = false;
            ConfigFile configFileOriginal = SearchForNicknamesTpkOnly(configurationObject, false, out found);
            //here we have the basic config file
            ConfigFile configFileOriginalBase = new ConfigFile(); ;
            if (found) {
                string oldNickname = string.Empty;
                if (!configFileOriginal.availableNickname.isBaseNickname) {
                    oldNickname = configurationObject.nickname;
                    configurationObject.nickname = configFileOriginal.availableNickname.referenceNickname;
                    configFileOriginalBase = SearchForNicknamesTpkOnly(configurationObject, true, out found);
                    configurationObject.nickname = oldNickname;
                }
                //=====>>>  care here we need to keep the basic configurationObject.nickname intact
                configurationObject.nickname = configurationObject.nickname + "_ORA11_MIG";
                bool foundOra11Mig;
                ConfigFile configFileOra11Mig = SearchForNicknamesTpkOnly(configurationObject, false, out foundOra11Mig);
                ConfigFile configFileOra11MigBase = new ConfigFile();
                if (foundOra11Mig) {// check for dump check tpk murex then go to env
                    // case found here we have same reference nicknames ==> no work done on base config file
                    if (!configFileOra11Mig.availableNickname.isBaseNickname && string.Equals(configFileOra11Mig.availableNickname.referenceNickname, configFileOriginal.availableNickname.referenceNickname)) {
                        if (!string.IsNullOrEmpty(configFileOra11Mig.availableNickname.dumpId)) {
                            // we need to replace the dump if the dump was in public config
                            configFileOra11Mig.availableNickname.newXmlRepresentation = configFileOra11Mig.availableNickname.oldXmlRepresentation.Replace(configFileOra11Mig.availableNickname.dumpId, configFileOriginal.availableNickname.dumpId); 
                        }
                        //they have different reference nicknames
                    }else if (!configFileOra11Mig.availableNickname.isBaseNickname) {
                        configurationObject.nickname = configFileOra11Mig.availableNickname.referenceNickname;
                        configFileOra11MigBase = SearchForNicknamesTpkOnly(configurationObject, true, out foundOra11Mig);
                        //get dump id and replace it ====> or here we get the databases tag entirely
                        if (configFileOra11MigBase.availableNickname.oldXmlRepresentation.Contains("Dump")) {
                            configFileOra11MigBase.availableNickname.newXmlRepresentation = configFileOra11MigBase.availableNickname.oldXmlRepresentation.Replace(configFileOra11MigBase.availableNickname.dumpId, configFileOriginalBase.availableNickname.dumpId);
                        } else if (configFileOra11Mig.availableNickname.oldXmlRepresentation.Contains("Dump")) {
                        }
                    }                  
                } else {
                    //create new 

                }


                configurationObject.nickname = configurationObject.nickname + "_ORA11";
                bool foundOra11;
                ConfigFile configFileOra11 = SearchForNicknamesTpkOnly(configurationObject, false, out foundOra11);
                ConfigFile configFileOra11Base;
                if (foundOra11) {//test parameters (tpk and env ) and bcps
                    if (!configFileOra11Mig.availableNickname.isBaseNickname) {
                        configurationObject.nickname = configFileOra11.availableNickname.referenceNickname;
                        configFileOra11Base = SearchForNicknamesTpkOnly(configurationObject, true, out foundOra11);
                    }
                } else {
                    //create new 

                }


            } else {
                // do nothing coz nickname not found
            }
            return configFiles;
        }


        private ConfigFile SearchForNicknames(ConfigurationObject configurationObject, bool searchForBase, out bool found) {

            ConfigFile confFile = new ConfigFile();
            found = false;

            confFile = MarshalConfigFile(configurationObject.tpkPublicConfigCheckedOutPath, configurationObject.nickname, searchForBase, out found);
            confFile.filePath = configurationObject.tpkPublicConfigCheckedOutPath;
            confFile.isEnv = false;
            confFile.isPublic = true;
            if (!found) {
                confFile = MarshalConfigFile(configurationObject.tpkMurexConfigCheckedOutPath, configurationObject.nickname, searchForBase, out found);
                confFile.filePath = configurationObject.tpkMurexConfigCheckedOutPath;
                confFile.isEnv = false;
                confFile.isPublic = false;
                if (!found) {
                    confFile = MarshalConfigFile(configurationObject.envPublicConfigCheckedOutPath, configurationObject.nickname, searchForBase, out found);
                    confFile.filePath = configurationObject.envPublicConfigCheckedOutPath;
                    confFile.isEnv = true;
                    confFile.isPublic = true;
                    if (!found) {
                        confFile = MarshalConfigFile(configurationObject.envMurexConfigCheckedOutPath, configurationObject.nickname, searchForBase, out found);
                        confFile.filePath = configurationObject.envMurexConfigCheckedOutPath;
                        confFile.isEnv = true;
                        confFile.isPublic = false;
                    }
                }
            }
            return confFile;
        }


        private ConfigFile SearchForNicknamesTpkOnly(ConfigurationObject configurationObject, bool searchForBase, out bool found) {
            ConfigFile confFile = new ConfigFile();
            found = false;
            confFile = MarshalConfigFile(configurationObject.tpkPublicConfigCheckedOutPath, configurationObject.nickname, searchForBase, out found);
            confFile.filePath = configurationObject.tpkPublicConfigCheckedOutPath;
            confFile.isEnv = false;
            confFile.isPublic = true;
            if (!found) {
                confFile = MarshalConfigFile(configurationObject.tpkMurexConfigCheckedOutPath, configurationObject.nickname, searchForBase, out found);
                confFile.filePath = configurationObject.tpkMurexConfigCheckedOutPath;
                confFile.isEnv = false;
                confFile.isPublic = false;              
            }
            return confFile;
        }

        private ConfigFile MarshalConfigFile(string pathOfConfigFile, string nickname, bool searchForBase, out bool found) {
            found = false;
            ConfigFile configFile = new ConfigFile();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(pathOfConfigFile);
            configFile.availableNickname = new ConfigFileNickname();
            XmlNodeList childrenTests = xmlDoc.DocumentElement.ChildNodes;
            for (int i = 0; i < childrenTests.Count && !found; i++) {

                XDocument xdoc = XDocument.Parse(childrenTests[i].OuterXml);
                string s1 = string.Empty;
                var q1 = from c in xdoc.Descendants("AvailableTest")
                         select new {
                             s1 = (string)c.Element("NickName")
                         };
                if (string.Equals(q1.ElementAt(0).s1, nickname)) {
                    ConfigFileNickname nicknameObject = new ConfigFileNickname();
                    bool isbaseNickname;
                    string referenceNickname;
                    List<string> testParams;
                    string foundNickname;
                    string bcps;
                    string dumpId;
                    GetNicknameObject(nickname, childrenTests[i].ChildNodes, out isbaseNickname, out referenceNickname, out testParams, out bcps, out foundNickname, out dumpId);
                    nicknameObject.isBaseNickname = isbaseNickname;
                    nicknameObject.referenceNickname = referenceNickname;
                    nicknameObject.nickname = foundNickname;
                    nicknameObject.oldXmlRepresentation= childrenTests[i].OuterXml;
                    nicknameObject.bcps = bcps;
                    nicknameObject.testParameters = testParams;
                    nicknameObject.dumpId = dumpId;
                    configFile.availableNickname = nicknameObject;
                    if (searchForBase && isbaseNickname) {
                        found = true;
                    } else if (!searchForBase) {
                        found = true;
                    }
                }
            }
            return configFile;
        }

        private void GetNicknameObject(string nickname, XmlNodeList xmlNodeList, out bool isbaseNickname, out string referenceNick, out List<string> testParams, out string databasesTag, out string foundNickname, out string dumpId) {
            isbaseNickname = true;
            dumpId = string.Empty;
            foundNickname = string.Empty;
            referenceNick = string.Empty;
            databasesTag = string.Empty;
            testParams = new List<string>();
            for (int i = 0; i < xmlNodeList.Count; i++) {
                if (string.Equals(xmlNodeList[i].Name, "Nickname", StringComparison.InvariantCultureIgnoreCase)) {
                    foundNickname = xmlNodeList[i].InnerXml;
                } else if (string.Equals(xmlNodeList[i].Name, "Import", StringComparison.InvariantCultureIgnoreCase)) {
                    XmlNodeList importNodes = xmlNodeList[i].ChildNodes;
                    for (int j = 0; j < importNodes.Count; j++) {
                        if (string.Equals(importNodes[j].Name, "RefNickName", StringComparison.InvariantCultureIgnoreCase)) {
                            isbaseNickname = false;
                            referenceNick = importNodes[j].InnerXml;
                        }
                    }
                } else if (string.Equals(xmlNodeList[i].Name, "Customize", StringComparison.InvariantCultureIgnoreCase)) {
                    XDocument xdoc = XDocument.Parse(xmlNodeList[i].OuterXml);
                    var q1 = from c in xdoc.Descendants("Customize")
                             select new {
                                 s1 = (string)c.Element("Databases").Element("Database").Element("Dump")
                             };
                    
                    XmlNodeList customizeNodes = xmlNodeList[i].ChildNodes;
                    for (int k = 0; k < customizeNodes.Count; k++) {
                        if (string.Equals(customizeNodes[k].Name, "TestParameters", StringComparison.InvariantCultureIgnoreCase)) {
                            testParams = customizeNodes[k].InnerXml.Split(' ').ToList();
                        } else if (string.Equals(customizeNodes[k].Name, "Databases", StringComparison.InvariantCultureIgnoreCase)) {
                            databasesTag = customizeNodes[k].OuterXml;
                        }
                    }
                }
            }
        }

        private void GetSqlConnection() {
            SqlConnection conn = new SqlConnection();

            try {
                conn.Open();
            } catch (Exception ex) {
                
            }
            conn.Close();
        }


        private string ReadFile(string pathOfConfigFile) {
            string readText = string.Empty;
            StreamReader reader = new StreamReader(pathOfConfigFile);
            try {
                readText = reader.ReadToEnd();
            } finally {
                reader.Close();
                reader.Dispose();
            }
            return readText;
        }

    }
}
