using System;
using System.Collections.Generic;
using System.Text;
using Squader.Cqrs;

namespace Squader.ReadModel.Announcements.Queries
{
    public class GetAnnouncementByIdQuery : IQuery<GetAnnouncementByIdQueryResult>
    {
        public Guid AnnouncementId { get; private set; }

        public GetAnnouncementByIdQuery(Guid announcementId)
        {
            AnnouncementId = announcementId;
        }
    }
}
