using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using ftd.dataaccess;
using ftd.data;
using ftd.service;
using ftd.nsql;

namespace ftd.web
{
    public static class EoUserEventHelper
    {
        #region [事件類型]
        /// <summary>
        /// 設定事件類型
        /// </summary>
        [AttributeUsage(AttributeTargets.Class)]
        public class EventAttribute : Attribute
        {            
            public EventAttribute(string eventCode) : this(eventCode, false)
            {                
            }

            public EventAttribute(string eventCode, bool isObjectIdNeed)
            {
                EventCode = eventCode;
                IsObjectIdNeed = isObjectIdNeed;
            }

            /// <summary>
            /// 事件代碼
            /// </summary>
            public string EventCode;
            /// <summary>
            /// 是否需要指定事件物件(default false)
            /// </summary>
            public bool IsObjectIdNeed;
        }
        #endregion        

        /// <summary>
        /// 使用者最後一次的事件代碼(Must考量Session_OnEnd事件)
        /// </summary>
        private static string LastEventCode
        {
            get 
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                return (string)HttpContext.Current.Session["AppUserEventHelper.LastEventCode"]; 
            }
            set 
            {
                if (HttpContext.Current == null)
                    return;
                HttpContext.Current.Session["AppUserEventHelper.LastEventCode"] = value; 
            }
        }      

        /// <summary>
        /// 紀錄事件
        /// </summary>
        public static void logEvent(string eventCode, string userId, string objectId)
        {
            var qry = new NsDmQuery();
            {
                var t1 = qry.from<EO_UserEvent>();
                qry.Where = t1.EOUE_EventCode == eventCode.toConstReq1();
            }
            var row = qry.queryData<EO_UserEventDataTable>().FirstRow;

            //不存在自動新增
            {
                if (row == null)
                {
                    var dt = new EO_UserEventDataTable();
                    row = dt.newTypedRow();
                    row.ns_AssignNewId();

                    row.EOUE_Description = string.Empty;
                    row.EOUE_EventCode = eventCode;
                    row.EOUE_KindName = eventCode;
                    row.EOUE_ListOrder = 1;
                    dt.addTypedRow(row);
                    dt.ns_update();
                    dt.AcceptChanges();
                }
            }

            ////不重複才新增
            //if (LastEventCode == eventCode + "_" + objectId)
            //    return;

            //新增此事件
            {
                var sourceIP = getSourceIP();
                var dt2 = new EO_UserEventLogDataTable();
                var row2 = dt2.newTypedRow();
                row2.ns_AssignNewId();
                row2.EOUEL_EventDate = DateTime.Now;
                row2.EOUEL_UserEventId = row.EOUE_UserEventId;
                row2.EOUEL_UserId = userId;
                row2.EOUEL_ObjectId = objectId;
                row2.EOUEL_SourceIP = sourceIP;
                dt2.addTypedRow(row2);
                dt2.ns_update();
            }

            //LastEventCode = eventCode + "_" + objectId;
        }

        //取得遠端IP，需考慮使用者透過proxy連線
        private static string getSourceIP()
        {
            var ctx = HttpContext.Current;
            if (ctx == null)
                return string.Empty;

            string ip = "";

            try
            {
                //Client 可能透過 prosy
                string requestFrom = ctx.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

                if (requestFrom.isNullOrEmpty() || requestFrom.indexOf("unknown") > 0)
                {
                    ip = ctx.Request.ServerVariables["REMOTE_ADDR"];
                }
                else if (requestFrom.indexOf(",") > 0)
                {
                    ip = requestFrom.Substring(0, requestFrom.indexOf(","));
                }
                else if (requestFrom.indexOf(";") > 0)
                {
                    ip = requestFrom.Substring(0, requestFrom.indexOf(";"));
                }
                else
                {
                    ip = requestFrom;
                }
            }
            catch //(Exception ex)
            {
            }
            return ip;
        }
    }    
}
