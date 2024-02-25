using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.Data.Configurations
{
    internal sealed class WindowConfiguration : IEntityTypeConfiguration<Window>
    {
        public void Configure(EntityTypeBuilder<Window> builder)
        {
            builder.ToTable(nameof(Window));

            builder.HasKey(window => window.Id);

            builder.Property(window => window.Name).IsRequired();
            builder.Property(window => window.Quantity).IsRequired();

            builder.HasOne(window => window.Order)
                .WithMany(order => order.Windows)
                .HasForeignKey(window => window.OrderId);

            builder.HasMany(window => window.SubElements)
                .WithOne(subElement => subElement.Window)
                .HasForeignKey(subElement => subElement.WindowId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
