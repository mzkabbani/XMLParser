using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi {
   public class checkboxItems {
       public string stepName;
       public string filepath;
       public string stepTitle;
       public string stepEvents;

       public override string ToString() {
           return  stepName + " | " + stepTitle ;
       }
   }
}
