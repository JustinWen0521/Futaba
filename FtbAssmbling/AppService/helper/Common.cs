using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ftd.helper
{
    public struct DateDifference
    {
        public int Years { get; set; }
        public int Months { get; set; }
        public int Days { get; set; }
    }

    public class Common
    {

        ///// <summary>
        ///// 計算兩個日期時間差
        ///// </summary>
        ///// <param name="date1"></param>
        ///// <param name="date2"></param>
        ///// <returns></returns>
        //public static Tuple<int, int, int> Cal2DateDifference_YMD(DateTime date1, DateTime date2)
        //{
        //    int years, months, days;
        //    // 因為只需取量，不決定誰大誰小，所以如果date1 < date2時要交換將大的擺前面
        //    if (date1 < date2)
        //    {
        //        DateTime tmp = date2;
        //        date2 = date1;
        //        date1 = tmp;
        //    }

        //    // 將年轉換成月份以便用來計算
        //    months = 12 * (date1.Year - date2.Year) + (date1.Month - date2.Month);

        //    // 如果天數要相減的量不夠時要向月份借天數補滿該月再來相減
        //    if (date1.Day < date2.Day)
        //    {
        //        months--;
        //        days = DateTime.DaysInMonth(date2.Year, date2.Month) - date2.Day + date1.Day;
        //    }
        //    else
        //    {
        //        days = date1.Day - date2.Day;
        //    }

        //    // 天數計算完成後將月份轉成年
        //    years = months / 12;
        //    months = months % 12;

        //    return Tuple.Create(years, months, days);
        //}

        /// <summary>
        /// 計算兩個日期時間差
        /// </summary>
        /// <param name="date1"></param>
        /// <param name="date2"></param>
        /// <returns></returns>
        //public static Tuple<int, int> Cal2DateDifference_YM(DateTime date1, DateTime date2)
        public static DateDifference Cal2DateDifference_YM(DateTime date1, DateTime date2)
        {
            int years, months;
            // 因為只需取量，不決定誰大誰小，所以如果date1 < date2時要交換將大的擺前面
            if (date1 < date2)
            {
                DateTime tmp = date2;
                date2 = date1;
                date1 = tmp;
            }

            years = date1.Year - date2.Year;
            months = date1.Month - date2.Month;

            if (months < 0)
            {
                years--;
                months += 12;
            }

            //return Tuple.Create(years, months);
            DateDifference diff = new DateDifference();
            diff.Years = years;
            diff.Months = months;
            diff.Days = 0;
            return diff;
        }

        ///// <summary>
        ///// 取得輸出格式
        ///// </summary>
        ///// <param name="contenttype">副檔名</param>
        ///// <returns></returns>
        //public static string GetPrintType(string contenttype)
        //{
        //    string print = "";
        //    switch (contenttype)
        //    {
        //        case "pdf":
        //            print = "PDF";
        //            break;
        //        case "xls":
        //        case "xlsx":
        //            print = "Excel";
        //            break;
        //        case "doc":
        //        case "docx":
        //            print = "Word";
        //            break;
        //        default:
        //            throw new Exception("不合法的Reporting Service輸出格式");
        //    }
        //    return print;
        //}

        /// <summary>
        /// 民國年字串轉其他格式 例:1040529
        /// <param name="formatKind">
        /// A：98年12月7日
        /// B：98/10/02
        /// C：中華民國102年09月28日
        /// D：10301
        /// </param>
        /// </summary>
        public static string toStrTwFormat(string theTw, string formatKind)
        {
            string strYear = "", strMonth = "", strDay = "";
            string format = "";

            if (theTw.Length < 7)
                throw new Exception(string.Format("不合法的輸出格式:{0} invalid.", theTw));

            strYear = theTw.Substring(0, 3);
            strMonth = theTw.Substring(3, 2);
            strDay = theTw.Substring(5, 2);

            switch (formatKind)
            {
                case "A":
                    format = "{0}年{1:00}月{2:00}日";
                    break;
                case "B":
                    format = "{0}/{1:00}/{2:00}";
                    break;
                case "C":
                    format = "中華民國{0}年{1:00}月{2:00}日";
                    break;
                case "D":
                    format = "{0}{1:00}";
                    break;
                default:
                    throw new NotImplementedException(string.Format("Format:{0} invalid.", formatKind));
            }
            return string.Format(format, strYear, strMonth, strDay);
        }

        /// <summary>
        /// 民國年字串轉日期型態 例:1040529
        /// </summary>
        /// <param name="theTw"></param>
        /// <returns></returns>
        public static DateTime toTwDate(string theTw)
        {
            return DateTime.Parse(toStrTwFormat(theTw,"B"));
        }
    }
}
