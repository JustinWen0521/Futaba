using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using ftd.data;
using ftd.data.model.tag;
using ftd.nsql;
using ftd.query.model;
using ftd.service;

namespace ftd.service
{
    /// <summary>
    /// 
    /// </summary>
    public class WtDataService : FtdServiceBase
    {
        public static readonly WtDataService Instance;

        static WtDataService()
        {
            FtdCreatorService.Instance.createObject<WtDataService>(ref Instance);
        }

        #region [WT_ScheduleTask]
        public WT_ScheduleTaskDataTable WtScheduleTask_getList(WtScheduleTaskQryModel qm)
        {
            var dt = NsDmHelper.WT_ScheduleTask
                .selectAll(t => t.AllExt)
                .where(t =>
                    t.WTST_IsEnable == qm.Q_IsEnable.toConstOpt1()
                    & t.WTST_ExecuteState == qm.Q_ExecuteState.toConstOpt1()
                    & t.WTST_TaskName.contains(qm.Q_TaskName.toConstOpt1())
                )
                .query();

            return dt;
        }

        public WT_ScheduleTaskDataTable WtScheduleTask_create(int rowCount = 1)
        {
            var dt = new WT_ScheduleTaskDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public WT_ScheduleTaskDataTable WtScheduleTask_getById(string id)
        {
            var row = NsDmHelper.WT_ScheduleTask
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public bool WtScheduleTask_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.WT_ScheduleTask
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

        #region [WT_ScheduleDate]
        public WT_ScheduleDateDataTable WtScheduleDate_getList(WtScheduleTaskQryModel qm)
        {
            var dt = NsDmHelper.WT_ScheduleDate
                .selectAll(t => t.AllExt)
                .where(t => 
                    t.WTSD_ScheduleTaskId == qm.Q_ScheduleTaskId.toConstReq1()
                    & t.WTSD_IsEnable == qm.Q_IsEnable.toConstOpt1()
                )
                .query();

            return dt;
        }

        public WT_ScheduleDateDataTable WtScheduleDate_getListByTaskId(string taskId)
        {
            var row = NsDmHelper.WT_ScheduleDate
                .selectAll(t => t.AllExt)
                .where(t => t.WTSD_ScheduleTaskId == taskId.toConstReq1())
                .query();

            return row;
        }

        public WT_ScheduleDateDataTable WtScheduleDate_create(int rowCount = 1)
        {
            var dt = new WT_ScheduleDateDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                dt.addTypedRow(row);
            }
            return dt;
        }

        public WT_ScheduleDateDataTable WtScheduleDate_createWithTaskId(string taskId, int rowCount = 1)
        {
            var dt = new WT_ScheduleDateDataTable();
            if (rowCount < 0)
                rowCount = 0;

            for (int i = 0; i < rowCount; i++)
            {
                var row = dt.newTypedRow();
                row.ns_AssignNewId();
                row.WTSD_ScheduleTaskId = taskId;
                dt.addTypedRow(row);
            }
            return dt;
        }

        public WT_ScheduleDateDataTable WtScheduleDate_getById(string id)
        {
            var row = NsDmHelper.WT_ScheduleDate
                .selectAll(t => t.AllExt)
                .wherepk(id)
                .query();

            return row;
        }

        public bool WtScheduleDate_deleteBatch(string[] ids)
        {
            var dt = NsDmHelper.WT_ScheduleDate
                .wherepks(ids)
                .query();

            if (dt == null || dt.Count == 0)
                return false;

            foreach (var row in dt)
            {
                row.Delete();
            }
            dt.ns_update();
            return true;
        }
        #endregion

        #region [WT_ReportDefine]
        //public WT_ReportDefineDataTable WtReportDefine_getList(string ReportName)
        //{
        //    var dt = NsDmHelper.WT_ReportDefine
        //        .selectAll(t => t.AllExt)
        //        .where(t =>t.WTRD_ReportName == ReportName.toConstOpt1())
        //        .query();
        //    return dt;
        //}

        //public WT_ReportDefineDataTable WtReportDefine_getList(string[] ids)
        //{
        //    var dt = NsDmHelper.WT_ReportDefine
        //        .selectAll(t => t.AllPhysical)
        //        .where(t => t.WTRD_ReportDefineId.batchin(ids.toConstReq1()))
        //        .query();
        //    return dt;
        //}

        //public WT_ReportDefineDataTable WtReportDefine_getById(string id)
        //{
        //    var row = NsDmHelper.WT_ReportDefine
        //        .selectAll(t => t.AllExt)
        //        .wherepk(id)
        //        .query();

        //    return row;
        //}

        //public bool UlAddProof_checkDuplicate(string id, String ReportName)
        //{
        //    var row = NsDmHelper.WT_ReportDefine
        //        .where(t =>
        //            t.WTRD_ReportDefineId != id.toConstReq1()
        //            & t.WTRD_ReportName == ReportName.Trim().toConstReq1()
        //        )
        //        .queryFirst();

        //    return (row != null);
        //}
        #endregion
    }
}
