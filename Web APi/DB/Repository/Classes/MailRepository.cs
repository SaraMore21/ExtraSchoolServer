using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using DB.Repository.Interfaces;

namespace DB.Repository.Classes
{
    public class MailRepository : IMailRepository
    {


        public void SendEmail(string contactAddress, string subject, string body)
        {
            string FromMail = "more21automail@gmail.com";
            //string FromMail = "finallproject1@gmail.com";
            string emailTo = contactAddress;
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(FromMail, " More21 Auto Mail");
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
           // mail.ReplyToList.Add("more21service@gmail.com");
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            //SmtpServer.DeliveryFormat= SmtpDeliveryFormat.International;
            SmtpServer.Credentials = new System.Net.NetworkCredential("more21automail@gmail.com", "gnhkhpeofjltfdca");
            //SmtpServer.Credentials = new System.Net.NetworkCredential("more21automail@gmail.com", "16040010");
            //SmtpServer.Credentials = new System.Net.NetworkCredential("finallproject1@gmail.com", "finallProject11");

            //using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            //{
            //    smtp.Credentials = new NetworkCredential("ravcevel.system@gmail.com", "Sari-30020010");
            //    smtp.EnableSsl = true;
            //    smtp.Send(mail);
            //}
            SmtpServer.EnableSsl = true;
            try
            {
               SmtpServer.Send(mail);
            }
            catch (Exception e)
            {

                Console.WriteLine(e.InnerException);
                throw e;

            }
        }


        public void SendEmailWithAttachment(string toEmail, string subject, string body, string attachmentPath)
        {
            string FromMail = "more21automail@gmail.com";
            //string FromMail = "finallproject1@gmail.com";
            string emailTo = toEmail;
            MailMessage mail = new MailMessage();
            mail.IsBodyHtml = true;
            mail.From = new MailAddress(FromMail, " More21 Auto Mail");
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            // mail.ReplyToList.Add("more21service@gmail.com");
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            //SmtpServer.DeliveryFormat= SmtpDeliveryFormat.International;
            SmtpServer.Credentials = new System.Net.NetworkCredential("more21automail@gmail.com", "gnhkhpeofjltfdca");
            //SmtpServer.Credentials = new System.Net.NetworkCredential("more21automail@gmail.com", "16040010");
            //SmtpServer.Credentials = new System.Net.NetworkCredential("finallproject1@gmail.com", "finallProject11");

            //using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            //{
            //    smtp.Credentials = new NetworkCredential("ravcevel.system@gmail.com", "Sari-30020010");
            //    smtp.EnableSsl = true;
            //    smtp.Send(mail);
            //}
            SmtpServer.EnableSsl = true;

            // Attach the file
            Attachment attachment = new Attachment(attachmentPath, MediaTypeNames.Application.Octet);
            mail.Attachments.Add(attachment);

            try
            {
                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Email sending failed: " + ex.Message);
                throw ex;
            }
            finally
            {
                mail.Dispose();
                SmtpServer.Dispose();
            }
        }
    }
}
