using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(Announcement announcement)
        {
            await context.Announcements.AddAsync(announcement);
            await context.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public async Task<Announcement> GetAsync(Guid announcementid)
        {
            return await context.Announcements.FirstOrDefaultAsync(x => x.Id == announcementid);
        }

        public async Task UpdateAsync(Announcement announcement)
        {
            context.Announcements.Update(announcement);
            await context.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
