using Autofac.Core.Lifetime;
using Autofac.Core.Registration;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Squader.Cqrs;

namespace Squader.Api.Areas
{
    [Produces("application/json")]
    [Route("[controller]")]
    [EnableCors("AllowAny")]
    public class BaseApiController : Controller
    {
        protected IMessageBus messageBus;

        protected BaseApiController(IMessageBus messageBus)
        {
            this.messageBus = messageBus;
        }
    }
}
