using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using Autofac;
using Squader.Cqrs;
using Squader.DomainModel.Advertisements.Commands;
using Squader.DomainModel.Advertisements.Commands.Handlers;

namespace Squader.IoC.Modules
{
    public class CommandModule : Autofac.Module
    { 
        protected override void Load(ContainerBuilder builder)
        {
            var list = new List<string>();
            var stack = new Stack<Assembly>();

            stack.Push(Assembly.GetEntryAssembly());
            do
            {
                var asm = stack.Pop();

                if (asm.FullName.Contains("Squader.DomainModel"))
                {
                    var handlers = asm.GetTypes()
                        .Where(type => typeof(ICommandHandler).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
                        .ToList();

                    foreach (var handler in handlers)
                    {
                        builder.RegisterType(handler)
                            .As(handler.GetInterfaces().First())
                            .InstancePerLifetimeScope();
                    }
                }

                foreach (var reference in asm.GetReferencedAssemblies())
                    if (!list.Contains(reference.FullName))
                    {
                        stack.Push(Assembly.Load(reference));
                        list.Add(reference.FullName);
                    }

            }
            while (stack.Count > 0);
             

            builder.RegisterType<CommandBus>()
                .As<ICommandBus>()
                .InstancePerLifetimeScope();
            
        }
        
    }
}
