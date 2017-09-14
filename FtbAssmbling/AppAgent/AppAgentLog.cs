using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ftd.data.log;
using ftd.service;

namespace ftd.agent
{
    class AppAgentLog : FtdLog
    {
        public AppAgentLog()
        {
            IsEnabled = bool.Parse(FtdConfigService.Instance.getAppSettingValue(this.GetType().Name + ".IsLogEnable", "true"));
        }

        /// <summary>
        /// Write Site Log
        /// </summary>       
        public static void writeLog(string log_txt)
        {
            Console.WriteLine("{0}:{1}", DateTime.Now.ToString("HH:mm:ss"), log_txt);
            //Console.WriteLine();

            var log = new AppAgentLog();
            log.LogContent = log_txt;
            log.post();
        }

        public override string getLogFileName()
        {
            return "AgentLog.txt";
        }

        /// <summary>
        /// 取得檔案分切類型(預設By日期)
        /// </summary>            
        public override string getFileSplit()
        {
            return Split_ByHour;
        }

        /// <summary>
        /// 保留檔案數量
        /// </summary>            
        public override int getMaxFileCount()
        {
            //保留10天，每小時一個檔案-->共240個檔案
            return 24 * 10;
        }
    }
}
