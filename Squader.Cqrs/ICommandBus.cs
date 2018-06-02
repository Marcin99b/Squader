using System.Threading.Tasks;

namespace Squader.Cqrs
{
    public interface ICommandBus
    {
        Task ExecuteAsync<T>(T command) where T : ICommand;
    }
}
