using Microsoft.EntityFrameworkCore;
using Squader.DomainModel.Announcements;
using Squader.DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.Infrastructure.DAL
{
    public interface IContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Announcement> Announcements { get; set; }
        int SaveChanges();
    }
}
