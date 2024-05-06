using BolognaInformationSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace BolognaInformationSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<LearningOutcome> LearningOutcomes { get; set; }
        public DbSet<ProgramOutcome> ProgramOutcomes { get; set; }
        public DbSet<OutcomeRelation> OutcomeRelations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // OutcomeRelation için birleşik anahtar tanımlama
            modelBuilder.Entity<OutcomeRelation>()
                .HasKey(or => new { or.OutcomeID, or.ProgramOutcomeID });
        }
    }
}
