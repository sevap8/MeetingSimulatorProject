using MeetingSimulator.Api.Data;
using MeetingSimulator.Core.Models;
using MeetingSimulator.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MeetingSimulator.Api.Repositories
{
    public class MeetingRepository : IMeetingRepository
    {
        private readonly MeetingSimulatorDbContext dbContext;
        public MeetingRepository(MeetingSimulatorDbContext dbContex)
        {
            this.dbContext = dbContex;
        }

        public void Add(MeetingEntity meetingEntity)
        {
            this.dbContext.Meetings.Add(meetingEntity);
        }

        public MeetingEntity GetMeetingById(int id)
        {
            return dbContext.Meetings.Where(a => a.Id == id).FirstOrDefault();
        }

        public IEnumerable<MeetingEntity> GetAllMeeting()
        {
            return dbContext.Meetings.Select(a => a);
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }
        public bool ContainsId(int entityId)
        {
            return this.dbContext.Meetings.Any(a =>
        a.Id == entityId);
        }

        public bool Contains(MeetingEntity meetingEntity)
        {
            return this.dbContext.Meetings.Any(a =>
           a.Name == meetingEntity.Name
           && a.Place == meetingEntity.Place
           && a.DateTimeMeeting == meetingEntity.DateTimeMeeting
           && a.Id == meetingEntity.Id);
        }

        public void Remove(MeetingEntity meetingEntity)
        {
            this.dbContext.Meetings.Remove(meetingEntity);
        }
    }
}
