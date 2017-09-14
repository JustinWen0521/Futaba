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
    /// &lt;CRR&gt;報名{Registratio}
    /// </summary>
    public interface CR_Registration : INsTable
    {
        /// <summary>
        /// [DIRECT]*報名ID{RegistrationId}：【PK&lt;CRR&gt;】
        /// </summary> 
        NsColumn CRR_RegistrationId { get; }
        /// <summary>
        /// [DIRECT]*身分證{DTN_NVARCHAR10}：【A123456789】
        /// </summary> 
        NsColumn CRR_CitizenId { get; }
        /// <summary>
        /// [DIRECT]*班別代號{DTN_NVARCHAR10}：【A01】&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_ClassCode_XX { get; }
        /// <summary>
        /// [DIRECT]*開班日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_ClassDate_XX { get; }
        /// <summary>
        /// [DIRECT]*班別ID{DTN_NID}：【PK&lt;CRCL&gt;】
        /// </summary> 
        NsColumn CRR_ClassId { get; }
        /// <summary>
        /// [DIRECT]*上課時間{DTN_NVARCHAR20}：【09:00~17:00】&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_ClassTime_XX { get; }
        /// <summary>
        /// [DIRECT]*課程代號{DTN_NVARCHAR10}：【10410001】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_CourseCode_XX { get; }
        /// <summary>
        /// [DIRECT]*課程描述{DTN_NVARCHAR200}：【】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_CourseDesc_XX { get; }
        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR1}：【Y：是 / N：否】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_CourseEnable_XX { get; }
        /// <summary>
        /// [DIRECT]*是否啟用{DTN_NVARCHAR10}：【Y：是 / N：否】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_CourseEnableName_XX { get; }
        /// <summary>
        /// [DIRECT]*課程ID{DTN_NID}：【PK&lt;CRC&gt;】&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_CourseId_XX { get; }
        /// <summary>
        /// [DIRECT]*課程名稱{DTN_NVARCHAR50}：【】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_CourseName_XX { get; }
        /// <summary>
        /// [DIRECT]*建立日期(DTN_DATETIME_19)：【】
        /// </summary> 
        NsColumn CRR_CreateDate { get; }
        /// <summary>
        /// [DIRECT]人員編號{EmployeeCode:20}：【EA001】&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_CreatorCode_XX { get; }
        /// <summary>
        /// [DIRECT]*建立者ID(DTN_NID)：【】
        /// </summary> 
        NsColumn CRR_CreatorId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_CreatorName_XX { get; }
        /// <summary>
        /// [DIRECT]*餐飲服務{DTN_NVARCHAR1}：【N：無 / A：餐盒 / B：茶點】&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_DietServcie_XX { get; }
        /// <summary>
        /// [DIRECT]*餐飲服務{DTN_NVARCHAR10}：【N：無 / A：餐盒 / B：茶點】&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_DietServiceName_XX { get; }
        /// <summary>
        /// [DIRECT]*Email{DTN_NVARCHAR50}：【user@company.com】
        /// </summary> 
        NsColumn CRR_Email { get; }
        /// <summary>
        /// [DIRECT]*課程結束日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_EndDate_XX { get; }
        /// <summary>
        /// [DIRECT]*葷素{FoodKind:1}：【A：葷食 / B：素食】
        /// </summary> 
        NsColumn CRR_FoodKind { get; }
        /// <summary>
        /// [DIRECT]*葷素{FoodKindName_X:1}：【A：葷食 / B：素食】
        /// </summary> 
        NsColumn CRR_FoodKindName_XX { get; }
        /// <summary>
        /// [DIRECT]*人數限制{DTN_INTEGER}：【40】&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_LimitQty_XX { get; }
        /// <summary>
        /// [DIRECT]*姓名{DTN_NVARCHAR20}：【王小明】
        /// </summary> 
        NsColumn CRR_Name { get; }
        /// <summary>
        /// [DIRECT]*單位名稱{OrganName:50}：【中正高中】
        /// </summary> 
        NsColumn CRR_OrganName { get; }
        /// <summary>
        /// [DIRECT]*報名結束日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_RegisterEndDate_XX { get; }
        /// <summary>
        /// *已報名人數{DTN_INTEGER}：【35】&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_RegisterQty_XX { get; }
        /// <summary>
        /// [DIRECT]*報名開始日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_RegisterStartDate_XX { get; }
        /// <summary>
        /// [DIRECT]*課程開始日期{DTN_NVARCHAR10}：【1041031】&lt;br/&gt;&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_StartDate_XX { get; }
        /// <summary>
        /// [DIRECT]*聯絡電話{Tel:20}：【07-3368333#3097】
        /// </summary> 
        NsColumn CRR_Tel { get; }
        /// <summary>
        /// [DIRECT]*異動日期(DTN_DATETIME_19)：【】
        /// </summary> 
        NsColumn CRR_UpdateDate { get; }
        /// <summary>
        /// [DIRECT]*異動者ID(DTN_NID)：【】
        /// </summary> 
        NsColumn CRR_UpdaterId { get; }
        /// <summary>
        /// [DIRECT]*人員姓名{EmployeeName:20}：【林勝文】&lt;br/&gt;
        /// </summary> 
        NsColumn CRR_UpdaterName_XX { get; }
    }

    namespace nstable
    {
        [Serializable]
        public class CR_RegistrationNsTable : NsTable, CR_Registration
        {
            public NsColumn CRR_RegistrationId
            {
                  get { return this["CRR_RegistrationId"]; }
            }
            public NsColumn CRR_CitizenId
            {
                  get { return this["CRR_CitizenId"]; }
            }
            public NsColumn CRR_ClassCode_XX
            {
                  get { return this["CRR_ClassCode_XX"]; }
            }
            public NsColumn CRR_ClassDate_XX
            {
                  get { return this["CRR_ClassDate_XX"]; }
            }
            public NsColumn CRR_ClassId
            {
                  get { return this["CRR_ClassId"]; }
            }
            public NsColumn CRR_ClassTime_XX
            {
                  get { return this["CRR_ClassTime_XX"]; }
            }
            public NsColumn CRR_CourseCode_XX
            {
                  get { return this["CRR_CourseCode_XX"]; }
            }
            public NsColumn CRR_CourseDesc_XX
            {
                  get { return this["CRR_CourseDesc_XX"]; }
            }
            public NsColumn CRR_CourseEnable_XX
            {
                  get { return this["CRR_CourseEnable_XX"]; }
            }
            public NsColumn CRR_CourseEnableName_XX
            {
                  get { return this["CRR_CourseEnableName_XX"]; }
            }
            public NsColumn CRR_CourseId_XX
            {
                  get { return this["CRR_CourseId_XX"]; }
            }
            public NsColumn CRR_CourseName_XX
            {
                  get { return this["CRR_CourseName_XX"]; }
            }
            public NsColumn CRR_CreateDate
            {
                  get { return this["CRR_CreateDate"]; }
            }
            public NsColumn CRR_CreatorCode_XX
            {
                  get { return this["CRR_CreatorCode_XX"]; }
            }
            public NsColumn CRR_CreatorId
            {
                  get { return this["CRR_CreatorId"]; }
            }
            public NsColumn CRR_CreatorName_XX
            {
                  get { return this["CRR_CreatorName_XX"]; }
            }
            public NsColumn CRR_DietServcie_XX
            {
                  get { return this["CRR_DietServcie_XX"]; }
            }
            public NsColumn CRR_DietServiceName_XX
            {
                  get { return this["CRR_DietServiceName_XX"]; }
            }
            public NsColumn CRR_Email
            {
                  get { return this["CRR_Email"]; }
            }
            public NsColumn CRR_EndDate_XX
            {
                  get { return this["CRR_EndDate_XX"]; }
            }
            public NsColumn CRR_FoodKind
            {
                  get { return this["CRR_FoodKind"]; }
            }
            public NsColumn CRR_FoodKindName_XX
            {
                  get { return this["CRR_FoodKindName_XX"]; }
            }
            public NsColumn CRR_LimitQty_XX
            {
                  get { return this["CRR_LimitQty_XX"]; }
            }
            public NsColumn CRR_Name
            {
                  get { return this["CRR_Name"]; }
            }
            public NsColumn CRR_OrganName
            {
                  get { return this["CRR_OrganName"]; }
            }
            public NsColumn CRR_RegisterEndDate_XX
            {
                  get { return this["CRR_RegisterEndDate_XX"]; }
            }
            public NsColumn CRR_RegisterQty_XX
            {
                  get { return this["CRR_RegisterQty_XX"]; }
            }
            public NsColumn CRR_RegisterStartDate_XX
            {
                  get { return this["CRR_RegisterStartDate_XX"]; }
            }
            public NsColumn CRR_StartDate_XX
            {
                  get { return this["CRR_StartDate_XX"]; }
            }
            public NsColumn CRR_Tel
            {
                  get { return this["CRR_Tel"]; }
            }
            public NsColumn CRR_UpdateDate
            {
                  get { return this["CRR_UpdateDate"]; }
            }
            public NsColumn CRR_UpdaterId
            {
                  get { return this["CRR_UpdaterId"]; }
            }
            public NsColumn CRR_UpdaterName_XX
            {
                  get { return this["CRR_UpdaterName_XX"]; }
            }
        }
    }
}
