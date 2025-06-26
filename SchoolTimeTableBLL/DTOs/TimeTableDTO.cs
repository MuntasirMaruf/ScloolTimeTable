using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableBLL.DTOs
{
    public class TimeTableDTO
    {
        public int Id { get; set; }
        public int ClassSectionSubjectId { get; set; }
        public int RoomSlotId { get; set; }
    }
}
