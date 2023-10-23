using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace To_Do.Models
{
    public class User
    {
        public User()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int user_id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string username { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string user_email { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string password { get; set; }

    }
}
