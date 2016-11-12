using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AuthorizationAndAuthontication.Util
{
    public class SessionNotValiedException : Exception
    {
        public SessionNotValiedException() : base() { }

        public SessionNotValiedException(string message) : base(message) { }
    }

    public class UnauthorizeAccessException : Exception
    {
        public UnauthorizeAccessException() : base() { }

        public UnauthorizeAccessException(string message) : base(message) { }
    }
}