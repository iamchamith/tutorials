using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EMSystem.Setup;
using System.Web.Mvc;
using System.Text;

namespace EMSystem.Helpers
{
    public class BaseController : Controller
    {
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new JsonContractResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = behavior };
        }
    }
}