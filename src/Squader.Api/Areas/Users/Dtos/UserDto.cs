using System;
using Squader.DomainModel.Users;

namespace Squader.Api.Areas.Users.Dtos
{
    public class UserDto
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Forename { get; private set; }
        public string Surname { get; private set; }
        public string City { get; private set; }
        public DateTime ChangedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public UserDto(User user)
        {
            Id = user.Id;
            Username = user.Username;
            Email = user.Email;
            Forename = user.Forename;
            Surname = user.Surname;
            City = user.City;
            ChangedAt = user.ChangedAt;
            CreatedAt = user.CreatedAt;
        }
    }
}
