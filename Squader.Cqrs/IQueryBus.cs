using System.Threading.Tasks;

namespace Squader.Cqrs
{
    public interface IQueryBus
    {
        Task ExecuteAsync<T>(T query) where T :IQuery;
    }
}