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
    /// &lt;EOUE&gt;網站使用者事件主檔{UserEvent}
    /// </summary>
    public interface EO_UserEvent : INsTable
    {
        /// <summary>
        /// [DIRECT]*事件ID{UserEventLogId}：【PK&lt;EPUE&gt;】
        /// </summary> 
        NsColumn EOUE_UserEventId { get; }
        /// <summary>
        /// [DIRECT]*事件描述{Description:100}：【使用者登入系統】
        /// </summary> 
        NsColumn EOUE_Description { get; }
        /// <summary>
        /// [DIRECT]*事件代碼{EventCode:50}：【KM_LOGIN】
        /// </summary> 
        NsColumn EOUE_EventCode { get; }
        /// <summary>
        /// [DIRECT]*事件類型{KindName:50}：【登入系統】
        /// </summary> 
        NsColumn EOUE_KindName { get; }
        /// <summary>
        /// [DIRECT]*列表順序 {ListOrder:INT}：【1】
        /// </summary> 
        NsColumn EOUE_ListOrder { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class EO_UserEventNsTable : NsTable, EO_UserEvent
        {
            public NsColumn EOUE_UserEventId
            {
                  get { return this["EOUE_UserEventId"]; }
            }
            public NsColumn EOUE_Description
            {
                  get { return this["EOUE_Description"]; }
            }
            public NsColumn EOUE_EventCode
            {
                  get { return this["EOUE_EventCode"]; }
            }
            public NsColumn EOUE_KindName
            {
                  get { return this["EOUE_KindName"]; }
            }
            public NsColumn EOUE_ListOrder
            {
                  get { return this["EOUE_ListOrder"]; }
            }
        }
    }
}
