using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingSimulator.Api.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MeetingSimulator.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            MeetingSimulatorDbContex meetingSimulatorDbContex = new MeetingSimulatorDbContex();
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
