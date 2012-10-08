using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using Automation.Common;

namespace Automation.Common{
    public class ComplexCaptureMatchObject {
        public AdvancedRecomendation captureEvent;  
        public List<FileAndNumberOfMatches> fileNamesHit = new List<FileAndNumberOfMatches>();
        public ReplacementEvent usedReplacementEvent;
    }

    public class FileAndNumberOfMatches {
        public string fileName;
        public List<XNode> matchedNodes = new List<XNode>(); 
        
    }
}
