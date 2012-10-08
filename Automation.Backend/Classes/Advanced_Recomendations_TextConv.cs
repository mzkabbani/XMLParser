using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using Automation.Common.Utils;
using Automation.Common;
using System.Data;

namespace Automation.Backend{
    public static class Advanced_Recomendations_TextConv {

        private static int InsertRecommendationForTextConversion(AdvancedRecomendation captureEvent) {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            int value = 0;
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(Advanced_Recomendations_TextConv_SQL.commandInsertRecommendationTextConv, conn);
                command.Parameters.Add("@name", captureEvent.CaptureEventName);
                command.Parameters.Add("@description", captureEvent.CaptureEventDescription);
                command.Parameters.Add("@eventText", captureEvent.CaptureEventEventText);
                // @categoryId, @usageCount
                command.Parameters.Add("@categoryId", captureEvent.captureEventCategory);
                command.Parameters.Add("@usageCount", captureEvent.captureEventUsageCount);
                command.Parameters.Add("@userId", FrontendUtils.LoggedInUserId);
                value = Convert.ToInt32(command.ExecuteNonQuery());
                SqlCeCommand commandMaxId = new SqlCeCommand(Advanced_Recomendations_TextConv_SQL.commandMaxRecommendationIdTextConv, conn);
                value = Convert.ToInt32(commandMaxId.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return value;
        }

       
        public static int InsertCaptureEventForTextConversion(AdvancedRecomendation captureEvent, ReplacementEvent replacementEvent) {
            int returnCode = -1;
            int RecommendationId = InsertRecommendationForTextConversion(captureEvent);
            int CapturePointId = Rec_CapturePoints_TextConv.InsertCapturePointsForTextConversion(RecommendationId, captureEvent.CaptureEventCapturePointsList);
            replacementEvent.capturePointId = RecommendationId;
            Advanced_Replacements_TextConv.InsertNewReplacementForTextConversion(replacementEvent);
            return returnCode;
        }

        private static AdvancedRecomendation GetCaptureEventItemForTextConverion(DataRow advancedRecRow, DataTable capturePointsTable, SqlCeConnection conn) {
            List<CustomTreeNode> customCapturePointList = BackEndUtils.GetCustomCapturePointListFromTable(capturePointsTable);
            AdvancedRecomendation capture = new AdvancedRecomendation(Convert.ToInt32(advancedRecRow["id"]), advancedRecRow["name"].ToString(), advancedRecRow["description"].ToString(), advancedRecRow["event_text"].ToString(), Convert.ToInt32(advancedRecRow["categoryId"]), Convert.ToInt32(advancedRecRow["usageCount"]), customCapturePointList, FrontendUtils.LoggedInUserId);
            capture.Replacement = Advanced_Replacements_TextConv.GetReplacementEventByCaptureEventIdForTextConverion(capture.CaptureEventId, conn);
            return capture;
        }

        public static List<AdvancedRecomendation> GetAllAdvancedRecsAsListTextConv() {
            List<AdvancedRecomendation> allCaptureEvens = new List<AdvancedRecomendation>();
            DataTable advancedRexTable = new DataTable();
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            SqlCeCommand getAllRecsCommand = new SqlCeCommand(Advanced_Recomendations_TextConv_SQL.commandGetAllrecommendationsTextConv, conn);
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(Advanced_Recomendations_TextConv_SQL.commandGetAllrecommendationsTextConv, conn)) {
                    adapter.Fill(dataTable);
                }
                for (int i = 0; i < dataTable.Rows.Count; i++) {
                    DataTable capturePointsTable = Rec_CapturePoints_TextConv.GetRespectiveCapturePointsForTextConversion(dataTable.Rows[i].ItemArray[6], conn);
                    allCaptureEvens.Add(GetCaptureEventItemForTextConverion(dataTable.Rows[i], capturePointsTable, conn));
                }
            } finally {
                conn.Close();
            }
            return allCaptureEvens;
        }

        public static void DisableAdvanceRecById(int advanceRecId) {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(Advanced_Recomendations_TextConv_SQL.commandDisableAdvancedRecTextConv, conn);
                command.Parameters.Add("@id", advanceRecId);
                command.Parameters.Add("@isEnabled", "0");
                command.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
        }

     

        public static void SaveCaptureEventByIdForTextConversion(int captureEventId, AdvancedRecomendation captureEvent, ReplacementEvent replacementEvent) {
            SqlCeTransaction transaction;
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                transaction = conn.BeginTransaction();
                try {
                    UpdateRecommendationByIdForTextConversion(captureEventId, captureEvent, conn, transaction);
                    Rec_CapturePoints_TextConv.DeletAllRespectiveCapturePointsForTextConversion(captureEventId, conn, transaction);
                    Rec_CapturePoints_TextConv.InsertCapturePointsAsTransactionForTextConversion(captureEventId, captureEvent.CaptureEventCapturePointsList, conn, transaction);
                    replacementEvent.capturePointId = captureEventId;
                    Advanced_Replacements_TextConv.SaveReplacementEventForTextConversion(replacementEvent, conn, transaction);
                    transaction.Commit();
                } catch (Exception ex) {
                    FrontendUtils.LogError(ex.Message, ex);
                    transaction.Rollback();
                }
            } finally {
                conn.Close();
            }
        }

        private static void UpdateRecommendationByIdForTextConversion(int captureEventId, AdvancedRecomendation captureEvent, SqlCeConnection conn, SqlCeTransaction transaction) {
            int value = 0;
            SqlCeCommand command = new SqlCeCommand(Advanced_Recomendations_TextConv_SQL.commandUpdateRecommendationByIdTextConv, conn);
            command.Transaction = transaction;
            command.Parameters.Add("@name", captureEvent.CaptureEventName);
            command.Parameters.Add("@description", captureEvent.CaptureEventDescription);
            command.Parameters.Add("@event_text", captureEvent.CaptureEventEventText);
            command.Parameters.Add("@id", captureEventId);
            command.Parameters.Add("@categoryId", captureEvent.captureEventCategory);
            command.Parameters.Add("@usageCount", captureEvent.captureEventUsageCount);
            command.Parameters.Add("@userId", FrontendUtils.LoggedInUserId);
            value = Convert.ToInt32(command.ExecuteNonQuery());
        }




    }
}
