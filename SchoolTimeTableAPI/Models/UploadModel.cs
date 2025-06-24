using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolTimeTableApi.Models
{
    public class UploadModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadDate { get; set; }
    }
}