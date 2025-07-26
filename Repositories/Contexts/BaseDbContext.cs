using Core.Entities;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repositories.EntityConfigurations;
using Role = Core.Entities.Role;

namespace Repositories.Contexts;

public class BaseDbContext : DbContext
{
    public DbSet<Role> Roles { get; set; }
    public DbSet<UserRoleMapping> UserRoles { get; set; }

    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
    {
        
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
            entity.Property(e => e.NationalityIdentity).IsRequired().HasMaxLength(11);
            entity.Property(e => e.DateOfBirth).IsRequired();
            entity.Property(e => e.PasswordHash).IsRequired();
            entity.Property(e => e.PasswordSalt).IsRequired();

            entity.HasIndex(e => e.Email).IsUnique();
            entity.HasIndex(e => e.NationalityIdentity).IsUnique();
        });
        
        modelBuilder.Entity<UserRoleMapping>(entity =>
        {
            entity.ToTable("UserRoles");
            entity.HasKey(e => new { e.UserId, e.RoleId });

            entity.HasOne(ur => ur.User)
                .WithMany(u => u.UserRoles)
                .HasForeignKey(ur => ur.UserId);

            entity.HasOne(ur => ur.Role)
                .WithMany()
                .HasForeignKey(ur => ur.RoleId);
        });



        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Roles");
            entity.Property(e => e.Name).IsRequired().HasMaxLength(50);
        });

    }
    public DbSet<User> Users { get; set; } 
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Blacklist> Blacklists { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Bootcamp> Bootcamps { get; set; }


}