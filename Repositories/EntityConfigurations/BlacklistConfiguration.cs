using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityConfigurations;

public class BlacklistConfiguration : IEntityTypeConfiguration<Blacklist>
{
    public void Configure(EntityTypeBuilder<Blacklist> builder)
    {
        builder.HasKey(b => b.Id);
        builder.Property(b => b.Reason).IsRequired();
        builder.Property(b => b.Date).IsRequired();
        builder.HasOne(b => b.Applicant)
            .WithMany()
            .HasForeignKey(b => b.ApplicantId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}