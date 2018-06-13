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

        [HttpGet]
        public IActionResult GetUserById()
        {
            var query = new GetUserByIdQuery(Guid.NewGuid());
            var result = this.queryBus.Execute(query);
            Debug.WriteLine(result.User.Id);
            return Json(new UserDto(result.User));
        }

        [HttpGet("test")]
        public async Task<IActionResult> CreateNewUser()
        {
            var command = new CreateNewUserCommand();
            await this.commandBus.ExecuteAsync(command);
            return Ok();
        }
    }
}
