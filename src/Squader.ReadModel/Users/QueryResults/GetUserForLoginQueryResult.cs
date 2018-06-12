﻿using Squader.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.ReadModel.Users.QueryResults
{
    public class GetUserForLoginQueryResult :IQueryResult
    {
       

        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public GetUserForLoginQueryResult(Guid id, string email, string username, string role, string password, string salt)
        {
            Id = id;
            Email = email;
            Username = username;
            Role = role;
            Password = password;
            Salt = salt;
        }
    }
}
