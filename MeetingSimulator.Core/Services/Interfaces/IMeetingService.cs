using MeetingSimulator.Core.Dto;
using MeetingSimulator.Core.Models;
using System.Collections.Generic;

namespace MeetingSimulator.Core.Services.Interfaces
{
    public interface IMeetingService
    {
        void AddMeeting(MeetingRegistrationInfo meetingRegistrationInfo);
        MeetingEntity GetMeetingById(int id);
        IEnumerable<MeetingEntity> GetAllMeeting();
        void RemoveMeeting(int id);
    }
}
