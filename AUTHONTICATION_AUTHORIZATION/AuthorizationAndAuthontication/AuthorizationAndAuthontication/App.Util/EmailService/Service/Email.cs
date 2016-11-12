using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using App.Bo;

namespace App.Util.EmailService.Service
{
    public class Email
    {
        public Email(EmailConfigBo senderConfig, List<string> toEmails, string subject, string body)
        {
            try
            {
                string smtpAddress = senderConfig.SmtpAddress;
                int portNumber = senderConfig.PortNumber;
                bool enableSSL = senderConfig.EnableSSL;

                string emailFrom = senderConfig.SendEmail;
                string password = senderConfig.Password;
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(emailFrom);
                    foreach (var items in toEmails)
                    {
                        mail.To.Add(items);
                    }
                    mail.Subject = subject;
                    mail.Body = body;
                    mail.IsBodyHtml = true;
                    // Can set to false, if you are sending pure text.

                    using (SmtpClient smtp = new SmtpClient(smtpAddress, portNumber))
                    {
                        smtp.Credentials = new NetworkCredential(emailFrom, password);
                        smtp.EnableSsl = enableSSL;
                        smtp.Send(mail);
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
