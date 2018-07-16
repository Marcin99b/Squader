using System;
using System.Collections.Generic;
using System.Text;
using Squader.Cqrs;
using Squader.DomainModel.Teams;

namespace Squader.ReadModel.Teams.Queries
{
    public class GetTeamByIdQueryResult : IQueryResult
    {
        public Team Team { get; private set; }

        public GetTeamByIdQueryResult(Team team)
        {
            Team = team;
        }
    }
}
