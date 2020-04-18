using MeetingSimulator.Core.Dto;
using MeetingSimulator.Core.Models;
using MeetingSimulator.Core.Repositories;
using MeetingSimulator.Core.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace MeetingSimulator.Core.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository memberRepository;
        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public void AddMember(MemberRegistrationInfo memberRegistrationInfo)
        {

            var entityToAdd = new MemberEntity() 
            { 
                Name = memberRegistrationInfo.Name, 
                Surname = memberRegistrationInfo.Surname, 
                Mail = memberRegistrationInfo.Mail
            };

            if (this.memberRepository.Contains(entityToAdd))
            {
                throw new ArgumentException("This member has been registered. Can't continue");
            }

            this.memberRepository.Add(entityToAdd);

            this.memberRepository.Save();
        }

        public MemberEntity GetMemberById(int id)
        {
            if (!memberRepository.ContainsId(id))
            {
                throw new ArgumentException($"This member is missing {id}! ");
            }

            return memberRepository.GetMemberById(id); 
        }

        public IEnumerable<MemberEntity> GetAllMember()
        {
            var allMember = memberRepository.GetAllMember();
            if (allMember == null)
            {
                throw new ArgumentException($"The list is empty! ");
            }

            return allMember;
        }

        public void RemoveMember(int id)
        {
            if (!memberRepository.ContainsId(id))
            {
                throw new ArgumentException($"This member is missing {id}! ");
            }
            
            memberRepository.Remove(GetMemberById(id));
            memberRepository.Save();
        }
    }
}
