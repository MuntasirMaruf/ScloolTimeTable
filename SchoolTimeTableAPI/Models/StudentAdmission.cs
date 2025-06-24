using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolTimeTableApi.Models
{
    public class StudentAdmission
    {
        public int StudentRoll { get; set; }
        public string ClassName { get; set; }
        public string SectionName { get; set; }
    }
}