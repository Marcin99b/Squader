using System;

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
        public bool IsDeleted { get; private set; }
        public string Role { get; private set; }
        
        public User(string username, string email, string forename, string surname, string city, string hashPassword,
            string salt)
        {
            Id = Guid.NewGuid();
            SetUsername(username);
            SetEmail(email);
            SetForename(forename);
            SetSurname(surname);
            SetCity(city);
            SethashPassword(hashPassword);
            SetSalt(salt);
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
            
        }

        public User(string username, string email, string hashPassword, string salt)
        {
            Username = username;
            Email = email;
            HashPassword = hashPassword;
            Salt = salt;
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

        public void Delete()
        {
            IsDeleted = true;
        }

        private void UpdateVersion()
        {
            ChangedAt = DateTime.UtcNow;
        }
    }
}
