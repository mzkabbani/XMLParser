using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Advanced_Recomendations_TextConv_SQL {
        public static string commandUpdateRecommendationUsageCountByIdTextConv = "UPDATE    Advanced_Recomendations_TextConv " +
                                                        "SET       usageCount =@usageCount  " +
                                                        "Where id = @id";


        public static string commandUpdateRecommendationByIdTextConv = "UPDATE    Advanced_Recomendations_TextConv " +
                                                               "SET       name =@name, description =@description , event_text = @event_text , categoryId =@categoryId , userId =@userId , usageCount =@usageCount  " +
                                                               "Where id = @id";

        public static string commandCountRecommendationsTextConv = "SELECT COUNT(*) AS Expr1" +
                                                            "FROM   (SELECT DISTINCT Advanced_Recomendations_TextConv.id" +
                                                            "FROM  Advanced_Recomendations_TextConv " +
                                                            "INNER JOIN " +
                                                            "Rec_CapturePoints_TextConv ON Advanced_Recomendations_TextConv.id = Rec_CapturePoints.pointRecId) AS derivedtbl_1";

        public static string commandGetAllrecommendationsTextConv = "SELECT * " +
                                                            "FROM Advanced_Recomendations_TextConv " +
                                                            "Where isEnabled=1";


        public static string commandInsertRecommendationTextConv = "INSERT INTO " +
                                                            "Advanced_Recomendations_TextConv    (name, description, event_text, categoryId, usageCount, userId,isEnabled) " +
                                                            "VALUES (@name,@description,@eventText, @categoryId, @usageCount, @userId,1)";

        public static string commandSelectAdvancedRecByIdTextConv = "Select * " +
                                                            "From Advanced_Recomendations_TextConv " +
                                                            "Where id=@id";

        public static string commandSelectSumOfAllAdvancedRecUsageTextConv = "SELECT     SUM(usageCount) AS Total " +
                                                                             "FROM         Advanced_Recomendations_TextConv " +
                                                                             "Where isEnabled=1";

        public static string commandDisableAdvancedRecTextConv = "UPDATE    Advanced_Recomendations_TextConv " +
                                                                 "SET              isEnabled = @isEnabled " +
                                                                 "WHERE     ( id=@id)";


             public static string     commandMaxRecommendationIdTextConv =                "SELECT MAX(id) " +
                                                       "FROM Advanced_Recomendations_TextConv";
    
    }
}
