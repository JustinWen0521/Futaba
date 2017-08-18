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
    /// &lt;CRC&gt;課程{Course}
    /// </summary>
    public interface CR_Course : INsTable
    {
        /// <summary>
        /// [DIRECT]*課程ID{DTN_NID}：【PK&lt;CRC&gt;】
        /// </summary> 
        NsColumn CRC_CourseId { get; }
        /// <summary>
        /// [DIRECT]*課程代號{DTN_NVARCHAR10}：【10410001】
        /// </summary> 
        NsColumn CRC_Code { get; }
        /// <summary>
        /// [DIRECT]*建立日期(DTN_DATETIME_19)：【】
        /// </summary> 
        NsColumn CRC_CreateDate { get; }
        /// <summary>
        /// [DIRECT]*建立者ID(DTN_NID)：【】
        /// </summary> 
        NsColumn CRC_CreatorId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn CRC_CreatorName_XX { get; }
        /// <summary>
        /// [DIRECT]*課程描述{DTN_NVARCHAR200}：【】
        /// </summary> 
        NsColumn CRC_Description { get; }
        /// <summary>
        /// [DIRECT]*課程結束日期{DTN_NVARCHAR10}：【1041031】
        /// </summary> 
        NsColumn CRC_EndDate { get; }
        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR1}：【Y：是 / N：否】
        /// </summary> 
        NsColumn CRC_IsEnable { get; }
        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR10}：【Y：是 / N：否】
        /// </summary> 
        NsColumn CRC_IsEnableName_XX { get; }
        /// <summary>
        /// [DIRECT]*課程名稱{DTN_NVARCHAR50}：【】
        /// </summary> 
        NsColumn CRC_Name { get; }
        /// <summary>
        /// [DIRECT]*報名結束日期{DTN_NVARCHAR10}：【1041031】
        /// </summary> 
        NsColumn CRC_RegisterEndDate { get; }
        /// <summary>
        /// *已報名人數{RegisterQty_XX:D}：【30】
        /// </summary> 
        NsColumn CRC_RegisterQty_XX { get; }
        /// <summary>
        /// [DIRECT]*報名開始日期{DTN_NVARCHAR10}：【1041031】
        /// </summary> 
        NsColumn CRC_RegisterStartDate { get; }
        /// <summary>
        /// [DIRECT]*課程開始日期{DTN_NVARCHAR10}：【1041031】
        /// </summary> 
        NsColumn CRC_StartDate { get; }
        /// <summary>
        /// [DIRECT]*異動日期(DTN_DATETIME_19)：【】
        /// </summary> 
        NsColumn CRC_UpdateDate { get; }
        /// <summary>
        /// [DIRECT]*異動者ID(DTN_NID)：【】
        /// </summary> 
        NsColumn CRC_UpdaterId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn CRC_UpdaterName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class CR_CourseNsTable : NsTable, CR_Course
        {
            public NsColumn CRC_CourseId
            {
                  get { return this["CRC_CourseId"]; }
            }
            public NsColumn CRC_Code
            {
                  get { return this["CRC_Code"]; }
            }
            public NsColumn CRC_CreateDate
            {
                  get { return this["CRC_CreateDate"]; }
            }
            public NsColumn CRC_CreatorId
            {
                  get { return this["CRC_CreatorId"]; }
            }
            public NsColumn CRC_CreatorName_XX
            {
                  get { return this["CRC_CreatorName_XX"]; }
            }
            public NsColumn CRC_Description
            {
                  get { return this["CRC_Description"]; }
            }
            public NsColumn CRC_EndDate
            {
                  get { return this["CRC_EndDate"]; }
            }
            public NsColumn CRC_IsEnable
            {
                  get { return this["CRC_IsEnable"]; }
            }
            public NsColumn CRC_IsEnableName_XX
            {
                  get { return this["CRC_IsEnableName_XX"]; }
            }
            public NsColumn CRC_Name
            {
                  get { return this["CRC_Name"]; }
            }
            public NsColumn CRC_RegisterEndDate
            {
                  get { return this["CRC_RegisterEndDate"]; }
            }
            public NsColumn CRC_RegisterQty_XX
            {
                  get { return this["CRC_RegisterQty_XX"]; }
            }
            public NsColumn CRC_RegisterStartDate
            {
                  get { return this["CRC_RegisterStartDate"]; }
            }
            public NsColumn CRC_StartDate
            {
                  get { return this["CRC_StartDate"]; }
            }
            public NsColumn CRC_UpdateDate
            {
                  get { return this["CRC_UpdateDate"]; }
            }
            public NsColumn CRC_UpdaterId
            {
                  get { return this["CRC_UpdaterId"]; }
            }
            public NsColumn CRC_UpdaterName_XX
            {
                  get { return this["CRC_UpdaterName_XX"]; }
            }
        }
    }
}
