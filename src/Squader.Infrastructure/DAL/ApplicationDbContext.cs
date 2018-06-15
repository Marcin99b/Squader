using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using Squader.DomainModel.Users;
using Squader.DomainModel.Announcements;

namespace Squader.Infrastructure.DAL
{
    public class ApplicationDbContext : DbContext, IContext
    {
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=squader.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

        
        public DbSet<User> Users { get; set; }
        public DbSet<Announcement> Announcements { get; set; }

    }
}
