using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace To_Do.Models
{
    public class ToDoItems
    {
        public ToDoItems()
        {
            date_added = DateTime.Now;
        }
        [Key]
        public int todo_id { get; set; }

        [Column(TypeName ="varchar(MAX)")]
        public string task_name { get; set; }

        [Column(TypeName ="date")]
        public DateTime date_added 
        {
            get;set;
        }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd MMM yy}")]
        [Column(TypeName = "date")]
        public DateTime due_date { get; set; }

        [ForeignKey("FK_toDoItems_User")]
        public int user_id { get; set; }
    }
   
}
