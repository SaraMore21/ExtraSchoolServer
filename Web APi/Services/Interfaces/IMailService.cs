using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IMailService
    {
        public void SendEmail(string contactAddress, string subject, string body);

        public void SendEmailWithAttachment(string toEmail, string subject, string body, string attachmentPath);
    }
}
