using System;
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
        public async Task ShouldRegisterUserCorrectly()
        {
            //Arrange
            User createdUser = null;
            var usersRepository = new Mock<IUsersRepository>();

            usersRepository.Setup(x => x.AddAsync(It.IsAny<User>()))
                .Callback<User>(x => createdUser = x)
                .Returns(Task.CompletedTask);

            var registerUserHandler = new RegisterUserHandler(usersRepository.Object);
            var command = new RegisterUserCommand("test", "Test@test.pl", "test", "test");

            //Act
            await registerUserHandler.HandleAsync(command);

            //Assert
            Assert.That(createdUser.Username, Is.EqualTo(command.Username));
        }

        [Test]
        public async Task ShouldDeleteUserAccountCorrectly()
        {
            //Arrange
            User user = new User("test", "test", "test", "test");
            var dateDeleted = new DateTime();
            var usersRepository = new Mock<IUsersRepository>();
            usersRepository.Setup(x => x.Get(It.IsAny<Guid>()))
                .Returns(user);

            usersRepository.Setup(x => x.UpdateAsync(It.IsAny<User>()))
                .Callback<User>(x =>
                {
                    user = x;
                    dateDeleted = user.ChangedAt;
                })
                .Returns(Task.CompletedTask);


            var deleteUserHandler = new DeleteUserHandler(usersRepository.Object);
            var command = new DeleteUserCommand(user.Id);
            
            //Act
            await deleteUserHandler.HandleAsync(command);

            //Assert

            usersRepository.Verify(x => x.Get(It.IsAny<Guid>()), Times.Once);
            usersRepository.Verify(x => x.UpdateAsync(It.IsAny<User>()), Times.Once);
            Assert.That(user.IsDeleted);
            Assert.That(user.ChangedAt, Is.EqualTo(dateDeleted));           
        }

        [Test]
        public async Task ShouldUpdateUserAccountCorrectly()
        {
            //Arrange
            User user = new User("test", "test", "test", "test");
            var usersRepository = new Mock<IUsersRepository>();
            var dateUpdated = new DateTime();

            usersRepository.Setup(x => x.Get(It.IsAny<Guid>()))
                .Returns(user);

            usersRepository.Setup(x => x.UpdateAsync(It.IsAny<User>()))
                .Callback<User>(x =>
                {
                    user = x;
                    dateUpdated = user.ChangedAt;
                })
                .Returns(Task.CompletedTask);

            var updateUserHandler = new UpdateUserHandler(usersRepository.Object);
            var command = new UpdateUserCommand(user.Id, "test2", "test2", "test2", "test2","test2");

            //Act
            await updateUserHandler.HandleAsync(command);


            //Assert
            usersRepository.Verify(x => x.Get(It.IsAny<Guid>()), Times.Once);
            usersRepository.Verify(x => x.UpdateAsync(It.IsAny<User>()), Times.Once);
            Assert.That(user.ChangedAt, Is.EqualTo(dateUpdated));
            Assert.That(user.Username, Is.EqualTo(command.Username));
            Assert.That(user.Email, Is.EqualTo(command.Email));
            Assert.That(user.Forename, Is.EqualTo(command.Forename));
            Assert.That(user.Surname, Is.EqualTo(command.Surname));
            Assert.That(user.City, Is.EqualTo(command.City));
        }

        //private User GetLastInputUser(Mock<IUsersRepository> usersRepository)
        //    => (User) usersRepository.Invocations.Select(inv => inv.Arguments)
        //        .Select(obj =>obj.FirstOrDefault(x => x.GetType() == typeof(User))).First();

 
    }
}

