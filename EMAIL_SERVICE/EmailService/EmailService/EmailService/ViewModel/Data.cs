using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailService.ViewModel
{
    public class Data
    {
        public static string[] RegisterTemplate()
        {
            return new[]
            {
                "" +
                "Dear #ReseverName#" +
                "Please Verify Email, following #Link#","Email Validation"
            };
        }

        public static string[] ForgetPasswordTemplate()
        {
            return new[]
            {
                "" +
                "Dear #ReseverName#" +
                "This is your new password #NewPassword#","Forget password"
            };
        }
    }
}
