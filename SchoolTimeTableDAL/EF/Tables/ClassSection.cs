using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.EF.Tables
{
    public class ClassSection
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int ClassId { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int SectionId { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int StudentCount { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Status { get; set; }
    }
}
