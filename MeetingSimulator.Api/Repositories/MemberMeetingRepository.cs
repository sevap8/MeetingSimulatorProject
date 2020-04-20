using MeetingSimulator.Api.Data;
using MeetingSimulator.Core.Dto;
using MeetingSimulator.Core.Models;
using MeetingSimulator.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MeetingSimulator.Api.Repositories
{
    public class MemberMeetingRepository : IMemberMeetingRepository
    {
        private readonly MeetingSimulatorDbContext dbContext;
        public MemberMeetingRepository(MeetingSimulatorDbContext dbContex)
        {
            this.dbContext = dbContex;
        }

        public IEnumerable<MeetingMembeInfo> GetAll()
        {
            var some = from meeting in dbContext.Meetings
                    join memberMeeting in dbContext.MemberMeetings on meeting.Id equals memberMeeting.MeetingId
                    join member in dbContext.Members on memberMeeting.MemberId equals member.Id
                    select new MeetingMembeInfo{  MeetingName = meeting.Name, Place = meeting.Place, 
                        DateTimeMeeting = meeting.DateTimeMeeting, MemberName = member.Name, Surname = member.Surname, Mail = member.Mail };
            return some;
        }

        public void Add(MemberMeetingEntity memberMeetingEntity)
        {
            this.dbContext.MemberMeetings.Add(memberMeetingEntity);
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }

        public bool Contains(MemberMeetingEntity memberMeetingEntity)
        {
            return this.dbContext.MemberMeetings.Any(a =>
           a.MeetingId == memberMeetingEntity.MeetingId
           && a.MemberId == memberMeetingEntity.MemberId);
        }

        public void Remove(MemberMeetingEntity memberMeetingEntity)
        {
            this.dbContext.MemberMeetings.Remove(memberMeetingEntity);
        }

        public bool ContainsMeetingId(int entityId)
        {
            return this.dbContext.Meetings.Any(a =>
        a.Id == entityId);
        }

        public bool ContainsMemberId(int entityId)
        {
            return this.dbContext.Members.Any(a =>
        a.Id == entityId);
        }
    }
}
