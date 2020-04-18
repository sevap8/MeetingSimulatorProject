using MeetingSimulator.Core.Models;
using System.Collections.Generic;

namespace MeetingSimulator.Core.Repositories
{
    public interface IMeetingRepository
    {
        void Add(MeetingEntity meetingEntity);
        MeetingEntity GetMeetingById(int id);
        IEnumerable<MeetingEntity> GetAllMeeting();
        void Save();
        bool ContainsId(int entityId);
        bool Contains(MeetingEntity meetingEntity);
        void Remove(MeetingEntity meetingEntity);
    }
}
