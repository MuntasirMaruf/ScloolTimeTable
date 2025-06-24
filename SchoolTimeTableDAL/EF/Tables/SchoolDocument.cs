using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.EF.Tables
{
    public class SchoolDocument
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Filename { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string FilePath { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime UploadDate { get; set; }
    }
}
