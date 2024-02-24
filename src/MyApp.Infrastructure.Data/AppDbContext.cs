using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Contracts.Infrastructure;
using MyApp.Domain.Entities;
using MyApp.Infrastructure.Data.Configurations;

namespace MyApp.Infrastructure.Data
{
    public sealed class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Order> Orders { get; set; }

        public DbSet<Window> Windows { get; set; }

        public DbSet<SubElement> SubElements { get; set; }

        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new WindowConfiguration());
            modelBuilder.ApplyConfiguration(new SubElementConfiguration());
        }
    }
}
