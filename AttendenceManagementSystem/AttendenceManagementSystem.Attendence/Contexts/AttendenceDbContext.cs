using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using AttendenceManagementSystem.Attendence.Entities;
using Autofac;
using Microsoft.EntityFrameworkCore;

namespace AttendenceManagementSystem.Attendence.Contexts
{
    public class AttendenceDbContext:DbContext,IAttendenceDbContext
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public AttendenceDbContext(string connectionString, string migrationAssemblyName)
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

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Student> Students;
        public DbSet<Attendance> Attendances;
    }
}
