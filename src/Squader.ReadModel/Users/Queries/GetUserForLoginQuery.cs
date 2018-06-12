using Squader.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.ReadModel.Users.Queries
{
    public class GetUserForLoginQuery : IQuery
    {
        public string Email { get; set; }
    }
}
