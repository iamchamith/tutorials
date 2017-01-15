using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace DependancyInjections.Controllers
{
    public class TracingController : ApiController
    {
        public HttpResponseMessage GetTrace() {

            ITraceWriter x = Configuration.Services.GetTraceWriter();
            x.Trace(Request, "Category", TraceLevel.Error, $"this is test");

            return null;
        }
    }
}
