using System;
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
            base.Load(builder);

            var handlers = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                .Where(b => typeof(ICommandHandler).IsAssignableFrom(b) && !b.IsInterface && !b.IsAbstract)
                .ToList();

            foreach (var handler in handlers)
            {
                builder.RegisterType(handler)
                    .As(handler.GetInterfaces().First())
                    .InstancePerLifetimeScope();
            }
            
            builder.Register<Func<Type, ICommandHandler>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(ICommandHandler<>).MakeGenericType(t);
                    return (ICommandHandler)ctx.Resolve(handlerType);
                };
            });

            builder.RegisterType<MessageBus>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
        }
    }
}
