using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Automation.Common;
using System.Data.SqlServerCe;
using System.Data;

namespace Automation.Backend{
    public class Simple_Recommendation {

        public static int InsertNewSimpleRecommendation(SimpleRecommendationObject newRecObj) {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            int value = 0;
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(Simple_Recommendation_SQL.commandInsertNewSimpleRec, conn);
                command.Parameters.Add("@SR_name", newRecObj.optionName);
                command.Parameters.Add("@SR_isRegex", newRecObj.isRegex.ToString());
                command.Parameters.Add("@SR_description", newRecObj.description);
                command.Parameters.Add("@SR_pattern", newRecObj.pattern);
                command.Parameters.Add("@SR_replacement", newRecObj.replacement);
                command.Parameters.Add("@SR_fileName", newRecObj.fileName);
                value = Convert.ToInt32(command.ExecuteNonQuery());
                SqlCeCommand commandMaxId = new SqlCeCommand(Simple_Recommendation_SQL.commandMaxSimpleRecommendationId, conn);
                value = Convert.ToInt32(commandMaxId.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return value;
        }


        public static List<SimpleRecommendationObject> GetAllSimpleRecsAsList() {
            List<SimpleRecommendationObject> simpleRecommendationObjects = new List<SimpleRecommendationObject>();
            DataTable advancedRexTable = new DataTable();
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            SqlCeCommand getAllRecsCommand = new SqlCeCommand(Simple_Recommendation_SQL.commandGetAllSimpleRecommendations, conn);
            DataTable dataTable = new DataTable();
            try {
                conn.Open();
                using (SqlCeDataAdapter adapter = new SqlCeDataAdapter(Simple_Recommendation_SQL.commandGetAllSimpleRecommendations, conn)) {
                    adapter.Fill(dataTable);
                }
                for (int i = 0; i < dataTable.Rows.Count; i++) {
                    // DataTable capturePointsTable = GetRespectiveCapturePoints(dataTable.Rows[i].ItemArray[0], conn);
                    object[] itemArray = dataTable.Rows[i].ItemArray;
                    SimpleRecommendationObject simpleRec = new SimpleRecommendationObject();
                    simpleRec.optionName = itemArray[1] as string;
                    simpleRec.isRegex = string.Equals((itemArray[2] as string), "True");
                    simpleRec.description = itemArray[3] as string;
                    simpleRec.pattern = itemArray[4] as string;
                    simpleRec.replacement = itemArray[5] as string;
                    simpleRec.fileName = itemArray[6] as string;
                    simpleRecommendationObjects.Add(simpleRec);
                }
            } finally {
                conn.Close();
            }
            return simpleRecommendationObjects;
        }

        public static void UpdateSimpleRecByName(SimpleRecommendationObject newRecObj, string newName) {
            int simpleRecId = GetSimpleRecIdByName(newRecObj.optionName);
            UpdateSimpleRecById(simpleRecId, newRecObj, newName);
        }

        private static void UpdateSimpleRecById(int simpleRecId, SimpleRecommendationObject newRecObj, string newName) {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(Simple_Recommendation_SQL.commandUpdateSimpleRecByName, conn);
                command.Parameters.Add("@SR_name", newName);
                command.Parameters.Add("@SR_isRegex", newRecObj.isRegex.ToString());
                command.Parameters.Add("@SR_description", newRecObj.description);
                command.Parameters.Add("@SR_pattern", newRecObj.pattern);
                command.Parameters.Add("@SR_replacement", newRecObj.replacement);
                command.Parameters.Add("@SR_fileName", newRecObj.fileName);
                command.Parameters.Add("@id", simpleRecId);
                command.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
        }

        private static int GetSimpleRecIdByName(string optionName) {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            int value = 0;
            try {
                conn.Open();
                SqlCeCommand commandRecIdByName = new SqlCeCommand(Simple_Recommendation_SQL.commandGetSimpleRecIdByName, conn);
                commandRecIdByName.Parameters.Add("@SR_name", optionName);
                value = Convert.ToInt32(commandRecIdByName.ExecuteScalar());
            } finally {
                conn.Close();
            }
            return value;
        }

    }
}
