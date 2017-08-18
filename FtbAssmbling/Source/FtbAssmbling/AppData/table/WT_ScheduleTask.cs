using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using ftd.nsql;
using ftd.service;
using ftd.data.nstable;
namespace ftd.data
{
    /// <summary>
    /// &lt;WTST&gt;排程工作{ScheduleTask}
    /// </summary>
    public interface WT_ScheduleTask : INsTable
    {
        /// <summary>
        /// [DIRECT]*排程工作ID{ScheduleTaskId}：【PK&lt;WTST&gt;】
        /// </summary> 
        NsColumn WTST_ScheduleTaskId { get; }
        /// <summary>
        /// [DIRECT]*工作描述{Descripton:200}：【回收暫存檔案資料】
        /// </summary> 
        NsColumn WTST_Description { get; }
        /// <summary>
        /// [DIRECT]*執行起始日期{ExecuteBeginDate:D}：【2008/04/01 12:30:40】
        /// </summary> 
        NsColumn WTST_ExecuteBeginDate { get; }
        /// <summary>
        /// [DIRECT]*執行結束日期{ExecuteEndDate:D}：【2008/04/01 12:30:50】
        /// </summary> 
        NsColumn WTST_ExecuteEndDate { get; }
        /// <summary>
        /// [DIRECT]*執行例外{ExecuteException:1000}：【資料庫無法開啟】
        /// </summary> 
        NsColumn WTST_ExecuteException { get; }
        /// <summary>
        /// #執行時間(秒){ExecuteSeconds_XX}：【10】
        /// </summary> 
        NsColumn WTST_ExecuteSeconds_XX { get; }
        /// <summary>
        /// [DIRECT]*執行結果{ExecuteState:1,ExecuteStateName_XX}：○{Name}成功 ○{Name_U}失敗
        /// </summary> 
        NsColumn WTST_ExecuteState { get; }
        /// <summary>
        /// [DIRECT]*執行結果{ExecuteState:1,ExecuteStateName_XX}：○{Name}成功 ○{Name_U}失敗
        /// </summary> 
        NsColumn WTST_ExecuteStateName_XX { get; }
        /// <summary>
        /// [DIRECT]*是否啟用{IsEnable:1,IsEnableName_XX}：○{Name}啟用 ○{Name_U}不啟用
        /// </summary> 
        NsColumn WTST_IsEnable { get; }
        /// <summary>
        /// [DIRECT]*是否啟用{IsEnable:1,IsEnableName_XX}：○{Name}啟用 ○{Name_U}不啟用
        /// </summary> 
        NsColumn WTST_IsEnableName_XX { get; }
        /// <summary>
        /// [DIRECT]*物件類型{ObjectTypeName:100}：【sys.service.HcCareScheduleNotifyTask,AppService】
        /// </summary> 
        NsColumn WTST_ObjectTypeName { get; }
        /// <summary>
        /// [DIRECT]*物件參數{Parameters:100}：【DAILYREPORT AreaId】
        /// </summary> 
        NsColumn WTST_Parameters { get; }
        /// <summary>
        /// [DIRECT]*工作名稱{TaskName:50}：【資料回收程式】
        /// </summary> 
        NsColumn WTST_TaskName { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class WT_ScheduleTaskNsTable : NsTable, WT_ScheduleTask
        {
            public NsColumn WTST_ScheduleTaskId
            {
                  get { return this["WTST_ScheduleTaskId"]; }
            }
            public NsColumn WTST_Description
            {
                  get { return this["WTST_Description"]; }
            }
            public NsColumn WTST_ExecuteBeginDate
            {
                  get { return this["WTST_ExecuteBeginDate"]; }
            }
            public NsColumn WTST_ExecuteEndDate
            {
                  get { return this["WTST_ExecuteEndDate"]; }
            }
            public NsColumn WTST_ExecuteException
            {
                  get { return this["WTST_ExecuteException"]; }
            }
            public NsColumn WTST_ExecuteSeconds_XX
            {
                  get { return this["WTST_ExecuteSeconds_XX"]; }
            }
            public NsColumn WTST_ExecuteState
            {
                  get { return this["WTST_ExecuteState"]; }
            }
            public NsColumn WTST_ExecuteStateName_XX
            {
                  get { return this["WTST_ExecuteStateName_XX"]; }
            }
            public NsColumn WTST_IsEnable
            {
                  get { return this["WTST_IsEnable"]; }
            }
            public NsColumn WTST_IsEnableName_XX
            {
                  get { return this["WTST_IsEnableName_XX"]; }
            }
            public NsColumn WTST_ObjectTypeName
            {
                  get { return this["WTST_ObjectTypeName"]; }
            }
            public NsColumn WTST_Parameters
            {
                  get { return this["WTST_Parameters"]; }
            }
            public NsColumn WTST_TaskName
            {
                  get { return this["WTST_TaskName"]; }
            }
        }
    }
}
