using System;
using Squader.DomainModel.Users;

namespace Squader.Api.Areas.Users.Dtos
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public DateTime ChangedAt { get; set; }
        public DateTime CreatedAt { get; set; }

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
