using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Squader.Api.Areas.Users.Dtos;
using Squader.Cqrs;
using Squader.ReadModel.Users.Queries;

namespace Squader.Api.Areas
{
    [Produces("application/json")]
    [Route("[controller]")]
    [EnableCors("AllowAny")]
    public class BaseApiController : Controller
    {
        protected ICommandBus commandBus;
        protected IQueryBus queryBus;
        protected ILogger<BaseApiController> logger;
        protected UserDto AuthorizedUser => GetAuthorizedUser();

        protected BaseApiController(ICommandBus commandBus, IQueryBus queryBus, ILogger<BaseApiController> logger)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
            this.logger = logger;
        }

        [Authorize]
        private UserDto GetAuthorizedUser()
        {
            var userId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var query = new GetUserByIdQuery(userId);
            var userDto = new UserDto(queryBus.Execute(query).User);
            return userDto;
        }
    }
}
