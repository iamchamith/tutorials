using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.Emails.Infrastructure
{
    public interface IEmail
    {
        void Send(string message, string body, List<string> emails);
    }
}
