using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squader.Api.Areas.Authentication.Dtos
{
    public class LoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
