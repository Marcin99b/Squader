using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.DomainModel.Teams.Commands.Handlers
{
    public class DeleteTeamHandler : ICommandHandler<DeleteTeamCommand>
    {
        private readonly ITeamsRepository teamsRepository;

        public DeleteTeamHandler(ITeamsRepository teamsRepository)
        {
            this.teamsRepository = teamsRepository;
        }

        public async Task HandleAsync(DeleteTeamCommand command)
        {
            var team = await teamsRepository.GetAsync(command.TeamId);
            team.Delete();
            await teamsRepository.UpdateAsync(team);
        }
    }
}
