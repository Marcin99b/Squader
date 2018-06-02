using System.Threading.Tasks;

namespace Squader.Cqrs
{
    public interface IQueryBus
    {
        Task<W> ExecuteAsync<T,W>(T query) 
            where W :IQueryResult
            where T :IQuery;
    }
}