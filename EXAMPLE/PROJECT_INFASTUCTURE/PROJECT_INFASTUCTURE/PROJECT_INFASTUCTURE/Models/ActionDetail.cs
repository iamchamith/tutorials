using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PROJECT_INFASTUCTURE.Models
{
    public class ActionDetail
    {
        public object Content { get; set; }
        public bool State { get; set; }
        public string Message { get; set; }
        public List<string> Messages { get; set; }
        public string RederectUrl { get; set; }
        public App.Util.Enums.Enums.ResponseState ResponseState { get; set; }

        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
    }

    public class Actions {

        public static ActionDetail Success(object content=null,string message="success",string url="/",
            List<string> messageList = null) {

            return new ActionDetail
            {
                Content = content,
                ExceptionMessage = string.Empty,
                ExceptionStackTrace = string.Empty,
                Message = message,
                Messages = messageList ?? new List<string>(),
                RederectUrl = url,
                ResponseState = App.Util.Enums.Enums.ResponseState.Success,
                State = true

            };
        }

        public static  ActionDetail Error(Exception ex,string  message="Error",List<string> messageList=null,string url="/", App.Util.Enums.Enums.ResponseState responseState = App.Util.Enums.Enums.ResponseState.ServerError) {

            return new ActionDetail
            {
                Content = null,
                ExceptionMessage = ex.Message,
                ExceptionStackTrace =ex.StackTrace,
                Message = message,
                Messages = messageList ?? new List<string>(),
                RederectUrl = url,
                ResponseState = responseState,
                State = false

            };
        }

    }
}
