using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.EF.Tables
{
    public class TimeTable
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int ClassSectionSubjectId { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int RoomSlotId { get; set; }
    }
}
