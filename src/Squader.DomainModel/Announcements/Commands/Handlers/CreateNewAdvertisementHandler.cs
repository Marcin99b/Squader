using System.Threading.Tasks;
using Squader.Cqrs;

namespace Squader.DomainModel.Announcements.Commands.Handlers
{
    public class CreateNewAnnouncementHandler : ICommandHandler<CreateNewAnnouncementCommand>
    {
        public async Task HandleAsync(CreateNewAnnouncementCommand command)
        {
            //at now you must use debugger to see command content
        }
    }
}
