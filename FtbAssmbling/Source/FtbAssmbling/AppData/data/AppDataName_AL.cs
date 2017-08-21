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
        /// AL
        /// </summary>        
        [FdmSystemDef("AL_")]
        public const string AL = "AL";

        #region [AL_Assmbling]

        /// <summary>
        /// {T}組立機臺主檔 {AL_Assmbling}
        /// </summary>
        [FdmTableDef("ALA_", AppDataName.ALA_AssmblingId,
              RowInsertUserName = AppDataName.ALA_CreatorId,
              RowInsertDateName = AppDataName.ALA_CreateDate,
              RowModifyUserName = AppDataName.ALA_UpdaterId,
              RowModifyDateName = AppDataName.ALA_UpdateDate,
              IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.AlAssmblingProvider, AppService")]
        [FdmCodeGen(Title = "組立機臺主檔")]
        public const string AL_Assmbling = "AL_Assmbling";

        /// <summary>
        /// *後工程組立ID {DTN_NID}：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "後工程組立ID", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ALA_AssmblingId = "ALA_AssmblingId";

        /// <summary>
        /// *機臺編碼 {DTN_NVARCHAR10}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmCodeGen(Title = "機臺編碼", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALA_MCID = "ALA_MCID";

        /// <summary>
        /// *列位置 {DTN_INTEGER}：【】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCodeGen(Title = "列位置", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALA_SEQRow = "ALA_SEQRow";

        /// <summary>
        /// *行位置 {DTN_INTEGER}：【】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCodeGen(Title = "行位置", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALA_SEQCol = "ALA_SEQCol";

        /// <summary>
        /// *工程代碼 {DTN_NVARCHAR20}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "工程代碼", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALA_MCCode  = "ALA_MCCode";

        /// <summary>
        /// *工程描述 {DTN_NVARCHAR50}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "工程描述", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALA_MCName  = "ALA_MCName";

        /// <summary>
        /// *建立者ID {DTN_NID}：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "建立者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ALA_CreatorId = "ALA_CreatorId";

        /// <summary>
        /// *建立者姓名 {DTN_NVARCHAR20}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "建立者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        [FdmLink(AppDataName.ALA_CreatorId, AppDataName.EOE_EmployeeName)]
        public const string ALA_CreatorName_XX = "ALA_CreatorName_XX";

        /// <summary>
        /// *建立日期 {DTN_DATETIME_19}：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "建立日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ALA_CreateDate = "ALA_CreateDate";

        /// <summary>
        /// *異動者ID {DTN_NVARCHAR1}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmCodeGen(Title = "異動者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ALA_UpdaterId = "ALA_UpdaterId";

        /// <summary>
        /// *異動者姓名 {DTN_NVARCHAR20}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "異動者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        [FdmLink(AppDataName.ALA_UpdaterId, AppDataName.EOE_EmployeeName)]
        public const string ALA_UpdaterName_XX = "ALA_UpdaterName_XX";

        /// <summary>
        /// *異動日期 {DTN_DATETIME_19}：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "異動日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ALA_UpdateDate = "ALA_UpdateDate";

        #endregion

        #region [AL_AssmblingDetail]

        /// <summary>
        /// {T}組立機臺明細 {AL_AssmblingDetail}
        /// </summary>
        [FdmTableDef("ALAD_",
            //RowInsertUserName = AppDataName.ALAD_CreatorId,
            //RowInsertDateName = AppDataName.ALAD_CreateDate,
            //RowModifyUserName = AppDataName.ALAD_UpdaterId,
            //RowModifyDateName = AppDataName.ALAD_UpdateDate,
              IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.AlAssmblingDetailProvider, AppService")]
        [FdmCodeGen(Title = "組立機臺明細")]
        public const string AL_AssmblingDetail = "AL_AssmblingDetail";

        //<summary>
        //*組立機臺明細ID {DTN_NID}：【】
        //</summary>
        //[FdmStyleType(DTN_NID)]
        //[FdmCodeGen(Title = "組立機臺明細ID", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //public const string ALAD_AssmblingDetailId = "ALAD_AssmblingDetailId";

        /// <summary>
        /// *機臺編碼 {DTN_NVARCHAR10}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmCodeGen(Title = "機臺編碼", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALAD_MCID = "ALAD_MCID";

        /// <summary>
        /// *生產階段日期 {DTN_DATETIME_19}：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "生產階段日期", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALAD_DATE = "ALAD_DATE";

        /// <summary>
        /// *品名 {DTN_NVARCHAR20}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "品名", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALAD_ITEM = "ALAD_ITEM";

        /// <summary>
        /// *生產數量 {DTN_DECIMAL}：【】
        /// </summary>
        [FdmStyleType(DTN_DECIMAL)]
        [FdmCodeGen(Title = "生產數量", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALAD_QTY = "ALAD_QTY";

        ///// <summary>
        ///// *建立者ID {DTN_NID}：【】
        ///// </summary>
        //[FdmStyleType(DTN_NID)]
        //[FdmCodeGen(Title = "建立者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //public const string ALAD_CreatorId = "ALAD_CreatorId";

        ///// <summary>
        ///// *建立者姓名 {DTN_NVARCHAR20}：【】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmCodeGen(Title = "建立者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //[FdmLink(AppDataName.ALAD_CreatorId, AppDataName.EOE_EmployeeName)]
        //public const string ALAD_CreatorName_XX = "ALAD_CreatorName_XX";

        ///// <summary>
        ///// *建立日期 {DTN_DATETIME_19}：【】
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //[FdmCodeGen(Title = "建立日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //public const string ALAD_CreateDate = "ALAD_CreateDate";

        ///// <summary>
        ///// *異動者ID {DTN_NVARCHAR1}：【】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR1)]
        //[FdmCodeGen(Title = "異動者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //public const string ALAD_UpdaterId = "ALAD_UpdaterId";

        ///// <summary>
        ///// *異動者姓名 {DTN_NVARCHAR20}：【】
        ///// </summary>
        //[FdmStyleType(DTN_NVARCHAR20)]
        //[FdmCodeGen(Title = "異動者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //[FdmLink(AppDataName.ALAD_UpdaterId, AppDataName.EOE_EmployeeName)]
        //public const string ALAD_UpdaterName_XX = "ALAD_UpdaterName_XX";

        ///// <summary>
        ///// *異動日期 {DTN_DATETIME_19}：【】
        ///// </summary>
        //[FdmStyleType(DTN_DATETIME_19)]
        //[FdmCodeGen(Title = "異動日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        //public const string ALAD_UpdateDate = "ALAD_UpdateDate";

        #endregion

        #region [AL_AssmblingLog]

        /// <summary>
        /// {T}組立機臺主檔Log {AL_AssmblingLog}
        /// </summary>
        [FdmTableDef("ALAL_", AppDataName.ALAL_AssmblingLogId,
              RowInsertUserName = AppDataName.ALAL_CreatorId,
              RowInsertDateName = AppDataName.ALAL_CreateDate,
              RowModifyUserName = AppDataName.ALAL_UpdaterId,
              RowModifyDateName = AppDataName.ALAL_UpdateDate,
              IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.AlAssmblingLogProvider, AppService")]
        [FdmCodeGen(Title = "組立機臺主檔Log")]
        public const string AL_AssmblingLog = "AL_AssmblingLog";

        /// <summary>
        /// *組立機臺主檔LogID {DTN_NID}：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "組立機臺主檔LogID", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ALAL_AssmblingLogId = "ALAL_AssmblingLogId";


        /// <summary>
        /// *後工程組立ID {DTN_NID}：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "後工程組立ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ALAL_AssmblingId = "ALAL_AssmblingId";

        /// <summary>
        /// *機臺編碼 {DTN_NVARCHAR10}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmCodeGen(Title = "機臺編碼", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALAL_MCID = "ALAL_MCID";

        /// <summary>
        /// *列位置 {DTN_INTEGER}：【】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCodeGen(Title = "列位置", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALAL_SEQRow = "ALAL_SEQRow";

        /// <summary>
        /// *行位置 {DTN_INTEGER}：【】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCodeGen(Title = "行位置", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALAL_SEQCol = "ALAL_SEQCol";

        /// <summary>
        /// *有效日期 {DTN_DATETIME_19}：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "有效日期", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALAL_EffectDate = "ALAL_EffectDate";

        /// <summary>
        /// *失效日期 {DTN_DATETIME_19}：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "失效日期", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ALAL_InvalidDate = "ALAL_InvalidDate";

        /// <summary>
        /// *建立者ID {DTN_NID}：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "建立者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ALAL_CreatorId = "ALAL_CreatorId";

        /// <summary>
        /// *建立者姓名 {DTN_NVARCHAR20}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "建立者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        [FdmLink(AppDataName.ALAL_CreatorId, AppDataName.EOE_EmployeeName)]
        public const string ALAL_CreatorName_XX = "ALAL_CreatorName_XX";

        /// <summary>
        /// *建立日期 {DTN_DATETIME_19}：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "建立日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ALAL_CreateDate = "ALAL_CreateDate";

        /// <summary>
        /// *異動者ID {DTN_NVARCHAR1}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmCodeGen(Title = "異動者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ALAL_UpdaterId = "ALAL_UpdaterId";

        /// <summary>
        /// *異動者姓名 {DTN_NVARCHAR20}：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "異動者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        [FdmLink(AppDataName.ALAL_UpdaterId, AppDataName.EOE_EmployeeName)]
        public const string ALAL_UpdaterName_XX = "ALAL_UpdaterName_XX";

        /// <summary>
        /// *異動日期 {DTN_DATETIME_19}：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "異動日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ALAL_UpdateDate = "ALAL_UpdateDate";

        #endregion

    }
}
