using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using XmlParsersAndUi.Classes;
using System.IO;
using Automation.Common.Utils;
using Automation.Common.Classes.Monitoring;

namespace XmlParsersAndUi.Forms {
    public partial class PackageGenerator : Form {
        public PackageGenerator() {
            InitializeComponent();
        }

        string pathToThisExec = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);


        private void PackageGenerator_Load(object sender, EventArgs e) {
            try {
                try {
                    if (!string.IsNullOrEmpty(MonitorObject.username)) {
                        MonitorObject.formAndAccessTime.Add(new FormAndAccessTime(this.Name, DateTime.Now));
                    }
                } catch (Exception) {

                }
                cboPropertyType.SelectedIndex = 0;
                //populate all props from installer file

                string pathToInstallerFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\installMain.groovy";

                PopulateAllAvailableProperties(pathToInstallerFile);
                // PopulateAllAvailableProps();
                lbAvailableProps.SelectedIndex = 0;


                string pathToUtilsFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\FrontendUtilities.groovy";
                LoadAvailableFunctionsToList(pathToUtilsFile);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void LoadAvailableFunctionsToList(string utilsFilePath) {
            string readFile = FrontendUtils.ReadFile(utilsFilePath);

            Regex regex = new Regex("(public).*?(\\S+).?\\((.*)\\)\\{");
            MatchCollection matches = regex.Matches(readFile);

            foreach (Match match in matches) {
                string functionName = match.Groups[2].Value;
                string allFunctionVariables = match.Groups[3].Value;

                string[] variables = allFunctionVariables.Split(',');
                Dictionary<string, List<string>> variableTypAndName = new Dictionary<string, List<string>>();
                variableTypAndName.Add("boolean", new List<string>());
                variableTypAndName.Add("other", new List<string>());

                string functionCall = string.Empty;

                for (int i = 0; i < variables.Length; i++) {
                    string[] variableTypeAndName = variables[i].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                    if (variableTypeAndName.Length > 1) {
                        functionCall = functionCall + variableTypeAndName[1] + " ,";
                        if (string.Equals(variableTypeAndName[0], "boolean") || string.Equals(variableTypeAndName[0], "Boolean")) {
                            variableTypAndName["boolean"].Add(variableTypeAndName[1]);
                        } else {
                            variableTypAndName["other"].Add(variableTypeAndName[1]);
                        }
                    }
                }
                functionCall = functionCall.Trim(new char[] { ',' });
                CustomizationFunction function = new CustomizationFunction(functionName, "desc", variableTypAndName, functionCall);

                function.localDescription = GetDiscription(function.localName, readFile);

                lbAvailableFunctions.Items.Add(function);
                //Label lbl = new Label();
                //lbl.Text = variableTypeAndName[1];
                //pnlParameters.Controls.Add(lbl);
                //lbl.Dock = DockStyle.Top;
                //if (string.Equals(variableTypeAndName[0], "boolean") || string.Equals(variableTypeAndName[0], "Boolean")) {
                //    ComboBox cbo = new ComboBox();
                //    cbo.Items.Add("True");
                //    cbo.Items.Add("False");
                //    cbo.DropDownStyle = ComboBoxStyle.DropDownList;
                //    cbo.Name = variableTypeAndName[1];
                //    pnlParameters.Controls.Add(cbo);
                //    cbo.Dock = DockStyle.Top;
                //} else {
                //    TextBox txt = new TextBox();
                //    txt.Name = variableTypeAndName[1];
                //    pnlParameters.Controls.Add(txt);
                //    txt.Dock = DockStyle.Top;
                //}

            }
        }

        private string GetDiscription(string functionName, string inputText) {
            string description = string.Empty;
            Regex reg = new Regex("//desc-start.*Name:(" + functionName + ")(.*?)//desc-end", RegexOptions.Singleline);
            Match match = reg.Match(inputText);
            if (match.Groups.Count > 0) {
                string funName = match.Groups[1].Value;
                string desc = match.Groups[2].Value;
                desc = desc.Replace("//", "").Replace("Description:", "").Replace("\t", "").Replace("\r", "").Replace("\n", "");
                desc = desc.Replace("Parameter", "\r\nParameter");
                description = desc;
            }
            return description;
        }

        private void lbAvailableFunctions_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                UpdateUiFromSelectedItem(lbAvailableFunctions.SelectedItem as CustomizationFunction);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void UpdateUiFromSelectedItem(CustomizationFunction customizationFunction) {
            pnlParameters.Controls.Clear();
            txtFunctionName.Text = customizationFunction.localName;
            txtDescription.Text = customizationFunction.localDescription;
            for (int i = 0; i < customizationFunction.localVariableTypeAndName.Count; i++) {
                for (int j = 0; j < customizationFunction.localVariableTypeAndName.ElementAt(i).Value.Count; j++) {

                    Label lbl = new Label();

                    lbl.Text = customizationFunction.localVariableTypeAndName.ElementAt(i).Value[j].Substring(0, 1).ToUpperInvariant() +
                    customizationFunction.localVariableTypeAndName.ElementAt(i).Value[j].Substring(1);
                    lbl.Dock = DockStyle.Top;


                    if (string.Equals(customizationFunction.localVariableTypeAndName.ElementAt(i).Key, "boolean")) {
                        ComboBox cbo = new ComboBox();
                        cbo.Items.Add("True");
                        cbo.Items.Add("False");
                        cbo.DropDownStyle = ComboBoxStyle.DropDown;
                        cbo.Name = customizationFunction.localVariableTypeAndName.ElementAt(i).Value[j];
                        cbo.Dock = DockStyle.Top;
                        cbo.SelectedIndex = 0;
                        cbo.ContextMenuStrip = cmsAddPropertyMenu;
                        pnlParameters.Controls.Add(cbo);
                        pnlParameters.Controls.Add(lbl);

                    } else {
                        TextBox txt = new TextBox();
                        txt.Name = customizationFunction.localVariableTypeAndName.ElementAt(i).Value[j];
                        txt.Dock = DockStyle.Top;
                        txt.Text = "\"\"";
                        txt.ContextMenuStrip = cmsAddPropertyMenu;
                        pnlParameters.Controls.Add(txt);
                        pnlParameters.Controls.Add(lbl);

                    }

                }
            }
        }

        //void txt_TextChanged(object sender, EventArgs e) {
        //    TextBox txt = sender as TextBox;
        //    if(!string.IsNullOrEmpty(txt.Text)){
        //        if(!txt.Text.StartsWith("\"")){
        //            txt.Text = "\"" + txt.Text;
        //        }
        //        if(!txt.Text.EndsWith("\"")){
        //            txt.Text = txt.Text + "\"";
        //        }
        //    }
        //}
        int counter = 1;
        private void btnAdd_Click(object sender, EventArgs e) {
            try {
                string operationValue = GetAllVariables();
                //txtOutput.Text = txtOutput.Text + "\r\n\r\n" + counter + "- " + operationValue;
                int rowIndex = dgvOutputOperations.Rows.Add();
                dgvOutputOperations.Rows[rowIndex].Cells["Steps"].Value = rowIndex + 1;
                dgvOutputOperations.Rows[rowIndex].Cells["Operations"].Value = operationValue;
                counter++;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnRemove_Click(object sender, EventArgs e) {
            try {
                if (dgvOutputOperations.Rows.Count > 0) {
                    dgvOutputOperations.Rows.RemoveAt(dgvOutputOperations.Rows.Count - 1);
                }

                //txtOutput.Text = txtOutput.Text.Remove(txtOutput.Text.LastIndexOf("\r\n\r\n"));
                counter--;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private string GetAllVariables() {
            //update this to consider properties
            string returnValue = (lbAvailableFunctions.SelectedItem as CustomizationFunction).functionCall;
            foreach (Control control in pnlParameters.Controls) {
                if (control is TextBox) {
                    Regex reg = new Regex(@"\b" + control.Name + @"\b");
                    if (!control.Text.Contains("{")) {
                        returnValue = reg.Replace(returnValue, control.Text);
                        // returnValue = returnValue.Replace(control.Name, "\"" + control.Text + "\"");
                    } else {
                        //propname+asdasdasdasd
                        Regex propBracketReg = new Regex("\\{(\\S+)\\}");
                        string propertyName = "PROP_" + propBracketReg.Match(control.Text).Groups[1].Value;
                        returnValue = reg.Replace(returnValue, control.Text.Replace("{" + propBracketReg.Match(control.Text).Groups[1].Value + "}", "PROP_" + propBracketReg.Match(control.Text).Groups[1].Value));

                    }
                } else if (control is ComboBox) {
                    Regex reg = new Regex(@"\b" + control.Name + @"\b");
                    //returnValue = returnValue + (string.Equals(control.Text, "True") ? true : false) + " ,";
                    if (!control.Text.Contains("{")) {
                        returnValue = reg.Replace(returnValue, (string.Equals(control.Text, "True") ? "true" : "false"));
                        //returnValue =    returnValue.Replace(control.Name, (string.Equals(control.Text, "True") ? true : false).ToString());
                    } else {
                        returnValue = reg.Replace(returnValue, "PROP_" + control.Text.Trim(new char[] { '{', '}' }));

                    }
                }
            }
            return returnValue;
        }

        private void btnGeneratePackage_Click(object sender, EventArgs e) {
            try {

                PreparePackageForGeneration();

                #region Create Generation Command and Generate

                FolderBrowserDialog dial = new FolderBrowserDialog();

                dial.ShowNewFolderButton = true;

                dial.Description = "Generated Package Location";

                if (dial.ShowDialog() == DialogResult.OK) {
                    string pathToTarget = dial.SelectedPath;
                    string pathToCisPackage = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\cis-mxpack-1.0-full.jar";
                    string pathToConfigFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\ci.xml";

                    string pathToSource = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk";

                    string packageId = "MigrationPackage";

                    string commandToExecute = "java -jar \"" + pathToCisPackage + "\"" +
                                              " " +
                                              "-configfile:\"" + pathToConfigFile + "\"" +
                                              " " +
                                              "-source:\"" + pathToSource + "\"" +
                                              " " +
                                              "-target:\"" + pathToTarget + "\"" +
                                              " " +
                                              "-packageid:" + packageId;


                    FrontendUtils.WriteFile(pathToThisExec + @"\compile.cmd", commandToExecute);
                    FrontendUtils.ExecuteCommandSync(pathToThisExec + @"\compile.cmd");
                }
                #endregion

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void PreparePackageForGeneration() {
            #region Prepare Package for Generations

            string pathToMainInstallerFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\installMain.groovy";
            string pathToInstallerFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\Installer.groovy";
            string pathToOriginalOperationFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\main.groovy";
            string pathToOperationFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\Operations.groovy";


            #region Installer File

            //Copy Installer File
            File.Copy(pathToMainInstallerFile, pathToInstallerFile, true);
            //Read fresh Installer File
            string installerFile = FrontendUtils.ReadFile(pathToInstallerFile);

            Regex reg = new Regex(@"//Start-Properties(.*)End-Properties", RegexOptions.Singleline);

            string replacementAllProperties = GetAllProperties();

            installerFile = reg.Replace(installerFile, "//Start-Properties\n\n" + replacementAllProperties + "\n\n//End-Properties");
            //write new Installer File
            FrontendUtils.WriteFile(pathToInstallerFile, installerFile);

            #endregion


            #region Operations file

            //copy fresh operations file
            File.Copy(pathToOriginalOperationFile, pathToOperationFile, true);

            //Read fresh operations file
            string operationFile = FrontendUtils.ReadFile(pathToOperationFile);

            //get formatted properties from UI
            //add properties to operations file
            string allProperties = GetAllPropertiesForOperations();
            operationFile = operationFile.Replace("}}", allProperties + "\r\n\r\n}}");


            //get formatted function calls from UI
            //add function calls to operations file
            //string GeneratedOperationsFile = GetFormatedFunctions(txtOutput.Text);

            string GeneratedOperationsFile = ExtractOperationsFromGridView();
            Regex startEndOperationsRegex = new Regex("//Start-Operations.*//End-Operations", RegexOptions.Singleline);

            operationFile = startEndOperationsRegex.Replace(operationFile, "//Start-Operations" + GeneratedOperationsFile + "\r\n\t//End-Operations");
            //operationFile = operationFile.Replace("}}", GeneratedOperationsFile + "\r\n\r\n}}");

            //write new operations file
            FrontendUtils.WriteFile(pathToOperationFile, operationFile);

            #endregion

            #endregion
        }

        private string ExtractOperationsFromGridView() {
            string extractedOperations = string.Empty;
            for (int i = 0; i < dgvOutputOperations.Rows.Count; i++) {
                extractedOperations = extractedOperations + "\r\n\tfrontEndUtilities." + dgvOutputOperations.Rows[i].Cells["Operations"].Value + ";";
            }
            return extractedOperations;
        }

        private string GetAllPropertiesForOperations() {
            string propertiesInOperations = string.Empty;
            for (int i = 0; i < lbAvailableProps.Items.Count; i++) {
                InstallerProp prop = lbAvailableProps.Items[i] as InstallerProp;
                propertiesInOperations = propertiesInOperations + "def PROP_" + prop.localName + " = properties.get(\"" + prop.localName + "\");\n\r";

            }
            return propertiesInOperations;
        }

        private string GetAllProperties() {
            string propertyAndAddition = string.Empty;

            for (int i = 0; i < lbAvailableProps.Items.Count; i++) {
                InstallerProp prop = lbAvailableProps.Items[i] as InstallerProp;
                propertyAndAddition = propertyAndAddition + "\r\nproperty(name:'" + prop.localName + "'){\r\n" +
                                                                   "description = '" + prop.localDescription + "'\r\n" +
                                                                   "type = " + (prop.localType == InstallerProp.PropType.BooleanProperty ? "boolean" : "String") + "\r\n" +
                                                                   "defaultValue = " + (prop.localType == InstallerProp.PropType.StringProperty ? "'" : "") + prop.localDefaultValue + (prop.localType == InstallerProp.PropType.StringProperty ? "'" : "") + "\r\n}\r\n" +
                                                                   "props.put(\"" + prop.localName + "\", " + prop.localName + ")\r\n";

            }

            return propertyAndAddition;
        }

        //private string GetFormatedFunctions(string outputText) {
        //    string formattedOutput = string.Empty;
        //    string[] outputByLine = txtOutput.Text.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);
        //    Regex reg = new Regex("\\d+-.");
        //    for (int i = 0; i < outputByLine.Length; i++) {
        //        if (!string.IsNullOrEmpty(outputByLine[i].Trim())) {
        //            formattedOutput = formattedOutput + "\n\t" + "frontEndUtilities." + reg.Replace(outputByLine[i], "");
        //        }
        //    }
        //    return formattedOutput;
        //}

        private void btnClear_Click(object sender, EventArgs e) {
            try {
                //txtOutput.Clear();
                dgvOutputOperations.Rows.Clear();
                counter = 1;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnExportCi_Click(object sender, EventArgs e) {
            try {

                PreparePackageForGeneration();

                string pathToThisExec = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string pathToDotCiFolder = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk";
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.ShowNewFolderButton = true;
                if (dialog.ShowDialog() == DialogResult.OK) {
                    FrontendUtils.CopyDirectory(pathToDotCiFolder, dialog.SelectedPath);
                    File.Delete(dialog.SelectedPath + @"\.ci\package\murex\Migration\main.groovy");
                    File.Delete(dialog.SelectedPath + @"\.ci\package\murex\Migration\installMain.groovy");
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void cboPropertyType_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                // 0 String
                // 1 Boolean
                if (cboPropertyType.SelectedIndex == 0) {
                    txtPropertyValue.Visible = true;
                    cboPropertyValue.Visible = false;
                } else {
                    txtPropertyValue.Visible = false;
                    cboPropertyValue.Visible = true;
                    cboPropertyValue.SelectedIndex = 0;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            try {

                //if (string.Equals(tabControl1.SelectedTab.Text, "Properties")) {
                //    //populate all props from installer file

                //    string pathToInstallerFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\installMain.groovy";

                //    PopulateAllAvailableProperties(pathToInstallerFile);
                //    lbAvailableProps.SelectedIndex = 0;

                //}
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }



        private void PopulateAllAvailableProperties(string pathToInstallerFile) {
            lbAvailableProps.Items.Clear();

            // string pathToThisExec = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            //  string pathToInstallerFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\installMain.groovy";

            string installerFile = FrontendUtils.ReadFile(pathToInstallerFile);

            Regex reg = new Regex(@"\bStart-Properties(.*)End-Properties\b", RegexOptions.Singleline);

            string match = reg.Match(installerFile).Groups[1].Value;

            Regex propertyValues = new Regex(@"\bproperty\(name:'(\S+)'.*?description = '(.*?)'.*?type = (\S+).*?(defaultValue = (\S+))\b", RegexOptions.Singleline);

            MatchCollection propertyValuesMatches = propertyValues.Matches(match);


            foreach (Match propertyValuesMatch in propertyValuesMatches) {

                InstallerProp installerPropertyObject
                    = new InstallerProp(propertyValuesMatch.Groups[1].Value,
                propertyValuesMatch.Groups[2].Value,
                string.Equals(propertyValuesMatch.Groups[3].Value.Trim(new char[] { '\'' }), "boolean") ? InstallerProp.PropType.BooleanProperty : InstallerProp.PropType.StringProperty,
                propertyValuesMatch.Groups[5].Value.Trim(new char[] { '\'' }));

                lbAvailableProps.Items.Add(installerPropertyObject);
            }
        }

        //private void PopulateAllAvailableProps() {
        //    lbAvailableProps.Items.Clear();

        //    string pathToThisExec = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        //    string pathToInstallerFile = pathToThisExec + @"\MIGRATION\FIRSTPACKAGE\trunk\.ci\package\murex\Migration\installMain.groovy";

        //    string installerFile = FrontendUtils.ReadFile(pathToInstallerFile);

        //    Regex reg = new Regex(@"\bStart-Properties(.*)End-Properties\b", RegexOptions.Singleline);

        //    string match = reg.Match(installerFile).Groups[1].Value;

        //    Regex propertyValues = new Regex(@"\bproperty\(name:'(\S+)'.*?description = '(.*?)'.*?type = (\S+).*?(defaultValue = (\S+))\b", RegexOptions.Singleline);

        //    MatchCollection propertyValuesMatches = propertyValues.Matches(match);


        //    foreach (Match propertyValuesMatch in propertyValuesMatches) {

        //        InstallerProp installerPropertyObject
        //            = new InstallerProp(propertyValuesMatch.Groups[1].Value,
        //        propertyValuesMatch.Groups[2].Value,
        //        string.Equals(propertyValuesMatch.Groups[3].Value.Trim(new char[] { '\'' }), "boolean") ? InstallerProp.PropType.BooleanProperty : InstallerProp.PropType.StringProperty,
        //        propertyValuesMatch.Groups[5].Value.Trim(new char[] { '\'' }));

        //        lbAvailableProps.Items.Add(installerPropertyObject);
        //    }
        //}

        private void lbAvailableProps_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                txtPropertyName.ReadOnly = true;
                btnAddProperty.Enabled = false;
                btnSaveProperty.Enabled = true;


                InstallerProp selectedInstallerPropertyObject = lbAvailableProps.SelectedItem as InstallerProp;
                if (selectedInstallerPropertyObject != null) {

                    txtPropertyName.Text = selectedInstallerPropertyObject.localName;
                    txtPropertyDesc.Text = selectedInstallerPropertyObject.localDescription;

                    cboPropertyType.SelectedIndex = (selectedInstallerPropertyObject.localType == InstallerProp.PropType.BooleanProperty) ? 1 : 0;
                    if (cboPropertyType.SelectedIndex == 0) {
                        txtPropertyValue.Text = selectedInstallerPropertyObject.localDefaultValue.ToString();
                    } else {
                        cboPropertyValue.SelectedIndex = string.Equals(selectedInstallerPropertyObject.localDefaultValue.ToString(), "true") ? 0 : 1;
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            try {
                lbAvailableProps.ClearSelected();
                btnAddProperty.Enabled = true;
                btnSaveProperty.Enabled = false;

                txtPropertyName.ReadOnly = false;
                txtPropertyName.Clear();
                txtPropertyDesc.Clear();
                txtPropertyValue.Clear();
                cboPropertyValue.SelectedIndex = 0;
                cboPropertyType.SelectedIndex = 0;



            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnAddProperty_Click(object sender, EventArgs e) {

            try {
                if (IsValidToAddProperty(gbProperty.Controls)) {
                    if (lbAvailableProps.FindStringExact(txtPropertyName.Text) == ListBox.NoMatches) {

                        InstallerProp selectedInstallerPropertyObject =
                                    new InstallerProp(txtPropertyName.Text,
                                                      txtPropertyDesc.Text,
                                                      cboPropertyType.SelectedIndex == 0 ? InstallerProp.PropType.StringProperty : InstallerProp.PropType.BooleanProperty,
                                                      txtPropertyValue.Visible ? txtPropertyValue.Text : cboPropertyValue.SelectedItem.ToString().ToLower());

                        lbAvailableProps.Items.Add(selectedInstallerPropertyObject);
                    } else {
                        FrontendUtils.ShowInformation("The property name is already in use, please choose a unique name!",true);
                    }

                } else {
                    FrontendUtils.ShowInformation("Please make sure all fields are filled",true);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private bool IsValidToAddProperty(Control.ControlCollection controlCollection) {
            foreach (Control control in controlCollection) {
                if (control is TextBox && control.Visible) {
                    if (string.IsNullOrEmpty(control.Text)) {
                        return false;
                    }
                }
            }
            return true;
        }

        private void btnRemoveProperty_Click(object sender, EventArgs e) {
            try {
                lbAvailableProps.Items.Remove(lbAvailableProps.SelectedItem);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnSaveProperty_Click(object sender, EventArgs e) {
            try {
                if (IsValidToAddProperty(gbProperty.Controls)) {
                    InstallerProp installerProp = lbAvailableProps.Items[lbAvailableProps.FindStringExact(txtPropertyName.Text)] as InstallerProp;

                    installerProp.localDescription = txtPropertyDesc.Text;
                    installerProp.localType = cboPropertyType.SelectedIndex == 0 ? InstallerProp.PropType.StringProperty : InstallerProp.PropType.BooleanProperty;
                    installerProp.localDefaultValue = txtPropertyValue.Visible ? txtPropertyValue.Text : cboPropertyValue.SelectedItem.ToString().ToLower();

                } else {
                    FrontendUtils.ShowInformation("Please make sure all fields are filled",true);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private Rectangle dragBoxFromMouseDown;
        private int rowIndexFromMouseDown;
        private int rowIndexOfItemUnderMouseToDrop;

        private void dgvOutputOperations_MouseMove(object sender, MouseEventArgs e) {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left) {
                // If the mouse moves outside the rectangle, start the drag.         
                if (dragBoxFromMouseDown != Rectangle.Empty && !dragBoxFromMouseDown.Contains(e.X, e.Y)) {
                    // Proceed with the drag and drop, passing in the list item.                                 
                    DragDropEffects dropEffect = dgvOutputOperations.DoDragDrop(dgvOutputOperations.Rows[rowIndexFromMouseDown], DragDropEffects.Move);
                }
            }
        }

        private void dgvOutputOperations_MouseDown(object sender, MouseEventArgs e) {
            // Get the index of the item the mouse is below.
            rowIndexFromMouseDown = dgvOutputOperations.HitTest(e.X, e.Y).RowIndex;
            if (rowIndexFromMouseDown != -1) {
                // Remember the point where the mouse down occurred.       
                // The DragSize indicates the size that the mouse can move       
                // before a drag event should be started.
                Size dragSize = SystemInformation.DragSize;
                // Create a rectangle using the DragSize, with the mouse position being         
                // at the center of the rectangle.         
                dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2), e.Y - (dragSize.Height / 2)), dragSize);
            } else {
                // Reset the rectangle if the mouse is not over an item in the ListBox.         
                dragBoxFromMouseDown = Rectangle.Empty;
            }
        }

        private void dgvOutputOperations_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void dgvOutputOperations_DragDrop(object sender, DragEventArgs e) {
            // The mouse locations are relative to the screen, so they must be      
            // converted to client coordinates.     
            Point clientPoint = dgvOutputOperations.PointToClient(new Point(e.X, e.Y));
            // Get the row index of the item the mouse is below.      
            rowIndexOfItemUnderMouseToDrop = dgvOutputOperations.HitTest(clientPoint.X, clientPoint.Y).RowIndex;
            // If the drag operation was a move then remove and insert the row.
            if (e.Effect == DragDropEffects.Move) {
                DataGridViewRow rowToMove = e.Data.GetData(typeof(DataGridViewRow)) as DataGridViewRow;
                dgvOutputOperations.Rows.RemoveAt(rowIndexFromMouseDown);
                dgvOutputOperations.Rows.Insert(rowIndexOfItemUnderMouseToDrop, rowToMove);
            }
        }

        /// <summary> /// Gets controls for context menu ///
        /// </summary> /// <param name="Sender">Sender object from menu event handler</param> ///
        /// <returns></returns> 
        private object GetSourceControl(Object Sender) {
            // ContextMenuStrip sended?
            if (Sender as ContextMenuStrip != null) {
                ContextMenuStrip cms = Sender as ContextMenuStrip;
                return cms.SourceControl;
            }
            var item = Sender as ToolStripItem;
            // move to root item   
            while (item.OwnerItem != null) {
                item = item.OwnerItem;
            }
            // we have root item now, so lets take ContextMenuStrip object   
            var menuObject = item.Owner as ContextMenuStrip;
            if (menuObject != null) {
                return menuObject.SourceControl;
            }
            return null;
        }

        private void addPropertyToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                //  AddPropertyForm form = new AddPropertyForm(lbAvailableProps.Items);
                AddPropertyForm form = new AddPropertyForm(lbAvailableProps.Items);
                // form.Parent = this.Parent;
                form.StartPosition = FormStartPosition.CenterParent;
                DialogResult result = form.ShowDialog();

                if (result == DialogResult.OK) {
                    Control control = GetSourceControl((sender as ToolStripMenuItem).GetCurrentParent()) as Control;
                    if (control != null) {
                        control.Text = control.Text + "{" + form.selectedInstallerProp.localName + "}";
                    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void btnImportCi_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog dial = new FolderBrowserDialog();

                if (dial.ShowDialog() == DialogResult.OK) {
                    StartImportOfCi(dial.SelectedPath);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void StartImportOfCi(string PathToCiFolder) {
            dgvOutputOperations.Rows.Clear();
            string[] installerFile = Directory.GetFiles(PathToCiFolder, "Installer.groovy", SearchOption.AllDirectories);
            string[] OperationsFile = Directory.GetFiles(PathToCiFolder, "Operations.groovy", SearchOption.AllDirectories);
            ParseCiProperties(installerFile[0]);
            ParseCiFunctions(OperationsFile[0]);
        }

        private void ParseCiFunctions(string pathToOperationsFile) {
            Regex operationsRegex = new Regex("//Start-Operations(.*)//End-Operations", RegexOptions.Singleline);
            string readOperationsFile = FrontendUtils.ReadFile(pathToOperationsFile);

            string allOperations = operationsRegex.Match(readOperationsFile).Groups[1].Value;

            Regex anOperation = new Regex(@"frontEndUtilities.(.*);");
            MatchCollection mCollection = anOperation.Matches(allOperations);

            foreach (Match match in mCollection) {
                //SetUtilsLogDir(logDir, );
                int rowIndex = dgvOutputOperations.Rows.Add();
                dgvOutputOperations.Rows[rowIndex].Cells["Steps"].Value = rowIndex + 1;
                dgvOutputOperations.Rows[rowIndex].Cells["Operations"].Value = match.Groups[1].Value;

            }
        }

        private void ParseCiProperties(string pathToInstallerFile) {
            PopulateAllAvailableProperties(pathToInstallerFile);
        }

        private void relAppdirToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                 Control control = GetSourceControl((sender as ToolStripMenuItem).GetCurrentParent()) as Control;
            if (control != null) {
                control.Text = "AppDir + \"/\"";
            }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

    }
}
