using Squader.Cqrs;
using Squader.ReadModel.Users.Queries;
using Squader.ReadModel.Users.QueryResults;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Squader.ReadModel.Users.Handlers
{
    public class GetUserForLoginHandler : IQueryHandler<GetUserForLoginQuery, GetUserForLoginQueryResult>
    {
        public Task<GetUserForLoginQueryResult> HandleAsync(GetUserForLoginQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
