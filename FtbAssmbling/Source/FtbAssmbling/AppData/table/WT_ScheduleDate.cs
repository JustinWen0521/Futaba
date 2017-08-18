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
    /// &lt;WTSD&gt;排程日期{ScheduleDate}
    /// </summary>
    public interface WT_ScheduleDate : INsTable
    {
        /// <summary>
        /// [DIRECT]*排程日期ID{ScheduleDateId}：【PK&lt;WTSD&gt;】
        /// </summary> 
        NsColumn WTSD_ScheduleDateId { get; }
        /// <summary>
        /// [DIRECT]*日期描述{Description:50}：【每天06:30分執行】
        /// </summary> 
        NsColumn WTSD_Description { get; }
        /// <summary>
        /// [DIRECT]*每天-小時{INT}：【0~24】
        /// </summary> 
        NsColumn WTSD_EveryDayHour { get; }
        /// <summary>
        /// [DIRECT]*每天-分鐘{INT}：【0~59】
        /// </summary> 
        NsColumn WTSD_EveryDayMiniute { get; }
        /// <summary>
        /// [DIRECT]*是否啟用{IsEnable:1,IsEnableName_XX}：Y：啟用 N：不啟用
        /// </summary> 
        NsColumn WTSD_IsEnable { get; }
        /// <summary>
        /// [DIRECT]*是否啟用{IsEnable:1,IsEnableName_XX}：Y：啟用 N：不啟用
        /// </summary> 
        NsColumn WTSD_IsEnableName_XX { get; }
        /// <summary>
        /// [DIRECT]超過排程日期{getCurrentScheduleTime()}多少分鐘，仍視為到期的。
        /// </summary> 
        NsColumn WTSD_MoreMinute { get; }
        /// <summary>
        /// [DIRECT]*物件參數{Parameters:4000}：【0ZW0sIFZlcnNpb249Mi4wLjAuMCwgQ3V==】
        /// </summary> 
        NsColumn WTSD_Parameters { get; }
        /// <summary>
        /// [DIRECT]*週期類型{1}：【A：每天 / B：每小時】
        /// </summary> 
        NsColumn WTSD_PeriodType { get; }
        /// <summary>
        /// [DIRECT]*排程工作ID{ScheduleTaskId}：【KEY&lt;WTST&gt;】
        /// </summary> 
        NsColumn WTSD_ScheduleTaskId { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class WT_ScheduleDateNsTable : NsTable, WT_ScheduleDate
        {
            public NsColumn WTSD_ScheduleDateId
            {
                  get { return this["WTSD_ScheduleDateId"]; }
            }
            public NsColumn WTSD_Description
            {
                  get { return this["WTSD_Description"]; }
            }
            public NsColumn WTSD_EveryDayHour
            {
                  get { return this["WTSD_EveryDayHour"]; }
            }
            public NsColumn WTSD_EveryDayMiniute
            {
                  get { return this["WTSD_EveryDayMiniute"]; }
            }
            public NsColumn WTSD_IsEnable
            {
                  get { return this["WTSD_IsEnable"]; }
            }
            public NsColumn WTSD_IsEnableName_XX
            {
                  get { return this["WTSD_IsEnableName_XX"]; }
            }
            public NsColumn WTSD_MoreMinute
            {
                  get { return this["WTSD_MoreMinute"]; }
            }
            public NsColumn WTSD_Parameters
            {
                  get { return this["WTSD_Parameters"]; }
            }
            public NsColumn WTSD_PeriodType
            {
                  get { return this["WTSD_PeriodType"]; }
            }
            public NsColumn WTSD_ScheduleTaskId
            {
                  get { return this["WTSD_ScheduleTaskId"]; }
            }
        }
    }
}
