using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace StudentManegementSystem.Util
{
    public  class HttpResponseMessageExtention: HttpResponseMessage
    {
        public object Content { get; set; }

    }
}