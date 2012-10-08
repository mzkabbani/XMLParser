using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi.Classes {
    public class EventsGroupNameAndID {
        
        public string OperationID;
        public string OperationName;
        public string OperationGeneratedID;


        public EventsGroupNameAndID(string operationName, string generatedID) {
            OperationName = operationName;
            OperationGeneratedID = generatedID;        
        }

    }
}
