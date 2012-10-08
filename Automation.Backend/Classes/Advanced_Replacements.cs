using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Automation.Common;
using System.Data.SqlServerCe;
using Automation.Common.Utils;

namespace Automation.Backend {
    public static class Advanced_Replacements {

        public static ReplacementEvent GetReplacementEventByCaptureEventId(int captureEventId, SqlCeConnection conn) {
            List<ReplacementEvent> replacements = GetAvailableReplacementsByCaptureId(captureEventId, conn);
            return replacements.Count > 0 ? replacements[0] : null;
        }

        public static int GetTotalAdvanceReplacementUsageCount(int captureEventId) {
            int total = 0;
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            SqlCeCommand command = new SqlCeCommand(Advanced_Replacements_SQL.commandSelectSumOfAllReplacementUsage, conn);
            try {
                conn.Open();
                command.Parameters.AddWithValue("@capturePointId",captureEventId);
                total = Convert.ToInt32(command.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return total;
        }

        public static int InsertNewReplacement(ReplacementEvent replacementEvent) {
            int replacementId = 0;
            int numberAffectedRows = 0;
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(Advanced_Replacements_SQL.commandInsertReplacement, conn);
                command.Parameters.Add("@name", replacementEvent.name);
                command.Parameters.Add("@description", replacementEvent.description);
                command.Parameters.Add("@value", replacementEvent.Value);
                command.Parameters.Add("@typeId", replacementEvent.typeId);
                command.Parameters.Add("@capturePointId", replacementEvent.capturePointId);
                command.Parameters.Add("@userId", replacementEvent.userId);
                command.Parameters.Add("@usageCount", replacementEvent.usageCount);
                numberAffectedRows = Convert.ToInt32(command.ExecuteNonQuery());
                SqlCeCommand commandMaxId = new SqlCeCommand(Advanced_Replacements_SQL.commandMaxReplacementId, conn);
                replacementId = Convert.ToInt32(commandMaxId.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return replacementId;
        }


        public static List<ReplacementEvent> GetAvailableReplacementsByCaptureId(int captureEventId, SqlCeConnection conn) {
            //commandGetCapturePointReplacements
            List<ReplacementEvent> replacementEvents = new List<ReplacementEvent>();
            if (conn.State == ConnectionState.Open) {
                DataSet availableReplacementsAsDataset = GetAvailableReplacementsAsDataset(captureEventId, conn);
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
            } else {
                try {
                    conn.Open();
                    DataSet availableReplacementsAsDataset = GetAvailableReplacementsAsDataset(captureEventId, conn);
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
                } finally {
                    conn.Close();
                }
            }
            return replacementEvents;
        }


        private static DataSet GetAvailableReplacementsAsDataset(int captureEventId, SqlCeConnection conn) {
            SqlCeCommand getAllReplacementsByCaptureIDCommand = new SqlCeCommand(Advanced_Replacements_SQL.commandGetCapturePointReplacements, conn);
            getAllReplacementsByCaptureIDCommand.Parameters.Add("@capturePointId", captureEventId);
            DataSet dataSet = new DataSet();
            SqlCeDataAdapter da = new SqlCeDataAdapter(getAllReplacementsByCaptureIDCommand);
            SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
            da.Fill(dataSet);
            return dataSet;
        }

        public static void IncrementReplacementsListUsageById( List<ComplexCaptureMatchObject> capturesAndReplacements) {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                for (int i = 0; i < capturesAndReplacements.Count; i++) {
                    SqlCeCommand incrementUsageCount = new SqlCeCommand(Advanced_Replacements_SQL.commandUpdateReplacementUsageCountById,conn);
                    incrementUsageCount.Parameters.Add("@usageCount", capturesAndReplacements[i].usedReplacementEvent.usageCount + 1);
                    incrementUsageCount.Parameters.Add("@id",   capturesAndReplacements[i].usedReplacementEvent.id);
                    object resutlt = incrementUsageCount.ExecuteNonQuery();
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message,ex);
            } finally {
                conn.Close();
            }
        }

        public static void SaveReplacementEvent(ReplacementEvent replacementEvent) {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(Advanced_Replacements_SQL.commandUpdateReplacementById, conn);
                command.Parameters.Add("@name", replacementEvent.name);
                command.Parameters.Add("@description", replacementEvent.description);
                command.Parameters.Add("@value", replacementEvent.Value);
                command.Parameters.Add("@typeId", replacementEvent.typeId);
                command.Parameters.Add("@capturePointId", replacementEvent.capturePointId);
                command.Parameters.Add("@userId", replacementEvent.userId);
                command.Parameters.Add("@usageCount", replacementEvent.usageCount);
                command.Parameters.Add("@id", replacementEvent.id);
                command.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
        }


    }
}
