using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace ftd.helper
{
    /// <summary>
    /// 簡訊Helper
    /// </summary>
    public static class SmsHelper
    {
        /// <summary>
        /// Every8d簡訊服務
        /// 回傳字傳為OK開始代表成功，其餘為失敗。
        /// </summary>
        public static string every8d_sendSmsMessage(string customer_id, string user_id, string user_pwd, string sms_number, string sms_txt)
        {
            var srv_security = new com.every8d.tw.Security();

            // 執行Login
            var ResultXml = srv_security.Login(customer_id, user_id, user_pwd, "", "");

            //分析回傳xml
            var doc = new XmlDocument();
            doc.LoadXml(ResultXml);
            var ErrorCode = doc.SelectSingleNode("/USER/ERROR_CODE").InnerText;

            if (ErrorCode != "0000")
            {
                return "登入失敗";                
            }

            var company_no = doc.SelectSingleNode("/USER/COMPANY_NO").InnerText;  //所屬公司代碼,簡訊發送時需傳入
            var user_no = doc.SelectSingleNode("/USER/USER_NO").InnerText;        //所屬使用者代碼,簡訊發送時需傳入
            var credit = Convert.ToDouble(doc.SelectSingleNode("/USER/CREDIT").InnerText); //目前點數餘額
            var sms_number_ii = sms_number;
            if (sms_number_ii.StartsWith("09"))
            {
                sms_number_ii = +886 + sms_number_ii.Substring(1);
            }

            var targetXml = "<REPS><IP/><CARD_NO/><USER NAME='' MOBILE='" + sms_number_ii + "' EMAIL='' SENDTIME='' PARAM=''/></REPS>";
            var srv_message = new com.every8d.tw1.Message();
            var result = srv_message.QueueIn(customer_id, company_no, user_no, "100", "10", "", sms_txt, "", "", targetXml, "", "");

            if (result.StartsWith("-"))
                return "傳送失敗。剩餘點數=" + credit;

            return "OK,傳送成功。剩餘點數=" + Convert.ToDouble(result.Split(',')[0]);
        }
    }
}
