using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XmlParsersAndUi.Classes;
using XmlParsersAndUi.Controls;
using Automation.Common.Utils;
using Automation.Backend;
using Automation.Common;

namespace XmlParsersAndUi.Forms {
    public partial class ShowSearchDetailsForm : Form {

        public AdvancedRecomendation captureEvent;
        public ReplacementEvent selectedReplacementEvent;


        public ShowSearchDetailsForm(AdvancedRecomendation passedCaptureEvent) {
            InitializeComponent();
            captureEvent = passedCaptureEvent;
        }

        private void ShowSearchDetailsForm_Load(object sender, EventArgs e) {
            try {
                List<ReplacementEvent> availableReplacements = Advanced_Replacements.GetAvailableReplacementsByCaptureId(captureEvent.CaptureEventId, BackEndUtils.GetSqlConnection());
                for (int i = 0; i < availableReplacements.Count; i++) {
                    CustomizedReplacement customizedReplacement = new CustomizedReplacement();
                    customizedReplacement.Click += new EventHandler(customizedReplacement_Click);
                    customizedReplacement.Location = new System.Drawing.Point(3, 3 + (207 * (i)) + 6);
                    customizedReplacement.Name = availableReplacements[i].name;

                    customizedReplacement.repDescription = availableReplacements[i].description;
                    customizedReplacement.repName = availableReplacements[i].name;
                    customizedReplacement.repReplacement = availableReplacements[i].Value;
                    customizedReplacement.replacementEvent = availableReplacements[i];
                    customizedReplacement.Size = new System.Drawing.Size(790, 207);
                    customizedReplacement.TabIndex = 0;
                  //  customizedReplacement.popularity = (int)SetPopularity(availableReplacements[i]);

                    pnlReplacements.Controls.Add(customizedReplacement);
                }
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void customizedReplacement_Click(object sender, EventArgs e) {
            try {

            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

//        private double SetPopularity(ReplacementEvent replacementEvent) {
//            int totalUsage = Advanced_Replacements.GetTotalAdvanceReplacementUsageCount();
//            return (((double)replacementEvent.usageCount / totalUsage) * 20);
//
//
//        }

        private void ShowSearchDetailsForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (selectedReplacementEvent != null) {
                this.DialogResult = DialogResult.OK;
            }

        }

    }
}
