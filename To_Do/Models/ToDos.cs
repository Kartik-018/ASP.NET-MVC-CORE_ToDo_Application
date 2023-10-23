using Microsoft.EntityFrameworkCore;

namespace To_Do.Models
{
    public class ToDos:DbContext
    {

        public ToDos(DbContextOptions<ToDos> options) : base(options)
        {
            
        }
        public DbSet<ToDoItems> toDoItems { get; set; }
        public DbSet<BargraphItems> bargraphItems { get; set; }
    }
}
