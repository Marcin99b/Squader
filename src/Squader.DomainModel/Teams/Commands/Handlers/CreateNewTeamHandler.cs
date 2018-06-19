using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.DomainModel.Teams.Commands.Handlers
{
    public class CreateNewTeamHandler : ICommandHandler<CreateNewTeamCommand>
    {
        private readonly ITeamsRepository teamsRepository;

        public CreateNewTeamHandler(ITeamsRepository teamsRepository)
        {
            this.teamsRepository = teamsRepository;
        }

        public async Task HandleAsync(CreateNewTeamCommand command)
        {
            var team = new Team(command.Author, command.Title, command.Description);
            await this.teamsRepository.AddAsync(team);
        }
    }
}
