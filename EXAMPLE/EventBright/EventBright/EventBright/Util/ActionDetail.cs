using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EventBright.Util
{
    public class JsonResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public object data { get; set; }
        public int responseCode { get; set; }
        public List<string> messageList { get; set; }
        public string rederectUrl { get; set; }
        public string exceptionMessage { get; set; }
        public string exceptionStackTrace { get; set; }
    }

    public class ResponseMessage
    {

        public static JsonResult Success(object content = null, string message_ = "success", string rederectUtl_ = "")
        {
            return new JsonResult
            {
                data = content,
                message = message_,
                rederectUrl = rederectUtl_,
                success = true,
                responseCode = (int)ResponseCode.Success
            };
        }
        public static JsonResult Error(Exception ex, string message_ = "not success", string rederectUrl_ = "", ResponseCode ResponseCode= ResponseCode.BadRequest,List<string > messageList_=null)
        {
            return new JsonResult
            {
                message = message_,
                rederectUrl = rederectUrl_,
                success = true,
                responseCode = (int)ResponseCode,
                exceptionMessage = ex.Message,
                exceptionStackTrace = ex.StackTrace,
                data = null,
                messageList = messageList_
            };
        }
    }

    public enum ResponseCode
    {
        Success,
        Error500,
        Error401,
        Error404,
        BadRequest
    }
}