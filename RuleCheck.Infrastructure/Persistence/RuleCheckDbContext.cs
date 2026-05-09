using Microsoft.EntityFrameworkCore;
using RuleCheck.Domain.Entities;

namespace RuleCheck.Infrastructure.Persistence
{
    public class RuleCheckDbContext : DbContext
    {
        public RuleCheckDbContext(DbContextOptions<RuleCheckDbContext> options)
            : base(options)
        {
        }

        public DbSet<Rule> Rules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RuleCheckDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}