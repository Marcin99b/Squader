using Squader.Cqrs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Squader.DomainModel.Users.Commands.Handlers
{
    class RegisterUserHandler : ICommandHandler<RegisterUserCommand>
    {
        public Task HandleAsync(RegisterUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
