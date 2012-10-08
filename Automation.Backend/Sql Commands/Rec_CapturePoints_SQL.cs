using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Rec_CapturePoints_SQL {

        public static string commandRemoveAllCapturePointsByRecId = "Delete From Rec_CapturePoints where pointRecId = @pointRecId";

        public static string commandInsertCapturePoint = "INSERT INTO " +
                                                 "Rec_CapturePoints (pointText, pointUsedAttributes, pointParentNode,pointUsedAttribValues,pointRecId,Level,ItemIndex,parentLevel,parentIndex ) " +
                                                 "VALUES (@pointText, @pointUsedAttributes, @pointParentNode, @pointUsedAttribValues, @pointRecId,@Level,@ItemIndex,@parentLevel,@parentIndex)";

        public static string commandMaxRecommendationId = "SELECT MAX(id) " +
                                                          "FROM Advanced_Recommendations";

        public static string commandMaxCapturePointId = "SELECT MAX(id) " +
                                                        "FROM Rec_CapturePoints";

        public static string commandGetAllRespectiveCapturePoints = "SELECT Rec_CapturePoints.pointText, Rec_CapturePoints.pointUsedAttributes, Rec_CapturePoints.pointParentNode, Rec_CapturePoints.pointUsedAttribValues, Rec_CapturePoints.Level ,Rec_CapturePoints.ItemIndex ,Rec_CapturePoints.parentLevel, Rec_CapturePoints.parentIndex \n" +
                                                                   "FROM Advanced_Recommendations INNER JOIN  Rec_CapturePoints ON Advanced_Recommendations.id = Rec_CapturePoints.pointRecId \n" +
                                                                   "WHERE (Rec_CapturePoints.pointRecId = @pointRecId)";


    }
}
