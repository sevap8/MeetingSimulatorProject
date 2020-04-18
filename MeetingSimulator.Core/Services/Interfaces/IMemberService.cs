using MeetingSimulator.Core.Dto;
using MeetingSimulator.Core.Models;
using System.Collections.Generic;

namespace MeetingSimulator.Core.Services.Interfaces
{
    public interface IMemberService
    {
        void AddMember(MemberRegistrationInfo memberRegistrationInfo);
        MemberEntity GetMemberById(int id);
        IEnumerable<MemberEntity> GetAllMember();
        void RemoveMember(int id);
    }
}
