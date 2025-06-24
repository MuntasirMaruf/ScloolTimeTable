using SchoolTimeTableBLL.DTOs;
using SchoolTimeTableBLL.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace SchoolTimeTableApi.Controllers
{
    public class UploadController : ApiController
    {
        [HttpPost]
        [Route("api/upload")]
        public async Task<IHttpActionResult> UploadFile()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                return BadRequest("Unsupported media type.");
            }

            var root = HttpContext.Current.Server.MapPath("~/UploadedFiles");
            if (!Directory.Exists(root))
            {
                Directory.CreateDirectory(root);
            }

            var provider = new MultipartFormDataStreamProvider(root);

            try
            {
                await Request.Content.ReadAsMultipartAsync(provider);

                foreach (MultipartFileData fileData in provider.FileData)
                {
                    var originalFileName = fileData.Headers.ContentDisposition.FileName.Trim('\"');
                    var newFilePath = Path.Combine(root, originalFileName);

                    if (File.Exists(newFilePath))
                        File.Delete(newFilePath);

                    File.Move(fileData.LocalFileName, newFilePath);
                    var schoolDocumentDto = new SchoolDocumentDTO()
                    {
                        FileName = originalFileName,
                        FilePath = "/UploadedFiles/" + originalFileName,
                        UploadDate = DateTime.Now
                    };

                    UploadService.Add(schoolDocumentDto);
                }

                return Ok("File(s) uploaded and saved to database.");
            }
            catch (System.Exception e)
            {
                return InternalServerError(e);
            }
        }

        [HttpGet]
        [Route("api/all")]
        public HttpResponseMessage Get()
        {
            try
            {
                var data = UploadService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, data);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.OK, ex);
            }
        }

    }
}
