using System;
using System.Collections.Generic;
using Squader.Cqrs;
using Squader.DomainModel.Conversations;
using Squader.DomainModel.Users;

namespace Squader.DomainModel.Conversations.Commands
{
    public class CreateNewConversationCommand : ICommand
    {
        public IEnumerable<ConversationUser> Users { get; private set; }
        
        public CreateNewConversationCommand(IEnumerable<ConversationUser> users)
        {
            Users = users;
        }
    }
}
