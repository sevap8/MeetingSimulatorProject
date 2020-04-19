using MeetingSimulator.Core.Repositories;
using MeetingSimulator.Core.Services;
using MeetingSimulator.Core.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingSimulator.Core
{
    public static class DependencyServices
    {
        public static IServiceCollection GetDependencyServices(this IServiceCollection services)
        {
            return services.AddTransient<IMeetingService, MeetingService>()
                .AddTransient<IMemberService, MemberService>()
                .AddTransient<IMemberMeetingService, MemberMeetingService>();
        }
    }
}
