using MeetingSimulator.Core.Dto;
using MeetingSimulator.Core.Models;
using MeetingSimulator.Core.Repositories;
using MeetingSimulator.Core.Services;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace MeetingSimulator.Core.Tests
{
    public class MeetingServiceTests
    {
        [Test]
        public void ShouldAddNewMeeting()
        {
            // Arrange
            var mock = new Mock<IMeetingRepository>();
            var meetingService = new MeetingService(mock.Object);
            MeetingRegistrationInfo meetingRegistrationInfo = new MeetingRegistrationInfo
            {
                Name = "SomeName",
                Place = "SomePlace"
            };

            // Act
            meetingService.AddMeeting(meetingRegistrationInfo);

            // Assert
            mock.Verify(a => a.Add(It.Is<MeetingEntity>(a => a.Name == "SomeName" && a.Place == "SomePlace")));
            mock.Verify(a => a.Save());
        }

        [Test]
        public void ShouldGetMeetingById()
        {
            // Arrange
            var mock = new Mock<IMeetingRepository>();
            var id = 1;
            var meetingEntity = new MeetingEntity
            {
                Name = "SomeName",
                Place = "SomePlace"
            };
            mock.Setup(a => a.GetMeetingById(It.IsAny<int>())).Returns(meetingEntity);
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            var meetingService = new MeetingService(mock.Object);

            // Act
            var entity = meetingService.GetMeetingById(id);

            // Assert
            Assert.AreEqual(entity, meetingEntity);
        }

        [Test]
        public void ShouldGetAllMeeting()
        {
            // Arrange
            var mock = new Mock<IMeetingRepository>();
            var meetingEntity = new MeetingEntity
            {
                Name = "SomeName",
                Place = "SomePlace"
            };
            var list = new List<MeetingEntity> { meetingEntity };
            mock.Setup(a => a.GetAllMeeting()).Returns(list);
            var meetingService = new MeetingService(mock.Object);

            // Act
            var entity = meetingService.GetAllMeeting();

            // Assert
            Assert.AreEqual(entity, list);
        }

        [Test]
        public void ShouldRemoveMeeting()
        {
            // Arrange
            var mock = new Mock<IMeetingRepository>();
            mock.Setup(a => a.ContainsId(It.IsAny<int>())).Returns(true);
            var meetingService = new MeetingService(mock.Object);
            var id = 1;

            // Act
            meetingService.RemoveMeeting(id);

            // Assert
            mock.Verify(a => a.Remove(It.IsAny<MeetingEntity>()));
            mock.Verify(a => a.Save());
        }
    }
}