using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace XmlParsersAndUi {
    public class BulkMacroTreeNode : TreeNode, IComparable<BulkMacroTreeNode> {
       public string stepName;
       public string filepath;
       public string stepTitle;
       public string stepEvents;
       public int startStepId;
       public int endStepId;
       public bool isParentNode;

       public static Comparison<BulkMacroTreeNode> stepIndexComparison =
           delegate(BulkMacroTreeNode bulkMacroTreeNode1, BulkMacroTreeNode bulkMacroTreeNode2) {
       		
       	
       	return Convert.ToInt32(bulkMacroTreeNode1.stepName.Replace("step","").Replace("_events.xml","")).CompareTo(Convert.ToInt32(bulkMacroTreeNode2.stepName.Replace("step","").Replace("_events.xml","")));
           };


       public int CompareTo(BulkMacroTreeNode bulkMacroTreeNode) {
           return stepEvents.CompareTo(bulkMacroTreeNode.stepEvents);
       }
      

       public override string ToString() {
           return stepName + " | " + stepTitle;
       }


    }
}
