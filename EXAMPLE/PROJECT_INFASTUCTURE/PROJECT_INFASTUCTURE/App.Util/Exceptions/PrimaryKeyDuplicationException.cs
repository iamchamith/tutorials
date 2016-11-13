using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.Exceptions
{
    public class PrimaryKeyDuplicationException:Exception
    {
        public PrimaryKeyDuplicationException() : base(){ }
        public PrimaryKeyDuplicationException(string message) : base(message) { }
    }
}
