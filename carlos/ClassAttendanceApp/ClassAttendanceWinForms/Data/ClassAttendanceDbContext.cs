using System;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class ClassAttendanceDbContext : DbContext
    {
        private const string LocalDb = "Server=(localdb)\\MSSQLLocalDB;Database=ClassAttendanceDB;Trusted_Connection=True;MultipleActiveResultSets=True";

        public DbSet<ApplicationUserRole> Roles { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(LocalDb)
                    .UseLazyLoadingProxies()
                    .LogTo(Console.WriteLine, new[] { DbLoggerCategory.Database.Command.Name }, LogLevel.Information)
                    .EnableSensitiveDataLogging();
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationUserRole>(m =>
            {
                m.ToTable("Roles").HasKey(r => r.Id);
            });

            modelBuilder.Entity<ApplicationUser>(m =>
            {
                m.ToTable("Users").HasKey(r => r.Id);
            });

            modelBuilder.Entity<Course>(m =>
            {
                m.ToTable("Courses").HasKey(r => r.Id);
            });

            modelBuilder.Entity<Class>(m =>
            {
                m.ToTable("Classes").HasKey(r => r.Id);
            });

            modelBuilder.Entity<Topic>(m =>
            {
                m.ToTable("Topics").HasKey(r => r.Id);
            });

            modelBuilder.Entity<Student>(m =>
            {
                m.ToTable("Students").HasKey(r => r.Id);
            });

            modelBuilder.Entity<Teacher>(m =>
            {
                m.ToTable("Teachers").HasKey(r => r.Id);
            });

            modelBuilder.Entity<StudentCourse>(m =>
            {
                m.ToView("StudentCourse").HasNoKey();
            });
        }

    }
}