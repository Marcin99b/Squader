using System.Threading.Tasks;

namespace Squader.Web.Cqrs
{
    public interface ICommandHandler<T> where T : ICommand
    {
        Task HandleAsync(T command);
    }
}
