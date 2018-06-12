using System;
using Squader.Common;
using Squader.Common.CustomObjects;

namespace Squader.DomainModel.Users
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Forename { get; private set; }
        public string Surname { get; private set; }
        public string City { get; private set; }
        public string HashPassword { get; private set; }
        public string Salt { get; private set; }
        public DateTime ChangedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public User()
        {
        }

        public User(string username, string email, string forename, string surname, string city, string hashPassword,
            string salt)
        {
            Id = Guid.NewGuid().ToShort();
            SetUsername(username);
            SetEmail(email);
            SetForename(forename);
            SetSurname(surname);
            SetCity(city);
            SethashPassword(hashPassword);
            SetSalt(salt);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUsername(string username)
        {
            Username = username;
            UpdateVersion();
        }

        public void SetEmail(string email)
        {
            Email = email;
            UpdateVersion();
        }

        public void SetForename(string forename)
        {
            Forename = forename;
            UpdateVersion();
        }

        public void SetSurname(string surname)
        {
            Surname = surname;
            UpdateVersion();
        }

        public void SetCity(string city)
        {
            City = city;
            UpdateVersion();
        }

        public void SethashPassword(string hashPassword)
        {
            HashPassword = hashPassword;
            UpdateVersion();
        }

        public void SetSalt(string salt)
        {
            Salt = salt;
            UpdateVersion();
        }

        private void UpdateVersion()
        {
            ChangedAt = DateTime.UtcNow;
        }
    }
}
