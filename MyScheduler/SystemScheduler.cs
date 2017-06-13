using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduler
{
    public class SystemScheduler
    {
        private SystemScheduler()
        {
        }

        public static SystemScheduler CreateInstance()
        {
            return new SystemScheduler();
        }

        private IScheduler _scheduler;

        public void StartScheduler()
        {
            int hour = int.Parse(((NameValueCollection)ConfigurationSettings.GetConfig("JobList/Job"))["Hour"]);
            int minute = int.Parse(((NameValueCollection)ConfigurationSettings.GetConfig("JobList/Job"))["Minute"]);

            ISchedulerFactory schedulerFactory = new StdSchedulerFactory();//内存调度
            _scheduler = schedulerFactory.GetScheduler();

            IJobDetail synchronousData = new JobDetailImpl("SynchronousData", typeof(SynchronousData));
            ITrigger trigger =
                TriggerBuilder.Create()
                    .WithDailyTimeIntervalSchedule(
                        a => a.WithIntervalInHours(24).OnEveryDay().StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(13, 36))).Build();
            _scheduler.ScheduleJob(synchronousData, trigger);

            _scheduler.Start();
        }

        public void StopScheduler()
        {
            _scheduler.Shutdown();
        }
    }
}
