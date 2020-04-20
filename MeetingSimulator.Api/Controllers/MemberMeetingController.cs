using System.Collections.Generic;
using MeetingSimulator.Core.Dto;
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

        //Invoke-RestMethod https://localhost:44361/api/MemberMeeting -Method POST -Body (@{MeetingId = 3; MemberId= 3} | ConvertTo-Json) -ContentType "application/json"
        // POST: api/MemberMeeting
        [HttpPost]
        public void Post([FromBody] MeetingMemberRegistrationInfo registrationInfo)
        {
            memberMeetingService.AddMembersToTheMeeting(registrationInfo);
        }

        //Invoke-RestMethod https://localhost:44361/api/MemberMeeting -Method DELETE -Body (@{MeetingId = 4; MemberId= 3} | ConvertTo-Json) -ContentType "application/json"
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public void Delete(MeetingMemberRegistrationInfo registrationInfo)
        {
            memberMeetingService.RemoveMembersToTheMeeting(registrationInfo);
        }
    }
}
