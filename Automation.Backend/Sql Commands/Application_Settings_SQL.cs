using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Application_Settings_SQL {

        public static string commandGetAllAppConfig = "SELECT * " +
                                                    "FROM Application_Settings";

        public static string commandUpdateAppConfigByName = "UPDATE    Application_Settings " +
                                                            "SET       settingValue = @settingValue " +
                                                            "WHERE settingName = @settingName";

        public static string commandSelectFromAppConfigByKey = "SELECT settingValue " +
                                                               "FROM Application_Settings " +
                                                               "WHERE id = @id";

    }
}
