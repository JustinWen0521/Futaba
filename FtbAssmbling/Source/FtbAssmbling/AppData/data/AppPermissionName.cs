using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Collections.Generic;
using System.Diagnostics;
using ftd.dataaccess;
using ftd.data;

namespace ftd.data
{
    /// <summary>
    /// 權限項目名稱
    /// </summary>
    public class AppPermissionName
    {
        #region [系統]
        /// <summary>
        /// 系統管理員
        /// </summary>
        [FtdPermissionInclude("APN_.*")]
        public const string APN_APP_SystemAdmin = "APN_APP_SystemAdmin";
        /// <summary>
        /// 
        /// </summary>
        [FtdPermissionInclude("APN_APP_Item.*,APN_APP_QueryItems")]
        public const string APN_APP_GeneralUse = "APN_APP_GeneralUse";
        /// <summary>
        /// 
        /// </summary>
        public const string APN_APP_ItemView = "APN_APP_ItemView";
        /// <summary>
        /// 
        /// </summary>
        public const string APN_APP_ItemUpdate = "APN_APP_ItemUpdate";
        /// <summary>
        /// 
        /// </summary>
        public const string APN_APP_ItemDelete = "APN_APP_ItemDelete";
        /// <summary>
        /// 
        /// </summary>
        public const string APN_APP_ItemNew = "APN_APP_ItemNew";
        /// <summary>
        /// 
        /// </summary>
        public const string APN_APP_ItemReply = "APN_APP_ItemReply";
        /// <summary>
        /// 
        /// </summary>
        public const string APN_APP_QueryItems = "APN_APP_QueryItems";
        #endregion    
     
        #region [企業組織]
        /// <summary>
        /// 系統\企業組織\系統管理員
        /// </summary>
        [FtdPermissionInclude("APN_EO_.*")]
        public const string APN_EO_SystemAdmin = "APN_EO_SystemAdmin";

        /// <summary>
        /// 系統\企業組織\一般使用權 
        /// </summary>
        public const string APN_EO_GeneralUse = "APN_EO_GeneralUse";

        #endregion     

        #region [EMS]
        /// <summary>
        /// EMS\平面配置圖\檢視權限
        /// 可檢視指定的配置圖
        /// </summary>        
        [FtdPermissionObjectNeed()]
        public const string APN_EM_LayoutView = "APN_EM_LayoutView";

        /// <summary>
        /// EMS\平面配置圖\管理權限
        /// 可管理指定的配置圖
        /// </summary>        
        [FtdPermissionObjectNeed()]
        [FtdPermissionInclude(APN_EM_LayoutView)]
        public const string APN_EM_LayoutManager = "APN_EM_LayoutManager";
       
        #endregion 
    }
}
