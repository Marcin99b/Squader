﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Squader.Cqrs;
using Squader.DomainModel.Advertisements.Commands;

namespace Squader.Api.Areas.Advertisements.Controllers
{
    public class AdvertisementsController : BaseApiController
    {
        
        public AdvertisementsController(ICommandBus commandBus, IQueryBus queryBus, ILogger<AdvertisementsController> logger) : base(commandBus, queryBus, logger)
        {
            
        }
        
        [HttpGet("create")] //should http post, but get is easier for manual tests
        public async Task<IActionResult> CreateNewAdvertisementAsync()
        {
            var command = new CreateNewAdvertisementCommand("test", "test");
            await this.commandBus.ExecuteAsync(command);
            logger.LogInformation("Logger works !");
            return Ok();
        }
    }
}
