using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Common {
    public class FormInfo {

        public enum formStatus {
            Active = 1,
            Disabled = 2,
        }

        public string localFormName, localFormUpdated;
        public int localFormStatus;

        public FormInfo(string formName, int formStatus, string formUpdated) {
            localFormName = formName;
            localFormStatus = formStatus;
            localFormUpdated = formUpdated;
        }

    }
}
