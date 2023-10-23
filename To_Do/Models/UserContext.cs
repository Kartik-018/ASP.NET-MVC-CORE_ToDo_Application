using Microsoft.EntityFrameworkCore;

namespace To_Do.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            
        }
        public DbSet<User> User { get; set; }

    }
}
