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
    [RoutePrefix("api/teacher")]
    public class TeacherController : ApiController
    {
        [HttpGet]
        [Route("get/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = TeacherService.Get();
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
                var data = TeacherService.Get(id);
                if (data == null)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Teacher not found.");
                }
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(TeacherDTO teacherDTO)
        {
            try
            {
                if (teacherDTO == null)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid teacher data.");
                }
                TeacherService.Add(teacherDTO);
                return Request.CreateResponse(HttpStatusCode.Created, "Teacher added successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(TeacherDTO teacherDTO)
        {
            try
            {
                if (teacherDTO == null || teacherDTO.Id <= 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid teacher data.");
                }
                TeacherService.Update(teacherDTO);
                return Request.CreateResponse(HttpStatusCode.OK, "Teacher updated successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Invalid teacher ID.");
                }
                TeacherService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Teacher deleted successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
