using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ECommerceSystem.Profile.Contexts;
using ECommerceSystem.Profile.Repositories;
using ECommerceSystem.Profile.Services;
using ECommerceSystem.Profile.UniteOfWorks;

namespace ECommerceSystem.Profile
{
    public class ProfileModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

       
        public ProfileModule(string connectionString,string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductDbContext>().As<IProductDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();
           
            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductUniteOfWork>().As<IProductUniteOfWork>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
