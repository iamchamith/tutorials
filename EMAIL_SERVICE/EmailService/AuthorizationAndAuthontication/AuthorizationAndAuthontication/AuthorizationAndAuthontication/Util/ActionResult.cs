using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorizationAndAuthontication.Util
{
    public class ActionResult
    {
        public bool success { get; set; }
        public string message { get; set; }
        public List<string> messageList { get; set; }
        public object content { get; set; }
        public string exceptionName { get; set; }
        public string exceptionStack { get; set; }
        public string rederectUrl { get; set; }
        public EResponseCode ResponseCode { get; set; }
    }

    public enum EResponseCode
    {
        Success = 0,
        Error500 = 1,
        Error404 = 2,
        Error403 = 3,
        Error401 = 4
    }

    public class Actions
    {
        public static ActionResult Success(object content = null, string message = "success", List<string> messageList = null, string rederectUrl = "")
        {
            return new ActionResult
            {
                message = message,
                content = content,
                success = true,
                rederectUrl = rederectUrl,
                messageList = messageList,
                ResponseCode = EResponseCode.Success

            };
        }

        public static ActionResult Error(Exception ex, string message = "not success", List<string> messageList = null, string rederectUrl = "", EResponseCode responseCode = EResponseCode.Error401)
        {
            return new ActionResult
            {
                message = message,
                content = null,
                success = false,
                rederectUrl = rederectUrl,
                messageList = messageList,
                ResponseCode = responseCode,
                exceptionName = ex.Message,
                exceptionStack = ex.StackTrace,
                
            };
        }
    }
}