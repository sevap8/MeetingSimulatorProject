using MeetingSimulator.Core.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingSimulator.Core.Services.Interfaces
{
    public interface IMemberMeetingService
    {
        void AddMembersToTheMeeting(MeetingMemberRegistrationInfo registrationInfo);
        void RemoveMembersToTheMeeting(MeetingMemberRegistrationInfo registrationInfo);
        IEnumerable<MeetingMembeInfo> ListOfMeetingsAndMembers();
    }
}
