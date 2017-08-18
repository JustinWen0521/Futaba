using System;
using System.Collections.Generic;
using System.Text;
using ftd.data.log;
using ftd.data;
using ftd.nsql;

namespace ftd.service
{
    public class AppLogService : FtdLogService
    {
        protected override void saveLog(FtdLog log)
        {
            base.saveLog(log);

            //if (log is FtdServiceLog)
            //{
            //    var log2 = log as FtdServiceLog;
            //    //服務例外追加到Table中
            //    if (log2.MessageType == FtdServiceLog.MessageType_Exception)
            //    {
            //        var dt = new WT_ServiceExceptionDataTable();
            //        var row = dt.newTypedRow();
            //        row.ns_AssingNewId();
            //        row.WTSE_RaiseDate = log2.LogDate;
            //        row.WTSE_Program = log2.ServiceName;
            //        row.WTSE_ExceptionMessage = log2.LogContent;
            //        dt.addTypedRow(row);
            //        dt.ns_update();
            //    }
            //}
        }
    }
}
