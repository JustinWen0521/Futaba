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
    /// &lt;WTST&gt;訂單{ScheduleTask}
    /// </summary>
    public interface ZZ_Order : INsTable
    {
        /// <summary>
        /// [DIRECT]*訂單ID {DTN_NID}：【PK&lt;ZZO&gt;】
        /// </summary> 
        NsColumn ZZO_OrderId { get; }
        /// <summary>
        /// [DIRECT]*建立日期(DTN_DATETIME_19)：【】
        /// </summary> 
        NsColumn ZZO_CreateDate { get; }
        /// <summary>
        /// [DIRECT]*建立者ID(DTN_NID)：【】
        /// </summary> 
        NsColumn ZZO_CreatorId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn ZZO_CreatorName_XX { get; }
        /// <summary>
        /// [DIRECT]*訂單日期{DTN_NVARCHAR50}：【Note7炸彈一支】
        /// </summary> 
        NsColumn ZZO_Date { get; }
        /// <summary>
        /// [DIRECT]*訂單說明{DTN_NVARCHAR50}：【Note7炸彈一支】
        /// </summary> 
        NsColumn ZZO_Desc { get; }
        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR1}：【Y：啟用 / N：不啟用】
        /// </summary> 
        NsColumn ZZO_IsEnable { get; }
        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR10}：【Y：啟用 / N：不啟用】
        /// </summary> 
        NsColumn ZZO_IsEnableName_XX { get; }
        /// <summary>
        /// *訂單總金額{DTN_INTEGER}：【2008/04/01 12:30:40】
        /// </summary> 
        NsColumn ZZO_OrderAmount_XX { get; }
        /// <summary>
        /// [DIRECT]*訂單號碼{DTN_NVARCHAR10}：【20161022001】
        /// </summary> 
        NsColumn ZZO_OrderNo { get; }
        /// <summary>
        /// [DIRECT]*異動日期(DTN_DATETIME_19)：【】
        /// </summary> 
        NsColumn ZZO_UpdateDate { get; }
        /// <summary>
        /// [DIRECT]*異動者ID(DTN_NID)：【】
        /// </summary> 
        NsColumn ZZO_UpdaterId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn ZZO_UpdaterName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class ZZ_OrderNsTable : NsTable, ZZ_Order
        {
            public NsColumn ZZO_OrderId
            {
                  get { return this["ZZO_OrderId"]; }
            }
            public NsColumn ZZO_CreateDate
            {
                  get { return this["ZZO_CreateDate"]; }
            }
            public NsColumn ZZO_CreatorId
            {
                  get { return this["ZZO_CreatorId"]; }
            }
            public NsColumn ZZO_CreatorName_XX
            {
                  get { return this["ZZO_CreatorName_XX"]; }
            }
            public NsColumn ZZO_Date
            {
                  get { return this["ZZO_Date"]; }
            }
            public NsColumn ZZO_Desc
            {
                  get { return this["ZZO_Desc"]; }
            }
            public NsColumn ZZO_IsEnable
            {
                  get { return this["ZZO_IsEnable"]; }
            }
            public NsColumn ZZO_IsEnableName_XX
            {
                  get { return this["ZZO_IsEnableName_XX"]; }
            }
            public NsColumn ZZO_OrderAmount_XX
            {
                  get { return this["ZZO_OrderAmount_XX"]; }
            }
            public NsColumn ZZO_OrderNo
            {
                  get { return this["ZZO_OrderNo"]; }
            }
            public NsColumn ZZO_UpdateDate
            {
                  get { return this["ZZO_UpdateDate"]; }
            }
            public NsColumn ZZO_UpdaterId
            {
                  get { return this["ZZO_UpdaterId"]; }
            }
            public NsColumn ZZO_UpdaterName_XX
            {
                  get { return this["ZZO_UpdaterName_XX"]; }
            }
        }
    }
}
