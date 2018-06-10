using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Squader.Api.Areas.Authentication.Dtos
{
    public class UserForJwtDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
    }
}
