using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Common.Classes.Monitoring;
using System.Data.SqlServerCe;
using Automation.Backend.Sql_Commands;

namespace Automation.Backend.Classes {
    public static class Monitor {

        public static void InsertNewMonitorObject() {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            int value = 0;
            try {
                conn.Open();
                int sessionID = User_Sessions.InsertNewUserSession(conn);
                for (int i = 0; i < MonitorObject.formAndAccessTime.Count; i++) {
                    SqlCeCommand command = new SqlCeCommand(Monitor_SQL.commandInsertNewMonitor, conn);
                    command.Parameters.Add("@formName", MonitorObject.formAndAccessTime[i].formName);
                    command.Parameters.Add("@accessTime", MonitorObject.formAndAccessTime[i].AccessTime);
                    command.Parameters.Add("@userName", MonitorObject.username);
                    command.Parameters.Add("@sessionID", sessionID);
                    value = Convert.ToInt32(command.ExecuteNonQuery());
                }
            } finally {
                conn.Close();
            }

        }

    }
}
