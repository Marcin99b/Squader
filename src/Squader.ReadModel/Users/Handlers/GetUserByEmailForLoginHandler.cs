using Squader.Cqrs;
using Squader.ReadModel.Users.Queries;
using Squader.ReadModel.Users.QueryResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Squader.ReadModel.Users.Handlers
{
    public class GetUserByEmailForLoginHandler : IQueryHandler<GetUserByEmailForLoginQuery, GetUserByEmailForLoginQueryResult>
    {
        public Task<GetUserByEmailForLoginQueryResult> HandleAsync(GetUserByEmailForLoginQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
