using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.DomainModel.Announcements.Commands.Handlers
{
    public class CreateNewAnnouncementHandler : ICommandHandler<CreateNewAnnouncementCommand>
    {
        private readonly IAnnouncementsRepository announcementsRepository;

        public CreateNewAnnouncementHandler(IAnnouncementsRepository announcementsRepository)
        {
            this.announcementsRepository = announcementsRepository;
        }

        public async Task HandleAsync(CreateNewAnnouncementCommand command)
        {
            var announcement = new Announcement(command.Author, command.Title, command.ShortDescription, command.Description, 
                command.Requirements, command.Tags);
            await announcementsRepository.AddAsync(announcement);
        }
    }
}
