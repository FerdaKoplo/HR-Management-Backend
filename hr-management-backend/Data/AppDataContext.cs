using hr_management_backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace hr_management_backend.Data
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Salary> Salaries { get; set; }
        public DbSet<Recruitment> Recruitments { get; set; }
        public DbSet<EmployeeTraining> EmployeeTraining { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<JobTitle> JobTitles { get; set; }
        public DbSet<Training> Training { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Department → Employees
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.JobTitle)
                .WithMany(j => j.Employees)
                .HasForeignKey(e => e.JobTitleId)
                .OnDelete(DeleteBehavior.Restrict);

            // Employee → Attendance
            modelBuilder.Entity<Attendance>()
                .HasOne(a => a.Employee)
                .WithMany(e => e.Attendances)
                .HasForeignKey(a => a.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee → Salary
            modelBuilder.Entity<Salary>()
                .HasOne(s => s.Employee)
                .WithMany(e => e.Salaries)
                .HasForeignKey(s => s.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // Employee → Evaluation
            modelBuilder.Entity<Evaluation>()
                .HasOne(ev => ev.Employee)
                .WithMany(e => e.Evaluations)
                .HasForeignKey(ev => ev.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            // EmployeeTraining many-to-many
            modelBuilder.Entity<EmployeeTraining>()
                .HasKey(et => new { et.EmployeeId, et.TrainingId });

            modelBuilder.Entity<EmployeeTraining>()
                .HasOne(et => et.Employee)
                .WithMany(e => e.EmployeeTrainings)
                .HasForeignKey(et => et.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EmployeeTraining>()
                .HasOne(et => et.Training)
                .WithMany(t => t.EmployeeTrainings)
                .HasForeignKey(et => et.TrainingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Recruitment>(entity =>
            {
                entity.Property(e => e.Status)
                .HasDefaultValue(RecruitmentStatus.Pending);

                entity.HasOne(r => r.JobTitle)
                    .WithMany(j => j.Recruitments)
                    .HasForeignKey(r => r.JobTitleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Department>()
                .HasOne(d => d.Manager)
                .WithMany() // if an employee can manage only one department
                .HasForeignKey(d => d.ManagerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(u => u.Email).IsUnique();

                entity.Property(u => u.Role);
                // Relationship: User → Employee (optional, since EmployeeId is nullable)
                entity.HasOne(u => u.Employee)
                    .WithOne(e => e.User) // if Employee has a navigation property back
                    .HasForeignKey<User>(u => u.EmployeeId)
                    .OnDelete(DeleteBehavior.SetNull); // If employee deleted, keep user but set EmployeeId = null
            });

            base.OnModelCreating(modelBuilder);

            // Seed Admin user
            var adminPassword = BCrypt.Net.BCrypt.HashPassword("Admin123!");

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1, 
                Name = "admin",
                Email = "admin@example.com",
                Password = adminPassword, 
                Role = UserRole.Admin
            });
        }
    }
}
