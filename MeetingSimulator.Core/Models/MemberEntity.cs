using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MeetingSimulator.Core.Models
{
    public class MemberEntity
    {
        [Key]
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
