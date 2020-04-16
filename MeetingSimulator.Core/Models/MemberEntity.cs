using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingSimulator.Core.Models
{
    public class MemberEntity
    {
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }

        public List<MemberMeetingEntity> MemberMeetings { get; set; }

        public MemberEntity()
        {
            MemberMeetings = new List<MemberMeetingEntity>();
        }
    }
}
