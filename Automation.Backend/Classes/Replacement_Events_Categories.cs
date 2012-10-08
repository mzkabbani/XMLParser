using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlServerCe;

namespace Automation.Backend{
    public class Replacement_Events_Categories {

        public static DataTable GetAllReplacementCategoriesAsDataTable() {
            DataTable dataTable = new DataTable();
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            SqlCeCommand command = new SqlCeCommand(Replacement_Events_Categories_SQL.commandGetAllReplacementCategories, conn);
            using (SqlCeDataAdapter adapter2 = new SqlCeDataAdapter(command)) {
                adapter2.Fill(dataTable);
            }
            return dataTable;
        }
       

    }
}
