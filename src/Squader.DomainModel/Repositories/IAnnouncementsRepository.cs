using System;
using System.Threading.Tasks;
using Squader.DomainModel.Announcements;

namespace Squader.DomainModel.Repositories
{
    public interface IAnnouncementsRepository : IRepository
    {
        Task AddAsync(Announcement announcement);
        Task<Announcement> GetAsync(Guid announcementId);
        Task UpdateAsync(Announcement announcement);
    }
}
