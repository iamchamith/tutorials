using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace StudentManegementSystem.Util
{
    public class ActionResult
    {
        public bool Success { get; set; }
        public List<string> Messages { get; set; }
        public string Message { get; set; }
        public object Content { get; set; }
        public State State { get; set; }

        public string ExceptionMessage { get; set; }
        public string ExceptionStackTrace { get; set; }
    }
    public enum State
    {
        Success = 0,
        Error500 = 1, // server error
        Error400 = 2, // bad request [validation errors]
        Error401 = 3, // unauthorized
    }

    public class ActionResultProcess
    { 
        public static ActionResult Success(object content = null, string message = "Success", List<string> messages = null)
        {
            return new ActionResult
            {
                Content = content,
                Message = message,
                Messages = messages ?? new List<string>(),
                State = State.Success,
                Success = true
            };
        }
        public static ActionResult Error(Exception ex = null, string message = "Not success", List<string> messages = null, State state = State.Error400)
        {
#if DEBUG
            return new ActionResult
            {
                Content = null,
                Message = message,
                Messages = messages ?? new List<string>(),
                State = state,
                Success = false,
                ExceptionMessage = ex.Message,
                ExceptionStackTrace = ex.StackTrace
            };
#else
            message = "not success";
            return new ActionResult
            {
                Content = null,
                Message = message,
                Messages = messages ?? new List<string>(),
                State = state,
                Success = false
            };
#endif
        }


    }
}