using System;
using System.Threading.Tasks;
using Squader.DomainModel.Users;

namespace Squader.DomainModel.Repositories
{
    public interface IUsersRepository : IRepository
    {
        Task AddAsync(User user);
        Task<User> GetAsync(Guid userId);
        Task UpdateAsync(User user);
    }
}
