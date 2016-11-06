using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.Exception
{
    public class ItemNotFoundException:System.Exception
    {
        public ItemNotFoundException() : base("Item not found") { }
        public ItemNotFoundException(string message) : base(message) { }
    }
}
