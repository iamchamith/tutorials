using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.Exceptions
{
    public class ObjectNotFoundException:Exception
    {
        public ObjectNotFoundException() : base(){ }
        public ObjectNotFoundException(string message) : base(message) { }
    }
}
