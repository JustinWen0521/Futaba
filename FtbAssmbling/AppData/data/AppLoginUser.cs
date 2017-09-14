using System;
using System.Data;
using System.Configuration;
using ftd.dataaccess;
using ftd.data;
using System.Diagnostics;
using System.Collections.Generic;
using ftd.service;
using ftd.nsql;

namespace ftd.data
{
    /// <summary>
    /// 系統登入者
    /// </summary>
    public class AppLoginUser
    {
        public const string GuestUserId = "GuestUserId";

        public AppLoginUser()
        {
        }

        /// <summary>
        /// 使用者擁有的權限
        /// </summary>
        public FtdActorPermission UserPermission
        {
            get;
            set;
        }

        /// <summary>
        /// 使用者的功能選單(樹狀結構)
        /// </summary>
        public FtdXmlMenu UserMenu 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 使用者的功能清單(List)
        /// </summary>
        public List<FtdXmlMenuNode> UserFunctions 
        { 
            get; 
            set; 
        }

        /// <summary>
        /// 使用者的程式功能清單(List)
        /// </summary>
        public Dictionary<string, Dictionary<string, string>> UserFunPermSet
        {
            get;
            set;
        }

        /// <summary>
        /// ID
        /// </summary>
        public string UserId
        {
            get;
            set;
        }

        /// <summary>
        /// 登入帳號
        /// </summary>
        public string LoginAccount
        {
            get;
            set;
        }

        /// <summary>
        /// 姓名
        /// </summary>
        public string UserName
        {
            get;
            set;
        }

        /// <summary>
        /// 身份代碼
        /// </summary>
        public string TitleCode
        {
            get;
            set;
        }

        /// <summary>
        /// 身份名稱
        /// </summary>
        public string TitleName
        {
            get;
            set;
        }

        /// <summary>
        /// 機關ID
        /// </summary>
        public string DepartmentId
        {
            get;
            set;
        }

        /// <summary>
        /// 機關名稱
        /// </summary>
        public string DepartmentName
        {
            get;
            set;
        }

        ///// <summary>
        ///// 單位名稱
        ///// </summary>
        //public string UnitName
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 電話1
        /// </summary>
        public string Phone1
        {
            get;
            set;
        }

        /// <summary>
        /// 電話2
        /// </summary>
        public string Phone2
        {
            get;
            set;
        }

        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsSysAdmin
        {
            get
            {
                if (containsPermission(AppPermissionName.APN_APP_SystemAdmin))
                    return true;
                else
                    return false;
            }
        }

        /// <summary>
        /// 父階機關ID
        /// </summary>
        public string ParentDeptId
        {
            get;
            set;
        }

        /// <summary>
        /// 父階機關IDs
        /// </summary>
        public string[] ParentDeptIds
        {
            get;
            set;
        }

        /// <summary>
        /// 子階機關IDs
        /// </summary>
        public string[] ChildDeptIds
        {
            get;
            set;
        }

        /// <summary>
        /// 可查詢的機關IDs
        /// (自己部門+父部門+子部門)
        /// </summary>
        public string[] AvaliableDeptIds 
        {
            get
            {
                List<string> deptIds = new List<string>();
                deptIds.Add(DepartmentId);
                deptIds.AddRange(ParentDeptIds);
                deptIds.AddRange(ChildDeptIds);
                return deptIds.ToArray();
            }
        }

        ///// <summary>
        ///// 目前年度Id(使用者檢視)
        ///// </summary>
        //public string WM_YearId
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 目前年度名稱(使用者檢視)
        ///// </summary>
        //public string WM_YearName
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 目前資料是否可修正(如果使用者選擇是目前年度)
        ///// </summary>
        //public bool WM_IsModifyable
        //{
        //    get { return WM_SysYearId == WM_YearId; }
        //}

        ///// <summary>
        ///// 目前年度Id(系統)
        ///// </summary>
        //public string WM_SysYearId
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 目前年度名稱(系統)
        ///// </summary>
        //public string WM_SysYearName
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// Grid是否
        /// </summary>
        public bool GridAllowPaging
        {
            get; //{ return bool.Parse(FtdConfigService.Instance.getAppSettingValue("FwbUiService.WindowDebugMode", "true")); }
            set;
        }

        /// <summary>
        /// 是否是訪客
        /// </summary>
        public bool IsGuest
        {
            get { return UserId == GuestUserId; }
        }

        /// <summary>
        /// 是否擁有指定的權限
        /// </summary>
        public bool containsPermission(string permissionName)
        {
            if (UserPermission == null)
                return false;
            return UserPermission.containPermisson(permissionName);
        }

        /// <summary>
        /// 是否擁有指定物件指定的權限
        /// </summary>
        public bool containObjectPermission(string objectId, string permissionName)
        {
            if (UserPermission == null)
                return false;
            return UserPermission.containObjectPermission(objectId, permissionName);
        }

        ///// <summary>
        ///// GIS URL (首頁)
        ///// </summary>
        //public string UrlGIS
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// GIS Link URL (土地標示定位查詢)
        ///// </summary>
        //public string UrlGISLink
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// KM Web Service URL
        ///// </summary>
        //public string UrlKmWs
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// KM Entry URL
        ///// </summary>
        //public string UrlKmEntry
        //{
        //    get;
        //    set;
        //}

        /// <summary>
        /// 機碼
        /// </summary>
        public string MachineCode
        {
            get;
            set;
        }

        ///// <summary>
        ///// Partition 位置
        ///// </summary>
        //public string StoreLoc
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 機關代碼
        ///// </summary>
        //public string OrganId
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 機關簡稱
        ///// </summary>
        //public string OrganSName
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 機關全銜
        ///// </summary>
        //public string OrganAName
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 機關簡碼
        ///// </summary>
        //public string OrganShortId
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// IsOrganManager權限角色
        ///// </summary>
        //public string IsOrganManager
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// IsCity
        ///// </summary>
        //public string IsCity
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// IsEnterpriseLimit
        ///// </summary>
        //public string IsEnterpriseLimit
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// IsEnterpriseLimit
        ///// </summary>
        //public string IsOfficialLimit
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 是否案件管控中
        ///// </summary>
        //public bool IsControlled
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 取得登入者所管理的(機關)_公用系統
        ///// </summary>
        //public List<string> ManagedData
        //{
        //    get
        //    {
        //        return GetManageData(" ");
        //    }
        //}

        //private List<string> GetManageData(string type)
        //{
        //    List<string> returnList = new List<string>();

        //    var qry = (NsDbQuery)null;
        //    var dt = (DataTable)null;

        //    //管區管理機關ID
        //    qry = new NsDbQuery();
        //    qry.setSelect(s =>
        //    {
        //        var t1 = s.from<SY_Organ>();
        //        s.Where = t1.SYO_DistrictId == this.UserId.toConstReq1();
        //        s.select(t1.SYO_OrganId);
        //    });
        //    dt = qry.queryData();

        //    if (dt != null && dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            returnList.Add(dr[0].ToString());
        //        }
        //    }

        //    return returnList;
        //}
    }
}
