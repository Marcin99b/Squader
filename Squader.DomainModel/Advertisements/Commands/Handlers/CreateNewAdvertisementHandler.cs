using System.Threading.Tasks;
using Squader.Cqrs;

namespace Squader.DomainModel.Advertisements.Commands.Handlers
{
    public class CreateNewAdvertisementHandler : ICommandHandler<CreateNewAdvertisementCommand>
    {
        public async Task HandleAsync(CreateNewAdvertisementCommand command)
        {
            //at now you must use debugger to see command content
        }
    }
}
