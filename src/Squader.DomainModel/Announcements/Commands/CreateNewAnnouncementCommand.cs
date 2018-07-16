using System;
using System.Collections.Generic;
using Squader.Cqrs;
using Squader.DomainModel.Users;

namespace Squader.DomainModel.Announcements.Commands
{
    public class CreateNewAnnouncementCommand : ICommand
    {
        public Guid AuthorId { get; private set; }
        public Guid TeamId { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<string> Requirements { get; private set; }
        public IEnumerable<string> Tags { get; private set; }
        
        public CreateNewAnnouncementCommand(Guid authorId, Guid teamId, string title, string shortDescription, string description, IEnumerable<string> requirements = null, IEnumerable<string> tags = null)
        {
            AuthorId = authorId;
            TeamId = teamId;
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Requirements = requirements;
            Tags = tags;
        }
    }
}
