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
    /// &lt;ZZOD&gt;訂單明細{ZZ_OrderDetail}
    /// </summary>
    public interface ZZ_OrderDetail : INsTable
    {
        /// <summary>
        /// [DIRECT]*訂單明細ID {DTN_NID}：【PK&lt;ZZO&gt;】
        /// </summary> 
        NsColumn ZZOD_OrderDetailId { get; }
        /// <summary>
        /// [DIRECT]*金額{DTN_INTEGER}：【299】
        /// </summary> 
        NsColumn ZZOD_Amount_XX { get; }
        /// <summary>
        /// [DIRECT]*建立日期(DTN_DATETIME_19)：【】
        /// </summary> 
        NsColumn ZZOD_CreateDate { get; }
        /// <summary>
        /// [DIRECT]*建立者ID(DTN_NID)：【】
        /// </summary> 
        NsColumn ZZOD_CreatorId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn ZZOD_CreatorName_XX { get; }
        /// <summary>
        /// [DIRECT]*品項{DTN_NVARCHAR20}：【滑鼠】
        /// </summary> 
        NsColumn ZZOD_Item { get; }
        /// <summary>
        /// [DIRECT]*訂單說明{DTN_NVARCHAR50}：【Note7炸彈一支】&lt;br/&gt;
        /// </summary> 
        NsColumn ZZOD_OrderDate_XX { get; }
        /// <summary>
        /// [DIRECT]*訂單說明{DTN_NVARCHAR50}：【Note7炸彈一支】&lt;br/&gt;
        /// </summary> 
        NsColumn ZZOD_OrderDesc_XX { get; }
        /// <summary>
        /// [DIRECT]*訂單ID {DTN_NID}：【PK&lt;ZZO&gt;】
        /// </summary> 
        NsColumn ZZOD_OrderId { get; }
        /// <summary>
        /// [DIRECT]*訂單號碼{DTN_NVARCHAR10}：【20161022001】&lt;br/&gt;
        /// </summary> 
        NsColumn ZZOD_OrderNo_XX { get; }
        /// <summary>
        /// [DIRECT]*數量{DTN_INTEGER}：【1】
        /// </summary> 
        NsColumn ZZOD_Qty { get; }
        /// <summary>
        /// [DIRECT]*單價{DTN_INTEGER}：【1】
        /// </summary> 
        NsColumn ZZOD_UnitPrice { get; }
        /// <summary>
        /// [DIRECT]*異動日期(DTN_DATETIME_19)：【】
        /// </summary> 
        NsColumn ZZOD_UpdateDate { get; }
        /// <summary>
        /// [DIRECT]*異動者ID(DTN_NID)：【】
        /// </summary> 
        NsColumn ZZOD_UpdaterId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn ZZOD_UpdaterName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class ZZ_OrderDetailNsTable : NsTable, ZZ_OrderDetail
        {
            public NsColumn ZZOD_OrderDetailId
            {
                  get { return this["ZZOD_OrderDetailId"]; }
            }
            public NsColumn ZZOD_Amount_XX
            {
                  get { return this["ZZOD_Amount_XX"]; }
            }
            public NsColumn ZZOD_CreateDate
            {
                  get { return this["ZZOD_CreateDate"]; }
            }
            public NsColumn ZZOD_CreatorId
            {
                  get { return this["ZZOD_CreatorId"]; }
            }
            public NsColumn ZZOD_CreatorName_XX
            {
                  get { return this["ZZOD_CreatorName_XX"]; }
            }
            public NsColumn ZZOD_Item
            {
                  get { return this["ZZOD_Item"]; }
            }
            public NsColumn ZZOD_OrderDate_XX
            {
                  get { return this["ZZOD_OrderDate_XX"]; }
            }
            public NsColumn ZZOD_OrderDesc_XX
            {
                  get { return this["ZZOD_OrderDesc_XX"]; }
            }
            public NsColumn ZZOD_OrderId
            {
                  get { return this["ZZOD_OrderId"]; }
            }
            public NsColumn ZZOD_OrderNo_XX
            {
                  get { return this["ZZOD_OrderNo_XX"]; }
            }
            public NsColumn ZZOD_Qty
            {
                  get { return this["ZZOD_Qty"]; }
            }
            public NsColumn ZZOD_UnitPrice
            {
                  get { return this["ZZOD_UnitPrice"]; }
            }
            public NsColumn ZZOD_UpdateDate
            {
                  get { return this["ZZOD_UpdateDate"]; }
            }
            public NsColumn ZZOD_UpdaterId
            {
                  get { return this["ZZOD_UpdaterId"]; }
            }
            public NsColumn ZZOD_UpdaterName_XX
            {
                  get { return this["ZZOD_UpdaterName_XX"]; }
            }
        }
    }
}
