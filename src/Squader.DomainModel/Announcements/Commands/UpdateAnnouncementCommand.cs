using System;
using System.Collections.Generic;
using Squader.Cqrs;

namespace Squader.DomainModel.Announcements.Commands
{
    public class UpdateAnnouncementCommand : ICommand
    {
        public Guid AnnouncementId { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<string> Requirements { get; private set; }
        public IEnumerable<string> Tags { get; private set; }
        public Action<IEnumerable<string>> RequirementsAction { get; private set; }
        public Action<IEnumerable<string>> TagsAction { get; private set; }
        
        public UpdateAnnouncementCommand(Guid announcementId, string title, string shortDescription, string description, 
            IEnumerable<string> requirements = null, IEnumerable<string> tags = null,
            Action<IEnumerable<string>> requirementsAction = null, Action<IEnumerable<string>> tagsAction = null)
        {
            AnnouncementId = announcementId;
            Title = title;
            ShortDescription = shortDescription;
            Description = description;
            Requirements = requirements;
            Tags = tags;
            RequirementsAction = requirementsAction;
            TagsAction = tagsAction;
        }
    }
}
