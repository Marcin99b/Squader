using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Squader.DomainModel.Announcements;
using Squader.DomainModel.Repositories;
using Squader.DomainModel.Users;

namespace Squader.Infrastructure.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private static readonly List<Announcement> announcements = new List<Announcement>
        {
            new Announcement(new User("gesgs", "gefa", "ges", "ges"), "dadsa", "gesges", "edgeas"),
            new Announcement(new User("gesgs", "gefa", "ges", "ges"), "dadsa", "gesges", "edgeas"),
            new Announcement(new User("gesgs", "gefa", "ges", "ges"), "dadsa", "gesges", "edgeas"),
            new Announcement(new User("gesgs", "gefa", "ges", "ges"), "dadsa", "gesges", "edgeas"),
            new Announcement(new User("gesgs", "gefa", "ges", "ges"), "dadsa", "gesges", "edgeas"),
            new Announcement(new User("gesgs", "gefa", "ges", "ges"), "dadsa", "gesges", "edgeas"),
            new Announcement(new User("gesgs", "gefa", "ges", "ges"), "dadsa", "gesges", "edgeas")
        };

        public async Task AddAsync(Announcement announcement)
        {
            announcements.Add(announcement);
            await Task.CompletedTask;
        }

        public async Task<Announcement> GetAsync(Guid announcementid)
        {
            return await Task.FromResult(announcements.FirstOrDefault(x => x.Id == announcementid));
        }

        public async Task UpdateAsync(Announcement user)
        {
            announcements.Where(x => x.Id == user.Id).Select(x =>
            {
                x = user;
                return x;
            });
            await Task.CompletedTask;
        }
    }
}
