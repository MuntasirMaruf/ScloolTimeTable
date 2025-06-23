using SchoolTimeTableBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace SchoolTimeTableApi.Auths
{
    public class TeacherLogged : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var header = actionContext.Request.Headers.Authorization;
            if (header == null)
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Unauthorized. Please supply the token.");

            }
            else if (!AuthService.IsTokenValid(header.Parameter))
            {
                actionContext.Response = actionContext.Request.CreateResponse(System.Net.HttpStatusCode.Unauthorized, "Supplied token is invalid or expired");
            }

            base.OnAuthorization(actionContext);
        }
    }
}