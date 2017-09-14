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
    /// Windows Form系統登入者
    /// </summary>
    [Serializable]
    public class AppWinLoginUser
    {
        public const string GuestUserId = "GuestUserId";

        public AppWinLoginUser()
        {
        }

        ///// <summary>
        ///// 使用者擁有的權限
        ///// </summary>
        //public FtdActorPermission UserPermission
        //{
        //    get;
        //    set;
        //}

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
        /// 登入密碼
        /// </summary>
        public string LoginPwd
        {
            get;
            set;
        }

        /// <summary>
        /// 代號
        /// </summary>
        public string UserCode
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
        /// 機關代號
        /// </summary>
        public string DepartmentCode
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
            //get
            //{
            //    List<string> deptIds = new List<string>();
            //    deptIds.Add(DepartmentId);
            //    deptIds.AddRange(ParentDeptIds);
            //    deptIds.AddRange(ChildDeptIds);
            //    return deptIds.ToArray();
            //}
            get;
            set;
        }

        /// <summary>
        /// 目前年度Id(使用者檢視)
        /// </summary>
        public string Data_YearId
        {
            get;
            set;
        }

        /// <summary>
        /// 目前資料是否可修正(如果使用者選擇是目前年度)
        /// </summary>
        public bool Data_IsModifyable
        {
            get { return Data_SysYearId == Data_YearId; }
        }

        /// <summary>
        /// 目前年度名稱(使用者檢視)
        /// </summary>
        public string Data_YearName
        {
            get;
            set;
        }

        /// <summary>
        /// 目前年度Id(系統)
        /// </summary>
        public string Data_SysYearId
        {
            get;
            set;
        }

        /// <summary>
        /// 目前年度名稱(系統)
        /// </summary>
        public string Data_SysYearName
        {
            get;
            set;
        }

        /// <summary>
        /// 是否是訪客
        /// </summary>
        public bool IsGuest
        {
            get { return UserId == GuestUserId; }
        }

        ///// <summary>
        ///// 使用者功能選單
        ///// </summary>
        //public FtdXmlMenu UserMenu
        //{
        //    get;
        //    set;
        //}

        ///// <summary>
        ///// 是否擁有指定的權限
        ///// </summary>
        //public bool containsPermission(string permissionName)
        //{
        //    if (UserPermission == null)
        //        return false;
        //    return UserPermission.containPermisson(permissionName);           
        //}

        ///// <summary>
        ///// 是否擁有指定物件指定的權限
        ///// </summary>
        //public bool containObjectPermission(string objectId, string permissionName)
        //{
        //    if (UserPermission == null)
        //        return false;
        //    return UserPermission.containObjectPermission(objectId, permissionName);
        //}
    }
}
