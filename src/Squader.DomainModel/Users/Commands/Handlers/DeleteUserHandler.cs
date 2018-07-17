using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.DomainModel.Users.Commands.Handlers
{
    public class DeleteUserHandler : ICommandHandler<DeleteUserCommand>
    {
        private readonly IUsersRepository usersRepository;

        public DeleteUserHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task HandleAsync(DeleteUserCommand command)
        {
            var user = usersRepository.Get(command.UserId);
            user.Delete();
            await usersRepository.UpdateAsync(user);
        }
    }
}
