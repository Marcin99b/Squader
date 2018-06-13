using Squader.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.ReadModel.Users.Queries
{
    public class GetUserByIdentifiersQuery : IQuery<GetUserByIdentifiersQueryResult>
    {
        public string UserIdentifier { get; set; }

        public GetUserByIdentifiersQuery(string identifier)
        {
            UserIdentifier = identifier;
        }
    }
}
