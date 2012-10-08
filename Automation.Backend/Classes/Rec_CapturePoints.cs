using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Common;
using System.Data.SqlServerCe;
using System.Data;

namespace Automation.Backend{
    public class Rec_CapturePoints {

        public static int InsertCapturePointsAsTransaction(int RecommendationId, List<CustomTreeNode> customNodesList, SqlCeConnection conn, SqlCeTransaction transaction) {
            int returnCode = -1;
            List<int> capturePointsIds = new List<int>();
            for (int i = 0; i < customNodesList.Count; i++) {
                SqlCeCommand command = new SqlCeCommand(Rec_CapturePoints_SQL.commandInsertCapturePoint, conn);
                command.Transaction = transaction;
                //@pointText, @pointUsedAttributes, @pointParentNode, @pointUsedAttribValues, @pointRecId
                command.Parameters.Add("@pointText", customNodesList[i].Text);
                command.Parameters.Add("@pointUsedAttributes", BackEndUtils.GetUsedAttributes(customNodesList[i].customizedAttributeCollection));
                command.Parameters.Add("@pointParentNode", (customNodesList[i].Parent == null ? "" : customNodesList[i].Parent.Text));
                command.Parameters.Add("@pointUsedAttribValues", BackEndUtils.GetUsedAttributesValues(customNodesList[i].customizedAttributeCollection));
                command.Parameters.Add("@pointRecId", RecommendationId);
                command.Parameters.Add("@Level", customNodesList[i].Level);
                command.Parameters.Add("@ItemIndex", customNodesList[i].Index);
                command.Parameters.Add("@parentLevel", customNodesList[i].Parent == null ? -1 : customNodesList[i].Parent.Level);
                command.Parameters.Add("@parentIndex", customNodesList[i].Parent == null ? -1 : customNodesList[i].Parent.Index);

                
                returnCode = Convert.ToInt32(command.ExecuteNonQuery());
                SqlCeCommand commandMaxId = new SqlCeCommand(Rec_CapturePoints_SQL.commandMaxCapturePointId, conn);
                capturePointsIds.Add(Convert.ToInt32(commandMaxId.ExecuteScalar()));
            }
            return returnCode;
        }

        public static void DeletAllRespectiveCapturePoints(int captureEventId, SqlCeConnection conn, SqlCeTransaction transaction) {
            //pointRecId
            int value = 0;
            SqlCeCommand command = new SqlCeCommand(Rec_CapturePoints_SQL.commandRemoveAllCapturePointsByRecId, conn);
            command.Transaction = transaction;
            command.Parameters.Add("@pointRecId", captureEventId);
            value = Convert.ToInt32(command.ExecuteNonQuery());
        }


        public static int InsertCapturePoints(int RecommendationId, List<CustomTreeNode> customNodesList) {
            int returnCode = -1;
            List<int> capturePointsIds = new List<int>();
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                for (int i = 0; i < customNodesList.Count; i++) {
                    SqlCeCommand command = new SqlCeCommand(Rec_CapturePoints_SQL.commandInsertCapturePoint, conn);
                    //@pointText, @pointUsedAttributes, @pointParentNode, @pointUsedAttribValues, @pointRecId
                    command.Parameters.Add("@pointText", customNodesList[i].Text);
                    command.Parameters.Add("@pointUsedAttributes", BackEndUtils.GetUsedAttributes(customNodesList[i].customizedAttributeCollection));
                    command.Parameters.Add("@pointParentNode", (customNodesList[i].Parent == null ? "" : customNodesList[i].Parent.Text));
                    command.Parameters.Add("@pointUsedAttribValues", BackEndUtils.GetUsedAttributesValues(customNodesList[i].customizedAttributeCollection));
                    command.Parameters.Add("@pointRecId", RecommendationId);
                    command.Parameters.Add("@Level", customNodesList[i].Level);
                    command.Parameters.Add("@ItemIndex", customNodesList[i].Index);
                     command.Parameters.Add("@parentLevel", customNodesList[i].Parent == null ? -1 : customNodesList[i].Parent.Level);
                    command.Parameters.Add("@parentIndex", customNodesList[i].Parent == null ? -1 : customNodesList[i].Parent.Index);

                    returnCode = Convert.ToInt32(command.ExecuteNonQuery());
                    SqlCeCommand commandMaxId = new SqlCeCommand(Rec_CapturePoints_SQL.commandMaxCapturePointId, conn);
                    capturePointsIds.Add(Convert.ToInt32(commandMaxId.ExecuteScalar()));
                }
            } finally {
                conn.Close();
            }
            return returnCode;
        }

        public static DataTable GetRespectiveCapturePoints(object advancedRecId, SqlCeConnection conn) {
            DataTable dataTable = new DataTable();//pointRecId
            SqlCeCommand command = new SqlCeCommand(Rec_CapturePoints_SQL.commandGetAllRespectiveCapturePoints, conn);
            command.Parameters.Add("@pointRecId", Convert.ToInt32(advancedRecId));
            using (SqlCeDataAdapter adapter2 = new SqlCeDataAdapter(command)) {
                adapter2.Fill(dataTable);
            }
            return dataTable;
        }

    }
}
