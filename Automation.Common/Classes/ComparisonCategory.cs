using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Automation.Common {
    public class ComparisonCategoryTreeNode : TreeNode {

        public ComparisonCategory comparisonCategory;
        public ComparisonCategoryTreeNode(string text) {
            this.Text = text;
        }

    }

    public class ComparisonCategory {
        public int categoryId;
        public string categoryName;
        public string categoryDescription;
        public string categoryPath;
        public int categoryParentId;

        public ComparisonCategory(int id, string name, string description, string path, int parentId) {
            categoryId = id;
            categoryName = name;
            categoryDescription = description;
            categoryPath = path;
            categoryParentId = parentId;
        }

        public ComparisonCategory(string name, string description, string path) {
            categoryName = name;
            categoryDescription = description;
            categoryPath = path;
        }
    }
}
