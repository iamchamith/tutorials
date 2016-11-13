using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Util.Enums
{
    public class Enums
    {
        public enum ResponseState {
            Success = 200,
            ServerError = 500,
            ValidationError = 403
        }
    }
}
