using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Squader.Api.Areas.Authentication.Dtos;
using Squader.Common.Extensions;
using Squader.Cqrs;

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
            if(user.Username.IsEmail())
            //call EmailCommand
            { }
            else
            // call usernameCommand
            { }
             

            




            return Ok();
        }

       
    }
}