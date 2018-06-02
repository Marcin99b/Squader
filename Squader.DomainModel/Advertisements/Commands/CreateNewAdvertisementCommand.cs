using Squader.Cqrs;

namespace Squader.DomainModel.Advertisements.Commands
{
    public class CreateNewAdvertisementCommand : ICommand
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public CreateNewAdvertisementCommand(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
