using System.Threading.Tasks;

namespace Squader.Cqrs
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
