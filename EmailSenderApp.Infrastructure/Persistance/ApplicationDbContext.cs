using EmailSenderApp.Domain.Entites.Models.AuthModels;
using Microsoft.EntityFrameworkCore;

namespace EmailSenderApp.Infrastructure.Persistance
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<User> Users { get; set; }
    }
}
