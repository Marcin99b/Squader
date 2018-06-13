using System.Threading.Tasks;

namespace Squader.Cqrs
{
    public interface IQueryBus
    {
        W Execute<W>(IQuery<W> query) where W : IQueryResult;
    }
    
}