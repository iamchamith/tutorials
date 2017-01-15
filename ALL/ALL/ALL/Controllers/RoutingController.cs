using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ALL.Controllers
{
    [RoutePrefix("api2/{v}")]
    public class RoutingController : ApiController
    {

        // ATTRIBUTE ROUTING
        //www.github.com/api/v1/{userName}/{repo}/assert/typeScript/{file}

        [HttpGet]
        [Route("{userName}/{repo}/assert/typeScript/{file}")]
        //give same result
        // [Route("v1/{userName}/{repo}/assert/typeScript/{file}")]
        //example
        //http://localhost:7777/api/v1/iamchamith/sample/assert/typeScript/comman
        public HttpResponseMessage AttributeRouting_1(string v, string userName, string repo, string file)
        {

            return new HttpResponseMessage
            {
                Content = new StringContent($"this is {v}->{userName}->{repo}->{file}")
            };
        }

        // CONVENTION BASE ROUTING 
        //default routing is conceptualBase routing
        //example
        //http://localhost:7777/api/Routing/ConventionBaseRouting
        [HttpGet]
        public HttpResponseMessage ConventionBaseRouting()
        {

            return new HttpResponseMessage
            {
                Content = new StringContent("this is Convention base routing")
            };
        }

        // ROUTING WITH ACTION VERBS
        //http://localhost:7777/api/v3/iamchamith
        [Route("{username}")]
        [ActionName("AV")]
        [HttpGet]
        public HttpResponseMessage ActionVerb(string username)
        {

            return new HttpResponseMessage
            {
                Content = new StringContent("action verb routing")
            };
        }

        //ROUTER CONSTRANT
        // if constrant true http://localhost:7777/api/v3/12/880240684v/22
        //else 404
        [Route("{id:int}/{nic:length(10)}/{age:range(18,75)}")]
        [HttpGet]
        public HttpResponseMessage SampleRouterConstrant(int id, string nic, int age)
        {

            return new HttpResponseMessage
            {
                Content = new StringContent($"id:{id} | nic:{nic} | age :{age}")
            };
        }

        // DEFAULT AND OPTIONAL PARAMETERS
        [Route("default/{id:int?}")]
        [HttpGet]
        public HttpResponseMessage DefaultValue(int id = 1033) {
            return new HttpResponseMessage {
                Content = new StringContent($"id : {id}")
            };
        }

        [Route("default2/{id:int=1033}")]
        public HttpResponseMessage OptionalUrl(int id)
        {
            return new HttpResponseMessage
            {
                Content = new StringContent($"id : {id}")
            };
        }
    }
}
