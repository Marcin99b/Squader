using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.DomainModel.Users
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; set; }
        public string Password { get; protected set; }
        public string Salt { get; protected set; }
    }
}
