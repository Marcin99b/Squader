using Squader.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.ReadModel.Users.QueryResults
{
    public class GetUserForLoginQueryResult :IQueryResult
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
    }
}
