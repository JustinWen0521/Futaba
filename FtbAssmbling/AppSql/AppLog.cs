using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ftd.data.log;
using ftd.service;

namespace ftd
{
    public class AppLog : FtdLog
    {
        public AppLog()
        {
            IsEnabled = bool.Parse(FtdConfigService.Instance.getAppSettingValue(this.GetType().Name + ".IsLogEnable", "true"));
        }

        /// <summary>
        /// Write Log
        /// </summary>       
        public static void writeLog(string msg)
        {
            Console.WriteLine("{0}:{1}", DateTime.Now.ToString("HH:mm:ss"), msg);
            //Console.WriteLine();

            var log = new AppLog();
            log.LogContent = msg;
            log.post();
        }

        public override string getFileSplit()
        {
            return FtdLog.Split_ByDay;
        }

        /// <summary>
        /// 保留3天
        /// </summary>
        public override int getMaxFileCount()
        {
            return 1 * 7;
        }

        public override string getLogFileName()
        {
            return "AppLog.txt";
        }
    }
}
