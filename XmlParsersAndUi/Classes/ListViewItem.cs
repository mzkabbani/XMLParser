using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi {
    public class ListViewItem {

        public string DisplayName;
        public string Content;


        public override string ToString() {
            return DisplayName;        
        }
    
    }
}
