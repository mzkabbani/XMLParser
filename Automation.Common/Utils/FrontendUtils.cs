using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Drawing.Imaging;
using System.Net.Mime;
using Automation.Common.Forms;
using System.Threading;

namespace Automation.Common.Utils {
	public static class FrontendUtils {

		public enum UiPrepareFor {
			Save = 1,
			Add = 2,
			Reset = 3
		}

		public static int LoggedInUserId {
			get;
			set;
		}

		public enum AdvancedRecCategory {
			SpecificConf = 1,
			Verbal = 2,
			Xpath = 3
		}


		public static void CopyDirectory(string sourceDirectory, string targetDirectory) {
			DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
			DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

			CopyAll(diSource, diTarget);
		}


		

		public static string GetRandomHexNumber(int digits) {
			Random random = new Random();
			byte[] buffer = new byte[digits / 2];
			random.NextBytes(buffer);
			string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
			if (digits % 2 == 0) {
				return result;
			}
			return result + random.Next(16).ToString("X");
		}

		public static void CopyAll(DirectoryInfo source, DirectoryInfo target) {
			// Check if the target directory exists, if not, create it.
			if (Directory.Exists(target.FullName) == false) {
				Directory.CreateDirectory(target.FullName);
			}

			// Copy each file into it's new directory.
			foreach (FileInfo fi in source.GetFiles()) {
				Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
				fi.CopyTo(Path.Combine(target.ToString(), fi.Name), true);
			}

			// Copy each subdirectory using recursion.
			foreach (DirectoryInfo diSourceSubDir in source.GetDirectories()) {
				DirectoryInfo nextTargetSubDir =
					target.CreateSubdirectory(diSourceSubDir.Name);
				CopyAll(diSourceSubDir, nextTargetSubDir);
			}
		}

		public static string ExecuteCommandSync(string fileName) {
			try {
				// create the ProcessStartInfo using "cmd" as the program to be run,
				// and "/c " as the parameters.
				// Incidentally, /c tells cmd that we want it to execute the command that follows,
				// and then exit.
				System.Diagnostics.ProcessStartInfo procStartInfo =
					new System.Diagnostics.ProcessStartInfo("java.exe",fileName);

				procStartInfo.UseShellExecute = false;
				procStartInfo.CreateNoWindow = false;
				
				procStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				Process proc;

				if ((proc = Process.Start(procStartInfo)) == null) {
					throw new InvalidOperationException("??");
				}

				
				proc.WaitForExit();
				int exitCode = proc.ExitCode;
				proc.Close();
				// The following commands are needed to redirect the standard output.
				// This means that it will be redirected to the Process.StandardOutput StreamReader.
				//procStartInfo.RedirectStandardOutput = true;
				//procStartInfo.UseShellExecute = false;
				// Do not create the black window.
				//  procStartInfo.CreateNoWindow = false;
				// Now we create a process, assign its ProcessStartInfo and start it
				//  System.Diagnostics.Process proc = new System.Diagnostics.Process();
				//   proc.StartInfo = procStartInfo;
				//   proc.Start();
				// Get the output into a string
				return "";
				// Display the command output.

			} catch (Exception objException) {
				// Log the exception
				FrontendUtils.LogError(objException.Message, objException);
			}
			return string.Empty;
		}

		public static string FormatXml(string sUnformattedXml) {
			//load unformatted xml into a dom
			XmlDocument xd = new XmlDocument();
			xd.LoadXml(sUnformattedXml);
			//will hold formatted xml
			StringBuilder sb = new StringBuilder();
			//pumps the formatted xml into the StringBuilder above
			StringWriter sw = new StringWriter(sb);
			//does the formatting
			XmlTextWriter xtw = null;
			try {
				//point the xtw at the StringWriter
				xtw = new XmlTextWriter(sw);
				//we want the output formatted
				xtw.Formatting = Formatting.Indented;
				//get the dom to dump its contents into the xtw
				xd.WriteTo(xtw);
			} finally {
				//clean up even if error
				if (xtw != null)
					xtw.Close();
			}
			//return the formatted xml
			return sb.ToString();
		}


		static string logFilePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Logs\app.logs";

		[DllImport("User32.dll")]
		private static extern bool
			GetLastInputInfo(ref LASTINPUTINFO plii);

		//Step 4
		public struct LASTINPUTINFO {
			public uint cbSize;
			public uint dwTime;
		}

		public static void ShowError(string errorText, Exception ex) {
			ExceptionForm form = new ExceptionForm(errorText, ex);
			//form.MdiParent = MainForm.ActiveForm.ParentForm;
			form.ShowDialog();
			LogError(errorText, ex);
		}

		public static void LogError(string errorText, Exception ex) {
			StreamWriter writer = new StreamWriter(logFilePath, true);
			try {
				try {
					writer.Write("\n\n\n\n\n" + DateTime.Now + "\n\n\n" + errorText + "\n\n\n" + (ex == null ? "" : ex.ToString()));
				} finally {
					if (writer != null) {
						writer.Flush();
						writer.Close();
						writer.Dispose();
					}
				}
			} catch (Exception exc) {
				// dirty catch
			}
		}

		public static Bitmap GetScreenShot() {
			//to allow the screen to refresh(repaint)
			Application.DoEvents();
			int width = 0;
			int height = 0;
			int smallerX = 99999;
			int smallerY = 99999;
			int totalWidth = 0;
			int totalHeight = 0;
			// Set the bitmap object to the size of the screen
			for (int i = 0; i < Screen.AllScreens.Count(); i++) {
				width = width + Screen.AllScreens[i].Bounds.Width;
				height = Screen.AllScreens[i].Bounds.Height;
				if (smallerX > Screen.AllScreens[i].Bounds.X) {
					smallerX = Screen.AllScreens[i].Bounds.X;
				}
				if (smallerY > Screen.AllScreens[i].Bounds.Y) {
					smallerY = Screen.AllScreens[i].Bounds.Y;
				}
				totalWidth = totalWidth + Screen.AllScreens[i].Bounds.Size.Width;
				totalHeight = Screen.AllScreens[i].Bounds.Size.Height;
			}
			var bmpScreenshot = new Bitmap(width
			                               , height
			                               , PixelFormat.Format32bppArgb
			                              );
			Size totalSize = new Size(totalWidth, totalHeight);
			// Create a graphics object from the bitmap
			Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);
			// Take the screenshot from the upper left corner to the right bottom corner
			try {
				gfxScreenshot.CopyFromScreen(smallerX
				                             , smallerY
				                             , 0
				                             , 0
				                             , totalSize
				                             , CopyPixelOperation.SourceCopy
				                            );
			} catch (Exception ex) {
			}
			return bmpScreenshot;
		}

		public static void ShowInformation(string infoText, bool asError) {
			if (asError) {
				MessageBox.Show(infoText, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			} else {
				MessageBox.Show(infoText, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
				
			}
		}

		public static void CheckoutPath(string repositoryLocation, string localLocation) {
			try {
				Process p = new Process();
				p.StartInfo.FileName = "svn";
				p.StartInfo.Arguments = "checkout " + repositoryLocation + " " + localLocation;
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				p.StartInfo.CreateNoWindow = false;
				p.Start();
				string output = p.StartInfo.Arguments + "\r\n";
				output = output + p.StandardOutput.ReadToEnd();
				p.WaitForExit();
			} catch (Exception ex) {
				MessageBox.Show(ex.Message, "SVN checkout issue");
			}
		}

		public static void SetColumnsHeadersToBold(DataGridView grid) {
			for (int i = 0; i < grid.Columns.Count; i++) {
				grid.Columns[i].HeaderCell.Style.Font = new Font("Arial", 8, FontStyle.Bold);
			}
		}

		public static string ReadFile(string filePath) {
			string readText = string.Empty;
			StreamReader reader = new StreamReader(filePath);
			try {
				readText = reader.ReadToEnd();
			} finally {
				if (reader != null) {
					reader.Close();
					reader.Dispose();
				}
			}
			return readText;
		}

		public static DialogResult ShowConformation(string confirmationText) {
			return MessageBox.Show(confirmationText, "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		public static void WriteXmlFile(string filePath, string readTextReplaced) {
			XmlTextWriter writer = new XmlTextWriter(filePath, Encoding.Default);
			// StreamWriter writer = new StreamWriter(filePath, false);
			try {
				writer.WriteString(readTextReplaced);
				//writer.WriteLine(readTextReplaced);
			} finally {
				if (writer != null) {
					writer.Flush();
					writer.Close();
				}
			}
		}
	
		public static void WriteFile(string filePath, string readTextReplaced) {
			StreamWriter writer = new StreamWriter(filePath, false);
			try {
				writer.WriteLine(readTextReplaced);
			} finally {
				if (writer != null) {
					writer.Flush();
					writer.Close();
					writer.Dispose();
				}
			}
		}

		public static void AddSimpleRectoSvn(string inputDir) {
			try {
				Process p = new Process();
				p.StartInfo.FileName = "svn";
				p.StartInfo.Arguments = "add -N " + inputDir + @"\*";
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				p.StartInfo.CreateNoWindow = false;
				p.Start();
				string output = p.StartInfo.Arguments + "\r\n";
				output = output + p.StandardOutput.ReadToEnd();
				p.WaitForExit();
				p = new Process();
				p.StartInfo.FileName = "svn";
				p.StartInfo.Arguments = "commit " + inputDir + "\\* -m\"addedFiles\"";
				p.StartInfo.UseShellExecute = false;
				p.StartInfo.RedirectStandardOutput = true;
				p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				p.StartInfo.CreateNoWindow = false;
				p.Start();
				p.WaitForExit();
			} catch (Exception ex) {
				MessageBox.Show(ex.Message, "SVN checkout issue");
			}
		}

		public static void SendEmail(string sender, string recipient, string subject, string body) {
			try {
				MailAddress mailfrom = new MailAddress("autoengine@murex.com", sender);
				MailAddress mailto = new MailAddress(recipient);
				MailMessage newmsg = new MailMessage(mailfrom, mailto);
				newmsg.Subject = subject;
				newmsg.Body = body;
				//Attachment att = new Attachment("C:\\...file path");
				//newmsg.Attachments.Add(att);
				SmtpClient smtp = new SmtpClient("Barid.lb.murex.com");
				smtp.UseDefaultCredentials = false;
				smtp.Credentials = new NetworkCredential();
				smtp.Send(newmsg);
			} catch (Exception ex) {
				
			}
		}

		public static void SendUsageNotification(string Title) {
			SendEmail("MET", "mkabbani@murex.com", "MET STAT: " + Title, Title);
		}

		public static string GetCurrentUser() {
			string currentUserName = string.Empty;
			System.Security.Principal.WindowsIdentity user =
				System.Security.Principal.WindowsIdentity.GetCurrent();
			string[] usernameArray = user.Name.Split('\\');
			currentUserName = usernameArray[1];
			return currentUserName;
		}

		public static void CreateLogsDirectory() {
			if (!Directory.Exists(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Logs")) {
				Directory.CreateDirectory(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Logs");
			}
		}

	
		public static void SendEmailWithAttachement(string exceptionMessage, Exception sentException, string fileName) {
			string currentUserName = GetCurrentUser();
			MailAddress mailfrom = new MailAddress(currentUserName+"@murex.com", "MET-"+currentUserName);
			MailAddress mailto = new MailAddress("mkabbani@murex.com");
			MailMessage newmsg = new MailMessage(mailfrom, mailto);
			if (sentException != null) {
				newmsg.Subject = "MET Exception: " + sentException.Message + "- " + currentUserName;
				newmsg.Body = exceptionMessage + "\n\n\n" + sentException.ToString() + "\n\n\n\nStack:\n" + sentException.StackTrace;
			} else {
				newmsg.Subject = "MET Exception: " + exceptionMessage;
				newmsg.Body = exceptionMessage;
			}
			Attachment att = new Attachment(fileName);
			newmsg.Attachments.Add(att);
			SmtpClient smtp = new SmtpClient("Barid.lb.murex.com");
			smtp.UseDefaultCredentials = false;
			smtp.Credentials = new NetworkCredential();
			//smtp.EnableSsl = true;
			smtp.Send(newmsg);
		}



		public static void BindCombo(ComboBox cboReplacementType, System.Data.DataTable datable, string displayMember, string valueMember) {
			cboReplacementType.DataSource = datable.DefaultView;
			cboReplacementType.DisplayMember = displayMember;
			cboReplacementType.ValueMember = valueMember;
		}

		public static string GetFileOpenDialog() {
			string selectedFilePath = string.Empty;
			OpenFileDialog dialog = new OpenFileDialog();
			dialog.Filter = "All files (*.*)|*.*";
			DialogResult dialogResult = dialog.ShowDialog();
			if(dialogResult == DialogResult.OK){
				selectedFilePath = dialog.FileName;
			}
			return selectedFilePath;
		}
	}
}
