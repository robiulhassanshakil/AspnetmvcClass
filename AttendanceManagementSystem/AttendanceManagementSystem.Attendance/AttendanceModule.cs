using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceManagementSystem.Attendance.Contexts;
using AttendanceManagementSystem.Attendance.Repositories;
using AttendanceManagementSystem.Attendance.Services;
using AttendanceManagementSystem.Attendance.UniteOfWork;
using Autofac;

namespace AttendanceManagementSystem.Attendance
{
    public class AttendanceModule:Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public AttendanceModule(string connectionString,string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AttendanceDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<AttendanceDbContext>().As<IAttendanceDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<AttendanceUniteOfWork>().As<IAttendanceUniteOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AttendanceService>().As<IAttendanceService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AttendanceRepository>().As<IAttendanceRepository>()
                .InstancePerLifetimeScope();

            

            base.Load(builder);
        }
    }
}
