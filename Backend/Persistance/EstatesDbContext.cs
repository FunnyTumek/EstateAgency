using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistance.Configurations;

namespace Persistance
{
    public class EstatesDbContext : DbContext
    {
        public EstatesDbContext(DbContextOptions options)
    : base(options)
        {
        }

        public DbSet<Estates> Estates { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new EstatesConfiguration());
        }
    }
}

