using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Entities;

namespace MyApp.Domain.Contracts.Infrastructure
{
    public interface IAppDbContext
    {
        DbSet<Order> Orders { get; set; }

        DbSet<Window> Windows { get; set; }

        DbSet<SubElement> SubElements { get; set; }

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
