using Squader.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.ReadModel.Users.Queries
{
    public class GetUserByUsernameQuery :IQuery<GetUserByUsernameQueryResult>
    {
        public string Username { get; set; }

        public GetUserByUsernameQuery(string username)
        {
            Username = username;
        }
    }
}
