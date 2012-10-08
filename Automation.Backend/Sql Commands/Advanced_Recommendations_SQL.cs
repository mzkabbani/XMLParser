using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Advanced_Recommendations_SQL {

        public static string commandUpdateRecommendationUsageCountById = "UPDATE    Advanced_Recommendations " +
                                                             "SET       usageCount =@usageCount  " +
                                                             "Where id = @id";


        public static string commandUpdateRecommendationById = "UPDATE    Advanced_Recommendations " +
                                                               "SET       name =@name, description =@description , event_text = @event_text , categoryId =@categoryId , userId =@userId , usageCount =@usageCount  " +
                                                               "Where id = @id";

        public static string commandCountRecommendations = "SELECT COUNT(*) AS Expr1" +
                                                            "FROM   (SELECT DISTINCT Advanced_Recommendations.id" +
                                                            "FROM  Advanced_Recommendations " +
                                                            "INNER JOIN " +
                                                            "Rec_CapturePoints ON Advanced_Recommendations.id = Rec_CapturePoints.pointRecId) AS derivedtbl_1";

        public static string commandGetAllrecommendations = "SELECT * " +
                                                            "FROM Advanced_Recommendations "+
        	  												"Where isEnabled=1";


        public static string commandInsertRecommendation = "INSERT INTO " +
                                                            "Advanced_Recommendations    (name, description, event_text, categoryId, usageCount, userId) " +
                                                            "VALUES (@name,@description,@eventText, @categoryId, @usageCount, @userId)";

        public static string commandSelectAdvancedRecById = "Select * " +
                                                            "From Advanced_Recommendations " +
                                                            "Where id=@id";

        public static string commandSelectSumOfAllAdvancedRecUsage = "SELECT     SUM(usageCount) AS Total " +
                                                                     "FROM         Advanced_Recommendations "+
        															 "Where isEnabled=1";

        public static string commandMaxRecommendationId = "SELECT MAX(id) " +
                                                       "FROM Advanced_Recommendations";
    

          public static string commandDisableAdvancedRec = "UPDATE    Advanced_Recommendations " +
                                                                 "SET              isEnabled = @isEnabled " +
                                                                 "WHERE     ( id=@id)";

        
    }
}
