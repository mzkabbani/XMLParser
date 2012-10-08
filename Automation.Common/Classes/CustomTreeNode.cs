using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace Automation.Common {

    

    public class CustomTreeNode : TreeNode {
        public XmlAttributeCollection Attributes;
        public List<CustomizedAttribute> customizedAttributeCollection;        
        public bool isNodeUsed { get; set; }
        public bool nodeVisited;
        public string parentNodeText;
        public string nodeIncludedText;
        public int nodeLevel;
        public int nodeIndex;
        public int parentLevel;
        public int parentIndex;
        public CustomTreeNode(string text, XmlAttributeCollection attrCollection) {
            Attributes = attrCollection;
            if (this.Attributes != null) {
                this.Text = this.Attributes["name"] == null ? text : this.Attributes["name"].Value;
                customizedAttributeCollection = new List<CustomizedAttribute>();
                foreach (XmlAttribute attribute in attrCollection) {
                    CustomizedAttribute attr = new CustomizedAttribute(attribute, true);
                    customizedAttributeCollection.Add(attr);
                }
            } else {
                this.Text = text;
            }
        }
    }

    public class CustomizedAttribute {
        public XmlAttribute attribute;
       
        public bool isUsed { get; set; }
        public string attrName = string.Empty;
        public string attrValue = string.Empty;
        public CustomizedAttribute(XmlAttribute attr, bool used) {
            attribute = attr;
            isUsed = used;
        }

        public CustomizedAttribute(string name, string value, bool used) {
            attrName = name;
            attrValue = value;
            isUsed = used;
        }

    }
}

