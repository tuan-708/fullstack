using Microsoft.EntityFrameworkCore;

namespace DemoAutoMigration.Models
{
    public class JobContext : DbContext
    {
        public JobContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Job> jobs { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }
    }
}
