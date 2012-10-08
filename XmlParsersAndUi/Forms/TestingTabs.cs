using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace XmlParsersAndUi.Forms {
    public partial class TestingTabs : Form {
        public TestingTabs() {
            InitializeComponent();
        }

        


        private void TestingTabs_Load(object sender, EventArgs e) {

        }

        private void tdhTabCtl1_OnTabEvents(object sender, XmlParsersAndUi.TabEventArgs e) {
            switch (e.TabEvent) {

                case XmlParsersAndUi.TabEventArgs.TabEvents.TabAdded:
                    // optionally do something
                    break;
                case XmlParsersAndUi.TabEventArgs.TabEvents.TabAddRejected:
                    // optionally do something

                    // For instance:
                    // Add the [TdhTabPage] to the TabPageCollection of a standard TabControl
                    //this.tabControl1.Controls.Add(e.TabPage);
                    this.tdhTabCtl1.TabPages.Add(e.TabPage);
                    break;
                case XmlParsersAndUi.TabEventArgs.TabEvents.TabRemoved:
                    // optionally do something

                    // For instance:
                    // Add the [TdhTabPage] to the TabPageCollection of a standard TabControl
                    //this.tabControl1.Controls.Add(e.TabPage);
                    this.tdhTabCtl1.TabPages.Remove(e.TabPage);
                  //  this.tdhTabCtl1.TabPages.Add(e.TabPage);
                    break;
                case XmlParsersAndUi.TabEventArgs.TabEvents.TabRenamed:
                    // optionally do something
                    break;
                case XmlParsersAndUi.TabEventArgs.TabEvents.TabsReordered:
                    // This "subevent" is not raised 
                    // if the [tdhTabCtl1.OnTabsReordered] eventhandler is assigned
                    // It is raised for each TdhTabPage affected by the reorder

                    // optionally do something

                    Console.WriteLine("TdhTabPage reordered."      // TEST
                        + "    OldInd=" + e.TabIndexOld.ToString()   // TEST
                        + "    NewInd=" + e.TabIndexNew.ToString()); // TEST
                    break;
                default:
                    break;
            
            }
        }
    }
}
