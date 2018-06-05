using System;
using System.Threading.Tasks;
using Autofac;

namespace Squader.Cqrs
{
    public class QueryBus : IQueryBus
    {
        private IComponentContext _context;
        public QueryBus(IComponentContext context)
        {
            _context = context;
        }
        
        public async Task<W> ExecuteAsync<T, W>(T query)
            where T : IQuery
            where W : IQueryResult
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query),
                    $"Query: '{typeof(T).Name}' can not be null.");
            }
            var handler = _context.Resolve<IQueryHandler<T,W>>();

            return await handler.HandleAsync(query);
        }
    }
}