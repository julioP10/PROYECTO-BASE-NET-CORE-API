using Hangfire;
using Infraestructure.Crosscutting.Enums;
using Infraestructure.Crosscutting.Scheduler;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.MainModule.Scheduler
{
    public class HangfireScheduler : IScheduler
    {
        private readonly IServiceProvider _serviceProvider;

        public HangfireScheduler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void Register<TJob>(JobConfig config)
            where TJob : IJob
        {
            var executionTimes = config.Hours.Split(',').Select(p => TimeSpan.Parse(p));

            switch (config.Frequency)
            {
                case (int)FrequencyType.OneTime:
                    RegisterOnce<TJob>(executionTimes, config);
                    break;
                case (int)FrequencyType.Daily:
                    RegisterDaily<TJob>(executionTimes, config);
                    break;
                case (int)FrequencyType.Weekly:
                    RegisterWeekly<TJob>(executionTimes, config);
                    break;
                default:
                    break;
            }
        }

        public void DeleteJobs(string idMask, string hours)
        {
            var timeArray = hours.Split(',').Select(p => TimeSpan.Parse(p)); ;

            foreach (var time in timeArray)
            {
                RecurringJob.RemoveIfExists($"{idMask}_{time.ToString("hhmm")}");
            }
        }

        private void RegisterOnce<TJob>(IEnumerable<TimeSpan> times, JobConfig config)
            where TJob : IJob
        {
            foreach (var time in times)
            {
                var instanceJob = _serviceProvider.GetService<TJob>();
                BackgroundJob.Schedule(() => instanceJob.Run(config), new DateTimeOffset(config.StartDate.Date.AddTicks(time.Ticks)));
            }
        }

        private void RegisterDaily<TJob>(IEnumerable<TimeSpan> times, JobConfig config)
            where TJob : IJob
        {
            foreach (var time in times)
            {
                var utcDate = config.StartDate.Date.AddTicks(time.Ticks).ToUniversalTime();
                var utcTime = utcDate.TimeOfDay;
                var instanceJob = _serviceProvider.GetService<TJob>();
                var cronExpression = $"{utcTime.Minutes} {utcTime.Hours} {utcDate.Day}/{config.FrequencyInterval} * *";

                RecurringJob.AddOrUpdate(
                    $"{config.Type}{config.Id}_{time.ToString("hhmm")}",
                    () => instanceJob.Run(config), cronExpression, TimeZoneInfo.Utc);
            }
        }

        private void RegisterWeekly<TJob>(IEnumerable<TimeSpan> times, JobConfig config)
            where TJob : IJob
        {
            foreach (var time in times)
            {
                var utcDate = config.StartDate.Date.AddTicks(time.Ticks).ToUniversalTime();
                var utcTime = utcDate.TimeOfDay;
                var instanceJob = _serviceProvider.GetService<TJob>();
                var cronExpression = $"{utcTime.Minutes} {utcTime.Hours} * * {config.DaysRepeat ?? "*"}";

                RecurringJob.AddOrUpdate(
                    $"{config.Type}{config.Id}_{time.ToString("hhmm")}",
                    () => instanceJob.Run(config), cronExpression, TimeZoneInfo.Utc);
            }
        }
    }
}
