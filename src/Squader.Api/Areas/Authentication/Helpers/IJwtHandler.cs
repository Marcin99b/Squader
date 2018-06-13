using Squader.Api.Areas.Authentication.Dtos;
using Squader.DomainModel.Users;
using Squader.ReadModel.Users.Queries;
using System;
using System.Security.Claims;
using System.Threading.Tasks;


namespace Squader.Api.Areas.Authentication.Helpers
{
    public interface IJwtHandler
    {
        Task<JwtDto> CreateTokenAsync(Guid userId, string role);
        Task<JwtDto> CreateTokenByUserObject(User user);
        Task<JwtDto> RefreshTokenAsync(ClaimsPrincipal userToken);
    }
}
