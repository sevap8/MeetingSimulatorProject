using MeetingSimulator.Core.Dto;
using MeetingSimulator.Core.Models;
using MeetingSimulator.Core.Repositories;
using MeetingSimulator.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingSimulator.Core.Services
{
    public class MemberMeetingService : IMemberMeetingService
    {
        private readonly IMemberMeetingRepository memberMeetingRepository;
        public MemberMeetingService(IMemberMeetingRepository memberMeetingRepository)
        {
            this.memberMeetingRepository = memberMeetingRepository;
        }

        public void AddMembersToTheMeeting(MeetingMemberRegistrationInfo registrationInfo)
        {
            var entityToAdd = new MemberMeetingEntity
            {
                MeetingId = registrationInfo.MeetingId,
                MemberId = registrationInfo.MemberId
            };

            if (this.memberMeetingRepository.Contains(entityToAdd))
            {
                throw new ArgumentException("This entity has been registered. Can't continue");
            }

            if (!this.memberMeetingRepository.ContainsMeetingId(entityToAdd.MeetingId) ||
                !this.memberMeetingRepository.ContainsMemberId(entityToAdd.MemberId))
            {
                throw new ArgumentException("This entity is missing!");
            }

            this.memberMeetingRepository.Add(entityToAdd);
            this.memberMeetingRepository.Save();
        }        
        
        public void RemoveMembersToTheMeeting(MeetingMemberRegistrationInfo registrationInfo)
        {
            var memberMeetingEntity = new MemberMeetingEntity 
            { 
                MeetingId = registrationInfo.MeetingId,
                MemberId = registrationInfo.MemberId
            };

            if (!this.memberMeetingRepository.Contains(memberMeetingEntity))
            {
                throw new ArgumentException("This entity is missing!");
            }

            this.memberMeetingRepository.Remove(memberMeetingEntity);
            this.memberMeetingRepository.Save();
        }

        public IEnumerable<MeetingMembeInfo> ListOfMeetingsAndMembers()
        {
           return memberMeetingRepository.GetAll();
        }
    }
}
