using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace EMS.DB.Models;

public class EMSDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    public EMSDbContext()
    {
    }
    public EMSDbContext(DbContextOptions<EMSDbContext> options, IConfiguration configuration) : base(options)
    {
        _configuration = configuration;
    }

    public DbSet<Employee> Employees { get; set; }
    public DbSet<Location> Locations { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<EmployeeDetail> EmployeeDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("C:\\Users\\alekhya.n\\Desktop\\html\\Task8 CodeFirst\\EMS\\appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("DBConnection"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>()
                .HasKey(e => e.Id);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany()
            .HasForeignKey(e => e.DepartmentId)
            .IsRequired(false);
        
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Role)
            .WithMany()
            .HasForeignKey(e => e.RoleId)
            .IsRequired(false);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Location)
            .WithMany()
            .HasForeignKey(e => e.LocationId)
            .IsRequired(false);

        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Project)
            .WithMany()
            .HasForeignKey(e => e.ProjectId)
            .IsRequired(false);

        modelBuilder.Entity<Location>()
            .HasKey(l => l.Id);
        
        modelBuilder.Entity<Department>()
            .HasKey(d => d.Id);

        modelBuilder.Entity<Role>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Project>()
            .HasKey(p => p.Id);  

        modelBuilder.Entity<EmployeeDetail>() //mapping to the view
            .ToView("EmployeeDetail");
    }
}
