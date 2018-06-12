using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Squader.Api.Areas.Authentication.Dtos;
using Squader.Common.Extensions;
using Squader.Cqrs;
using Squader.ReadModel.Users.Queries;
using Squader.ReadModel.Users.QueryResults;

namespace Squader.Api.Areas.Authentication.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        public AuthenticationController(ICommandBus commandBus, IQueryBus queryBus, ILogger<AuthenticationController> logger) : base(commandBus, queryBus, logger)
        {

        }
        
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(UserForLoginDto user)
        {
            var query = new GetUserForLoginQuery(user.Username);
            var queryResult = queryBus.ExecuteAsync<GetUserForLoginQuery, GetUserForLoginQueryResult>(query);




            return Ok();
        }

       
    }
}