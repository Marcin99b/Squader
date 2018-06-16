using System;
using System.Threading.Tasks;
using Squader.DomainModel.Teams;

namespace Squader.DomainModel.Repositories
{
    public interface ITeamsRepository : IRepository
    {
        Task AddAsync(Team team);
        Task<Team> GetAsync(Guid teamId);
        Task UpdateAsync(Team team);
    }
}
