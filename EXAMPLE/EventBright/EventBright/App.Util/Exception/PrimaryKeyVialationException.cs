using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.Exception
{
    public class PrimaryKeyVialationException:System.Exception
    {
        public PrimaryKeyVialationException() : base("Primary key vialation") { }
        public PrimaryKeyVialationException(string message) : base(message) { }
    }
}
