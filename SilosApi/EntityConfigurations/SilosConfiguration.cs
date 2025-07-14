using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SilosApi.Entities;

namespace SilosApi.EntityConfigurations;

public class SilosConfiguration : IEntityTypeConfiguration<Silos>
{
    public void Configure(EntityTypeBuilder<Silos> builder)
    {
        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(e => e.AdditionalInfo)
            .HasMaxLength(2000);
    }
}