using SchoolTimeTableApi.Auths;
using SchoolTimeTableBLL.DTOs;
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
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/student")]
    public class StudentController : ApiController
    {

        [TeacherLogged]
        [HttpGet]
        [Route("get/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = StudentService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex);
            }
        }

        [TeacherLogged]
        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                var data = StudentService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex);
            }
        }

        [TeacherLogged]
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(StudentDTO studentDTO)
        {
            try
            {
                StudentService.Add(studentDTO);
                return Request.CreateResponse(HttpStatusCode.Created, "Student added successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [TeacherLogged]
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(StudentDTO studentDTO)
        {
            try
            {
                StudentService.Update(studentDTO);
                return Request.CreateResponse(HttpStatusCode.OK, "Student updated successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        [TeacherLogged]
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                StudentService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Student deleted successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}
