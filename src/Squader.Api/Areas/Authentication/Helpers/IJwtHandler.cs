using Squader.Api.Areas.Authentication.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Squader.Api.Areas.Authentication.Helpers
{
    public interface IJwtHandler
    {
        Task<JwtDto> CreateTokenAsync(Guid userId, string role);
        Task<JwtDto> CreateTokenByUserObject(UserForJwtDto user);
        Task<JwtDto> RefreshTokenAsync(ClaimsPrincipal userToken);
    }
}
