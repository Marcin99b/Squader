using System;
using System.Collections.Generic;
using Squader.DomainModel.Users;

namespace Squader.DomainModel.Announcements
{
    public class Announcement
    {
        private ISet<string> requirements = new HashSet<string>();
        private ISet<string> tags = new HashSet<string>();

        public Guid Id { get; private set; }
        public Guid AuthorId { get; private set; }
        public Guid TeamId { get; private set; } //TODO add team domain model
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<string> Requirements
        {
            get => requirements;
            private set => requirements = new HashSet<string>(value);
        }
        public IEnumerable<string> Tags
        {
            get => tags;
            private set => tags = new HashSet<string>(value);
        }
        public DateTime ChangedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        public Announcement(User author, string title, string shortDescription, string description)
        {
            Id = Guid.NewGuid();
            AuthorId = author.Id;
            SetTitle(title);
            SetShortDescription(shortDescription);
            SetDescription(description);
            CreatedAt = DateTime.UtcNow;
        }

        public Announcement(User author, string title, string shortDescription, string description, IEnumerable<string> requirements, IEnumerable<string> tags)
        {
            Id = Guid.NewGuid();
            AuthorId = author.Id;
            SetTitle(title);
            SetShortDescription(shortDescription);
            SetDescription(description);
            SetRequirements(requirements);
            SetTags(tags);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetTitle(string title)
        {
            if (title == null)
            {
                return;
            }
            this.Title = title;
            UpdateVersion();
        }

        public void SetShortDescription(string shortDescription)
        {
            if (shortDescription == null)
            {
                return;
            }
            this.ShortDescription = shortDescription;
            UpdateVersion();
        }

        public void SetDescription(string description)
        {
            if (description == null)
            {
                return;
            }
            this.Description = description;
        }

        public void SetRequirements(IEnumerable<string> requirements)
        {
            if (requirements == null)
            {
                return;
            }
            Requirements = requirements;
            UpdateVersion();
        }

        public void SetRequirements(Action<IEnumerable<string>> action)
        {
            if (action == null)
            {
                return;
            }
            action.Invoke(Requirements);
            UpdateVersion();
        }

        public void SetTags(Action<IEnumerable<string>> action)
        {
            if (action == null)
            {
                return;
            }
            action.Invoke(Tags);
            UpdateVersion();
        }

        public void SetTags(IEnumerable<string> tags)
        {
            if (tags == null)
            {
                return;
            }
            Tags = tags;
            UpdateVersion();
        }

        public void UpdateVersion()
        {
            ChangedAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
