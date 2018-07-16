using System;
using System.Threading.Tasks;
using Squader.DomainModel.Users;

namespace Squader.DomainModel.Repositories
{
    public interface IUsersRepository : IRepository
    {
        Task AddAsync(User user);
        User Get(Guid userId);
        Task UpdateAsync(User user);
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> GetUserByEmailAsync(string email);
    }
}
