using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OracleConfigAlterations {
    public  class ConfigFileNickname : ConfigFile {
        public string nickname;
        public string referenceNickname;
        public string dumpId;
        public List<string> testParameters;
        public string bcps;
        public bool isBaseNickname;
        public string oldXmlRepresentation;
        public string newXmlRepresentation;
    }
}
