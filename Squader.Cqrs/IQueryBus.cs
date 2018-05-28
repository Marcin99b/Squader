using System.Threading.Tasks;

namespace Squader.Cqrs
{
    public interface IQueryBus
    {
        Task<W> ExecuteAsync<T,W>(T Query) 
            where W :IQueryResult
            where T :IQuery;
    }
}