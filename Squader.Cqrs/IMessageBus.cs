using System.Threading.Tasks;

namespace Squader.Cqrs
{
    public interface IMessageBus
    {
        Task ExecuteAsync<T>(T command) where T : ICommand;
    }
}
