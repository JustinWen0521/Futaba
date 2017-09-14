using System;
using System.Runtime.CompilerServices;
using System.Threading;
using ftd.service;
using System.IO;
using ftd.nsql;
using ftd.data;
using System.Data;
using ftd.dataaccess;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace ftd.agent.work
{
    class MailTask
    {
        public MailTask()
        {
        }

        public void doWork()
        {
            string smtpHost = string.Empty;
            string smtpUserId = string.Empty;
            string smtpPasswd = string.Empty;
            string smtpSender = string.Empty;
            
            smtpHost = FtdConfigService.Instance.getAppSettingValue("SmtpHost");
            smtpUserId = FtdConfigService.Instance.getAppSettingValue("SmtpUserId");
            smtpPasswd = FtdConfigService.Instance.getAppSettingValue("SmtpPasswd");
            smtpSender = FtdConfigService.Instance.getAppSettingValue("SmtpSender");

            StringBuilder sb = new StringBuilder(); 
            string errorMsg = string.Empty;
            SY_NewsDataTable dtNews = new SY_NewsDataTable();
            SY_NewsObjectDataTable dtNewsObject = new SY_NewsObjectDataTable();
            AppAgentLog.writeLog(string.Format("排程開始同步資料[{0}] : {1}", "", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            DateTime DT = DateTime.Now;

            try
            {
                #region //查詢系統日之前未寄出的通知
                var dt = NsDmHelper.SY_MailList
                    .selectAll(t => t.AllPhysical)
                    .where(t => t.SYML_EventTime.tostring(NsDataFormat.DATE_YYYYMMDD) <= DateTime.Now.ToString("yyyyMMdd")
                        & t.SYML_IsSent == "N"
                        & t.SYML_NotifyWay == "A" 
                        & t.SYML_Target != null
                    ).query();

                foreach (var row in dt.TypeRows)
                {
                    string email = row.SYML_Target;
                    try
                    {
                        //信件內容控制 
                        StringBuilder sb1 = new StringBuilder();
                        string tBody = string.Empty;
                        sb1.Append("<font size=3 color=\"black\">" + row.SYML_Message + "</font><br>");
                        tBody = "<html><body><tr><td>" + sb1.ToString() + "</td></tr></body></html>";

                        MailMessage message = new MailMessage(smtpSender, email, row.SYML_MsgTypeName_XX, tBody);

                        message.IsBodyHtml = true;
                        SmtpClient client = new SmtpClient(smtpHost);
                        client.Credentials = new NetworkCredential(smtpUserId, smtpPasswd);
                        client.Send(message);

                        row.SYML_IsSent = "Y";
                        row.SYML_RealSentTime = DateTime.Now;

                        var scope = new FdbTransScope(FdbTransScopeOption.Required);
                        using (scope.Use)
                        {
                            dt.ns_update();
                            scope.complete();
                            dt.AcceptChanges();
                        }
                    }
                    catch (Exception e)
                    {
                        sb.Append("發送mail失敗, 訊息 : " + e.Message + Environment.NewLine);
                    }
                }
                #endregion
                
                AppAgentLog.writeLog(string.Format("完成同步資料[{0}] : {1}", GetType().Name, DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
                string split = new string('-', 30);
                AppAgentLog.writeLog(split);
            }
            catch (Exception ex)
            {
                AppAgentLog.writeLog(ex.Message);
            }
            finally
            {
            }
        }
    }
}
