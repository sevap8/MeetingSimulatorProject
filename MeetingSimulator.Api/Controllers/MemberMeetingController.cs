using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingSimulator.Core.Models;
using MeetingSimulator.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingSimulator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberMeetingController : ControllerBase
    {
        private readonly IMemberMeetingService memberMeetingService;
        public MemberMeetingController(IMemberMeetingService memberMeetingService)
        {
            this.memberMeetingService = memberMeetingService;
        }

        // GET: api/MemberMeeting
        [HttpGet]
        public ActionResult<IEnumerable<MemberMeetingEntity>> Get()
        {
            var memberMeeting = memberMeetingService.ListOfMeetingsAndMembers();
            return new ObjectResult(memberMeeting);
        }

        // POST: api/MemberMeeting
        [HttpPost]
        public void Post([FromBody] int meetingId, int memberId)
        {
            memberMeetingService.AddMembersToTheMeeting(meetingId, memberId);
        }

        //Invoke-RestMethod https://localhost:44361/api/MemberMeeting/1/1 -Method DELETE
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int meetingId, int memberId)
        {
            memberMeetingService.RemoveMembersToTheMeeting(meetingId, memberId);
        }
    }
}
