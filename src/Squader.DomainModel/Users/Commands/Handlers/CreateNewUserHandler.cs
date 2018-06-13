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

        public Task HandleAsync(CreateNewUserCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}
