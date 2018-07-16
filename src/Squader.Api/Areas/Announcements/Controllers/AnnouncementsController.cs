using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Squader.Api.Areas.Announcements.Dtos;
using Squader.Cqrs;
using Squader.DomainModel.Announcements.Commands;
using Squader.ReadModel.Announcements.Queries;

namespace Squader.Api.Areas.Announcements.Controllers
{
    public class AnnouncementsController : BaseApiController
    {
        
        public AnnouncementsController(ICommandBus commandBus, IQueryBus queryBus, ILogger<AnnouncementsController> logger) : base(commandBus, queryBus, logger)
        {
            
        }

        [HttpGet("{id}")]
        public IActionResult GetAccouncementById(Guid id)
        {
            var query = new GetAnnouncementByIdQuery(id);
            var announcement = queryBus.Execute(query).Announcement;
            var announcementDto = new AnnouncementDto(announcement);
            return Json(announcementDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewAnnouncementAsync([FromBody] CreateNewAnnouncementRequest request)
        {
            var command = new CreateNewAnnouncementCommand(request.AuthorId, request.Title, request.ShortDescription,
                request.Description, request.Requirements, request.Tags);
            await commandBus.ExecuteAsync(command);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAnnouncementAsync([FromBody] UpdateAnnouncementRequest request)
        {
            var command = new UpdateAnnouncementCommand(request.AnnouncementId, request.Title, request.ShortDescription,
                request.Description, request.Requirements, request.Tags);
            await commandBus.ExecuteAsync(command);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAnnouncementAsync([FromBody] DeleteAnnouncementRequest request)
        {
            var command = new DeleteAnnouncementCommand(request.AnnouncementId);
            await commandBus.ExecuteAsync(command);
            return Ok();
        }
    }
}
