using System.Threading.Tasks;

namespace Squader.Web.Cqrs
{
    public interface ICommandDispatcher
    {
        Task DispatchAsync<T>(T command) where T : ICommand;
    }
}
