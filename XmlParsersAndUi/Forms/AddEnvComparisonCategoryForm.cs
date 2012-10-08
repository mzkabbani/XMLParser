using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XmlParsersAndUi.Classes;
using Automation.Common.Utils;
using Automation.Common;

namespace XmlParsersAndUi.Forms {
    public partial class EnvComparisonCategoryForm : Form {
        
        public ComparisonCategory workingCompCategory ;
        
        public EnvComparisonCategoryForm() {
            InitializeComponent();
            btnSaveCategory.Enabled = false;
        }

        public EnvComparisonCategoryForm(ComparisonCategory comparisonCategory) {
            InitializeComponent();
            workingCompCategory = comparisonCategory;
            btnAddCategory.Enabled = false;
        }

        private void EnvComparisonCategoryForm_Load(object sender, EventArgs e) {
            try {
                if(workingCompCategory !=null){
                    txtCategoryName.Text = workingCompCategory.categoryName;
                    txtCategoryDesc.Text = workingCompCategory.categoryDescription;
                    txtCategoryPath.Text = workingCompCategory.categoryPath;
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }

        }

        private void btnSaveCategory_Click(object sender, EventArgs e) {
            try {
                workingCompCategory = FillCategoryFromUiForSave();

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private ComparisonCategory FillCategoryFromUiForSave() {
            ComparisonCategory comparisonCategory = new ComparisonCategory(workingCompCategory.categoryId,
                txtCategoryName.Text,
                txtCategoryDesc.Text,
                txtCategoryPath.Text,
                workingCompCategory.categoryParentId);

            return comparisonCategory;
        }

        private void btnAddCategory_Click(object sender, EventArgs e) {
            try {
                workingCompCategory = FillCategoryFromUiForAdd();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private ComparisonCategory FillCategoryFromUiForAdd() {
            ComparisonCategory comparisonCategory = new ComparisonCategory(txtCategoryName.Text, txtCategoryDesc.Text, txtCategoryPath.Text);
            return comparisonCategory;
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            this.Close();
        }

    }
}
