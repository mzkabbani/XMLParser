using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Common {
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
        public SimpleRecommendationObject() { }

        public SimpleRecommendationObject(string newOptionName, bool newIsRegex, string newDescription, string newPattern, string newReplacement, string newFileName) {
            this.optionName = newOptionName;
            this.isRegex = newIsRegex;
            this.description = newDescription;
            this.pattern = newPattern;
            this.replacement = newReplacement;
            this.fileName = newFileName;
        }

    }
}
