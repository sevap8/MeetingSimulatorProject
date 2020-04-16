using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingSimulator.Core.Models
{
    public class MeetingEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }

        public DateTime DateTimeMeeting { get; set; }

        public List<MemberMeetingEntity> MemberMeetings { get; set; }

        public MeetingEntity()
        {
            MemberMeetings = new List<MemberMeetingEntity>();
        }
    }
}
