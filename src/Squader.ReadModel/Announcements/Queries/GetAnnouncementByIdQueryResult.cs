using System;
using System.Collections.Generic;
using System.Text;
using Squader.Cqrs;
using Squader.DomainModel.Announcements;

namespace Squader.ReadModel.Announcements.Queries
{
    public class GetAnnouncementByIdQueryResult : IQueryResult
    {
        public Announcement Announcement { get; private set; }

        public GetAnnouncementByIdQueryResult(Announcement announcement)
        {
            Announcement = announcement;
        }
    }
}
