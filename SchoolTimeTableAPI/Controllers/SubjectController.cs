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
    [RoutePrefix("api/subject")]
    public class SubjectController : ApiController
    {
        [TeacherLogged]
        [HttpGet]
        [Route("get/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = SubjectService.Get();
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
                var data = SubjectService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("add")]
        public HttpResponseMessage Add(SubjectDTO subjectDTO)
        {
            try
            {
                SubjectService.Add(subjectDTO); 
                ClassSectionSubjectService.AssignClassSectionSubject();
                return Request.CreateResponse(HttpStatusCode.Created, "Subject added successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPut]
        [Route("update")]
        public HttpResponseMessage Update(SubjectDTO subjectDTO)
        {
            try
            {
                SubjectService.Update(subjectDTO);
                return Request.CreateResponse(HttpStatusCode.OK, "Subject updated successfully.");
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
                SubjectService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Subject deleted successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
