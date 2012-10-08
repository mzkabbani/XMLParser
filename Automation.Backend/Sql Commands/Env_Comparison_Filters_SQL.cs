using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Env_Comparison_Filters_SQL {

        public static string commandSelectComparisonFilterById = "SELECT     * " +
                                                                  "FROM         Env_Comparison_Filters " +
                                                                  "Where id = @id";

        public static string commandSelectAllComparisonFilters = "SELECT     * " +
                                                                  "FROM         Env_Comparison_Filters";

        public static string commandInsertNewComparisonFilter = "INSERT INTO Env_Comparison_Filters " +
                                                                 "(name, description, filter, userid, filterType,isFolderDeletion,"+
        														 "filterScript,exclusionList,dateAdded) " +
                                                                 "VALUES     (@name, @description, @filter, @userid, @filterType, "+
        														 "@isFolderDeletion,@filterScript,@exclusionList,@dateAdded)";

        public static string commandUpdateComparisonFilterById = "UPDATE    Env_Comparison_Filters " +
                                                             "SET name =@name, description =@description, filter =@filter, filterType =@filterType"+
        													 " filterScript=@filterScript, exclusionList=@exclusionList,isFolderDeletion=@isFolderDeletion ,dateModified=@dateModified , modifiedByUserId=@modifiedByUserId " +
                                                             "Where id =@id";

        public static string commandSelectMaxComparisonFilter = "SELECT MAX(id) " +
                                                          "FROM Env_Comparison_Filters";

    }
}
