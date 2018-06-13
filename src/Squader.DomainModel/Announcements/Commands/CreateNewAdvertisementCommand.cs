using Squader.Cqrs;

namespace Squader.DomainModel.Announcements.Commands
{
    public class CreateNewAnnouncementCommand : ICommand
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public CreateNewAnnouncementCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
