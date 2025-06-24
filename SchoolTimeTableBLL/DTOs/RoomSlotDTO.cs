using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableBLL.DTOs
{
    public class RoomSlotDTO
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
        public int SlotId { get; set; }
        public int Status { get; set; }
    }
}
