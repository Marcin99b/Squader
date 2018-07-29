using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Squader.DomainModel.Conversations
{
    public class ConversationMessage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; private set; }
        public Guid AuthorId { get; private set; }
        public string Message { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public Guid ConversationId { get; private set; }

        private ConversationMessage() { }

        public ConversationMessage(Guid authorId, string message, Guid conversationId)
        {
            Id = Guid.NewGuid();
            AuthorId = authorId;
            Message = message;
            CreatedAt = DateTime.UtcNow;
            ConversationId = conversationId;
        }
    }
}
