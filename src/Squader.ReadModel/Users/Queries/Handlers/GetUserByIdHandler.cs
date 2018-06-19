using System.Threading.Tasks;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;
using Squader.DomainModel.Users;


namespace Squader.ReadModel.Users.Queries.Handlers
{
    public class GetUserByIdHandler : IQueryHandler<GetUserByIdQuery, GetUserByIdQueryResult>
    {

        private readonly IUsersRepository usersRepository;

        public GetUserByIdHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public GetUserByIdQueryResult Handle(GetUserByIdQuery query)
        {
            var user = usersRepository.GetAsync(query.UserId).Result;

            return new GetUserByIdQueryResult(user);
        }
    }
}
