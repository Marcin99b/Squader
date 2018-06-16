using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Squader.DomainModel.Repositories;
using Squader.DomainModel.Teams;

namespace Squader.Infrastructure.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private static readonly List<Team> teams = new List<Team>();

        public async Task AddAsync(Team team)
        {
            teams.Add(team);
            await Task.CompletedTask;
        }

        public async Task<Team> GetAsync(Guid teamId)
        {
            return await Task.FromResult(teams.FirstOrDefault(x => x.Id == teamId));
        }

        public async Task UpdateAsync(Team team)
        {
            teams.Where(x => x.Id == team.Id).Select(x =>
            {
                x = team;
                return x;
            });
            await Task.CompletedTask;
        }
    }
}
