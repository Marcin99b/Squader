using System;
using Squader.Cqrs;

namespace Squader.DomainModel.Users.Commands
{
    public class DeleteUserCommand : ICommand
    {
        public Guid UserId { get; private set; }

        public DeleteUserCommand(Guid userId)
        {
            UserId = userId;
        }
    }
}
