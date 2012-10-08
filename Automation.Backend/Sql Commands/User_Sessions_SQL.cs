using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend.Sql_Commands {
    public static class User_Sessions_SQL {
    
        public static string commandInsertNewUserSession = "INSERT INTO User_Sessions "+
                      "(userName, loginTime, logoutTime) "+
                      "VALUES     (@userName, @loginTime, @logoutTime)";

        public static string commandMaxId = "Select MAX(id) from User_Sessions";

    }
}
