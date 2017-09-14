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
    /// CR 課程報名系統
    /// </summary>
    public partial class AppDataName : FdmDataName
    {
        /// <summary>
        /// &lt;CR>課程報名系統{Course Registeration}
        /// </summary>
        [FdmSystemDef("CR_")]
        public const string CR = "CR";

        #region [CR_Course]
        /// <summary>
        /// &lt;CRC>課程{Course}
        /// </summary>
        [FdmTableDef("CRC_", CRC_CourseId,
              RowInsertUserName = AppDataName.CRC_CreatorId,
              RowInsertDateName = AppDataName.CRC_CreateDate,
              RowModifyUserName = AppDataName.CRC_UpdaterId,
              RowModifyDateName = AppDataName.CRC_UpdateDate,
              IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.CrCourseProvider,AppService")]
        public const string CR_Course = "CR_Course";

        /// <summary>
        /// *課程ID{DTN_NID}：【PK&lt;CRC>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string CRC_CourseId = "CRC_CourseId";

        /// <summary>
        /// *課程代號{DTN_NVARCHAR10}：【10410001】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        public const string CRC_Code = "CRC_Code";

        /// <summary>
        /// *課程名稱{DTN_NVARCHAR50}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        public const string CRC_Name = "CRC_Name";

        /// <summary>
        /// *課程描述{DTN_NVARCHAR200}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR200)]
        public const string CRC_Description = "CRC_Description";

        /// <summary>
        /// *是否啟用{DTN_NVARCHAR1}：【Y：是 / N：否】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string CRC_IsEnable = "CRC_IsEnable";

        /// <summary>
        /// *是否啟用{DTN_NVARCHAR10}：【Y：是 / N：否】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmCodeName("CTN_APP_YN", CRC_IsEnable)]
        public const string CRC_IsEnableName_XX = "CRC_IsEnableName_XX";

        /// <summary>
        /// *課程開始日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        public const string CRC_StartDate = "CRC_StartDate";

        /// <summary>
        /// *課程結束日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        public const string CRC_EndDate = "CRC_EndDate";

        /// <summary>
        /// *報名開始日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        public const string CRC_RegisterStartDate = "CRC_RegisterStartDate";

        /// <summary>
        /// *報名結束日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        public const string CRC_RegisterEndDate = "CRC_RegisterEndDate";

        /// <summary>
        /// *已報名人數{RegisterQty_XX:D}：【30】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        public const string CRC_RegisterQty_XX = "CRC_RegisterQty_XX";

        /// <summary>
        /// *建立者ID(DTN_NID)：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "建立者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string CRC_CreatorId = "CRC_CreatorId";

        /// <summary>
        /// *建立者姓名(DTN_NVARCHAR20)：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(AppDataName.CRC_CreatorId, AppDataName.EOE_EmployeeName)]
        [FdmCodeGen(Title = "建立者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRC_CreatorName_XX = "CRC_CreatorName_XX";

        /// <summary>
        /// *建立日期(DTN_DATETIME_19)：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "建立日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRC_CreateDate = "CRC_CreateDate";

        /// <summary>
        /// *異動者ID(DTN_NID)：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "異動者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRC_UpdaterId = "CRC_UpdaterId";

        /// <summary>
        /// *異動者姓名(DTN_NVARCHAR20)：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(AppDataName.CRC_UpdaterId, AppDataName.EOE_EmployeeName)]
        [FdmCodeGen(Title = "異動者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRC_UpdaterName_XX = "CRC_UpdaterName_XX";

        /// <summary>
        /// *異動日期(DTN_DATETIME_19)：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "異動日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRC_UpdateDate = "CRC_UpdateDate";

        #endregion

        #region [CR_Class]
        /// <summary>
        /// &lt;CRCL>班別{Class}
        /// </summary>
        [FdmTableDef("CRCL_", CRCL_ClassId,
              RowInsertUserName = AppDataName.CRCL_CreatorId,
              RowInsertDateName = AppDataName.CRCL_CreateDate,
              RowModifyUserName = AppDataName.CRCL_UpdaterId,
              RowModifyDateName = AppDataName.CRCL_UpdateDate,
              IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.CrClassProvider,AppService")]
        public const string CR_Class = "CR_Class";

        /// <summary>
        /// *班別ID{DTN_NID}：【PK&lt;CRCL>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string CRCL_ClassId = "CRCL_ClassId";

        /// <summary>
        /// *課程ID{DTN_NID}：【PK&lt;CRC>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string CRCL_CourseId = "CRCL_CourseId";

        /// <summary>
        /// *課程代號{DTN_NVARCHAR10}：【10410001】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRCL_CourseId, AppDataName.CRC_Code)]
        public const string CRCL_CourseCode_XX = "CRCL_CourseCode_XX";

        /// <summary>
        /// *課程名稱{DTN_NVARCHAR50}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmLink(AppDataName.CRCL_CourseId, AppDataName.CRC_Name)]
        public const string CRCL_CourseName_XX = "CRCL_CourseName_XX";

        /// <summary>
        /// *課程描述{DTN_NVARCHAR200}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR200)]
        [FdmLink(AppDataName.CRCL_CourseId, AppDataName.CRC_Description)]
        public const string CRCL_CourseDesc_XX = "CRCL_CourseDesc_XX";

        /// <summary>
        /// *是否啟用{DTN_NVARCHAR1}：【Y：是 / N：否】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmLink(AppDataName.CRCL_CourseId, AppDataName.CRC_IsEnable)]
        public const string CRCL_CourseEnable_XX = "CRCL_CourseEnable_XX";

        /// <summary>
        /// *是否啟用{DTN_NVARCHAR10}：【Y：是 / N：否】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRCL_CourseId, AppDataName.CRC_IsEnableName_XX)]
        public const string CRCL_CourseEnableName_XX = "CRCL_CourseEnableName_XX";

        /// <summary>
        /// *課程開始日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRCL_CourseId, AppDataName.CRC_StartDate)]
        public const string CRCL_StartDate_XX = "CRCL_StartDate_XX";

        /// <summary>
        /// *課程結束日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRCL_CourseId, AppDataName.CRC_EndDate)]
        public const string CRCL_EndDate_XX = "CRCL_EndDate_XX";

        /// <summary>
        /// *報名開始日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRCL_CourseId, AppDataName.CRC_RegisterStartDate)]
        public const string CRCL_RegisterStartDate_XX = "CRCL_RegisterStartDate_XX";

        /// <summary>
        /// *報名結束日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRCL_CourseId, AppDataName.CRC_RegisterEndDate)]
        public const string CRCL_RegisterEndDate_XX = "CRCL_RegisterEndDate_XX";

        /// <summary>
        /// *班別代號{DTN_NVARCHAR10}：【A01】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        public const string CRCL_Code = "CRCL_Code";

        /// <summary>
        /// *開班日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        public const string CRCL_ClassDate = "CRCL_ClassDate";

        /// <summary>
        /// *上課時間{DTN_NVARCHAR20}：【09:00~17:00】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        public const string CRCL_ClassTime = "CRCL_ClassTime";

        /// <summary>
        /// *上課地點{DTN_NVARCHAR50}：【高雄市政府資訊中心電腦教室】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        public const string CRCL_Place = "CRCL_Place";

        /// <summary>
        /// *地址{DTN_NVARCHAR100}：【高雄市苓雅區四維三路2號8樓】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR100)]
        public const string CRCL_Address = "CRCL_Address";

        /// <summary>
        /// *人數限制{DTN_INTEGER}：【40】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        public const string CRCL_LimitQty = "CRCL_LimitQty";

        /// <summary>
        /// *餐飲服務{DTN_NVARCHAR1}：【N：無 / A：餐盒 / B：茶點】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string CRCL_DietServcie = "CRCL_DietServcie";

        /// <summary>
        /// *餐飲服務{DTN_NVARCHAR10}：【N：無 / A：餐盒 / B：茶點】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmCodeName("CTN_CRCL_DietServcie", CRCL_DietServcie)]
        public const string CRCL_DietServiceName_XX = "CRCL_DietServiceName_XX";

        /// <summary>
        /// *已報名人數{DTN_INTEGER}：【35】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        public const string CRCL_RegisterQty_XX = "CRCL_RegisterQty_XX";

        /// <summary>
        /// *建立者ID(DTN_NID)：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "建立者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string CRCL_CreatorId = "CRCL_CreatorId";

        /// <summary>
        /// *建立者姓名(DTN_NVARCHAR20)：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(AppDataName.CRCL_CreatorId, AppDataName.EOE_EmployeeName)]
        [FdmCodeGen(Title = "建立者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRCL_CreatorName_XX = "CRCL_CreatorName_XX";

        /// <summary>
        /// *建立日期(DTN_DATETIME_19)：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "建立日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRCL_CreateDate = "CRCL_CreateDate";

        /// <summary>
        /// *異動者ID(DTN_NID)：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "異動者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRCL_UpdaterId = "CRCL_UpdaterId";

        /// <summary>
        /// *異動者姓名(DTN_NVARCHAR20)：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(AppDataName.CRCL_UpdaterId, AppDataName.EOE_EmployeeName)]
        [FdmCodeGen(Title = "異動者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRCL_UpdaterName_XX = "CRCL_UpdaterName_XX";

        /// <summary>
        /// *異動日期(DTN_DATETIME_19)：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "異動日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRCL_UpdateDate = "CRCL_UpdateDate";

        #endregion

        #region [CR_Registration]
        /// <summary>
        /// &lt;CRR>報名{Registratio}
        /// </summary>
        [FdmTableDef("CRR_", CRR_RegistrationId,
              RowInsertUserName = AppDataName.CRR_CreatorId,
              RowInsertDateName = AppDataName.CRR_CreateDate,
              RowModifyUserName = AppDataName.CRR_UpdaterId,
              RowModifyDateName = AppDataName.CRR_UpdateDate,
              IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.CrRegistratioProvider,AppService")]
        public const string CR_Registration = "CR_Registration";

        /// <summary>
        /// *報名ID{RegistrationId}：【PK&lt;CRR>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string CRR_RegistrationId = "CRR_RegistrationId";

        /// <summary>
        /// *班別ID{DTN_NID}：【PK&lt;CRCL>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string CRR_ClassId = "CRR_ClassId";

        /// <summary>
        /// *課程ID{DTN_NID}：【PK&lt;CRC>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_CourseId)]
        public const string CRR_CourseId_XX = "CRR_CourseId_XX";

        /// <summary>
        /// *課程代號{DTN_NVARCHAR10}：【10410001】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_CourseCode_XX)]
        public const string CRR_CourseCode_XX = "CRR_CourseCode_XX";

        /// <summary>
        /// *課程名稱{DTN_NVARCHAR50}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_CourseName_XX)]
        public const string CRR_CourseName_XX = "CRR_CourseName_XX";

        /// <summary>
        /// *課程描述{DTN_NVARCHAR200}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR200)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_CourseDesc_XX)]
        public const string CRR_CourseDesc_XX = "CRR_CourseDesc_XX";

        /// <summary>
        /// *是否啟用{DTN_NVARCHAR1}：【Y：是 / N：否】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_CourseEnable_XX)]
        public const string CRR_CourseEnable_XX = "CRR_CourseEnable_XX";

        /// <summary>
        /// *是否啟用{DTN_NVARCHAR10}：【Y：是 / N：否】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_CourseEnableName_XX)]
        public const string CRR_CourseEnableName_XX = "CRR_CourseEnableName_XX";

        /// <summary>
        /// *課程開始日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_StartDate_XX)]
        public const string CRR_StartDate_XX = "CRR_StartDate_XX";

        /// <summary>
        /// *課程結束日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_EndDate_XX)]
        public const string CRR_EndDate_XX = "CRR_EndDate_XX";

        /// <summary>
        /// *報名開始日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_RegisterStartDate_XX)]
        public const string CRR_RegisterStartDate_XX = "CRR_RegisterStartDate_XX";

        /// <summary>
        /// *報名結束日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_RegisterEndDate_XX)]
        public const string CRR_RegisterEndDate_XX = "CRR_RegisterEndDate_XX";

        /// <summary>
        /// *餐飲服務{DTN_NVARCHAR1}：【N：無 / A：餐盒 / B：茶點】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_DietServcie)]
        public const string CRR_DietServcie_XX = "CRR_DietServcie_XX";

        /// <summary>
        /// *餐飲服務{DTN_NVARCHAR10}：【N：無 / A：餐盒 / B：茶點】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_DietServiceName_XX)]
        public const string CRR_DietServiceName_XX = "CRR_DietServiceName_XX";

        /// <summary>
        /// *班別代號{DTN_NVARCHAR10}：【A01】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_Code)]
        public const string CRR_ClassCode_XX = "CRR_ClassCode_XX";

        /// <summary>
        /// *開班日期{DTN_NVARCHAR10}：【1041031】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_ClassDate)]
        public const string CRR_ClassDate_XX = "CRR_ClassDate_XX";

        /// <summary>
        /// *上課時間{DTN_NVARCHAR20}：【09:00~17:00】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_ClassTime)]
        public const string CRR_ClassTime_XX = "CRR_ClassTime_XX";

        /// <summary>
        /// *人數限制{DTN_INTEGER}：【40】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_LimitQty)]
        public const string CRR_LimitQty_XX = "CRR_LimitQty_XX";

        /// <summary>
        /// 已報名人數{DTN_INTEGER}：【40】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmLink(AppDataName.CRR_ClassId, AppDataName.CRCL_RegisterQty_XX)]
        public const string CRR_RegisterQty_XX = "CRR_RegisterQty_XX";

        /// <summary>
        /// *姓名{DTN_NVARCHAR20}：【王小明】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        public const string CRR_Name = "CRR_Name";

        /// <summary>
        /// *身分證{DTN_NVARCHAR10}：【A123456789】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        public const string CRR_CitizenId = "CRR_CitizenId";

        /// <summary>
        /// *Email{DTN_NVARCHAR50}：【user@company.com】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        public const string CRR_Email = "CRR_Email";

        /// <summary>
        /// *葷素{FoodKind:1}：【A：葷食 / B：素食】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        public const string CRR_FoodKind = "CRR_FoodKind";

        /// <summary>
        /// *葷素{FoodKindName_X:1}：【A：葷食 / B：素食】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmCodeName("CTN_FoodKind", AppDataName.CRR_FoodKind)]
        public const string CRR_FoodKindName_XX = "CRR_FoodKindName_XX";

        /// <summary>
        /// *單位名稱{OrganName:50}：【中正高中】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        public const string CRR_OrganName = "CRR_OrganName";

        /// <summary>
        /// *聯絡電話{Tel:20}：【07-3368333#3097】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        public const string CRR_Tel = "CRR_Tel";

        /// <summary>
        /// *建立者ID(DTN_NID)：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "建立者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string CRR_CreatorId = "CRR_CreatorId";

        /// <summary>
        /// *建立者代號(DTN_NVARCHAR20)：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(AppDataName.CRR_CreatorId, AppDataName.EOE_EmployeeCode)]
        [FdmCodeGen(Title = "建立者代號", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRR_CreatorCode_XX = "CRR_CreatorCode_XX";

        /// <summary>
        /// *建立者姓名(DTN_NVARCHAR20)：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(AppDataName.CRR_CreatorId, AppDataName.EOE_EmployeeName)]
        [FdmCodeGen(Title = "建立者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRR_CreatorName_XX = "CRR_CreatorName_XX";

        /// <summary>
        /// *建立日期(DTN_DATETIME_19)：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "建立日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRR_CreateDate = "CRR_CreateDate";

        /// <summary>
        /// *異動者ID(DTN_NID)：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "異動者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRR_UpdaterId = "CRR_UpdaterId";

        /// <summary>
        /// *異動者姓名(DTN_NVARCHAR20)：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(AppDataName.CRR_UpdaterId, AppDataName.EOE_EmployeeName)]
        [FdmCodeGen(Title = "異動者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRR_UpdaterName_XX = "CRR_UpdaterName_XX";

        /// <summary>
        /// *異動日期(DTN_DATETIME_19)：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "異動日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string CRR_UpdateDate = "CRR_UpdateDate";

        #endregion
    }
}
