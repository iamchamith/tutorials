using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.Emails.ViewModel
{
    public class EmailViewModel
    {
        public EnumEmailType.EEnumEmailType EnumEmailType { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
