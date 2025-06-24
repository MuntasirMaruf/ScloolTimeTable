using SchoolTimeTableApi.Auths;
using SchoolTimeTableBLL.DTOs;
using SchoolTimeTableBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SchoolTimeTableApi.Controllers
{
    [RoutePrefix("api/room")]
    public class RoomController : ApiController
    {
        [TeacherLogged]
        [HttpGet]
        [Route("get/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = RoomService.Get();
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
                var data = RoomService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(RoomDTO RoomDTO)
        {
            try
            {
                RoomService.Add(RoomDTO);
                RoomSlotService.AssignRoomSlot();
                return Request.CreateResponse(HttpStatusCode.Created, "Room added successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(RoomDTO RoomDTO)
        {
            try
            {
                RoomService.Update(RoomDTO);
                return Request.CreateResponse(HttpStatusCode.OK, "Room updated successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                RoomService.Delete(id);
                RoomSlotService.AssignRoomSlot();
                return Request.CreateResponse(HttpStatusCode.OK, "Room deleted successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
