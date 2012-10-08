using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace DragDrop {

    //this class will represent a file/folder and the list will be 
    //filled with objects of this class.
    public class FileObject {
        private string fileName;
        private string filePath;
        private bool isFolder;
        //constructor
        public FileObject(string name, bool folder) {
            //parse the file name and get the filename without the path.
            string[] pieces = name.Split(new char[] { '\\' });
            fileName = pieces[pieces.Length - 1];
            filePath = name;
            isFolder = folder;
        }
        public string Name {
            get {
                return fileName;
            }
        }
        public string NameWithPath {
            get {
                return filePath;
            }
        }
        public bool IsFolder {
            get {
                return isFolder;
            }
        }
        //since we are adding the FileObjects to the list the list will display the 
        //name of each item by calling its ToString method.Thats why we override it
        //and return the filename/foldername to be shown.
        public override string ToString() {
            return fileName;
        }
    }

    public partial class Form1 : Form {
        ListBox list;
		RichTextBox rich;
		Button prev;
		Label fileLabel;
		HelpProvider hlp;
		ArrayList fileObjects;
		public Form1()
		{
			//create a blank list of fileObjects
			fileObjects = new ArrayList();
			InitializeComponents();
			//fill the list with c: as the starting point.
			fillList(@"c:\");
		}
		//This method will be used when browsing from one directory to another.
		//This method will remove the contents of the previous directory and fill
		//the list with contents of the new direcory
	    void fillList(string path)
	    {
	    	//clear the filesObjets as well as the list
	    	//cos we are refilling the list.So remove the old items.
	    	fileObjects.Clear();
	    	list.Items.Clear();
	    	//set the application title to the current path being browsed.
	    	this.Text = path;
	    	//fill the fileObject arry with folders in the current path
	    	string[] dirs = Directory.GetDirectories(path);
	    	foreach(string dir in dirs)
			{
				  fileObjects.Add(new FileObject(dir,true));
			}
			//fill the fileObject arry with files in the current path
			string[] files = Directory.GetFiles(path);
			foreach(string file in files)
			{
				  fileObjects.Add(new FileObject(file,false));				
			}
			//fill the list with the filesObjects from the array
			foreach(FileObject item in fileObjects)
			{
				  list.Items.Add(item);				
			}
			//if the path is the root i.e c: then disable the Back button
	    	if(path.ToLower() == @"c:\" || path.ToLower() == @"c:")
	    		prev.Enabled = false;
	    	else
	    		prev.Enabled = true;
	    }
		// This method is used in the forms designer.
		// Change this method on you own risk
		void InitializeComponents()
		{
			// 
			//  Set up generated class MainForm
			// 
			this.SuspendLayout();
			this.Name = "MainForm";
			this.Text = "This is my form";
			this.Size = new Size(600, 400);
			//implement a help provider for this form.
			hlp = new HelpProvider();
						
			list              = new ListBox();
			list.Size         = new Size(520,145);
			list.Location     = new Point(1,1);
			list.MultiColumn  = true;
			list.DrawMode     = DrawMode.OwnerDrawFixed;
			list.MouseDown   += new MouseEventHandler(this.OnMouseDown);
			list.DoubleClick += new EventHandler(this.OnDblClick);
			list.DrawItem    += new DrawItemEventHandler(this.OnDrawItem);
			//set the helpstring for the list and enable the dispalying of help when
			//the listbox has focus and user presses F1.
			hlp.SetHelpString(list,"Shows files and folders in the current folder");
			hlp.SetShowHelp(list,true);
			
			prev          = new Button();
			prev.Text     = "Back";
			prev.Size     = new Size(50,30);
			prev.Location = new Point(530,60);
			prev.Click   += new EventHandler(this.OnPrevClicked);
			//set the helpstring for the button and enable the dispalying of help when
			//the Back button has focus and user presses F1.
			hlp.SetHelpString(prev,"Click to go to parent folder");
			hlp.SetShowHelp(prev,true);
			
			fileLabel          = new Label();
			fileLabel.Size     = new Size(590,40);
			fileLabel.Location = new Point(1,147);
			
			rich            = new RichTextBox();
			rich.Size       = new Size(590,180);
			rich.Location   = new Point(1,190);
			rich.AllowDrop  = true;
			rich.DragEnter +=new DragEventHandler(this.OnDragEnter);
			rich.DragDrop  += new DragEventHandler(this.OnDragDrop);
			//set the helpstring for the text box and enable the dispalying of help when
			//the rich textbox has focus and user presses F1.
			hlp.SetHelpString(rich,"Shows contents of file dropped");
			hlp.SetShowHelp(rich,true);
			this.ResumeLayout(false);
			
			Controls.Add(list);
			Controls.Add(prev);
			Controls.Add(fileLabel);
			Controls.Add(rich);
		}
		//we have implemented an event handler for the DrawItem event of the ListBox
		//this will enable us to display the Folders ,differently from the Files in 
		//a current folder.
		void OnDrawItem(object sender, DrawItemEventArgs drawArgs)
		{
		
			ListBox lb = (ListBox)sender;
			int index = drawArgs.Index;
			if(index >= 0)
			{
				//get the current FileObj from the index retrived from DrawItemEventArgs
				FileObject obj = (FileObject)lb.Items[index];
				Graphics g = drawArgs.Graphics;
				Font f = new Font(drawArgs.Font,FontStyle.Bold);
				//If the FileObject is a folder then paint it red and make it Bold
				if(obj.IsFolder)
					g.DrawString(obj.Name,f,Brushes.Red,drawArgs.Bounds.Left,drawArgs.Bounds.Top);
				else
					g.DrawString(obj.Name,drawArgs.Font,Brushes.Black,drawArgs.Bounds.Left,drawArgs.Bounds.Top);
				//make sure that the column width as much as the longest file/folder name
				if(lb.ColumnWidth < obj.Name.Length * 10)
					lb.ColumnWidth = obj.Name.Length * 10;
				
			}
		}
		//this method will ensure that the listbox displays the contents of the
		//parent folder when the Back button is pressed.
		void OnPrevClicked(object sender,EventArgs e)
		{
			string path = this.Text;
			try{
				DirectoryInfo info = Directory.GetParent(path);
				if(info.FullName != "")
				{
					
					fillList(info.FullName);
				}
			}
			catch
			{
				prev.Enabled = false;
			}
			
				
		}
		//this method is implemented to display the contents of a file after
		//it has been dragged and dropped onto the rich text box.
		void OnDragDrop(object sender,DragEventArgs de)
		{
			//get the dragged data from the DragEventArgs.
			//we are only interested in the Text or FileDrop data 
			//and will only accept text drag and drop
			StreamReader read;
			string fileName = "";
			if(de.Data.GetDataPresent(DataFormats.Text)) 
			{
				fileName = (string)de.Data.GetData(DataFormats.Text);
			}
			else if(de.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] fileNames;
				fileNames = (string[])de.Data.GetData(DataFormats.FileDrop);
				fileName = fileNames[0];
			}
			fileLabel.Text = fileName;
			read = new StreamReader(fileName);
			string strb = (string)read.ReadToEnd();
			read.Close();
			rich.Text = strb;
			
		}
		//when the mouse is dragging an object onto the text box make sure that
		//the data being dragged is Text or FileDrop only.
		void OnDragEnter(object sender, DragEventArgs de)
		{
			if(de.Data.GetDataPresent(DataFormats.Text) || de.Data.GetDataPresent(DataFormats.FileDrop))
			{
				de.Effect = DragDropEffects.Copy;
			}
			else
			{
				de.Effect = DragDropEffects.None;
			}
				
		}
		//This function handles the MouseDown event and will start the drag and drop
		//operation if all conditions are satisfied.
		void OnMouseDown(object sender,	MouseEventArgs me)
		{
			ListBox lb = (ListBox)sender;
			int index = lb.IndexFromPoint(me.X,me.Y) ;
			
			if(index >= 0)
			{
				FileObject item = (FileObject)lb.Items[index];
				//start the drag and drop operation only if the FileObject represents
				//a file and not a folder.
				if(!item.IsFolder)
				{
				   lb.DoDragDrop(item.NameWithPath,DragDropEffects.Copy);
				}
  			}
		}
		//This function will take us inside a directory when we double click on it.
		void OnDblClick(object sender,	EventArgs me)
		{
			ListBox lb = (ListBox)sender;
			int index = lb.SelectedIndex;
			if(index >= 0)
			{
				FileObject item = (FileObject)lb.Items[index];
				//make sure that the file object is a directory.
				if(item.IsFolder)
				{
					fillList(item.NameWithPath);
				}
			}
		}
	
	}			

    }

