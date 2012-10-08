using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace SemiAutomaticConverter {
   public class EmailRequest {

       public void SendEmailToMultiUsers(string sender, string recipient, string subject, string body) {
           string[] recipients = recipient.Split(';');
           try {
               for (int i = 0; i < recipients.Length; i++) {
                   SendEmail(sender, recipients[i], subject, body,"");
               }
               MessageBox.Show("A new rule request has been sent, \nyou will be notified with the addition shortly.", "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);         
           } catch (Exception ex) {
               ShowCustomError(ex.Message, false);
           }       
       }

       public DialogResult ShowCustomError(string errorText, bool useYesNo) {
           if (!useYesNo) {               
               return MessageBox.Show(errorText, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
           } else {               
               return MessageBox.Show(errorText, "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
           }
       }

       public void SendEmail(string sender,string recipient,string subject,string body, string attachement){

           MailMessage mm = new MailMessage();
           mm.From = new MailAddress("lebaneseamerican.lau@gmail.com");
           mm.To.Add("mzkabbani@gmail.com");
           mm.Subject = "Ant Subject";
           mm.Body = "Body Cha MEssag here ";

           SmtpClient ss = new SmtpClient();
           ss.Host = "smtp.gmail.com";
           ss.Port = 587;
           ss.EnableSsl = true;

           ss.Credentials = new System.Net.NetworkCredential("lebaneseamerican.lau@gmail.com", "19881990");

           ss.Send(mm);

           //MailAddress mailfrom = new MailAddress(sender);
          // MailAddress mailto = new MailAddress(recipient);
           
           
           
           //MailMessage newmsg = new MailMessage("lebaneseamerican.lau@gmail.com", "lebaneseamerican.lau@gmail.com");
           
          
           //newmsg.Subject = subject;
           //newmsg.Body = body;           
           //string[] files = Directory.GetFiles(attachement);
           //for (int i = 0; i < files.Length; i++) {
            //   Attachment att = new Attachment(files[i]);
            //   newmsg.Attachments.Add(att);
          // }

           //SmtpClient smtp = new SmtpClient("smtp.gmail.com");
           //smtp.UseDefaultCredentials = false;
           //smtp.Port = 587;
           
          // smtp.Credentials = new NetworkCredential("lebaneseamerican.lau@gmail.com", "19881990");
           
           //smtp.EnableSsl = true;           
          // smtp.Send(newmsg);          
       }

    }
}
