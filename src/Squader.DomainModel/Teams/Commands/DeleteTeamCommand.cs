using System;
using Squader.Cqrs;

namespace Squader.DomainModel.Teams.Commands
{
    public class DeleteTeamCommand : ICommand
    {
        public Guid TeamId { get; private set; }

        public DeleteTeamCommand(Guid teamId)
        {
            TeamId = teamId;
        }
    }
}
