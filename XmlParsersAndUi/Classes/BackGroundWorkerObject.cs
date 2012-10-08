using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Common;

namespace XmlParsersAndUi.Classes {
    public class BackGroundWorkerObject {

        public List<AdvancedRecomendation> selectedCaptureEvents = new List<AdvancedRecomendation>();
        public List<FileToParseObject> targetedFiles = new List<FileToParseObject>();
        public object returnObject;
        public List<ComplexCaptureMatchObject> returnedComplexCaptureMatchObject = new List<ComplexCaptureMatchObject>();

        public override string ToString() {
            return "Replacement";
        }
    }
    public class FileToParseObject {
        public string fileName;
        public bool parsed;

        public FileToParseObject(string newFileName, bool isParsed) {
            fileName = newFileName;
            parsed = isParsed;
        }
    }
    
}
