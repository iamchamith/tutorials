using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.Exceptions
{
    public class InvaliedUserLoginInfomationException:Exception
    {
        public InvaliedUserLoginInfomationException() : base()
        {

        }
        public InvaliedUserLoginInfomationException(string message) : base(message)
        {

        }
    }

    public class EmailAddressNotValidateException : Exception
    {
        public EmailAddressNotValidateException() : base()
        {

        }
        public EmailAddressNotValidateException(string message) : base(message)
        {

        }
    }

}
