using System;
using System.Collections.Generic;
using ClassAttendance.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ClassAttendance.Data
{
    public class ClassAttendanceDbContext : DbContext
    {
        private const string LocalDb = "Server=(localdb)\\MSSQLLocalDB;Database=ClassAttendanceDB;Trusted_Connection=True;MultipleActiveResultSets=True";

        public DbSet<ApplicationUserRole> Roles { get; set; }
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }

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
            base.OnModelCreating(modelBuilder);
        }

    }
}