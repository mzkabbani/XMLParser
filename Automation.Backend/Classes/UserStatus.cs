using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Data;
using Automation.Common.Utils;
using Automation.Common;

namespace Automation.Backend {
    public static class UserStatus {

        public static void UpdateUserStatusById(int userId, bool isLoginEvent) {
            int loginCount = GetLoginCountByUserId(userId);
            //onlineStatus =@onlineStatus, loginCount =@loginCount, lastLogin =@lastLogin"+
            //"WHERE id=@id"
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            SqlCeCommand command = new SqlCeCommand(UserStatus_SQL.commandUpdateUserStatusWithId, conn);
            command.Parameters.Add("@onlineStatus", isLoginEvent ? "Online" : "Offline");
            command.Parameters.Add("@loginCount", isLoginEvent ? (loginCount + 1) : loginCount);
            command.Parameters.Add("@lastLogin", DateTime.Now);
            command.Parameters.Add("@id", userId);
            command.Parameters.Add("@appVersion",GlobalApplicationSettings.ApplicationVersion );
            try {
                conn.Open();
                int returnCode = Convert.ToInt32(command.ExecuteNonQuery());
            } finally {
                conn.Close();
            }
        }

        public static bool IsUserKicked(string userName) {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                SqlCeCommand command = new SqlCeCommand(UserStatus_SQL.commandGetKickedUserByUserName, conn);
                command.Parameters.Add("@username", userName);
                conn.Open();
                int result = Convert.ToInt32(command.ExecuteScalar());
                if (result == 1) {
                    command = new SqlCeCommand(UserStatus_SQL.commandResetKickStatusByUserName, conn);
                    command.Parameters.Add("@username", userName);
                    command.ExecuteNonQuery();
                    return true;
                }


            } catch (Exception ex) {
                FrontendUtils.LogError(ex.Message,ex);
            } finally {
                conn.Close();
            }
            return false;
        }


        public static DataTable GetAllUsersTable() {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(UserStatus_SQL.commandGetAllUsersTable, conn)) {
                    // 3
                    // Use DataAdapter to fill DataTable
                    adapter.Fill(dataTable);
                    // 4
                    // Render data onto the screen
                    // dataGridView1.DataSource = t; // <-- From your designer
                }
            } finally {
                conn.Close();
            }
            return dataTable;
        }

        public static int InsertNewUser(string username) {
            int insertedUserId = -1;
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(UserStatus_SQL.commandInsertNewUser, conn);
                // @username, @onlineStatus, @loginCount, @lastLogin, @firstLogin
                command.Parameters.Add("@username", username);
                command.Parameters.Add("@onlineStatus", "Offline");
                command.Parameters.Add("@loginCount", 1);
                command.Parameters.Add("@lastLogin", DateTime.Now);
                command.Parameters.Add("@firstLogin", DateTime.Now);
                 command.Parameters.Add("@appVersion",GlobalApplicationSettings.ApplicationVersion );
                Convert.ToInt32(command.ExecuteScalar());
                insertedUserId = BackEndUtils.GetMaxId("UserStatus", conn);
            } finally {
                conn.Close();
            }
            return insertedUserId;
        }


        public static int GetLoginCountByUserId(int userId) {
            int selectedLoginCount = -1;
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(UserStatus_SQL.commandGetLoginCountByUserId, conn);
                command.Parameters.Add("@id", userId);
                selectedLoginCount = Convert.ToInt32(command.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return selectedLoginCount;
        }

        public static int GetUserIdByUsername(string username) {
            int selectedUserId = -1;
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(UserStatus_SQL.commandGetUserIdByUserName, conn);
                command.Parameters.Add("@username", username);
                selectedUserId = Convert.ToInt32(command.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return selectedUserId;
        }


        public static DataSet GetAllUsersTableAsDataSet() {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(UserStatus_SQL.commandGetAllUsersTable, conn);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }



    }
}
