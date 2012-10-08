using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using Automation.Common;
using System.Data;

namespace Automation.Backend{
    public class Advanced_Replacements_TextConv {


        public static DataSet GetAvailableReplacementsAsDatasetForTextConversion(int captureEventId, SqlCeConnection conn) {
            SqlCeCommand getAllReplacementsByCaptureIDCommand = new SqlCeCommand(Advanced_Replacements_TextConv_SQL.commandGetCapturePointReplacementsTextConv, conn);
            getAllReplacementsByCaptureIDCommand.Parameters.Add("@capturePointId", captureEventId);
            DataSet dataSet = new DataSet();
            SqlCeDataAdapter da = new SqlCeDataAdapter(getAllReplacementsByCaptureIDCommand);
            SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
            da.Fill(dataSet);
            return dataSet;
        }


        public static void SaveReplacementEventForTextConversion(ReplacementEvent replacementEvent, SqlCeConnection conn, SqlCeTransaction transaction) {

            SqlCeCommand command = new SqlCeCommand(Advanced_Replacements_TextConv_SQL.commandUpdateReplacementByIdTextConv, conn);
            command.Transaction = transaction;
            command.Parameters.Add("@name", replacementEvent.name);
            command.Parameters.Add("@description", replacementEvent.description);
            command.Parameters.Add("@value", replacementEvent.Value);
            command.Parameters.Add("@typeId", replacementEvent.typeId);
            command.Parameters.Add("@capturePointId", replacementEvent.capturePointId);
            command.Parameters.Add("@userId", replacementEvent.userId);
            command.Parameters.Add("@usageCount", replacementEvent.usageCount);
            command.Parameters.Add("@id", replacementEvent.id);
            command.ExecuteNonQuery();

        }       

      

        public static ReplacementEvent GetReplacementEventByCaptureEventIdForTextConverion(int captureEventId, SqlCeConnection conn) {
            List<ReplacementEvent> replacements = GetAvailableReplacementsByCaptureIdForTextConversion(captureEventId, conn);
            return replacements[0];
        }

        public static List<ReplacementEvent> GetAvailableReplacementsByCaptureIdForTextConversion(int captureEventId, SqlCeConnection conn) {
            //commandGetCapturePointReplacements
            List<ReplacementEvent> replacementEvents = new List<ReplacementEvent>();
            DataSet availableReplacementsAsDataset = GetAvailableReplacementsAsDatasetForTextConversion(captureEventId, conn);
            foreach (DataRow row in availableReplacementsAsDataset.Tables[0].Rows) {
                ReplacementEvent repEvent = new ReplacementEvent(Convert.ToInt32(row["id"]),
                                                                 Convert.ToInt32(row["userId"]),
                                                                 row["name"].ToString(),
                                                                 row["description"].ToString(),
                                                                 row["value"].ToString(),
                                                                 Convert.ToInt32(row["typeId"]),
                                                                 Convert.ToInt32(row["capturePointId"]),
                                                                 Convert.ToInt32(row["usageCount"]));
                replacementEvents.Add(repEvent);
            }
            return replacementEvents;
        }

        public static int InsertNewReplacementForTextConversion(ReplacementEvent replacementEvent) {
            int replacementId = 0;
            int numberAffectedRows = 0;
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(Advanced_Replacements_TextConv_SQL.commandInsertReplacementTextConv, conn);
                command.Parameters.Add("@name", replacementEvent.name);
                command.Parameters.Add("@description", replacementEvent.description);
                command.Parameters.Add("@value", replacementEvent.Value);
                command.Parameters.Add("@typeId", replacementEvent.typeId);
                command.Parameters.Add("@capturePointId", replacementEvent.capturePointId);
                command.Parameters.Add("@userId", replacementEvent.userId);
                command.Parameters.Add("@usageCount", replacementEvent.usageCount);
                numberAffectedRows = Convert.ToInt32(command.ExecuteNonQuery());
                SqlCeCommand commandMaxId = new SqlCeCommand(Advanced_Replacements_TextConv_SQL.commandMaxReplacementIdTextConv, conn);
                replacementId = Convert.ToInt32(commandMaxId.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return replacementId;
        }
    
    }
}
