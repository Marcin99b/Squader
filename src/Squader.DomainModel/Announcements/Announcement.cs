using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using Squader.Common.Extensions;
using Squader.DomainModel.Users;

namespace Squader.DomainModel.Announcements
{
    public class Announcement
    {
        [NotMapped]
        private ISet<string> requirements
        {
            get => requirementsFromJson.ToHashSet();
            set => requirementsFromJson = value;
        }

        [NotMapped]
        private ISet<string> tags
        {
            get => tagsFromJson.ToHashSet();
            set => tagsFromJson = value;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; private set; }
        public Guid AuthorId { get; private set; }
        public Guid TeamId { get; private set; } //TODO add team domain model
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        [Column("Tags")]
        private string tagsJson { get; set; }
        [Column("Requirements")]
        private string requirementsJson { get; set; } 

        [NotMapped]
        private IEnumerable<string> requirementsFromJson
        {
            get { return requirementsJson == null ? null : JsonConvert.DeserializeObject<string[]>(requirementsJson); }
            set { requirementsJson = JsonConvert.SerializeObject(value); }
        }

        [NotMapped]
        private IEnumerable<string> tagsFromJson
        {
            get { return tagsJson == null ? null : JsonConvert.DeserializeObject<string[]>(tagsJson); }
            set { tagsJson = JsonConvert.SerializeObject(value); }
        }

        [NotMapped]
        public IEnumerable<string> Requirements
        {
            get => requirements;
            private set => requirements = new HashSet<string>(value);
        }
        [NotMapped]
        public IEnumerable<string> Tags
        {
            get => tags;
            private set => tags = new HashSet<string>(value);
        }
        public DateTime ChangedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        private Announcement() { }

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

        public void SetRequirements(Action<ISet<string>> action)
        {
            if (action == null)
            {
                return;
            }
            action.Invoke(requirements);
            UpdateVersion();
        }

        public void SetTags(Action<ISet<string>> action)
        {
            if (action == null)
            {
                return;
            }
            action.Invoke(tags);
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


        public class AnnouncementConfiguration : IEntityTypeConfiguration<Announcement>
        {
            public void Configure(EntityTypeBuilder<Announcement> builder)
            {
                builder.Property(x => x.tagsJson);
                builder.Property(x => x.requirementsJson);
            }
        }
    }
    
}
