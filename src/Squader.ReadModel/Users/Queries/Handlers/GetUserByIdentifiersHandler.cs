using Squader.Common.Extensions;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;
using Squader.DomainModel.Users;
using Squader.Infrastructure.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Squader.ReadModel.Users.Queries.Handlers
{
    public class GetUserByIdentifiersHandler : IQueryHandler<GetUserByIdentifiersQuery, GetUserByIdentifiersQueryResult>
    {
        private readonly IUsersRepository usersRepository;
        private readonly IContext context;

        public GetUserByIdentifiersHandler(IUsersRepository userRepository, IContext context)
        {
            this.usersRepository = userRepository;
            this.context = context;
        }

        public GetUserByIdentifiersQueryResult Handle(GetUserByIdentifiersQuery query)
        {
            if (query.UserIdentifier.IsEmail())
            {
                var userWithEmail = usersRepository.GetUserByEmailAsync(query.UserIdentifier).Result;

                if (userWithEmail == null)
                    return null;

                return new GetUserByIdentifiersQueryResult(userWithEmail);
                

            }
                
            
            
                var userWithUsername = usersRepository.GetUserByUsernameAsync(query.UserIdentifier).Result;

                if (userWithUsername == null)
                    return null;

                return new GetUserByIdentifiersQueryResult(userWithUsername);
            


        }
    }
}
