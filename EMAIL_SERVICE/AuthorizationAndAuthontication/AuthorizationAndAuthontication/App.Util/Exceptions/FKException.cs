using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.Exceptions
{
    public class FKException:Exception
    {
        public FKException() : base()
        {
        }

        public FKException(string message) : base(message)
        {

        }
    }
}
