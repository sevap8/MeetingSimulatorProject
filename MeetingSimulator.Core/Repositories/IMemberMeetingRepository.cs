using MeetingSimulator.Core.Dto;
using MeetingSimulator.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingSimulator.Core.Repositories
{
    public interface IMemberMeetingRepository
    {
        IEnumerable<MeetingMembeInfo> GetAll();
        void Add(MemberMeetingEntity memberMeetingEntity);
        void Save();
        bool Contains(MemberMeetingEntity memberMeetingEntity);
        void Remove(MemberMeetingEntity memberMeetingEntity);
        bool ContainsMeetingId(int entityId);
        bool ContainsMemberId(int entityId);
    }
}
