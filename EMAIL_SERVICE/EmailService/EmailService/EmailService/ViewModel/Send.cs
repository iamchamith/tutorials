using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.ViewModel
{
    public class Send
    {
        public Send(MailAddressCollection emails, string subject, string body)
        {
            Console.WriteLine("logThis ");
        }
    }
}
