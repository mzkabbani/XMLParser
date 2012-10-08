using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Automation.Common {

    public enum CapturePointListType {
        SimpleList = 1,
        ListWithMutlipleDesc = 2,
    }

	  public enum AdvancedRecomendationCategory {
        SpecificConfiguration = 1,
        Verbal = 2,
        XpathBased = 3,
    }
	
    public class AdvancedRecomendation {
        public string CaptureEventName, CaptureEventDescription, CaptureEventEventText;
        public ReplacementEvent Replacement;
        public List<CustomTreeNode> CaptureEventCapturePointsList;
        public CapturePointListType capturePointListType;
        public int captureEventCategory;
        public int captureEventuserId;
        public int captureEventUsageCount, CaptureEventId;
        public AdvancedRecomendation(string Name, string Description, string EventText,List<CustomTreeNode> CapturePointsList) {
            CaptureEventName = Name;
            CaptureEventDescription = Description;
            CaptureEventEventText = EventText;
            CaptureEventCapturePointsList = CapturePointsList;   
        }

        public AdvancedRecomendation(int id, string Name, string Description, string EventText, List<CustomTreeNode> CapturePointsList) {
            CaptureEventId = id;
            CaptureEventName = Name;
            CaptureEventDescription = Description;
            CaptureEventEventText = EventText;
            CaptureEventCapturePointsList = CapturePointsList;
        }

        public AdvancedRecomendation(string Name, string Description, string EventText,int categoryId, int usageCount, List<CustomTreeNode> CapturePointsList) {
            CaptureEventName = Name;
            CaptureEventDescription = Description;
            CaptureEventEventText = EventText;
            captureEventCategory = categoryId;
            CaptureEventCapturePointsList = CapturePointsList;
            captureEventUsageCount = usageCount;
        }

        public AdvancedRecomendation(int id, string Name, string Description, string EventText, int categoryId, int usageCount, List<CustomTreeNode> CapturePointsList) {
            CaptureEventId = id;
            CaptureEventName = Name;
            CaptureEventDescription = Description;
            CaptureEventEventText = EventText;
            captureEventCategory = categoryId;
            CaptureEventCapturePointsList = CapturePointsList;
            captureEventUsageCount = usageCount;
        }

        public AdvancedRecomendation(int id, string Name, string Description, string EventText, int categoryId, int usageCount, List<CustomTreeNode> CapturePointsList, int userId) {
            CaptureEventId = id;
            CaptureEventName = Name;
            CaptureEventDescription = Description;
            CaptureEventEventText = EventText;
            captureEventCategory = categoryId;
            CaptureEventCapturePointsList = CapturePointsList;
            captureEventUsageCount = usageCount;
            captureEventuserId = userId;
        }
        public AdvancedRecomendation() { 
        
        }
        public override string ToString() {
            return CaptureEventName;
        }
    
    }
}
