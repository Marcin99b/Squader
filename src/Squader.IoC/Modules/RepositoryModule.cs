using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Squader.DomainModel.Repositories;
using Squader.Infrastructure.Repositories;

namespace Squader.IoC.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var list = new List<string>();
            var stack = new Stack<Assembly>();
            var projects = new List<string>();
            stack.Push(Assembly.GetEntryAssembly());
            do
            {
                var asm = stack.Pop();
                if(asm.FullName.Contains("Squader"))
                    projects.Add(asm.FullName);

                if (asm.FullName.Contains("Squader.Infrastructure"))
                {
                    builder.RegisterAssemblyTypes(asm)
                        .Where(x => x.IsAssignableTo<IRepository>())
                        .AsImplementedInterfaces()
                        .InstancePerLifetimeScope();
                }

                foreach (var reference in asm.GetReferencedAssemblies())
                    if (!list.Contains(reference.FullName))
                    {
                        stack.Push(Assembly.Load(reference));
                        list.Add(reference.FullName);
                    }

            }
            while (stack.Count > 0);
        }
    }
}
