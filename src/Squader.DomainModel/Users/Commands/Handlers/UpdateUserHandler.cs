using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.DomainModel.Users.Commands.Handlers
{
    public class UpdateUserHandler : ICommandHandler<UpdateUserCommand>
    {
        private readonly IUsersRepository usersRepository;

        public UpdateUserHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public async Task HandleAsync(UpdateUserCommand command)
        {
            var user = await usersRepository.GetAsync(command.UserId);
            var updated = UpdateUser(user, command);
            await usersRepository.UpdateAsync(updated);
        }

        private User UpdateUser(User user, UpdateUserCommand command)
        {
            user.SetUsername(command.Username);
            user.SetEmail(command.Email);
            user.SetForename(command.Forename);
            user.SetSurname(command.Surname);
            user.SetCity(command.City);
            return user;
        }
    }
}
