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
    [RoutePrefix("api/slot")]
    public class SlotController : ApiController
    {
        [TeacherLogged]
        [HttpGet]
        [Route("get/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = SlotService.Get();
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
                var data = SlotService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(SlotDTO SlotDTO)
        {
            try
            {
                SlotService.Add(SlotDTO);
                RoomSlotService.AssignRoomSlot();
                return Request.CreateResponse(HttpStatusCode.Created, "Slot added successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(SlotDTO SlotDTO)
        {
            try
            {
                SlotService.Update(SlotDTO);
                return Request.CreateResponse(HttpStatusCode.OK, "Slot updated successfully.");
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
                SlotService.Delete(id);
                RoomSlotService.AssignRoomSlot();
                return Request.CreateResponse(HttpStatusCode.OK, "Slot deleted successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
