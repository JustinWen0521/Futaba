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
    /// 測試
    /// </summary>
    public partial class AppDataName : FdmDataName
    {
        /// <summary>
        /// &lt;WT>/// 測試{Web Task}
        /// </summary>
        [FdmSystemDef("ZZ_")]
        public const string ZZ = "ZZ";

        #region [ZZ_Order]
        /// <summary>
        /// &lt;WTST>訂單{ScheduleTask}
        /// </summary>
        [FdmTableDef("ZZO_", ZZO_OrderId, IsSessionEnable = false,
            RowInsertUserName = ZZO_CreatorId,
            RowInsertDateName = ZZO_CreateDate,
            RowModifyUserName = ZZO_UpdaterId,
            RowModifyDateName = ZZO_UpdateDate
            )]
        [FdmTableProvider("ftd.dataaccess.ZzOrderProvider,AppService")]
        public const string ZZ_Order = "ZZ_Order";

        /// <summary>
        /// *訂單ID {DTN_NID}：【PK&lt;ZZO>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "訂單ID", IsRequired = true, IsUnique = true, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZO_OrderId = "ZZO_OrderId";

        /// <summary>
        /// *訂單號碼{DTN_NVARCHAR10}：【20161022001】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmCodeGen(Title = "訂單號碼", IsRequired = true, IsUnique = true, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZO_OrderNo = "ZZO_OrderNo";

        /// <summary>
        /// *訂單日期{DTN_NVARCHAR50}：【Note7炸彈一支】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_10)]
        [FdmCodeGen(Title = "訂單日期", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = true, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZO_Date = "ZZO_Date";

        /// <summary>
        /// *訂單說明{DTN_NVARCHAR50}：【Note7炸彈一支】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmCodeGen(Title = "訂單說明", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZO_Desc = "ZZO_Desc";

        /// <summary>
        /// *是否啟用{DTN_NVARCHAR1}：【Y：啟用 / N：不啟用】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR1)]
        [FdmCodeGen(Title = "啟用", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZO_IsEnable = "ZZO_IsEnable";

        /// <summary>
        /// *是否啟用{DTN_NVARCHAR10}：【Y：啟用 / N：不啟用】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmCodeName("CTN_APP_IsEnable", ZZO_IsEnable)]
        [FdmCodeGen(Title = "啟用", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZO_IsEnableName_XX = "ZZO_IsEnableName_XX";

        /// <summary>
        /// *訂單總金額{DTN_INTEGER}：【2008/04/01 12:30:40】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        [FdmCodeGen(Title = "訂單總金額", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = true, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZO_OrderAmount_XX = "ZZO_OrderAmount_XX";

        /// <summary>
        /// *建立者ID(DTN_NID)：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "建立者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZO_CreatorId = "ZZO_CreatorId";

        /// <summary>
        /// *建立者姓名(DTN_NVARCHAR20)：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(AppDataName.ZZO_CreatorId, AppDataName.EOE_EmployeeName)]
        [FdmCodeGen(Title = "建立者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ZZO_CreatorName_XX = "ZZO_CreatorName_XX";

        /// <summary>
        /// *建立日期(DTN_DATETIME_19)：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "建立日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ZZO_CreateDate = "ZZO_CreateDate";

        /// <summary>
        /// *異動者ID(DTN_NID)：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "異動者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ZZO_UpdaterId = "ZZO_UpdaterId";

        /// <summary>
        /// *異動者姓名(DTN_NVARCHAR20)：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(AppDataName.ZZO_UpdaterId, AppDataName.EOE_EmployeeName)]
        [FdmCodeGen(Title = "異動者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ZZO_UpdaterName_XX = "ZZO_UpdaterName_XX";

        /// <summary>
        /// *異動日期(DTN_DATETIME_19)：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "異動日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ZZO_UpdateDate = "ZZO_UpdateDate";

        #endregion

        #region [ZZ_OrderDetail]
        /// <summary>
        /// &lt;ZZOD>訂單明細{ZZ_OrderDetail}
        /// </summary>
        [FdmTableDef("ZZOD_", ZZOD_OrderDetailId, IsSessionEnable = false,
            RowInsertUserName = ZZOD_CreatorId,
            RowInsertDateName = ZZOD_CreateDate,
            RowModifyUserName = ZZOD_UpdaterId,
            RowModifyDateName = ZZOD_UpdateDate
            )]
        [FdmTableProvider("ftd.dataaccess.ZzOrderDetailProvider,AppService")]
        public const string ZZ_OrderDetail = "ZZ_OrderDetail";

        /// <summary>
        /// *訂單明細ID {DTN_NID}：【PK&lt;ZZO>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "訂單明細ID", IsRequired = true, IsUnique = true, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ZZOD_OrderDetailId = "ZZOD_OrderDetailId";

        /// <summary>
        /// *訂單ID {DTN_NID}：【PK&lt;ZZO>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "訂單ID", IsRequired = true, IsUnique = true, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ZZOD_OrderId = "ZZOD_OrderId";

        /// <summary>
        /// *訂單號碼{DTN_NVARCHAR10}：【20161022001】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        [FdmLink(ZZOD_OrderId, ZZO_OrderNo)]
        [FdmCodeGen(Title = "訂單號碼", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZOD_OrderNo_XX = "ZZOD_OrderNo_XX";

        /// <summary>
        /// *訂單日期{DTN_NVARCHAR50}：【2016/10/22】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_10)]
        [FdmLink(ZZOD_OrderId, ZZO_Desc)]
        [FdmCodeGen(Title = "訂單日期", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = true, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZOD_OrderDate_XX = "ZZOD_OrderDate_XX";

        /// <summary>
        /// *訂單說明{DTN_NVARCHAR50}：【Note7炸彈一支】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR50)]
        [FdmLink(ZZOD_OrderId, ZZO_Desc)]
        [FdmCodeGen(Title = "訂單說明", IsRequired = true, IsUnique = false, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZOD_OrderDesc_XX = "ZZOD_OrderDesc_XX";

        /// <summary>
        /// *品項{DTN_NVARCHAR20}：【滑鼠】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmCodeGen(Title = "品項", IsRequired = true, IsUnique = true, IsSearch = true, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZOD_Item = "ZZOD_Item";

        /// <summary>
        /// *數量{DTN_INTEGER}：【1】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCodeGen(Title = "數量", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZOD_Qty = "ZZOD_Qty";

        /// <summary>
        /// *單價{DTN_INTEGER}：【1】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCodeGen(Title = "單價", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZOD_UnitPrice = "ZZOD_UnitPrice";

        /// <summary>
        /// *金額{DTN_INTEGER}：【299】
        /// </summary>
        [FdmStyleType(DTN_INTEGER)]
        [FdmCalculate]
        [FdmCodeGen(Title = "金額", IsRequired = true, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZOD_Amount_XX = "ZZOD_Amount_XX";

        /// <summary>
        /// *建立者ID(DTN_NID)：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "建立者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = true, IsCreateVisible = true, IsEditVisible = true)]
        public const string ZZOD_CreatorId = "ZZOD_CreatorId";

        /// <summary>
        /// *建立者姓名(DTN_NVARCHAR20)：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(AppDataName.ZZOD_CreatorId, AppDataName.EOE_EmployeeName)]
        [FdmCodeGen(Title = "建立者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ZZOD_CreatorName_XX = "ZZOD_CreatorName_XX";

        /// <summary>
        /// *建立日期(DTN_DATETIME_19)：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "建立日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ZZOD_CreateDate = "ZZOD_CreateDate";

        /// <summary>
        /// *異動者ID(DTN_NID)：【】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        [FdmCodeGen(Title = "異動者ID", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ZZOD_UpdaterId = "ZZOD_UpdaterId";

        /// <summary>
        /// *異動者姓名(DTN_NVARCHAR20)：【】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR20)]
        [FdmLink(AppDataName.ZZOD_UpdaterId, AppDataName.EOE_EmployeeName)]
        [FdmCodeGen(Title = "異動者姓名", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ZZOD_UpdaterName_XX = "ZZOD_UpdaterName_XX";

        /// <summary>
        /// *異動日期(DTN_DATETIME_19)：【】
        /// </summary>
        [FdmStyleType(DTN_DATETIME_19)]
        [FdmCodeGen(Title = "異動日期", IsRequired = false, IsUnique = false, IsSearch = false, IsSearchRange = false, IsListVisible = false, IsCreateVisible = false, IsEditVisible = false)]
        public const string ZZOD_UpdateDate = "ZZOD_UpdateDate";

        #endregion

    }
}
