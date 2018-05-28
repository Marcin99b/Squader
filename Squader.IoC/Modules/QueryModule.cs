using System;
using System.Linq;
using Autofac;
using Squader.Cqrs;

namespace Squader.IoC.Modules
{
    public class QueryModule :Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            var handlers = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes())
                .Where(b => typeof(IQueryHandler).IsAssignableFrom(b) && !b.IsInterface && !b.IsAbstract)
                .ToList();

            foreach (var handler in handlers)
            {
                builder.RegisterType(handler)
                    .As(handler.GetInterfaces().First())
                    .InstancePerLifetimeScope();
            }
            
            builder.Register<Func<Type, IQueryHandler>>(c =>
            {
                var ctx = c.Resolve<IComponentContext>();

                return t =>
                {
                    var handlerType = typeof(IQueryHandler<,>).MakeGenericType(t);
                    return (IQueryHandler)ctx.Resolve(handlerType);
                };
            });

            builder.RegisterType<QueryBus>()
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
            
        }
    }
        
    
}