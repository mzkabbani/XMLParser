using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class UserStatus_SQL {
        public static string commandGetUserIdByUserName = "SELECT id " +
                                                      "FROM UserStatus " +
                                                      "WHERE username=@username";

        public static string commandGetKickedUserByUserName = "SELECT isKicked " +
                                                      "FROM UserStatus " +
                                                      "WHERE username=@username";
        
         public static string commandResetKickStatusByUserName = "UPDATE    UserStatus " +
                                                             "SET  isKicked = 0 " +
                                                             "WHERE username=@username ";
        
        public static string commandUpdateUserStatusWithId = "UPDATE    UserStatus " +
                                                             "SET  onlineStatus =@onlineStatus, loginCount =@loginCount, lastLogin =@lastLogin, appVersion=@appVersion " +
                                                             "WHERE id=@id ";

        public static string commandGetAllUsersTable = "SELECT * " +
                                                       "FROM UserStatus";

        public static string commandInsertNewUser = "INSERT INTO " +
                                                    "UserStatus(username, onlineStatus, loginCount, lastLogin, firstLogin, appVersion) " +
                                                    "VALUES  (@username, @onlineStatus, @loginCount, @lastLogin, @firstLogin, @appVersion)";

        public static string commandGetLoginCountByUserId = "SELECT loginCount " +
                                                            "FROM UserStatus " +
                                                            "WHERE id=@id";


    }
}
