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

    [RoutePrefix("api/roomslot")]
    public class RoomSlotController : ApiController
    {

        [HttpGet]
        [Route("get/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = RoomSlotService.Get();
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
                RoomSlotService.AssignRoomSlot();
                return Request.CreateResponse(HttpStatusCode.OK, "Room Slot Assigned Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
