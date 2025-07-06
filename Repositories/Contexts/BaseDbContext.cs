using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repositories.Contexts;

public class BaseDbContext : DbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Applicant> Applicants { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Blacklist> Blacklists { get; set; }
    public DbSet<Application> Applications { get; set; }
    public DbSet<Bootcamp> Bootcamps { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}