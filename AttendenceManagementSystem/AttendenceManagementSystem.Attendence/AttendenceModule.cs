﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendenceManagementSystem.Attendence.Contexts;
using AttendenceManagementSystem.Attendence.Repositories;
using AttendenceManagementSystem.Attendence.Services;
using AttendenceManagementSystem.Attendence.UniteOfWork;
using Autofac;

namespace AttendenceManagementSystem.Attendence
{
    public class AttendenceModule:Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public AttendenceModule(string connectionString,string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AttendenceDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<AttendenceDbContext>().As<IAttendenceDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<AttendenceUniteOfWork>().As<IAttendenceUniteOfWork>()
                .InstancePerMatchingLifetimeScope();

            builder.RegisterType<AttdenceService>().As<IAttdenceService>()
                .InstancePerMatchingLifetimeScope();

            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
                .InstancePerMatchingLifetimeScope();

            builder.RegisterType<AttendenceRepository>().As<IAttendenceRepository>()
                .InstancePerMatchingLifetimeScope();

            

            base.Load(builder);
        }
    }
}
