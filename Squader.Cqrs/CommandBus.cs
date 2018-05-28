using System;
using System.Threading.Tasks;
using Autofac;

namespace Squader.Cqrs
{
    public class MessageBus : IMessageBus
    {
        private readonly Func<Type, ICommandHandler> _handlersFactory;

        public MessageBus(Func<Type, ICommandHandler> handlersFactory)
        {
            _handlersFactory = handlersFactory;
        }

        public async Task ExecuteAsync<T>(T command) where T : ICommand
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command),
                    $"Command: '{typeof(T).Name}' can not be null.");
            }
            var handler = (ICommandHandler<T>)_handlersFactory(typeof(T));

            await handler.HandleAsync(command);
        }
    }
}
