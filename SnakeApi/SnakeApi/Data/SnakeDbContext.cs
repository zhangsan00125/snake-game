using Microsoft.EntityFrameworkCore;
using SnakeApi.Models;

namespace SnakeApi.Data
{
    public class SnakeDbContext : DbContext
    {
        public SnakeDbContext(DbContextOptions<SnakeDbContext> options) : base(options)
        {
        }

        public DbSet<Score> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Score>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.ScoreValue).IsRequired();
                entity.Property(e => e.Time).IsRequired();
            });
        }
    }
}
