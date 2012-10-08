using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Backend{
    public static class Folder_Names_SQL {
        public static string commandGetAllFolderNamesTable = "SELECT * " +
                                                               "FROM Folder_Name";

        public static string commandDeleteAllFolderNames = "DELETE " +
                                                           "FROM Folder_Name";

        public static string commandInsertFolderName = "INSERT INTO Folder_Name " +
                                                       "(id, folderName, parentId, generatedID ) " +
                                                       "VALUES (@id, @folderName, @parentId, @generatedID)";

    }
}
