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
using Squader.DomainModel.Teams;
using Squader.DomainModel.Teams.Commands;
using Squader.DomainModel.Teams.Commands.Handlers;
using Squader.DomainModel.Users;

namespace Squader.Tests.UnitTests.DomainModel.Teams
{
    [TestFixture]
    class TeamsManagementTests
    {
        [Test]
        public async Task ShouldCreateTeamCorrectly()
        {
            //Arrange
            Team createdTeam = null;
            var teamsRepository = new Mock<ITeamsRepository>();
            var author = new User("test", "test@test.pl", "test", "test");

            teamsRepository.Setup(x => x.AddAsync(It.IsAny<Team>())).Callback<Team>(x => createdTeam = x).Returns(Task.CompletedTask);
            
            var createTeamHandler = new CreateNewTeamHandler(teamsRepository.Object);
            var command = new CreateNewTeamCommand(author, "test", "test");

            //Act
            await createTeamHandler.HandleAsync(command);

            //Assert
            Assert.That(createdTeam.Description, Is.EqualTo(command.Description));
        }
        [Test]
        public async Task ShouldDeleteTeamCorrectly()
        {
            //Arrange
            User testUser = new User("test", "test", "test", "test");
            Team testTeam = new Team(testUser, "test", "test");
            var dateDeleted = new DateTime();
            var teamsRepository = new Mock<ITeamsRepository>();
            teamsRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(testTeam);
            teamsRepository.Setup(x => x.UpdateAsync(It.IsAny<Team>())).Callback<Team>(x => { testTeam = x; dateDeleted = testTeam.ChangedAt; }).Returns(Task.CompletedTask);

            var deleteTeamHandler = new DeleteTeamHandler(teamsRepository.Object);
            var command = new DeleteTeamCommand(testTeam.Id);

            //Act
            await deleteTeamHandler.HandleAsync(command);

            //Assert
            teamsRepository.Verify(x => x.Get(It.IsAny<Guid>()), Times.Once);
            teamsRepository.Verify(x => x.UpdateAsync(It.IsAny<Team>()), Times.Once);
            Assert.That(testTeam.Deleted);
            Assert.That(testTeam.ChangedAt, Is.EqualTo(dateDeleted));
        }
        [Test]
        public async Task ShouldUpdateTeamCorrectly()
        {
            //Arrange
            User testUser = new User("test", "test", "test", "test");
            Team testTeam = new Team(testUser, "test", "test");
            var dateUpdated = new DateTime();
            var teamsRepository = new Mock<ITeamsRepository>();

            teamsRepository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(testTeam);
            teamsRepository.Setup(x => x.UpdateAsync(It.IsAny<Team>())).Callback<Team>(x => { testTeam = x; dateUpdated = testTeam.ChangedAt; }).Returns(Task.CompletedTask);

            var updateTeamHandler = new UpdateTeamHandler(teamsRepository.Object);
            var command = new UpdateTeamCommand(testTeam.Id, "test", "test");

            //Act
            await updateTeamHandler.HandleAsync(command);
            //Assert
            teamsRepository.Verify(x => x.Get(It.IsAny<Guid>()), Times.Once);
            teamsRepository.Verify(x => x.UpdateAsync(It.IsAny<Team>()), Times.Once);
            Assert.That(testTeam.ChangedAt, Is.EqualTo(dateUpdated));
            Assert.That(testTeam.Title, Is.EqualTo(command.Title));
            Assert.That(testTeam.Description, Is.EqualTo(command.Description));
            Assert.That(testTeam.Id, Is.EqualTo(command.TeamId));


           
        }

    }
}
