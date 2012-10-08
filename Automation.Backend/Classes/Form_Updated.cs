using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using Automation.Common;

namespace Automation.Backend {
    public class Form_Updated {

        private static int GetFormStatus(string formName, SqlCeConnection conn) {
            int returnCode = -1;
            try {
                SqlCeCommand command = new SqlCeCommand(Form_Updated_SQL.commandGetFormStatus, conn);
                command.Parameters.Add("@formName", formName);
                returnCode = Convert.ToInt32(command.ExecuteScalar());
            } catch (Exception ex) {
            }
            return returnCode;
        }

        public static int InsertFormInfoCheckForFirstUse(string formName) {
            FormInfo formInfo = new FormInfo(formName, (int)FormInfo.formStatus.Active, "True");
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            int returnedFormStatus = -1;
            try {
                conn.Open();
                int foundRows = GetFoundRowsForExistingForm(formName, conn);
                if (foundRows > 0) {
                    returnedFormStatus = GetFormStatus(formName, conn);
                } else {
                    InsertNewFormInfo(formInfo);
                }
            } finally {
                conn.Close();
            }
            return returnedFormStatus;
        }


        private static int GetFoundRowsForExistingForm(string formName, SqlCeConnection conn) {
            int returnCode = -1;
            try {
                SqlCeCommand command = new SqlCeCommand(Form_Updated_SQL.commandGetFormCount, conn);
                command.Parameters.Add("@formName", formName);
                returnCode = Convert.ToInt32(command.ExecuteScalar());
            } catch (Exception ex) {
            }
            return returnCode;
        }

        public static int InsertNewFormInfo(FormInfo formInfo) {
            int numberAffectedRows = 0;
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(Form_Updated_SQL.commandInsertIntoFormInfo, conn);
                command.Parameters.Add("@formName", formInfo.localFormName);
                command.Parameters.Add("@formStatus", FormInfo.formStatus.Active);
                command.Parameters.Add("@formUpdated", "True");
                numberAffectedRows = Convert.ToInt32(command.ExecuteNonQuery());

            } finally {
                conn.Close();
            }
            return numberAffectedRows;
        }



    }
}
