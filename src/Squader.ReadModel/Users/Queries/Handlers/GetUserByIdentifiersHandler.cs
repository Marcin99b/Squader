using Squader.Common.Extensions;
using Squader.Cqrs;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Squader.ReadModel.Users.Queries.Handlers
{
    public class GetUserByIdentifiersHandler : IQueryHandler<GetUserByIdentifiersQuery, GetUserByIdentifiersQueryResult>
    {
        public GetUserByIdentifiersQueryResult Handle(GetUserByIdentifiersQuery query)
        {
            if (query.UserIdentifier.IsEmail()) { }
            throw new NotImplementedException();
        }
    }
}
