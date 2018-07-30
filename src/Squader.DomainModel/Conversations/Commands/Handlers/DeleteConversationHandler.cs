using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.DomainModel.Conversations.Commands.Handlers
{
    public class DeleteConversationHandler : ICommandHandler<DeleteConversationCommand>
    {
        private readonly IConversationsRepository conversationsRepository;

        public DeleteConversationHandler(IConversationsRepository conversationsRepository)
        {
            this.conversationsRepository = conversationsRepository;
        }

        public async Task HandleAsync(DeleteConversationCommand command)
        {
            var announcement = conversationsRepository.Get(command.ConversationId);
            announcement.Delete();
            await conversationsRepository.UpdateAsync(announcement);
        }
    }
}
