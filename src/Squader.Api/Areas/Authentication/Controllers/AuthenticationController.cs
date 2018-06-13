using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

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
        

        public AuthenticationController(ICommandBus commandBus, IQueryBus queryBus,
            ILogger<AuthenticationController> logger, IJwtHandler jwtHandler, IEncrypter encrypter) 
            : base(commandBus, queryBus, logger)
        {
            _jwtHandler = jwtHandler;
            _encrypter = encrypter;
            
        }
        
        [HttpPost("login")]
        public IActionResult Login([FromBody]UserForLoginRequest user)
        {
            var query = new GetUserByIdentifiersQuery(user.Username);
            var queryResult = queryBus.Execute(query);
            if (queryResult == null)
                return Unauthorized();
        

            var passHash = _encrypter.GetHash(user.Password, queryResult.User.Salt);

            if (passHash != queryResult.User.HashPassword) return Unauthorized();

            var jwtToken = _jwtHandler.CreateTokenByUserObject(queryResult);

            return Json(jwtToken);
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody]UserForRegistrationRequest user)
        {
            var usernameQuery = new GetUserByIdentifiersQuery(user.Username);
            if (queryBus.Execute(usernameQuery) != null)
                return Json(new Exception($"Username : {user.Username} already exists"));

            var emailQuery = new GetUserByIdentifiersQuery(user.Email);
            if(queryBus.Execute(emailQuery) != null)
                return Json(new Exception($"User with email : {user.Email} already exists"));
             

            var salt = _encrypter.GetSalt();
            var passHash = _encrypter.GetHash(user.Password, salt);

            var command = new RegisterUserCommand(user.Username, user.Email, passHash, salt);
            await commandBus.ExecuteAsync(command);

            return StatusCode(201);
        }

       
    }
}