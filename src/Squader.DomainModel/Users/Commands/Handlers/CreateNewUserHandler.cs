using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.DomainModel.Users.Commands.Handlers
{
    public class CreateNewUserHandler : ICommandHandler<CreateNewUserCommand>
    {
        private readonly IUsersRepository usersRepository;

        public CreateNewUserHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task HandleAsync(CreateNewUserCommand command)
        {
            var user = new User(command.Username, command.Email, command.Forename, command.Surname, command.City, 
                command.HashPassword, command.Salt);
            await usersRepository.AddAsync(user);
        }
    }
}
