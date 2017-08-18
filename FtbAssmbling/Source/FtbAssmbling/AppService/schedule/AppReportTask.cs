using System;
using System.Collections.Generic;
using System.Text;
using ftd.thread;
using ftd.data.schedule;
using System.Threading;
using ftd.service;
using ftd.nsql;
using System.Linq;
using System.Web.Script.Serialization;
using System.IO;
using System.Data;

namespace ftd.data.schedule
{
    public class AppReportTask : FtdScheduleTask
    {
        public override void scheduleMain(ThreadStart doEvent)
        {
            ////找出還沒列印的Report
            //var dtService = NsDmHelper.WT_ReportDefine.query();//queryTasks();

            //var dt = NsDmHelper.SY_Report.where(t =>( t.SYR_Remark != "OK"
            //    | t.SYR_Remark==null)
            //    ).query();
            ////string path = System.IO.Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "bin");
            
            //foreach (var dr in dt)
            //{
            //    try
            //    {
            //        JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            //        string cond = dr.SYR_Condition;
            //        report.model.FtbReportModel parm = json_serializer.Deserialize<report.model.FtbReportModel>(cond);
            //        string ctype = dr.SYR_Format;
            //        string msg = "";
                    
            //        //byte[] data = UL001ReportService.Instance.UML001r(parm, ref ctype);
            //        //File.WriteAllBytes(System.AppDomain.CurrentDomain.BaseDirectory + "/" + dr.SYR_Code + "." + dr.SYR_Format, data);
                    
            //        // msg = UL001ReportService.Instance.processReport(parm);
            //        var rowTask = dtService.Where(t => t.WTRD_ReportName == dr.SYR_Code).FirstOrDefault();
            //        if (rowTask != null)
            //        {
            //            var ser = AppReportService.Instance.deserializeService(rowTask);
            //            msg = ser.processReport2(parm,cond);
            //            dr.SYR_Remark = msg;
            //        }
            //    }
            //    catch{
            //    };
            //}
            //dt.ns_update();
        }      
    }
}
