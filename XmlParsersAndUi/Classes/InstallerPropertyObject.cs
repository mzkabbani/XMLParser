using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi.Classes {
    public class InstallerProp {
        public enum PropType {
            StringProperty = 1,
            BooleanProperty = 2
        }


       public string localName;
       public string localDescription;
       public PropType localType;
       public object localDefaultValue;

        public InstallerProp(string name, string description, PropType type, object defaultValue) {
            localName=name;
            localDescription=description;
            localType= type;
            localDefaultValue= defaultValue;
        }

        public override string ToString() {
            return localName;
        }
    }
}
