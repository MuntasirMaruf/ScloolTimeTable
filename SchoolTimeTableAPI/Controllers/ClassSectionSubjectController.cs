using SchoolTimeTableApi.Auths;
using SchoolTimeTableBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolTimeTableApi.Controllers
{
    [RoutePrefix("api/class/section/subject")]
    public class ClassSectionSubjectController : ApiController
    {
        [HttpGet]
        [Route("get/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ClassSectionSubjectService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [TeacherLogged]
        [HttpPost]
        [Route("assign")]

        public HttpResponseMessage Assign()
        {
            try
            {
                ClassSectionSubjectService.AssignClassSectionSubject();
                return Request.CreateResponse(HttpStatusCode.OK, "Subjects Assigned Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
