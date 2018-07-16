using System;
using System.Threading.Tasks;
using Squader.DomainModel.Announcements;

namespace Squader.DomainModel.Repositories
{
    public interface IAnnouncementsRepository : IRepository
    {
        Task AddAsync(Announcement announcement);
        Announcement Get(Guid announcementId);
        Task UpdateAsync(Announcement announcement);
    }
}
