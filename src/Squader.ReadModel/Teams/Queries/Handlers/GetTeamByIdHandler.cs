using System;
using System.Collections.Generic;
using System.Text;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.ReadModel.Teams.Queries.Handlers
{
    public class GetTeamByIdHandler : IQueryHandler<GetTeamByIdQuery, GetTeamByIdQueryResult>
    {
        private readonly ITeamsRepository teamsRepository;

        public GetTeamByIdHandler(ITeamsRepository teamsRepository)
        {
            this.teamsRepository = teamsRepository;
        }

        public GetTeamByIdQueryResult Handle(GetTeamByIdQuery query)
        {
            var team = teamsRepository.Get(query.TeamId);
            return new GetTeamByIdQueryResult(team);
        }
    }
}
