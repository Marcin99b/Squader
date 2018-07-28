using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Squader.DomainModel.Users;
using Squader.DomainModel.Announcements;
using System.Threading.Tasks;
using System.Threading;
using Squader.DomainModel.Teams;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Squader.Common.Extensions;
using Squader.Common.Settings;

namespace Squader.Infrastructure.DAL
{
    public class ApplicationDbContext : DbContext, IContext
    {
        private readonly SqlSettings sqlSettings;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, SqlSettings sqlSettings) : base(options)
        {
            this.sqlSettings = sqlSettings;
        }
        public ApplicationDbContext(SqlSettings sqlSettings)
        {
            this.sqlSettings = sqlSettings;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(sqlSettings.ConnectionString);
        } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Announcement.AnnouncementConfiguration());
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


        public async Task<int> SaveChangesAsync()
        {
            return await this.SaveChangesAsync(CancellationToken.None);
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<UserTeam> UserTeams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Announcement> Announcements { get; set; }



        public void ApplyMigrationsOnStartup()
        {
            this.Database.EnsureCreated();
        }



    }

}
