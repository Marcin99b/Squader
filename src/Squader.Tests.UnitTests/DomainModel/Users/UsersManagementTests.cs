using System;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
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
        public async Task ShouldCreateUserAccountCorrectly()
        {
            //Arrange
            var responseUser = new User(string.Empty, string.Empty, string.Empty, string.Empty);
            var usersRepository = new Mock<IUsersRepository>();
            usersRepository.Setup(x => x.AddAsync(It.IsAny<User>()))
                .Callback<User>(x => responseUser = x)
                .Returns(Task.CompletedTask);

            var createNewUserHandler = new CreateNewUserHandler(usersRepository.Object);
            var command = new CreateNewUserCommand("test", "test", "test", "test", "test", "test", "test");

            //Act
            await createNewUserHandler.HandleAsync(command);

            //Assert
            usersRepository.Verify(x => x.AddAsync(It.IsAny<User>()), Times.Once);
            Assert.That(responseUser.Username, Is.EqualTo(command.Username));
        }
    }
}
