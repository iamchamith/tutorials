using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace DependancyInjections.Controllers
{
    public class ExceptionsController : ApiController
    {

        public async Task<IHttpActionResult> GetItem(int id)
        {

            throw new HttpResponseException(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.Forbidden,
                ReasonPhrase = "item not found",
                Content = new StringContent(string.Format("No product with ID = {0}", id)),

            });
        }
        public async Task<HttpResponseMessage> GetProduct(int id)
        {
            if (id == 1)
            {
                var message = string.Format("Product with id = {0} not found", id);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { name = "pencile", id = 2 });
            }
        }
    }
}
