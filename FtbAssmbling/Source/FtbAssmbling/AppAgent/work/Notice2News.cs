using System;
using System.Runtime.CompilerServices;
using System.Threading;
using ftd.service;
using System.IO;
using ftd.nsql;
using ftd.data;
using System.Data;
using ftd.dataaccess;

namespace ftd.agent.work
{
    class Notice2News
    {
        public Notice2News()
        {
        }

        public void doWork()
        {
            string errorMsg = string.Empty;
            SY_NewsDataTable dtNews = new SY_NewsDataTable();
            SY_NewsObjectDataTable dtNewsObject = new SY_NewsObjectDataTable();
            AppAgentLog.writeLog(string.Format("排程開始同步資料[{0}] : {1}", "", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss")));
            DateTime DT = DateTime.Now;

            try
            {
                var dtNotice2 = NsDmHelper.SY_Notice2
                    .selectAll(t => t.AllPhysical)
                    .where(t =>
                          t.SYN2_NewsId == null
                        & t.SYN2_StartTime.tostring(NsDataFormat.DATE_YYYYMMDD) == Convert.ToDateTime(DT).ToString("yyyyMMdd")
                    )
                    .query();

                if (dtNotice2 != null && dtNotice2.Rows.Count > 0)
                {
                    var drNotice2 = dtNotice2.FirstRow;
                    string year = drNotice2.SYN2_Year;
                    string season = drNotice2.SYN2_Season;
                    string strDT = string.Empty;

                    var dtReportMaster = NsDmHelper.PP_ReportMaster
                        .selectAll(t => t.AllPhysical)
                        .where(t =>
                            t.PPRM_Year == year & t.PPRM_Season == season
                            & t.PPRM_ReportDate == null // 尚未送件
                        )
                        .query();

                    #region //有需要公告對象時產生
                    if (dtReportMaster != null && dtReportMaster.Rows.Count > 0)
                    {
                        #region //公告增加一筆
                        var drNews = dtNews.newTypedRow();
                        drNews.ns_AssignNewId();
                        drNews.SYN_Type = "B";
                        if (!string.IsNullOrEmpty(drNotice2.SYN2_StartTime))
                            strDT = (Convert.ToInt32(drNotice2.SYN2_StartTime.Substring(0, 3)) + 1911).ToString() + "/" + drNotice2.SYN2_StartTime.Substring(3, 2).PadLeft(2, '0') + "/" + drNotice2.SYN2_StartTime.Substring(5, 2).PadLeft(2, '0');
                        drNews.SYN_StartTime = Convert.ToDateTime(strDT);
                        if (!string.IsNullOrEmpty(drNotice2.SYN2_EndTime))
                            strDT = (Convert.ToInt32(drNotice2.SYN2_EndTime.Substring(0, 3)) + 1911).ToString() + "/" + drNotice2.SYN2_EndTime.Substring(3, 2).PadLeft(2, '0') + "/" + drNotice2.SYN2_EndTime.Substring(5, 2).PadLeft(2, '0');
                        drNews.SYN_EndTime = Convert.ToDateTime(strDT);
                        drNews.SYN_Subject = drNotice2.SYN2_Subject;
                        drNews.SYN_Message = drNotice2.SYN2_Content;
                        dtNews.addTypedRow(drNews);
                        #endregion

                        #region //公告明細增加多筆
                        string newsid = drNews.SYN_NewsId;
                        foreach (var dr in dtReportMaster.TypeRows)
                        {
                            var drNewsObject = dtNewsObject.newTypedRow();
                            drNewsObject.ns_AssignNewId();
                            drNewsObject.SYNO_NewsId = newsid;
                            drNewsObject.SYNO_ObjectId = dr.PPRM_ManageOrgId;
                            dtNewsObject.addTypedRow(drNewsObject);
                        }
                        #endregion

                        drNotice2.SYN2_NewsId = newsid;
                    }
                    #endregion

                    //確認無誤一起更新
                    var scope = new FdbTransScope(FdbTransScopeOption.RequiresNew);
                    using (scope.Use)
                    {
                        drNotice2.ns_update();
                        dtNews.ns_update();
                        dtNewsObject.ns_update();
                        scope.complete();
                        drNotice2.AcceptChanges();
                        dtNews.AcceptChanges();
                        dtNewsObject.AcceptChanges();
                    }
                }

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
