using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Squader.Api.Areas.Announcements.Dtos;
using Squader.Cqrs;
using Squader.DomainModel.Announcements;
using Squader.DomainModel.Announcements.Commands;
using Squader.ReadModel.Announcements.Queries;
using Squader.ReadModel.Teams.Queries;

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
            var announcement = GetAnnouncement(id);
            var announcementDto = new AnnouncementDto(announcement);
            return Json(announcementDto);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateNewAnnouncementAsync([FromBody] CreateNewAnnouncementRequest request)
        {
            var team = queryBus.Execute(new GetTeamByIdQuery(request.TeamId)).Team;
            if (team == null)
            {
                //should throw exception, but adding announcement without teamId is possible -> every logged in user should can add announcements etc
                //TODO -> add announcement without team (then team will be possible to set in update) OR return exception, with information about bad team id
            }

            var command = new CreateNewAnnouncementCommand(AuthorizedUser.Id, request.TeamId, request.Title, request.ShortDescription,
                request.Description, request.Requirements, request.Tags);
            await commandBus.ExecuteAsync(command);
            return Ok();
        }

        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAnnouncementAsync([FromBody] UpdateAnnouncementRequest request)
        {
            if (GetAnnouncement(request.AnnouncementId).AuthorId != AuthorizedUser.Id)
            {
                Unauthorized();
            }

            var command = new UpdateAnnouncementCommand(request.AnnouncementId, request.Title, request.ShortDescription,
                request.Description, request.Requirements, request.Tags);
            await commandBus.ExecuteAsync(command);
            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteAnnouncementAsync([FromBody] DeleteAnnouncementRequest request)
        {
            if (GetAnnouncement(request.AnnouncementId).AuthorId != AuthorizedUser.Id)
            {
                Unauthorized();
            }

            var command = new DeleteAnnouncementCommand(request.AnnouncementId);
            await commandBus.ExecuteAsync(command);
            return Ok();
        }

        private Announcement GetAnnouncement(Guid id)
        {
            var query = new GetAnnouncementByIdQuery(id);
            var announcement = queryBus.Execute(query).Announcement;
            return announcement;
        }
    }
}
