using Microsoft.EntityFrameworkCore;
using HRMS.Models; 

// using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HRMS.Data
{
    public class AppDbContext :  IdentityDbContext<User>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relation entre Department et Employee
            modelBuilder.Entity<Department>()
                .HasMany(d => d.Employees) // Un département a plusieurs employés
                .WithOne(e => e.Department) // Un employé appartient à un département
                .HasForeignKey(e => e.DepartmentId) // Clé étrangère dans Employee
                .OnDelete(DeleteBehavior.Restrict); // Empêche la suppression cascade

            base.OnModelCreating(modelBuilder);
        }
    }
}
