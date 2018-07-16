using System;
using System.Collections.Generic;
using System.Text;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.ReadModel.Announcements.Queries.Handlers
{
    public class GetAnnouncementByIdHandler : IQueryHandler<GetAnnouncementByIdQuery, GetAnnouncementByIdQueryResult>
    {
        private readonly IAnnouncementsRepository announcementsRepository;

        public GetAnnouncementByIdHandler(IAnnouncementsRepository announcementsRepository)
        {
            this.announcementsRepository = announcementsRepository;
        }

        public GetAnnouncementByIdQueryResult Handle(GetAnnouncementByIdQuery query)
        {
            var announcement = announcementsRepository.Get(query.AnnouncementId);
            return new GetAnnouncementByIdQueryResult(announcement);
        }
    }
}
