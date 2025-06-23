using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.EF.Tables
{
    public class Class
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Status { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime? CreatedAt { get; set; }

        [Column(TypeName = "DATETIME")]
        public DateTime? UpdatedAt { get; set; }
    }
}
