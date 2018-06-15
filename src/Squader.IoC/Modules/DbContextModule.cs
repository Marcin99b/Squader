using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Squader.Infrastructure.DAL;

namespace Squader.IoC.Modules
{
    class DbContextModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(ApplicationDbContext)).As(typeof(IContext)).InstancePerLifetimeScope();
        }
    }
}
