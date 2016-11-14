using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.EmailService.ViewModel
{
    public class ForgetPasswordEmailViewModel: CommanEmailViewModel
    {
        public string ReseverName { get; set; }
        public string NewPassword { get; set; }
    }
}
