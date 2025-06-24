using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableBLL.DTOs
{
    public class ScheduleDTO
    {
        public int Id { get; set; }
        public int ClassSectionStudentId { get; set; }
        public int TeacherId { get; set; }
        public int RoomSlotId { get; set; }
        public int Status { get; set; }
    }
}
