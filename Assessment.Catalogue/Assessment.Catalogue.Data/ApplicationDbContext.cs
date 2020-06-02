using Assessment.Catalogue.Data.Configurations;
using Assessment.Catalogue.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assessment.Catalogue.Data
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
        public DbSet<Book> Books { get; set; }

    }
}
