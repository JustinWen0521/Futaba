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
    /// 
    /// </summary>
    public interface EO_UserEventLog : INsTable
    {
        /// <summary>
        /// [DIRECT]*事件檔紀錄ID{UserEventLogId}：【PK&lt;EPUEL&gt;】
        /// </summary> 
        NsColumn EOUEL_UserEventLogId { get; }
        /// <summary>
        /// [DIRECT]*事件日期{EventDate:D}：【2007/11/12 13:14】
        /// </summary> 
        NsColumn EOUEL_EventDate { get; }
        /// <summary>
        /// [DIRECT]查看的物件Id{ObjectId }：【KEY】
        /// </summary> 
        NsColumn EOUEL_ObjectId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;*工作名稱{TaskName:50}：【資料回收程式】&lt;br/&gt;
        /// </summary> 
        NsColumn EOUEL_ObjectName_XX { get; }
        /// <summary>
        /// [DIRECT]來源IP{SourceId }：【168.95.1.1】
        /// </summary> 
        NsColumn EOUEL_SourceIP { get; }
        /// <summary>
        /// [DIRECT]*事件代碼{EventCode:50}：【KM_LOGIN】&lt;br/&gt;
        /// </summary> 
        NsColumn EOUEL_UserEventCode_XX { get; }
        /// <summary>
        /// [DIRECT]*事件Id{UserEventId}：【KEY&lt;EPUE&gt;】
        /// </summary> 
        NsColumn EOUEL_UserEventId { get; }
        /// <summary>
        /// [DIRECT]*事件類型{KindName:50}：【登入系統】&lt;br/&gt;
        /// </summary> 
        NsColumn EOUEL_UserEventName_XX { get; }
        /// <summary>
        /// [DIRECT]*人員{UserId}：【KEY&lt;EOE,ENM,KCG&gt;】
        /// </summary> 
        NsColumn EOUEL_UserId { get; }
        /// <summary>
        /// [DIRECT]#完整姓名{EmployeeFullName_XX}：【市政府-林勝文 組長】&lt;br/&gt;
        /// </summary> 
        NsColumn EOUEL_UserName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_UserEventLogNsTable : NsTable, EO_UserEventLog
        {
            public NsColumn EOUEL_UserEventLogId
            {
                  get { return this["EOUEL_UserEventLogId"]; }
            }
            public NsColumn EOUEL_EventDate
            {
                  get { return this["EOUEL_EventDate"]; }
            }
            public NsColumn EOUEL_ObjectId
            {
                  get { return this["EOUEL_ObjectId"]; }
            }
            public NsColumn EOUEL_ObjectName_XX
            {
                  get { return this["EOUEL_ObjectName_XX"]; }
            }
            public NsColumn EOUEL_SourceIP
            {
                  get { return this["EOUEL_SourceIP"]; }
            }
            public NsColumn EOUEL_UserEventCode_XX
            {
                  get { return this["EOUEL_UserEventCode_XX"]; }
            }
            public NsColumn EOUEL_UserEventId
            {
                  get { return this["EOUEL_UserEventId"]; }
            }
            public NsColumn EOUEL_UserEventName_XX
            {
                  get { return this["EOUEL_UserEventName_XX"]; }
            }
            public NsColumn EOUEL_UserId
            {
                  get { return this["EOUEL_UserId"]; }
            }
            public NsColumn EOUEL_UserName_XX
            {
                  get { return this["EOUEL_UserName_XX"]; }
            }
        }
    }
}
