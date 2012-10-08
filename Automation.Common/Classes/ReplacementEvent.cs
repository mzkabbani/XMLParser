using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Common {
    public class ReplacementEvent {
        public string name, description, Value;
        public int id, typeId, usageCount, capturePointId, userId;


        public override string ToString() {
            return name;
        }


        public ReplacementEvent(int replacementId, int replacementUserId, string replacementName, string replacementDescription, string replacementValue, int replacementType, int replacementCapturePointId, int replacementUsageCount) {
            id = replacementId;
            name = replacementName;
            description = replacementDescription;
            Value = replacementValue;
            typeId = Convert.ToInt32(replacementType);
            capturePointId = replacementCapturePointId;
            userId = replacementUserId;
            usageCount = replacementUsageCount;
        }
           

        public ReplacementEvent(int replacementId, string replacementName, string replacementDescription, string replacementValue, int replacementType, int replacementCapturePointId, int replacementUsageCount) {
            id = replacementId;
            name = replacementName;
            description = replacementDescription;
            Value = replacementValue;
            typeId = Convert.ToInt32(replacementType);
            capturePointId = replacementCapturePointId;
            usageCount = replacementUsageCount;
        }   

        public ReplacementEvent(string replacementName, string replacementDescription, string replacementValue, int replacementType, int replacementCapturePointId) {
            name = replacementName;
            description = replacementDescription;
            Value = replacementValue;
            typeId = replacementType;
            capturePointId = replacementCapturePointId;
        }

        public ReplacementEvent(string replacementName, string replacementDescription, string replacementValue, int replacementType, int replacementCapturePointId, int replacementLoggedInUser) {
            name = replacementName;
            description = replacementDescription;
            Value = replacementValue;
            typeId = replacementType;
            capturePointId = replacementCapturePointId;
            userId = replacementLoggedInUser;
        }

        public ReplacementEvent(string replacementName, string replacementDescription, string replacementValue, int replacementType) {
            name = replacementName;
            description = replacementDescription;
            Value = replacementValue;
            typeId = Convert.ToInt32(replacementType);
        }
    }
}
