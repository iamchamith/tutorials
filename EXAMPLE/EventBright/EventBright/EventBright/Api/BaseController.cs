using App.DbService.DbService;
using App.DbService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EventBright.Api
{
    public class BaseController : ApiController
    {
        protected EventService eventService = null;
        public BaseController() {
            eventService = new EventService();
        }
    }
}
