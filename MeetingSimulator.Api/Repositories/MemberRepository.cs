using MeetingSimulator.Api.Data;
using MeetingSimulator.Core.Models;
using MeetingSimulator.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace MeetingSimulator.Api.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly MeetingSimulatorDbContext dbContext;
        public MemberRepository(MeetingSimulatorDbContext dbContex)
        {
            this.dbContext = dbContex;
        }

        public void Add(MemberEntity memberEntity)
        {
            this.dbContext.Members.Add(memberEntity);
        }

        public MemberEntity GetMemberById(int id)
        {
            return dbContext.Members.Where(a => a.Id == id).FirstOrDefault();
        }

        public IEnumerable<MemberEntity> GetAllMember()
        {
            return dbContext.Members.Select(a => a);
        }

        public void Save()
        {
            this.dbContext.SaveChanges();
        }
        public bool ContainsId(int entityId)
        {
            return this.dbContext.Members.Any(a =>
        a.Id == entityId);
        }

        public bool Contains(MemberEntity memberEntity)
        {
            return this.dbContext.Members.Any(a =>
           a.Name == memberEntity.Name
           && a.Surname == memberEntity.Surname
           && a.Mail == memberEntity.Mail
           && a.Id == memberEntity.Id);
        }

        public void Remove(MemberEntity memberEntity)
        {
            this.dbContext.Members.Remove(memberEntity);
        }
    }
}
