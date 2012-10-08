using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automation.Common {
	public class EnvComparisonFilter: ListViewItem {
        public int filterId, FilterType;
        public string Name, Description, FilterPattern, FilterScript, ExclusionList;
        public int AddedByUserId;

       public bool IsFolderDeletion;

        public override string ToString() {
            return Name ;
        }

        public EnvComparisonFilter(int id, string name, string description, string pattern, int filterType, int userId) {
            filterId = id;
            Name = name;
            Description = description;
            FilterPattern = pattern;
            FilterType = filterType;
            AddedByUserId = userId;
        }



        public EnvComparisonFilter(int id, string name, string description, string pattern, int filterType, int userId, bool isFolderDeletion, string filterScript, string exclusionList) {
            filterId = id;
            Name = name;
            Description = description;
            FilterPattern = pattern;
            FilterType = filterType;
            AddedByUserId = userId;
            FilterScript = filterScript;
            ExclusionList = exclusionList;
        }

        public enum ComparisonFilterType {
            Regular=0,
            PreFilter=1,
            Deletion=2
        }

    }
}
