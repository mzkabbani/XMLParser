using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Form_Updated_SQL {

        public static string commandSelectAllFormInfo = "SELECT     formName, id, formStatus, formUpdated " +
                                                      "FROM         Form_Updated";

        public static string commandGetFormCount = "SELECT     COUNT(*) AS Expr1 " +
                                                   "FROM         Form_Updated " +
                                                   "WHERE     (formName LIKE '%@formName%') ";

        public static string commandGetFormStatus = "SELECT     formStatus " +
                                                   "FROM         Form_Updated " +
                                                   "WHERE     (formName LIKE '%@formName%') ";

        public static string commandInsertIntoFormInfo = "INSERT INTO Form_Updated " +
                                                         "(formName, formStatus, formUpdated) " +
                                                         "VALUES     (@formName, @formStatus, @formUpdated) ";

    }
}
