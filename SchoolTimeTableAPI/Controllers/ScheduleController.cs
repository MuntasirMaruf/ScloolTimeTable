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
    [RoutePrefix("api/schedule")]
    public class ScheduleController : ApiController
    {
        [HttpGet]
        [Route("get/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = ScheduleService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = ScheduleService.GetSchedule(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [Route("sendmail/{id}")]
        public HttpResponseMessage SendEmail(int id)
        {
            try
            {
                ScheduleService.SendEmail(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Email Sent");
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
                ScheduleService.AssignSchedule();
                return Request.CreateResponse(HttpStatusCode.OK, "Schedule Assigned Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
