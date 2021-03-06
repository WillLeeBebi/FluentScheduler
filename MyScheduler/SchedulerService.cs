﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MyScheduler
{
    public partial class SchedulerService : ServiceBase
    {
        public SchedulerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            SystemScheduler _systemScheduler = SystemScheduler.CreateInstance();
            _systemScheduler.StartScheduler();
        }

        protected override void OnStop()
        {
        }
    }
}
