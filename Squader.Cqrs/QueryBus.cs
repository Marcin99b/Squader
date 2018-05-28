using System;
using System.Threading.Tasks;

namespace Squader.Cqrs
{
    public class QueryBus : IQueryBus
    {
        private readonly Func<Type, IQueryHandler> _handlersFactory;
        public QueryBus(Func<Type, IQueryHandler> handlersFactory)
        {
            _handlersFactory = handlersFactory;
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
            var handler = (IQueryHandler<T,W>)_handlersFactory(typeof(T));

            return await handler.HandleAsync(query);
        }
    }
}