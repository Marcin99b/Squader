using Squader.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.ReadModel.Users.Queries
{
    public class GetUserForLoginQuery : IQuery
    {
        public string UserIdentifier { get; set; }

        public GetUserForLoginQuery(string identifier)
        {
            UserIdentifier = identifier;
        }
    }
}
