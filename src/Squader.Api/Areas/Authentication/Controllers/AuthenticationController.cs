using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Squader.Cqrs;

namespace Squader.Api.Areas.Authentication.Controllers
{
    public class AuthenticationController : BaseApiController
    {
        public AuthenticationController(ICommandBus commandBus, IQueryBus queryBus, ILogger<AuthenticationController> logger) : base(commandBus, queryBus, logger)
        {

        }
        

        
        public IActionResult Index()
        {
            return View();
        }
    }
}