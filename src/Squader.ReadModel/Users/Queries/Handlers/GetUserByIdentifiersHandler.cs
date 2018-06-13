using Squader.Common.Extensions;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;
using Squader.DomainModel.Users;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Squader.ReadModel.Users.Queries.Handlers
{
    public class GetUserByIdentifiersHandler : IQueryHandler<GetUserByIdentifiersQuery, GetUserByIdentifiersQueryResult>
    {
        private readonly IUsersRepository usersRepository;
        public GetUserByIdentifiersHandler(IUsersRepository userRepository)
        {
            this.usersRepository = userRepository;
        }

        public GetUserByIdentifiersQueryResult Handle(GetUserByIdentifiersQuery query)
        {
            if (query.UserIdentifier.IsEmail())
            {
                var user = usersRepository.GetUserByEmailAsync(query.UserIdentifier).Result;

                if (user == null)
                    return null;

                return new GetUserByIdentifiersQueryResult(user);
                

            }
                
            else
            {
                var user = usersRepository.GetUserByUsernameAsync(query.UserIdentifier).Result;

                if (user == null)
                    return null;

                return new GetUserByIdentifiersQueryResult(user);
            }


        }
    }
}
