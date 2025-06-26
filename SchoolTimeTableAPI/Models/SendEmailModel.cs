using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolTimeTableApi.Models
{
    public class SendEmailModel
    {
        public int Id { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public string SubjectName { get; set; }
    }
}