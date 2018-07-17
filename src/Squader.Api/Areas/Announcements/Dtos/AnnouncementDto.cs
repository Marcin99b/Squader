using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Squader.DomainModel.Announcements;

namespace Squader.Api.Areas.Announcements.Dtos
{
    public class AnnouncementDto
    {
        public Guid Id { get; private set; }
        public Guid AuthorId { get; private set; }
        public Guid TeamId { get; private set; }
        public string Title { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<string> Requirements { get; private set; }
        public IEnumerable<string> Tags { get; private set; }
        public DateTime ChangedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public AnnouncementDto(Announcement announcement)
        {
            Id = announcement.Id;
            AuthorId = announcement.AuthorId;
            TeamId = announcement.AuthorId;
            Title = announcement.Title;
            ShortDescription = announcement.ShortDescription;
            Description = announcement.ShortDescription;
            Requirements = announcement.Requirements;
            Tags = announcement.Tags;
            ChangedAt = announcement.ChangedAt;
            CreatedAt = announcement.CreatedAt;
        }
    }
}
