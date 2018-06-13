using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Squader.Api.Areas.Authentication.Dtos;
using Squader.Api.Areas.Authentication.Helpers;
using Squader.Common.Extensions;
using Squader.Common.Settings;
using Squader.Cqrs;
using Squader.DomainModel.Users.Commands;
using Squader.ReadModel.Users.Queries;

namespace Squader.Api.Areas.Authentication.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IEncrypter _encrypter;
        private readonly JwtSettings _jwtSettings;

        public AuthenticationController(ICommandBus commandBus, IQueryBus queryBus,
            ILogger<AuthenticationController> logger, IJwtHandler jwtHandler, IEncrypter encrypter, IConfiguration configuration ) 
            : base(commandBus, queryBus, logger)
        {
            _jwtHandler = jwtHandler;
            _encrypter = encrypter;
            _jwtSettings = configuration.GetSettings<JwtSettings>();
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserForLoginDto user)
        {
            var query = new GetUserForLoginQuery(user.Username);
            var queryResult = queryBus.Execute(query);

            var passHash = _encrypter.GetHash(user.Password, queryResult.Salt);

            if (passHash != queryResult.Password) return Unauthorized();

            var jwtToken = _jwtHandler.CreateTokenByUserObject(queryResult);

            return Json(jwtToken);
        }

        public async Task<IActionResult> RegisterAsync(UserForRegistrationDto user)
        {
            var salt = _encrypter.GetSalt(_jwtSettings.Key);
            var passHash = _encrypter.GetHash(user.Password, salt);

            var command = new RegisterUserCommand(user.Username, user.Email, passHash, salt);
            await commandBus.ExecuteAsync(command);

            return StatusCode(201);
        }

       
    }
}