using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentManegementSystem.Util
{
    public class CompressContentAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var response = HttpContext.Current.Response;
            if (response.IsRequestBeingRedirected) return;
            var encoding = HttpContext.Current.Request.Headers["Accept-Encoding"];
            var isSupported = !string.IsNullOrEmpty(encoding) && (encoding.Contains("gzip") || encoding.Contains("deflate"));
            if (isSupported)
            {
                var acceptEncoding = HttpContext.Current.Request.Headers["Accept-Encoding"];
                if (acceptEncoding.Contains("gzip"))
                {
                    response.Filter = new System.IO.Compression.GZipStream(response.Filter, System.IO.Compression.CompressionMode.Compress);
                    response.Headers.Remove("Content-Encoding");
                    response.AppendHeader("Content-Encoding", "gzip");
                }
                else
                {
                    response.Filter = new System.IO.Compression.DeflateStream(response.Filter, System.IO.Compression.CompressionMode.Compress);
                    response.Headers.Remove("Content-Encoding");
                    response.AppendHeader("Content-Encoding", "deflate");
                }
            }
            response.AppendHeader("Vary", "Content-Encoding");
        }
    }

}