﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Squader.DomainModel.Conversations
{
    public class ConversationUser
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid UserId { get; private set; }
        public int ConversationRoleId { get; private set; }
        [NotMapped]
        public ConversationRole Role { get; private set; }

        private ConversationUser() { }

        public ConversationUser(Guid userId, ConversationRole role)
        {
            UserId = userId;
            Role = role;
        }
    }
}
