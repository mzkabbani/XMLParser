using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;

namespace Automation.Backend{
    public class Advanced_Recommendation_Categories {


        public static DataTable GetAllCaptureCategoriesAsDataTable() {
            DataTable dataTable = new DataTable();
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            SqlCeCommand command = new SqlCeCommand(Advanced_Recommendation_Categories_SQL.commandGetAllCaptureCategories, conn);
            using (SqlCeDataAdapter adapter2 = new SqlCeDataAdapter(command)) {
                adapter2.Fill(dataTable);
            }
            return dataTable;
        }

        public static DataSet GetAllAdvancedRecCategoriesAsDataset() {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(Advanced_Recommendation_Categories_SQL.commandGetAllCaptureCategories, conn);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

       

    }
}
