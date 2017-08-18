using System;
using System.Collections.Generic;
using System.Text;
using ftd.data.model.tag;
using ftd.data.model.datatype;
using ftd.data;
using ftd.nsql;

namespace ftd.data
{
    /// <summary>
    /// 資料名稱
    /// </summary>
    public partial class AppDataName : FdmDataName
    {
        /// <summary>
        /// &lt;WT>網站工作{Web Task}
        /// </summary>
        [FdmSystemDef("WT_")]
        public const string WT = "WT";

        #region [WT_ScheduleTask]
        /// <summary>
        /// &lt;WTST>排程工作{ScheduleTask}
        /// </summary>
        [FdmTableDef("WTST_", WTST_ScheduleTaskId, IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.WtScheduleTaskProvider,AppService")]
        public const string WT_ScheduleTask = "WT_ScheduleTask";

        /// <summary>
        /// *排程工作ID{ScheduleTaskId}：【PK&lt;WTST>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string WTST_ScheduleTaskId = "WTST_ScheduleTaskId";

        /// <summary>
        /// *工作名稱{TaskName:50}：【資料回收程式】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        public const string WTST_TaskName = "WTST_TaskName";

        /// <summary>
        /// *工作描述{Descripton:200}：【回收暫存檔案資料】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR200)]
        public const string WTST_Description = "WTST_Description";

        /// <summary>
        /// *是否啟用{IsEnable:1,IsEnableName_XX}：○{Name}啟用 ○{Name_U}不啟用
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string WTST_IsEnable = "WTST_IsEnable";

        ///// <summary>
        ///// *是否啟用{IsLogEnable}：○{Name}啟用 ○{Name_U}不啟用
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1)]
        //public const string WTST_IsLogEnable = "WTST_IsLogEnable";

        /// <summary>
        /// *是否啟用{IsEnable:1,IsEnableName_XX}：○{Name}啟用 ○{Name_U}不啟用
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCodeName("CTN_WTST_IsEnable", WTST_IsEnable)]
        public const string WTST_IsEnableName_XX = "WTST_IsEnableName_XX";

        /// <summary>
        /// *執行起始日期{ExecuteBeginDate:D}：【2008/04/01 12:30:40】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        public const string WTST_ExecuteBeginDate = "WTST_ExecuteBeginDate";

        /// <summary>
        /// *執行結束日期{ExecuteEndDate:D}：【2008/04/01 12:30:50】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        public const string WTST_ExecuteEndDate = "WTST_ExecuteEndDate";

        /// <summary>
        /// *執行結果{ExecuteState:1,ExecuteStateName_XX}：○{Name}成功 ○{Name_U}失敗
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string WTST_ExecuteState = "WTST_ExecuteState";

        /// <summary>
        /// *執行結果{ExecuteState:1,ExecuteStateName_XX}：○{Name}成功 ○{Name_U}失敗
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCalculate]
        public const string WTST_ExecuteStateName_XX = "WTST_ExecuteStateName_XX";

        /// <summary>
        /// *執行例外{ExecuteException:1000}：【資料庫無法開啟】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        public const string WTST_ExecuteException = "WTST_ExecuteException";

        /// <summary>
        /// #執行時間(秒){ExecuteSeconds_XX}：【10】
        /// </summary>
        [FdmStyleType(DTN_DECIMAL)]
        [FdmCalculate]
        public const string WTST_ExecuteSeconds_XX = "WTST_ExecuteSeconds_XX";

        /// <summary>
        /// *物件類型{ObjectTypeName:100}：【sys.service.HcCareScheduleNotifyTask,AppService】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        public const string WTST_ObjectTypeName = "WTST_ObjectTypeName";

        /// <summary>
        /// *物件參數{Parameters:100}：【DAILYREPORT AreaId】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        public const string WTST_Parameters = "WTST_Parameters";

        #endregion

        #region [WT_ScheduleDate]
        /// <summary>
        /// &lt;WTSD>排程日期{ScheduleDate}
        /// </summary>
        [FdmTableDef("WTSD_", WTSD_ScheduleDateId, IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.WtScheduleDateProvider,AppService")]
        public const string WT_ScheduleDate = "WT_ScheduleDate";

        /// <summary>
        /// *排程日期ID{ScheduleDateId}：【PK&lt;WTSD>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string WTSD_ScheduleDateId = "WTSD_ScheduleDateId";

        /// <summary>
        /// *排程工作ID{ScheduleTaskId}：【KEY&lt;WTST>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string WTSD_ScheduleTaskId = "WTSD_ScheduleTaskId";

        /// <summary>
        /// *日期描述{Description:50}：【每天06:30分執行】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        public const string WTSD_Description = "WTSD_Description";

        /// <summary>
        /// *物件參數{Parameters:4000}：【0ZW0sIFZlcnNpb249Mi4wLjAuMCwgQ3V==】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR4000)]
        public const string WTSD_Parameters = "WTSD_Parameters";

        /// <summary>
        /// *是否啟用{IsEnable:1,IsEnableName_XX}：Y：啟用 N：不啟用
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string WTSD_IsEnable = "WTSD_IsEnable";

        /// <summary>
        /// *是否啟用{IsEnable:1,IsEnableName_XX}：Y：啟用 N：不啟用
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1000)]
        [FdmCodeName("CTN_WTST_IsEnable", WTSD_IsEnable)]
        public const string WTSD_IsEnableName_XX = "WTSD_IsEnableName_XX";

        /// <summary>
        /// *週期類型{1}：【A：每天 / B：每小時】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string WTSD_PeriodType = "WTSD_PeriodType";

        /// <summary>
        /// *每天-小時{INT}：【0~24】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        public const string WTSD_EveryDayHour = "WTSD_EveryDayHour";

        /// <summary>
        /// *每天-分鐘{INT}：【0~59】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        public const string WTSD_EveryDayMiniute = "WTSD_EveryDayMiniute";

        /// <summary>
        /// 超過排程日期{getCurrentScheduleTime()}多少分鐘，仍視為到期的。
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmDefaultValue(5)]
        public const string WTSD_MoreMinute = "WTSD_MoreMinute";

        #endregion

        #region [WT_ScheduleNotify]
        ///// <summary>
        ///// 報表通知對象
        ///// </summary>
        //[FdmTableDef("WTSN_", WTSN_ScheduleNotifyId, IsSessionEnable = false)]
        //[FdmTableProvider("ftd.dataaccess.WtScheduleNotifyProvider, AppService")]
        //[FdmCodeGen("排程通知對象")]
        //public const string WT_ScheduleNotify = "WT_ScheduleNotify";

        ///// <summary>
        ///// *報表通知ID{PrimaryKey}：【key(EMMT)】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //[FdmCodeGen("排程通知ID")]
        //public const string WTSN_ScheduleNotifyId = "WTSN_ScheduleNotifyId";

        ///// <summary>
        ///// *排程Id{key}：【keyof(EOE)】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //[FdmCodeGen("排程Id")]
        //public const string WTSN_ScheduleTaskId = "WTSN_ScheduleTaskId";

        ///// <summary>
        ///// *通知對象Id{key}：【keyof(EOE)】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //[FdmCodeGen("通知對象Id")]
        //public const string WTSN_EmployeeId = "WTSN_EmployeeId";

        ///// <summary>
        ///// #通知對象名稱{20}：【市政府-林勝文 組長】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //[FdmLink(WTSN_EmployeeId, EOE_EmployeeFullName_XX)]
        //[FdmCodeGen("通知對象名稱")]
        //public const string WTSN_EmployeeFullName_XX = "WTSN_EmployeeFullName_XX";

        ///// <summary>
        ///// #EMAIL{100}：【hello@kcg.gov.tw】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //[FdmLink(WTSN_EmployeeId, EOE_EmployeeEmail)]
        //[FdmCodeGen("EMAIL")]
        //public const string WTSN_EmployeeEmail_XX = "WTSN_EmployeeEmail_XX";

        #endregion

        #region [WT_MailQueue]
        ///// <summary>
        ///// &lt;WTMQ>Email 佇列{MailQueue}
        ///// </summary>
        //[FdmTableDef("WTMQ_", WTMQ_MailQueueId, RowInsertDateName = WTMQ_RowInsertDate)]
        //[FdmTableProvider("ftd.dataaccess.WtMailQueueProvider,AppService")]
        //public const string WT_MailQueue = "WT_MailQueue";

        ///// <summary>        
        ///// *MailQueueId{MailQueueId}：【PK&lt;WTMQ>】      
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTMQ_MailQueueId = "WTMQ_MailQueueId";

        ///// <summary>      
        ///// *郵件內容{Content:TEXT}：【ABCDXXXNXXX==】
        ///// </summary>
        //[FdmStyleType(DTN_NTEXT)]
        //public const string WTMQ_Content = "WTMQ_Content";

        ///// <summary>    
        ///// *新增日期{RowInsertDate:D}：【2008/09/01 12:13:10】
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string WTMQ_RowInsertDate = "WTMQ_RowInsertDate";
        #endregion

        #region [WT_ServiceException]
        ///// <summary>
        ///// &lt;WTSE>服務例外{ServiceException}
        ///// </summary>
        //[FdmTableDef("WTSE_", WTSE_ServiceExceptionId)]
        //[FdmTableProvider("ftd.dataaccess.WtServiceExceptionProvider,AppService")]
        //public const string WT_ServiceException = "WT_ServiceException";

        ///// <summary>
        ///// *例外ID{ServiceExceptionId}：【PK&lt;WTSE>】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTSE_ServiceExceptionId = "WTSE_ServiceExceptionId";

        ///// <summary>
        ///// *發生時間{RaiseDate:D}：【2006/11/07 13:30:58】
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string WTSE_RaiseDate = "WTSE_RaiseDate";

        ///// <summary>
        ///// *程式{Program:50}：【急診單】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string WTSE_Program = "WTSE_Program";

        ///// <summary>
        ///// *例外內容{ExceptionMessage:TEXT}：【not implement Exception】
        ///// </summary>
        //[FdmStyleType(DTN_NTEXT)]
        //public const string WTSE_ExceptionMessage = "WTSE_ExceptionMessage";

        ///// <summary>
        ///// #短例外內容{ExceptionMessageShort_XX:80}：【not implement Exception】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1000)]
        //[FdmCalculate]
        //public const string WTSE_ExceptionMessageShort_XX = "WTSE_ExceptionMessageShort_XX";

        #endregion

        #region [WT_WebDirectory]
        ///// <summary>
        ///// &lt;WTWD>網站檔案目錄{WebDirectory}
        ///// </summary>
        //[FdmTableDef("WTWD_", WTWD_WebDirectoryId)]
        //[FdmTableProvider("ftd.dataaccess.WtWebDirectoryProvider,AppService")]
        //public const string WT_WebDirectory = "WT_WebDirectory";

        ///// <summary>
        ///// *目錄ID{WebDirectoryId}：【PK&lt;WTWD>】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTWD_WebDirectoryId = "WTWD_WebDirectoryId";

        ///// <summary>
        ///// *目錄名稱{DirectoryName:50}：【住院檔案目錄】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string WTWD_DirectoryName = "WTWD_DirectoryName";

        ///// <summary>
        ///// #檔案數量{FileCount_XX:INT}：【5】
        ///// </summary>
        //[FdmStyleType(DTN_INTEGER)]
        //[FdmCalculate]
        //public const string WTWD_FileCount_XX = "WTWD_FileCount_XX";

        ///// <summary>
        ///// *實體目錄名稱{PhysicalFolderName:20}：【Perscription】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //public const string WTWD_PhysicalFolderName = "WTWD_PhysicalFolderName";

        ///// <summary>
        ///// #完整目錄名稱{PhysicalFolderFullName_XX}：【C:\Hello\Perscription】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1000)]
        //[FdmCalculate]
        //public const string WTWD_PhysicalFolderFullName_XX = "WTWD_PhysicalFolderFullName_XX";
        #endregion

        #region [WT_WebFile]
        ///// <summary>
        ///// Web檔案
        ///// </summary>
        //[FdmTableDef("WTWF_", WTWF_WebFileId, RowInsertDateName = WTWF_RowInsertDate)]
        //[FdmTableProvider("ftd.dataaccess.WtWebFileProvider,AppService")]
        //public const string WT_WebFile = "WT_WebFile";
        ///// <summary>
        ///// *檔案ID{WebFileId}：【PK&lt;WTWF>】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTWF_WebFileId = "WTWF_WebFileId";

        ///// <summary>
        ///// *檔案名稱{FileName:50}：【急診單.doc】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string WTWF_FileName = "WTWF_FileName";

        ///// <summary>
        ///// #檔案名稱{FileFullName_XX}：【住院檔案目錄\急診單.doc】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //[FdmCalculate]
        //public const string WTWF_FileFullName_XX = "WTWF_FileFullName_XX";

        ///// <summary>
        ///// *儲存檔名{StorageName:50}：【ABC001WFXGUXX.doc】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string WTWF_StorageName = "WTWF_StorageName";

        ///// <summary>
        ///// *目錄ID{WebDirectoryId}：【KEY&lt;WTWD>】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTWF_DirectoryId = "WTWF_DirectoryId";

        ///// <summary>
        ///// #目錄名稱{DirectoryName_XX}：【住院檔案目錄】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1000)]
        //[FdmLink(WTWF_DirectoryId, WTWD_DirectoryName)]
        //public const string WTWF_DirectoryName_XX = "WTWF_DirectoryName_XX";

        ///// <summary>
        ///// 檔案描述{Desc:50}：【林勝文的機密檔案】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string WTWF_Desc = "WTWF_Desc";

        ///// <summary>
        ///// *新增日期{RowInsertDate:D}：【2007/11/23 12:30:34】
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string WTWF_RowInsertDate = "WTWF_RowInsertDate";

        ///// <summary>
        ///// #檔案副檔名{ExtName_XX}：【.doc】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1000)]
        //[FdmCalculate]
        //public const string WTWF_ExtName_XX = "WTWF_ExtName_XX";

        ///// <summary>
        ///// #檔案ContentType{ContentType_XX}：【txt_source/plain】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1000)]
        //[FdmLink(WTWF_ExtName_XX, WTCT_ContentType)]
        //public const string WTWF_ContentType_XX = "WTWF_ContentType_XX";

        ///// <summary>
        ///// #儲存完整檔名{StorageFullName_XX}：【C:\Hello\Perscription\WTWF_1.doc】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1000)]
        //[FdmCalculate]
        //public const string WTWF_StorageFullName_XX = "WTWF_StorageFullName_XX";

        ///// <summary>
        ///// 參考來源{SourceId}：【KEY】※可自由設定ID以便紀錄來源。
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTWF_SourceId = "WTWF_SourceId";

        #endregion

        #region [WT_ContentType]
        ///// <summary>
        ///// Web檔案ContentType
        ///// </summary>
        //[FdmTableDef("WTCT_", WTCT_ExtName)]
        //[FdmTableProvider("ftd.dataaccess.WtContentTypeProvider,AppService")]
        //public const string WT_ContentType = "WT_ContentType";

        ///// <summary>
        ///// *副檔名稱{ ExtName }：【&lt;PK>】例:.jpg※主健 空白代表無法對應的類型
        ///// </summary>
        //[FdmNVarcharType(10, true, FdmNVarcharType.CharacterCasingName.Lower)]
        //public const string WTCT_ExtName = "WTCT_ExtName";

        ///// <summary>
        ///// *ContentType {ContentType}：【image/jpeg】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string WTCT_ContentType = "WTCT_ContentType";
        #endregion

        #region [WT_EventAttachment]
        ///// <summary>
        ///// 活動附件
        ///// </summary>
        //[FdmTableDef("WTEA_", WTEA_EventAttachmentId,
        //    RowInsertDateName = WTEA_CreateDate,
        //    RowInsertUserName = WTEA_CreatorId,
        //    RowModifyDateName = WTEA_UpdateDate,
        //    RowModifyUserName = WTEA_UpdaterId,
        //    IsSessionEnable = false)]
        //[FdmTableProvider("ftd.dataaccess.WtEventAttachmentProvider, AppService")]
        //public const string WT_EventAttachment = "WT_EventAttachment";

        ///// <summary>
        ///// ID (Primary Key)
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTEA_EventAttachmentId = "WTEA_EventAttachmentId";

        ///// <summary>
        ///// 活動Id
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //public const string WTEA_EventId = "WTEA_EventId";

        ///// <summary>
        ///// 檔案id
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string WTEA_FileId = "WTEA_FileId";

        ///// <summary>
        ///// 檔案名稱
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string WTEA_FileName = "WTEA_FileName";

        ///// <summary>
        ///// 副檔名
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR10)]
        //public const string WTEA_FileExtension = "WTEA_FileExtension";

        ///// <summary>
        ///// 說明
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //public const string WTEA_Comment = "WTEA_Comment";

        ///// <summary>
        ///// 建立者id
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTEA_CreatorId = "WTEA_CreatorId";

        ///// <summary>
        ///// 建立者姓名
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmLink(WTEA_CreatorId, AppDataName.EOE_EmployeeName)]
        //public const string WTEA_CreatorName_XX = "WTEA_CreatorName_XX";

        ///// <summary>
        ///// 建立日期
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string WTEA_CreateDate = "WTEA_CreateDate";

        ///// <summary>
        ///// 異動者id
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTEA_UpdaterId = "WTEA_UpdaterId";

        ///// <summary>
        ///// 異動者姓名
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmLink(WTEA_UpdaterId, AppDataName.EOE_EmployeeName)]
        //public const string WTEA_UpdaterName_XX = "WTEA_UpdaterName_XX";

        ///// <summary>
        ///// 異動日期
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string WTEA_UpdateDate = "WTEA_UpdateDate";

        #endregion

        #region [WT_ReportNotify]
        ///// <summary>
        ///// 報表通知對象
        ///// </summary>
        //[FdmTableDef("WTRN_", WTRN_ReportNotifyId, IsSessionEnable = true)]
        //[FdmTableProvider("ftd.dataaccess.WtReportNotifyProvider, AppService")]
        //[FdmCodeGen("報表通知對象")]
        //public const string WT_ReportNotify = "WT_ReportNotify";

        ///// <summary>
        ///// *報表通知ID{PrimaryKey}：【key(EMMT)】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //[FdmCodeGen("報表通知ID")]
        //public const string WTRN_ReportNotifyId = "WTRN_ReportNotifyId";

        ///// <summary>
        ///// *排程Id{key}：【keyof(EOE)】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //[FdmCodeGen("排程Id")]
        //public const string WTRN_ScheduleTaskId = "WTRN_ScheduleTaskId";

        ///// <summary>
        ///// *通知對象Id{key}：【keyof(EOE)】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //[FdmCodeGen("通知對象Id")]
        //public const string WTRN_EmpId = "WTRN_EmpId";

        ///// <summary>
        ///// *區域ID {AreaId}：【AreaId】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //public const string WTRN_AreaId = "WTRN_AreaId";

        ///// <summary>
        ///// #通知對象名稱{20}：【市政府-林勝文 組長】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //[FdmLink(WTRN_EmpId, EOE_EmployeeFullName_XX)]
        //[FdmCodeGen("通知對象名稱")]
        //public const string WTRN_EmpName_XX = "WTRN_EmpName_XX";

        ///// <summary>
        ///// #EMAIL{100}：【hello@kcg.gov.tw】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //[FdmLink(WTRN_EmpId, EOE_EmployeeEmail)]
        //[FdmCodeGen("EMAIL")]
        //public const string WTRN_EmpEmail_XX = "WTRN_EmpEmail_XX";

        #endregion

        #region [WT_ReportLog]
        ///// <summary>
        ///// 報表排程Log檔
        ///// </summary>
        //[FdmTableDef("WTRL_", WTRL_ReportLogId, IsSessionEnable = true)]
        //[FdmTableProvider("ftd.dataaccess.WtReportLogProvider, AppService")]
        //[FdmCodeGen("報表排程Log檔")]
        //public const string WT_ReportLog = "WT_ReportLog";

        ///// <summary>
        ///// *報表通知ID{PrimaryKey}：【key】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //[FdmCodeGen("報表LogID")]
        //public const string WTRL_ReportLogId = "WTRL_ReportLogId";

        ///// <summary>
        ///// *排程Id{key}：【key】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //[FdmCodeGen("排程Id")]
        //public const string WTRL_ScheduleTaskId = "WTRL_ScheduleTaskId";

        ///// <summary>
        ///// *報表名稱：【ReportName】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmCodeGen("報表名稱")]
        //public const string WTRL_ReportName = "WTRL_ReportName";

        ///// <summary>
        ///// *傳送時間：【keyof(EOE)】
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //[FdmCodeGen("傳送時間")]
        //public const string WTRL_SendTime = "WTRL_SendTime";

        #endregion

        #region [WT_PageContent]

        ///// <summary>
        ///// &lt;WTPC>網頁內容{PageContent}
        ///// </summary>
        //[FdmTableDef("WTPC_", WTPC_PageContentId,
        //    RowInsertDateName = WTPC_CreateDate,
        //    RowInsertUserName = WTPC_CreatorId,
        //    RowModifyDateName = WTPC_UpdateDate,
        //    RowModifyUserName = WTPC_UpdaterId,
        //    IsSessionEnable = false)]
        //[FdmTableProvider("ftd.dataaccess.WtPageContentProvider, AppService")]
        //public const string WT_PageContent = "WT_PageContent";

        ///// <summary>
        ///// *ID{ContentId} 
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTPC_PageContentId = "WTPC_PageContentId";

        ///// <summary>
        ///// *標題{Title} History、Organization、Privacy
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //public const string WTPC_Title = "WTPC_Title";

        ///// <summary>
        ///// *標題說明{Title_XX} 【History：歷史沿革、Organization：組織職掌、Privacy：隱私權保護政策】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //[FdmCodeName("CTN_PageContent", WTPC_Title)]
        //public const string WTPC_TitleName_XX = "WTPC_TitleName_XX";

        ///// <summary>
        ///// *內容{Content} 
        ///// </summary>
        //[FdmStyleType(DTN_NTEXT)]
        //public const string WTPC_Content = "WTPC_Content";

        ///// <summary>
        ///// *建立者id{CreatorId} 
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTPC_CreatorId = "WTPC_CreatorId";

        ///// <summary>
        ///// *建立者姓名{CreatorName_XX} 
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmLink(AppDataName.WTPC_CreatorId, AppDataName.EOE_EmployeeName)]
        //public const string WTPC_CreatorName_XX = "WTPC_CreatorName_XX";

        ///// <summary>
        ///// *建立日期{CreateDate} yyyy/MM/dd HH:mm:ss
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string WTPC_CreateDate = "WTPC_CreateDate";

        ///// <summary>
        ///// *異動者id{UpdaterId} 
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTPC_UpdaterId = "WTPC_UpdaterId";

        ///// <summary>
        ///// *異動者姓名{UpdaterName_XX} 
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmLink(AppDataName.WTPC_UpdaterId, AppDataName.EOE_EmployeeName)]
        //public const string WTPC_UpdaterName_XX = "WTPC_UpdaterName_XX";

        ///// <summary>
        ///// *異動日期{UpdateDate} yyyy/MM/dd HH:mm:ss
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string WTPC_UpdateDate = "WTPC_UpdateDate";

        #endregion

        #region [WT_Announce]
        ///// <summary>
        ///// &lt;WTA>訊息公告{Announce}
        ///// </summary>
        //[FdmTableDef("WTA_", WTA_AnnounceId,
        //   RowInsertDateName = WTA_CreateDate,
        //   RowInsertUserName = WTA_CreatorId,
        //   RowModifyDateName = WTA_UpdateDate,
        //   RowModifyUserName = WTA_UpdaterId,
        // IsSessionEnable = false)]
        //[FdmTableProvider("ftd.dataaccess.WtAnnounceProvider,AppService")]
        //public const string WT_Announce = "WT_Announce";

        ///// <summary>
        ///// *ID{AnnounceId}：【PK】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTA_AnnounceId = "WTA_AnnounceId";

        ///// <summary>
        ///// *標題{Title}：
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string WTA_Title = "WTA_Title";

        ///// <summary>
        ///// *類別{Type}：N:訊息公告  E:活動公告
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1)]
        //public const string WTA_Type = "WTA_Type";

        ///// <summary>
        ///// *內容{Content}：
        ///// </summary>
        //[FdmStyleType(DTN_NTEXT)]
        //public const string WTA_Content = "WTA_Content";

        ///// <summary>
        ///// *刊登日期{StartDate}：
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_10)]
        //public const string WTA_StartDate = "WTA_StartDate";

        ///// <summary>
        ///// *截止日期{EndDate}：
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_10)]
        //public const string WTA_EndDate = "WTA_EndDate";

        ///// <summary>
        ///// *建立者id{CreatorId}：
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTA_CreatorId = "WTA_CreatorId";

        ///// <summary>
        ///// *建立者姓名{CreatorName_XX}：
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmLink(WTA_CreatorId, AppDataName.EOE_EmployeeName)]
        //public const string WTA_CreatorName_XX = "WTA_CreatorName_XX";

        ///// <summary>
        ///// *建立日期{CreateDate}：
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string WTA_CreateDate = "WTA_CreateDate";

        ///// <summary>
        ///// *異動者id{UpdaterId}：
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTA_UpdaterId = "WTA_UpdaterId";

        ///// <summary>
        ///// *異動者姓名{UpdaterName_XX}：
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmLink(WTA_UpdaterId, AppDataName.EOE_EmployeeName)]
        //public const string WTA_UpdaterName_XX = "WTA_UpdaterName_XX";

        ///// <summary>
        ///// *異動日期{UpdateDate}：
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //public const string WTA_UpdateDate = "WTA_UpdateDate";

        #endregion
        
        #region  [WT_UploadFile]
        ///// <summary>
        ///// 上傳檔案
        ///// </summary>
        //[FdmTableDef("WTUF_", WTUF_UploadFileId)]
        //[FdmTableProvider("ftd.dataaccess.WtUploadFileProvider,AppService")]
        //public const string WT_UploadFile = "WT_UploadFile";

        ///// <summary>
        ///// *上傳檔案ID{UploadFileId}：【PK&lt;WTST>】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTUF_UploadFileId = "WTUF_UploadFileId";

        ///// <summary>
        ///// *檔案名稱{FileName}：【xxx.jpg】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //public const string WTUF_FileName = "WTUF_FileName";

        ///// <summary>
        ///// *檔案類型{FileType}：【A:員工圖片; B:品項圖片; C:論壇圖片; D:檔案;】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1)]
        //public const string WTUF_FileType = "WTUF_FileType";

        ///// <summary>
        ///// #檔案類型{FileTypeName}：【A:員工圖片; B:品項圖片; C:論壇圖片; D:檔案;】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR10)]
        //[FdmCodeName("CTN_WTUF_FileType", WTUF_FileType)]
        //public const string WTUF_FileTypeName_XX = "WTUF_FileTypeName_XX";

        #endregion

        #region [WT_ReportDefine]
        ///// <summary>
        ///// &lt;WTST>報表定義{ReportDefine}
        ///// </summary>
        //[FdmTableDef("WTRD_", WTRD_ReportDefineId, IsSessionEnable = false)]
        //[FdmTableProvider("ftd.dataaccess.WtReportDefineProvider,AppService")]
        //public const string WT_ReportDefine = "WT_ReportDefine";

        ///// <summary>
        ///// *報表定義ID{ScheduleTaskId}：【PK&lt;WTST>】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //public const string WTRD_ReportDefineId = "WTRD_ReportDefineId";

        ///// <summary>
        ///// *報表名稱{TaskName:50}：
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR50)]
        //public const string WTRD_ReportName = "WTRD_ReportName";

        ///// <summary>
        ///// *工作描述{Descripton:200}：【回收暫存檔案資料】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR200)]
        //public const string WTRD_Description = "WTRD_Description";

        ///// <summary>
        ///// *物件類型/ReportService名稱 {ObjectTypeName:100}：【ftd.service.UL001ReportService,AppService】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR100)]
        //public const string WTRD_ObjectTypeName = "WTRD_ObjectTypeName";

        #endregion
        
    }
}
