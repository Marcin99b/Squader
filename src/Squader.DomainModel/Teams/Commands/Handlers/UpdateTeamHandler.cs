using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.DomainModel.Teams.Commands.Handlers
{
    public class UpdateTeamHandler : ICommandHandler<UpdateTeamCommand>
    {
        private readonly ITeamsRepository teamsRepository;

        public UpdateTeamHandler(ITeamsRepository teamsRepository)
        {
            this.teamsRepository = teamsRepository;
        }

        public async Task HandleAsync(UpdateTeamCommand command)
        {
            var team = await teamsRepository.GetAsync(command.TeamId);
            team.SetTitle(command.Title);
            team.SetDescription(command.Description);
            team.SetUsers(command.Users);
            team.SetUsers(command.UsersAction);
            await teamsRepository.UpdateAsync(team);
        }
    }
}
