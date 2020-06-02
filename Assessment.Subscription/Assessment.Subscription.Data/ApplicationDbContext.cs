using Assessment.Subscription.Data.Configurations;
using Assessment.Subscription.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Subscription.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
        }
        public DbSet<Domain.Entities.Subscription> Books { get; set; }

    }
}
