using System;
using MeetingSimulator.Api.Data;
using MeetingSimulator.Api.Repositories;
using MeetingSimulator.Core.Dto;
using MeetingSimulator.Core.Models;
using MeetingSimulator.Core.Repositories;
using MeetingSimulator.Core.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace MeetingSimulator.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //MeetingSimulatorDbContext meetingSimulatorDbContext = new MeetingSimulatorDbContext();
            //IMemberRepository memberRepository = new MemberRepository(meetingSimulatorDbContext);
            //MemberServices memberServices = new MemberServices(memberRepository);
            //MeetingRepository meetingRepository = new MeetingRepository(meetingSimulatorDbContext);
            //MeetingService meetingService = new MeetingService(meetingRepository);
            //MemberMeetingRepository memberMeetingRepository = new MemberMeetingRepository(meetingSimulatorDbContext);
            //MemberMeetingService memberMeetingService = new MemberMeetingService(memberMeetingRepository);
            //var a = memberRepository.ContainsId(4);
            //var b = memberMeetingRepository.ContainsMemberId(4);
           //memberMeetingService.AddMembersToTheMeeting(3, 4);

            //foreach (var item in some)
            //{
            //    Console.WriteLine(item.MeetingName, item.Place, item.Surname);
            //}

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
