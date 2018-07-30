using System;
using System.Linq;
using System.Threading.Tasks;
using Squader.DomainModel.Conversations;
using Squader.DomainModel.Repositories;
using Squader.Infrastructure.DAL;

namespace Squader.Infrastructure.Repositories
{
    public class ConversationsRepository : IConversationsRepository
    {
        private readonly IContext context;

        public ConversationsRepository(IContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Conversation conversation)
        {
            await context.Conversations.AddAsync(conversation);
            await context.SaveChangesAsync();

            await Task.CompletedTask;
        }

        public Conversation Get(Guid conversationId)
        {
            return context.Conversations.FirstOrDefault(x => x.Id == conversationId && !x.IsDeleted);
        }

        public async Task UpdateAsync(Conversation conversation)
        {
            context.Conversations.Update(conversation);
            await context.SaveChangesAsync();

            await Task.CompletedTask;
        }
    }
}
