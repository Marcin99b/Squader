using System.Threading.Tasks;

namespace Squader.Cqrs
{
    public interface ICommandHandler
    {
    }

    public interface ICommandHandler<T> : ICommandHandler where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
