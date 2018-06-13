using System;
using Autofac;
using Autofac.Core;

namespace Squader.Cqrs
{
    public class QueryBus : IQueryBus
    {
        private IComponentContext _context;
        public QueryBus(IComponentContext context)
        {
            _context = context;
        }

        public W Execute<W>(IQuery<W> query) where W : IQueryResult
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query),
                    $"Query: '{query.GetType().Name}' can not be null.");
            }
            var handlerType = typeof(IQueryHandler<,>)
                .MakeGenericType(query.GetType(), typeof(W));
            dynamic handler = _context.Resolve(handlerType);
            return handler.Handle((dynamic)query);
        }
    }
}