using System;
using System.Collections.Generic;
using Squader.Cqrs;

namespace Squader.DomainModel.Teams.Commands
{
    public class UpdateTeamCommand : ICommand
    {
        public Guid TeamId { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public IEnumerable<UserTeam> Users { get; private set; }
        public Action<ISet<UserTeam>> UsersAction { get; private set; }

        public UpdateTeamCommand(Guid teamId, string title, string description, 
            IEnumerable<UserTeam> users = null, Action<ISet<UserTeam>> usersAction = null)
        {
            TeamId = teamId;
            Title = title;
            Description = description;
            Users = users;
            UsersAction = usersAction;
        }
    }
}
