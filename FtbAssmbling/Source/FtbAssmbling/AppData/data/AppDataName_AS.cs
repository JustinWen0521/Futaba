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
    /// AS AS400
    /// </summary>
    public partial class AppDataName : FdmDataName
    {
        /// <summary>
        /// &lt;AS>AS400範例
        /// </summary>
        [FdmSystemDef("AS_")]
        public const string AS = "AS";

        #region [AS_Tmp1]
        /// <summary>
        /// &lt;AST>測試 {TMP1}
        /// </summary>
        [FdmTableDef("AST_", AST_TITM,
              //RowInsertUserName = AppDataName.AST_CreatorId,
              //RowInsertDateName = AppDataName.AST_CreateDate,
              //RowModifyUserName = AppDataName.AST_UpdaterId,
              //RowModifyDateName = AppDataName.AST_UpdateDate,
              IsSessionEnable = false)]
        [FdmTableProvider("ftd.dataaccess.AsTmp1Provider,AppService")]
        public const string AS_Tmp1 = "AS_Tmp1";

        /// <summary>
        /// *TITM {DTN_NID}：【PK&lt;AST>】
        /// </summary>
        [FdmStyleType(DTN_NID)]
        public const string AST_TITM = "AST_TITM";

        /// <summary>
        /// * {DTN_NVARCHAR10}：【100】
        /// </summary>
        [FdmStyleType(DTN_NVARCHAR10)]
        public const string AST_TQTY = "AST_TQTY";

        #endregion
    }
}
