using System;
using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.DomainModel.Announcements.Commands.Handlers
{
    public class UpdateAnnouncementHandler : ICommandHandler<UpdateAnnouncementCommand>
    {
        private readonly IAnnouncementsRepository announcementsRepository;

        public UpdateAnnouncementHandler(IAnnouncementsRepository announcementsRepository)
        {
            this.announcementsRepository = announcementsRepository;
        }

        public async Task HandleAsync(UpdateAnnouncementCommand command)
        {
            var user = announcementsRepository.Get(command.AnnouncementId);
            var updated = UpdateAnnouncement(user, command);
            await announcementsRepository.UpdateAsync(updated);
        }

        private Announcement UpdateAnnouncement(Announcement announcement, UpdateAnnouncementCommand command)
        {
            announcement.SetTitle(command.Title);
            announcement.SetDescription(command.Description);
            announcement.SetShortDescription(command.ShortDescription);
            announcement.SetRequirements(command.Requirements);
            announcement.SetRequirements(command.RequirementsAction);
            announcement.SetTags(command.Tags);
            announcement.SetTags(command.TagsAction);
            return announcement;
        }
    }
}
