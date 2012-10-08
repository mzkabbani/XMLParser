using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Advanced_Replacements_SQL {
        public static string commandGetAllAdvancedReplacements = "SELECT     id, name, description, value, typeId, capturePointId, userId, AF1, AF2, AF3, AF4, usageCount " +
                                                                  "FROM         Advanced_Replacements ";

        public static string commandGetCapturePointReplacements = "SELECT     id, name, description, value, typeId, capturePointId,userId, AF1, AF2, AF3, AF4, usageCount " +
                                                                 "FROM         Advanced_Replacements " +
                                                                 "WHERE capturePointId = @capturePointId ";

        public static string commandInsertReplacement = "INSERT INTO Advanced_Replacements " +
                                                        "(name, description, value, typeId, capturePointId, userId, AF1, AF2, AF3, AF4,usageCount) " +
                                                        "VALUES     (@name ,@description ,@value ,@typeId ,@capturePointId ,@userId ,NULL ,NULL ,NULL ,NULL,@usageCount )";

        public static string commandUpdateReplacementById = "UPDATE    Advanced_Replacements " +
                                                        "SET              name =@name, description =@description, value =@value, typeId =@typeId, capturePointId =@capturePointId, userId =@userId, AF1 =NULL, AF2 =NULL, AF3 =NULL, AF4 =NULL,usageCount = @usageCount " +
                                                        "WHERE id = @id ";

        public static string commandMaxReplacementId = "SELECT MAX(id) " +
                                                       "FROM Advanced_Replacements";

        public static string commandSelectSumOfAllReplacementUsage = "SELECT     SUM(usageCount) AS Total " +
                                                                    "FROM         Advanced_Replacements " +
        														    "Where capturePointId=@capturePointId";

    
	 public static string commandUpdateReplacementUsageCountById = "UPDATE    Advanced_Replacements " +
                                                             "SET       usageCount =@usageCount  " +
                                                             "Where id = @id";
	}
}
