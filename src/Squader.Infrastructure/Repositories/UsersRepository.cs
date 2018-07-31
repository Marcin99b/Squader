using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public async Task AddAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            
            await Task.CompletedTask;
        }

        public User Get(Guid userId)
        {
            return context.Users.FirstOrDefault(x => x.Id == userId && !x.IsDeleted);
        }

        public async Task UpdateAsync(User user)
        {
            context.Users.Update(user);
            await context.SaveChangesAsync();
            await Task.CompletedTask;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
           
            return await context.Users.FirstOrDefaultAsync(x => x.Username == username);
        }

    }
}
