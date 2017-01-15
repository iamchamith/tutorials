using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;

namespace ALL.Controllers
{
    public class CookiesController : ApiController
    {
        //https://www.asp.net/web-api/overview/advanced/http-cookies
        // when client request some web page, server create a cookie with following attribute
        // and add to the request header and send to client.
        /*
        Domain,Path,Expires,Max-age 
        */
        [HttpGet]
        public HttpResponseMessage Set() {

            var resp = new HttpResponseMessage();
            var nv = new NameValueCollection();
            nv["sid"] = "12345";
            nv["token"] = "abcdef";
            nv["theme"] = "dark blue";
            var cookie = new CookieHeaderValue("session", nv);
            cookie.Expires = DateTimeOffset.Now.AddDays(1);
            cookie.Domain = Request.RequestUri.Host;
            cookie.Path = "/";

            resp.Headers.AddCookies(new CookieHeaderValue[] { cookie });
            return resp;
        }

        // this is not working. but we can get cookie value from browser and send to the client
        public HttpResponseMessage Get()
        {
            string sessionId = Request.Properties["session"] as string;

            return new HttpResponseMessage()
            {
                Content = new StringContent("Your session ID = " + sessionId)
            };
        }
    }
}
