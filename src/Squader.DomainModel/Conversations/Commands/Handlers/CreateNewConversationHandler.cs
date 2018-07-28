using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;

namespace Squader.DomainModel.Conversations.Commands.Handlers
{
    public class CreateNewConversationHandler : ICommandHandler<CreateNewConversationCommand>
    {
        private readonly IConversationsRepository conversationsRepository;

        public CreateNewConversationHandler(IConversationsRepository conversationsRepository)
        {
            this.conversationsRepository = conversationsRepository;
        }

        public async Task HandleAsync(CreateNewConversationCommand command)
        {
            var conversation = new Conversation(command.Users);
            await conversationsRepository.AddAsync(conversation);
        }
    }
}
