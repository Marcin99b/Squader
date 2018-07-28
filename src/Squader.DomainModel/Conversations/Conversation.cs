using System;
using System.Collections.Generic;
using System.Linq;

namespace Squader.DomainModel.Conversations
{
    public class Conversation
    {
        private ISet<ConversationUser> users = new HashSet<ConversationUser>();
        private ISet<ConversationMessage> messages = new HashSet<ConversationMessage>();

        public Guid Id { get; private set; }
        public IEnumerable<ConversationUser> Users
        {
            get { return users; }
            set { users = new HashSet<ConversationUser>(value); }
        }
        public IEnumerable<ConversationMessage> Messages
        {
            get { return messages; }
            set { messages = new HashSet<ConversationMessage>(value); }
        }
        public DateTime ChangedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Deleted { get; private set; }

        public Conversation(IEnumerable<ConversationUser> users)
        {
            Id = Guid.NewGuid();
            SetUsers(users);
            CreatedAt = DateTime.UtcNow;
        }

        public void SetUsers(IEnumerable<ConversationUser> users)
        {
            Users = users;
            ChangedAt = DateTime.UtcNow;
        }

        public void AddMessage(ConversationMessage message)
        {
            messages.Add(message);
            ChangedAt = DateTime.UtcNow;
        }

        public void Delete()
        {
            Deleted = true;
        }
    }
}
