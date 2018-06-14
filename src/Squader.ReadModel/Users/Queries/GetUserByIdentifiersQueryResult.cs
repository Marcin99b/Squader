using Squader.Cqrs;
using Squader.DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.ReadModel.Users.Queries
{
    public class GetUserByIdentifiersQueryResult :IQueryResult
    {
       

        public User User { get;}

        public GetUserByIdentifiersQueryResult(User user)
        {
            User = user;
        }
    }
}
