using System;

namespace Squader.DomainModel.Conversations
{
    public class ConversationUser
    {
        public Guid UserId { get; private set; }
        public ConversationRole Role { get; private set; }

        public ConversationUser(Guid userId, ConversationRole role)
        {
            UserId = userId;
            Role = role;
        }
    }
}
