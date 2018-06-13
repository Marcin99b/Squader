using Squader.Cqrs;

namespace Squader.DomainModel.Users.Commands
{
    public class CreateNewUserCommand : ICommand
    {
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Forename { get; private set; }
        public string Surname { get; private set; }
        public string City { get; private set; }
        public string HashPassword { get; private set; }
        public string Salt { get; private set; }

        public CreateNewUserCommand(string username, string email, string forename, string surname, string city, 
            string hashPassword, string salt)
        {
            Username = username;
            Email = email;
            Forename = forename;
            Surname = surname;
            City = city;
            HashPassword = hashPassword;
            Salt = salt;
        }
    }
}
