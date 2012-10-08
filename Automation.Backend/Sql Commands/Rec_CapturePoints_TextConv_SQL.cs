using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Rec_CapturePoints_TextConv_SQL {

        public static string commandRemoveAllCapturePointsByRecIdTextConv = "Delete From Rec_CapturePoints_TextConv where pointRecId = @pointRecId";

        public static string commandInsertCapturePointTextConv = "INSERT INTO " +
                                                 "Rec_CapturePoints_TextConv (pointText, pointUsedAttributes, pointParentNode,pointUsedAttribValues,pointRecId,Level,ItemIndex,parentLevel,parentIndex ) " +
                                                 "VALUES (@pointText, @pointUsedAttributes, @pointParentNode, @pointUsedAttribValues, @pointRecId,@Level,@ItemIndex,@parentLevel,@parentIndex)";

        public static string commandMaxRecommendationIdTextConv = "SELECT MAX(id) " +
                                                          "FROM Advanced_Recomendations_TextConv";

        public static string commandMaxCapturePointIdTextConv = "SELECT MAX(id) " +
                                                        "FROM Rec_CapturePoints_TextConv";

        public static string commandGetAllRespectiveCapturePointsTextConv = "SELECT Rec_CapturePoints_TextConv.pointText, Rec_CapturePoints_TextConv.pointUsedAttributes, Rec_CapturePoints_TextConv.pointParentNode, " +
                                                                    " Rec_CapturePoints_TextConv.pointUsedAttribValues, Rec_CapturePoints_TextConv.Level ,Rec_CapturePoints_TextConv.ItemIndex ,Rec_CapturePoints_TextConv.parentLevel ,Rec_CapturePoints_TextConv.parentIndex \n" +
                                                                   "FROM Advanced_Recomendations_TextConv INNER JOIN  Rec_CapturePoints_TextConv ON Advanced_Recomendations_TextConv.id = Rec_CapturePoints_TextConv.pointRecId \n" +
                                                                   "WHERE (Rec_CapturePoints_TextConv.pointRecId = @pointRecId)";




    }
}
