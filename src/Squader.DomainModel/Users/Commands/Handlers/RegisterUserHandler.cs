using Squader.Cqrs;
using Squader.DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Squader.DomainModel.Users.Commands.Handlers
{
    class RegisterUserHandler : ICommandHandler<RegisterUserCommand>
    { 
        private readonly IUsersRepository usersRepository;

        public RegisterUserHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
    
        public async Task HandleAsync(RegisterUserCommand command)
        {
            var user = new User(command.Username, command.Email, command.HashPassword, command.Salt);
            await usersRepository.AddAsync(user);
        }
    }
}
