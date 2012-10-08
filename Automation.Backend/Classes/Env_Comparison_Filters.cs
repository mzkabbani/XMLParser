using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;

using Automation.Common;
using Automation.Common.Utils;

namespace Automation.Backend {
    public class Env_Comparison_Filters {

        public static int InserNewFilter(EnvComparisonFilter envComparisonFilter) {
            int returnedId = -1;
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(Env_Comparison_Filters_SQL.commandInsertNewComparisonFilter, conn);
                command.Parameters.Add("@name", envComparisonFilter.Name);
                command.Parameters.Add("@description", envComparisonFilter.Description);
                command.Parameters.Add("@filter", envComparisonFilter.FilterPattern);
                command.Parameters.Add("@userid", envComparisonFilter.AddedByUserId);
                command.Parameters.Add("@filterType", envComparisonFilter.FilterType);

                command.Parameters.Add("@dateAdded", DateTime.Now);              
                
                if(envComparisonFilter.FilterType == 2) {
                    command.Parameters.Add("@isFolderDeletion", envComparisonFilter.IsFolderDeletion);
                    command.Parameters.Add("@filterScript", envComparisonFilter.FilterScript);
                    command.Parameters.Add("@exclusionList", envComparisonFilter.ExclusionList);
                }
                int numberAffectedRows = Convert.ToInt32(command.ExecuteNonQuery());
                returnedId =  BackEndUtils.GetMaxId("Env_Comparison_Filters", conn);
            } finally {
                conn.Close();
            }
            return returnedId;
        }

        public static DataSet GetAllAvailableFiltersAsDataset() {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            SqlCeCommand Command = new SqlCeCommand(Env_Comparison_Filters_SQL.commandSelectAllComparisonFilters, conn);
            DataSet dataSet = new DataSet();
            try {
                SqlCeDataAdapter da = new SqlCeDataAdapter(Command);
                SqlCeCommandBuilder cb = new SqlCeCommandBuilder(da);
                da.Fill(dataSet);
            } finally {
                conn.Close();
            }
            return dataSet;
        }

        public static void UpdatedFilterById(EnvComparisonFilter filter) {
            SqlCeConnection conn = BackEndUtils.GetSqlConnection();
            try {
                conn.Open();
                SqlCeCommand command = new SqlCeCommand(Env_Comparison_Filters_SQL.commandUpdateComparisonFilterById, conn);
                command.Parameters.Add("@name", filter.Name);
                command.Parameters.Add("@description", filter.Description);
                command.Parameters.Add("@filter", filter.FilterPattern);               
                command.Parameters.Add("@filterType", filter.FilterType);
                command.Parameters.Add("@id", filter.filterId);
                command.Parameters.Add("@modifiedByUserId",FrontendUtils.LoggedInUserId);                 
                command.Parameters.Add("@dateModified",DateTime.Now);
                   if(filter.FilterType == 2) {
                    command.Parameters.Add("@isFolderDeletion", filter.IsFolderDeletion);
                    command.Parameters.Add("@filterScript", filter.FilterScript);
                    command.Parameters.Add("@exclusionList", filter.ExclusionList);
                }
                command.ExecuteNonQuery();
            } finally {
                conn.Close();
            }
        }

    }
}
