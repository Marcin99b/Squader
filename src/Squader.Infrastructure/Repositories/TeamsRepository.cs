using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Squader.DomainModel.Repositories;
using Squader.DomainModel.Teams;
using Squader.Infrastructure.DAL;

namespace Squader.Infrastructure.Repositories
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly IContext context;

        public TeamsRepository(IContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Team team)
        {
            await context.Teams.AddAsync(team);
            await context.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public Team Get(Guid teamId)
        {
            return context.Teams.FirstOrDefault(x => x.Id == teamId && !x.Deleted);
        }

        public async Task UpdateAsync(Team team)
        {
            context.Teams.Update(team);
            await context.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
