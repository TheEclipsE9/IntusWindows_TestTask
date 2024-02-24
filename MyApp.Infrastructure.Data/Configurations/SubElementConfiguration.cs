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

            builder.Property(subElement => subElement.Type);
            builder.Property(subElement => subElement.Width);
            builder.Property(subElement => subElement.Height);

            builder.HasOne(subElement => subElement.Window)
                .WithMany(window => window.SubElements)
                .HasForeignKey(subElement => subElement.WindowId);
        }
    }
}
