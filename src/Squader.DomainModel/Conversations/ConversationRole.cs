using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.DomainModel.Conversations
{
    public class ConversationRole
    {
        public int Id { get; private set; }
        public string Role { get; private set; }
        public bool AddUsers { get; private set; }
        public bool DeleteUsers { get; private set; }
        public bool DeleteConversation { get; private set; }

        public static ConversationRole Owner = new ConversationRole
        {
            Id = 0,
            Role = "Owner",
            AddUsers = true,
            DeleteUsers = true,
            DeleteConversation = true
        };

        public static ConversationRole Admin = new ConversationRole
        {
            Id = 1,
            Role = "Admin",
            AddUsers = true,
            DeleteUsers = true,
            DeleteConversation = false
        };

        public static ConversationRole User = new ConversationRole
        {
            Id = 2,
            Role = "User",
            AddUsers = false,
            DeleteUsers = false,
            DeleteConversation = false
        };
    }
}
