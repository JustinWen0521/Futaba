using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using ftd.dataaccess;
using ftd.data;
using ftd.service;
using ftd.nsql;

namespace ftd.web
{
    /// <summary>
    /// Web Session
    /// </summary>
    public class AppUserSession
    {
        /// <summary>
        /// 實例
        /// </summary>
        static public AppUserSession Instance
        {                        
            get 
            {
                if (HttpContext.Current == null)
                    return null;
                if (HttpContext.Current.Session == null)
                    return null;
                return SessionInstance;                
            }            
        }

        /// <summary>
        /// 登入使用者
        /// </summary>
        static public AppLoginUser User
        {
            get 
            {
                if (Instance == null)
                    return null;
                return Instance.LoginUser; 
            }
        }

        /// <summary>
        /// Instance放置於Session
        /// </summary>
        private static AppUserSession SessionInstance
        {
            get 
            {
                const string SessionName = "AppUserSession.Instance";
                if (HttpContext.Current.Session[SessionName] == null)
                {
                    var session = new AppUserSession();
                    HttpContext.Current.Session[SessionName] = session;

                    //設定登入者
                    if (!HttpContext.Current.User.Identity.IsAuthenticated)
                        session.loginUser(AppLoginUser.GuestUserId);
                    else
                    {
                        var userId = HttpContext.Current.User.Identity.Name;
                        session.loginUser(userId);
                    }                    
                }
                return (AppUserSession)HttpContext.Current.Session[SessionName];
            }
        }        

        /// <summary>
        /// 使用者是否已登入
        /// </summary>
        public bool IsUserLogin
        {
            get 
            {
                return LoginUser.IsGuest == false;
            }
        }

        /// <summary>
        /// 登入使用者
        /// </summary>
        public AppLoginUser LoginUser
        {
            get;
            private set;
        }

        private string _currentFunc = "";
        /// <summary>
        /// 目前執行程式
        /// </summary>
        public string CurrentFunc
        {
            get
            {
                return _currentFunc;
            }
            set
            {
                _currentFunc = value;

                if (User == null)
                {
                    return;
                }

                if (User.UserMenu == null || User.UserMenu.RootNode == null || User.UserMenu.RootNode.ChildNodes == null || User.UserMenu.RootNode.ChildNodes.Count < 1)
                {
                    return;
                }

                if (value == null || "".equalIgnoreCase(value.Trim()))
                {
                    return;
                }

                var item = User.UserMenu.findeNodeByAttr("itemNo", value);
                var chkNodeIdList = new List<string>();
                while (item != null)
                {
                    chkNodeIdList.Add(item.ID);
                    item = item.Parent;
                }
                //do
                //{
                //    chkNodeIdList.Add(item.ID);
                //    item = item.Parent;
                //} while (item != null);

                this.CurrentFuncHier = chkNodeIdList;
            }
        }

        public List<string> CurrentFuncHier
        {
            get;
            set;
        }

        /// <summary>
        /// 會員登入
        /// </summary>
        public void loginUser(string userId)
        {
            var qry = new NsDmQuery();

            //Guest登入
            if (userId == AppLoginUser.GuestUserId)
            {
                var usr = new AppLoginUser();
                usr.UserId = userId;
                usr.UserName = "GUEST";
                usr.UserPermission = FtdPermissionService.Instance.getActorPermission(usr.UserId);
                usr.TitleName = "訪客";
                usr.TitleCode = "";
                usr.GridAllowPaging = bool.Parse(FtdConfigService.Instance.getAppSettingValue("FwbUiService.GridAllowPaging", "true"));
                usr.MachineCode = FtdConfigService.Instance.getAppSettingValue("MachineCode", "true");
                //usr.UrlGIS = FtdConfigService.Instance.getAppSettingValue("URL_GIS", "");
                //usr.UrlKmWs = FtdConfigService.Instance.getAppSettingValue("URL_KMWS", "");
                //usr.UrlKmEntry = FtdConfigService.Instance.getAppSettingValue("URL_KMEntry", "");
                //usr.IsControlled = false;
                LoginUser = usr;

                return;
            }
            //有帳號的會員登入
            else
            {                
                var t1 = qry.from<EO_Employee>();
                qry.selectAll(
                    t1.AllDirect
                );
                qry.Where = t1.EOE_EmployeeId == userId.toConstReq1();
                var dt = (EO_EmployeeDataTable)qry.queryData();
                var rowusr = dt.FirstRow;
                if (rowusr == null)
                    return;

                var usr = new AppLoginUser();
                usr.LoginAccount = rowusr.EOE_LoginAccount_XX;
                usr.UserId = rowusr.EOE_EmployeeId;
                usr.UserName = rowusr.EOE_EmployeeName;
                usr.TitleCode = rowusr.EOE_EmployeeTitleCode_XX;
                usr.TitleName = rowusr.EOE_EmployeeTitleName_XX;
                usr.DepartmentId = rowusr.EOE_DepartmentId;
                usr.DepartmentName = rowusr.EOE_DepartmentName_XX;
                //usr.IsOrganManager = rowusr.EOE_IsOrganManager;
                //usr.OrganId = rowusr.EOE_OrganId;
                //usr.OrganSName = rowusr.EOE_OrganSName_XX;
                //usr.OrganAName = rowusr.EOE_OrganAName_XX;
                //usr.OrganShortId = rowusr.EOE_OrganShortId_XX;
                //usr.StoreLoc = rowusr.EOE_OrganStoreLoc_XX;
                //usr.IsCity = rowusr.EOE_OrganTitle_XX;
                //usr.IsEnterpriseLimit = rowusr.EOE_EnterpriseLimit_XX;
                //usr.IsOfficialLimit = rowusr.EOE_OfficialLimit_XX;
                //usr.UnitName = rowusr.EOE_UnitName;
                usr.Phone1 = rowusr.EOE_Phone1;
                usr.Phone2 = rowusr.EOE_Phone2;
                usr.Email = rowusr.EOE_EmployeeEmail;

                usr.GridAllowPaging = bool.Parse(FtdConfigService.Instance.getAppSettingValue("FwbUiService.GridAllowPaging", "true"));
                
                usr.UserPermission = FtdPermissionService.Instance.getActorPermission(usr.UserId);
                
                #region //找出父、子階部門id
                //var dtDept = NsDmHelper.EO_Department
                //    .selectAll()
                //    .query();

                //#region //找父階部門id
                //List<string> parentIds = new List<string>();
                //Action<string, List<string>> gerParentIdFunc = null;
                //gerParentIdFunc = (deptId, ids) =>
                //{
                //    var dept = dtDept.Where(x => x.EOD_DepartmentId == deptId).FirstOrDefault();
                //    if (dept == null || dept.EOD_ParentId.isNullOrEmpty())
                //        return;

                //    ids.Add(dept.EOD_ParentId);
                //    gerParentIdFunc(dept.EOD_ParentId, ids);
                //};
                //gerParentIdFunc(usr.DepartmentId, parentIds);
                //#endregion

                //#region //找子階部門id
                //List<string> childIds = new List<string>();
                //Action<string, List<string>> gerChildIdFunc = null;
                //gerChildIdFunc = (deptId, ids) =>
                //{
                //    var depts = dtDept.Where(x => x.EOD_ParentId == deptId);
                //    if (depts == null || depts.Count() == 0)
                //        return;

                //    foreach (var d in depts)
                //    {
                //        ids.Add(d.EOD_DepartmentId);
                //        gerChildIdFunc(d.EOD_DepartmentId, ids);
                //    }
                //};
                //gerChildIdFunc(usr.DepartmentId, childIds);
                //#endregion

                //if (parentIds.Count > 0)
                //    usr.ParentDeptId = parentIds[0];
                //else
                //    usr.ParentDeptId = "";

                //usr.ParentDeptIds = parentIds.ToArray();
                //usr.ChildDeptIds = childIds.ToArray();
                #endregion

                usr.MachineCode = FtdConfigService.Instance.getAppSettingValue("MachineCode", "true");
                //usr.UrlGIS = FtdConfigService.Instance.getAppSettingValue("URL_GIS", "");
                //usr.UrlGISLink = FtdConfigService.Instance.getAppSettingValue("URL_GISLink", "");
                //usr.UrlKmWs = FtdConfigService.Instance.getAppSettingValue("URL_KMWS", "");
                //usr.UrlKmEntry = FtdConfigService.Instance.getAppSettingValue("URL_KMEntry", "");
                LoginUser = usr;
                usr.UserMenu = EoDataService.Instance.getUserMenus(rowusr.EOE_EmployeeId);

                var userMenu = usr.UserMenu;
                var xmlMenuNodes = userMenu.selectNodes(node => true
                    //, new[] { "itemNo", "class", "title" }
                );
                usr.UserFunctions = xmlMenuNodes;

                var dicUsrFunPermSet = EoDataService.Instance.queryUserFunPermSet(usr.UserId, "EOM_MAINMENU");
                usr.UserFunPermSet = dicUsrFunPermSet;

                //是否管控中
                //int cntPM = PmDataService.Instance.PmControlCase_getExpiredCount(usr.OrganId);
                //usr.IsControlled = (cntPM > 0);
            }
        }

        ///// <summary>
        ///// 會員登出
        ///// </summary>
        //public void logoutUser()
        //{
        //   loginUser(AppLoginUser.GuestUserId);
        //}    

        private AppUserSession()
        {
        }

        //public string getStoreLoc(ref string orgId, bool checkPermission = true)
        //{
        //    if (orgId.isNullOrEmpty())
        //        orgId = AppUserSession.User.OrganId;

        //    if (orgId.equalIgnoreCase(AppUserSession.User.OrganId))
        //        return AppUserSession.User.StoreLoc;

        //    var orgId2 = orgId;
        //    SY_OrganRow org = null;
        //    //不檢查權限
        //    if (!checkPermission)
        //    {
        //        org = NsDmHelper.SY_Organ
        //            .select(t => t.SYO_StoreLoc)
        //            .where(t =>
        //                t.SYO_OrganId == orgId2.toConstReq1()
        //            )
        //            .queryFirst();

        //        if (org == null)
        //            return "";

        //        return org.SYO_StoreLoc;
        //    }

        //    //是否為系統管理權限
        //    bool isAdmin = AppUserSession.User.IsOrganManager.equalIgnoreCase("A");
        //    //是否為上層機關
        //    bool isManager = AppUserSession.User.IsOrganManager.equalIgnoreCase("Y");
        //    if (!isAdmin && !isManager)
        //    {
        //        orgId = AppUserSession.User.OrganId;
        //        return AppUserSession.User.StoreLoc;
        //    }

        //    //上層機關-->可查詢下屬機關
        //    var orgIdPrefix = "";
        //    if (isManager)
        //    {
        //        orgIdPrefix = AppUserSession.User.OrganId.Substring(0, 5);
        //        if (!orgIdPrefix.equalIgnoreCase(orgId.Substring(0,5)))
        //        {
        //            orgId = AppUserSession.User.OrganId;
        //            return AppUserSession.User.StoreLoc;
        //        }
        //        //orgIdPrefix += "%";
        //    }

        //    org = NsDmHelper.SY_Organ
        //        .select(t => t.SYO_StoreLoc)
        //        .where(t =>
        //            t.SYO_OrganId == orgId2.toConstReq1()
        //            //& t.SYO_OrganId.like(orgIdPrefix.toConstOpt1())
        //        )
        //        .queryFirst();

        //    if (org == null)
        //        return "";

        //    return org.SYO_StoreLoc;
        //}

        public string replaceVariables(string data)
        {
            //UserId
            data = data.Replace("{UserId}", User.UserId);
            
            //UserCode
            data = data.Replace("{UserCode}", User.LoginAccount);

            //OrgId
            //data = data.Replace("{OrgId}", User.OrganId);

            return data;
        }
    }
}
