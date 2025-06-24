using SchoolTimeTableApi.Auths;
using SchoolTimeTableApi.Models;
using SchoolTimeTableBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace SchoolTimeTableApi.Controllers
{
    [EnableCors("*", "*", "*")]
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("api/teacher/login")]
        public HttpResponseMessage AuthTeacher(Login login)
        {
            var tk = AuthService.Auth(login.Email, login.Password);
            if (tk != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, tk.Key);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Teacher Crentials");
            }
        }


        [HttpPost]
        [Route("api/student/login")]
        public HttpResponseMessage AuthStudent(Login login)
        {
            var tk = StudentAuthService.Auth(login.Email, login.Password);
            if (tk != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, tk.Key);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.Unauthorized, "Invalid Student Crentials");
            }
        }

        [TeacherLogged]
        [HttpPost]
        [Route("api/logout")]
        public HttpResponseMessage Logout()
        {
            var token = Request.Headers.Authorization.ToString();
            var rettk = AuthService.Logout(token);
            return Request.CreateResponse(HttpStatusCode.OK, rettk);
        }
    }
}
