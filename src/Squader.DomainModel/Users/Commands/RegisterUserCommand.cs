using Squader.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.DomainModel.Users.Commands
{
    public class RegisterUserCommand :ICommand
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string HashPassword { get; private set; }
        public string Salt { get; private set; }

        public RegisterUserCommand(string username, string email, string hashPassword, string salt)
        {
            Username = username;
            Email = email;
            HashPassword = hashPassword;
            Salt = salt;
        }
    
    }
}
