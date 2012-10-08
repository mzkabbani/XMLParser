using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Simple_Recommendation_SQL {

        public static string commandInsertNewSimpleRec = "INSERT INTO " +
                                                        "Simple_Recommendation (SR_name, SR_isRegex, SR_description, SR_pattern, SR_replacement, SR_fileName) " +
                                                        "VALUES (@SR_name, @SR_isRegex, @SR_description, @SR_pattern, @SR_replacement, @SR_fileName)";

        public static string commandMaxSimpleRecommendationId = "SELECT MAX(id) " +
                                                                "FROM Simple_Recommendation";

        public static string commandGetAllSimpleRecommendations = "SELECT * " +
                                                                  "FROM Simple_Recommendation";

        public static string commandUpdateSimpleRecByName = "UPDATE    Simple_Recommendation " +
                                                            "SET  SR_name=@SR_name, SR_isRegex= @SR_isRegex , SR_description= @SR_description, SR_pattern= @SR_pattern , SR_replacement = @SR_replacement, SR_fileName = @SR_fileName " +
                                                            "WHERE id=@id ";

        public static string commandGetSimpleRecIdByName = "SELECT id " +
                                                           "FROM Simple_Recommendation " +
                                                           "WHERE SR_name=@SR_name ";

    }
}
