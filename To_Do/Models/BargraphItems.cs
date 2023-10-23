using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do.Models
{
    public class BargraphItems
    {
        public BargraphItems()
        {
            this.date = DateTime.Today;
        }

        [Key]
        public int id { get; set; }

        public DateTime date { get; set; }

        [Column(TypeName = "int")]
        public int completed_task { get; set; }

        [ForeignKey("FK_bargraphItems_User")]
        public int user_id { get; set; }
    }
}
