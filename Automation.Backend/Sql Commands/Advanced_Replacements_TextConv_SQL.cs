using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Advanced_Replacements_TextConv_SQL {

        public static string commandGetAllAdvancedReplacementsTextConv = "SELECT     id, name, description, value, typeId, capturePointId, userId, AF1, AF2, AF3, AF4, usageCount " +
                                                          "FROM         Advanced_Replacements_TextConv ";

        public static string commandGetCapturePointReplacementsTextConv = "SELECT     id, name, description, value, typeId, capturePointId,userId, AF1, AF2, AF3, AF4, usageCount " +
                                                                 "FROM         Advanced_Replacements_TextConv " +
                                                                 "WHERE capturePointId = @capturePointId ";

        public static string commandInsertReplacementTextConv = "INSERT INTO Advanced_Replacements_TextConv " +
                                                        "(name, description, value, typeId, capturePointId, userId, AF1, AF2, AF3, AF4,usageCount) " +
                                                        "VALUES     (@name ,@description ,@value ,@typeId ,@capturePointId ,@userId ,NULL ,NULL ,NULL ,NULL,@usageCount )";

        public static string commandUpdateReplacementByIdTextConv = "UPDATE    Advanced_Replacements_TextConv " +
                                                        "SET              name =@name, description =@description, value =@value, typeId =@typeId, capturePointId =@capturePointId, userId =@userId, AF1 =NULL, AF2 =NULL, AF3 =NULL, AF4 =NULL,usageCount = @usageCount " +
                                                        "WHERE id = @id ";

        public static string commandMaxReplacementIdTextConv = "SELECT MAX(id) " +
                                                       "FROM Advanced_Replacements_TextConv";

        public static string commandSelectSumOfAllReplacementUsageTextConv = "SELECT     SUM(usageCount) AS Total " +
                                                                    "FROM         Advanced_Replacements_TextConv";


    }
}
