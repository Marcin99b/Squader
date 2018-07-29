using System;
using Squader.Cqrs;

namespace Squader.DomainModel.Conversations.Commands
{
    public class DeleteConversationCommand : ICommand
    {
        public Guid ConversationId { get; private set; }

        public DeleteConversationCommand(Guid conversationId)
        {
            ConversationId = conversationId;
        }
    }
}
