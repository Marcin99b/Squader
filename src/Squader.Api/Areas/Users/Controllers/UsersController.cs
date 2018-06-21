using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Squader.Api.Areas.Users.Dtos;
using Squader.Cqrs;
using Squader.DomainModel.Users.Commands;
using Squader.ReadModel.Users.Queries;

namespace Squader.Api.Areas.Users.Controllers
{
    public class UsersController : BaseApiController
    {
        public UsersController(ICommandBus commandBus, IQueryBus queryBus, ILogger<BaseApiController> logger) : base(commandBus, queryBus, logger)
        {
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(Guid id)
        {
            var query = new GetUserByIdQuery(id);
            var result = this.queryBus.Execute(query);
            if (result.User == null)
                return Json(new Exception($"There is no user with id : {id}"));

            return Json(new UserDto(result.User));
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewUser([FromBody]CreateUserRequest request)
        {
            var command = new CreateNewUserCommand(request.Username, request.Email, request.Forename, request.Surname, request.City, "", "");
            await this.commandBus.ExecuteAsync(command);
            return Ok();
        }

        [HttpPost("CheckUsernameAvailability")]
        public async Task<IActionResult> CheckUsernameAvailability([FromBody]CheckUsernameAvailabilityRequest request)
        {
            var query = new GetUserByUsernameQuery(request.Username);
            var result = await Task.Run(() => this.queryBus.Execute(query));

            if (result != null)
                return StatusCode(409);

            return Ok();         
        }
    }
}
