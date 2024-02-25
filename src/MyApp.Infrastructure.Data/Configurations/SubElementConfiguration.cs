using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyApp.Domain.Entities;

namespace MyApp.Infrastructure.Data.Configurations
{
    internal sealed class SubElementConfiguration : IEntityTypeConfiguration<SubElement>
    {
        public void Configure(EntityTypeBuilder<SubElement> builder)
        {
            builder.ToTable(nameof(SubElement));

            builder.HasKey(subElement => subElement.Id);

            builder.Property(subElement => subElement.Type).IsRequired();
            builder.Property(subElement => subElement.Width).IsRequired();
            builder.Property(subElement => subElement.Height).IsRequired();

            builder.HasOne(subElement => subElement.Window)
                .WithMany(window => window.SubElements)
                .HasForeignKey(subElement => subElement.WindowId);
        }
    }
}
