using Squader.Cqrs;
using Squader.DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.ReadModel.Users.Queries
{
    public class GetUserByUsernameQueryResult :IQueryResult
    {
        public User User { get; }

        public GetUserByUsernameQueryResult(User user)
        {
            User = user;
        }

    }
}
