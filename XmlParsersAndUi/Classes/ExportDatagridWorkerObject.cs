using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace XmlParsersAndUi.Classes {
    public class ExportDatagridWorkerObject {

        public string localFileName;
        public DataTable localItemsPresentInGrid;
        public DataTable localGOLDEN_ORIGINAL_RESTULS;
        public int localMaxNumberOfRows;

        public ExportDatagridWorkerObject(string fileName,DataTable ItemsPresentInGrid, DataTable GOLDEN_ORIGINAL_RESTULS, int maxNumberOfRows) {
            localFileName = fileName;
            localItemsPresentInGrid = ItemsPresentInGrid;
            localGOLDEN_ORIGINAL_RESTULS = GOLDEN_ORIGINAL_RESTULS;
            localMaxNumberOfRows = maxNumberOfRows;
        
        }
    }
}
