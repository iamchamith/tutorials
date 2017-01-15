using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ALL.Controllers
{
    public class WindowsResponseController : ApiController
    {
        [HttpGet]
        public async Task<HttpResponseMessage> Get(string test)
        {
            return new HttpResponseMessage(HttpStatusCode.OK) {
                Content = new StringContent (JsonConvert.SerializeObject(new string[] { "value1", "value2",test }))
            };
        }

        // POST: api/WindowsResponse
        [HttpPost]
        public async Task<HttpResponseMessage> Post(string value)
        {
            return new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StringContent($"Success post: {value}")
            };
        }
 
    }
}
