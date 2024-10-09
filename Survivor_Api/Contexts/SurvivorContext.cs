using Microsoft.EntityFrameworkCore;
using Survivor_Api.Entities;

namespace Survivor_Api.Contexts
{
    public class SurvivorContext : DbContext
    {
        public SurvivorContext(DbContextOptions<SurvivorContext> options)
            : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Competitor> Competitors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Competitor entity
            modelBuilder.Entity<Competitor>()
                .HasKey(c => c.Id);

            modelBuilder.Entity<Competitor>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Competitor>()
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Competitor>()
                .HasOne(c => c.Category)
                .WithMany(cat => cat.Competitors)
                .HasForeignKey(c => c.CategoryId);

            // Configure Category entity
            modelBuilder.Entity<Category>()
                .HasKey(cat => cat.Id);

            modelBuilder.Entity<Category>()
                .Property(cat => cat.Name)
                .IsRequired()
                .HasMaxLength(100);
        }
    }

}
