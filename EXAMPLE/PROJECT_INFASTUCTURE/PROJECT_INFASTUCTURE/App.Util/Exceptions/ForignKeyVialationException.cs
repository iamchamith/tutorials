using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.Exceptions
{
    public class ForignKeyVialationException:Exception
    {
        public ForignKeyVialationException() : base(){ }
        public ForignKeyVialationException(string message) : base(message) { }
    }
}
