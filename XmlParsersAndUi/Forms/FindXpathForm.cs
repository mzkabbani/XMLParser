using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Automation.Common.Utils;

namespace XmlParsersAndUi {
    public partial class FindXpathForm : Form {
        public FindXpathForm() {
            InitializeComponent();
        }

        private void btnFindXpath_Click(object sender, EventArgs e) {

            try {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(txtXmlInput.Text);
                XmlNodeList nodes = doc.SelectNodes(txtFinder.Text.Split('=')[0]);

                foreach (XmlNode node in nodes) {
                    txtXpathOut.Text = txtXpathOut.Text + "\r\n" + node.Value;


            //        if (string.Equals(node.Value, txtFinder.Text.Split('=')[1])) {
                //        txtXpathOut.Text = txtXpathOut.Text + FindXPath(node) + "\r\n";
                //    }
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }


        static string FindXPath(XmlNode node) {
            StringBuilder builder = new StringBuilder();
            while (node != null) {
                switch (node.NodeType) {
                    case XmlNodeType.Attribute:
                        builder.Insert(0, "/@" + node.Name);
                        node = ((XmlAttribute)node).OwnerElement;
                        break;
                    case XmlNodeType.Text:
                        builder.Insert(0, "/text()");
                        node = node.ParentNode;                        
                        break;
                    case XmlNodeType.Element:
                        int index = FindElementIndex((XmlElement)node);
                        if (string.Equals(node.Name, "Component")) {
                            builder.Insert(0, "/" + node.Name + "[@Code=\'" + node.Attributes["Code"].Value + "\']");
                        } else {
                            builder.Insert(0, "/" + node.Name + "[" + index + "]");
                        
                        }
                        node = node.ParentNode;
                        break;
                    case XmlNodeType.Document:
                        return builder.ToString();
                    default:
                        throw new ArgumentException("Only elements and attributes are supported");
                }
            }
            throw new ArgumentException("Node was not in a document");
        }

        static int FindElementIndex(XmlElement element) {
            XmlNode parentNode = element.ParentNode;
            if (parentNode is XmlDocument) {
                return 1;
            }
            XmlElement parent = (XmlElement)parentNode;
            int index = 1;
            foreach (XmlNode candidate in parent.ChildNodes) {
                if (candidate is XmlElement && candidate.Name == element.Name) {
                    if (candidate == element) {
                        return index;
                    }
                    index++;
                }
            }
            throw new ArgumentException("Couldn't find element within parent");
        }
    }
}
