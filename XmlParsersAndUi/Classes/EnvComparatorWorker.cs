using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi.Classes {
    public class EnvComparatorWorker {
        public string localRefHost;
        public string localRefPath;
        public string localInputHost;
        public string localInputPath;

        public EnvComparatorWorker(string refHost, string refPath, string inputHost, string inputPath) {
            localRefHost = refHost;
            localRefPath = refPath;
            localInputHost = inputHost;
            localInputPath = inputPath;
        }
    }
}
