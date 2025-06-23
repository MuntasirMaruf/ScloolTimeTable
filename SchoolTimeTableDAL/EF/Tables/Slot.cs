using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.EF.Tables
{
    public class Slot
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime StartTime { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime EndTime { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Status { get; set; }
    }
}
