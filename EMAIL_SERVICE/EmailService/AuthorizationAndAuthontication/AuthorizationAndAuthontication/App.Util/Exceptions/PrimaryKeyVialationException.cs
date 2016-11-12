using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.Exceptions
{
    public class PrimaryKeyVialationException:Exception
    {
        public PrimaryKeyVialationException() : base()
        {
        }

        public PrimaryKeyVialationException(string message) : base(message)
        {

        }
    }
}
