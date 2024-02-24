using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.Data.Configurations
{
    internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));

            builder.HasKey(order => order.Id);

            builder.Property(order => order.Name);
            builder.Property(order => order.State);

            builder.HasMany(order => order.Windows)
                .WithOne(window => window.Order)
                .HasForeignKey(window => window.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
