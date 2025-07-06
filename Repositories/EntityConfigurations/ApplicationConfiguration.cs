using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityConfigurations;

public class ApplicationConfiguration : IEntityTypeConfiguration<Application>
{
    public void Configure(EntityTypeBuilder<Application> builder)
    {
        builder.ToTable("Applications");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.ApplicantId);
        
        builder.Property(x => x.BootcampId);
        
        builder.Property(x => x.ApplicationState)
            .IsRequired();
        
        // Application - Bootcamp ilişkisi (çok Application - bir Bootcamp)
        builder.HasOne(x => x.Bootcamp)
            .WithMany(x => x.Applications) // Bootcamp entity'sinde ICollection<Application> Applications olmalı
            .HasForeignKey(x => x.BootcampId)
            .OnDelete(DeleteBehavior.Cascade);

        // Application - Applicant ilişkisi (çok Application - bir Applicant)
        builder.HasOne(x => x.Applicant)
            .WithMany(x => x.Applications) // Applicant entity'sinde ICollection<Application> Applications olmalı
            .HasForeignKey(x => x.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}