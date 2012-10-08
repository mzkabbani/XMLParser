using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi.Classes {
    public class CustomizationFunction {
        public string localName;
        public string localDescription;
        public Dictionary<string, List<string>> localVariableTypeAndName;
        public string functionCall;


        public CustomizationFunction(string name, string description, Dictionary<string, List<string>> variableNameAndType, string matchFunction) {
            localName = name;
            localDescription = description;
            localVariableTypeAndName = variableNameAndType;
            functionCall = name + "( "+matchFunction+")";
            //functionCall = name+"("++")";
        }

        public override string ToString() {
            return localName;
        }
    }
}
