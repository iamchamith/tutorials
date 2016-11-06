using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.Exception
{
    public class ForignKeyVialationException : System.Exception
    {
        public ForignKeyVialationException() : base("FK vialation") { }
        public ForignKeyVialationException(string message) : base(message) { }
    }
}
