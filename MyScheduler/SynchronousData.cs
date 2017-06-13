using Quartz;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduler
{
    public class SynchronousData : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            string Url = ((NameValueCollection)ConfigurationSettings.GetConfig("JobList/Job"))["Url"];
            WebClient wc = new WebClient();
            WebRequest wr = WebRequest.Create(new Uri(Url));
            using (StreamWriter sw = File.AppendText(@"d:\SchedulerService.txt"))
            {
                sw.WriteLine("------------------" + "MyService服务在：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "     执行了一次任务" + "------------------");
                sw.Flush();
            }
        }
    }
}
