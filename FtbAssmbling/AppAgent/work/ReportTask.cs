using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Data;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using ftd.service;
using ftd.nsql;
using ftd.data;
using ftd.dataaccess;
using System.Web.Script.Serialization;
using ftd.query.model;

namespace ftd.agent.work
{
    public class ReportTask
    {
        public ReportTask()
        {
        }

        public void doWork()
        {
            AppAgentLog.writeLog(string.Format("報表排程[{0}]開始", GetType().Name));

            try
            {
                var dtRptTask = NsDmHelper.SY_ReportTask
                    .selectAll(t => t.AllExt)
                    .where(t =>
                        t.SYRT_TaskStatus == "N"
                        & (t.SYRT_ScheduleDate <= DateTime.Now | t.SYRT_ScheduleDate == null)
                    )
                    .orderby(t => new[]{
                        t.SYRT_ScheduleDate.Asc,
                        t.SYRT_CreateDate.Asc
                    })
                    .query();

                //KM Web Service
                var kmUrl = FtdConfigService.Instance.getAppSettingValue("URL_KMWS", "");
                if (kmUrl.isNullOrEmpty())
                {
                    AppAgentLog.writeLog("KM Web Service Invalid");
                    return;
                }

                var reportId = "";
                foreach (var task in dtRptTask)
                {
                    AppAgentLog.writeLog(string.Format("處理報表-開始, TaskId：{0}，ReportId：{1}", task.SYRT_ReportTaskId, task.SYRT_ReportId));
                    try
                    {
                        task.SYRT_ExecuteStartTime = DateTime.Now;

                        Type tService = Type.GetType(task.SYRT_ServiceClass_XX);
                        Type tModel = Type.GetType(task.SYRT_QueryModelClass_XX);

                        var rptService = Activator.CreateInstance(tService) as AppReportService;
                        var rptModel = Activator.CreateInstance(tModel) as AppQryModel;

                        JavaScriptSerializer json_serializer = new JavaScriptSerializer();
                        rptModel = json_serializer.Deserialize(task.SYRT_Conditions, tModel) as AppQryModel;

                        if (rptService == null || rptModel == null)
                        {
                            task.SYRT_ExecuteEndTime = DateTime.Now;
                            task.SYRT_TaskStatus = "F";
                            task.SYRT_ExecuteResult = "服務類別或參數類別定義錯誤";

                            task.ns_update();
                            dtRptTask.AcceptChanges();
                            continue;
                        }
                        
                        //處理中
                        task.SYRT_TaskStatus = "P";
                        task.ns_update();

                        reportId = rptModel.ReportId;
                        //產製報表
                        var rawData = rptService.processReport(rptModel);

                        //空值
                        if (rawData == null || rawData.Length == 0)
                        {
                            task.SYRT_ExecuteEndTime = DateTime.Now;
                            task.SYRT_TaskStatus = "Y";
                            task.SYRT_ExecuteResult = "無資料";

                            task.ns_update();
                            dtRptTask.AcceptChanges();
                            continue;
                        }

                        // Save to KM System
                        try
                        {
                            var kmWS = new KmWebService.AcceptFromFinance();
                            kmWS.Url = kmUrl;
                            kmWS.Timeout = 1000 * 60 * 10; //ms
                            var fileId = kmWS.UploadFile(task.SYRT_OrganId, task.SYRT_CreatorCode_XX, rptModel.ExportName, rawData);

                            task.SYRT_ExecuteEndTime = DateTime.Now;
                            task.SYRT_TaskStatus = "Y";
                            task.SYRT_ExecuteResult = "成功";
                            task.SYRT_FileId = fileId;
                        }
                        catch (Exception ex2)
                        {
                            task.SYRT_ExecuteEndTime = DateTime.Now;
                            task.SYRT_TaskStatus = "F";
                            task.SYRT_ExecuteResult = "存檔至 KM 失敗";
                            AppAgentLog.writeLog(string.Format("產製報表發生錯誤：存檔至 KM 失敗, ReportId:{0}\r\n{1}", reportId, ex2.ToString()));
                        }

                        task.ns_update();
                        dtRptTask.AcceptChanges();
                    }
                    catch (Exception ex1)
                    {
                        task.SYRT_ExecuteEndTime = DateTime.Now;
                        task.SYRT_TaskStatus = "F";
                        task.SYRT_ExecuteResult = "產製報表發生錯誤";

                        task.ns_update();
                        dtRptTask.AcceptChanges();

                        AppAgentLog.writeLog(string.Format("產製報表發生錯誤, ReportId:{0}\r\n{1}", reportId, ex1.ToString()));
                    }
                    finally
                    {
                        var timeSpan = task.SYRT_ExecuteEndTime.Value.Subtract(task.SYRT_ExecuteStartTime.Value);
                        AppAgentLog.writeLog(string.Format("處理報表-結束, TaskId：{0}，ReportId：{1}，耗時：{2}秒", task.SYRT_ReportTaskId, task.SYRT_ReportId, timeSpan.TotalSeconds));
                    }
                }
            }
            catch (Exception ex)
            {
                AppAgentLog.writeLog(string.Format("產製報表發生錯誤, \r\n{0}", ex.ToString()));
            }
            finally
            {
                AppAgentLog.writeLog(string.Format("報表排程[{0}]結束", GetType().Name));
                string split = new string('-', 50);
                AppAgentLog.writeLog(split);
            }
        }
    }
}
