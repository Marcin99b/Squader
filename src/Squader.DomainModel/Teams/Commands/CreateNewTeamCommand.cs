using Squader.Cqrs;
using Squader.DomainModel.Users;

namespace Squader.DomainModel.Teams.Commands
{
    public class CreateNewTeamCommand : ICommand
    {
        public User Author { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public CreateNewTeamCommand(User author, string title, string description)
        {
            Author = author;
            Title = title;
            Description = description;
        }
    }
}
