using System;

namespace Squader.DomainModel.Conversations
{
    public class ConversationUser
    {
        public Guid UserId { get; private set; }
        public ConversationRole Role { get; privates et; }

        public ConversationUser(Guid userId, ConversationRole role)
        {
            UserId = userId;
            Role = role;
        }
    }
}
