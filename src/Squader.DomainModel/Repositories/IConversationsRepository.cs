using Squader.DomainModel.Conversations;
using System;
using System.Threading.Tasks;

namespace Squader.DomainModel.Repositories
{
    public interface IConversationsRepository : IRepository
    {
        Task AddAsync(Conversation conversation);
        Conversation Get(Guid conversationId);
        Task UpdateAsync(Conversation conversation);
    }
}
