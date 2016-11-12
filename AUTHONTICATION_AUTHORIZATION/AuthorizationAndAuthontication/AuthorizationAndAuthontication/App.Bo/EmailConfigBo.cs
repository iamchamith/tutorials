using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Bo
{
    public class EmailConfigBo
    {
        public string SendEmail { get; set; }
        public string Password { get; set; }
        public string SmtpAddress { get; set; }
        public int PortNumber { get; set; }
        public bool EnableSSL { get; set; }
    }
}
