using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using FirstDemoExercise.Areas.Admin.Models;
using FirstDemoExercise.Services;

namespace FirstDemoExercise
{
    public class WebModule : Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SimpleDatabaseServicecs>().As<IDatabaseService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CourseListModel>().AsSelf();

            base.Load(builder);
        }
    }
}
