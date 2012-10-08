using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

using Automation.Backend;
using Automation.Backend.Classes;
using Automation.Common;
using Automation.Common.Classes.Monitoring;
using Automation.Common.Forms;
using Automation.Common.Utils;
using Utilities.WinForms;
using XmlParsersAndUi.Classes;
using XmlParsersAndUi.Forms;

namespace XmlParsersAndUi {
    public partial class MainForm : Form {

        #region Constructor

        public MainForm() {
            InitializeComponent();
        }

        #endregion

        #region Variables

        public string APPLICATION_VERSION = "1.1.2";
        private int childFormNumber = 0;
        string loggedInUser = string.Empty;
        int idleCounter = 0;
        public static bool appProcessing = false;
        bool TIMER_ENABLED = true;
        int CONFIGURED_IDLE_TIME = 15;

        #endregion

        #region Properties

        public List<string> priveligedUsers {
            get;
            set;
        }

        #endregion

        #region Methods

        private void SetBackEndConnectionParameter(XmlNodeList configFileNodes) {
            for (int i = 0; i < configFileNodes.Count; i++) {
                if (configFileNodes[i].NodeType == XmlNodeType.Element && configFileNodes[i].Attributes["key"] != null) {
                    if (string.Equals(configFileNodes[i].Attributes["key"].Value, "ConnectionParameter")) {

                        Automation.Backend.BackEndUtils.ConnectionParamter = configFileNodes[i].Attributes["value"].Value;

                        // tsConnectedTo.Text = "Connected to " + Directory.GetParent(BackEndUtils.ConnectionParamter);
                    }
                    if (string.Equals(configFileNodes[i].Attributes["key"].Value, "ConnectionParameter2")) {
                        BackEndUtils.ConnectionParamterPrimary = configFileNodes[i].Attributes["value"].Value;

                        // tsConnectedTo.Text = "Connected to " + Directory.GetParent(BackEndUtils.ConnectionParamter);
                    }
                }
            }
            if (string.IsNullOrEmpty(Automation.Backend.BackEndUtils.ConnectionParamter)) {
                Automation.Backend.BackEndUtils.ConnectionParamter = @"X:\beast\Test_Automation\Database.sdf";
            }
        }

        private void UpdateUIForPriviligedUsers(List<string> priviligedUsersList, string loggedInUser) {
            if (priviligedUsersList.Contains(loggedInUser)) {
                setupToolStripMenuItem.Visible = true;
            }
            if (string.Equals(loggedInUser, "mkabbani")) {
                testingToolStripMenuItem.Visible = true;
                preferencesToolStripMenuItem.Visible = true;
            }
        }

        private XmlNodeList LoadConfigFileNodes() {
            string configFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\app.conf";
            XmlDocument xmldoc = new XmlDocument();
            try {
                xmldoc.Load(configFile);
                priveligedUsers = new List<string>();
                return xmldoc.DocumentElement.ChildNodes[0].ChildNodes;
            } catch (Exception ex) {
                FrontendUtils.ShowError("Configuration file not found, default configuration will be loaded", ex);
            }
            return null;
        }

        public List<string> GetPriviligedUsersFromConfigFile(XmlNodeList nodeList) {
            List<string> priveligedUsers = new List<string>();
            for (int i = 0; i < nodeList.Count; i++) {
                if (nodeList[i].NodeType == XmlNodeType.Element && nodeList[i].Attributes["key"] != null) {
                    priveligedUsers.Add(nodeList[i].Attributes["key"].Value);
                }
            }
            return priveligedUsers;
        }

        private void CheckIdleTime() {
            int cpuPct = (int)(ApplicationIdleTimer.CPUUsageThreshold * 100.0);
            ApplicationIdleTimer.ApplicationIdle += new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);
            Application.Idle += new System.EventHandler(this.Idle_Count);
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(this.timer1_Tick);
            // Start the timer
            timer1.Start();
            timer1.Interval = 250;
        }

        #endregion

        #region Events

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
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Form1 form1 = new Form1();
                form1.MdiParent = this;
                form1.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void setupRecommendationsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Recommendation Config started by " + loggedInUser);
                SetupSimpleRecForm setupRecForm = new SetupSimpleRecForm();
                setupRecForm.MdiParent = this;
                setupRecForm.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void configBuilderToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                ConfigBuilder configBuilder = new ConfigBuilder();
                configBuilder.MdiParent = this;
                configBuilder.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void cleanupToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                CleanupForm cleanupForm = new CleanupForm();
                cleanupForm.MdiParent = this;
                cleanupForm.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (!ApplicationIdleTimer.IsIdle && this.tsLabelStatus.Text != "Busy") {
                this.tsLabelStatus.BackColor = Color.LightCoral;
                this.tsLabelStatus.Text = "Busy";
            }
            this.tsAppStatus.Text = idleCounter.ToString("#,##0");
        }

        private void App_Idle(ApplicationIdleTimer.ApplicationIdleEventArgs e) {
            tsLabelStatus.Text = string.Format("Idle: {0}s", e.IdleDuration.TotalSeconds.ToString("0"));
            tsLabelStatus.BackColor = Color.LightCyan;
            if (e.IdleDuration.Minutes > CONFIGURED_IDLE_TIME && !appProcessing) {
                //FrontendUtils.SendUsageNotification(loggedInUser + " was forced to exit by timer!");
                Application.Exit();
            }
        }

        private void Idle_Count(object sender, System.EventArgs e) {
            idleCounter++;
        }

        private void StartCheckIfKickTimer() {
            System.Windows.Forms.Timer checkKickTimer = new System.Windows.Forms.Timer();
            checkKickTimer.Tick += new EventHandler(this.checkKickTimer_Tick);
            // Start the timer
            checkKickTimer.Start();
            checkKickTimer.Interval = 60000;
        }

        private void checkKickTimer_Tick(object sender, EventArgs e) {
            if(UserStatus.IsUserKicked(loggedInUser)) {
                int userId = UserStatus.GetUserIdByUsername(loggedInUser);
                UserStatus.UpdateUserStatusById(userId, false);
                Application.ExitThread();
                Application.Exit();
            }
        }

        private void MainForm_Load(object sender, EventArgs e) {
            try {
                MainAppVariables.AppVersion = APPLICATION_VERSION;
                loggedInUser = FrontendUtils.GetCurrentUser();
                FrontendUtils.CreateLogsDirectory();
                this.Text = this.Text +" v." +APPLICATION_VERSION + " - Welcome " + loggedInUser + "!";
                XmlNodeList configFileNodes = LoadConfigFileNodes();
                SetBackEndConnectionParameter(configFileNodes);
                string applicationVersion = (string)Application_Settings.GetAppConfigValueByKey(Application_Settings.ApplicationConfigKeys.ApplicationVersion);
                GlobalApplicationSettings.ApplicationVersion = APPLICATION_VERSION;
                GlobalApplicationSettings.ApplicationVersionInDB=applicationVersion;
                if (string.Equals(applicationVersion, APPLICATION_VERSION)) {
                    StartCheckIfKickTimer();
                    // || string.Equals(loggedInUser, "mkabbani")) {
                    bool TIMER_ENABLED = Convert.ToBoolean(Application_Settings.GetAppConfigValueByKey(Application_Settings.ApplicationConfigKeys.EnableTimerKey));
                    if (TIMER_ENABLED) {
                        CONFIGURED_IDLE_TIME = Convert.ToInt32(Application_Settings.GetAppConfigValueByKey(Application_Settings.ApplicationConfigKeys.TimerDurationKey));
                        CheckIdleTime();
                    }
                    int userId = UserStatus.GetUserIdByUsername(loggedInUser);
                    if (userId < 1) {
                        userId = UserStatus.InsertNewUser(loggedInUser);
                    }
                    FrontendUtils.LoggedInUserId = userId;
                    UserStatus.UpdateUserStatusById(userId, true);
                    List<string> priviligedUsersList = Application_Settings.GetPriviligedUsersAsList();
                    UpdateUIForPriviligedUsers(priviligedUsersList, loggedInUser);
                    MonitorObject.username = loggedInUser;
                    MonitorObject.loginTime = DateTime.Now;
                    MonitorObject.formAndAccessTime = new List<FormAndAccessTime>();
                    MonitorObject.formAndAccessTime.Add(new FormAndAccessTime(this.Name, DateTime.Now));



                } else {
                    this.menuStrip.Enabled = false;
                    Exception ex = new InvalidAsynchronousStateException("The application is out date. Please update to the latest version!");
                    //http://globalqa/svn/PAR/PFR/0000081/trunk/pfr/QAA-Activities/MaintenanceReduction/Maintenance-Reduction.zip
                    DialogResult dial = FrontendUtils.ShowConformation("A new version is now available on SVN!\nProceed with update?");
                    if (dial == DialogResult.Yes) {
                        Process.Start("http://globalqa/svn/PAR/PFR/0000081/trunk/pfr/QAA-Activities/MaintenanceReduction/Maintenance-Reduction.zip");
                        Application.ExitThread();
                        Application.Exit();
                    } else {
                        FrontendUtils.ShowError(ex.Message, ex);
                        Application.ExitThread();
                        Application.Exit();
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
                try {
                    Bitmap bitmap = FrontendUtils.GetScreenShot();
                    string bitmapFileName = Path.GetTempPath() + DateTime.Now.Date.Day + "-" + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "-" + DateTime.Now.Millisecond + ".jpeg";
                    bitmap.Save(bitmapFileName);
                    FrontendUtils.SendEmailWithAttachement(ex.Message, ex, bitmapFileName);
                } catch (Exception ex1) {

                    throw;
                }
                Application.ExitThread();
                Application.Exit();
            }
        }

        private void macroSplitToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Macro split started by " + loggedInUser);

                BulkMacroSplitterTreeForm form = new BulkMacroSplitterTreeForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void firstLevelCleanupToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("First Level Cleanup started by " + loggedInUser);
                CleanupForm form = new CleanupForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void advancedOperationToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void bulkCustomsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Bulk Customs started by " + loggedInUser);
                BulkCustomsForm form = new BulkCustomsForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void advancedRecToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Setup Advanced Recs started by " + loggedInUser);
                SetupAdvancedRecForm form = new SetupAdvancedRecForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                DatabaseViewer form = new DatabaseViewer();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void form1ToolStripMenuItem_Click_1(object sender, EventArgs e) {
            Form1 form = new Form1();
            form.MdiParent = this;
            form.Show();
        }

        private void rFTUpdaterToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("RFT updater started by " + loggedInUser);
                RftReplacementForm form = new RftReplacementForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            try {

                MonitorObject.logoutTime = DateTime.Now;

                Monitor.InsertNewMonitorObject();
                int userId = UserStatus.GetUserIdByUsername(loggedInUser);
                UserStatus.UpdateUserStatusById(userId, false);
                FrontendUtils.SendUsageNotification(loggedInUser + " has exited the application!");
                Environment.Exit(2);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void testExceptionToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                StreamReader reader = new StreamReader("D:\test.xml");
                reader.ReadToEnd();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
                FrontendUtils.ShowError("wow", null);
                ExceptionForm form = new ExceptionForm("Sample exception!!", ex);
                form.Show();
            }
        }

        private void userStatusToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                UsersStatus form = new UsersStatus();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void nicknameSpecificToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                OracleUpdaterForm form = new OracleUpdaterForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void form2ToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                Form2 form2 = new Form2();
                form2.MdiParent = this;
                form2.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                ApplicationPreferencesForm form = new ApplicationPreferencesForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void remoteServerToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                RemoteServer form = new RemoteServer();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        #endregion

        private void selectFolderNameToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                SelectFolderNameForm form = new SelectFolderNameForm();
                form.MdiParent = this;
                form.Show();

                //form.SelectedString;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void configureFolderNamesToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                ConfigureFolderNamesForm form = new ConfigureFolderNamesForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void secondLevelCleanupToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Second Level Cleanup started by " + loggedInUser);
                SecondLevelCleanupForm form = new SecondLevelCleanupForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void convertToEnumToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                ConvertToEnumForm form = new ConvertToEnumForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void showDetailsFormToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                AdvancedRecomendation obj = new AdvancedRecomendation();
                ShowSearchDetailsForm form = new ShowSearchDetailsForm(obj);
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void testReplacementFOrmToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                testReplacements form = new testReplacements();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void jobPusherToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                PushAutomationJobForm form = new PushAutomationJobForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void envComparisonToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Environment Comparison started by " + loggedInUser);
                EnvironmentComparisonForm form = new EnvironmentComparisonForm();

                bool found = false;
                foreach (Form childForm in this.MdiChildren) {
                    if (childForm is EnvironmentComparisonForm) {
                        found = true;
                    }
                }
                if (!found) {
                    form.MdiParent = this;
                    form.Show();
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void advancedRecommendationsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Setup Advanced Rec started " + loggedInUser);
                SetupAdvancedRecForm form = new SetupAdvancedRecForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void simpleRecommendationsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Recommendation Config started by " + loggedInUser);
                SetupSimpleRecForm setupRecForm = new SetupSimpleRecForm();
                setupRecForm.MdiParent = this;
                setupRecForm.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void envComparisonToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Environment comparison started by " + loggedInUser);
                EnvironmentComparisonForm form = new EnvironmentComparisonForm();
                bool found = false;
                foreach (Form childForm in this.MdiChildren) {
                    if (childForm is EnvironmentComparisonForm) {
                        found = true;
                    }
                }
                if (!found) {
                    form.MdiParent = this;
                    form.Show();
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void fTPToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("FTP downloader started by " + loggedInUser);
                FTPDownloaderForm form = new FTPDownloaderForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void functionParserToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Package Gen started by " + loggedInUser);
                PackageGenerator form = new PackageGenerator();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void packagingToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Package Gen started by " + loggedInUser);
                PackageGenerator form = new PackageGenerator();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void tabsToolStripMenuItem_Click(object sender, EventArgs e) {
            TestingTabs tabs = new TestingTabs();

            tabs.MdiParent = this;
            tabs.Show();
        }

        private void macroConverterToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Macro Converter configuration started by " + loggedInUser);
                MacroConverterConfForm form = new MacroConverterConfForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void macroToTextToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("SDD generator started by " + loggedInUser);
                SDDGeneratorForm form = new SDDGeneratorForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void sDDEventsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Macro Converter configuration started by " + loggedInUser);
                MacroConverterConfForm form = new MacroConverterConfForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void sDDGeneratorToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("SDD generator started by " + loggedInUser);
                SDDGeneratorForm form = new SDDGeneratorForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void mulToolStripMenuItem_Click(object sender, EventArgs e) {
            Multi_TestCaseForm form = new Multi_TestCaseForm();
            form.MdiParent = this;
            form.Show();
        }

        private void findXpathToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FindXpathForm form = new FindXpathForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void newBulkMacrosToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                BulkMacroSplitterTreeForm form = new BulkMacroSplitterTreeForm();
                form.MdiParent = this;
                form.Show();

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

    }
}