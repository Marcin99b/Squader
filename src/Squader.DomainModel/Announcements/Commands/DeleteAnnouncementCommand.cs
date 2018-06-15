using System;
using Squader.Cqrs;

namespace Squader.DomainModel.Announcements.Commands
{
    public class DeleteAnnouncementCommand : ICommand
    {
        public Guid AnnouncementId { get; private set; }

        public DeleteAnnouncementCommand(Guid announcementId)
        {
            AnnouncementId = announcementId;
        }
    }
}
