using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi {
    public class DtdElement {
        public string parentElementName;
        public string elementName;        
        public string elementAttributeName;
        public List<string> elementAttributeValues = new List<string>();
        public bool elementAttributeOptional;
        public string elementMinOccurance;
        public string elementMaxOccurance;
                
    }
}
