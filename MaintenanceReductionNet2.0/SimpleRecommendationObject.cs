using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi {
    public class SimpleRecommendationObject {
        public string optionName;
        public bool isRegex;
        public string description;
        public string pattern;
        public string replacement;
        public string fileName;
        public override string ToString() {
            return optionName;
        }
    }
}
