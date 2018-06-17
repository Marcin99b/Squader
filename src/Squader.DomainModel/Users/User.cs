using System;
using System.ComponentModel.DataAnnotations;

namespace Squader.DomainModel.Users
{
    public class User
    {
        [Key]
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

        private User() { }
        
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
            CreatedAt = DateTime.UtcNow;
            IsDeleted = false;
        }

        public void SetUsername(string username)
        {
            if (username == null)
            {
                return;;
            }
            Username = username;
            UpdateVersion();
        }

        public void SetEmail(string email)
        {
            if (email == null)
            {
                return; ;
            }
            Email = email;
            UpdateVersion();
        }

        public void SetForename(string forename)
        {
            if (forename == null)
            {
                return; ;
            }
            Forename = forename;
            UpdateVersion();
        }

        public void SetSurname(string surname)
        {
            if (surname == null)
            {
                return; ;
            }
            Surname = surname;
            UpdateVersion();
        }

        public void SetCity(string city)
        {
            if (city == null)
            {
                return; ;
            }
            City = city;
            UpdateVersion();
        }

        public void SethashPassword(string hashPassword)
        {
            if (hashPassword == null)
            {
                return; ;
            }
            HashPassword = hashPassword;
            UpdateVersion();
        }

        public void SetSalt(string salt)
        {
            if (salt == null)
            {
                return; ;
            }
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
