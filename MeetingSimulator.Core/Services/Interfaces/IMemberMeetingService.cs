using MeetingSimulator.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingSimulator.Core.Services.Interfaces
{
    public interface IMemberMeetingService
    {
        void AddMembersToTheMeeting(int meetingId, int memberId);
        void RemoveMembersToTheMeeting(int meetingId, int memberId);
        IEnumerable<MeetingMembeInfo> ListOfMeetingsAndMembers();
    }
}
