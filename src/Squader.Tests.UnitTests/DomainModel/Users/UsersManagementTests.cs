﻿using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Squader.Common.Extensions;
using Squader.Cqrs;
using Squader.DomainModel.Repositories;
using Squader.DomainModel.Users;
using Squader.DomainModel.Users.Commands;
using Squader.DomainModel.Users.Commands.Handlers;

namespace Squader.Tests.UnitTests.DomainModel.Users
{
    [TestFixture]
    public class UsersManagementTests
    {
        [Test]
        public async Task ShouldDeleteUserAccountCorrectly()
        {
            //Arrange
            
            var user = new User("test", "test", "test", "test", "test", "test", "test");
            var userId = user.Id;
            var dateDeleted = new DateTime();
            var usersRepository = new Mock<IUsersRepository>();
            usersRepository.Setup(x => x.GetAsync(It.IsAny<Guid>()))
                .Returns(Task.FromResult(user));

            usersRepository.Setup(x => x.UpdateAsync(It.IsAny<User>()))
                .Callback<User>(x =>
                {
                    user = x;
                    dateDeleted = user.ChangedAt;
                })
                .Returns(Task.CompletedTask);


            var deleteUserHandler = new DeleteUserHandler(usersRepository.Object);
            var command = new DeleteUserCommand(userId);
            
             //Act

            await deleteUserHandler.HandleAsync(command);

            //Assert

            usersRepository.Verify(x => x.GetAsync(It.IsAny<Guid>()), Times.Once);
            usersRepository.Verify(x => x.UpdateAsync(It.IsAny<User>()), Times.Once);
            Assert.That(user.IsDeleted);
            Assert.That(user.ChangedAt, Is.EqualTo(dateDeleted));
            
        } 

        [Test]
        public async Task ShouldRegisterUserCorrectly()
        {
            //Arrange
            var usersRepository = new Mock<IUsersRepository>();

            usersRepository.Setup(x => x.AddAsync(It.IsAny<User>()))
                .Returns(Task.CompletedTask);

            var registerUserHandler = new RegisterUserHandler(usersRepository.Object);
            var registerUserCommand = new RegisterUserCommand("test", "Test@test.pl", "test", "test");

            //Act
            await registerUserHandler.HandleAsync(registerUserCommand);

            //Assert
            var responseUser = GetLastInputUser(usersRepository);
            Assert.That(responseUser.Username, Is.EqualTo(registerUserCommand.Username));
        }

        private User GetLastInputUser(Mock<IUsersRepository> usersRepository)
            => (User) usersRepository.Invocations.Select(inv => inv.Arguments)
                .Select(obj =>obj.FirstOrDefault(x => x.GetType() == typeof(User))).First();

    }
}
