using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MeetingSimulator.Api.Data;
using MeetingSimulator.Api.Repositories;
using MeetingSimulator.Core;
using MeetingSimulator.Core.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace MeetingSimulator.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MeetingSimulatorDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DbContext")));
            services.AddControllers();
            services.GetDependencyServices();
            services.AddTransient<IMeetingRepository, MeetingRepository>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IMemberMeetingRepository, MemberMeetingRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
