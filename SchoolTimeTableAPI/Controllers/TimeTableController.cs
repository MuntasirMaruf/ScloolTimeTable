using SchoolTimeTableApi.Auths;
using SchoolTimeTableApi.Models;
using SchoolTimeTableBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolTimeTableApi.Controllers
{
    [RoutePrefix("api/time/table")]
    public class TimeTableController : ApiController
    {
        [HttpGet]
        [Route("get/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = TimeTableService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [TeacherLogged]
        [HttpGet]
        [Route("get")]

        public HttpResponseMessage GetTime(TimeSlotModel ts)
        {
            try
            {
                var data = TimeTableService.GetTimeSlot(ts.ClassName, ts.SectionName, ts.SubjectName);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [TeacherLogged]
        [HttpPost]
        [Route("sendmail")]

        public HttpResponseMessage GetTime(SendEmailModel ts)
        {
            try
            {
                TimeTableService.EmailTimeSlot(ts.Id, ts.ClassName, ts.SectionName, ts.SubjectName);
                return Request.CreateResponse(HttpStatusCode.OK, "Mail Sent");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [TeacherLogged]
        [HttpPost]
        [Route("add")]

        public HttpResponseMessage Assign(TimeTableModel tm)
        {
            try
            {
                TimeTableService.AddTimeTable(tm.ClassName, tm.SectionName, tm.SubjectName, tm.RoomNumber, tm.SlotId);
                return Request.CreateResponse(HttpStatusCode.OK, "Time Table Assigned Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
