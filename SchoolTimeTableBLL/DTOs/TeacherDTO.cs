using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableBLL.DTOs
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public int Subject { get; set; }
        public int Salary { get; set; }
        public DateTime JoinDate { get; set; }
        public string Password { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
