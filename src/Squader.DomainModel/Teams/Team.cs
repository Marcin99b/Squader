using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Squader.DomainModel.Users;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Squader.DomainModel.Teams
{
    public class Team
    {
        
        protected virtual ICollection<UserTeam> users { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime ChangedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Deleted { get; private set; }

        [NotMapped]
        public IEnumerable<UserTeam> Users
        {
            get => users;
            private set => users = new HashSet<UserTeam>(value);
        }

        private Team() { }

        public Team(User author, string title, string description)
        {
            users = new HashSet<UserTeam>();
            SetTitle(title);
            SetDescription(description);
            AddUserTeam(new UserTeam(author, TeamRole.Owner));
            CreatedAt = DateTime.UtcNow;
        }     

        public void SetTitle(string title)
        {
            if (title == null)
            {
                return;
            }
            Title = title;
            UpdateVersion();
        }

        public void SetDescription(string description)
        {
            if (description == null)
            {
                return;
            }
            Description = description;
            UpdateVersion();
        }

        public void AddUserTeam(UserTeam user)
        {
            users.Add(user);
            UpdateVersion();

        }
        /*
        public void SetUsers(IEnumerable<UserTeam> users)
        {
            if (users == null)
            {
                return;
            }
            Users = users;
            UpdateVersion();
        }

        public void SetUsers(Action<ICollection<UserTeam>> action)
        {
            if (action == null)
            {
                return;
            }
            action.Invoke(users);
            UpdateVersion();
        }
        */
        public void UpdateVersion()
        {
            ChangedAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            Deleted = true;
        }

        public class TeamConfiguration : IEntityTypeConfiguration<Team>
        {
            public void Configure(EntityTypeBuilder<Team> builder)
            {
                builder
                    .HasMany(x => x.users)
                    .WithOne(x => x.Team)
                    .HasForeignKey(x => x.TeamId);
            }
        }
    }
   
}
