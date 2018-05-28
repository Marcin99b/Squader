using System.Threading.Tasks;

namespace Squader.Cqrs
{
    public interface IQueryHandler
    {

    }
    public interface IQueryHandler<T, W> : IQueryHandler 
    where T :IQuery
    where W :IQueryResult

    {
          Task<W> HandleAsync(T query);
    }
}