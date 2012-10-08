using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using System.IO;
using System.Collections;
using System.Xml;
using Automation.Common.Utils;

namespace XmlParsersAndUi {
    public partial class ConfigBuilder : Form {

        #region Global Variables

        string parentElementName = string.Empty;
        string readText = string.Empty;

        #endregion

        #region Constructor

        public ConfigBuilder() {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void FindChildren(string readText, string nodeName, out ArrayList childrenList) {
            childrenList = new ArrayList();
            XDocument newXDocument = XDocument.Parse(readText);
            IEnumerable<XElement> items = newXDocument.Descendants("element");
            var selectedElementsFirstRun = from c in newXDocument.Descendants("element")
                                           where string.Equals(c.Attribute("name").Value, nodeName)
                                           select new {
                                               s1 = c
                                           };
            if (selectedElementsFirstRun.ElementAt(0).s1.HasElements) {
                var selectedElements = from c in newXDocument.Descendants("element")
                                       where string.Equals(c.Attribute("name").Value, nodeName)
                                       select new {
                                           s1 = c.Descendants("element")
                                       };
                IEnumerable<XElement> sElements = selectedElements.ElementAt(0).s1;
                for (int i = 0; i < sElements.Count(); i++) {
                    childrenList.Add(sElements.ElementAt(i).Attributes("ref").ElementAt(0).Value);
                }
                childrenList.Sort();
            } else {
                // something here
            }
        }

        private string FormatXml(string sUnformattedXml) {
            //load unformatted xml into a dom
            XmlDocument xd = new XmlDocument();
            xd.LoadXml(sUnformattedXml);
            //will hold formatted xml
            StringBuilder sb = new StringBuilder();
            //pumps the formatted xml into the StringBuilder above
            StringWriter sw = new StringWriter(sb);
            //does the formatting
            XmlTextWriter xtw = null;
            try {
                //point the xtw at the StringWriter
                xtw = new XmlTextWriter(sw);
                //we want the output formatted
                xtw.Formatting = Formatting.Indented;
                //get the dom to dump its contents into the xtw 
                xd.WriteTo(xtw);
            } finally {
                //clean up even if error
                if (xtw != null)
                    xtw.Close();
            }
            //return the formatted xml
            return sb.ToString();
        }

        private void AddtoListBox(ArrayList Children, ListBox lbGeneric) {
            for (int i = 0; i < Children.Count; i++) {
                lbGeneric.Items.Add(Children[i]);
            }
        }

        private void DisplayElementParams(DtdElement element) {
            txtLogs.Text = txtLogs.Text + "Element name: " + element.elementName + "\r\n";
            txtLogs.Text = txtLogs.Text + "Element parent name: " + element.parentElementName + "\r\n";
            txtLogs.Text = txtLogs.Text + "Element min occurances: " + element.elementMinOccurance + "\r\n";
            txtLogs.Text = txtLogs.Text + "Element max occurances: " + element.elementMaxOccurance + "\r\n";
            txtLogs.Text = txtLogs.Text + "Element attribute name: " + element.elementAttributeName + "\r\n";
            txtLogs.Text = txtLogs.Text + "Element attribute optional: " + element.elementAttributeOptional + "\r\n";
            txtLogs.Text = txtLogs.Text + "Element possible attributes: " + ConvertToString(element.elementAttributeValues) + "\r\n\r\n\r\n\r\n";
            txtLogs.SelectionStart = txtLogs.Text.Length;
            txtLogs.ScrollToCaret();
            txtLogs.Refresh();
        }

        private string ConvertToString(List<string> list) {
            string returnString = string.Empty;
            for (int i = 0; i < list.Count; i++) {
                returnString = returnString + list[i] + ", ";
            }
            return returnString;
        }

        private DtdElement GetElementAttributes(DtdElement element, string readText) {
            DtdElement newElement = element;
            XDocument xdoc = XDocument.Parse(readText);
            var selectedElementsFirstRun = from c in xdoc.Descendants("element")
                                           where string.Equals(c.Attribute("name").Value, element.elementName)
                                           select new {
                                               s1 = c
                                           };
            if (selectedElementsFirstRun.ElementAt(0).s1.HasElements) {
                var slectedchildren = from v in selectedElementsFirstRun.ElementAt(0).s1.Descendants("attribute")
                                      select new {
                                          s2 = v
                                      };
                if (slectedchildren.Count() != 0) {
                    if (slectedchildren.ElementAt(0).s2 != null) {
                        newElement.elementAttributeName = slectedchildren.ElementAt(0).s2.Attribute("name").Value;
                        newElement.elementAttributeOptional = slectedchildren.ElementAt(0).s2.Attribute("use").Value.Equals("optional") ? true : false;
                        var attributeEnums = from b in slectedchildren.ElementAt(0).s2.Descendants("enumeration")
                                             select new { s3 = b };
                        for (int i = 0; i < attributeEnums.Count(); i++) {
                            newElement.elementAttributeValues.Add(attributeEnums.ElementAt(i).s3.Attribute("value").Value);
                        }
                    }
                }
            }
            return newElement;
        }

        private DtdElement GetMinAndMaxOccurances(DtdElement element, string xmlText) {
            DtdElement newElement = element;
            XDocument xdoc = XDocument.Parse(xmlText);
            var selectedElementsFirstRun = from c in xdoc.Descendants("element")
                                           where string.Equals(c.Attribute("name").Value, element.elementName)
                                           select new {
                                               s1 = c
                                           };
            if (selectedElementsFirstRun.ElementAt(0).s1.HasElements) {
                var slectedchildren = from v in selectedElementsFirstRun.ElementAt(0).s1.Descendants()
                                      where v.Attribute("minOccurs") != null
                                      select new {
                                          s2 = v
                                      };
                if (slectedchildren.Count() > 0) {
                    newElement.elementMaxOccurance = slectedchildren.ElementAt(0).s2.Attribute("maxOccurs") == null ? "" : slectedchildren.ElementAt(0).s2.Attribute("maxOccurs").Value;
                    newElement.elementMinOccurance = slectedchildren.ElementAt(0).s2.Attribute("minOccurs") == null ? "" : slectedchildren.ElementAt(0).s2.Attribute("minOccurs").Value;
                }
            }
            return newElement;
        }

        #endregion

        #region Events

        private void ConfigBuilder_Load(object sender, EventArgs e) {
            try {
                StreamReader reader = new StreamReader(@"D:\output.txt");
                try {
                    readText = reader.ReadToEnd();
                } finally {
                    reader.Close();
                }
                ArrayList ImportChildren = new ArrayList();
                FindChildren(readText, "Import", out ImportChildren);
                AddtoListBox(ImportChildren, lbImport);
                ArrayList CustomizeChildren = new ArrayList();
                FindChildren(readText, "Customize", out CustomizeChildren);
                AddtoListBox(CustomizeChildren, lbCustomize);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }
        
        private void lbCustomize_DoubleClick(object sender, EventArgs e) {
            try {
                DtdElement element = new DtdElement();
                if (!string.Equals(((ListBox)sender).Tag, "generic")) {
                    element.parentElementName = "Customize";
                } else {
                    element.parentElementName = parentElementName;
                }
                element.elementName = ((ListBox)sender).Text;
                element = GetMinAndMaxOccurances(element, readText);
                element = GetElementAttributes(element, readText);
                gbParameters.Visible = true;
                gbParameters.Controls.Clear();
                Label label = new Label();
                label.Text = element.elementName;
                label.Dock = DockStyle.Left;
                gbParameters.Controls.Add(label);
                ListBox lbGeneric = new ListBox();
                lbGeneric.Visible = false;
                lbGeneric.Parent = gbParameters;
                lbGeneric.Dock = DockStyle.Left;
                ArrayList childrenNodes = new ArrayList();
                //FindChildren(readText, label.Text, out childrenNodes);
                FindChildren(readText, element.elementName, out childrenNodes);
                AddtoListBox(childrenNodes, lbGeneric);
                if (lbGeneric.Items.Count > 0) {
                    gbParameters.Controls.Add(lbGeneric);
                    lbGeneric.DoubleClick += new EventHandler(lbCustomize_DoubleClick);
                    lbGeneric.Visible = true;
                    lbGeneric.Sorted = true;
                    lbGeneric.Tag = "generic";
                }
                DisplayElementParams(element);
                parentElementName = element.elementName;
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void txtConfigFileText_TextChanged(object sender, EventArgs e) {
            //txtConfigFileText.Text = FormatXml(txtConfigFileText.Text);
        }  

        #endregion
    }
}
