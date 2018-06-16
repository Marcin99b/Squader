using System;
using System.Collections.Generic;
using Squader.DomainModel.Users;

namespace Squader.DomainModel.Teams
{
    public class Team
    {
        private ISet<UserTeam> users = new HashSet<UserTeam>();

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<UserTeam> Users
        {
            get => users;
            private set => users = new HashSet<UserTeam>(value);
        }
        public DateTime ChangedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Deleted { get; private set; }

        public Team(User author, string title, string description)
        {
            SetTitle(title);
            SetDescription(description);
            SetUsers(x => x.Add(new UserTeam(author, TeamRole.Owner)));
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

        public void SetUsers(IEnumerable<UserTeam> users)
        {
            if (users == null)
            {
                return;
            }
            Users = users;
            UpdateVersion();
        }

        public void SetUsers(Action<ISet<UserTeam>> action)
        {
            if (action == null)
            {
                return;
            }
            action.Invoke(users);
            UpdateVersion();
        }

        public void UpdateVersion()
        {
            ChangedAt = DateTime.UtcNow;
        }
    }
}
