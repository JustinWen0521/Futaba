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
    /// &lt;CRCL&gt;班別{Class}
    /// </summary>
    public interface CR_Class : INsTable
    {
        /// <summary>
        /// [DIRECT]*班別ID{DTN_NID}：【PK&lt;CRCL&gt;】
        /// </summary> 
        NsColumn CRCL_ClassId { get; }
        /// <summary>
        /// [DIRECT]*地址{DTN_NVARCHAR100}：【高雄市苓雅區四維三路2號8樓】
        /// </summary> 
        NsColumn CRCL_Address { get; }
        /// <summary>
        /// [DIRECT]*開班日期{DTN_NVARCHAR10}：【1041031】
        /// </summary> 
        NsColumn CRCL_ClassDate { get; }
        /// <summary>
        /// [DIRECT]*上課時間{DTN_NVARCHAR20}：【09:00~17:00】
        /// </summary> 
        NsColumn CRCL_ClassTime { get; }
        /// <summary>
        /// [DIRECT]*班別代號{DTN_NVARCHAR10}：【A01】
        /// </summary> 
        NsColumn CRCL_Code { get; }
        /// <summary>
        /// [DIRECT]*課程代號{DTN_NVARCHAR10}：【10410001】&lt;br/&gt;
        /// </summary> 
        NsColumn CRCL_CourseCode_XX { get; }
        /// <summary>
        /// [DIRECT]*課程描述{DTN_NVARCHAR200}：【】&lt;br/&gt;
        /// </summary> 
        NsColumn CRCL_CourseDesc_XX { get; }
        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR1}：【Y：是 / N：否】&lt;br/&gt;
        /// </summary> 
        NsColumn CRCL_CourseEnable_XX { get; }
        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR10}：【Y：是 / N：否】&lt;br/&gt;
        /// </summary> 
        NsColumn CRCL_CourseEnableName_XX { get; }
        /// <summary>
        /// [DIRECT]*課程ID{DTN_NID}：【PK&lt;CRC&gt;】
        /// </summary> 
        NsColumn CRCL_CourseId { get; }
        /// <summary>
        /// [DIRECT]*課程名稱{DTN_NVARCHAR50}：【】&lt;br/&gt;
        /// </summary> 
        NsColumn CRCL_CourseName_XX { get; }
        /// <summary>
        /// [DIRECT]*建立日期(DTN_DATETIME_19)：【】
        /// </summary> 
        NsColumn CRCL_CreateDate { get; }
        /// <summary>
        /// [DIRECT]*建立者ID(DTN_NID)：【】
        /// </summary> 
        NsColumn CRCL_CreatorId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn CRCL_CreatorName_XX { get; }
        /// <summary>
        /// [DIRECT]*餐飲服務{DTN_NVARCHAR1}：【N：無 / A：餐盒 / B：茶點】
        /// </summary> 
        NsColumn CRCL_DietServcie { get; }
        /// <summary>
        /// [DIRECT]*餐飲服務{DTN_NVARCHAR10}：【N：無 / A：餐盒 / B：茶點】
        /// </summary> 
        NsColumn CRCL_DietServiceName_XX { get; }
        /// <summary>
        /// [DIRECT]*課程結束日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;
        /// </summary> 
        NsColumn CRCL_EndDate_XX { get; }
        /// <summary>
        /// [DIRECT]*人數限制{DTN_INTEGER}：【40】
        /// </summary> 
        NsColumn CRCL_LimitQty { get; }
        /// <summary>
        /// [DIRECT]*上課地點{DTN_NVARCHAR50}：【高雄市政府資訊中心電腦教室】
        /// </summary> 
        NsColumn CRCL_Place { get; }
        /// <summary>
        /// [DIRECT]*報名結束日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;
        /// </summary> 
        NsColumn CRCL_RegisterEndDate_XX { get; }
        /// <summary>
        /// *已報名人數{DTN_INTEGER}：【35】
        /// </summary> 
        NsColumn CRCL_RegisterQty_XX { get; }
        /// <summary>
        /// [DIRECT]*報名開始日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;
        /// </summary> 
        NsColumn CRCL_RegisterStartDate_XX { get; }
        /// <summary>
        /// [DIRECT]*課程開始日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;
        /// </summary> 
        NsColumn CRCL_StartDate_XX { get; }
        /// <summary>
        /// [DIRECT]*異動日期(DTN_DATETIME_19)：【】
        /// </summary> 
        NsColumn CRCL_UpdateDate { get; }
        /// <summary>
        /// [DIRECT]*異動者ID(DTN_NID)：【】
        /// </summary> 
        NsColumn CRCL_UpdaterId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn CRCL_UpdaterName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class CR_ClassNsTable : NsTable, CR_Class
        {
            public NsColumn CRCL_ClassId
            {
                  get { return this["CRCL_ClassId"]; }
            }
            public NsColumn CRCL_Address
            {
                  get { return this["CRCL_Address"]; }
            }
            public NsColumn CRCL_ClassDate
            {
                  get { return this["CRCL_ClassDate"]; }
            }
            public NsColumn CRCL_ClassTime
            {
                  get { return this["CRCL_ClassTime"]; }
            }
            public NsColumn CRCL_Code
            {
                  get { return this["CRCL_Code"]; }
            }
            public NsColumn CRCL_CourseCode_XX
            {
                  get { return this["CRCL_CourseCode_XX"]; }
            }
            public NsColumn CRCL_CourseDesc_XX
            {
                  get { return this["CRCL_CourseDesc_XX"]; }
            }
            public NsColumn CRCL_CourseEnable_XX
            {
                  get { return this["CRCL_CourseEnable_XX"]; }
            }
            public NsColumn CRCL_CourseEnableName_XX
            {
                  get { return this["CRCL_CourseEnableName_XX"]; }
            }
            public NsColumn CRCL_CourseId
            {
                  get { return this["CRCL_CourseId"]; }
            }
            public NsColumn CRCL_CourseName_XX
            {
                  get { return this["CRCL_CourseName_XX"]; }
            }
            public NsColumn CRCL_CreateDate
            {
                  get { return this["CRCL_CreateDate"]; }
            }
            public NsColumn CRCL_CreatorId
            {
                  get { return this["CRCL_CreatorId"]; }
            }
            public NsColumn CRCL_CreatorName_XX
            {
                  get { return this["CRCL_CreatorName_XX"]; }
            }
            public NsColumn CRCL_DietServcie
            {
                  get { return this["CRCL_DietServcie"]; }
            }
            public NsColumn CRCL_DietServiceName_XX
            {
                  get { return this["CRCL_DietServiceName_XX"]; }
            }
            public NsColumn CRCL_EndDate_XX
            {
                  get { return this["CRCL_EndDate_XX"]; }
            }
            public NsColumn CRCL_LimitQty
            {
                  get { return this["CRCL_LimitQty"]; }
            }
            public NsColumn CRCL_Place
            {
                  get { return this["CRCL_Place"]; }
            }
            public NsColumn CRCL_RegisterEndDate_XX
            {
                  get { return this["CRCL_RegisterEndDate_XX"]; }
            }
            public NsColumn CRCL_RegisterQty_XX
            {
                  get { return this["CRCL_RegisterQty_XX"]; }
            }
            public NsColumn CRCL_RegisterStartDate_XX
            {
                  get { return this["CRCL_RegisterStartDate_XX"]; }
            }
            public NsColumn CRCL_StartDate_XX
            {
                  get { return this["CRCL_StartDate_XX"]; }
            }
            public NsColumn CRCL_UpdateDate
            {
                  get { return this["CRCL_UpdateDate"]; }
            }
            public NsColumn CRCL_UpdaterId
            {
                  get { return this["CRCL_UpdaterId"]; }
            }
            public NsColumn CRCL_UpdaterName_XX
            {
                  get { return this["CRCL_UpdaterName_XX"]; }
            }
        }
    }
}
