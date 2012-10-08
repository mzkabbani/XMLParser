using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PackageGenerator.Classes {
   public class ExportExcelObject {
      public DataSet exportDataSet;
      public string outputFilePath;
      public bool showCompletedPopup = false;
   }
}
