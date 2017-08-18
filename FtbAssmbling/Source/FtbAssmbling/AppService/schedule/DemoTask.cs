using System;
using System.Collections.Generic;
using System.Text;
using ftd.thread;
using ftd.data.schedule;
using System.Threading;
using ftd.service;

namespace ftd.data.schedule
{
    public class DemoTask : FtdScheduleTask
    {
        public override void scheduleMain(ThreadStart doEvent)
        {            
            Thread.Sleep(1000 * 10); //10 Seconds
        }      
    }
}
