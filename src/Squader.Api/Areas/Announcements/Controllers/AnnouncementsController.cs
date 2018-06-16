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
        
    }
}
