using System;
using System.Threading.Tasks;
using Autofac;

namespace Squader.Cqrs
{
    public class MessageBus : IMessageBus
    {
        private readonly IComponentContext _context;

        public MessageBus(IComponentContext context)
        {
            _context = context;
        }

        public async Task ExecuteAsync<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command),
                    $"Command: '{typeof(T).Name}' can not be null.");
            }
            
            var handler = _context.Resolve<ICommandHandler<T>>();
            await handler.HandleAsync(command);
        }
    }
}
