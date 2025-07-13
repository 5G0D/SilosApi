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

        builder.Property(e => e.StartDate)
            .HasColumnType("date");

        builder.Property(e => e.HarvestYear)
            .HasMaxLength(4);

        builder.Property(e => e.AdditionalInfo)
            .HasMaxLength(500);
    }
}