using System;
using System.Threading.Tasks;
using Squader.DomainModel.Teams;

namespace Squader.DomainModel.Repositories
{
    public interface ITeamsRepository : IRepository
    {
        Task AddAsync(Team team);
        Team Get(Guid teamId);
        Task UpdateAsync(Team team);
    }
}
