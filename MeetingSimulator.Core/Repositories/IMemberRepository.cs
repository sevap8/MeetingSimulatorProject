using MeetingSimulator.Core.Models;
using System.Collections.Generic;

namespace MeetingSimulator.Core.Repositories
{
    public interface IMemberRepository
    {
        void Add(MemberEntity memberEntity);
        MemberEntity GetMemberById(int id);
        IEnumerable<MemberEntity> GetAllMember();
        void Save();
        bool ContainsId(int entityId);
        bool Contains(MemberEntity memberEntity);
        void Remove(MemberEntity memberEntity);
    }
}
