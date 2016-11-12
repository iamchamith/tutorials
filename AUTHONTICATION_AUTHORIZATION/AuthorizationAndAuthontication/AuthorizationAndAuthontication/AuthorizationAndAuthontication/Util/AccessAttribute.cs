using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Mvc;
using System.Web.Routing;
using App.Bo.Enums;
using AuthorizationAndAuthontication.Models.User;


namespace AuthorizationAndAuthontication.Util
{
    public class AccessAttribute : System.Web.Http.AuthorizeAttribute
    {
        public string RoleTags { get; set; }
        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            try
            {
                var x = RoleTags;
                var thisUserMode = UserSessionState.UserType;
                var roles = ApplicationState.RoleAccess;

                if (!roles.Exists(p => p.Tag == RoleTags && p.RoleId == thisUserMode))
                {
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Forbidden);
                }
            }
            catch (SessionNotValiedException ex)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }
            catch (Exception ex)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            }


        }


    }
}