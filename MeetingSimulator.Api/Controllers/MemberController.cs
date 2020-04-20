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
    public class MemberController : ControllerBase
    {
        private readonly IMemberService memberService;
        public MemberController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        // GET: api/Member
        [HttpGet]
        public ActionResult<IEnumerable<MemberEntity>> Get()
        {
            var member = memberService.GetAllMember();
            return new ObjectResult(member);
        }

        // GET: api/Member/5
        [HttpGet("{id}", Name = "GetMember")]
        public ActionResult<MemberEntity> Get(int id)
        {
            var member = memberService.GetMemberById(id);
            return new ObjectResult(member);
        }

        //Invoke-RestMethod https://localhost:44361/api/Member -Method POST -Body (@{Surname = "SomeSurname"; Name = "SomeName"; Mail= "SomeMail"} | ConvertTo-Json) -ContentType "application/json"
        // POST: api/Member
        [HttpPost]
        public void Post([FromBody] MemberRegistrationInfo value)
        {
            memberService.AddMember(value);
        }

        //Invoke-RestMethod https://localhost:44361/api/Member/2 -Method DELETE
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            memberService.RemoveMember(id);
        }
    }
}
