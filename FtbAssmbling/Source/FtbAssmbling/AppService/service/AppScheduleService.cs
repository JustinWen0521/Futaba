using System;
using System.Collections.Generic;
using System.Text;
using ftd.thread;
using System.Data;
using ftd.data;
using ftd.dataaccess;
using System.Collections.Specialized;
using ftd.nsql;
using ftd.web;

namespace ftd.service
{
    public class AppScheduleService : FtdScheduleService
    {
        protected override FtdScheduleTask deserializeTask(DataRow rowTask)
        {
            var rowTask2 = (WT_ScheduleTaskRow)rowTask;
            var type = Type.GetType(rowTask2.WTST_ObjectTypeName);
            var task = (FtdScheduleTask)type.GetConstructor(new Type[] { }).Invoke(new object[] { });
            task.Db_PrimaryKey = rowTask2.WTST_ScheduleTaskId;
            task.Db_IsEnable = (rowTask2.WTST_IsEnable == "Y");
            if (rowTask2 != null)
                task.Db_LastExecuteDate = rowTask2.WTST_ExecuteBeginDate;
            task.TaskTitle = rowTask2.WTST_TaskName;
            return task;
        }

        protected override FtdScheduleDate deserializeDate(DataRow rowDate)
        {
            var rowDate2 = rowDate as WT_ScheduleDateRow;
            var date = new FtdScheduleDate();
            date.Db_DbPrimaryKey = rowDate2.WTSD_ScheduleDateId;
            date.Db_IsEnable = (rowDate2.WTSD_IsEnable == "Y");
            var nv = FtdIoHelper.deSerializeFromString<NameValueCollection>(rowDate2.WTSD_Parameters);
            date.setParameters(nv);
            return date;
        }

        protected override DataTable queryTasks()
        {
            var qry = new NsDmQuery();
            qry.from<WT_ScheduleTask>();
            var dt = qry.queryData();
            return dt;
        }

        protected override DataTable queryDates(DataRow rowTask)
        {
            var rowTask2 = rowTask as WT_ScheduleTaskRow;
            var qry = new NsDmQuery();
            var t1 = qry.from<WT_ScheduleDate>();
            qry.Where = t1.WTSD_ScheduleTaskId == rowTask2.WTST_ScheduleTaskId.toConstReq1();
            var dt = qry.queryData();
            return dt;
        }

        protected override void saveTaskState(FtdScheduleTask task)
        {
            //取得之前的資料
            var rowTask = NsDmHelper.WT_ScheduleTask
                .wherepk(task.Db_PrimaryKey)
                .queryFirst();

            rowTask.WTST_ExecuteBeginDate = task.ExecuteBeginDate.Value;
            rowTask.WTST_ExecuteEndDate = task.ExecuteEndDate.Value;
            if (task.ServiceException == null)
            {
                rowTask.WTST_ExecuteException = string.Empty;
                rowTask.WTST_ExecuteState = "A";

                EoUserEventHelper.logEvent("WT_ScheduleTaskExecuted", "", task.Db_PrimaryKey);
            }
            else
            {
                rowTask.WTST_ExecuteException = task.ServiceException.ToString();
                rowTask.WTST_ExecuteState = "B";

                EoUserEventHelper.logEvent("WT_ScheduleTaskFailed", "", task.Db_PrimaryKey);
            }

            rowTask.ns_update();
        }
    }
}
