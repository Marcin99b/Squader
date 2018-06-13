using Squader.Cqrs;
using Squader.DomainModel.Users;

namespace Squader.ReadModel.Users.Queries
{
    public class GetUserByIdQueryResult : IQueryResult
    {
        public User User { get; }

        public GetUserByIdQueryResult(User user)
        {
            User = user;
        }
    }
}
