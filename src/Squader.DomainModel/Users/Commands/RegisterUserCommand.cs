using Squader.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.DomainModel.Users.Commands
{
    public class RegisterUserCommand :ICommand
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public string HashPassword { get; private set; }
        public string Salt { get; private set; }

        public RegisterUserCommand(string username, string email, string hashPassword, string salt)
        {
            Username = username;
            Email = email;
            CreatedAt = DateTime.Now;
            HashPassword = hashPassword;
            Salt = salt;
        }
    }
}
