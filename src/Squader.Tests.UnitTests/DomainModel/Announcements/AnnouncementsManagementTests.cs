﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Squader.DomainModel.Announcements;
using Squader.DomainModel.Announcements.Commands;
using Squader.DomainModel.Announcements.Commands.Handlers;
using Squader.DomainModel.Repositories;
using Squader.DomainModel.Users;

namespace Squader.Tests.UnitTests.DomainModel.Announcements
{
    [TestFixture]
    public class AnnouncementsManagementTests
    {
        [Test]
        public async Task ShouldCreateAnnouncementProperly()
        {
            var repository = new Mock<IAnnouncementsRepository>();
            var announcement = new Announcement(new Guid(), new Guid(), string.Empty, string.Empty, string.Empty, new List<string>(),
                new List<string>());

            repository.Setup(x => x.AddAsync(It.IsAny<Announcement>()))
                .Callback<Announcement>(x => announcement = x)
                .Returns(Task.CompletedTask);

            var createNewAnnouncementHandler = new CreateNewAnnouncementHandler(repository.Object);
            var command = new CreateNewAnnouncementCommand(new Guid(), new Guid(), "test", "test", "test",
                new List<string>(), new List<string>());

            //Act

            await createNewAnnouncementHandler.HandleAsync(command);

            //Assert
            repository.Verify(x => x.AddAsync(It.IsAny<Announcement>()), Times.Once);
            Assert.That(announcement.Description, Is.EqualTo((command.Description)));
            Assert.That(announcement.ShortDescription, Is.EqualTo(command.ShortDescription));




        }
    }
}
