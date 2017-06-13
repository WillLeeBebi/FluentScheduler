using FluentScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySchedulerHelper
{
    public class MySchedulerHelper
    {
        public static void Test1(Action schedulerAction)
        {
            JobManager.AddJob(schedulerAction, t => { t.ToRunNow().AndEvery(1).Seconds(); });
        }
    }
}
