using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolTimeTableDAL.EF.Tables
{
    public class Login
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int Roll { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int UserType { get; set; }

        [Required]
        [Column(TypeName = "DATETIME")]
        public DateTime LastLogged { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int UserStatus { get; set; }

        [Required]
        [Column(TypeName = "INT")]
        public int UserId { get; set; }

    }
}
