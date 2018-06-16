using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Squader.DomainModel.Announcements;
using Squader.DomainModel.Repositories;
using Squader.DomainModel.Users;
using Squader.Infrastructure.DAL;

namespace Squader.Infrastructure.Repositories
{
    public class AnnouncementsRepository : IAnnouncementsRepository
    {
        private readonly IContext context;

        public AnnouncementsRepository(IContext context)
        {
            this.context = context;
        }


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
