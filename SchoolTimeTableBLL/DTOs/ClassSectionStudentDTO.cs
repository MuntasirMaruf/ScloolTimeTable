using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableBLL.DTOs
{
    public class ClassSectionStudentDTO
    {
        public int Id { get; set; }
        public int ClassSectionId { get; set; }
        public int StudentId { get; set; }
        public int Status { get; set; }
    }
}
