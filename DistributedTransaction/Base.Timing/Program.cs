using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AA.Log4Net;
using Base.Timing.AAJob;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Quartz;
using Quartz.Impl;

namespace Base.Timing
{
    public class Program
    {
        private static IScheduler _scheduler; // add this field
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            StartScheduler();
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();


        private static void StartScheduler()
        {
            Log4NetLogger.Use("log4net.config");
            var schedulerFactory = new StdSchedulerFactory();
            _scheduler = schedulerFactory.GetScheduler().Result;
            _scheduler.Start().Wait();

            var RetryServiceJob = JobBuilder.Create<RetryServiceJob>()
                .WithIdentity("RetryServiceJob", "jobGroup1")
                .Build();
            var RetryServiceTrigger = TriggerBuilder.Create()
                .WithIdentity("RetryServiceTriggerCron", "triggerGroup1")
                .StartNow()
                .WithCronSchedule("/10 * * ? * *")
                .Build();

            _scheduler.ScheduleJob(RetryServiceJob, RetryServiceTrigger).Wait();
        }
    }
}
