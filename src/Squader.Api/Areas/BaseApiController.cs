using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Squader.Cqrs;

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

        protected BaseApiController(ICommandBus commandBus, IQueryBus queryBus, ILogger<BaseApiController> logger)
        {
            this.commandBus = commandBus;
            this.queryBus = queryBus;
            this.logger = logger;
        }
    }
}
