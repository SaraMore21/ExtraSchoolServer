using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using DB.Repository.Classes;

namespace Services.Classes
{
    public class MailService : IMailService
    {
        public void SendEmail(string Address, string subject, string body)
        {
            try
            {
                new MailRepository().SendEmail(Address, subject, body);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void SendEmailWithAttachment(string toEmail, string subject, string body, string attachmentPath)
        {
            try
            {
                new MailRepository().SendEmailWithAttachment(toEmail, subject, body,attachmentPath);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
