using System;
using System.Threading.Tasks;
using Squader.Cqrs;

namespace Squader.ReadModel.Users.Queries
{
    public class GetUserByIdQuery : IQuery<GetUserByIdQueryResult>
    {
        public Guid UserId { get; }

        public GetUserByIdQuery(Guid userId)
        {
            UserId = userId;
        }
    }
}
