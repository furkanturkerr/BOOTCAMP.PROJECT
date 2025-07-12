using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EntityConfigurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.Property(i => i.CompanyName).IsRequired();
        builder.HasMany(i => i.Bootcamps)
            .WithOne(b => b.Instructor)
            .HasForeignKey(b => b.InstructorId);
    }

}