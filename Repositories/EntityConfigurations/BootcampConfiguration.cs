using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityConfigurations;

public class BootcampConfiguration : IEntityTypeConfiguration<Bootcamp>
{
    public void Configure(EntityTypeBuilder<Bootcamp> builder)
    {
        builder.ToTable("Bootcamps");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(x => x.StartDate)
            .IsRequired();

        builder.Property(x => x.EndDate)
            .IsRequired();

        builder.Property(x => x.BootcampState)
            .IsRequired();

// Bootcamp - Instructor ilişkisi
        builder.HasOne(x => x.Instructor)
            .WithMany(x => x.Bootcamps)    // Instructor entity'sinde ICollection<Bootcamp> Bootcamps olmalı
            .HasForeignKey(x => x.InstructorId)
            .OnDelete(DeleteBehavior.Restrict);

// Bootcamp - Applications ilişkisi
        builder.HasMany(x => x.Applications)
            .WithOne(x => x.Bootcamp)      // Application entity'sinde Bootcamp Bootcamp olmalı
            .HasForeignKey(x => x.BootcampId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}