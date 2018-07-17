using System;
using System.Collections.Generic;
using System.Text;
using Squader.Cqrs;

namespace Squader.ReadModel.Teams.Queries
{
    public class GetTeamByIdQuery : IQuery<GetTeamByIdQueryResult>
    {
        public Guid TeamId { get; private set; }

        public GetTeamByIdQuery(Guid teamId)
        {
            TeamId = teamId;
        }

    }
}
