using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using ftd.service;

namespace ftd.data.log
{
    public class PerformanceLog : FtdLog
    {
        #region [Static]
        /// <summary>
        /// 執行緒的LogCallLevel
        /// </summary>
        private static int CallLogLevel
        {
            get
            {
                return 0;
            }
            set { }
        }

        /// <summary>
        /// 增加紀錄階層
        /// </summary>
        public static void incLogLevel()
        {
        }

        /// <summary>
        /// 減少紀錄階層
        /// </summary>
        public static void decLogLevel()
        {
        }
        #endregion

        /// <summary>
        /// 本紀錄的階層 0....N
        /// </summary>
        private int LogLevel = 0;

        private int ThreadCode;

        /// <summary>
        /// Constructor
        /// </summary>
        public PerformanceLog()
            : base()
        {
            LogLevel = CallLogLevel;
            ThreadCode = Thread.CurrentThread.GetHashCode();
            IsEnabled = bool.Parse(FtdConfigService.Instance.getAppSettingValue(this.GetType().Name + ".IsLogEnable", "false"));
        }

        public override string getFileSplit()
        {
            return FtdLog.Split_ByHour;
        }

        /// <summary>
        /// 保留3天
        /// </summary>
        public override int getMaxFileCount()
        {
            return 24 * 3;
        }

        public override string getLogFileName()
        {
            return "PerformanceLog.txt";
        }

        public override void render(StreamWriter sw)
        {
            //縮排階層
            var identLevel = LogLevel > 1 ? LogLevel - 1 : 0;

            if (identLevel == 0)
            {
                sw.WriteLine("--執行緒{1} 日期 {0}", LogDate.ToString("yyyy/MM/dd HH:mm:ss.fff", CultureInfo.InvariantCulture), ThreadCode);
                sw.Write(LogContent);
                sw.WriteLine();
            }
            else
            {
                var sb = new StringBuilder();
                for (var i = 0; i < identLevel; i++)
                    sb.Append("\t");
                var tabstr = sb.ToString();
                sb.Length = 0;
                sb.AppendLine("--" + "".PadLeft(identLevel, '＞'));
                sb.AppendFormat("--執行緒{1} 日期 {0}", LogDate.ToString("yyyy/MM/dd HH:mm:ss.fff", CultureInfo.InvariantCulture), ThreadCode);
                sb.AppendLine();
                sb.Append(LogContent);
                sb.AppendLine();
                var lines = sb.ToString().Replace("\r\n", "\n").Split('\n');
                sb.Length = 0;
                lines.forEach(x => { sb.Append(tabstr); sb.Append(x); sb.AppendLine(); });
                sw.Write(sb.ToString());
            }
        }
    }
}
