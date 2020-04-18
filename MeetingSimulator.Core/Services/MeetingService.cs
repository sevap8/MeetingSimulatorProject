using MeetingSimulator.Core.Dto;
using MeetingSimulator.Core.Models;
using MeetingSimulator.Core.Repositories;
using MeetingSimulator.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingSimulator.Core.Services
{
    public class MeetingService : IMeetingService
    {
        private readonly IMeetingRepository meetingRepository;
        public MeetingService(IMeetingRepository meetingRepository)
        {
            this.meetingRepository = meetingRepository;
        }

        public void AddMeeting(MeetingRegistrationInfo meetingRegistrationInfo)
        {
            var entityToAdd = new MeetingEntity()
            {
                Name = meetingRegistrationInfo.Name,
                Place = meetingRegistrationInfo.Place,
                DateTimeMeeting = meetingRegistrationInfo.DateTimeMeeting
            };

            if (this.meetingRepository.Contains(entityToAdd))
            {
                throw new ArgumentException("This meeting has been registered. Can't continue");
            }

            this.meetingRepository.Add(entityToAdd);
            this.meetingRepository.Save();
        }

        public MeetingEntity GetMeetingById(int id)
        {
            if (!meetingRepository.ContainsId(id))
            {
                throw new ArgumentException($"This meeting is missing {id}! ");
            }

            return meetingRepository.GetMeetingById(id);
        }

        public IEnumerable<MeetingEntity> GetAllMeeting()
        {
            var allMember = meetingRepository.GetAllMeeting();
            if (allMember == null)
            {
                throw new ArgumentException($"The list is empty! ");
            }

            return allMember;
        }

        public void RemoveMeeting(int id)
        {
            if (!meetingRepository.ContainsId(id))
            {
                throw new ArgumentException($"This member is missing {id}! ");
            }

            meetingRepository.Remove(GetMeetingById(id));
            meetingRepository.Save();
        }
    }
}
