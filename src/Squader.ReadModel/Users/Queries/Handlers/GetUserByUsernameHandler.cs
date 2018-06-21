using Squader.Cqrs;
using Squader.DomainModel.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Squader.ReadModel.Users.Queries.Handlers
{
    public class GetUserByUsernameHandler : IQueryHandler<GetUserByUsernameQuery, GetUserByUsernameQueryResult>
    {
        private readonly IUsersRepository usersRepository;

        public GetUserByUsernameHandler(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public GetUserByUsernameQueryResult Handle(GetUserByUsernameQuery query)
        {
            var user = usersRepository.GetUserByUsernameAsync(query.Username).Result;
            if (user == null)
                return null;

            return new GetUserByUsernameQueryResult(user);
        }
    }

}
