using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace SchoolTimeTableApi.Models
{
    public class TimeTableModel
    {
        public string ClassName { get; set; }
        public string SectionName { get; set; }
        public string SubjectName { get; set; }
        public int RoomNumber { get; set; }
        public int SlotId { get; set; }
    }
}