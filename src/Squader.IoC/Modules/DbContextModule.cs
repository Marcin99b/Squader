using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Squader.Infrastructure.DAL;

namespace Squader.IoC.Modules
{
    class DbContextModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ApplicationDbContext>()
                .As<IContext>()
                .InstancePerLifetimeScope();
        }
    }
}
