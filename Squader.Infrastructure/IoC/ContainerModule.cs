using Autofac;
using Microsoft.Extensions.Configuration;
using Squader.Infrastructure.IoC.Modules;

namespace Squader.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<CommandModule>();
        }
    }
}
