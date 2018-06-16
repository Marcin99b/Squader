using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Users;
using Squader.Infrastructure.DAL;

namespace Squader.ReadModel.Users.Queries.Handlers
{
    public class GetUserByIdHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {
        

        public GetUserByIdHandler()
        {
            
        }

        public GetUserByIdQueryResult Handle(GetUserByIdQuery query)
        {
            return new GetUserByIdQueryResult(new User("", "", "", "", "", "", ""));
        }
    }
}
