using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Env_Comparison_Categories_SQL {

        public static string commandSelectAllEnvComparisonCategory = "SELECT      " +
                                                                   "id,name, description, path, parentid " +
                                                                   "FROM " +
                                                                   "Env_Comparison_Categories ";

        public static string commandSelectEnvComparisonCategoryById = "SELECT      " +
                                                                      "name,description, path, parentid " +
                                                                      "FROM " +
                                                                      "Env_Comparison_Categories " +
                                                                      "Where " +
                                                                      "id = @id";

        public static string commandInsertNewEnvComparisonCategory = "INSERT INTO  " +
                                                                     "Env_Comparison_Categories " +
                                                                     "(id,name,description, path, parentid) " +
                                                                     "VALUES " +
                                                                     "(@id, @name, @description, @path, @parentid) ";

        public static string commandUpdateEnvComparisonCategoryById = "UPDATE     " +
                                                                      "Env_Comparison_Categories " +
                                                                      "SET               " +
                                                                      "name =@name, description =@description, path =@path, parentid = @parentid " +
                                                                      "Where  " +
                                                                      "id = @id ";

        public static string commandDeleteAllEnvCategories = "Delete From Env_Comparison_Categories";
        public static string commandDeleteEnvCategoryById = "Delete From Env_Comparison_Categories Where id=@id";

    }
}
