using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tamir.SharpSsh;
using FtpLib;
using System.Text.RegularExpressions;
using XmlParsersAndUi.Classes;
using System.IO;
using Tamir.SharpSsh.jsch;
using Automation.Common.Utils;
using Automation.Common;
using Automation.Backend;
using Automation.Common.Classes.Monitoring;
namespace XmlParsersAndUi.Forms {
    public partial class EnvironmentComparisonForm : Form {

        #region Contructor

        public EnvironmentComparisonForm() {
            InitializeComponent();
        }

        #endregion

        #region ComparisonScript

        string ComparisonScript = "#! /usr/bin/env bash\r\n\r\n###################################################\r\n##\r\n## dbouvier Feb 2007\r\n##\r\n## compare the content of two directories\r\n## \r\n###################################################\r\n\r\n# ----------------------------------------------------------------------------\r\n## Activate debug mode\r\n##\r\nif [ \"x${DBODEBUG}\" != \"x\" ] ; then \r\n    set -xv ;\r\nelse\r\n    set +xv ;\r\nfi\r\n\r\n# ----------------------------------------------------------------------------\r\n#  Ecran d'aide\r\n# ----------------------------------------------------------------------------\r\nUsage() \r\n{\r\n    echo \"+----------------------------------------------------------------------------------+\"\r\n    echo \"|                       compare.sh : compare tweo directories                      |\"\r\n    echo \"|                                                                                  |\"\r\n    echo \"| Option                Commentaire                                    Defaut      |\"\r\n    echo \"|==================================================================================|\"\r\n    echo \"|  -H    He;p : Print this screen and exit                               Off       |\"\r\n    echo \"|  -E    Ext  : Look only for files having a certain extension           Off       |\"\r\n    echo \"|  -D    Diff : Compare existing files and look for missing ones         Off       |\"\r\n    echo \"|  -R1   Rep1 : Look for files only present in R1                        Off       |\"\r\n    echo \"|  -R2   Rep2 : Look for files only present in R2                        Off       |\"\r\n    echo \"|  -A    All  : D + R1 + R2                                              On        |\"\r\n    echo \"|  -F    File : Generates diff files (potentialy dumps lots of files)    Off       |\"\r\n    echo \"+----------------------------------------------------------------------------------+\"\r\n    return 0\r\n}\r\n\r\n# ----------------------------------------------------------------------------\r\n#  Test des arguments\r\n# ----------------------------------------------------------------------------\r\nTestArg() {\r\nwhile [ $# -ne 0 ]\r\ndo\r\n OPTION=$1\r\n\r\n case $OPTION in\r\n\r\n  -h|-H)        \r\n\t\tUsage\r\n                exit 0;;\r\n\r\n  -ROOT)\r\n\t\tshift\r\n\t\t_ROOT=$1\r\n\t\tshift;;\r\n  -E|EXT)\r\n\t\tshift\r\n\t\t_EXT_LST=$1\r\n\t\tshift;;\r\n\r\n  -MOT)\r\n\t\tshift\r\n\t\t_MOT_LST=$1\r\n\t\tshift;;\r\n\r\n  *)            echo \"[ERROR] Pos: Mauvais parametre: '$OPTION'\"\r\n                Usage\r\n                exit 1;;\r\n esac \r\ndone\r\n}\r\n\r\n# ----------------------------------------------------------------------------\r\n# Dir to be compared\r\n# We extract absolute path to account deep levels of relative paths.\r\nexport _DIR1=$(cd $1 && pwd)\r\nexport _DIR2=$(cd $2 && pwd)\r\n\r\n# Content of each dir\r\nexport _TMP_FILE=\"/tmp/diff.txt\"\r\nexport _TMP_FILE1=\"/tmp/dir1.txt\"\r\nexport _TMP_FILE2=\"/tmp/dir2.txt\"\r\n\r\nif [ \"x${_EXT_LST}\" = \"x\" ] ; then\r\n\tfind $_DIR1 > $_TMP_FILE1\r\n\tfind $_DIR2 > $_TMP_FILE2\r\nelse\r\n\tfind $_DIR1 -name \"*.${_EXT_LST}\" > $_TMP_FILE1\r\n\tfind $_DIR2 -name \"*.${_EXT_LST}\" > $_TMP_FILE2\r\nfi\r\n\r\n_sep=\"--------------------------------------------------------------------\"\r\n# ----------------------------------------------------------------------------\r\n# Log\r\n# ----------------------------------------------------------------------------\r\nexport _RAPPORT=\"./Diff.log\"\r\necho ${_sep} > $_RAPPORT\r\necho \"Compare $_DIR1 and $_DIR2\" >> $_RAPPORT\r\necho ${_sep} >> $_RAPPORT\r\necho \"\" >> $_RAPPORT\r\n\r\n\r\n# ----------------------------------------------------------------------------\r\n# Check for files present in Dir1 but not in Dir2\r\n# ----------------------------------------------------------------------------\r\necho \"Files present ONLY in $_DIR1\" >> $_RAPPORT\r\necho ${_sep} >> $_RAPPORT\r\nfor i in `cat $_TMP_FILE1`\r\ndo\r\n\r\n  if [ -f $i ] ; then\r\n      file=${i#$_DIR1/}\r\n      filePath=`echo $i | sed -e 's|/|/|g'`\r\n\r\n      # file is missing in Dir2\r\n      if [ ! -f $_DIR2/$file ] ; then\r\n\t  echo \"$filePath\">> $_RAPPORT\r\n      fi  \r\n  fi\r\ndone\r\necho \"\" >> $_RAPPORT\r\necho \"\" >> $_RAPPORT\r\n\r\n# ----------------------------------------------------------------------------\r\n# Check for files present in Dir2 but not in Dir1\r\n# ----------------------------------------------------------------------------\r\necho \"Files present ONLY in $_DIR2\" >> $_RAPPORT\r\necho ${_sep} >> $_RAPPORT\r\nfor i in `cat $_TMP_FILE2`\r\ndo\r\n\r\n  if [ -f $i ] ; then\r\n      file=${i#$_DIR2/}\r\n      filePath=`echo $i | sed -e 's|/|/|g'`\r\n\r\n      # file is missing in Dir1\r\n      if [ ! -f $_DIR1/$file ] ; then\r\n\t  echo \"$filePath\">> $_RAPPORT\r\n      fi  \r\n  fi\r\ndone\r\necho \"\" >> $_RAPPORT\r\necho \"\" >> $_RAPPORT\r\n\r\n# ----------------------------------------------------------------------------\r\n# For each file in Dir 1 make a diff with the same file in Dir 2\r\n# If the later does not exist, log it is missing\r\n# ----------------------------------------------------------------------------\r\necho \"Files different between $_DIR1 and $_DIR2\" >> $_RAPPORT\r\necho ${_sep} >> $_RAPPORT\r\nfor i in `cat $_TMP_FILE1`\r\ndo\r\n\r\n  if [ -f $i ] ; then\r\n      file=${i#$_DIR1/}\r\n      filePath=`echo $i | sed -e 's|/|/|g'`\r\n\r\n      # file is present in both dirs, make a diff\r\n      if [ -f $_DIR2/$file ] ; then\r\n\t  dif=`diff $_DIR1/$file $_DIR2/$file > ${_TMP_FILE}`\r\n\r\n    # No need to perform sed if _TMP_FILE is zero length.\r\n    if [ -s ${_TMP_FILE} ]; then\r\n\t      filePath=`echo $i | sed -e 's|/|/|g'`\r\n\t      #echo $i \r\n\t      echo \"$_DIR1/$file\" >> $_RAPPORT\r\n\t      cp -p ${_TMP_FILE} ./diff.$filePath.txt\r\n\t  fi\r\n      fi\r\n  fi\r\ndone\r\n\r\n###############################################################\r\nprintRep()\r\n{\r\n    cat $_RAPPORT\r\n}\r\n\r\n\r\n\r\n\r\n###############################################################\r\nexport _D1=\"N\"\r\n\r\nprintRep\r\n";

        #endregion

        #region Comparsion Config Tab

        #region Variables

        bool WorkerWasCancelled = false;
        string compareScriptLocation = "/dell014srv1/automation/automation-Jobs/Comparison/";
        DataTable SAVED_SEARCH_RESULTS;
        DataTable SearchSafeResults;
        int Total_Number_Diffs = 0;
        bool LOCAL_TA_USAGE;
        #endregion

        #region Methods

        private string GetFileTypeFromExtension(string fileName) {
            string fileType = string.Empty;
            string fileExtention = string.Empty;
            if (Path.HasExtension(fileName)) {
                fileExtention = Path.GetExtension(fileName);
            }

            switch (fileExtention.ToLower()) {
            case ".sh":
                fileType = "Script";
                break;
            case ".pl":
                fileType = "Perl";
                break;
            case ".pm":
                fileType = "Perl";
                break;
            case ".mxres":
                fileType = "Config";
                break;
            case ".so":
                fileType = "Library";
                break;
            case ".binary":
                fileType = "Binary";
                break;
            case ".xdb":
                fileType = "Report";
                break;
            case ".xml":
                fileType = "XML";
                break;
            case ".directory":
                fileType = "Directory";
                break;
            case ".xsl":
                fileType = "XSL";
                break;
            case ".csv":
                fileType = "CSV";
                break;
            case ".txt":
                fileType = "Text";
                break;
            case ".jar":
                fileType = "JAR";
                break;
            case ".sql":
                fileType = "SQL";
                break;
            case ".logs":
                fileType = "Logs";
                break;
            case ".log":
                fileType = "Logs";
                break;
            case ".gz":
                fileType = "Archive";
                break;
            case ".properties":
                fileType = "Properties file";
                break;
            case ".props":
                fileType = "Properties file";
                break;
            case ".cmd":
                fileType = "Command";
                break;
            case ".html":
                fileType = "Hypertext Markup Language";
                break;
            case ".bat":
                fileType = "Batch file";
                break;
            case ".cfg":
                fileType = "Configuration file";
                break;
            default:
                fileType = fileExtention.ToUpper().Trim(new char[] { '.' });
                break;
            }
            return fileType;
        }

        private bool IsValidToBeginDiff(string inputEnv, string inputHost, string refEnv, string refHost, string compareScriptLocation, string scriptHost) {


            FtpConnection connection;
            #region RefEnvValidation

            connection = new FtpConnection(refHost, "mxftp", "mxftp");


            try {
                try {
                    connection.Open();
                    // bgDoServerWork.ReportProgress(5, "Validating Results...");
                } catch (Exception ex) {
                    FrontendUtils.ShowError(ex.Message, ex);
                    return false;
                }
                connection.Login();
                if (!connection.DirectoryExists(refEnv)) {
                    FrontendUtils.ShowInformation("The reference environment path is incorrect!",true);
                    return false;
                }
                if (!connection.FileExists(refEnv + "/mxg2000_settings.sh")) {
                    FrontendUtils.ShowInformation("The reference environment path is incorrect!", true);
                    return false;
                }
                if (connection.FileExists(refEnv + "/clean.log")) {
                    FrontendUtils.ShowInformation("The reference environment is cleaned!", true);
                    return false;
                }
            } finally {
                connection.Close();
                connection.Dispose();
            }

            #endregion


            #region inputEnvValidations
            connection = new FtpConnection(inputHost, "mxftp", "mxftp");


            try {
                try {
                    connection.Open();
                    // bgDoServerWork.ReportProgress(5, "Validating Results...");
                } catch (Exception ex) {
                    FrontendUtils.ShowError(ex.Message, ex);
                    return false;
                }
                connection.Login();
                if (!connection.DirectoryExists(inputEnv)) {
                    FrontendUtils.ShowInformation("The input environment path is incorrect!",true);
                    return false;
                }

                if (!connection.FileExists(inputEnv + "/mxg2000_settings.sh")) {
                    FrontendUtils.ShowInformation("The input environment path is incorrect!", true);
                    return false;
                }
                if (connection.FileExists(inputEnv + "/clean.log")) {
                    FrontendUtils.ShowInformation("The input environment is cleaned!", true);
                    return false;
                }
            } finally {
                connection.Close();
                connection.Dispose();
            }
            #endregion

            #region ComparisonHostValidation

            connection = new FtpConnection(scriptHost, "mxftp", "mxftp");


            try {
                try {
                    connection.Open();
                    // bgDoServerWork.ReportProgress(5, "Validating Results...");

                } catch (Exception ex) {
                    FrontendUtils.ShowError(ex.Message, ex);
                    return false;
                }
                connection.Login();
                if (!connection.DirectoryExists(compareScriptLocation)) {
                    FrontendUtils.ShowInformation("Could not connect to master host!", true);
                    return false;
                }
                if (!connection.FileExists(compareScriptLocation + "/comparison.sh")) {
                    //testing
                }
            } finally {
                connection.Close();
                connection.Dispose();
            }


            #endregion

            return true;
        }

        private void StartComparison(string inputEnv, string inputHost, string refEnv, string refHost, string compareScriptLocation, out DataTable resultsTable) {
            resultsTable = new DataTable();
            string scriptHost = "dell014srv";
            bgDoServerWork.ReportProgress(5, "Validating environments...");
            if (LOCAL_TA_USAGE || IsValidToBeginDiff(inputEnv, inputHost, refEnv, refHost, compareScriptLocation, scriptHost)) {
                bgDoServerWork.ReportProgress(5, "Connecting to Hosts...");
                if (bgDoServerWork.CancellationPending) {
                    WorkerWasCancelled = true;
                    return;
                }

                //CopyComparisonScript(refHost, refEnv);
                SshStream ssh = new SshStream(scriptHost, "autoengine", "");
                //Set the end of response matcher character
                string response = string.Empty;
                try {
                    ssh.Prompt = "\\$";
                    //Remove terminal emulation characters
                    ssh.RemoveTerminalEmulationCharacters = true;
                    //Writing to the SSH channel
                    //tmReturn.Start();
                    //Remove terminal emulation characters
                    ssh.RemoveTerminalEmulationCharacters = true;
                    //Writing to the SSH channel
                    ssh.Write("cd " + compareScriptLocation);
                    //Reading from the SSH channel
                    response = ssh.ReadResponse();
                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                }
                string comparisonFolderName = DateTime.Now.Ticks.ToString();
                string comparisonFileName = comparisonFolderName + "comparison.log";

                if (bgDoServerWork.CancellationPending) {
                    WorkerWasCancelled = true;
                    return;
                }
                //ssh.Write("cp comparison.sh " + "/net/" + refHost + refEnv + " /net/" + inputHost + inputEnv + " -A >" + comparisonFileName);

                try {
                    ssh.Write("mkdir " + comparisonFolderName);
                    response = ssh.ReadResponse();

                    ssh.Write("cp comparison88.sh " + comparisonFolderName);
                    response = ssh.ReadResponse();

                    ssh.Write("cd " + comparisonFolderName);
                    //Reading from the SSH channel
                    response = ssh.ReadResponse();

                    ssh.Write("comparison88.sh " + "/net/" + refHost + refEnv + " /net/" + inputHost + inputEnv + " -A >" + comparisonFileName);
                    bgDoServerWork.ReportProgress(5, "Starting Comparison...");
                    response = ssh.ReadResponse();
                    ssh.Write("d");
                    response = ssh.ReadResponse();

                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                }

                bgDoServerWork.ReportProgress(5, "Comparison Completed");
                if (bgDoServerWork.CancellationPending) {
                    WorkerWasCancelled = true;
                    return;
                }

                FtpConnection connection = new FtpConnection(scriptHost, "mxftp", "mxftp");

                string localFileName = Path.GetTempFileName();
                try {
                    try {
                        try {
                            connection.Open();
                            bgDoServerWork.ReportProgress(5, "Validating Results...");
                        } catch (Exception ex) {
                            FrontendUtils.ShowError(ex.Message, ex);
                        }
                        connection.Login();
                        connection.SetCurrentDirectory(compareScriptLocation + comparisonFolderName);
                        //Path.GetTempFileName
                        connection.GetFile(comparisonFileName, localFileName, false);
                        connection.RemoveFile(comparisonFileName);
                        connection.SetCurrentDirectory(compareScriptLocation);
                        bgDoServerWork.ReportProgress(5, "Building Output...");
                    } finally {
                        connection.Close();
                        connection.Dispose();
                    }
                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                }

                try {
                    ssh.Write("cd ..");
                    //Reading from the SSH channel
                    response = ssh.ReadResponse();

                    ssh.Write("rm -rf " + comparisonFolderName);
                    //Reading from the SSH channel
                    response = ssh.ReadResponse();

                    ssh.Flush();
                    ssh.Close();
                    ssh.Dispose();
                    if (bgDoServerWork.CancellationPending) {
                        WorkerWasCancelled = true;
                        return;
                    }

                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                }
                try {
                    string readFile = FrontendUtils.ReadFile(localFileName);
                    //      Regex regex = new Regex("-.*-");
                    string[] array = new string[1];
                    //  array[0]= regex.Match(readFile).Value;
                    array[0] = "\n\n";
                    string[] splitFile = readFile.Split(array, StringSplitOptions.RemoveEmptyEntries);
                    int counter = 1;
                    bgDoServerWork.ReportProgress(5, "Displaying Results...");
                    Regex diffRegex = new Regex("diff.*");
                    DataTable results = new DataTable();
                    results.Columns.Add("Number");
                    results.Columns.Add("Operation");
                    results.Columns.Add("FileSize");
                    results.Columns.Add("FileModifyDate");
                    results.Columns.Add("FileType");
                    results.Columns.Add("FileName");

                    List<string> monthAbbreviations = new List<string>() { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
                    };

                    for (int j = 2; j < splitFile.Length; j++) {
                        string[] splitByLines = splitFile[j].Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int k = 3; k < splitByLines.Length; k++) {
                            //-rw-rw-r--   1 autoengine murex       1201 Jul 10 16:58 test.txt
                            //-rwxrwxr-x   1 autoengine murex        546 May 10  2008 script.sh*
                            // "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", and "Dec"
                            if (j == 2) {
                                string fileName = splitByLines[k].Replace("/net/" + refHost + refEnv, "").Replace("/net/" + inputHost + inputEnv, "");
                                string[] splitFileName = fileName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                if (diffRegex.Matches(fileName).Count == 0) {
                                    DateTime date;
                                    try {
                                        if (splitFileName[7].Contains(":")) {
                                            date = new DateTime(DateTime.Now.Year, monthAbbreviations.IndexOf(splitFileName[5]), Convert.ToInt32(splitFileName[6]), Convert.ToInt32(splitFileName[7].Split(new char[] { ':' })[0]), Convert.ToInt32(splitFileName[7].Split(new char[] { ':' })[1]), 0);
                                        } else {
                                            date = new DateTime(Convert.ToInt32(splitFileName[7]), monthAbbreviations.IndexOf(splitFileName[5]), Convert.ToInt32(splitFileName[6]));
                                        }
                                    } catch (Exception ex) {
                                        FrontendUtils.LogError("Could not get Date", ex);
                                        date = DateTime.Now;
                                    }


                                    long fileSize = (Convert.ToInt64(splitFileName[4]) / 1024) == 0 ? 1 : (Convert.ToInt64(splitFileName[4]) / 1024);

                                    results.Rows.Add(new object[] { counter, "Added", fileSize, date.ToString(), GetFileTypeFromExtension(splitFileName[8]), splitFileName[8] });

                                }
                            } else {
                                string fileName = splitByLines[k].Replace("/net/" + refHost + refEnv, "").Replace("/net/" + inputHost + inputEnv, "");
                                string[] splitFileName = fileName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                                if (diffRegex.Matches(fileName).Count == 0) {
                                    DateTime date;

                                    try {
                                        if (splitFileName[7].Contains(":")) {
                                            date = new DateTime(DateTime.Now.Year, monthAbbreviations.IndexOf(splitFileName[5]), Convert.ToInt32(splitFileName[6]), Convert.ToInt32(splitFileName[7].Split(new char[] { ':' })[0]), Convert.ToInt32(splitFileName[7].Split(new char[] { ':' })[1]), 0);
                                        } else {
                                            date = new DateTime(Convert.ToInt32(splitFileName[7]), monthAbbreviations.IndexOf(splitFileName[5]), Convert.ToInt32(splitFileName[6]));
                                        }
                                    } catch (Exception ex) {
                                        FrontendUtils.LogError("Could not get Date", ex);
                                        date = DateTime.Now;
                                    }
                                    long fileSize = (Convert.ToInt64(splitFileName[4]) / 1024) == 0 ? 1 : (Convert.ToInt64(splitFileName[4]) / 1024);

                                    results.Rows.Add(new object[] { counter, "Modified", fileSize, date.ToString(), GetFileTypeFromExtension(splitFileName[8]), splitFileName[8] });
                                }
                            }
                            counter++;
                        }
                    }

                    SAVED_SEARCH_RESULTS = results.Copy();
                    GOLDEN_ORIGINAL_RESTULS = results.Copy();
                    resultsTable = SAVED_SEARCH_RESULTS;
                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                }
            } else {
                bgDoServerWork.CancelAsync();
                WorkerWasCancelled = true;
            }
        }


        private void ParseComparisonResults(string localFileName,string inputEnv, string inputHost, string refEnv, string refHost, out DataTable resultsTable) {

            string readFile = FrontendUtils.ReadFile(localFileName);
            //      Regex regex = new Regex("-.*-");
            string[] array = new string[1];
            //  array[0]= regex.Match(readFile).Value;
            array[0] = "\n\n";
            string[] splitFile = readFile.Split(array, StringSplitOptions.RemoveEmptyEntries);
            int counter = 1;
            bgDoServerWork.ReportProgress(5, "Displaying Results...");
            Regex diffRegex = new Regex("diff.*");
            DataTable results = new DataTable();
            results.Columns.Add("Number");
            results.Columns.Add("Operation");
            results.Columns.Add("FileSize");
            results.Columns.Add("FileModifyDate");
            results.Columns.Add("FileType");
            results.Columns.Add("FileName");

            List<string> monthAbbreviations = new List<string>() { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            };

            for (int j = 2; j < splitFile.Length; j++) {
                string[] splitByLines = splitFile[j].Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
                for (int k = 3; k < splitByLines.Length; k++) {
                    //-rw-rw-r--   1 autoengine murex       1201 Jul 10 16:58 test.txt
                    //-rwxrwxr-x   1 autoengine murex        546 May 10  2008 script.sh*
                    // "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", and "Dec"
                    if (j == 2) {
                        string fileName = splitByLines[k].Replace("/net/" + refHost + refEnv, "").Replace("/net/" + inputHost + inputEnv, "");
                        string[] splitFileName = fileName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (diffRegex.Matches(fileName).Count == 0) {
                            DateTime date;
                            try {
                                if (splitFileName[7].Contains(":")) {
                                    date = new DateTime(DateTime.Now.Year, monthAbbreviations.IndexOf(splitFileName[5]), Convert.ToInt32(splitFileName[6]), Convert.ToInt32(splitFileName[7].Split(new char[] { ':' })[0]), Convert.ToInt32(splitFileName[7].Split(new char[] { ':' })[1]), 0);
                                } else {
                                    date = new DateTime(Convert.ToInt32(splitFileName[7]), monthAbbreviations.IndexOf(splitFileName[5]), Convert.ToInt32(splitFileName[6]));
                                }
                            } catch (Exception ex) {
                                FrontendUtils.LogError("Could not get Date", ex);
                                date = DateTime.Now;
                            }


                            long fileSize = (Convert.ToInt64(splitFileName[4]) / 1024) == 0 ? 1 : (Convert.ToInt64(splitFileName[4]) / 1024);

                            results.Rows.Add(new object[] { counter, "Added", fileSize, date.ToString(), GetFileTypeFromExtension(splitFileName[8]), splitFileName[8] });

                        }
                    } else {
                        string fileName = splitByLines[k].Replace("/net/" + refHost + refEnv, "").Replace("/net/" + inputHost + inputEnv, "");
                        string[] splitFileName = fileName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                        if (diffRegex.Matches(fileName).Count == 0) {
                            DateTime date;

                            try {
                                if (splitFileName[7].Contains(":")) {
                                    date = new DateTime(DateTime.Now.Year, monthAbbreviations.IndexOf(splitFileName[5]), Convert.ToInt32(splitFileName[6]), Convert.ToInt32(splitFileName[7].Split(new char[] { ':' })[0]), Convert.ToInt32(splitFileName[7].Split(new char[] { ':' })[1]), 0);
                                } else {
                                    date = new DateTime(Convert.ToInt32(splitFileName[7]), monthAbbreviations.IndexOf(splitFileName[5]), Convert.ToInt32(splitFileName[6]));
                                }
                            } catch (Exception ex) {
                                FrontendUtils.LogError("Could not get Date", ex);
                                date = DateTime.Now;
                            }
                            long fileSize = (Convert.ToInt64(splitFileName[4]) / 1024) == 0 ? 1 : (Convert.ToInt64(splitFileName[4]) / 1024);

                            results.Rows.Add(new object[] { counter, "Modified", fileSize, date.ToString(), GetFileTypeFromExtension(splitFileName[8]), splitFileName[8] });
                        }
                    }
                    counter++;
                }
            }

            SAVED_SEARCH_RESULTS = results.Copy();
            GOLDEN_ORIGINAL_RESTULS = results.Copy();
            resultsTable = SAVED_SEARCH_RESULTS;

        }

        private string CopyComparisonScript(string refHost, string refEnv) {
            string remoteScriptName = string.Empty;
            FtpConnection connection = new FtpConnection(refHost, "mxftp", "mxftp");
            string localFileName = Path.GetTempFileName();
            FrontendUtils.WriteFile(localFileName, ComparisonScript);
            try {
                try {
                    connection.Open();
                    //bgDoServerWork.ReportProgress(5, "Validating Results...");
                } catch (Exception ex) {
                    FrontendUtils.ShowError(ex.Message, ex);
                }
                connection.Login();
                connection.SetCurrentDirectory(refEnv);
                //Path.GetTempFileName
                remoteScriptName = Path.GetFileName(localFileName);
                connection.PutFile(localFileName);
                connection.RenameFile(remoteScriptName, Path.GetFileNameWithoutExtension(remoteScriptName) + ".sh");
                //connection.SendCommand("chmod 777 " + Path.GetFileNameWithoutExtension(remoteScriptName) + ".sh");
                remoteScriptName = Path.GetFileNameWithoutExtension(remoteScriptName) + ".sh";
            } finally {
                connection.Close();
                connection.Dispose();
            }
            return remoteScriptName;
        }

        private bool IsValidToStartComparison(string inputEnv, string inputHost, string refEnv, string refHost) {
            if (string.IsNullOrEmpty(inputEnv)) {
                FrontendUtils.ShowInformation("Input Environment cannot be empty!", true);
                return false;
            } else if (string.IsNullOrEmpty(inputHost)) {
                FrontendUtils.ShowInformation("Input Host cannot be empty!", true);
                return false;
            } else if (string.IsNullOrEmpty(refEnv)) {
                FrontendUtils.ShowInformation("Reference Environment cannot be empty!", true);
                return false;
            } else if (string.IsNullOrEmpty(refHost)) {
                FrontendUtils.ShowInformation("Reference Host cannot be empty!", true);
                return false;
            }
            return true;
        }

        private void LoadAllAvailableFiltersToCheckListBox() {
            clbAvailableFilters.Items.Clear();
            DataSet AllFilters = Env_Comparison_Filters.GetAllAvailableFiltersAsDataset();
            foreach (DataRow row in AllFilters.Tables[0].Rows) {
                EnvComparisonFilter filter =
                    new EnvComparisonFilter(Convert.ToInt32(row["id"]),
                                            row["name"].ToString(),
                                            row["description"].ToString(),
                                            row["filter"].ToString(),
                                            Convert.ToInt32(row["filterType"]),
                                            Convert.ToInt32(row["userid"]));
                clbAvailableFilters.Items.Add(filter);
            }
        }



        private DataTable CopyDataGridToDataTable(DataGridView dgvResults) {
            DataTable gridValues = new DataTable("Original Diff Result");
            gridValues.Columns.Add("#");
            gridValues.Columns.Add("Operation");
            gridValues.Columns.Add("File Size");
            gridValues.Columns.Add("Modify Date");
            gridValues.Columns.Add("File Type");
            gridValues.Columns.Add("File Path");
            foreach (DataGridViewRow row in dgvResults.Rows) {
                //# Operation filePath
                if (row.Visible) {
                    object[] values = new object[] { row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value };
                    gridValues.Rows.Add(values);
                }

            }
            return gridValues;
        }

        private void ApplySelectedFiltersToSearchResults(List<EnvComparisonFilter> selectedFilters) {
            // DataTable workingTable = CopyDataGridToDataTable(dgvResults);

            DataTable workingTable = SAVED_SEARCH_RESULTS.Copy();
            DataTable resultTable = SAVED_SEARCH_RESULTS.Copy();
            resultTable.Rows.Clear();
            foreach (EnvComparisonFilter filter in selectedFilters) {
                Regex regex = new Regex(filter.FilterPattern);
                int availableRows = workingTable.Rows.Count;
                resultTable.Rows.Clear();
                foreach (DataRow row in workingTable.Rows) {
                    if (regex.Matches(row.ItemArray[5].ToString()).Count == 0) {
                        resultTable.Rows.Add(row.ItemArray);
                    }
                }
                workingTable = resultTable.Copy();
            }
            FillDataGridFromDataTable(resultTable);
            lblTotalFiles.Text = "Remaining files: " + resultTable.Rows.Count + "/" + Total_Number_Diffs + "\nSize: " + GetTotalFilesSize(resultTable) + " KB";
        }

        private List<EnvComparisonFilter> GetSelectedFilters(CheckedListBox clbAvailableFilters) {
            List<EnvComparisonFilter> selectedFilters = new List<EnvComparisonFilter>();
            for (int i = 0; i < clbAvailableFilters.CheckedItems.Count; i++) {
                selectedFilters.Add(clbAvailableFilters.CheckedItems[i] as EnvComparisonFilter);
            }
            return selectedFilters;
        }

        private void ResetConfigTextBoxes(Control.ControlCollection controlCollection) {
            for (int i = 0; i < controlCollection.Count; i++) {
                if (controlCollection[i] is TextBox) {
                    (controlCollection[i] as TextBox).Clear();
                }
            }
        }

        //private void ApplyCustomSearchFilter(string customFilter) {
        //    DataTable workingTable = CopyDataGridToDataTable(dgvResults);
        //    Regex regex = new Regex(customFilter, RegexOptions.Compiled);
        //    int availableRows = workingTable.Rows.Count;
        //    for (int i = 0; i < availableRows; i++) {
        //        if (regex.IsMatch(workingTable.Rows[i].ItemArray[2].ToString())) {
        //            workingTable.Rows[i].Delete();
        //        }
        //    }
        //    FillDataGridFromDataTable(workingTable);
        //    lblTotalFiles.Text = "Remaining files: " + workingTable.Rows.Count + "/" + Total_Number_Diffs;
        //}

        private void FillDataGridFromDataTable(DataTable DataTable) {
            dgvResults.Rows.Clear();


            dgvResults.Columns.Clear();
            dgvResults.Columns.Add("#", "#");
            dgvResults.Columns.Add("Operation", "Operation");
            dgvResults.Columns.Add("FileSize", "File Size (KB)");
            dgvResults.Columns.Add("FileModifyDate", "Modify Date");
            dgvResults.Columns.Add("fileType", "File Type");
            dgvResults.Columns.Add("FilePath", "File Path");
            dgvResults.Columns[0].ReadOnly = true;
            dgvResults.Columns[1].ReadOnly = true;
            dgvResults.Columns[2].ReadOnly = true;
            dgvResults.Columns[3].ReadOnly = true;
            dgvResults.Columns[4].ReadOnly = true;
            dgvResults.Columns[5].ReadOnly = true;


            dgvResults.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
            dgvResults.Columns[0].FillWeight = 30;
            dgvResults.Columns[0].Width = 40;

            dgvResults.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResults.Columns[1].FillWeight = 50;
            dgvResults.Columns[1].Width = 80;

            dgvResults.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResults.Columns[2].FillWeight = 60;
            dgvResults.Columns[2].Width = 96;

            dgvResults.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResults.Columns[3].FillWeight = 60;
            dgvResults.Columns[3].Width = 96;

            dgvResults.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResults.Columns[4].FillWeight = 60;
            dgvResults.Columns[4].Width = 96;

            dgvResults.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvResults.Columns[5].FillWeight = 260;

            for (int i = 0; i < DataTable.Rows.Count; i++) {
                int rowIndex = dgvResults.Rows.Add();
                dgvResults.Rows[rowIndex].ContextMenuStrip = dgvContextMenu;
                dgvResults.Rows[rowIndex].Cells[0].Value = DataTable.Rows[i].ItemArray[0];
                dgvResults.Rows[rowIndex].Cells[1].Value = DataTable.Rows[i].ItemArray[1];
                dgvResults.Rows[rowIndex].Cells[2].Value = DataTable.Rows[i].ItemArray[2];
                dgvResults.Rows[rowIndex].Cells[3].Value = DataTable.Rows[i].ItemArray[3];
                dgvResults.Rows[rowIndex].Cells[4].Value = DataTable.Rows[i].ItemArray[4];
                dgvResults.Rows[rowIndex].Cells[5].Value = DataTable.Rows[i].ItemArray[5];
            }
        }

        #endregion

        #region Events

        private void btnResetGrid_Click(object sender, EventArgs e) {
            try {
                dgvResults.Columns.Clear();
                dgvResults.Rows.Clear();
                //dgvResults.DataSource = SAVED_SEARCH_RESULTS;
                SAVED_SEARCH_RESULTS = GOLDEN_ORIGINAL_RESTULS.Copy();
                FillDataGridFromDataTable(GOLDEN_ORIGINAL_RESTULS);
                lblTotalFiles.Text = "Remaining files: " + GOLDEN_ORIGINAL_RESTULS.Rows.Count + "/" + Total_Number_Diffs + "\nSize: " + GetTotalFilesSize(GOLDEN_ORIGINAL_RESTULS) + " KB";

                // dgvResults.Columns[0].Width = 40;
                dgvResults.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.NotSet;
                dgvResults.Columns[0].FillWeight = 30;
                dgvResults.Columns[0].Width = 40;

                dgvResults.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvResults.Columns[1].FillWeight = 50;
                dgvResults.Columns[1].Width = 80;

                dgvResults.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvResults.Columns[2].FillWeight = 60;
                dgvResults.Columns[2].Width = 96;

                dgvResults.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvResults.Columns[3].FillWeight = 60;
                dgvResults.Columns[3].Width = 96;

                dgvResults.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvResults.Columns[4].FillWeight = 60;
                dgvResults.Columns[4].Width = 96;

                dgvResults.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvResults.Columns[5].FillWeight = 260;

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnApplyFilters_Click(object sender, EventArgs e) {
            try {

                List<EnvComparisonFilter> selectedFilters = GetSelectedFilters(clbAvailableFilters);
                if (selectedFilters.Count != 0) {
                    ApplySelectedFiltersToSearchResults(selectedFilters);
                } else {
                    FillDataGridFromDataTable(GOLDEN_ORIGINAL_RESTULS);
                    lblTotalFiles.Text = "Remaining files: " + GOLDEN_ORIGINAL_RESTULS.Rows.Count + "/" + GOLDEN_ORIGINAL_RESTULS.Rows.Count + "\nSize: " + GetTotalFilesSize(GOLDEN_ORIGINAL_RESTULS) + " KB";
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            try {
                if (bgDoServerWork.IsBusy) {
                    bgDoServerWork.CancelAsync();
                    bgDoServerWork.Dispose();
                }
                dgvResults.Rows.Clear();
                btnStart.Enabled = true;

                #region Config Reset
                txtRefEnv.Clear();
                txtRefHost.Clear();
                lblReferenceVersionBid.Visible = false;

                txtInputEnv.Clear();
                txtInpHost.Clear();
                lblInputVersionBid.Visible = false;

                btnStart.Enabled = false;

                #endregion

                //ResetConfigTextBoxes(gbConfiguration.Controls);
                gbFilters.Visible = false;
                gbResultsGrid.Visible = false;
                SAVED_SEARCH_RESULTS = new DataTable();
                pcProgress.Visible = false;
                //txtCustomFilter.Clear();
                gbCustomFilters.Visible = false;
                lblProgess.Text = "";
                lblTotalFiles.Text = "Remaining files:\nSize:";
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void ExportToExcel(string fileName, DataTable ItemsPresentInGrid, DataTable GOLDEN_ORIGINAL_RESTULS, int maxNumberOfRows) {
            DataSet set = new DataSet();
            ItemsPresentInGrid.TableName = "Filtered Results";
            set.Tables.Add(ItemsPresentInGrid.Copy());

            if (GOLDEN_ORIGINAL_RESTULS.Rows.Count > maxNumberOfRows) {
                DataTable splitTable = GetDataTable("Original Results-0", new List<string> { "#", "Operation", "File Size", "Modify Date", "File Type", "File Path" });
                int counter = 1;
                int restableCounter = 1;
                for (int i = 0; i < GOLDEN_ORIGINAL_RESTULS.Rows.Count; i++) {
                    if (restableCounter == maxNumberOfRows || (restableCounter < maxNumberOfRows && (i == GOLDEN_ORIGINAL_RESTULS.Rows.Count - 1))) {
                        set.Tables.Add(splitTable);
                        splitTable = GetDataTable("Original Results-" + counter, new List<string> { "#", "Operation", "File Size", "Modify Date", "File Type", "File Path" });
                        restableCounter = 0;
                        counter++;
                    }
                    splitTable.Rows.Add(GOLDEN_ORIGINAL_RESTULS.Rows[i].ItemArray);
                    restableCounter++;
                }
            } else {
                DataTable goldenCopy = GOLDEN_ORIGINAL_RESTULS.Copy();
                goldenCopy.TableName = "Original Results";
                set.Tables.Add(goldenCopy);
            }
            FastExportingMethod.ExportToExcel(set, fileName);
        }

        private DataTable GetDataTable(string tableName, List<string> columnNames) {
            DataTable dataTable = new DataTable(tableName);
            for (int i = 0; i < columnNames.Count; i++) {
                dataTable.Columns.Add(columnNames[i]);
            }
            return dataTable;
        }


        private DataTable CopyDataGridToDataTableForExport(DataGridView dgvResults) {
            DataTable gridValues = new DataTable("Original Diff Result");
            gridValues.Columns.Add("FolderGroup");
            gridValues.Columns.Add("SubFolderGroup");

            gridValues.Columns.Add("#");
            gridValues.Columns.Add("Operation");
            gridValues.Columns.Add("File Size");
            gridValues.Columns.Add("Modify Date");
            gridValues.Columns.Add("File Type");
            gridValues.Columns.Add("File Path");
            foreach (DataGridViewRow row in dgvResults.Rows) {
                //# Operation filePath
                if (row.Visible) {
                    object[] values = new object[] { null,null,row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value, row.Cells[4].Value, row.Cells[5].Value };
                    gridValues.Rows.Add(values);
                }

            }
            return gridValues;
        }

        private void btnExportGrid_Click(object sender, EventArgs e) {
            SaveUpdatedTreeView();
            try {
                DataTable ItemsPresentInGrid = CopyDataGridToDataTableForExport(dgvResults);
                DialogResult dialog = FrontendUtils.ShowConformation("Do you want to apply the folder grouping feature?");
                if (dialog == DialogResult.Yes) {
                    //ItemsPresentInGrid.Columns.Add("FolderGroup");
                    //ItemsPresentInGrid.Columns.Add("SubFolderGroup");
                    for (int i = 0; i < ItemsPresentInGrid.Rows.Count; i++) {
                        for (int j = 0; j < allTreeNodes.Count; j++) {
                            if (allTreeNodes[j].Level == 0) {
                                if (ItemsPresentInGrid.Rows[i].ItemArray[7].ToString().StartsWith(allTreeNodes[j].comparisonCategory.categoryPath)) {
                                    object[] objs = new object[8];
                                    ItemsPresentInGrid.Rows[i].ItemArray.CopyTo(objs, 0);
                                    objs[0] = allTreeNodes[j].comparisonCategory.categoryName;
                                    ItemsPresentInGrid.Rows[i].ItemArray = objs;
                                }
                            } else if (allTreeNodes[j].Level == 1) {
                                if (ItemsPresentInGrid.Rows[i].ItemArray[7].ToString().StartsWith(allTreeNodes[j].comparisonCategory.categoryPath)) {
                                    object[] objs = new object[8];
                                    ItemsPresentInGrid.Rows[i].ItemArray.CopyTo(objs, 0);
                                    objs[1] = allTreeNodes[j].comparisonCategory.categoryName;
                                    ItemsPresentInGrid.Rows[i].ItemArray = objs;
                                }
                            }
                        }
                    }
                }

                int maxNumberOfRows = 64000;
                if (dgvResults.Rows.Count < maxNumberOfRows) {
                    SaveFileDialog dial = new SaveFileDialog();
                    dial.AddExtension = true;
                    dial.DefaultExt = ".xls";
                    dial.Filter = "Excel Files (*.xls)|*.xls";
                    if (dial.ShowDialog() == DialogResult.OK) {
                        ExportDatagridWorkerObject exportDatagridWorkerObject = new ExportDatagridWorkerObject(dial.FileName, ItemsPresentInGrid, GOLDEN_ORIGINAL_RESTULS, maxNumberOfRows);
                        btnExportGrid.Enabled = false;
                        //pcExport
                        //pcProgress.Visible = true;
                        //pcProgress.Rotate = true;
                        gbResultsGrid.Enabled = false;
                        bgwExportToExcel.RunWorkerAsync(exportDatagridWorkerObject);
                    }
                }
                #region old Export Code
                //if (dgvResults.Rows.Count < maxNumberOfRows) {
                //    SaveFileDialog dial = new SaveFileDialog();
                //    dial.AddExtension = true;
                //    dial.DefaultExt = ".xls";
                //    dial.Filter = "Excel Files (*.xls)|*.xls";
                //    if (dial.ShowDialog() == DialogResult.OK) {
                //        DataSet set = new DataSet();
                //        set.Tables.Add("Filtered Results");
                //        set.Tables[0].Columns.Add("#");
                //        set.Tables[0].Columns.Add("Operation");
                //        set.Tables[0].Columns.Add("File Type");
                //        set.Tables[0].Columns.Add("File Path");
                //        foreach (DataGridViewRow row in dgvResults.Rows) {
                //            //# Opration filePath
                //            if (row.Visible) {
                //                object[] values = new object[] { row.Cells[0].Value, row.Cells[1].Value, row.Cells[2].Value, row.Cells[3].Value };
                //                set.Tables[0].Rows.Add(values);
                //            }
                //        }
                //        if (GOLDEN_ORIGINAL_RESTULS.Rows.Count < maxNumberOfRows) {
                //            set.Tables.Add(GOLDEN_ORIGINAL_RESTULS.Copy());
                //        } else {
                //            DataTable splitTable = new DataTable("Original Results-0");

                //            splitTable.Columns.Add("#");
                //            splitTable.Columns.Add("Operation");
                //            splitTable.Columns.Add("File Type");
                //            splitTable.Columns.Add("File Path");

                //            DataTable temp = GOLDEN_ORIGINAL_RESTULS.Copy();
                //            //temp.Columns.Add("#");
                //            //temp.Columns.Add("Operation");
                //            //temp.Columns.Add("File Type");
                //            //temp.Columns.Add("File Path");



                //            //int startIndex = 0;
                //            int counter = 1;
                //            int restableCounter = 1;
                //            for (int i = 0; i < GOLDEN_ORIGINAL_RESTULS.Rows.Count; i++) {
                //                if (restableCounter == maxNumberOfRows || (restableCounter < maxNumberOfRows && (i == GOLDEN_ORIGINAL_RESTULS.Rows.Count - 1))) {
                //                    set.Tables.Add(splitTable);
                //                    splitTable = new DataTable("Original Results-" + counter);
                //                    splitTable.Columns.Add("#");
                //                    splitTable.Columns.Add("Operation");
                //                    splitTable.Columns.Add("File Type");
                //                    splitTable.Columns.Add("File Path");
                //                    restableCounter = 0;
                //                    counter++;
                //                }
                //                splitTable.Rows.Add(GOLDEN_ORIGINAL_RESTULS.Rows[i].ItemArray);
                //                restableCounter++;
                //            }
                //        }

                //        FastExportingMethod.ExportToExcel(set, dial.FileName);
                //    }
                //}
                #endregion
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private List<ComparisonCategoryTreeNode> GetLevelOneNodeList() {
            List<ComparisonCategoryTreeNode> comparisonCats = new List<ComparisonCategoryTreeNode>();
            for (int i = 0; i < tvResultsCategories.Nodes.Count; i++) {
                comparisonCats.Add(tvResultsCategories.Nodes[i] as ComparisonCategoryTreeNode);
            }
            return comparisonCats;
        }

        public static string WildcardToRegex(string pattern) {
            return "^" + Regex.Escape(pattern).
                   Replace("\\*", ".*").
                   Replace("\\?", ".") + "$";
        }

        DataTable GOLDEN_ORIGINAL_RESTULS = new DataTable();

        private void btnApplyCustomFilter_Click(object sender, EventArgs e) {
            try {
                SAVED_SEARCH_RESULTS = CopyDataGridToDataTable(dgvResults);
                List<EnvComparisonFilter> filters = new List<EnvComparisonFilter>();
                EnvComparisonFilter filter = new EnvComparisonFilter(0, "customFilter", "oneUsage", WildcardToRegex(cboCustomFilter.Text.Trim()), 0, 0);
                filters.Add(filter);
                ApplySelectedFiltersToSearchResults(filters);
                //ApplyCustomSearchFilter(txtCustomFilter.Text.Trim());
                cboCustomFilter.Items.Add(cboCustomFilter.Text);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnStart_Click(object sender, EventArgs e) {
            try {
                if (IsValidToStartComparison(txtInputEnv.Text.Trim(), txtInpHost.Text.Trim(), txtRefEnv.Text.Trim(), txtRefHost.Text.Trim())) {
                    EnvComparatorWorker envComparatorWorker = new EnvComparatorWorker(txtRefHost.Text.Trim(), txtRefEnv.Text.Trim(), txtInpHost.Text.Trim(), txtInputEnv.Text.Trim());
                    btnStart.Enabled = false;
                    pcProgress.Visible = true;
                    pcProgress.Rotate = true;
                    bgDoServerWork.RunWorkerAsync(envComparatorWorker);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void txtRefEnv_TextChanged(object sender, EventArgs e) {
            try {
                string remoteLocation = txtRefEnv.Text.Trim();
                if (string.IsNullOrEmpty(remoteLocation)) {
                    return;
                }
                string[] splitter = new string[] { @"/" };
                string[] remoteLocationSplit = remoteLocation.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                remoteLocation = Regex.Match(remoteLocationSplit[0], @"[a-zA-Z]+[0-9]+[a-zA-Z]+|[a-zA-Z]+", RegexOptions.Compiled).Value;
                txtRefHost.Text = remoteLocation;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void txtInputEnv_TextChanged(object sender, EventArgs e) {
            try {
                string remoteLocation = txtInputEnv.Text.Trim();
                if (string.IsNullOrEmpty(remoteLocation)) {
                    return;
                }
                string[] splitter = new string[] { @"/" };
                string[] remoteLocationSplit = remoteLocation.Split(splitter, StringSplitOptions.RemoveEmptyEntries);
                remoteLocation = Regex.Match(remoteLocationSplit[0], @"[a-zA-Z]+[0-9]+[a-zA-Z]+|[a-zA-Z]+", RegexOptions.Compiled).Value;
                txtInpHost.Text = remoteLocation;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void bgDoServerWork_DoWork(object sender, DoWorkEventArgs e) {
            try {
                IO.isCompleted = false;
                EnvComparatorWorker envComparatorWorker = e.Argument as EnvComparatorWorker;
                DataTable resultsTable = new DataTable();
                StartComparison(envComparatorWorker.localInputPath, envComparatorWorker.localInputHost, envComparatorWorker.localRefPath, envComparatorWorker.localRefHost, compareScriptLocation, out resultsTable);
                IO.isCompleted = true;
                e.Result = resultsTable;
                if (bgDoServerWork.CancellationPending) {
                    e.Cancel = true;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void bgDoServerWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            try {
                if (!WorkerWasCancelled) {
                    DataTable resultsTable = e.Result as DataTable;
                    FillDataGridFromDataTable(resultsTable);
                    lblProgess.Visible = false;
                    pcProgress.Visible = false;
                    pcProgress.Rotate = false;
                    gbResultsGrid.Visible = true;
                    gbFilters.Enabled = true;
                    gbFilters.Visible = true;
                    gbCustomFilters.Visible = true;
                    LoadAllAvailableFiltersToCheckListBox();
                    //SearchSafeResults = CopyDataGridToDataTable(dgvResults);
                    Total_Number_Diffs = SAVED_SEARCH_RESULTS.Rows.Count;
                    lblTotalFiles.Text = "Remaining files: " + SAVED_SEARCH_RESULTS.Rows.Count + "/" + Total_Number_Diffs + "\nSize: " + GetTotalFilesSize(SAVED_SEARCH_RESULTS) + " KB";
                    List<EnvComparisonFilter> preFilters = GetPrefilterList(clbAvailableFilters);

                    if (preFilters.Count > 0) {
                        string collectedPrefilters = GetFormattedPrefiltersForDisplay(preFilters);
                        DialogResult dialog = FrontendUtils.ShowConformation("Comparsion completed!\nAuto cleanup the following types?\n\n" + collectedPrefilters);
                        if (dialog == DialogResult.Yes) {
                            ApplySelectedFiltersToSearchResults(preFilters);
                        } else {
                            for (int i = 0; i < clbAvailableFilters.Items.Count; i++) {
                                clbAvailableFilters.SetItemCheckState(i, CheckState.Unchecked);
                            }
                        }
                    }
                } else {
                    btnStart.Enabled = true;
                    pcProgress.Visible = false;
                    pcProgress.Rotate = false;
                    lblProgess.Text = "";
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private int GetTotalFilesSize(DataTable SAVED_SEARCH_RESULTS) {
            int totalSize = 0;
            foreach (DataRow row in SAVED_SEARCH_RESULTS.Rows) {
                totalSize = totalSize + Convert.ToInt32(row.ItemArray[2]);
            }
            return totalSize;
        }

        private string GetFormattedPrefiltersForDisplay(List<EnvComparisonFilter> preFilters) {
            string formattedPreFilters = string.Empty;
            for (int i = 0; i < preFilters.Count; i++) {
                formattedPreFilters = formattedPreFilters + "  - " + preFilters[i].Name + " [" + preFilters[i].FilterPattern + "]\n";
            }
            return formattedPreFilters;
        }

        private List<EnvComparisonFilter> GetPrefilterList(CheckedListBox clbAvailableFilters) {
            List<EnvComparisonFilter> prefilters = new List<EnvComparisonFilter>();
            for (int i = 0; i < clbAvailableFilters.Items.Count; i++) {
                EnvComparisonFilter filter = clbAvailableFilters.Items[i] as EnvComparisonFilter;
                if (filter.FilterType == (int)EnvComparisonFilter.ComparisonFilterType.PreFilter) {
                    //prefilters = prefilters + "-" + filter.localName + " [" + filter.localFilterPattern + "]\n";
                    prefilters.Add(filter);
                    clbAvailableFilters.SetItemChecked(i, true);
                }
            }
            return prefilters;
        }

        private void RemoveDiffFilesFromResults(string filter) {
            List<EnvComparisonFilter> filters = new List<EnvComparisonFilter>();
            EnvComparisonFilter filterObject = new EnvComparisonFilter(0, "customFilter", "oneUsage", filter, 0, 0);
            filters.Add(filterObject);
            ApplySelectedFiltersToSearchResults(filters);
        }

        private void bgDoServerWork_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            try {
                lblProgess.Visible = true;
                lblProgess.Text = e.UserState.ToString();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnReloadFilters_Click(object sender, EventArgs e) {
            try {
                LoadAllAvailableFiltersToCheckListBox();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }


        #endregion

        #endregion

        #region FilterConfiguration

        #region Methods

        private void ReloadAllFiltersFromDatabase() {
            lbFilters.Items.Clear();
            lvAvailableFilters.Items.Clear();
            DataSet dataSet = Env_Comparison_Filters.GetAllAvailableFiltersAsDataset();
            foreach (DataRow row in dataSet.Tables[0].Rows) {
                EnvComparisonFilter filter =
                    new EnvComparisonFilter(Convert.ToInt32(row["id"]),
                                            row["name"].ToString(),
                                            row["description"].ToString(),
                                            row["filter"].ToString(),
                                            Convert.ToInt32(row["filterType"]),
                                            Convert.ToInt32(row["userid"]),
                                            string.Equals(row["userid"].ToString(),1),
                                            row["filterScript"].ToString(),
                                            row["exclusionList"].ToString());



                switch (Convert.ToInt32(row["filterType"])) {

                case (int)EnvComparisonFilter.ComparisonFilterType.Regular:
                    System.Windows.Forms.ListViewItem item = lvAvailableFilters.Items.Add(filter.Name,filter.Name);
                    item.Group =  lvAvailableFilters.Groups["lvgRegularGroup"];
                    item.Tag = filter;
                    break;
                case (int)EnvComparisonFilter.ComparisonFilterType.PreFilter:
                    item = lvAvailableFilters.Items.Add(filter.Name,filter.Name);
                    item.Group =  lvAvailableFilters.Groups["lvgPrefilter"];
                    item.Tag = filter;
                    break;
                case (int)EnvComparisonFilter.ComparisonFilterType.Deletion:
                    item = lvAvailableFilters.Items.Add(filter.Name,filter.Name);
                    item.Group =  lvAvailableFilters.Groups["lvgDeletionFilter"];
                    item.Tag = filter;
                    break;
                default:
                    break;
                }

                lbFilters.Items.Add(filter);
            }
        }

        private void ResetForm() {
            txtFilterName.Clear();
            txtFilterDescription.Clear();
            txtFilterPattern.Clear();
            lbFilters.ClearSelected();
            btnAddFilter.Enabled = true;
            btnSaveFilter.Enabled = false;
            txtExclusionList.Clear();
            txtGeneratedScript.Clear();
            if(cboFilterType.Items.Count>0) {
                cboFilterType.SelectedIndex = 0;
            }
        }

        private bool IsValidToAddFilter(string name, string description, string pattern) {
            if (string.IsNullOrEmpty(name)) {
                FrontendUtils.ShowInformation("Name field cannot be empty!", true);
                return false;
            } else if (string.IsNullOrEmpty(description)) {
                FrontendUtils.ShowInformation("Description field cannot be empty!", true);
                return false;
            } else if (string.IsNullOrEmpty(pattern)) {
                FrontendUtils.ShowInformation("Pattern field cannot be empty!", true);
                return false;
            }
            bool found = false;
            for (int i = 0; i < lbFilters.Items.Count && !found; i++) {
                if (string.Equals(lbFilters.Items.ToString(), name)) {
                    found = true;
                }
            }
            if (found) {
                FrontendUtils.ShowInformation("Filter name must be unique!", true);
                return false;
            }
            return true;
        }

        private bool IsValidToSaveFilter(int filterId, string name, string description, string pattern) {
            if (filterId < 1) {
                return false;
            } else if (string.IsNullOrEmpty(name)) {
                FrontendUtils.ShowInformation("Name field cannot be empty!", true);
                return false;
            } else if (string.IsNullOrEmpty(description)) {
                FrontendUtils.ShowInformation("Description field cannot be empty!", true);
                return false;
            } else if (string.IsNullOrEmpty(pattern)) {
                FrontendUtils.ShowInformation("Pattern field cannot be empty!", true);
                return false;
            }
            bool found = false;
            for (int i = 0; i < lbFilters.Items.Count && !found; i++) {
                if (string.Equals(lbFilters.Items[i].ToString(), name)) {
                    if ((lbFilters.SelectedItem as EnvComparisonFilter).filterId != (lbFilters.Items[i] as EnvComparisonFilter).filterId) {
                        found = true;
                    }
                }
            }
            if (found) {
                FrontendUtils.ShowInformation("Filter name must be unique!", true);
                return false;
            }
            return true;
        }

        private void FillUiFromSelectedFilter(EnvComparisonFilter selectedFilter) {
            txtFilterName.Text = selectedFilter.Name;
            txtFilterDescription.Text = selectedFilter.Description;
            txtFilterPattern.Text = selectedFilter.FilterPattern;
            btnAddFilter.Enabled = false;
            btnSaveFilter.Enabled = true;
            cboFilterType.SelectedIndex = selectedFilter.FilterType;
            if (selectedFilter.FilterType == (int)EnvComparisonFilter.ComparisonFilterType.Deletion) {
                cboRemoveFileOrFolder.SelectedIndex = selectedFilter.IsFolderDeletion ? 1 : 0;
                txtGeneratedScript.Text = GetGeneratedScript(selectedFilter.FilterPattern,selectedFilter.IsFolderDeletion);
                txtExclusionList.Text = selectedFilter.ExclusionList;
            }
        }

        private string GetGeneratedScript(string filterPattern, bool isFolderDeletion) {
            string generatedScript = string.Empty;
            if (isFolderDeletion) {
                generatedScript = "rm -rf "+filterPattern;
            } else {
                generatedScript = "rm "+filterPattern;
            }

            return generatedScript;
        }

        #endregion

        #region Events

        private void EnvironmentComparisonForm_FormClosing(object sender, FormClosingEventArgs e) {
            bgDoServerWork.CancelAsync();
            bgDoServerWork.Dispose();
            pcProgress.Dispose();
            pcProgress = new Utezduyar.Windows.Forms.ProgressCircle();
        }

        private void btnAddFilter_Click(object sender, EventArgs e) {
            try {
                string name = txtFilterName.Text.Trim();
                string description = txtFilterDescription.Text.Trim();
                string pattern = txtFilterPattern.Text.Trim();
                if (IsValidToAddFilter(name, description, pattern)) {
                    if (cboFilterType.SelectedIndex == (int)EnvComparisonFilter.ComparisonFilterType.Deletion) {
                        //deletionMode
                        //cboRemoveFileOrFolder.SelectedIndex=0 ==> file
                        //cboRemoveFileOrFolder.SelectedIndex=1 ==> folder
                        EnvComparisonFilter filter = new EnvComparisonFilter(-1, name, description, pattern, cboFilterType.SelectedIndex, FrontendUtils.LoggedInUserId, cboRemoveFileOrFolder.SelectedIndex==1, txtGeneratedScript.Text,txtExclusionList.Text);
                        int filterId = Env_Comparison_Filters.InserNewFilter(filter);
                        ResetForm();
                        ReloadAllFiltersFromDatabase();
                        FrontendUtils.ShowInformation("Deletion Filter ["+txtFilterName.Text+"] has beed added.",false);
                    } else {
                        //all other modes
                        EnvComparisonFilter filter = new EnvComparisonFilter(-1, name, description, pattern, cboFilterType.SelectedIndex, FrontendUtils.LoggedInUserId);
                        int filterId = Env_Comparison_Filters.InserNewFilter(filter);
                        ResetForm();
                        ReloadAllFiltersFromDatabase();
                        FrontendUtils.ShowInformation("Filter ["+txtFilterName.Text+"] has beed added.",false);
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnResetFilter_Click(object sender, EventArgs e) {
            try {
                ResetForm();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnReload_Click(object sender, EventArgs e) {
            try {
                ResetForm();
                ReloadAllFiltersFromDatabase();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void tcComparisonTabs_SelectedIndexChanged(object sender, EventArgs e) {
            try {

                //tcComparisonTabs.SelectedIndex = 0 ==> cleanup
                //tcComparisonTabs.SelectedIndex = 1 ==> comparison
                //tcComparisonTabs.SelectedIndex = 2 ==> configuration
                if (tcComparisonTabs.SelectedIndex == 1) {
                    ResetForm();
                    cboFilterType.DataSource = Enum.GetValues(typeof(EnvComparisonFilter.ComparisonFilterType));



                    ReloadAllFiltersFromDatabase();
                }

                if (tcComparisonTabs.SelectedIndex == 0) {

                    PopulateCleanupFilters();
                }

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void PopulateCleanupFilters() {
            clbAvailableCleanupFilters.Items.Clear();
            DataSet dataSet = Env_Comparison_Filters.GetAllAvailableFiltersAsDataset();
            foreach (DataRow row in dataSet.Tables[0].Rows) {
                EnvComparisonFilter filter =
                    new EnvComparisonFilter(Convert.ToInt32(row["id"]),
                                            row["name"].ToString(),
                                            row["description"].ToString(),
                                            row["filter"].ToString(),
                                            Convert.ToInt32(row["filterType"]),
                                            Convert.ToInt32(row["userid"]),
                                            string.Equals(row["userid"].ToString(),1),
                                            row["filterScript"].ToString(),
                                            row["exclusionList"].ToString());


                if (Convert.ToInt32(row["filterType"]) == (int)EnvComparisonFilter.ComparisonFilterType.Deletion) {
                    clbAvailableCleanupFilters.Items.Add(filter,true);
                }
            }

        }

        private void btnSaveFilter_Click(object sender, EventArgs e) {
            try {


                if (lvAvailableFilters.SelectedItems.Count > 0) {
                    EnvComparisonFilter envComparisonFilter = (lvAvailableFilters.SelectedItems[0].Tag as EnvComparisonFilter);

                    if (envComparisonFilter !=null) {
                        int filterId = envComparisonFilter.filterId;
                        string name = txtFilterName.Text.Trim();
                        string description = txtFilterDescription.Text.Trim();
                        string pattern = txtFilterPattern.Text.Trim();
                        if (IsValidToSaveFilter(filterId, name, description, pattern)) {

                            EnvComparisonFilter filter = new EnvComparisonFilter(filterId, name, description, pattern, (int)cboFilterType.SelectedItem, FrontendUtils.LoggedInUserId);

                            if (cboFilterType.SelectedIndex == (int)EnvComparisonFilter.ComparisonFilterType.Deletion) {
                                filter.IsFolderDeletion = cboRemoveFileOrFolder.SelectedIndex == 1;
                                filter.FilterScript = txtGeneratedScript.Text;
                                filter.ExclusionList = txtExclusionList.Text;
                            }
                            Env_Comparison_Filters.UpdatedFilterById(filter);
                            ReloadAllFiltersFromDatabase();
                        }
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void lbFilters_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                EnvComparisonFilter selectedFilter = lbFilters.SelectedItem as EnvComparisonFilter;
                if (selectedFilter != null) {
                    FillUiFromSelectedFilter(selectedFilter);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        #endregion

        private void EnvironmentComparisonForm_Load(object sender, EventArgs e) {
            if (!string.IsNullOrEmpty(MonitorObject.username)) {
                MonitorObject.formAndAccessTime.Add(new FormAndAccessTime(this.Name, DateTime.Now));
            }
            LOCAL_TA_USAGE = string.Equals(Application_Settings.GetAppConfigValueByKey(Application_Settings.ApplicationConfigKeys.EnvComparisonOnlyForEnv).ToString(), "True") ? true : false;
            LoadSavedFolderNames();
            PopulateCleanupFilters();
        }

        #endregion

        private void dgvResults_KeyPress(object sender, KeyPressEventArgs e) {
            try {
                //ctrl + find
                if ((int)e.KeyChar == 6) {
                    FindForm form = new FindForm(dgvResults);
                    //form.Parent = this;
                    form.Show();
                }
                //ctrl+z
                if ((int)e.KeyChar == 26) {
                    if (rowIndexSaved.Count > 0) {
                        for (int i = 0; i < rowIndexSaved.Count; i++) {
                            dgvResults.Rows[rowIndexSaved[i]].Visible = true;
                        }
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        bool checkedState = false;

        private void btnSelectAll_Click(object sender, EventArgs e) {
            try {
                for (int i = 0; i < clbAvailableFilters.Items.Count; i++) {
                    clbAvailableFilters.SetItemChecked(i, !checkedState);
                }
                checkedState = !checkedState;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        List<int> rowIndexSaved = new List<int>();

        int manuallyDeletedCount = 0;

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                rowIndexSaved = new List<int>();
                if (dgvResults.SelectedRows != null) {
                    for (int i = 0; i < dgvResults.SelectedRows.Count; i++) {
                        dgvResults.SelectedRows[i].Visible = false;
                        rowIndexSaved.Add(dgvResults.SelectedRows[i].Index);
                    }
                    manuallyDeletedCount = manuallyDeletedCount + rowIndexSaved.Count;
                    // check bug here
                    lblTotalFiles.Text = "Remaining files: " + (dgvResults.Rows.Count - manuallyDeletedCount) + "/" + Total_Number_Diffs + "\nSize: " + GetTotalFilesSize(CopyDataGridToDataTable(dgvResults)) + " KB";
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void undoLastDeleteToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                if (rowIndexSaved.Count > 0) {
                    for (int i = 0; i < rowIndexSaved.Count; i++) {
                        dgvResults.Rows[rowIndexSaved[i]].Visible = true;
                    }
                    manuallyDeletedCount = manuallyDeletedCount - rowIndexSaved.Count;
                    lblTotalFiles.Text = "Remaining files: " + (dgvResults.Rows.Count - manuallyDeletedCount) + "/" + Total_Number_Diffs + "\nSize: " + GetTotalFilesSize(CopyDataGridToDataTable(dgvResults)) + " KB";
                }
                rowIndexSaved = new List<int>();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnValidateVersion_Click(object sender, EventArgs e) {
            try {
                btnValidateVersion.Enabled = false;
                //pcProgress.Visible = true;
                //pcProgress.Rotate = true;
                //lblProgess.Text = "Validating...";
                Regex versionAndBuildIDRegex = new Regex("MX.*?(\\d+.\\d+.\\S+).*?(\\d+-\\d+-\\d+-\\d+)");
                string refReadFile = GetVersionFile(txtRefEnv.Text, txtRefHost.Text);
                string inpVersionFile = GetVersionFile(txtInputEnv.Text, txtInpHost.Text);

                if (string.IsNullOrEmpty(refReadFile) || string.IsNullOrEmpty(inpVersionFile)) {
                    FrontendUtils.ShowInformation("Could not validate versions!",true);
                    btnStart.Enabled = true;
                    btnValidateVersion.Enabled = true;
                    return;
                }

                string refBuildId = string.Empty;
                string inputBuildId = string.Empty;

                if (versionAndBuildIDRegex.Match(refReadFile).Groups.Count > 1) {
                    lblReferenceVersionBid.Text = "Version: " + versionAndBuildIDRegex.Match(refReadFile).Groups[1].Value + " @ " + versionAndBuildIDRegex.Match(refReadFile).Groups[2].Value;
                    lblReferenceVersionBid.Visible = true;
                    refBuildId = versionAndBuildIDRegex.Match(refReadFile).Groups[2].Value.Split('-')[0];
                }

                if (versionAndBuildIDRegex.Match(inpVersionFile).Groups.Count > 1) {
                    lblInputVersionBid.Text = "Version: " + versionAndBuildIDRegex.Match(inpVersionFile).Groups[1].Value + " @ " + versionAndBuildIDRegex.Match(inpVersionFile).Groups[2].Value;
                    lblInputVersionBid.Visible = true;
                    inputBuildId = versionAndBuildIDRegex.Match(inpVersionFile).Groups[2].Value.Split('-')[0];
                }

                //label coloring
                if (!string.Equals(refBuildId, inputBuildId)) {
                    lblInputVersionBid.ForeColor = Color.LimeGreen;
                    lblReferenceVersionBid.ForeColor = Color.LightCoral;
                    FrontendUtils.ShowInformation("The reference environment build id is not identical to the build id of the customized environment",true);

                } else {
                    //equal builds
                    lblInputVersionBid.ForeColor = Color.LightGreen;
                    lblReferenceVersionBid.ForeColor = Color.LightGreen;
                }

                //btnValidateVersion.Enabled = true;
                //pcProgress.Visible = false;
                //pcProgress.Rotate = false;
                //lblProgess.Text = string.Empty;
                btnStart.Enabled = true;
                btnValidateVersion.Enabled = true;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private string GetVersionFile(string appDirectory, string host) {
            string readFile = string.Empty;
            FtpConnection connection = new FtpConnection(host, "mxftp", "mxftp");
            string localFileName = Path.GetTempFileName();
            try {
                try {
                    try {
                        connection.Open();
                        //bgDoServerWork.ReportProgress(5, "Validating Results...");
                    } catch (Exception ex) {
                        FrontendUtils.ShowError(ex.Message, ex);
                    }
                    connection.Login();
                    connection.SetCurrentDirectory(appDirectory + "/logs");
                    //Path.GetTempFileName
                    connection.GetFile("mxversion.log", localFileName, false);
                } finally {
                    connection.Close();
                    connection.Dispose();
                }
                readFile = FrontendUtils.ReadFile(localFileName);
            } catch (Exception ex) {
                //   FrontendUtils.ShowInformation("Could not validate environment version \n["+appDirectory+"]");
                FrontendUtils.LogError(ex.Message, ex);
            }
            return readFile;
        }

        private void bgwExportToExcel_DoWork(object sender, DoWorkEventArgs e) {
            ExportDatagridWorkerObject exportDatagridWorkerObject = e.Argument as ExportDatagridWorkerObject;
            ExportToExcel(exportDatagridWorkerObject.localFileName, exportDatagridWorkerObject.localItemsPresentInGrid, exportDatagridWorkerObject.localGOLDEN_ORIGINAL_RESTULS, exportDatagridWorkerObject.localMaxNumberOfRows);
        }

        private void bgwExportToExcel_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            try {
                bgwExportToExcel.CancelAsync();
                bgwExportToExcel.Dispose();
                btnExportGrid.Enabled = true;
                //pcProgress.Visible = false;
                //pcProgress.Rotate = false;
                gbResultsGrid.Enabled = true;
                FrontendUtils.ShowInformation("Export completed!",false);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void addChildToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                ComparisonCategoryTreeNode comparisonCategoryTreeNode = tvResultsCategories.SelectedNode as ComparisonCategoryTreeNode;
                if (comparisonCategoryTreeNode.Level < 1) {
                    EnvComparisonCategoryForm form = new EnvComparisonCategoryForm();
                    DialogResult dial = form.ShowDialog();
                    if (dial == DialogResult.Yes) {
                        ComparisonCategory cat = form.workingCompCategory;
                        if (cat.categoryId == 0) {
                            //add button was pressed
                            //add button was pressed
                            ComparisonCategoryTreeNode childComparisonCategoryTreeNode = new ComparisonCategoryTreeNode(cat.categoryName);
                            childComparisonCategoryTreeNode.comparisonCategory = new ComparisonCategory(cat.categoryName, cat.categoryDescription, cat.categoryPath);
                            comparisonCategoryTreeNode.Nodes.Add(childComparisonCategoryTreeNode);
                        } else {
                            // save button was pressed
                        }
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void addRootNodeToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                // ComparisonCategoryTreeNode comparisonCategoryTreeNode = tvResultsCategories.SelectedNode as ComparisonCategoryTreeNode;
                EnvComparisonCategoryForm form = new EnvComparisonCategoryForm();
                DialogResult dial = form.ShowDialog();
                if (dial == DialogResult.Yes) {
                    ComparisonCategory cat = form.workingCompCategory;
                    if (cat.categoryId == 0) {
                        //add button was pressed
                        ComparisonCategoryTreeNode comparisonCategoryTreeNode = new ComparisonCategoryTreeNode(cat.categoryName);


                        comparisonCategoryTreeNode.comparisonCategory = new ComparisonCategory(cat.categoryName, cat.categoryDescription, cat.categoryPath);
                        tvResultsCategories.Nodes.Add(comparisonCategoryTreeNode);
                    } else {
                        // save button was pressed

                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void editNodeToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                ComparisonCategoryTreeNode comparisonCategoryTreeNode = tvResultsCategories.SelectedNode as ComparisonCategoryTreeNode;

                EnvComparisonCategoryForm form = new EnvComparisonCategoryForm(comparisonCategoryTreeNode.comparisonCategory);
                DialogResult dial = form.ShowDialog();
                if (dial == DialogResult.Yes) {
                    ComparisonCategory cat = form.workingCompCategory;
                    comparisonCategoryTreeNode.comparisonCategory = cat;
                    comparisonCategoryTreeNode.Text = cat.categoryName;
                }

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void tvResultsCategories_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            try {
                ComparisonCategoryTreeNode comparisonCategoryTreeNode = tvResultsCategories.SelectedNode as ComparisonCategoryTreeNode;

                EnvComparisonCategoryForm form = new EnvComparisonCategoryForm(comparisonCategoryTreeNode.comparisonCategory);
                DialogResult dial = form.ShowDialog();
                if (dial == DialogResult.Yes) {
                    ComparisonCategory cat = form.workingCompCategory;
                    comparisonCategoryTreeNode.comparisonCategory = cat;
                    comparisonCategoryTreeNode.Text = cat.categoryName;
                }

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        List<ComparisonCategoryTreeNode> allTreeNodes = new List<ComparisonCategoryTreeNode>();

        private void SaveUpdatedTreeView() {
            allTreeNodes = new List<ComparisonCategoryTreeNode>();
            LoopOverAllTreeNodes();

            Env_Comparison_Categories.UpdateEnvComparisonCategoriesTransaction(allTreeNodes);
        }

        private void LoopOverAllTreeNodes() {
            foreach (ComparisonCategoryTreeNode treeNode in tvResultsCategories.Nodes) {
                allTreeNodes.Add(treeNode);
                ParseAllChildren(treeNode);
            }
        }

        private void ParseAllChildren(ComparisonCategoryTreeNode treeNode) {
            foreach (ComparisonCategoryTreeNode childNode in treeNode.Nodes) {
                allTreeNodes.Add(childNode);
                if (childNode.Nodes.Count > 0) {
                    ParseAllChildren(childNode);
                }
            }
        }

        private void btnSaveCategories_Click(object sender, EventArgs e) {
            try {
                SaveUpdatedTreeView();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void RecursivelyPopulate(DataRow dbRow, ComparisonCategoryTreeNode node) {
            foreach (DataRow childRow in dbRow.GetChildRows("NodeRelation")) {
                ComparisonCategoryTreeNode childNode = CreateNode(childRow, true);
                node.Nodes.Add(childNode);
                RecursivelyPopulate(childRow, childNode);
            }
        }

        private void LoadSavedFolderNames() {
            DataSet dataSet = Env_Comparison_Categories.GetAllAvailableEnvCompCategsAsDataset();
            dataSet.Relations.Add("NodeRelation", dataSet.Tables[0].Columns["id"], dataSet.Tables[0].Columns["parentId"]);
            foreach (DataRow dataRow in dataSet.Tables[0].Rows) {
                if (dataRow.IsNull("parentId")) {
                    ComparisonCategoryTreeNode node = CreateNode(dataRow, true);
                    tvResultsCategories.Nodes.Add(node);
                    RecursivelyPopulate(dataRow, node);
                }
            }
            tvResultsCategories.ExpandAll();
        }

        private ComparisonCategoryTreeNode CreateNode(DataRow dataRow, bool p) {
            ComparisonCategoryTreeNode node = new ComparisonCategoryTreeNode(dataRow["name"].ToString());
            node.comparisonCategory = new ComparisonCategory(Convert.ToInt32(dataRow["id"]),
                    dataRow["name"].ToString(),
                    dataRow["description"].ToString(),
                    dataRow["path"].ToString(),
                    dataRow["parentId"] == DBNull.Value ? -1 : Convert.ToInt32(dataRow["parentId"]));
            return node;
        }

        private void deleteToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                ComparisonCategoryTreeNode comparisonCategoryTreeNode = tvResultsCategories.SelectedNode as ComparisonCategoryTreeNode;
                if (comparisonCategoryTreeNode.Nodes.Count > 0) {
                    foreach (ComparisonCategoryTreeNode node in comparisonCategoryTreeNode.Nodes) {
                        tvResultsCategories.Nodes.Remove(node);
                        Env_Comparison_Categories.DeleteEnvComparisonCategoryById(node.comparisonCategory.categoryId);
                    }
                }
                tvResultsCategories.Nodes.Remove(comparisonCategoryTreeNode);
                Env_Comparison_Categories.DeleteEnvComparisonCategoryById(comparisonCategoryTreeNode.comparisonCategory.categoryId);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnStartFromFile_Click(object sender, EventArgs e) {
            try {
                DataTable resultsTable = new DataTable();
                ParseComparisonResults(@"D:\comparison file\tmp8FE.tmp", txtInputEnv.Text, txtInpHost.Text, txtRefEnv.Text, txtRefHost.Text, out resultsTable);



                FillDataGridFromDataTable(resultsTable);
                lblProgess.Visible = false;
                pcProgress.Visible = false;
                pcProgress.Rotate = false;
                gbResultsGrid.Visible = true;
                gbFilters.Enabled = true;
                gbFilters.Visible = true;
                gbCustomFilters.Visible = true;
                LoadAllAvailableFiltersToCheckListBox();
                //SearchSafeResults = CopyDataGridToDataTable(dgvResults);
                Total_Number_Diffs = SAVED_SEARCH_RESULTS.Rows.Count;
                lblTotalFiles.Text = "Remaining files: " + SAVED_SEARCH_RESULTS.Rows.Count + "/" + Total_Number_Diffs + "\nSize: " + GetTotalFilesSize(SAVED_SEARCH_RESULTS) + " KB";
                List<EnvComparisonFilter> preFilters = GetPrefilterList(clbAvailableFilters);

                if (preFilters.Count > 0) {
                    string collectedPrefilters = GetFormattedPrefiltersForDisplay(preFilters);
                    DialogResult dialog = FrontendUtils.ShowConformation("Comparsion completed!\nAuto cleanup the following types?\n\n" + collectedPrefilters);
                    if (dialog == DialogResult.Yes) {
                        ApplySelectedFiltersToSearchResults(preFilters);
                    } else {
                        for (int i = 0; i < clbAvailableFilters.Items.Count; i++) {
                            clbAvailableFilters.SetItemCheckState(i, CheckState.Unchecked);
                        }
                    }
                }

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }

        }


        void CboFilterTypeSelectedIndexChanged(object sender, EventArgs e) {
            //setup for deletion
            if(cboFilterType.SelectedIndex == (int)EnvComparisonFilter.ComparisonFilterType.Deletion) {
                txtFilterPattern.Size = new Size(339, 23);
                cboRemoveFileOrFolder.SelectedIndex=0;
                cboRemoveFileOrFolder.Visible = true;
                lblGeneratedScript.Visible = true;
                txtGeneratedScript.Visible = true;
                btnGetScript.Visible = true;
                lblExcludeList.Visible = true;
                txtExclusionList.Visible = true;
            } else {
                //setup for all other operations
                txtFilterPattern.Size = new Size(496, 78);
                cboRemoveFileOrFolder.Visible = false;
                lblGeneratedScript.Visible = false;
                txtGeneratedScript.Visible = false;
                btnGetScript.Visible = false;
                lblExcludeList.Visible = false;
                txtExclusionList.Visible = false;
            }
        }



        void LvAvailableFiltersSelectedIndexChanged(object sender, EventArgs e) {
            try {

                if (lvAvailableFilters.SelectedItems.Count >0) {
                    EnvComparisonFilter selectedFilter =  lvAvailableFilters.SelectedItems[0].Tag as EnvComparisonFilter;
                    if (selectedFilter != null) {
                        FillUiFromSelectedFilter(selectedFilter);
                    }

                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message,ex);
            }
        }





        void BtnGetScriptClick(object sender, EventArgs e) {
            try {
                txtGeneratedScript.Clear();

                txtGeneratedScript.Text =  GetGeneratedScript(txtFilterPattern.Text,cboRemoveFileOrFolder.SelectedIndex==1);

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message,ex);
            }
        }


    }
}
