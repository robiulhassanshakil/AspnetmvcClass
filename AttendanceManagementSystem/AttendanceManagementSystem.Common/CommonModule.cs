using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AttendanceManagementSystem.Common
{
    public class CommonModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public CommonModule()
        {
            
        }
        public CommonModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            
            base.Load(builder);
        }
    }
}
