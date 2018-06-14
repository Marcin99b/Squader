using System;
using Squader.Cqrs;

namespace Squader.DomainModel.Users.Commands
{
    public class UpdateUserCommand : ICommand
    {
        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Forename { get; private set; }
        public string Surname { get; private set; }
        public string City { get; private set; }

        public UpdateUserCommand(Guid userId, string username, string email, string forename, string surname, string city)
        {
            UserId = userId;
            Username = username;
            Email = email;
            Forename = forename;
            Surname = surname;
            City = city;
        }
    }
}
