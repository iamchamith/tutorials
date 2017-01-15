using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DependancyInjections.Controllers
{
    [RoutePrefix("api2")]
    public class RoutingExampleController : ApiController
    {
        [Route("customers/{customerId}/orders")]
        public IEnumerable<string> GetOrdersByCustomer(int customerId)
        {
            return new List<string>() {
                "A","B","C"
            };
        }

        [Route("github/{user}/{repo}/blob/master/{file}")]
        public string GetFile(string user, string repo, string file)
        {

            return $"{user}-> {repo}->{file}";
        }

        [Route("user/{id:int}")]
        public string GetUser(int id)
        {

            return "Chamith " + id;
        }
    }
}
