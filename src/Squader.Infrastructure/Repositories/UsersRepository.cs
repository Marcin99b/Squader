using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Squader.DomainModel.Repositories;
using Squader.DomainModel.Users;
using Squader.Infrastructure.DAL;

namespace Squader.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly IContext context;
        public UsersRepository(IContext context)
        {
            this.context = context;
        }

        private static readonly List<User> users = new List<User>
        {
            new User("ffa", "grsgesr", "gsgs", "efea", "gesgs", "degfes", "grsgsr"),
            new User("ffa", "grsgesr", "gsgs", "efea", "gesgs", "degfes", "grsgsr"),
            new User("ffa", "grsgesr", "gsgs", "efea", "gesgs", "degfes", "grsgsr"),
            new User("ffa", "grsgesr", "gsgs", "efea", "gesgs", "degfes", "grsgsr"),
            new User("ffa", "grsgesr", "gsgs", "efea", "gesgs", "degfes", "grsgsr"),
            new User("ffa", "grsgesr", "gsgs", "efea", "gesgs", "degfes", "grsgsr"),
            new User("ffa", "grsgesr", "gsgs", "efea", "gesgs", "degfes", "grsgsr")
        };

        public async Task AddAsync(User user)
        {
            users.Add(user);
            await Task.CompletedTask;
        }

        public async Task<User> GetAsync(Guid userId)
        {
            return await Task.FromResult(users.FirstOrDefault(x => x.Id == userId));
        }

        public async Task UpdateAsync(User user)
        {
            users.Where(x => x.Id == user.Id).Select(x =>
            {
                x = user;
                return x;
            });
            await Task.CompletedTask;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await Task.FromResult(users.FirstOrDefault(x => x.Email == email));
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
           
            return await Task.FromResult(users.FirstOrDefault(x => x.Username == username));
        }

    }
}
