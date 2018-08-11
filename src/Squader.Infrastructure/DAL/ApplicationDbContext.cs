﻿using Microsoft.EntityFrameworkCore;
using Squader.DomainModel.Users;
using Squader.DomainModel.Announcements;
using System.Threading.Tasks;
using System.Threading;
using Squader.DomainModel.Teams;
using Squader.DomainModel.Conversations;

namespace Squader.Infrastructure.DAL
{
    public class ApplicationDbContext : DbContext, IContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public ApplicationDbContext() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=squader.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new Announcement.AnnouncementConfiguration());
            builder.ApplyConfiguration(new Team.TeamConfiguration());
            builder.ApplyConfiguration(new User.UserConfiguration());
            builder.ApplyConfiguration(new Conversation.ConversationConfiguration());

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
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<ConversationMessage> ConversationMessages { get; set; }
        public DbSet<ConversationUser> ConversationUsers { get; set; }

        public void ApplyMigrationsOnStartup()
        {
            this.Database.EnsureCreated();
        }



    }

}
