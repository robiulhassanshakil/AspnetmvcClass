using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Attendance.Entities;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace AttendanceManagementSystem.Attendance.Contexts
{
    public class AttendanceDbContext:DbContext,IAttendanceDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public AttendanceDbContext(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(_connectionString,
                    m => m.MigrationsAssembly(_migrationAssemblyName));
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasMany(s => s.Attendances)
                .WithOne(a => a.Student);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students;
        public DbSet<Entities.Attendance> Attendances;
    }
}
