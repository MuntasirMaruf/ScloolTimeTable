using SchoolTimeTableApi.Auths;
using SchoolTimeTableApi.Models;
using SchoolTimeTableBLL.DTOs;
using SchoolTimeTableBLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace SchoolTimeTableApi.Controllers
{
    [RoutePrefix("api/student/admission")]
    public class StudentAdmissionController : ApiController
    {
        [TeacherLogged]
        [HttpGet]
        [Route("get/all")]
        public HttpResponseMessage GetAllAdmissions()
        {
            try
            {
                var data = StudentAdmissionService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [TeacherLogged]
        [HttpGet]
        [Route("get/{id}")]
        public HttpResponseMessage GetAdmission(int id)
        {
            try
            {
                var data = StudentAdmissionService.Get(id);
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPost]
        [Route("admit")]
        public HttpResponseMessage AddAdmission(StudentAdmission admission)
        {
            try
            {
                StudentAdmissionService.Admit(admission.StudentRoll, admission.ClassName, admission.SectionName);
                return Request.CreateResponse(HttpStatusCode.OK, "Admission Successfull");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [HttpPut]
        [Route("update")]
        public HttpResponseMessage UpdateAdmission(ClassSectionStudentDTO admissionDTO)
        {
            try
            {
                StudentAdmissionService.Update(admissionDTO);
                return Request.CreateResponse(HttpStatusCode.OK, "Admission updated successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public HttpResponseMessage DeleteAdmission(int id)
        {
            try
            {
                StudentAdmissionService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, "Admission deleted successfully.");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
