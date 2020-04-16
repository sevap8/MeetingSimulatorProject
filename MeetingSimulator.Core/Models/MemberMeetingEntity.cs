using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingSimulator.Core.Models
{
    public class MemberMeetingEntity
    {
        public int MemberId { get; set; }
        public MemberEntity Member { get; set; }

        public int MeetingId { get; set; }
        public MeetingEntity Meeting { get; set; }
    }
}
