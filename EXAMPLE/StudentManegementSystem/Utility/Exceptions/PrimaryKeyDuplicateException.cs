using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Exceptions
{
    public class PrimaryKeyDuplicateException:Exception
    {
        public PrimaryKeyDuplicateException(string message) : base(message) { }
    }
}
