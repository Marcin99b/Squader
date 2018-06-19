using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.DomainModel.Announcements.Commands.Handlers
{
    public class DeleteAnnouncementHandler : ICommandHandler<DeleteAnnouncementCommand>
    {
        private readonly IAnnouncementsRepository announcementsRepository;

        public DeleteAnnouncementHandler(IAnnouncementsRepository announcementsRepository)
        {
            this.announcementsRepository = announcementsRepository;
        }

        public async Task HandleAsync(DeleteAnnouncementCommand command)
        {
            var announcement = await announcementsRepository.GetAsync(command.AnnouncementId);
            announcement.Delete();
            await announcementsRepository.UpdateAsync(announcement);
        }
    }
}
