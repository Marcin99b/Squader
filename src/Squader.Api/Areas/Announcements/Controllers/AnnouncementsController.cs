using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Squader.Cqrs;
using Squader.DomainModel.Announcements.Commands;

namespace Squader.Api.Areas.Announcements.Controllers
{
    public class AnnouncementsController : BaseApiController
    {
        
        public AnnouncementsController(ICommandBus commandBus, IQueryBus queryBus, ILogger<AnnouncementsController> logger) : base(commandBus, queryBus, logger)
        {
            
        }
        
        [HttpGet("create")] //should http post, but get is easier for manual tests
        public async Task<IActionResult> CreateNewAnnouncementAsync()
        {
            var command = new CreateNewAnnouncementCommand("test", "test");
            await this.commandBus.ExecuteAsync(command);
            logger.LogInformation("Logger works !");
            return Ok();
        }
    }
}
