using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Squader.Api.Areas.Authentication.Dtos;
using Squader.Api.Areas.Authentication.Helpers;
using Squader.Common.Extensions;
using Squader.Cqrs;
using Squader.ReadModel.Users.Queries;
using Squader.ReadModel.Users.QueryResults;

namespace Squader.Api.Areas.Authentication.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        private readonly IJwtHandler _jwtHandler;
        private readonly IEncrypter _encrypter;
        public AuthenticationController(ICommandBus commandBus, IQueryBus queryBus,
            ILogger<AuthenticationController> logger, IJwtHandler jwtHandler, IEncrypter encrypter ) 
            : base(commandBus, queryBus, logger)
        {
            _jwtHandler = jwtHandler;
            _encrypter = encrypter;
        }
        
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserForLoginDto user)
        {
            var query = new GetUserForLoginQuery(user.Username);
            var queryResult = await queryBus.ExecuteAsync<GetUserForLoginQuery, GetUserForLoginQueryResult>(query);

            var passHash = _encrypter.GetHash(user.Password, queryResult.Salt);

            if (passHash != queryResult.Password) return Unauthorized();

            var jwtToken = _jwtHandler.CreateTokenByUserObject(queryResult);

            return Json(jwtToken);
        }

       
    }
}