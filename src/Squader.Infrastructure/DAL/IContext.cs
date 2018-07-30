using Microsoft.EntityFrameworkCore;
using Squader.DomainModel.Announcements;
using Squader.DomainModel.Conversations;
using Squader.DomainModel.Teams;
using Squader.DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Squader.Infrastructure.DAL
{
    public interface IContext
    {
        Task<int> SaveChangesAsync();
        int SaveChanges();

        DbSet<Team> Teams { get; set; }
        DbSet<UserTeam> UserTeams { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Announcement> Announcements { get; set; }
        DbSet<Conversation> Conversations { get; set; }
        DbSet<ConversationMessage> ConversationMessages { get; set; }
        DbSet<ConversationUser> ConversationUsers { get; set; }

        void ApplyMigrationsOnStartup();
    }
}
