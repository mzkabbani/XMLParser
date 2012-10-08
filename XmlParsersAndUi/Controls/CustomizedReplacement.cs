using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using XmlParsersAndUi.Classes;
using XmlParsersAndUi.Forms;
using Automation.Common;

namespace XmlParsersAndUi.Controls {
    public partial class CustomizedReplacement : UserControl {
        
        public bool isUsed = false;

        #region Properties
        
        public string repName { get; set; }
        public string repReplacement { get; set; }
        public string repDescription { get; set; }
        public int popularity { get; set; }
        public ReplacementEvent replacementEvent { get; set; }

        #endregion
        
        public CustomizedReplacement() {
            InitializeComponent();
            txtReplacementName.Text = repName;
            rtxtReplacement.Text = repReplacement;
            rtxtReplacementDescription.Text = repDescription;
            SetPopualrity();
        }

        public CustomizedReplacement(string repName, string repReplacement, string repDescription, int popularity) {
            InitializeComponent();



            List<string> foundPatterns = GetReplacementParametersFromValue(rtxtReplacement.Text);
            List<string> uniquePatterns = new List<string>();
            for (int i = 0; i < foundPatterns.Count; i++) {
                if (!uniquePatterns.Contains(foundPatterns[i])) {
                    uniquePatterns.Add(foundPatterns[i]);
                    int foundIndex = rtxtReplacement.Text.IndexOf(foundPatterns[i]);
                    rtxtReplacement.Select(foundIndex, foundPatterns[i].Length);
                    rtxtReplacement.SelectionColor = Color.Red;
                } else {
                    int foundIndex = rtxtReplacement.Text.IndexOf(foundPatterns[i]);
                    foundIndex = rtxtReplacement.Text.IndexOf(foundPatterns[i], foundIndex+1);
                    rtxtReplacement.Select(foundIndex, foundPatterns[i].Length);
                    rtxtReplacement.SelectionColor = Color.Red;
                }
            }          
        }

        private List<string> GetReplacementParametersFromValue(string replacementValue) {
            List<string> caughtParameters = new List<string>();
            Regex regex = new Regex("{(.*?)}", RegexOptions.Compiled);
            foreach (Match match in regex.Matches(replacementValue)) {
                caughtParameters.Add(match.Groups[0].Value);
            }
            return caughtParameters;
        }

        private void CustomizedReplacement_Load(object sender, EventArgs e) {
            txtReplacementName.Text = repName;
            rtxtReplacement.Text = repReplacement;
            rtxtReplacementDescription.Text = repDescription;
            SetPopualrity();
            List<string> foundPatterns = GetReplacementParametersFromValue(rtxtReplacement.Text);
            List<string> uniquePatterns = new List<string>();
            for (int i = 0; i < foundPatterns.Count; i++) {
                if (!uniquePatterns.Contains(foundPatterns[i])) {
                    uniquePatterns.Add(foundPatterns[i]);
                    int foundIndex = rtxtReplacement.Text.IndexOf(foundPatterns[i]);
                    rtxtReplacement.Select(foundIndex, foundPatterns[i].Length);
                    rtxtReplacement.SelectionColor = Color.Red;
                } else {
                    int foundIndex = 0;
                    int recurseCount = GetRecurseCount(foundPatterns, i);
                    for (int j = 0; j < recurseCount; j++) {
                        foundIndex = rtxtReplacement.Text.IndexOf(foundPatterns[i], foundIndex + 1);
                    }
                    rtxtReplacement.Select(foundIndex, foundPatterns[i].Length);
                    rtxtReplacement.SelectionColor = Color.Red;
                }
            }
            SetPopualrity();
        }

        private void SetPopualrity() {
            srcReplacementPop.m_hoverStar = 0;
            srcReplacementPop.m_selectedStar = 0;
            srcReplacementPop.Invalidate();
            srcReplacementPop.m_hoverStar = (int)popularity;
            srcReplacementPop.m_selectedStar = (int)popularity;
            srcReplacementPop.m_hovering = true;
            srcReplacementPop.Invalidate();
        
        }

        private void CustomizedReplacement_VisibleChanged(object sender, EventArgs e) {
            txtReplacementName.Text = repName ;
            rtxtReplacement.Text= repReplacement; 
            rtxtReplacementDescription.Text = repDescription;



            List<string> foundPatterns = GetReplacementParametersFromValue(rtxtReplacement.Text);
            List<string> uniquePatterns = new List<string>();
            for (int i = 0; i < foundPatterns.Count; i++) {
                if (!uniquePatterns.Contains(foundPatterns[i])) {
                    uniquePatterns.Add(foundPatterns[i]);
                    int foundIndex = rtxtReplacement.Text.IndexOf(foundPatterns[i]);
                    rtxtReplacement.Select(foundIndex, foundPatterns[i].Length);
                    rtxtReplacement.SelectionColor = Color.Red;
                } else {
                    int foundIndex = 0;
                    int recurseCount = GetRecurseCount(foundPatterns,i);
                    for (int j = 0; j < recurseCount; j++) {
                        foundIndex = rtxtReplacement.Text.IndexOf(foundPatterns[i], foundIndex+1);
                    }                    
                    rtxtReplacement.Select(foundIndex, foundPatterns[i].Length);
                    rtxtReplacement.SelectionColor = Color.Red;
                }
            }
            SetPopualrity();
        }

        private int GetRecurseCount(List<string> foundPatterns, int index) {
            int count = 0;
            for (int i = 0; i < index+1; i++) {
                if(string.Equals(foundPatterns[i],foundPatterns[index])){
                    count++;
                }
            }
            return count;
        }  
    

       
    }
}
