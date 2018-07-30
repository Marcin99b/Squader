using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Internal;
using Moq;
using NUnit.Framework;
using Squader.DomainModel.Announcements;
using Squader.DomainModel.Announcements.Commands;
using Squader.DomainModel.Announcements.Commands.Handlers;
using Squader.DomainModel.Repositories;
using Squader.DomainModel.Users;
using Swashbuckle.AspNetCore.Swagger;

namespace Squader.Tests.UnitTests.DomainModel.Announcements
{
    [TestFixture]
    public class AnnouncementsManagementTests
    {
        [Test]
        public async Task ShouldCreateAnnouncementProperly()
        {
            //Arrange
            var tag = "tag";
            var tagList = new List<string>
            {
                tag
            };
            var repository = new Mock<IAnnouncementsRepository>();
            var announcement = new Announcement(new Guid(), new Guid(), string.Empty, string.Empty, string.Empty, new List<string>(),
                new List<string>());

            repository.Setup(x => x.AddAsync(It.IsAny<Announcement>()))
                .Callback<Announcement>(x => announcement = x)
                .Returns(Task.CompletedTask);

            var createNewAnnouncementHandler = new CreateNewAnnouncementHandler(repository.Object);
            var command = new CreateNewAnnouncementCommand(new Guid(), new Guid(), "test", "test", "test",
                new List<string>(), tagList);

            //Act
            await createNewAnnouncementHandler.HandleAsync(command);

            //Assert
            repository.Verify(x => x.AddAsync(It.IsAny<Announcement>()), Times.Once);
            Assert.That(announcement.Description, Is.EqualTo((command.Description)));
            Assert.That(announcement.ShortDescription, Is.EqualTo(command.ShortDescription));
            Assert.That(announcement.Tags.Any(x => x.Contains(tag)), Is.True);
        }

        [Test]
        public async Task ShouldUpdateAnnouncementProperly()
        {
            //Arrange
            var tag = "tag";
            var tagList = new List<string>
            {
                tag
            };
            var repository = new Mock<IAnnouncementsRepository>();
            var announcement = new Announcement(new Guid(), new Guid(), string.Empty, string.Empty, string.Empty, new List<string>(),
                new List<string>());
            var dateUpdated = new DateTime();

            repository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(announcement);
            repository.Setup(x => x.UpdateAsync(It.IsAny<Announcement>()))
                .Callback<Announcement>(x =>
                {
                    dateUpdated = x.ChangedAt;
                    announcement = x;
                })
                .Returns(Task.CompletedTask);

            var updateAnnouncementHandler = new UpdateConversationHandler(repository.Object);
            var command = new UpdateAnnouncementCommand(new Guid(), "test","test","test", tags: tagList);

            //Act
            await updateAnnouncementHandler.HandleAsync(command);

            //Assert
            repository.Verify(x => x.Get(It.IsAny<Guid>()), Times.Once);
            repository.Verify(x => x.UpdateAsync(It.IsAny<Announcement>()), Times.Once);
            Assert.That(announcement.Description, Is.EqualTo((command.Description)));
            Assert.That(announcement.ShortDescription, Is.EqualTo(command.ShortDescription));
            Assert.That(dateUpdated, Is.EqualTo(announcement.ChangedAt));
            Assert.That(announcement.Tags.Any(x => x.Contains(tag)), Is.True);
        }

        [Test]
        public async Task ShouldDeleteAnnouncementProperly()
        {
            //Arrange
            var repository = new Mock<IAnnouncementsRepository>();
            var announcement = new Announcement(new Guid(), new Guid(), string.Empty, string.Empty, string.Empty, new List<string>(),
                new List<string>());
            var dateUpdated  = new DateTime();
            repository.Setup(x => x.Get(It.IsAny<Guid>())).Returns(announcement);
            repository.Setup(x => x.UpdateAsync(It.IsAny<Announcement>()))
                .Callback<Announcement>(x =>
                {
                    dateUpdated = x.ChangedAt;
                    announcement = x;
                })
                .Returns(Task.CompletedTask);

            var deleteAnnouncementHandler = new DeleteAnnouncementHandler(repository.Object);
            var command = new DeleteAnnouncementCommand(new Guid());

            //Act
            await deleteAnnouncementHandler.HandleAsync(command);

            //Assert
            repository.Verify(x => x.Get(It.IsAny<Guid>()), Times.Once);
            repository.Verify(x => x.UpdateAsync(It.IsAny<Announcement>()), Times.Once);
            Assert.That(announcement.IsDeleted, Is.True);
            Assert.That(dateUpdated, Is.EqualTo(announcement.ChangedAt));

        }
    }
}
