using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OracleConfigAlterations {
    public class ConfigurationObject {

        public string tpkNumber;
        public string branch;
        public bool hasEnv;
        public string envNumber;
        public string nickname;
        public string oldDumpId;
        public string newDumpId;
        public string baseNickname;
        public string ora11MigNickname;
        public string ora11Nickname;

        //Local resources
        public string tpkPublicConfigCheckedOutPath;
        public string tpkMurexConfigCheckedOutPath;
        public string envPublicConfigCheckedOutPath;
        public string envMurexConfigCheckedOutPath;

        public override string ToString() {
            string fullText = string.Empty;

            if (hasEnv) {
                fullText = "PAR.TPK." + tpkNumber + " | PAR.ENV." + envNumber;
            } else {
                fullText = "PAR.TPK." + tpkNumber + " |";
            }
            return fullText;
        }
    }
}
