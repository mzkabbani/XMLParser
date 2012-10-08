using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using Automation.Common.Utils;

namespace Automation.Common.Forms {
    public partial class ExceptionForm : Form {
        Exception sentException;
        string sentErrorText;

        public ExceptionForm(string errorText, Exception ex) {
            InitializeComponent();
            sentException = ex;
            sentErrorText = errorText;
        }

        private void ExceptionForm_Load(object sender, EventArgs e) {
            this.Text = "Exception Caught...";


            txtMessage.Text = sentErrorText + "\r\n" + (sentException == null ? "" : (string.Equals(sentException.Message, sentErrorText) ? "" : sentException.Message));

            if (sentException != null) {
                btnMore.Enabled = true;
                txtExceptionStack.Text = sentException.ToString() + "\r\n\r\nStack:\r\n" + sentException.StackTrace;
            }

          
        }

        private void btnMore_Click(object sender, EventArgs e) {
            if (string.Equals(btnMore.Text, "More")) {
                this.Height = 512;
                btnMore.Text = "Less";
            } else {
                this.Height = 203;
                btnMore.Text = "More";
            }
        }

        private void btnExceptionOk_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void btnSendToAdmin_Click(object sender, EventArgs e) {
            Bitmap bitmap = FrontendUtils.GetScreenShot();
            string bitmapFileName = Path.GetTempPath() + DateTime.Now.Date.Day + "-" + DateTime.Now.Date.Month + "-" + DateTime.Now.Date.Year + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + "-" + DateTime.Now.Millisecond + ".jpeg";
            bitmap.Save(bitmapFileName);
            FrontendUtils.SendEmailWithAttachement(FrontendUtils.GetCurrentUser()+" - "+sentErrorText, sentException, bitmapFileName);
            this.Close();
        }

    }
}
