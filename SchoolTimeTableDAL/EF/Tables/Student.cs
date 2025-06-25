using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.EF.Tables
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Phone { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string Gender { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(600)]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(100)]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Status { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime AdmissionDate { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime UpdatedAt { get; set; }
    }
}
