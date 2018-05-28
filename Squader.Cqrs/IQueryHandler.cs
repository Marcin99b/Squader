using System.Threading.Tasks;

namespace Squader.Cqrs
{
    public interface IQueryHandler
    {

    }
    public interface IQueryHandler<T> : IQueryHandler where T :IQuery
    {
          Task HandleAsync(T query);
    }
}