using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Permissions;

namespace FileSystemWatcher {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        string logFile = @"D:\recorder.txt";
        

        [PermissionSet(SecurityAction.Demand, Name="FullTrust")]
        private void btnStart_Click(object sender, EventArgs e) {
            System.IO.FileSystemWatcher watcher = new System.IO.FileSystemWatcher();
            watcher.IncludeSubdirectories = true;
            watcher.Path = @"C:\";
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
           | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            watcher.Filter = "*";
            // Add event handlers.
            watcher.Changed += new FileSystemEventHandler(OnChanged);
            watcher.Created += new FileSystemEventHandler(OnChanged);
            watcher.Deleted += new FileSystemEventHandler(OnChanged);
            watcher.Renamed += new RenamedEventHandler(OnRenamed);

            // Begin watching.
            watcher.EnableRaisingEvents = true;


        }

        private static void OnChanged(object source, FileSystemEventArgs e) {
            // Specify what is done when a file is changed, created, or deleted.

            StreamWriter writer = new StreamWriter(@"D:\recorder.txt",true);
            try {
                writer.WriteLine(DateTime.Now+"   File: " + e.FullPath + " " + e.ChangeType);
            } finally {
                if(writer!=null){
                    writer.Close();
                }
            }
            Console.WriteLine("File: " + e.FullPath + " " + e.ChangeType);
        }

        private static void OnRenamed(object source, RenamedEventArgs e) {
            // Specify what is done when a file is renamed.
            StreamWriter writer = new StreamWriter(@"D:\recorder.txt", true);
            try {
                writer.WriteLine(DateTime.Now + "   File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
            } finally {
                if (writer != null) {
                    writer.Close();
                }
            }
            Console.WriteLine("File: {0} renamed to {1}", e.OldFullPath, e.FullPath);
        }

    }
}
