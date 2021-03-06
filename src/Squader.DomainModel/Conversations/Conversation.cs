﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Squader.DomainModel.Conversations
{
    public class Conversation
    {
        [NotMapped]
        private ISet<ConversationUser> users = new HashSet<ConversationUser>();
        [NotMapped]
        private ISet<ConversationMessage> messages = new HashSet<ConversationMessage>();

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Id { get; private set; }

        [NotMapped]
        public IEnumerable<ConversationUser> Users
        {
            get { return users; }
            set { users = new HashSet<ConversationUser>(value); }
        }

        [NotMapped]
        public IEnumerable<ConversationMessage> Messages
        {
            get { return messages; }
            set { messages = new HashSet<ConversationMessage>(value); }
        }
        public DateTime ChangedAt { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool IsDeleted { get; private set; }

        private Conversation() { }

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
            IsDeleted = true;
        }
    }
}
