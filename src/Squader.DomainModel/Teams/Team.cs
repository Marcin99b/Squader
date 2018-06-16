using System;
using System.Collections.Generic;

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
    }
}
