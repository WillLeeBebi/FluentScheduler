using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Action saction = () =>
            {
                //Do something...
                Console.WriteLine("Timer task,current time:{0}", DateTime.Now);
            };

            MySchedulerHelper.MySchedulerHelper.Test1(saction);
            Console.ReadKey();
        }
    }
}
