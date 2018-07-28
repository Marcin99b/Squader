using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.DomainModel.Conversations
{
    public class ConversationMessage
    {
        public Guid Id { get; private set; }
        public Guid AuthorId { get; private set; }
        public string Message { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public ConversationMessage(Guid authorId, string message)
        {
            Id = Guid.NewGuid();
            AuthorId = authorId;
            Message = message;
            CreatedAt = DateTime.UtcNow;
        }
    }
}
