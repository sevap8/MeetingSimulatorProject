using System.Collections.Generic;
using MeetingSimulator.Api.Data;
using MeetingSimulator.Api.Repositories;
using MeetingSimulator.Core.Dto;
using MeetingSimulator.Core.Models;
using MeetingSimulator.Core.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingSimulator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService meetingService;
        public MeetingController(IMeetingService meetingService)
        {
            this.meetingService = meetingService;
        }

        //Invoke-RestMethod https://localhost:44361/api/Meeting/ -Method GET
        // GET: api/Meeting
        [HttpGet]
        public ActionResult<IEnumerable<MeetingEntity>> Get()
        {
            var meeting = meetingService.GetAllMeeting();
            return new ObjectResult(meeting);
        }

        //Invoke-RestMethod https://localhost:44361/api/Meeting/1 -Method GET
        // GET: api/Meeting/3
        [HttpGet("{id}", Name = "GetMeeting")]
        public ActionResult<MeetingEntity> Get(int id)
        {
            var meeting =  meetingService.GetMeetingById(id);
            return new ObjectResult(meeting);
        }

        //Invoke-RestMethod https://localhost:44361/api/Meeting -Method POST -Body (@{Name = "SomeSurname"; Place = "SomePlace"; DateTime= 2015, 7, 20} | ConvertTo-Json) -ContentType "application/json"
        // POST: api/Meeting
        [HttpPost]
        public void Post([FromBody] MeetingRegistrationInfo value)
        {
            meetingService.AddMeeting(value);
        }

        //Invoke-RestMethod https://localhost:44361/api/Meeting/2 -Method DELETE
        // DELETE: api/Meeting/3
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            meetingService.RemoveMeeting(id);
        }
    }
}
