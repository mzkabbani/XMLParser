using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using XmlParsersAndUi.Controls;
using XmlParsersAndUi.Classes;
using Automation.Common.Utils;
using Automation.Common;
using Automation.Backend;

namespace XmlParsersAndUi.Forms {
    public partial class testReplacements : Form {

        public testReplacements() {
            InitializeComponent();
        }
        
        BackGroundWorkerObject globalWorkerObject;
        
        public testReplacements(BackGroundWorkerObject obj ) {
            InitializeComponent();
            globalWorkerObject = obj;
        }

        private void testReplacements_Load(object sender, EventArgs e) {
            FillDatagridWithResults(globalWorkerObject);
        }

        private void FillDatagridWithResults(BackGroundWorkerObject aBackGroundWorkerObject) {
            for (int i = 0; i < aBackGroundWorkerObject.returnedComplexCaptureMatchObject.Count; i++) {
                int rowIndex = dgvResults.Rows.Add();
                dgvResults.Rows[rowIndex].Cells[0].Value = aBackGroundWorkerObject.returnedComplexCaptureMatchObject[i].captureEvent.CaptureEventName;
                dgvResults.Rows[rowIndex].Cells[2].Value = GetTotalMatchesForCapture(aBackGroundWorkerObject.returnedComplexCaptureMatchObject[i].fileNamesHit);
                dgvResults.Rows[rowIndex].Cells[1].Value = aBackGroundWorkerObject.returnedComplexCaptureMatchObject[i].captureEvent;
            }
        }

        private int GetTotalMatchesForCapture(List<FileAndNumberOfMatches> fileList) {
            int totalMatches = 0;
            for (int i = 0; i < fileList.Count; i++) {
                totalMatches = totalMatches + fileList[i].matchedNodes.Count;
            }
            return totalMatches;
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            try {
                pnlAvailableReplacements.Controls.Clear();
                AdvancedRecomendation captureEvent = dgvResults[1, e.RowIndex].Value as AdvancedRecomendation;
                List<ReplacementEvent> availableReplacements = Advanced_Replacements.GetAvailableReplacementsByCaptureId(captureEvent.CaptureEventId,BackEndUtils.GetSqlConnection());
                for (int i = 0; i < availableReplacements.Count; i++) {
                    CustomizedReplacement customizedReplacement = new CustomizedReplacement();
                    customizedReplacement.Click += new EventHandler(customizedReplacement_Click);
                    customizedReplacement.Location = new System.Drawing.Point(3, 3 + (136 * (i)) + 6);
                    customizedReplacement.Name = availableReplacements[i].name;
                    customizedReplacement.repDescription = availableReplacements[i].description;
                    customizedReplacement.repName = availableReplacements[i].name;
                    customizedReplacement.repReplacement = availableReplacements[i].Value;
                    customizedReplacement.replacementEvent = availableReplacements[i];
                    customizedReplacement.Size = new System.Drawing.Size(566, 119);
                    customizedReplacement.TabIndex = i;
                    customizedReplacement.Visible = true;
                   // customizedReplacement.popularity = (int)SetPopularity(availableReplacements[i]);
                    pnlAvailableReplacements.Controls.Add(customizedReplacement);
                }
                pnlAvailableReplacements.Focus();
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

        private void customizedReplacement_Click(object sender, EventArgs e) {
        
            
        }

    }
}
