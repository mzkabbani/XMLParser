using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend.Sql_Commands {
    public static class Monitor_SQL {

        public static string commandInsertNewMonitor = "INSERT INTO Monitor " +
                      "(formName, accessTime, userName, sessionID) " +
                      "VALUES     (@formName, @accessTime, @userName, @sessionID)";


    }
}
