using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityConfigurations;

public class ApplicantConfiguration : IEntityTypeConfiguration<Applicant>
{
    public void Configure(EntityTypeBuilder<Applicant> builder)
    {
        builder.Property(a => a.About).IsRequired(false);
        builder.HasMany(a => a.Applications)
            .WithOne(app => app.Applicant)
            .HasForeignKey(app => app.ApplicantId);
    }

}