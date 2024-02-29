using EmailSenderApp.Domain.Entites.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderApp.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
    }
}
